using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvore_AVL
{
    class No
    {
        private No Pai { get; set; }
        private No FilhoEsq { get; set; }
        private No FilhoDir { get; set; }
        private int Balanceamento { get; set; }
        private int Valor { get; set; }

        public No(int Valor)
        {
            this.Valor = Valor;
        }

        public No GetPai()
        {
            return Pai;
        }

        public int GetValor()
        {
            return Valor;
        }

        public int GetBalanceamento() 
        {
            return Balanceamento;
        }

        public No GetFilhoEsq() 
        {
            return FilhoEsq;
        }

        public No GetFilhoDir() 
        {
            return FilhoDir;
        }

        public void InserirBalanceamento(int Balanceamento)
        {
            this.Balanceamento = Balanceamento;
        }

        public void InserirValor(int Valor) 
        {
            this.Valor = Valor;
        }

        public void InserirPai(No Pai) 
        {
            this.Pai = Pai;
        }

        public void InserirFilhoEsq(No FilhoEsq) 
        {
            this.FilhoEsq = FilhoEsq;
        }

        public void InserirFilhoDir(No FilhoDir)
        {
            this.FilhoDir = FilhoDir;
        }
    }
}
