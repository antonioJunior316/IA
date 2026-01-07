using System;
using System.Collections.Generic;

class BFSExample
{
    static List<string> BFS(
        Dictionary<string, List<string>> grafo,
        string inicio,
        string objetivo)
    {
        
        HashSet<string> visitados = new HashSet<string>();

      
        Queue<List<string>> fila = new Queue<List<string>>();

        fila.Enqueue(new List<string> { inicio });


        while (fila.Count > 0)
        {

            List<string> caminho = fila.Dequeue();

            string no = caminho[caminho.Count - 1];

            if (no == objetivo)
            {
                return caminho;
            }

            if (!visitados.Contains(no))
            {
                visitados.Add(no);

                
                if (grafo.ContainsKey(no))
                {
                    
                    foreach (string vizinho in grafo[no])
                    {
                    
                        List<string> novoCaminho = new List<string>(caminho);

                        novoCaminho.Add(vizinho);

                        fila.Enqueue(novoCaminho);
                    }
                }
            }
        }

        return null;
    }

    static void Main()
    {   

        var grafo = new Dictionary<string, List<string>>
        {
            { "A", new List<string> { "B", "C" } }, 
            { "B", new List<string> { "D", "E" } }, 
            { "C", new List<string> { "F" } }, 
            { "E", new List<string> { "F" } } 
        };

        List<string> resultado = BFS(grafo, "A", "F");

        if (resultado != null)
        {
            Console.WriteLine("busca Cega (bfs): " + string.Join(" -> ", resultado));
        }
        else
        {
            Console.WriteLine("Caminho não encontrado.");
        }
    }
}
