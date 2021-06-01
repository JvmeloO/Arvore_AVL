using System;

namespace Arvore_AVL
{
    class Program
    {
        static void Main(string[] args)
        {
            Arvore_AVL arvore_AVL = new Arvore_AVL();
            arvore_AVL.Inserir(20);
            arvore_AVL.Inserir(15);
            arvore_AVL.Inserir(10);
            arvore_AVL.Inserir(9);
            arvore_AVL.Inserir(25);
            arvore_AVL.Inserir(33);
            arvore_AVL.Inserir(38);
            arvore_AVL.Inserir(40);
            //arvore_AVL.Remover(5);
            arvore_AVL.PrintArvore();
            //arvore_AVL.Consultar(10);
        }
    }
}
