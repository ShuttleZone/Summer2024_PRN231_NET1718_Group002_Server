namespace ShuttleZone.Domain.WebResponses.Club
{
    public class CreateClubRequestDetailReponse
    {
        public Guid Id { get; set; }
        public string ClubName { get; set; } = null!;
        public string ClubAddress { get; set; } = null!;
        public string ClubPhone { get; set; } = null!;
        public string ClubDescription { get; set; } = null!;
        public string? Status { get; set; } 

        public TimeOnly OpenTime { get; set; }
        public TimeOnly CloseTime { get; set; }

        public ICollection<DtoClubImageResponse>? ClubImages { get; set; }
        public ICollection<OpenDateInWeekResponse>? OpenDateInWeeks { get; set; }
    }

    public record OpenDateInWeekResponse
    {
        public int Id { get; set; }
        public string Date { get; set; } = null!;
    }
}
