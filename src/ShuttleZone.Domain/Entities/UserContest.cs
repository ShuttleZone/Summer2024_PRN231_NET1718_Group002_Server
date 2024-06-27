namespace ShuttleZone.Domain.Entities;

public class UserContest 
{
    public Guid ParticipantsId { get; set; }
    public User Participant { get; set; } = null!;
    
    public Guid ContestId { get; set; }
    public Contest Contest { get; set; } = null!;

    public bool isCreatedPerson { get; set; } = false;
    public bool isWinner { get; set; } = false;
    public int Point { get; set; } = 0;
}
