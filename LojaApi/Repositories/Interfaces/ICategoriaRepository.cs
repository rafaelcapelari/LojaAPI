using System;
using LojaApi.Entities;

namespace LojaApi.Repositories.Interfaces;

public interface ICategoriaRepository
{
    List<Categoria> ObterTodas();
    Categoria? ObterPorId(int id);
    Categoria Adicionar(Categoria novaCategoria);
    Categoria? Atualizar(int id, Categoria categoriaAtualizada);
    bool Remover(int id);
}
