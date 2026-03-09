namespace Yusr.Core.Abstractions.Primitives
{
    public class FilterResponse<T>
    {
        public List<T> Data { get; set; }
        public int Count { get; set; }

        public FilterResponse()
        {
            Data = [];
            Count = 0;
        }
    }
}