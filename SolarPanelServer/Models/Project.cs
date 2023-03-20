using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace SolarPanelServer.Models
{
    [PrimaryKey(nameof(project_id))]
    public class Project
    {
        private int project_id { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public DateTime deadline { get; set; }
        public int fee { get; set; }
        public string status { get; set; }
        public string owner { get; set; }
        private DateTime row_updated { get; set; }
    }
}
