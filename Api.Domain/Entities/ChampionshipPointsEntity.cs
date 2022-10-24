using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Domain.Entities
{
    public class ChampionshipPointsEntity : BaseEntity
    {
        public TimeEntity Time { get; set; }
        public ChampionshipEntity Championship { get; set; }
        public int Points { get; set; }
    }
}
