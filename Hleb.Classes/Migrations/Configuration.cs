namespace Hleb.Classes.Migrations
{
    using Hleb.Classes.Model;
    using Hleb.Model;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<Hleb.Classes.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        //update-database
        protected override void Seed(Hleb.Classes.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            GetUsers(context);
        }
        private void GetUsers(Hleb.Classes.Context context)
        {
            var userJsonAll =
                GetEmbeddedResourceAsString("Hleb.Classes.Data.users.json");
            var Favourites = GetFavourites(context);
            JArray jsonValUsers = JArray.Parse(userJsonAll) as JArray;
            dynamic userssData = jsonValUsers;

            foreach (dynamic user in userssData)
            {
                var User = new User
                {
                    Id = user.Id,
                    Name = user.first_name,
                    LastName = user.last_name,
                    Email = user.Email,
                    Password = user.Password,
                    Favourites = new List<Favourite>()
                };
                foreach (var favourite in Favourites)
                {
                    if (favourite.UserId == User.Id)
                    {
                        User.Favourites.Add(favourite);
                    }
                }
                context.Users.AddOrUpdate(u => u.Email, User);
                context.SaveChanges();

            }
        }
        private List<Favourite> GetFavourites(Hleb.Classes.Context context)
        {
            var favouriteJsonAll =
                GetEmbeddedResourceAsString("Hleb.Classes.Data.favourites.json");
            var Favourites = new List<Favourite>();
            JArray jsonValFavourites = JArray.Parse(favouriteJsonAll) as JArray;
            dynamic favouritesData = jsonValFavourites;
            foreach (dynamic favourite in favouritesData)
            {
                var Favourite = new Favourite
                {
                    Id = favourite.Id,
                    RecipeId = favourite.RecipeId,
                    UserId = favourite.UserId,
                    Description = favourite.Description
                };
                Favourites.Add(Favourite);
            }
            return Favourites;
        }

        private string GetEmbeddedResourceAsString(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string result;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
