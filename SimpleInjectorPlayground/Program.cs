using SimpleInjector;

namespace SimpleInjectorPlayground
{
    class Program
    {
        static void Main(string[] args)
        {            
            Foo foo = SimpleInjectorBootstrapper.Container.GetInstance<Foo>();

            foo.DoSomething();
        }
    }
}
