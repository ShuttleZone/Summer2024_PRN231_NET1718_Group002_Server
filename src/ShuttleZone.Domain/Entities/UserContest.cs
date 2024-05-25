namespace ShuttleZone.Domain.Entities;

public class UserContest 
{
    public Guid ParticipantsId { get; set; }
    public Guid ContestId { get; set; }
    
    public bool isCreatedPerson { get; set; }
    public bool isWinner { get; set; }
    public int Point { get; set; }
}
