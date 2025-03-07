namespace backend.Models
{
  public class VerifyDocumentDto
  {
    public string VerificationCode { get; set; }
    public int VerifiedBy { get; set; } 
    public string Status { get; set; }
  }
}