using LojaApi.Entities;
using LojaApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<Produto>> GetAll()
        {
            var produtos = ProdutoRepository.GetAll();
            // 200 OK - Sucesso 
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> GetById(int id)
        {
            var produto = ProdutoRepository.GetById(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Cliente> Add(Produto novoProduto)
        {
            if (string.IsNullOrWhiteSpace(novoProduto.Codigo))
            {
                return BadRequest("O codigo do produto é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(novoProduto.Descricao))
            {
                return BadRequest("A descrição do produto é obrigatório.");
            }

            var produtoCriado = ProdutoRepository.Add(novoProduto);

            return CreatedAtAction(nameof(GetById), new { id = produtoCriado.Id }, produtoCriado);
        }
        
        [HttpPut("{id}")] 
        public ActionResult<Produto> Update(int id, Produto produtoAtualizado) 
        { 
            if (string.IsNullOrWhiteSpace(produtoAtualizado.Codigo))
            {
                return BadRequest("O codigo do produto é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(produtoAtualizado.Descricao))
            {
                return BadRequest("A descrição do produto é obrigatório.");
            }
            if (produtoAtualizado.Estoque < 0)
            {
                return BadRequest("Estoque não pode ser negativo.");
            }
             
            var produto = ProdutoRepository.Update(id, produtoAtualizado); 
 
            if (produto == null) 
            {  
                return NotFound(); 
            } 
 
            return Ok(produto);  
        } 
 
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id) 
        { 
            var sucesso = ProdutoRepository.Delete(id); 
 
            if (!sucesso) 
            { 
                return NotFound(); 
            } 
 
            return NoContent();  
        } 

    }
}
