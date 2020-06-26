using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EffId.Models
{
    public class RoomViewModel
    {
        public int Id_salle { get; set; }

        public string Numero_Salle { get; set; }

        public int Etage { get; set; }

        public string Type { get; set; }

        public int Occupee { get; set; }

        public int Capacite { get; set; }

        public List<RoomViewModel> Rooms { get; set; }

    }
}
