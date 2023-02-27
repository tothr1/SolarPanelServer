using Microsoft.EntityFrameworkCore;

namespace SolarPanelServer.Models
{
    [PrimaryKey(nameof(user_name))]
    public class User
    {
        private int id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public int role { get; set; }
        public DateTime row_updated { get; set; }
    }
}
