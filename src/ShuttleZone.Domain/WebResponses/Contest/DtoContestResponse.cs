using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebResponses.Contest;

public class DtoContestResponse
{
    public Guid Id { get; set; }
    public DateTime ContestDate { get; set; }
    public int MaxPlayer { get; set; }
    public string? Policy { get; set; }
    public ContestStatusEnum ContestStatus { get; set; }
    
    public List<User> Participants = new List<User>();

    
    public class DtoUserContestResponse
    {
        public Guid ParticipantsId { get; set; }
        public Guid ContestId { get; set; }
    
        public bool isCreatedPerson { get; set; }
        public bool isWinner { get; set; }
        public int Point { get; set; }
    }
}