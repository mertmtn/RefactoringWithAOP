using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Exception
{
    public class ExceptionAspect : MethodInterception
    {
        private Type _type;

        public ExceptionAspect(Type type)
        {
            _type = type;
        }

        public override void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (WebException we)
            {
                OnException(invocation, we);
            }
            catch (System.Exception ex)
            {
                OnException(invocation, ex);
            }
        }

        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            var exceptionMessage = e.Message;
            var instance = (IResult)Activator.CreateInstance(_type, null, false, exceptionMessage);

            instance.StatusCode = 500;
            if (e is WebException webEx)
            {
                var response = (HttpWebResponse)webEx.Response;
                var status = response?.StatusCode;
                int statusCode = status != null ? (int)((HttpStatusCode)status) : 500;
                instance.StatusCode = statusCode;
            }
            else if (e is ValidationException)
            {
                instance.StatusCode = 400;
            }

            invocation.ReturnValue = instance;
        }
    }
}
