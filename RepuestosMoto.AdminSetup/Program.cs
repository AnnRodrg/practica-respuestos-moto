// Programa de consola .NET para crear el usuario administrador seguro.
// Paquetes: Microsoft.Data.SqlClient y Microsoft.Extensions.Identity.Core
// Variables de entorno: REPUESTOSMOTO_CONNECTION y REPUESTOSMOTO_ADMIN_PASSWORD
// Ejecutar despues de 06A y antes de 06B.

using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System.Data;

var connectionString = Environment.GetEnvironmentVariable("REPUESTOSMOTO_CONNECTION");
var password = Environment.GetEnvironmentVariable("REPUESTOSMOTO_ADMIN_PASSWORD");

if (string.IsNullOrWhiteSpace(connectionString))
    throw new InvalidOperationException("Falta REPUESTOSMOTO_CONNECTION.");
if (string.IsNullOrWhiteSpace(password) || password.Length < 14 ||
    !password.Any(char.IsUpper) || !password.Any(char.IsLower) ||
    !password.Any(char.IsDigit) || !password.Any(c => !char.IsLetterOrDigit(c)))
    throw new InvalidOperationException("La contraseña debe tener al menos 14 caracteres, mayúscula, minúscula, número y símbolo.");

var hasher = new PasswordHasher<string>();
var hash = hasher.HashPassword("admin", password);

await using var connection = new SqlConnection(connectionString);
await connection.OpenAsync();
await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync();
try
{
    await using var command = new SqlCommand(@"
DECLARE @EmpleadoId INT = (SELECT EmpleadoId FROM dbo.Empleado WHERE CodigoEmpleado='EMP-001');
DECLARE @RolId INT = (SELECT RolId FROM dbo.Rol WHERE Nombre=N'Administrador');
IF @EmpleadoId IS NULL OR @RolId IS NULL
    THROW 51004, 'Primero ejecute el archivo 06A.', 1;
IF EXISTS (SELECT 1 FROM dbo.Usuario WHERE NombreUsuario='admin')
    THROW 51005, 'La cuenta admin ya existe; no se sobrescribira.', 1;
INSERT dbo.Usuario (EmpleadoId,NombreUsuario,PasswordHash,RequiereCambioPassword,Activo)
VALUES (@EmpleadoId,'admin',@Hash,1,1);
DECLARE @UsuarioId INT = CONVERT(INT,SCOPE_IDENTITY());
INSERT dbo.UsuarioRol (UsuarioId,RolId) VALUES (@UsuarioId,@RolId);", connection, transaction);
    command.Parameters.Add("@Hash", SqlDbType.NVarChar, 500).Value = hash;
    await command.ExecuteNonQueryAsync();
    await transaction.CommitAsync();
    Console.WriteLine("Administrador creado. Cambie la contraseña en el primer inicio de sesión.");
}
catch
{
    await transaction.RollbackAsync();
    throw;
}
