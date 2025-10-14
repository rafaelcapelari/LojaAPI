using System;
using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;
using LojaApi.Services.Interfaces;

namespace LojaApi.Services;

//Service contem as regras de negocio

public class CategoriaService : ICategoriaService
{
    public readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public List<Categoria> ObterTodas()
    {
        return _categoriaRepository.ObterTodas().ToList(); // Exemplo filtrar apenas ativas, que nesse caso nao existe
    }

    public Categoria? ObterPorId(int id)
    {
        return _categoriaRepository.ObterPorId(id);
    }

    public Categoria Adicionar(Categoria novaCategoria)
    {
        novaCategoria.Descricao = novaCategoria.Descricao.ToUpper(); /* trata valores */
        _categoriaRepository.Adicionar(novaCategoria);

        return novaCategoria;
    }

    public Categoria? Atualizar(int id, Categoria categoriaAtualizada)
    {
        if (id != categoriaAtualizada.Id) return null;

        _categoriaRepository.Atualizar(id, categoriaAtualizada);

        return categoriaAtualizada;
    }
    
    public bool Remover(int id)
    {
        var categoria = ObterPorId(id);
        if (categoria != null)
        {
            //delete "logico", faz atualização na tabela
            //categoria.Deletado = "Sim";
            //_categoriaRepository.Atualizar(id, categoria);

            return true; // retorna o resultado da atualizacao, com conteudo = true, e nulo = false, deu errado a atualização por algum motivo
        }

        //_categoriaRepository.Remover(id); -- delete "fisico"
        return false;
    }
}
