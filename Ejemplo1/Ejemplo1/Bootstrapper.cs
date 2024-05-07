using Autofac;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Ejemplo1.Views;
using Ejemplo1.Repositories;
using Ejemplo1.ViewModels;
using Ejemplo1;
using System;
namespace Ejemplo1
{
    public abstract class Bootstrapper
    {
        protected ContainerBuilder ContainerBuilder
        { get; private set; }
        public Bootstrapper()
        {
            Initialize();
            FinishInitialization();
        }
        protected virtual void Initialize()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder = new ContainerBuilder();
            foreach (var type in currentAssembly.DefinedTypes
                    .Where(e =>
                           e.IsSubclassOf(typeof(Page)) ||
                           e.IsSubclassOf(typeof(ViewModel))))
            {
                ContainerBuilder.RegisterType(type.AsType());
            }
            ContainerBuilder.RegisterType<TodoItemRepository>().SingleInstance();
        }
        private void FinishInitialization()
        {
            var container = ContainerBuilder.Build();
            Resolver.Initialize(container);
        }

        public static void Init()
        {
            throw new NotImplementedException();
        }
    }
}