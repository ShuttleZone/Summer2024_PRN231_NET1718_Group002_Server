namespace ShuttleZone.Domain.WebRequests;

public record CreateContestRequest
(
    string? Policy,
    IReadOnlyCollection<ContestSlot> ContestSlots,
    Guid CourtId,
    uint MaxPlayer
);

public record ContestSlot
(
    DateTime StartTime,
    DateTime EndTime
);
