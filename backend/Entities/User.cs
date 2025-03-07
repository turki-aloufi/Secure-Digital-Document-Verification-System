namespace backend.Entities
{
  public class User
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }  // Should be hashed in production
    public string Role { get; set; }      // e.g., "User", "Admin", "Verifier"

    // Navigation property
    public ICollection<Document> Documents { get; set; }
  }
}