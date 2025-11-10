using Microsoft.AspNetCore.Mvc;
using municipalService.Models;
using municipalService.Storage;

namespace municipalService.Controllers
{
    public class EventsController : Controller
    {
        // Code adapted from
        //https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.groupby?view=net-9.0
        [HttpGet]
            public IActionResult EventsPage()
            {
             
                if (!EventStorage.AllEvents.Any())
                {
                        var e1 = new EventModel { Title = "Health Fair", Category = "Health", Date = DateTime.Today.AddDays(5), Description = "Free screenings and wellness talks." };
                        var e2 = new EventModel { Title = "Art Exhibition", Category = "Culture", Date = DateTime.Today.AddDays(3), Description = "Local artists showcase their work." };
                        var e3 = new EventModel { Title = "Community Cleanup", Category = "Environment", Date = DateTime.Today.AddDays(7), Description = "Join neighbors to clean up the park and streets." };
                        var e4 = new EventModel { Title = "Job Readiness Workshop", Category = "Education", Date = DateTime.Today.AddDays(10), Description = "Learn how to write a CV and prepare for interviews." };
                        var e5 = new EventModel { Title = "Blood Donation Drive", Category = "Health", Date = DateTime.Today.AddDays(2), Description = "Give blood and help save lives in your community." };
                        var e6 = new EventModel { Title = "Music in the Park", Category = "Entertainment", Date = DateTime.Today.AddDays(14), Description = "Enjoy live performances by local bands." };
                        var e7 = new EventModel { Title = "Farmers Market", Category = "Community", Date = DateTime.Today.AddDays(1), Description = "Fresh produce and handmade goods from local vendors." };
                        var e8 = new EventModel { Title = "Coding Bootcamp", Category = "Technology", Date = DateTime.Today.AddDays(9), Description = "A hands-on workshop for beginners in programming." };
                        var e9 = new EventModel { Title = "Pet Adoption Day", Category = "Community", Date = DateTime.Today.AddDays(6), Description = "Find your new furry friend and support animal shelters." };
                        var e10 = new EventModel { Title = "Fitness Challenge", Category = "Sports", Date = DateTime.Today.AddDays(8), Description = "Compete in fun fitness activities and win prizes." };
                        var e11 = new EventModel { Title = "Book Club Meetup", Category = "Culture", Date = DateTime.Today.AddDays(12), Description = "Discuss this month’s featured novel with fellow readers." };
                        var e12 = new EventModel { Title = "Mental Health Awareness Talk", Category = "Health", Date = DateTime.Today.AddDays(4), Description = "Experts share tips on managing stress and anxiety." };
                        var e13 = new EventModel { Title = "Tech Innovation Expo", Category = "Technology", Date = DateTime.Today.AddDays(20), Description = "Showcase of local startups and new digital solutions." };
                        var e14 = new EventModel { Title = "Recycling Workshop", Category = "Environment", Date = DateTime.Today.AddDays(15), Description = "Learn practical recycling and upcycling techniques." };
                        var e15 = new EventModel { Title = "Youth Sports Festival", Category = "Sports", Date = DateTime.Today.AddDays(18), Description = "Fun games and tournaments for young athletes." };
                        var e16 = new EventModel { Title = "Community Garden Day", Category = "Environment", Date = DateTime.Today.AddDays(11), Description = "Help plant vegetables and learn about sustainable gardening." };
                        var e17 = new EventModel { Title = "Cultural Dance Night", Category = "Culture", Date = DateTime.Today.AddDays(17), Description = "Experience traditional dances and cultural performances." };
                        var e18 = new EventModel { Title = "Local Business Expo", Category = "Business", Date = DateTime.Today.AddDays(13), Description = "Meet local entrepreneurs and discover new services." };
                        var e19 = new EventModel { Title = "STEM for Kids Workshop", Category = "Education", Date = DateTime.Today.AddDays(16), Description = "Interactive science and coding activities for children." };
                        var e20 = new EventModel { Title = "Neighborhood Safety Meeting", Category = "Community", Date = DateTime.Today.AddDays(19), Description = "Discuss safety initiatives and crime prevention tips." };


                    EventStorage.AddEvent(e1);
                    EventStorage.AddEvent(e2);
                    EventStorage.AddEvent(e3);
                    EventStorage.AddEvent(e4);
                    EventStorage.AddEvent(e5);
                    EventStorage.AddEvent(e6);
                    EventStorage.AddEvent(e7);
                    EventStorage.AddEvent(e8);
                    EventStorage.AddEvent(e9);
                    EventStorage.AddEvent(e10);
                    EventStorage.AddEvent(e11);
                    EventStorage.AddEvent(e12);
                    EventStorage.AddEvent(e13);
                    EventStorage.AddEvent(e14);
                    EventStorage.AddEvent(e15);
                    EventStorage.AddEvent(e16);
                    EventStorage.AddEvent(e17);
                    EventStorage.AddEvent(e18);
                    EventStorage.AddEvent(e19);
                    EventStorage.AddEvent(e20);
                }
            ViewBag.Categories = EventMD.CategorySet.ToList();
            ViewBag.Dates = EventMD.DateSet.OrderBy(d => d).ToList();


            var events = EventStorage.AllEvents.Where(e => e.Date >= DateTime.Today)
            .OrderBy(e => e.Date).ToList();

            return View(events);
            }

            [HttpPost]
            public IActionResult EventsPage(string category, DateTime? date)
            {
                ViewBag.Categories = EventMD.CategorySet.ToList();
                ViewBag.Dates = EventMD.DateSet.OrderBy(d => d).ToList();
                SearchTracker.LogSearch(category ?? "", date);


                var results = EventStorage.Search(category ?? "", date);
                 
            var recommended = SearchTracker.MostSearchedCategories()
                 .SelectMany(cat => EventStorage.Search(cat, null))
                 .Where(e => !results.Contains(e))
                 .Distinct()
                 .Take(5)
                 .ToList();

            ViewBag.Recommendations = recommended;


            return View(results);
            }

            public IActionResult QueueView()
            {
                var queue = EventQueueStorage.GetQueueOrderedEvents();
                return View(queue);
            }

            public IActionResult StackView()
            {
                var stack = EventQueueStorage.GetRecentStack();
                return View(stack);
            }
    }
}
