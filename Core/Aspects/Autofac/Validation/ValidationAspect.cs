using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.Messages;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation;

public class ValidationAspect : MethodInterception
{
    private Type _validatorType;

    public ValidationAspect(Type validatorType)
    {
        if (!typeof(IValidator).IsAssignableFrom(validatorType))
        {
            throw new Exception(AspectMessages.WrongValiadtionType);
        }

        _validatorType = validatorType;
    }

    protected override void OnBefore(IInvocation invocation)
    {
        var validator = (IValidator)Activator.CreateInstance((_validatorType));
        var entityType = _validatorType.BaseType.GetGenericArguments()[0];
        var entites = invocation.Arguments.Where(t => t.GetType() == entityType);
        foreach (var entity in entites)
        {
            ValidationTool.Validate(validator, entity);
        }
    }
}