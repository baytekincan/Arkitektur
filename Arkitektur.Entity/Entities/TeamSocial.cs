namespace Arkitektur.Entity.Entities
{
    public class TeamSocial
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
