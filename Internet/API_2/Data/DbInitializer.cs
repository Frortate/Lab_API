using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SearchEventContext context)
        {
            context.Database.EnsureCreated();

            if (context.Ages.Any() && context.Categories.Any() && context.Cities.Any() && context.Events.Any() && 
                context.Organizers.Any() && context.Places.Any() && context.Sessions.Any() && 
                context.Types.Any() && context.Users.Any() && context.EventsOrganizers.Any() && context.UsersSessions.Any())
            {
                return;
            }

            var evnts = new Event[]
            {
                new Event { Title = "Title1", Description = "Что-то о Title1",
                    Site = "https://metanit.com/sharp/entityframeworkcore/1.3.php", IsNew = false, TypeId = 3, CategoryId = 2,
                    AgeId = 1},
                new Event { Title = "Title2", Description = "Что-то о Title2",
                    Site = "https://www.youtube.com/", IsNew = true, TypeId = 3, CategoryId = 2,
                    AgeId = 2}
                

            };
            foreach (Event e in evnts)
            {
                context.Events.Add(e);
            }
            context.SaveChanges();


            var age = new Age[]
            {
                new Age { Age1 = 6 },
                new Age { Age1 = 14 }
        };
            foreach (Age a in age)
            {
                context.Ages.Add(a);
            }
            context.SaveChanges();


            var caregory = new Category[]
           {
                new Category { Name = "Кино" },
                new Category { Name = "Концерты" }
       };
            foreach (Category c in caregory)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();


            var city = new City[]
           {
                new City { Name = "Иваново" },
                new City { Name = "Красноярск" }
       };
            foreach (City ci in city)
            {
                context.Cities.Add(ci);
            }
            context.SaveChanges();


            var org = new Organizer[]
           {
                new Organizer { Name = "No Name One", 
                    Site = "https://stackoverflow.com/questions/58006152/net-core-3-not-having-referenceloophandling-in-addjsonoptions", 
                    PlaceId = 2 },
                new Organizer { Name = "No Name Two",
                    Site = "https://stackoverflow.com/questions/58006152/net-core-3-not-having-referenceloophandling-in-addjsonoptions", 
                    PlaceId = 2 }
       };
            foreach (Organizer o in org)
            {
                context.Organizers.Add(o);
            }
            context.SaveChanges();


            var place = new Place[]
           {
                new Place { Address = "0000000", CityId = 1},
                new Place { Address = "*******", CityId = 1}
       };
            foreach (Place p in place)
            {
                context.Places.Add(p);
            }
            context.SaveChanges();


            var session = new Session[]
           {
                new Session { EventsOrganizersId = 1 },
                new Session { EventsOrganizersId = 1 }
       };
            foreach (Session s in session)
            {
                context.Sessions.Add(s);
            }
            context.SaveChanges();


            var type = new Type[]
           {
                new Type { Name = "*****" },
                new Type { Name = "*****" }
       };
            foreach (Type t in type)
            {
                context.Types.Add(t);
            }
            context.SaveChanges();


            var user = new User[]
           {
                new User { Login = "login", Password = "0000"},
                new User { Login = "Login", Password = "1111"}
       };
            foreach (User u in user)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();
        }


    }

}

