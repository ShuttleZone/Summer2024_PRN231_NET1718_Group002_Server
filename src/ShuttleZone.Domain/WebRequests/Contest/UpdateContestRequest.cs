namespace ShuttleZone.Domain.WebRequests.Contest
{
    public class UpdateContestRequest
    {
        public Guid Id { get; set; }
        public List<UserContestRequest> UserContests { get; set; } = null!;
    }

    public class UserContestRequest
    {
        public Guid ParticipantsId { get; set; }
        public bool isWinner { get; set; }
        public int Point { get; set; }
    }
}
