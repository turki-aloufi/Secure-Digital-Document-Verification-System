namespace backend.Models
{
  public class UploadDocumentDto
  {
    public string Title { get; set; }
    public IFormFile File { get; set; } // For file upload
  }

}