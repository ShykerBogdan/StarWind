using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TestCommon;
using TestRESTService.Domain;
using TestRESTService.Infrastrucutre;

namespace TestRESTService.Controllers
{
    [Route("Client")]
    public class ClientController : ControllerBase
    {
        private ILogger<ClientController> _logger;
        private IPlugin _plugin;
        private readonly IMapper _mapper;
        private static object s_locker = new object();

        public ClientController(ILogger<ClientController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AddAge")]
        public IActionResult AddAge([FromBody] AddAgeModel model)
        {
            _plugin = PluginContext.ActivatePlagin(model.PluginName);
            var client = _plugin.GetClient(model.Id);

            lock (s_locker)
            {
                client.Age++;
            }

            _plugin.UpdateClient(client);
            ClientDTO clientDTO = _mapper.Map<ClientDTO>(client);

            return Ok(clientDTO);
        }
    }
}
