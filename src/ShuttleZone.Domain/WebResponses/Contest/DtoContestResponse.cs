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

    public List<UserContestDTO> Participants { get; set; } = new List<UserContestDTO>();

    
    public class UserContestDTO
    {
        public Guid Id { get; set; }
        public string? Fullname { get; set; }
        public int Gender { get; set; }
        public UserStatusEnum UserStatusEnum { get; set; }
        public bool IsCreatedPerson { get; set; }
        public bool IsWinner { get; set; }
        public int Point { get; set; }
    }
    
}