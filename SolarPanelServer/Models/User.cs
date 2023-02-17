using Microsoft.EntityFrameworkCore;

namespace SolarPanelServer.Models
{
    [PrimaryKey(nameof(userName))]
    public class User
    {
        private int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public Int16 role { get; set; }
        public DateTime created { get; set; }
        public DateTime rowUpdated { get; set; }
    }
}
