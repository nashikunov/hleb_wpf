using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Model
{
    public class Recipe
    {
        [JsonProperty("recipe_id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Name { get; set; }
        [JsonProperty("source_url")]
        public Uri DetailsURL { get; set; }
        //public string Description { get; set; }
        //public string Instruction { get; set; }
        [JsonProperty("ingredients")]
        public List<string> Ingredients { get; set; }
        [JsonProperty("social_rank")]
        public double Rating { get; set; }
        [JsonProperty("image_url")]
        public string ImageURI { get; set; }
    }
}