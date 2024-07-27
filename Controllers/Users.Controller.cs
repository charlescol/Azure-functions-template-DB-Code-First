
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Functions.Worker;

namespace Controllers
{
    public class UsersController
    {

        private readonly Services.IUsersService<Models.Users> _service;
        private readonly ILogger<UsersController> _logger;


        public UsersController(Services.IUsersService<Models.Users> service, ILogger<UsersController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [Function("users")]
        public async Task<IActionResult> CreateUsers2([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            try
            {
                var body = await new StreamReader(req.Body).ReadToEndAsync();
                var user = JsonConvert.DeserializeObject<Models.Users>(body);
                _service.Add(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                if (e.InnerException != null)
                {
                    _logger.LogError("Inner exception: {0}", e.InnerException);
                }
                return new BadRequestResult();
            }
            return new OkObjectResult(null);
        }
    }
}
