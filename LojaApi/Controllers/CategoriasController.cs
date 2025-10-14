using LojaApi.Entities;
using LojaApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        public ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public ActionResult<List<Categoria>> ObterTodas()
        {
            return Ok(_categoriaService.ObterTodas());
        }

        [HttpGet("{id}")]
        public ActionResult<Categoria> ObterPorId(int id)
        {
            var categoria = _categoriaService.ObterPorId(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult<Categoria> Adicionar(Categoria novaCategoria)
        {
            if (string.IsNullOrWhiteSpace(novaCategoria.Descricao))
            {
                return BadRequest("A descrição da categoria é obrigatoria");
            }

            var categoria = _categoriaService.Adicionar(novaCategoria);
            return CreatedAtAction(nameof(ObterPorId), new { id = categoria.Id }, categoria);
        }

        [HttpPut("id")]
        public ActionResult<Categoria> Atualizar(int id, Categoria categoriaAtualizada)
        {
            if (string.IsNullOrWhiteSpace(categoriaAtualizada.Descricao))
            {
                return BadRequest("A descrição da categoria é obrigatoria");
            }

            var categoria = _categoriaService.Atualizar(id, categoriaAtualizada);
            if (categoria == null) return NotFound();

            return Ok(categoria);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var sucesso = _categoriaService.Remover(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}
