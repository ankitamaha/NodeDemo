using System;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApplication {
    [Route("/api")]
    public class ApiRootController : Controller {
        [HttpGet]
        public object Get() {
            return new {
                Guid = Guid.NewGuid(),
                Now = DateTime.Now.ToString()
            };
        }
    }
}
