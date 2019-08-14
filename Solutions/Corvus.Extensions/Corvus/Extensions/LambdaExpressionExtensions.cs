// <copyright file="LambdaExpressionExtensions.cs" company="Corvus">
// Copyright (c) Corvus. All rights reserved.
// </copyright>

namespace System
{
    using System.Linq.Expressions;

    /// <summary>
    /// Extensions for <see cref="LambdaExpression"/>.
    /// </summary>
    public static class LambdaExpressionExtensions
    {
        /// <summary>
        /// Extract a property name from a lambda expression.
        /// </summary>
        /// <param name="expression">The property expression.</param>
        /// <returns>The name of the property expression.</returns>
        public static string ExtractPropertyName(this LambdaExpression expression)
        {
            MemberExpression memberExpression = GetMemberExpression(expression);

            return memberExpression.Member.Name;
        }

        /// <summary>
        /// Gets a member expression from the body of a lambda expression.
        /// </summary>
        /// <param name="expression">The lambda expression.</param>
        /// <returns>The member expression.</returns>
        public static MemberExpression GetMemberExpression(this LambdaExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if (!(expression.Body is MemberExpression memberExpression))
            {
                throw new ArgumentException("The expression is not a member access expression.", nameof(expression));
            }

            return memberExpression;
        }
    }
}
