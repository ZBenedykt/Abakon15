using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.ComponentModel;
using Abakon15.ViewModels;
using System.Reflection;

namespace Abakon15.Infrastructure
{
    /// <summary>
    /// See http://www.albahari.com/expressions for information and examples.
    /// </summary>
    public static class PredicateBuilder
    {

        public static Expression<Func<T, bool>> True<T>() { return p => true; }
        public static Expression<Func<T, bool>> False<T>() { return p => false; }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }

        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression 
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);



        }




        /// <summary>
        /// Author Z. Benedykt
        /// </summary>
        public static Expression<Func<T, bool>> BuildExpression<T>(string atrybut, OperatoryRelacjiEnum relOperator, object constParam)
        {
            Type atrMemberType;
            Type encjaPosredniaType;
            ParameterExpression encja;
            MemberExpression atrMember;
            string atrybutEntity;
            string atrybutField;
            int pozcjaKropki = 0;
            LambdaExpression lambda;
            Expression<Func<T, bool>> lambdaEXP;


            if (atrybut.Contains("."))
            {
                MemberExpression atrMember1;
                pozcjaKropki = atrybut.IndexOf('.');
                atrybutEntity = atrybut.Substring(0, pozcjaKropki);
                atrybutField = atrybut.Substring(pozcjaKropki + 1, atrybut.Length - pozcjaKropki - 1);

                encja = Expression.Parameter(typeof(T), "p");
                encjaPosredniaType = TypeDescriptor.GetProperties(typeof(T))[atrybutEntity].PropertyType;
                atrMember1 = Expression.PropertyOrField(encja, atrybutEntity);
                atrMember = Expression.PropertyOrField(atrMember1, atrybutField);
                atrMemberType = TypeDescriptor.GetProperties(encjaPosredniaType)[atrybutField].PropertyType;
            }
            else
            {

                encja = Expression.Parameter(typeof(T), "p");
                if (TypeDescriptor.GetProperties(typeof(T))[atrybut] == null)
                {
                    lambda = Expression.Lambda(Expression.Constant(false), encja);
                    lambdaEXP = (Expression<Func<T, bool>>)Expression<Func<T, bool>>.Lambda(lambda.Type, lambda.Body, lambda.Parameters);
                    return lambdaEXP;
                }
                atrMemberType = TypeDescriptor.GetProperties(typeof(T))[atrybut].PropertyType;

                atrMember = Expression.PropertyOrField(encja, atrybut);

            }


            bool isNullconstParam = constParam == null || constParam.ToString() == string.Empty;


            ConstantExpression constMember;
            try
            {
                if (isNullconstParam)
                {
                    constMember = Expression.Constant(null, atrMember.Type);
                }
                else
                {
                    //constMember = Expression.Constant(constParam, atrMember.Type);
                    constMember = Expression.Constant(constParam, atrMemberType);
                }
            }

            catch (Exception)
            {
                lambda = Expression.Lambda(Expression.Constant(false), encja);
                lambdaEXP = (Expression<Func<T, bool>>)Expression<Func<T, bool>>.Lambda(lambda.Type, lambda.Body, lambda.Parameters);
                return lambdaEXP;
            }


            MethodInfo methodInfoCompare = atrMemberType.GetMethod("CompareTo", new[] { atrMemberType });
            MethodInfo methodInfoContains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            MethodInfo methodInfoToLower = typeof(string).GetMethod("ToLower", System.Type.EmptyTypes);  //  System.Globalization.CultureInfo.CurrentCulture
            MethodInfo methodInfoStartsWith = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });

            switch (relOperator)
            {
                case OperatoryRelacjiEnum.Equal:

                    if (isNullconstParam && atrMemberType.Name != "String")
                    {
                        lambda = Expression.Lambda(Expression.Constant(false), encja);
                    }
                    else
                    {
                        if (methodInfoCompare == null)
                        {
                            lambda = Expression.Lambda(Expression.Equal(atrMember, constMember), encja);
                        }
                        else
                        {
                            lambda = Expression.Lambda(Expression.Equal(Expression.Call(atrMember, methodInfoCompare, constMember), Expression.Constant(0)), encja);
                        }
                    }

                    break;
                case OperatoryRelacjiEnum.Empty:

                    if (isNullconstParam && atrMemberType.Name != "String")
                    {
                        // lambda = Expression.Lambda(Expression.Constant(""), encja);
                        lambda = Expression.Lambda(Expression.Equal(atrMember, Expression.Constant(null, atrMember.Type)), encja);
                    }
                    else
                    {
                        if (methodInfoCompare == null)
                        {
                            //   Expression.Equal(property, Expression.Constant(null, property.Type));
                            lambda = Expression.Lambda(Expression.Equal(atrMember, Expression.Constant(null, atrMember.Type)), encja);
                            // lambda = Expression.Lambda(Expression.Equal(atrMember, Expression.Constant("", typeof(string))), encja);
                        }
                        else
                        {
                            var ex1 = Expression.Equal(Expression.Call(atrMember, methodInfoCompare, Expression.Constant("", typeof(string))), Expression.Constant(0));
                            var ex2 = Expression.Equal(atrMember, Expression.Constant(null, atrMember.Type));
                            lambda = Expression.Lambda(Expression.Or(ex1, ex2), encja);


                        }
                    }

                    break;
                case OperatoryRelacjiEnum.NotEqual:
                    if (isNullconstParam)
                    {
                        lambda = Expression.Lambda(Expression.Constant(true), encja);
                    }
                    else
                    {
                        if (methodInfoCompare == null)
                        {
                            lambda = Expression.Lambda(Expression.NotEqual(atrMember, constMember), encja);
                        }
                        else
                        {
                            lambda = Expression.Lambda(Expression.NotEqual(Expression.Call(atrMember, methodInfoCompare, constMember), Expression.Constant(0)), encja);
                        }
                    }
                    break;

                case OperatoryRelacjiEnum.NotEmpty:

                    if (isNullconstParam && atrMemberType.Name != "String")
                    {
                        lambda = Expression.Lambda(Expression.Constant(""), encja);
                    }
                    else
                    {
                        if (methodInfoCompare == null)
                        {
                            lambda = Expression.Lambda(Expression.NotEqual(atrMember, Expression.Constant("", typeof(string))), encja);
                        }
                        else
                        {
                            var ex1 = Expression.NotEqual(Expression.Call(atrMember, methodInfoCompare, Expression.Constant("", typeof(string))), Expression.Constant(0));
                            var ex2 = Expression.NotEqual(atrMember, Expression.Constant(null, atrMember.Type));
                            lambda = Expression.Lambda(Expression.AndAlso(ex1, ex2), encja);
                            //   lambda = Expression.Lambda(Expression.NotEqual(Expression.Call(atrMember, methodInfoCompare, Expression.Constant("", typeof(string))), Expression.Constant(0)), encja);
                        }
                    }

                    break;

                case OperatoryRelacjiEnum.Less:

                    if (isNullconstParam)
                    {
                        lambda = Expression.Lambda(Expression.Constant(false), encja);
                    }
                    else
                    {
                        if (methodInfoCompare == null)
                        {
                            lambda = Expression.Lambda(Expression.LessThan(atrMember, constMember), encja);
                        }
                        else
                        {
                            lambda = Expression.Lambda(Expression.LessThan(Expression.Call(atrMember, methodInfoCompare, constMember), Expression.Constant(0)), encja);
                        }
                    }
                    break;

                case OperatoryRelacjiEnum.LessEqual:
                    if (isNullconstParam)
                    {
                        lambda = Expression.Lambda(Expression.Constant(false), encja);
                    }
                    else
                    {
                        if (methodInfoCompare == null)
                        {
                            lambda = Expression.Lambda(Expression.LessThanOrEqual(atrMember, constMember), encja);
                        }
                        else
                        {
                            lambda = Expression.Lambda(Expression.LessThanOrEqual(Expression.Call(atrMember, methodInfoCompare, constMember), Expression.Constant(0)), encja);
                        }
                    }
                    break;
                case OperatoryRelacjiEnum.Greater:
                    if (isNullconstParam)
                    {
                        lambda = Expression.Lambda(Expression.Constant(false), encja);
                    }
                    else
                    {
                        if (methodInfoCompare == null)
                        {
                            lambda = Expression.Lambda(Expression.GreaterThan(atrMember, constMember), encja);
                        }
                        else
                        {
                            lambda = Expression.Lambda(Expression.GreaterThan(Expression.Call(atrMember, methodInfoCompare, constMember), Expression.Constant(0)), encja);
                        }
                    }
                    break;

                case OperatoryRelacjiEnum.GreaterEqual:
                    if (isNullconstParam)
                    {
                        lambda = Expression.Lambda(Expression.Constant(false), encja);
                    }
                    else
                    {
                        if (methodInfoCompare == null)
                        {
                            lambda = Expression.Lambda(Expression.GreaterThanOrEqual(atrMember, constMember), encja);
                        }
                        else
                        {
                            lambda = Expression.Lambda(Expression.GreaterThanOrEqual(Expression.Call(atrMember, methodInfoCompare, constMember), Expression.Constant(0)), encja);
                        }
                    }
                    break;

                case OperatoryRelacjiEnum.Contains:
                    if (isNullconstParam || atrMemberType != typeof(string))
                    {
                        lambda = Expression.Lambda(Expression.Constant(false), encja);
                    }
                    else
                    {
                        var containsMethodExp = Expression.Call(Expression.Call(atrMember, methodInfoToLower), methodInfoContains, Expression.Call(Expression.Constant(constParam, typeof(string)), methodInfoToLower));
                        lambda = Expression.Lambda<Func<T, bool>>(containsMethodExp, encja);
                    }
                    break;

                case OperatoryRelacjiEnum.NotContains:
                    if (isNullconstParam || atrMemberType != typeof(string))
                    {
                        lambda = Expression.Lambda(Expression.Constant(false), encja);
                    }
                    else
                    {
                        var containsMethodExp = Expression.Not(Expression.Call(Expression.Call(atrMember, methodInfoToLower), methodInfoContains, Expression.Call(Expression.Constant(constParam, typeof(string)), methodInfoToLower)));
                        lambda = Expression.Lambda<Func<T, bool>>(containsMethodExp, encja);
                    }
                    break;

                case OperatoryRelacjiEnum.BeginsWith:
                    if (isNullconstParam || atrMemberType != typeof(string))
                    {
                        lambda = Expression.Lambda(Expression.Constant(false), encja);
                    }
                    else
                    {
                        var StartsWithMethodExp = Expression.Call(Expression.Call(atrMember, methodInfoToLower), methodInfoStartsWith, Expression.Call(Expression.Constant(constParam, typeof(string)), methodInfoToLower));
                        lambda = Expression.Lambda<Func<T, bool>>(StartsWithMethodExp, encja);
                    }
                    break;

                case OperatoryRelacjiEnum.NotBeginsWith:
                    if (isNullconstParam || atrMemberType != typeof(string))
                    {
                        lambda = Expression.Lambda(Expression.Constant(false), encja);
                    }
                    else
                    {
                        var StartsWithMethodExp = Expression.Not(Expression.Call(Expression.Call(atrMember, methodInfoToLower), methodInfoStartsWith, Expression.Call(Expression.Constant(constParam, typeof(string)), methodInfoToLower)));
                        lambda = Expression.Lambda<Func<T, bool>>(StartsWithMethodExp, encja);
                    }
                    break;

                default:
                    lambda = Expression.Lambda(Expression.Equal(atrMember, Expression.Constant(constParam)), encja);
                    break;
            }

            lambdaEXP = (Expression<Func<T, bool>>)Expression<Func<T, bool>>.Lambda(lambda.Type, lambda.Body, lambda.Parameters);
            return lambdaEXP;
        }
    }

    /// <summary>
    /// See http://www.albahari.com/expressions for information and examples.
    /// </summary>
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
}
