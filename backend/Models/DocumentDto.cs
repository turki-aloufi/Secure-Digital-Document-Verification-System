namespace backend.Models
{
  public class DocumentDto
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string FilePath { get; set; }
    public string VerificationCode { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}
