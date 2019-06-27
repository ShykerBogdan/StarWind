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
    public class ClientController : ControllerBase
    {
        private ILogger<ClientController> _logger;
        private IPlugin _plugin;
        private readonly IMapper _mapper;
        private readonly object _locker = new object();
        public ClientController(ILogger<ClientController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddAge([FromBody] AddAgeModel model)
        {
            _plugin = PluginContext.ActivatePlagin(model.PluginName);
            var clientDTO = _mapper.Map<ClientDTO>(_plugin.GetClient(model.Id));

            if (clientDTO == null)
                return NotFound("Client doen't exist");

            clientDTO.Age++;
            _plugin.UpdateClient(_mapper.Map<Client>(clientDTO));

            return Ok(clientDTO);
        }
    }
}
