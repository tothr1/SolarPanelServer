using Microsoft.EntityFrameworkCore;

namespace SolarPanelServer.Models
{
    [PrimaryKey(nameof(material_name))]
    public class Material
    {       
        private int material_id { get; set; }
        public string material_name { get; set; }
        public int shelf_limit { get; set; }
        public int price { get; set; }
        public DateTime row_updated { get; set; }
    }
}
