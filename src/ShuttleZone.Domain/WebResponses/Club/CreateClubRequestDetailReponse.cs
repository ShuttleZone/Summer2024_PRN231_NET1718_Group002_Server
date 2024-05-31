namespace ShuttleZone.Domain.WebResponses.Club
{
    public class CreateClubRequestDetailReponse
    {
        public Guid Id { get; set; }
        public string ClubName { get; set; } = null!;
        public string ClubAddress { get; set; } = null!;
        public string ClubPhone { get; set; } = null!;
        public string ClubDescription { get; set; } = null!;
        public string Status { get; set; } = null!;

        public TimeOnly OpenTime { get; set; }
        public TimeOnly CloseTime { get; set; }

        public ICollection<DtoClubImageResponse> ClubImages = new List<DtoClubImageResponse>();
        public ICollection<OpenDateInWeekResponse> OpenDateInWeeks = new List<OpenDateInWeekResponse>();
    }

    public record OpenDateInWeekResponse
    {
        public Guid Id { get; set; }
        public string Date { get; set; } = null!;
    }
}
