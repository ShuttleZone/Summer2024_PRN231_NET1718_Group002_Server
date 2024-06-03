using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebResponses.Contest;

public record DtoContestResponse
{
    public Guid Id { get; set; }
    public DateTime ContestDate { get; set; }
    public int MaxPlayer { get; set; }
    public string? Policy { get; set; }
    public ContestStatusEnum ContestStatus { get; set; }
    public ICollection<UserContestDto> UserContests { get; set; } = new List<UserContestDto>() ;
}

public record UserContestDto
{
    public Guid ContestId { get; set; }
    public Guid ParticipantsId { get; set; }
    public bool isCreatedPerson { get; set; }
    public bool isWinner { get; set; }
    public int Point { get; set; }
    
    public User? Participant { get; set; }
    
    public string? Fullname { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public int? Gender { get; set; }

}