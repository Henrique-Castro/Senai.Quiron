using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Quiron.WebApi.Domains;
using Senai.Quiron.WebApi.Interfaces;
using Senai.Quiron.WebApi.Providers;

namespace Senai.Quiron.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DoutoresController : ControllerBase
    {
        IDoutoresProvider _doutoresProvider;
        DatabaseContext _context { get; set; }

        public DoutoresController()
        {
            _context = new DatabaseContext();
            _doutoresProvider = new DoutoresProvider(_context);
        }


        [HttpPost]
        public IActionResult Cadastrar(Doutores doutor)
        {
            try
            {
                _doutoresProvider.Cadastrar(doutor);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_doutoresProvider.Listar());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarDoutorPorId(int id)
        {
            try
            {
                return Ok(_doutoresProvider.BuscarPorId(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {

                var doutor = _doutoresProvider.BuscarPorId(id);

                _doutoresProvider.Excluir(doutor);

                return Ok();

            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{idDoutor}")]
        public IActionResult Atualizar(int idDoutor, Doutores doutor)
        {
            try
            {
                var doutorEncontrado = _doutoresProvider.BuscarPorId(idDoutor);

                doutor.Crm = doutor.Crm == null ? doutorEncontrado.Crm : doutor.Crm;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}