using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DelProjekt1_Disp_Backend.Models
{
    public partial class Vaerktoejskasse
    {
        public Vaerktoejskasse()
        {
            Vaerktoej = new HashSet<Vaerktoej>();
        }
        [Key]
        public int VTKId { get; set; }
        public DateTime VTKAnskaffet { get; set; }
        public string VTKFabrikat { get; set; }
        public int? VTKEjesAf { get; set; }
        public string VTKModel { get; set; }
        public string VTKSerienummer { get; set; }
        public string VTKFarve { get; set; }
        [JsonIgnore]
        public Haandvaerker EjesAfNavigation { get; set; }
        [JsonIgnore]
        public HashSet<Vaerktoej> Vaerktoej { get; set; }
    }
}
