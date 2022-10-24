using System.Collections.Generic;

namespace Application.ViewModels
{
    public class ChampionshipViewModel
    {
        public List<MatchViewModel> matches { get; set; }
        public string Championship { get; set; }
        public string vice { get; set; }
        public string Third { get; set; }
    }
}
