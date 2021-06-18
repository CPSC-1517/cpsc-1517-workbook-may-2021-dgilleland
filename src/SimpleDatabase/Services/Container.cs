// Credits for this class go to:
//  https://stackoverflow.com/a/15717047

using System;
using System.Collections.Generic;
using System.Linq;

public class Container 
{
    Dictionary<Type, Func<object>> regs = new Dictionary<Type, Func<object>>();

    public void Register<TService, TImpl>() where TImpl : TService =>
        this.regs.Add(typeof(TService), () => this.GetInstance(typeof(TImpl)));

    public void Register<TService>(Func<TService> instanceCreator) =>
        this.regs.Add(typeof(TService), () => instanceCreator());

    public void RegisterInstance<TService>(TService instance) =>
        this.regs.Add(typeof(TService), () => instance);

    public void RegisterSingleton<TService>(Func<TService> instanceCreator) {
        var lazy = new Lazy<TService>(instanceCreator);
        this.Register<TService>(() => lazy.Value);
    }

    public T GetInstance<T>()
    {
        return (T) GetInstance(typeof(T));
    }
    public object GetInstance(Type type) {
        Func<object> creator;
        if (this.regs.TryGetValue(type, out creator)) return creator();
        else if (!type.IsAbstract) return this.CreateInstance(type);
        else throw new InvalidOperationException("No registration for "+ type);
    }

    private object CreateInstance(Type implementationType) {
        var ctor = implementationType.GetConstructors().Single();
        var parameterTypes = ctor.GetParameters().Select(p => p.ParameterType);
        var dependencies =
            parameterTypes.Select(t => this.GetInstance(t)).ToArray();
        return Activator.CreateInstance(implementationType, dependencies);
    }
}