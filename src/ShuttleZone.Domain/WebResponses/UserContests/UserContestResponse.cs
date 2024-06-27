namespace ShuttleZone.Domain.WebResponses.UserContests
{
    public class UserContestResponse
    {
        public string Fullname { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? ProfilePic { get; set; }
        public bool isCreatedPerson { get; set; } = false;
        public bool isWinner { get; set; } = false;
        public int Point { get; set; }
        public Guid ParticipantsId { get; set; }
        public Guid ContestId { get; set; }
    }
}
