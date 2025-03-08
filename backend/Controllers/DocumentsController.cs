using backend.Entities;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class DocumentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DocumentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // POST /api/documents - Upload a document & generate VerificationCode
    [HttpPost]
    public async Task<IActionResult> UploadDocument([FromForm] UploadDocumentDto uploadDto)
    {
        if (uploadDto.File == null || uploadDto.File.Length == 0)
            return BadRequest("No file uploaded.");

        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        var filePath = Path.Combine(uploadsFolder, uploadDto.File.FileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await uploadDto.File.CopyToAsync(stream);
        }

        var verificationCode = Guid.NewGuid().ToString("N").Substring(0, 12);

        var document = new Document
        {
            UserId = 1, // Replace with actual authenticated user ID
            Title = uploadDto.Title,
            FilePath = filePath,
            VerificationCode = verificationCode,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };

        _context.Documents.Add(document);
        await _context.SaveChangesAsync();

        var documentDto = new DocumentDto
        {
            Id = document.Id,
            Title = document.Title,
            FilePath = document.FilePath,
            VerificationCode = document.VerificationCode,
            Status = document.Status,
            CreatedAt = document.CreatedAt
        };

        return CreatedAtAction(nameof(GetDocument), new { id = document.Id }, documentDto);
    }

    // GET /api/documents/{id} - Retrieve document details
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDocument(int id)
    {
        var document = await _context.Documents
            .Select(d => new DocumentDto
            {
                Id = d.Id,
                Title = d.Title,
                FilePath = d.FilePath,
                VerificationCode = d.VerificationCode,
                Status = d.Status,
                CreatedAt = d.CreatedAt
            })
            .FirstOrDefaultAsync(d => d.Id == id);

        if (document == null)
            return NotFound();

        return Ok(document);
    }

    // NEW: GET /api/documents - Retrieve all documents
    [HttpGet]
    public async Task<IActionResult> GetAllDocuments()
    {
        var documents = await _context.Documents
            .Select(d => new DocumentDto
            {
                Id = d.Id,
                Title = d.Title,
                FilePath = d.FilePath,
                VerificationCode = d.VerificationCode,
                Status = d.Status,
                CreatedAt = d.CreatedAt
            })
            .ToListAsync();

        return Ok(documents);
    }
}