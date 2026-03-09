namespace Yusr.Core.Abstractions.Extensions
{
    public static class PaginateExtension
    {
        public static IQueryable<TSource> Paginate<TSource>(this IQueryable<TSource> source, int pageNumber, int rowsPerPage)
        {
            return source
                .Skip((pageNumber - 1) * rowsPerPage)
                .Take(rowsPerPage);
        }
    }
}
