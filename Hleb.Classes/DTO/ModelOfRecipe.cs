using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Classes.DTO
{
   public class ModelOfRecipe
    {
        [JsonProperty("recipe_id")]
        public string IDOfRecepies { get; set; }
        [JsonProperty("social_rank")]
        public string Rating { get; set; }
        [JsonProperty("title")]
        public string Name { get; set; }
        [JsonProperty("image_url")]
        public string ImageURI { get; set; }
    }
}
