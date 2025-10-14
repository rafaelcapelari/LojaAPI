using System;
using LojaApi.Entities;

namespace LojaApi.Repositories.Interfaces;

public class CategoriaRepository
{
    public readonly List<Categoria> _categorias = new List<Categoria>
    {
        new Categoria {Id = 1, Descricao = "Condutores"},
        new Categoria {Id = 2, Descricao = "Isolantes"},
        new Categoria {Id = 3, Descricao = "Aço"}
    };

    private int _nextId = 4;

    public List<Categoria> ObterTodos() => _categorias;

    public Categoria? ObterPorId(int id)
    {
        return _categorias.FirstOrDefault(c => c.Id == id);
    }

    public Categoria Adicionar(Categoria novaCategoria)
    {
        novaCategoria.Id = _nextId++;
        _categorias.Add(novaCategoria);
        return novaCategoria;
    }

    public Categoria? Atualizar(int id, Categoria categoriaAtualizada)
    {
        var categoria = ObterPorId(id);
        if (categoria == null) return null;

        categoria.Descricao = categoriaAtualizada.Descricao;

        return categoria;
    }
    public bool Remover(int id)
    {
        var categoria = ObterPorId(id);
        if (categoria == null) return false;

        _categorias.Remove(categoria);
        return true;
    }

}
