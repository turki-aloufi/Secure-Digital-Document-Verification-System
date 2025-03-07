namespace backend.Entities
{
  public class VerificationLog
  {
    public int Id { get; set; }
    public int DocumentId { get; set; }
    public int VerifiedBy { get; set; }  // UserId of verifier
    public DateTime Timestamp { get; set; }
    public string Status { get; set; }

    // Navigation properties
    public Document Document { get; set; }
    public User Verifier { get; set; }
  }
}