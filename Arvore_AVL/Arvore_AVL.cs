using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvore_AVL
{
    class Arvore_AVL
    {
        private No Raiz { get; set; }

        public Arvore_AVL() 
        {
            Raiz = null;
        }

        public void Inserir(int Valor) 
        {
            Inserir(Valor, Raiz);
        }

        private void Inserir(int Valor, No Atual)
        {
            if (Vazio())
            {
                No novo = new No(Valor);
                Raiz = novo;
                DefineFB(Raiz);
            }
            else
            {
                if (Valor < Atual.GetValor())
                {
                    if (Atual.GetFilhoEsq() == null)
                    {
                        No novo = new No(Valor);
                        Atual.InserirFilhoEsq(novo);
                        novo.InserirPai(Atual);
                        DefineFB(Raiz);
                        Raiz = Balanceia(Raiz);
                    }
                    else
                    {
                        Inserir(Valor, Atual.GetFilhoEsq());
                    }
                }
                if (Valor > Atual.GetValor())
                {
                    if (Atual.GetFilhoDir() == null)
                    {
                        No novo = new No(Valor);
                        Atual.InserirFilhoDir(novo);
                        novo.InserirPai(Atual);
                        DefineFB(Raiz);
                        Raiz = Balanceia(Raiz);
                    }
                    else
                    {
                        Inserir(Valor, Atual.GetFilhoDir());
                    }
                }
            }
        }

        public void Remover(int Valor) 
        {
            Remover(Valor, Raiz);
        }

        private No Remover(int Valor, No Atual) 
        {
            if (Vazio())
                Console.WriteLine("Arvore vazia!");

            if (Valor < Atual.GetValor())
                Atual.InserirFilhoEsq(Remover(Valor, Atual.GetFilhoEsq()));
            if (Valor > Atual.GetValor())
                Atual.InserirFilhoDir(Remover(Valor, Atual.GetFilhoDir()));            
            else
            {
                if (Atual.GetFilhoDir() == null && Atual.GetFilhoEsq() == null)
                {
                    if (Atual == Raiz)
                    {
                        Raiz = null;
                    }
                    else
                    {
                        Atual = null;
                    }

                }
                else if (Atual.GetFilhoEsq() == null)
                    Atual = Atual.GetFilhoDir();
                else if (Atual.GetFilhoDir() == null)
                    Atual = Atual.GetFilhoEsq();
                else
                {
                    No aux = Atual.GetFilhoEsq();
                    while (aux.GetFilhoDir() != null)
                    {
                        aux = aux.GetFilhoDir();
                    }
                    Atual.InserirValor(aux.GetValor());
                    aux.InserirValor(Valor);
                    Atual.InserirFilhoEsq(Remover(Valor, Atual.GetFilhoEsq()));              
                }
            }
            if (Raiz != null)
            {
                DefineFB(Raiz);
                Raiz = Balanceia(Raiz);
            }
            return Atual;
        }

        public void Consultar(int Valor) 
        {
            Consultar(Valor, Raiz);
        }

        private void Consultar(int Valor, No Atual) 
        {
            if (Atual != null)
            {
                if (Valor == Atual.GetValor())
                    Console.WriteLine("Nó existente!");

                Consultar(Valor, Atual.GetFilhoEsq());
                Consultar(Valor, Atual.GetFilhoDir());
            }            
        }

        public void PrintArvore() 
        {
            PrintArvore(Raiz);
        }

        private void PrintArvore(No Atual) 
        {
            if (Vazio())
                Console.WriteLine("Arvore vazia!");

            if (Atual != Raiz)
                Console.WriteLine("No Pai: " + Atual.GetPai().GetValor() + ", No: " + Atual.GetValor());
            else
                Console.WriteLine("Raiz: " + Atual.GetValor());
            if (Atual.GetFilhoEsq() != null)
            {
                PrintArvore(Atual.GetFilhoEsq());
            }
            if (Atual.GetFilhoDir() != null)
            {
                PrintArvore(Atual.GetFilhoDir());
            }
        }

        public bool Vazio() 
        {
            return Raiz == null;
        }

        public void DefineFB(No Atual) 
        {
            Atual.InserirBalanceamento(Altura(Atual.GetFilhoEsq()) - Altura(Atual.GetFilhoDir()));
            if (Atual.GetFilhoEsq() != null)
                DefineFB(Atual.GetFilhoEsq());
            if (Atual.GetFilhoDir() != null)
                DefineFB(Atual.GetFilhoDir());
        }

        public int Altura(No Atual)
        {
            if (Atual == null)
                return -1;
            if (Atual.GetFilhoDir() == null && Atual.GetFilhoEsq() == null)
                return 0;
            if (Atual.GetFilhoEsq() == null)
                return 1 + Altura(Atual.GetFilhoDir());
            if (Atual.GetFilhoDir() == null)
                return 1 + Altura(Atual.GetFilhoEsq());
            else
            {
                if (Altura(Atual.GetFilhoEsq()) > Altura(Atual.GetFilhoDir()))
                    return 1 + Altura(Atual.GetFilhoEsq());
                else
                    return 1 + Altura(Atual.GetFilhoDir());
            }
        }

        public No Balanceia(No Atual)
        {
            if (Atual.GetBalanceamento() == 2 && Atual.GetFilhoEsq().GetBalanceamento() >= 0)
            {
                Console.WriteLine("Arvore Desbalanceada!");
                Console.WriteLine("A Rotacao a direita será aplicada!");
                Console.ReadLine();
                Atual = RotacaoDireita(Atual);
            }
            if (Atual.GetBalanceamento() == -2 && Atual.GetFilhoDir().GetBalanceamento() <= 0)
            {
                Console.WriteLine("Arvore Desbalanceada!");
                Console.WriteLine("A Rotacao a esquerda será aplicada!");
                Console.ReadLine();
                Atual = RotacaoEsquerda(Atual);
            }
            if (Atual.GetBalanceamento() == 2 && Atual.GetFilhoEsq().GetBalanceamento() < 0)
            {
                Console.WriteLine("Arvore Desbalanceada!");
                Console.WriteLine("A Rotacao dupla a direita será aplicada!");
                Console.ReadLine();
                Atual = RotacaoDuplaDireita(Atual);
            }
            if (Atual.GetBalanceamento() == -2 && Atual.GetFilhoDir().GetBalanceamento() > 0)
            {
                Console.WriteLine("Arvore Desbalanceada!");
                Console.WriteLine("A Rotacao dupla a esquerda será aplicada!");
                Console.ReadLine();
                Atual = RotacaoDuplaEsquerda(Atual);
            }                

            if (Atual.GetFilhoDir() != null)
                Balanceia(Atual.GetFilhoDir());
            if (Atual.GetFilhoEsq() != null)
                Balanceia(Atual.GetFilhoEsq());
            return Atual;
        }

        public No RotacaoDireita(No Atual)
        {
            No aux = Atual.GetFilhoEsq();
            aux.InserirPai(Atual.GetPai());
            if (aux.GetFilhoDir() != null)
                aux.GetFilhoDir().InserirPai(Atual);
            Atual.InserirPai(aux);
            Atual.InserirFilhoEsq(aux.GetFilhoDir());
            aux.InserirFilhoDir(Atual); 
            if (aux.GetPai() != null)
            {
                if (aux.GetPai().GetFilhoDir() == Atual)
                    aux.GetPai().InserirFilhoDir(aux);
                else if (aux.GetPai().GetFilhoEsq() == Atual)
                    aux.GetPai().InserirFilhoEsq(aux);
            }
            DefineFB(aux);
            return aux;
        }

        public No RotacaoEsquerda(No Atual)
        {
            No aux = Atual.GetFilhoDir();
            aux.InserirPai(Atual.GetPai());
            if (aux.GetFilhoEsq() != null)
                aux.GetFilhoEsq().InserirPai(Atual);

            Atual.InserirPai(aux);
            Atual.InserirFilhoDir(aux.GetFilhoEsq());
            aux.InserirFilhoEsq(Atual);
            if (aux.GetPai() != null)
            {
                if (aux.GetPai().GetFilhoDir() == Atual)
                    aux.GetPai().InserirFilhoDir(aux);
                else if (aux.GetPai().GetFilhoEsq() == Atual)
                    aux.GetPai().InserirFilhoEsq(aux);
            }
            DefineFB(aux);
            return aux;
        }

        public No RotacaoDuplaDireita(No atual)
        {
            No aux = atual.GetFilhoEsq();
            atual.InserirFilhoEsq(RotacaoEsquerda(aux));
            No aux2 = RotacaoDireita(atual);
            return aux2;
        }

        public No RotacaoDuplaEsquerda(No atual)
        {
            No aux = atual.GetFilhoDir();
            atual.InserirFilhoDir(RotacaoDireita(aux));
            No aux2 = RotacaoEsquerda(atual);
            return aux2;
        }
    }
}
