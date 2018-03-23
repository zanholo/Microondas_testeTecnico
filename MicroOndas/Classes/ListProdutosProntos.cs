using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroOndas.Classes
{
    public class ListProdutosProntos
    {

        private List<ProdutosProntos> listProdutosProntos;

        public ListProdutosProntos()
        {
            listProdutosProntos = new List<ProdutosProntos>();

            ProdutosProntos produto = new ProdutosProntos();
            Aquecimento aqueci = new Aquecimento();

            produto.Id = 0;
            produto.Instrucoes = "";
            produto.NomeProduto = "";
            produto.Aquecer = "";
            aqueci.Potencia = 0;
            aqueci.Tempo = 0;

            produto.Aquecimento = aqueci;

            listProdutosProntos.Add(produto);

            ///
            produto = new ProdutosProntos();
            aqueci = new Aquecimento();

            produto.Id = 1;
            produto.Instrucoes = "Cobrir o Produto antes do processo de aquecimento.";
            produto.NomeProduto = "Frango";
            aqueci.Potencia = 8;
            produto.Aquecer = "F";
            aqueci.Tempo = 120;

            produto.Aquecimento = aqueci;

            listProdutosProntos.Add(produto);

            //
            produto = new ProdutosProntos();
            aqueci = new Aquecimento();

            produto.Id = 2;
            produto.Instrucoes = "Verifique na embalagem o lado certo da emabalagem para cima.";
            produto.NomeProduto = "Pipoca";
            produto.Aquecer = "P";
            aqueci.Potencia = 8;
            aqueci.Tempo = 60;

            produto.Aquecimento = aqueci;

            listProdutosProntos.Add(produto);

            //
            produto = new ProdutosProntos();
            aqueci = new Aquecimento();

            produto.Id = 3;
            produto.Instrucoes = "";
            produto.NomeProduto = "Leite Quente";
            aqueci.Potencia = 2;
            produto.Aquecer = "L";
            aqueci.Tempo = 30;

            produto.Aquecimento = aqueci;

            listProdutosProntos.Add(produto);


            //
            produto = new ProdutosProntos();
            aqueci = new Aquecimento();

            produto.Id = 4;
            produto.Instrucoes = "Deixar a embalagem onde o produto está tampada, adicionar um pouco de água na embalagem.";
            produto.NomeProduto = "Arroz";
            aqueci.Potencia = 5;
            produto.Aquecer = "A";
            aqueci.Tempo = 80;

            produto.Aquecimento = aqueci;

            listProdutosProntos.Add(produto);


            //
            produto = new ProdutosProntos();
            aqueci = new Aquecimento();

            produto.Id = 5;
            produto.Instrucoes = "Deixar a embalagem onde o produto está tampada, adicionar um pouco de água na embalagem.";
            produto.NomeProduto = "Feijão";
            produto.Aquecer = "C";
            aqueci.Potencia = 5;
            aqueci.Tempo = 70;

            produto.Aquecimento = aqueci;

            listProdutosProntos.Add(produto);
        }


        public List<ProdutosProntos> RetornaLista()
        {
            return listProdutosProntos;
        }

        public static implicit operator List<object>(ListProdutosProntos v)
        {
            throw new NotImplementedException();
        }

        public List<ProdutosProntos> InsereRetornaLista(ProdutosProntos produtos, Aquecimento aqueci)
        {
            produtos.Id = listProdutosProntos.Count;
            produtos.Instrucoes = produtos.Instrucoes;
            produtos.NomeProduto = produtos.NomeProduto;
            produtos.Aquecer = produtos.Aquecer;
            aqueci.Potencia = produtos.Potencia;
            aqueci.Tempo = produtos.Tempo;

            produtos.Aquecimento = aqueci;

            listProdutosProntos.Add(produtos);

            return listProdutosProntos;
        }

    }
}
