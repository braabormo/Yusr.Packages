namespace Yusr.Core.Abstractions.Primitives
{
    public class FilterCondition(string value, string columnName)
    {
        public string Value { get; set; } = value;
        public string ColumnName { get; set; } = columnName;
    }
}
