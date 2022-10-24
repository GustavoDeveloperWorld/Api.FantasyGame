namespace Domain.Entities
{
    public class MatchEntity : BaseEntity
    {
        public TimeEntity Time1 { get; set; }
        public int Goals1 { get; set; }
        public TimeEntity Time2 { get; set; }
        public int Goals2 { get; set; }
    }
}
