using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dojodachi.Controllers {
    public class HomeController : Controller {
        // GET: /Home/
        [HttpGet]
        [Route ("")]
        public IActionResult Index () {
            var petStats = new {
                happiness = 20,
                fullness = 20,
                energy = 50,
                meals = 3,
                dead = 0,
                win = 0,
                

            };
            // HttpContext.Session.
            ViewBag.happiness = petStats.happiness;
            ViewBag.fullness = petStats.fullness;

            ViewBag.meals = petStats.meals;

            ViewBag.energy = petStats.energy;
            HttpContext.Session.SetObjectAsJson("PetStats", petStats);
            return View ();

        }
        [HttpGet("feed")]
        public JsonResult Feed() 
        {
            Dictionary<string, int> PetStats = HttpContext.Session.GetObjectFromJson<Dictionary<string, int>>("PetStats");
            Random rand = new Random();
            int LikeIt = rand.Next(0,4);
            if(PetStats["meals"] > 0)
            {
                if(LikeIt == 3)
                {
                    PetStats["meals"]--;
                }
                else
                {
                    if(PetStats["meals"] > 0)
                    {
                        PetStats["meals"]--;
                        PetStats["fullness"] += rand.Next(5, 11);
                    }
                    
                    if(PetStats["fullness"] >= 100 && PetStats["energy"] >= 100 && PetStats["happiness"]>= 100)
                    {
                        PetStats["win"] = 1;
                    }
                }
            }  

            HttpContext.Session.SetObjectAsJson("PetStats", PetStats);
            return Json(PetStats);
        }
        //Every time you play with or feed your dojodachi there should be a 25% chance that it won't like it. Energy or meals will still decrease, but happiness and fullness won't change.

        [HttpGet("play")]
        public JsonResult Play()
        {
            Dictionary<string, int> PetStats = HttpContext.Session.GetObjectFromJson<Dictionary<string, int>>("PetStats");            
            Random rand = new Random();
            int LikeIt = rand.Next(0,4);
            if(LikeIt == 3)
            {
                PetStats["energy"] -= 5;
            }
            else 
            {
                if(PetStats["energy"] >0)
                {
                    PetStats["energy"] -= 5;
                    PetStats["happiness"] += rand.Next(5, 11);
                }
                else
                {
                    PetStats["dead"] = 1;
                }
                if(PetStats["fullness"] >= 100 && PetStats["energy"] >= 100 && PetStats["happiness"]>= 100)
                {
                    PetStats["win"] = 1;
                }
            }
            HttpContext.Session.SetObjectAsJson("PetStats", PetStats);
            return Json(PetStats);
        }
        [HttpGet("work")] 
        public JsonResult Work()
        {
            Dictionary<string, int> PetStats = HttpContext.Session.GetObjectFromJson<Dictionary<string, int>>("PetStats");            
            Random rand = new Random();
            
            if(PetStats["energy"] > 0)
            {
                PetStats["energy"] -= 5;
                PetStats["meals"] += rand.Next(1,4);
            }
            else
            {
                PetStats["dead"] = 1;
            }
            if(PetStats["fullness"] >= 100 && PetStats["energy"] >= 100 && PetStats["happiness"]>= 100)
            {
                PetStats["win"] = 1;
            }
            HttpContext.Session.SetObjectAsJson("PetStats", PetStats);
            return Json(PetStats);
        }
        [HttpGet("sleep")] 
        public JsonResult Sleep()
        {
            Dictionary<string, int> PetStats = HttpContext.Session.GetObjectFromJson<Dictionary<string, int>>("PetStats");            
            Random rand = new Random();
      
            if(PetStats["happiness"] > 0 && PetStats["fullness"] > 0)
            {
                PetStats["energy"] +=15;
                PetStats["fullness"] -= 5;
                PetStats["happiness"] -=5;
            }
            else
            {
                PetStats["dead"] = 1;
            }
            if(PetStats["fullness"] >= 100 && PetStats["energy"] >= 100 && PetStats["happiness"]>= 100)
            {
                PetStats["win"] = 1;
            }
            HttpContext.Session.SetObjectAsJson("PetStats", PetStats);
            return Json(PetStats);
        }
        
        
    }
    public static class SessionExtensions
        {
            public static void SetObjectAsJson(this ISession session, string key, object value)
            {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }
            public static T GetObjectFromJson<T>(this ISession session, string key)
            {
                string value = session.GetString(key);
                return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
            }
        }
}