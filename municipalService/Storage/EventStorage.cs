using municipalService.Models;
using municipalService.Storage;

using System.Data;


namespace municipalService.Storage
{// code adpated from:
    //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-9.0
    public static class EventStorage
    {

        public static Queue<municipalService.Models.EventModel> EventQueue = new();
        public static Stack<municipalService.Models.EventModel> RecentSubmissions = new();

        public static void EnqueueEvent(municipalService.Models.EventModel model)
        {
            EventQueue.Enqueue(model);
            RecentSubmissions.Push(model);
        }

        public static List<municipalService.Models.EventModel> GetQueueOrderedEvents()
        {
            return EventQueue.ToList();
        }

        public static List<municipalService.Models.EventModel> GetRecentStack()
        {
            return RecentSubmissions.ToList();
        }

        // code adpated from:
    //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-9.0
        private static readonly SortedDictionary<string, List<municipalService.Models.EventModel>> _eventsByCategory = new();

       
        public static IEnumerable<EventModel> AllEvents =>
            _eventsByCategory.Values.SelectMany(list => list);
        public static IEnumerable<string> UniqueCategories => _eventsByCategory.Keys;

        public static void AddEvent(municipalService.Models.EventModel model)
        {
            if (!_eventsByCategory.ContainsKey(model.Category))
            {
                _eventsByCategory[model.Category] = new List<municipalService.Models.EventModel>();
            }

            _eventsByCategory[model.Category].Add(model);
           
            EventMD.RegisterEvent(model);
            municipalService.Storage.EventMD.CategorySet.Add(model.Category);
            municipalService.Storage.EventMD.DateSet.Add(model.Date.Date);

            
            municipalService.Storage.EventQueueStorage.EnqueueEvent(model);


        }
        // code adpated from:
    //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-9.0
        public static List<municipalService.Models.EventModel> Search(string category, DateTime? date)
        {
            List<EventModel> results;

            if (!string.IsNullOrEmpty(category) && _eventsByCategory.TryGetValue(category, out var categoryEvents))
            {
                results = categoryEvents;
            }
            else
            {
                results = _eventsByCategory.Values.SelectMany(list => list).ToList();
            }

            if (date.HasValue)
            {
                results = results.Where(e => e.Date.Date == date.Value.Date).ToList();
            }

            return results;
        }
    }
}