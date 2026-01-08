using System;
using System.Collections.Generic;

class LabirintoBFS
{
   
    struct Posicao
    {
        public int X;
        public int Y;

        public Posicao(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

   
    static List<Posicao> BfsLabirinto(int[,] labirinto, Posicao inicio, Posicao objetivo)
    {
        int linhas = labirinto.GetLength(0);
        int colunas = labirinto.GetLength(1);

      
        Queue<(Posicao, List<Posicao>)> fila = new Queue<(Posicao, List<Posicao>)>();

  
        HashSet<(int, int)> visitados = new HashSet<(int, int)>();

        fila.Enqueue((inicio, new List<Posicao> { inicio }));
        visitados.Add((inicio.X, inicio.Y));

    
        int[] dx = { 0, 0, 1, -1 };
        int[] dy = { 1, -1, 0, 0 };

        while (fila.Count > 0)
        {
            var (atual, caminho) = fila.Dequeue();

            if (atual.X == objetivo.X && atual.Y == objetivo.Y)
                return caminho;

            for (int i = 0; i < 4; i++)
            {
                int nx = atual.X + dx[i];
                int ny = atual.Y + dy[i];

                if (nx >= 0 && nx < linhas &&
                    ny >= 0 && ny < colunas &&
                    labirinto[nx, ny] == 0 &&
                    !visitados.Contains((nx, ny)))
                {
                    var novaPosicao = new Posicao(nx, ny);
                    var novoCaminho = new List<Posicao>(caminho) { novaPosicao };

                    fila.Enqueue((novaPosicao, novoCaminho));
                    visitados.Add((nx, ny));
                }
            }
        }

        return null;
    }

    static void ExibirLabirinto(int[,] labirinto, List<Posicao> caminho)
    {
        int linhas = labirinto.GetLength(0);
        int colunas = labirinto.GetLength(1);

        HashSet<(int, int)> caminhoSet = new HashSet<(int, int)>();
        if (caminho != null)
        {
            foreach (var p in caminho)
                caminhoSet.Add((p.X, p.Y));
        }

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                if (caminhoSet.Contains((i, j)))
                    Console.Write("*");
                else if (labirinto[i, j] == 1)
                    Console.Write("#");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int[,] labirinto =
        {
            {0,1,0,0,0},
            {0,1,0,1,0},
            {0,0,0,1,0},
            {1,1,0,0,0}
        };

        Posicao inicio = new Posicao(0, 0);
        Posicao objetivo = new Posicao(3, 4);

        var caminho = BfsLabirinto(labirinto, inicio, objetivo);

        Console.WriteLine("Caminho encontrado (BFS):");
        if (caminho != null)
        {
            foreach (var p in caminho)
                Console.Write($"({p.X},{p.Y}) ");
        }
        else
        {
            Console.WriteLine("Nenhum caminho encontrado.");
        }

        Console.WriteLine("\n\nLabirinto com o caminho:");
        ExibirLabirinto(labirinto, caminho);
    }
}
