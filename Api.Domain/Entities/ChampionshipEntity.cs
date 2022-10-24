using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class ChampionshipEntity : BaseEntity
    {
        public ChampionshipEntity()
        {
            matches = new List<MatchEntity>();
        }
        public virtual List<MatchEntity> matches { get; set; }
        public TimeEntity Championship { get; set; }
        public TimeEntity Vice { get; set; }
        public TimeEntity Third { get; set; }
    }
}
