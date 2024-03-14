namespace ko_backend.Models
{
    public class Episode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Season { get; set; }
        public string EpisodeCode { get; set; }
        public DateTime AirDate { get; set; }
        public List<EpisodeCharacter> EpisodeCharacters { get; set; }
    }
}
