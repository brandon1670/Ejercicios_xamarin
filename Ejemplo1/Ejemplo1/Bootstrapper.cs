using Autofac;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Ejemplo1.Repositories;

namespace Ejemplo1
{
    public abstract class Bootstrapper
    {
        static ContainerBuilder ContainerBuilder
        { get;  set; }
        public Bootstrapper()
        {
            Initialize();
            FinishInitialization();
        }
        public static void Initialize()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder = new ContainerBuilder();
            foreach (var type in currentAssembly.DefinedTypes.Where(e =>
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
    }
}