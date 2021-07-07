using System;
using System.Collections.Generic;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class Columns
    {
        public Columns()
        {
            Elevators = new HashSet<Elevators>();
        }

        public long Id { get; set; }
        public string ColumnType { get; set; }
        public int? NbOfFloorsServed { get; set; }
        public string Status { get; set; }
        public string Info { get; set; }
        public string Notes { get; set; }
        public long? BatteryId { get; set; }

        public virtual Batteries Battery { get; set; }
        public virtual ICollection<Elevators> Elevators { get; set; }
    }
}
