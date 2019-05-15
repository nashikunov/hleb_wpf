using Hleb.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Classes.DTO
{

    public interface APIrequest
    {
        ListOfModelOfRecipes Filter(List<string> ingredients);
        ListOfRecepies GetRecipe(string id);
    }

    public class API : APIrequest
    {
        static string BuildUrl(string baseUrl, IDictionary<string, List<string>> parameters)
        {
            var sb = new StringBuilder(baseUrl);
            if (parameters?.Count > 0)
            {
                sb.Append('?');
                foreach (var p in parameters)
                {
                    sb.Append(p.Key);
                    sb.Append("=");
                    for (int i = 0; i < p.Value.Count(); i++)
                    {
                        sb.Append(WebUtility.UrlEncode(p.Value[i]));
                        if (i == p.Value.Count() - 1)
                        {
                            sb.Append('&');
                        }
                        else
                        {
                            sb.Append(',');
                        }
                    }
                    // This is the important part - percent-encoding

                }
                sb.Remove(sb.Length - 1, 1);    // Remove the last '&'
            }
            return sb.ToString();
        }

        static string BuildUrlForAnotherRecepie(string baseUrl, IDictionary<string, string> parameters)
        {
            var sb = new StringBuilder(baseUrl);
            if (parameters?.Count > 0)
            {
                sb.Append('?');
                foreach (var p in parameters)
                {
                    sb.Append(p.Key);
                    sb.Append("=");

                    sb.Append(WebUtility.UrlEncode(p.Value));
                    // This is the important part - percent-encoding
                    sb.Append('&');

                }
                sb.Remove(sb.Length - 1, 1);    // Remove the last '&'
            }
            return sb.ToString();
        }
       public static string MakeQueryforRecepies(List<string> ingridients)
        {
            // Simple option
            // return $"http://food2fork.com/api/search";
            List<string> key = new List<string>();
            //key[0] = "7d11e6e8f3c6fc0381373fde96262632";
            key.Add("7d11e6e8f3c6fc0381373fde96262632");
            // A better option:
            return BuildUrl("http://food2fork.com/api/search", new Dictionary<string, List<string>>
            {
                {"key", key },
                {"q", ingridients }
                //{"q", ingridients },

                //{"key", key }
            });
        }
        static string MakeQueryforTheBaseOfingridients(string IdOfRecepie)
        {
            // Simple option
            // return $"http://food2fork.com/api/search";
            string key = "7d11e6e8f3c6fc0381373fde96262632";
            // A better option:
            return BuildUrlForAnotherRecepie("http://food2fork.com/api/get", new Dictionary<string, string>
            {
                {"key", key },

                {"rId", IdOfRecepie }
            });
        }
        public ListOfModelOfRecipes Filter(List<string> ingredients)
        {
            using (var client = new HttpClient())
            {
                string result = client.GetStringAsync(MakeQueryforRecepies(ingredients)).Result;  // Blocking call!
                return JsonConvert.DeserializeObject<ListOfModelOfRecipes>(result);
            }
        }
        public ListOfRecepies GetRecipe(string id)
        {

            using (var client = new HttpClient())
            {
                string result = client.GetStringAsync(MakeQueryforTheBaseOfingridients(id)).Result;  // Blocking call!
                return JsonConvert.DeserializeObject<ListOfRecepies>(result);              
            }
            
        }

    }

    
}
