using System;
using System.Collections.Generic;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class Roles
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ResourceType { get; set; }
        public long? ResourceId { get; set; }
    }
}
