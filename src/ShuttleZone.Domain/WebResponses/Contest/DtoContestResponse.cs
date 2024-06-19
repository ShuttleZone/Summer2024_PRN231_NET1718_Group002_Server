using System.Collections;
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
    public ReservationDto? Reservation { get; set; }
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

public record ReservationDto
{
    public DateTime BookingDate { get; set; }
    public double TotalPrice { get; set; }
    public ICollection<ReservationDetailsDto> ReservationDetailsDtos { get; set; } = new List<ReservationDetailsDto>();
}   

public record ReservationDetailsDto{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public double Price { get; set; }
    
    public CourtDto? Court { get; set; }
}

public record CourtDto
{
    public string? Name { get; set; }
    public CourtType CourtType { get; set; }
    public CourtStatus CourtStatus { get; set; }
    public ClubDto? Club { get; set; } 

}

public record ClubDto
{
    public required string ClubName { get; set; }
    public required string ClubAddress { get; set; }
    public required string ClubPhone { get; set; }
    public required string ClubDescription { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    
} 