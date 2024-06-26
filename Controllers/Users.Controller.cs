using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Controllers
{
    public class UsersController
    {
        private readonly Services.IUsersService<Models.Users> _service;
        public UsersController(Services.IUsersService<Models.Users> service)
        {
            _service = service;
        }
        [FunctionName("users")]
        public async Task<IActionResult> CreateUsers(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                var body = await new StreamReader(req.Body).ReadToEndAsync();
                var user = JsonConvert.DeserializeObject<Models.Users>(body);
                _service.Add(user);
            }
            catch (Exception e)
            {
                log.LogError(e.Message);
                return new BadRequestResult();
            }
            return new OkObjectResult(null);
        }
    }
}
