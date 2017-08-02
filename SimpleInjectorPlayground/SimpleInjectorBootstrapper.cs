using SimpleInjector;
using SimpleInjector.Diagnostics;

namespace SimpleInjectorPlayground
{
    public static class SimpleInjectorBootstrapper
    {
        public static Container Container;

        static SimpleInjectorBootstrapper()
        {
            Container = new Container();

            Container.Register<ILogger, SimpleLogger>(Lifestyle.Transient);
            Container.Register<IDatabaseConnection, SimpleDatabaseConnection>(Lifestyle.Transient);
            Container.Register<IRepository, SimpleRepository>(Lifestyle.Transient);
            Container.Register<Foo>();

            //Container.Verify();
            //DiagnosticResult[] diagnosticResults = Analyzer.Analyze(Container);
        }
    }
}