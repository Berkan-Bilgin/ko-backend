namespace ko_backend.Models
{
    public class EpisodeCharacter
    {
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }

        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
