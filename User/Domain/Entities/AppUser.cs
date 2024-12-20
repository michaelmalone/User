namespace User.Domain
{
    public class AppUser : AuditableEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
