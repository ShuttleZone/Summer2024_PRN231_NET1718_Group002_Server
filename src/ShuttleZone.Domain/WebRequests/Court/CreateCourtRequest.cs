using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebRequests;

public sealed record CreateCourtRequest
(
    Guid ClubId,
    string Name,
    CourtType CourtType,
    CourtStatus CourtStatus,
    double Price
);
