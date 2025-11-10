using municipalService.Models;

namespace municipalService.Storage
{
    public class EventMD
    {
        // code adapeted from:
        //https://stackoverflow.com/questions/38333609/how-to-pass-value-to-hashset-of-a-model-from-view-c-sharp
        

        public static HashSet<string> CategorySet = new();
        public static HashSet<DateTime> DateSet = new();

        public static void RegisterEvent(EventModel model)
        {
            CategorySet.Add(model.Category);
            DateSet.Add(model.Date.Date);
        }

    }
}
