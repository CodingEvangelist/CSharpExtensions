using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExtensions
{
    /// <summary>
    /// Maps field Value from a Source object to a destination Object
    /// </summary>
    public static class MapperExtensions
    {
        public static TSource Map<TSource, TDestination, TSourceProperty, TDestProperty>(this TSource source, TDestination destination, Expression<Func<TSource, TSourceProperty>> sourceProperty,
                                Expression<Func<TDestination, TDestProperty>> targetProperty,
                                Func<TSource, TDestProperty> evaluateTargetValue)
        {
            Contract.Assume(evaluateTargetValue != null);
            TSourceProperty sourceValue = sourceProperty.Compile().Invoke(source);
            object targetValue =
            evaluateTargetValue(source);

            // Set the target value on the target property of the destination object
            // targetProperty.Body.Type.MemberType
            var prop = (PropertyInfo)((MemberExpression)targetProperty.Body).Member;
            prop.SetValue(destination, targetValue, null);
            return source;
        }
    }
}
