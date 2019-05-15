using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Classes.DTO
{
    class IdOfRecepies
    {
        [JsonProperty("recipe_id")]
        public List<string> IDOfRecepies { get; set; }
    }
}
