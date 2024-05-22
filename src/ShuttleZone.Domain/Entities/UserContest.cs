namespace ShuttleZone.Domain.Entities;

public class UserContest 
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
    
    public Guid ContestId { get; set; }
    public Contest Contest { get; set; } = null!;
    
    
}