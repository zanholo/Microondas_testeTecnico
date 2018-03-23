using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroOndas.Classes
{
    public class ProdutosProntos : Aquecimento
    {
        private int intId;
        private Aquecimento objAquecido;
        private string strInstrucoes;
        private string strNomeProduto;
        private string strAquecer;


        public int Id
        {
            get { return intId; }
            set { intId = value; }
        }

        public string Instrucoes
        {
            get { return strInstrucoes; }
            set { strInstrucoes = value; }
        }

        public string NomeProduto
        {
            get { return strNomeProduto; }
            set { strNomeProduto = value; }
        }
        
        public string Aquecer
        {
            get { return strAquecer; }
            set { strAquecer = value; }
        }

        public Aquecimento Aquecimento
        {
            get { return objAquecido; }
            set { objAquecido = value; }
        }

        public ProdutosProntos()
        {
            intId = 0;
            objAquecido = new Aquecimento();
            strInstrucoes = "";
            strNomeProduto = "";
        }
    }
}