namespace PanGainsAPI.Models
{
    public class Challenges
    {
        [Key]
        public int ChallengeID { get; set; }
        [Required]
        public string? ChallengeName { get; set; }
    }
}
