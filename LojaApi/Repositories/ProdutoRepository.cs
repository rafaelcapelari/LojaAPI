using System;
using LojaApi.Entities;

namespace LojaApi.Repositories;

public class ProdutoRepository
{

    private readonly List<Produto> _produtos = new List<Produto>
        {
            new Produto { Id = 1, Codigo = "123", Descricao = "Papel", Estoque = 123.56m },
            new Produto { Id = 2, Codigo = "456", Descricao = "Cobre", Estoque = 50 },
            new Produto { Id = 3, Codigo = "789", Descricao = "Silicio", Estoque = 1589.124m }
        };

    private int _nextId = 4;

    public List<Produto> ObterTodos() => _produtos;

    public Produto? ObterPorId(int id)
    {
        return _produtos.FirstOrDefault(c => c.Id == id);
    }
    public Produto Adicionar(Produto novoProduto)
    {
        novoProduto.Id = _nextId++;
        _produtos.Add(novoProduto);
        return novoProduto;
    }
    public Produto? Atualizar(int id, Produto produtoAtualizado)
    {
        var produtoExistente = ObterPorId(id);
        if (produtoExistente == null) return null;

        produtoExistente.Codigo = produtoAtualizado.Codigo;
        produtoExistente.Descricao = produtoAtualizado.Descricao;
        produtoExistente.Estoque = produtoAtualizado.Estoque;

        return produtoExistente;
    }

    public bool Remover(int id)
    {
        var produtoParaDeletar = ObterPorId(id);
        if (produtoParaDeletar == null) return false;

        _produtos.Remove(produtoParaDeletar);
        return true;
    }    
}
