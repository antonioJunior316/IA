using System;
using System.Collections.Generic;

class BuscaCompetitiva
{
    static int Minimax(object no, int profundidade, bool maximizando, int alfa, int beta)
    {
 
        if (profundidade == 0 || no is int)
        {
            return (int)no;
        }

        var filhos = (List<object>)no;

        if (maximizando) 
        {
            int valor = int.MinValue;

            foreach (var filho in filhos)
            {
                valor = Math.Max(valor, Minimax(filho, profundidade - 1, false, alfa, beta));
                alfa = Math.Max(alfa, valor);

                if (beta <= alfa)
                    break;
            }
            return valor;
        }
        else 
        {
            int valor = int.MaxValue;

            foreach (var filho in filhos)
            {
                valor = Math.Min(valor, Minimax(filho, profundidade - 1, true, alfa, beta));
                beta = Math.Min(beta, valor);

                if (beta <= alfa)
                    break;
            }
            return valor;
        }
    }

    static void Main()
    {
       
        var arvore = new List<object>
        {
            new List<object> { 3, 5, 6 },
            new List<object> { 2, 9, -1 },
            new List<object> { 0, -2, 4 }
        };

        int resultado = Minimax(
            arvore,
            profundidade: 2,
            maximizando: true,
            alfa: int.MinValue,
            beta: int.MaxValue
        );

        Console.WriteLine("Busca Competitiva (Minimax c/ Alfa-Beta): " + resultado);
    }
}
