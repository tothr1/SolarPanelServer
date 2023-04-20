using Microsoft.EntityFrameworkCore;
using SolarPanelServer.Data;

namespace SolarPanelServer.Models
{
    [PrimaryKey(nameof(component_id))]
    public class Component
    {
        public int component_id { get; set; }
        public int material { get; set; }
        public int shelf { get; set; }
        public int? project { get; set; }
        public DateTime row_updated { get; set; }

        //public Material Material { get; set; }

    }
}
