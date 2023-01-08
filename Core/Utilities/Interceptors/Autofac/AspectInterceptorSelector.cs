using System.Reflection;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors.Autofac;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
            (true).ToList();

        var methodAttributes =
            type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>();

        classAttributes.AddRange(methodAttributes);

        return classAttributes.OrderBy(x => x.Priorty).ToArray();
    }
}