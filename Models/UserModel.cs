using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberApp.Models
{
    public class UserModel
    {
        [JsonProperty("id_barbero")]
        public int id { get; set; }
        public string nombreUsuario { get; set; }

        //public string Password { get; set; }

        public string rol { get; set; }

        [JsonProperty("fechaRegistro")]
        public DateTime? fechaRegistro { get; set; }
    }
}
