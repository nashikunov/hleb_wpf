using Hleb.Classes.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Model
{
   public class User
    {
        public int Id { get; set; }
        [JsonProperty("first_name")]
        public string Name { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public virtual List<Favourite> Favourites { get; set; }
    }
}
