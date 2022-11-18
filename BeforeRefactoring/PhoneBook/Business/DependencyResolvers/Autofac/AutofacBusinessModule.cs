using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Data.Abstract;
using Data.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DepartmentManager>().As<IDepartmentService>().InstancePerLifetimeScope();
            builder.RegisterType<EfDepartmentDal>().As<IDepartmentDal>().InstancePerLifetimeScope(); 
            builder.RegisterType<EfPersonDal>().As<IPersonDal>().InstancePerLifetimeScope();
            builder.RegisterType<PersonManager>().As<IPersonService>().InstancePerLifetimeScope(); 
            builder.RegisterType<EfPhoneTypeDal>().As<IPhoneTypeDal>().InstancePerLifetimeScope(); 
            builder.RegisterType<PhoneTypeManager>().As<IPhoneTypeService>().InstancePerLifetimeScope();
            builder.RegisterType<PhoneManager>().As<IPhoneService>().InstancePerLifetimeScope(); 
            builder.RegisterType<EfPhoneDal>().As<IPhoneDal>().InstancePerLifetimeScope();
            
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()                    
                }).InstancePerLifetimeScope();
        }
    }
}
