using LojaApi.Entities;

namespace LojaApi.Repositories;

public class ProdutoRepository
{
    private static List<Produto> _produtos = new List<Produto>
    {
        new Produto { Id = 1, Codigo = "123", Descricao = "Madeira", Estoque = 0 },
        new Produto { Id = 2, Codigo = "456", Descricao = "Aluminio", Estoque = 2.7m },
        new Produto { Id = 3, Codigo = "789", Descricao = "Papel", Estoque = 15 }
    };

    private static int _nextId = 4; // Variável para gerenciar o próximo ID 

    public static List<Produto> GetAll()
    {
        return _produtos;
    }

    public static Produto? GetById(int id)
    {
        return _produtos.FirstOrDefault(c => c.Id == id);
    }

    public static Produto Add(Produto novoProduto)
    {
        novoProduto.Id = _nextId++;
        _produtos.Add(novoProduto);
        return novoProduto;
    }
    
    public static Produto? Update(int id, Produto produtoAtualizado)
    {
        var produtoExistente = _produtos.FirstOrDefault(c => c.Id == id);

        if (produtoExistente == null)
        {
            return null; 
        }

        produtoExistente.Codigo = produtoAtualizado.Codigo;
        produtoExistente.Descricao = produtoAtualizado.Descricao;
        produtoExistente.Estoque = produtoAtualizado.Estoque; 

        return produtoExistente;
    }

    public static bool Delete(int id)
    {
        var produtoParaDeletar = _produtos.FirstOrDefault(c => c.Id == id);

        if (produtoParaDeletar == null)
        {
            return false;
        }

        _produtos.Remove(produtoParaDeletar);
        return true;
    }
}
