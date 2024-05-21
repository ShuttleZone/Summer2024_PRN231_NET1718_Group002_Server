namespace ShuttleZone.Domain.Entities;

public class UserContest
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
    
    public Guid ContestId { get; set; }
    public Contest? Contest { get; set; }
    
    public bool isCreatedPerson { get; set; }
    public bool isWinner { get; set; }
    public int Point { get; set; }
}