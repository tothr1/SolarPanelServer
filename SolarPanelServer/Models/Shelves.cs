using Microsoft.EntityFrameworkCore;
using SolarPanelServer.Data;

namespace SolarPanelServer.Models
{

    namespace SolarPanel
    {
        [PrimaryKey(nameof(shelf_id))]
        public class Shelves
        {
            public int shelf_id { get; set; }
            public int shelf_row { get; set; }
            public string shelf_column { get; set; }
            public int shelf_level { get; set; }
            public int part_count { get; set; }
            public DateTime row_updated { get; set; }

            
        }
    }
}
