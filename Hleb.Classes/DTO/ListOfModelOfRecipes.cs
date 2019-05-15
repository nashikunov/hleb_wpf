using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Classes.DTO
{
   public class ListOfModelOfRecipes
    {
        [JsonProperty("recipes")]
        public List<ModelOfRecipe> ModelOfRecipes { get; set; }
    }
}
