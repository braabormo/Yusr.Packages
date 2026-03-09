namespace Yusr.Core.Abstractions.Extensions
{
    public static class CollectionExtensions
    {
        public static void Sync<TDb, TSource, TKey>(
            this ICollection<TDb> dbCollection,
            IEnumerable<TSource> sourceCollection,
            Func<TSource, TKey> sourceKeySelector,
            Func<TDb, TKey> dbKeySelector,
            Func<TSource, TDb> createFunc,
            Action<TSource, TDb>? updateAction = null) // Optional Update
            where TDb : class
        {
            var sourceList = sourceCollection.ToList();
            var sourceKeys = sourceList.Select(sourceKeySelector).ToHashSet();

            var toDelete = dbCollection
                .Where(db => !sourceKeys.Contains(dbKeySelector(db)))
                .ToList();

            foreach (var item in toDelete)
            {
                dbCollection.Remove(item);
            }

            foreach (var sourceItem in sourceList)
            {
                var key = sourceKeySelector(sourceItem);

                bool isDefaultKey = EqualityComparer<TKey>.Default.Equals(key, default);

                var existing = !isDefaultKey
                    ? dbCollection.FirstOrDefault(db => EqualityComparer<TKey>.Default.Equals(dbKeySelector(db), key))
                    : null;

                if (existing != null)
                {
                    updateAction?.Invoke(sourceItem, existing);
                }
                else
                {
                    dbCollection.Add(createFunc(sourceItem));
                }
            }
        }
    }
}