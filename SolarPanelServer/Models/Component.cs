using Microsoft.EntityFrameworkCore;

namespace SolarPanelServer.Models
{
    public class Component
    {
        [PrimaryKey(nameof(component_id))]
        public class User
        {
            private int component_id { get; set; }
            public string material { get; set; }
            public string shelf { get; set; }
            public int project { get; set; }
            public DateTime row_updated { get; set; }

        }
    }
}
