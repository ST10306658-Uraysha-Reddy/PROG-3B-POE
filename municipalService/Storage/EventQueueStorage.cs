using System.Collections.Generic;
using municipalService.Models;

namespace municipalService.Storage
{
        public static class EventQueueStorage

        { // code adapted from:
          //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1?view=net-9.0
          //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1?view=net-9.0

        private static readonly Queue<EventModel> _eventQueue = new();
            private static readonly Stack<EventModel> _recentStack = new();

            public static void EnqueueEvent(EventModel model)
            {
                _eventQueue.Enqueue(model);
                _recentStack.Push(model);
            }

            public static List<municipalService.Models.EventModel> GetQueueOrderedEvents()
            {
                return new List<municipalService.Models.EventModel>(_eventQueue);
            }

            public static List<municipalService.Models.EventModel> GetRecentStack()
            {
                return new List<municipalService.Models.EventModel>(_recentStack);
            }
        }
}


