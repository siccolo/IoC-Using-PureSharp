using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Puresharp;

namespace IoCTemplate
{
    
    public class InterceptAspect : Aspect
    {
        public override IEnumerable<Advisor> Manage(MethodBase method)
        {
            //Aspect will advice method on boundary using MyCustomAdvice.
            yield return Advice
                    .For(method)
                    .Around(() => new InterceptAdvice(method));

            yield return Advice
                    .For(method)
                    .Before(() => new InterceptAdvice(method));
        }
    }
    


    public class InterceptLogging : Aspect
    {
        override public IEnumerable<Advisor> Manage(MethodBase method)
        {
            //Use classic interceptor to create an 'Around' advisor (place break points in interceptor methods to test interception).
            yield return Advice
                .For(method)
                .Around(() => new InterceptAdvice(method));

            //Use linq expression to generate a 'Before' advisor.
            yield return Advice
                .For(method)
                .Before(invocation =>
                {
                    return Expression.Call
                    (
                        Metadata.Method(() => Console.WriteLine(Metadata<string>.Value)),
                        Expression.Constant($"Expression : { method.Name }")
                    );
                });

            //Use linq expression to generate a 'Before' advisor.
            yield return Advice
                .For(method)
                .Before
                (
                    Expression.Call
                    (
                        Metadata.Method(() => Console.WriteLine(Metadata<string>.Value)),
                        Expression.Constant($"Expression2 : { method.Name }")
                    )
                );

            /*
            //Use ILGeneration from reflection emit API to generate a 'Before' advisor.
            yield return Advice
                .For(method)
                .Before(advice =>
                {
                    advice.Emit(OpCodes.Ldstr, $"ILGenerator : { method.Name }");
                    advice.Emit(OpCodes.Call, Metadata.Method(() => Console.WriteLine(Metadata<string>.Value)));
                });
                */

            //Use simple Action to generate a 'Before' advisor.
            yield return Advice
                .For(method)
                .Before(() => Console.WriteLine($"Action : { method.Name }"));

            //Use an expression to generate an 'After-Returning-Value' Advisor
            yield return Advice
                .For(method)
                .After()
                .Returning()
                .Value(_Execution =>
                {
                    return Expression.Call
                    (
                        Metadata.Method(() => Console.WriteLine(Metadata<string>.Value)),
                        Expression.Call
                        (
                            Metadata.Method(() => string.Concat(Metadata<string>.Value, Metadata<string>.Value)),
                            Expression.Constant("Returned Value : "),
                            Expression.Call(_Execution.Return, Metadata<object>.Method(_Object => _Object.ToString()))
                        )
                    );
                });

            /*
            //Validate an email parameter value.
            yield return Advice
                .For(method)
                .Parameter<EmailAddressAttribute>()
                .Validate((_Parameter, _Attribute, _Value) =>
                {
                    if (_Value == null) { throw new ArgumentNullException(_Parameter.Name); }
                    try { new MailAddress(_Value.ToString()); }
                    catch (Exception exception) { throw new ArgumentException(_Parameter.Name, exception); }
                });
                */
        }
    }

}
