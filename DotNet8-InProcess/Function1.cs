using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DotNet8_InProcess
{
    public class Function1
    {
        private readonly IService _service;

        public Function1(IService service)
        {
            _service = service;
        }

        [FunctionName("Function1")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
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
