using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace UnityInterception
{
    class Program
    {
        internal static IUnityContainer Container = new UnityContainer();

        static void Main(string[] args)
        {
            // refer: https://msdn.microsoft.com/en-us/library/dn178466(v=pandp.30).aspx

            Container.AddNewExtension<Interception>();

            // register a one to one with IMyType and a behaviour
            //Container.RegisterType<IMyType, MyType>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<LoggingInterceptionBehavior>());

            // register a one to one with IMyType and a policy (attributes)
            //Container.RegisterType<IMyType, MyType>(new InterceptionBehavior<PolicyInjectionBehavior>(), new Interceptor<InterfaceInterceptor>());
            
            // respect all the attributes
            Container.RegisterTypes(
                AllClasses.FromAssembliesInBasePath(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled,
                x => new InjectionMember[] { new InterceptionBehavior<PolicyInjectionBehavior>(), new Interceptor<InterfaceInterceptor>() });


            var myType = Container.Resolve<IMyType>();
            var myType1 = Container.Resolve<IMyType1>();
            var myType2 = Container.Resolve<IMyType2>();

            myType.Dosomething();
            myType1.Dosomething();
            myType2.Dosomething();

            Console.ReadKey();

        }
    }
}
