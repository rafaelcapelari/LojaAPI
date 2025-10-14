using System;
using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;
using LojaApi.Services.Interfaces;

namespace LojaApi.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    // O Service agora recebe sua dependência (o contrato do repositório) via construtor.
    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public List<Produto> ObterTodos()
    {
        return _produtoRepository.ObterTodos().ToList();
    }

    public Produto? ObterPorId(int id)
    {
        return _produtoRepository.ObterPorId(id);
    }

    public Produto Adicionar(Produto novoProduto)
    {
        novoProduto.Codigo = novoProduto.Codigo.ToUpper();
        novoProduto.Descricao = novoProduto.Descricao.ToUpper();
        novoProduto.Estoque = 0m;
        novoProduto.DataCadastro = DateTime.UtcNow;
        
        return _produtoRepository.Adicionar(novoProduto);
    }

    public Produto? Atualizar(int id, Produto produtoAtualizado)
    {
        if (id != produtoAtualizado.Id) return null;
        return _produtoRepository.Atualizar(id, produtoAtualizado);
    }

public bool Remover(int id)
{
    var produto = _produtoRepository.ObterPorId(id);
    if (produto != null)
    {
        return _produtoRepository.Atualizar(id, produto) != null;
    }
    return false;
}
    
}
