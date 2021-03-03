using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Doenca;

namespace fresenius.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoencaController : ControllerBase
    {
        private readonly IDoencaService _service;
        private readonly ILogger<DoencaController> _logger;

        public DoencaController(ILogger<DoencaController> logger, IDoencaService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("inserir")]
        public void Inserir(DoencaDTO doenca)
        {
            _service.Inserir(doenca);
        }

        [HttpPost("atualizar")]
        public void Atualizar(DoencaDTO doenca)
        {
            _service.Alterar(doenca.Codigo, doenca.Nome);
        }

        [HttpPost("remover")]
        public void Remover(DoencaDTO doenca)
        {
            _service.Remover(doenca);
        }

        [HttpGet("obterdoencas")]
        public IEnumerable<DoencaDTO> ObterDoencas()
        {
            return _service.ObterDoencas();
        }
    }
}
