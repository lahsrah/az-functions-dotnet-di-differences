using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DotNet6_Isolated
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly IService _service;


        public Function1(ILogger<Function1> logger, IService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("Function1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            return new OkObjectResult(_service.Get());
        }
    }

    public interface IService
    {
        string Get();
        string GetFromRepository();
    }

    public class Service : IService
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public string GetFromRepository() => $"Hello from Service! {_repository.Get()}";

        public string Get() => "Hello from Service!";
    }

    public interface IRepository
    {
        string Get();
    }

    public class Repository : IRepository
    {
        public string Get() => "Hello from Repository!";
    }
}
