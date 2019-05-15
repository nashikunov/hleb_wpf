using Hleb.Classes.Model;
using Hleb.Classes.Repository;
using Hleb.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Classes
{
   public class Checker
    {
        private JsRepository _repo;

        private JsRepository GetJsRepository() => _repo ?? (_repo = new JsRepository());

        public Checker()
        {
            _repo = GetJsRepository();
            var user = new User()
            {
                Name = "name4",
                Email = "email",
                Password = "PasswordHelpers.GetHash(password)",
                Favourites = new List<Favourite>()
            };
            var fav = new Favourite()
            {
                Description = "dsf2",
                RecipeId = "2",
                Id = 2
            };
           // _repo.favouritesdata.ToList().Add(fav);
            _repo.Save();
            //_repo.SaveUser(users);
        }
      
       
    }
}
