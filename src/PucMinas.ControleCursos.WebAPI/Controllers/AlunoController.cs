using System;
using Microsoft.AspNetCore.Mvc;
using PucMinas.ControleCursos.WebAPI.Models.Entities;
using PucMinas.ControleCursos.WebAPI.Services.Interfaces;

namespace PucMinas.ControleCursos.WebAPI.Controllers
{
    [Produces("application/json")]
    public class AlunoController : Controller
    {
        private readonly IAlunoService _service;

        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("aluno/realizarAutenticacao/{usuario}/{senha}")]
        public IActionResult RealizarAutenticacao(string usuario, string senha)
        {
            try
            {
                var result = _service.Find(e => e.Email.Equals(usuario) && e.Senha.Equals(senha));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }

        [HttpGet]
        [Route("aluno/listarTodos")]
        public IActionResult ListarTodos()
        {
            try
            {
                var result = _service.FindAll();

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }

        [HttpPost]
        [Route("aluno/inserir")]
        public IActionResult Inserir([FromBody]Aluno model)
        {
            try
            {
                _service.Insert(model);
                return Ok(new
                {
                    success = true,
                    data = model
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = ex.Message
                });
            }
        }

        [HttpPut]
        [Route("aluno/alterar")]
        public IActionResult Alterar([FromBody]Aluno model)
        {
            try
            {
                _service.Update(model);
                return Ok(new
                {
                    success = true,
                    data = model
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = ex.Message
                });
            }
        }

        [HttpDelete]
        [Route("aluno/excluir/{cpf}")]
        public IActionResult Excluir(long cpf)
        {
            try
            {
                _service.Delete(cpf);
                return Ok(new
                {
                    success = true,
                    data = "Registro excluído com sucesso!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = ex.Message
                });
            }
        }
    }
}
