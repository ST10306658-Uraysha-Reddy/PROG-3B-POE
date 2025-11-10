namespace municipalService.Storage
{
    public static class SearchTracker
    {
        // Code adapted from:
        // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1?view=net-9.0

        public static Queue<(string Category, DateTime? Date)> SearchHistory = new();

        public static void LogSearch(string category, DateTime? date)
        {
            if (SearchHistory.Count > 10) SearchHistory.Dequeue(); // Keep recent 10
            SearchHistory.Enqueue((category, date));
        }

        public static List<string> MostSearchedCategories()
        {
            return SearchHistory
                .Where(s => !string.IsNullOrEmpty(s.Category))
                .GroupBy(s => s.Category)
                .OrderByDescending(g => g.Count())
                .Take(3)
                .Select(g => g.Key)
                .ToList();
        }
    }
}
