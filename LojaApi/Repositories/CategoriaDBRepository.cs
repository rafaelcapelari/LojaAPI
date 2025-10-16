using System;
using LojaApi.Data;
using LojaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaApi.Repositories.Interfaces;

public class CategoriaDBRepository : ICategoriaRepository
{
    private readonly LojaContext _context;

    public CategoriaDBRepository(LojaContext context)
    {
        _context = context;
    }

    public List<Categoria> ObterTodas()
    {
        return _context.Categorias.Include(p => p.Produtos).ToList();
    }

    public Categoria? ObterPorId(int id)
    {
        return _context.Categorias.Include(p => p.Produtos).FirstOrDefault(c => c.Id == id);
    }

    public Categoria Adicionar(Categoria novaCategoria)
    {
        _context.Categorias.Add(novaCategoria);
        _context.SaveChanges();
        return novaCategoria;
    }

    public Categoria? Atualizar(int id, Categoria categoriaAtualizada)
    {
        _context.Categorias.Update(categoriaAtualizada);
        _context.SaveChanges();
        return categoriaAtualizada;
    }

    public bool Remover(int id)
    {
        var categoria = ObterPorId(id);

        if (categoria == null) return false;
        _context.Categorias.Remove(categoria);
        _context.SaveChanges();
        return true;
    }
}
