namespace ShuttleZone.Domain.WebRequests;

public record CreateContestRequest
(
    string? Policy,
    DateTime StartTime,
    DateTime EndTime,
    Guid CourtId
);
