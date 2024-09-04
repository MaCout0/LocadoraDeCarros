﻿using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuloLocacao;

namespace LocadoraDeCarros.Dominio.ModuloTaxaServico;

public class TaxaServico : EntidadeBase
{
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public TipoCobrancaEnum TipoCobranca { get; set; }
    public List<Locacao> Locacoes { get; set; }

    protected TaxaServico()
    {
        Locacoes = new List<Locacao>();
    }

    public TaxaServico(string nome, decimal valor, TipoCobrancaEnum tipoCobranca) : this()
    {
        Nome = nome;
        Valor = valor;
        TipoCobranca = tipoCobranca;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Nome.Length < 3)
            erros.Add("O nome precisa conter ao menos 3 caracteres");

        if (Valor < 1.0m)
            erros.Add("O valor precisa ser ao menos 1");

        return erros;
    }
    
    public override string ToString()
    {
        return $"{Valor.ToString("C2")}\t{Nome}\t({TipoCobranca.ToString()})";
    }

    public decimal CalcularValor(int quantidadeDeDias)
    {
        if (TipoCobranca == TipoCobrancaEnum.Diaria)
            return Valor * quantidadeDeDias;

        return Valor;
    }
}