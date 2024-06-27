using ShuttleZone.Domain.WebResponses.UserContests;

namespace ShuttleZone.Domain.WebResponses.Contest
{
    public class ContestResponse
    {
        public Guid Id { get; set; }
        public DateTime ContestDate { get; set; }
        public int MaxPlayer { get; set; }
        public string? Policy { get; set; }
        public string? ContestStatus { get; set; }        
        public List<UserContestResponse>? UserContests { get; set; }
    }
}
