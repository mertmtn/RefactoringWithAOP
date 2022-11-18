using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System.Diagnostics;

namespace Core.Aspects.Autofac.Logging
{
    public class LoggingAspect : MethodInterception
    {

        public override void Intercept(IInvocation invocation)
        {
            var name = $"{invocation.Method.DeclaringType}.{invocation.Method.Name}";
            var args = string.Join(",", invocation.Arguments.Select(a => (a ?? "").ToString()));

            Debug.Write($"Call: {name}");
            Debug.Write($"Args: {args}");


            invocation.Proceed();

            Debug.Write($"Done: result was {invocation.ReturnValue}");
        }
    }
}
