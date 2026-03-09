using System.Linq.Expressions;
using System.Reflection;
using Yusr.Core.Abstractions.Primitives;

namespace Yusr.Core.Abstractions.Extensions
{
    public static class DynamicQueryExtensions
    {
        private static readonly MethodInfo StringToLower = typeof(string).GetMethod("ToLower", Type.EmptyTypes)!;
        private static readonly MethodInfo StringContains = typeof(string).GetMethod("Contains", [typeof(string)])!;

        public static IQueryable<T> ApplyDynamicFilter<T>(this IQueryable<T> query, FilterCondition? condition)
        {
            if (condition == null || string.IsNullOrWhiteSpace(condition.ColumnName))
                return query;

            var parameter = Expression.Parameter(typeof(T), "x");

            Expression property = parameter;
            try
            {
                foreach (var member in condition.ColumnName.Split('.'))
                {
                    property = Expression.PropertyOrField(property, member);
                }
            }
            catch (ArgumentException) { return query; }

            var propType = property.Type;
            var parsedValue = ParseValue(condition.Value, propType);

            if (parsedValue == null && !IsNullable(propType))
                return query;

            Expression comparison;

            // Default Behavior: 
            // - Strings use .Contains() (LIKE %value%)
            // - Other types (Int, Guid, Enum) use Equality (==)
            if (propType == typeof(string) && parsedValue != null)
            {
                var propertyToLower = Expression.Call(property, StringToLower);
                var constant = Expression.Constant(parsedValue.ToString()!.ToLower(), typeof(string));
                comparison = Expression.Call(propertyToLower, StringContains, constant);
            }
            else
            {
                var constant = Expression.Constant(parsedValue, propType);
                comparison = Expression.Equal(property, constant);
            }

            var lambda = Expression.Lambda<Func<T, bool>>(comparison, parameter);
            return query.Where(lambda);
        }

        private static bool IsNullable(Type type) => !type.IsValueType || Nullable.GetUnderlyingType(type) != null;

        private static object? ParseValue(string value, Type targetType)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            try
            {
                var underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

                if (underlyingType == typeof(Guid))
                    return Guid.Parse(value);

                if (underlyingType.IsEnum)
                    return Enum.Parse(underlyingType, value);

                return Convert.ChangeType(value, underlyingType);
            }
            catch { return null; }
        }
    }
}
