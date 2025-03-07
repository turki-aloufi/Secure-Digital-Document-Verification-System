// Controllers/VerificationController.cs
using backend.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

[Route("api/document/verify")]
[ApiController]
public class VerificationController : ControllerBase
{
    private readonly string _connectionString;

    public VerificationController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    // POST /api/verify - Verify a document using VerificationCode
    [HttpPost]
    public async Task<IActionResult> VerifyDocument([FromBody] VerifyDocumentDto verifyDto)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            // Check if document exists with the given VerificationCode
            var documentQuery = "SELECT Id, Status FROM Documents WHERE VerificationCode = @VerificationCode";
            var document = await connection.QueryFirstOrDefaultAsync<dynamic>(
                documentQuery,
                new { VerificationCode = verifyDto.VerificationCode });

            if (document == null)
                return NotFound("Document not found with the provided verification code.");

            // Update document status
            var updateQuery = "UPDATE Documents SET Status = @Status WHERE Id = @Id";
            await connection.ExecuteAsync(updateQuery, new { Status = verifyDto.Status, Id = document.Id });

            // Log the verification
            var logQuery = @"
                INSERT INTO VerificationLogs (DocumentId, VerifiedBy, Timestamp, Status)
                VALUES (@DocumentId, @VerifiedBy, @Timestamp, @Status)";
            await connection.ExecuteAsync(logQuery, new
            {
                DocumentId = document.Id,
                VerifiedBy = verifyDto.VerifiedBy,
                Timestamp = DateTime.UtcNow,
                Status = verifyDto.Status
            });

            return Ok(new { Message = "Document verified successfully", VerificationCode = verifyDto.VerificationCode });
        }
    }
}