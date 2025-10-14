using LojaApi.Entities;
using LojaApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public ActionResult<List<Produto>> ObterTodos()
        {
            return Ok(_produtoService.ObterTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> ObterPorId(int id)
        {
            var produto = _produtoService.ObterPorId(id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> Adicionar(Produto novoProduto)
        {
            if (string.IsNullOrWhiteSpace(novoProduto.Codigo))
            {
                return BadRequest("O código do produto é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(novoProduto.Descricao))
            {
                return BadRequest("A descrição do produto é obrigatório.");
            }
            var produtoCriado = _produtoService.Adicionar(novoProduto);
            return CreatedAtAction(nameof(ObterPorId), new { id = produtoCriado.Id }, produtoCriado);
        }

        [HttpPut("{id}")]
        public ActionResult<Produto> Atualizar(int id, Produto produtoAtualizado)
        {
            if (string.IsNullOrWhiteSpace(produtoAtualizado.Codigo))
            {
                return BadRequest("O código do produto é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(produtoAtualizado.Descricao))
            {
                return BadRequest("A descrição do produto é obrigatório.");
            }
            var produto = _produtoService.Atualizar(id, produtoAtualizado);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sucesso = _produtoService.Remover(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }

    }
}
