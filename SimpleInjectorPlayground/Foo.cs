namespace SimpleInjectorPlayground
{
    public class Foo
    {
        private readonly IRepository _repository;
        private readonly ILogger _logger;

        public Foo(IRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        //public Foo(IRepository repository)
        //{
        //    _repository = repository;
        //    _logger = null;
        //}

        //public Foo(ILogger logger)
        //{
        //    _repository = null;
        //    _logger = logger;
        //}

        public void DoSomething()
        {
            _repository.SaveStuff("stuff");

            _logger.LogError();
        }
    }
}