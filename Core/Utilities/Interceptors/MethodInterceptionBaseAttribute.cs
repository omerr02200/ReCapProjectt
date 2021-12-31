using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =true, Inherited =true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //Aspectlerin çalışma sırasını belirlemek için değişken.

        public virtual void Intercept(IInvocation invocation) //invocaiton tanımladığımız metod, yani çalıştırmaya çalışılan metodumuz.
        {
            
        }
    }
}
