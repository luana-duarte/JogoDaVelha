using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelhaConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Matriz do Jogo da Velha
            const int jogadas = 9;
            char[,] matriz = new char[3, 3];
            char player = 'X'; //X sempre começa

            for (int jogada = 0; jogada < jogadas; jogada++)
            {
                Console.WriteLine("   0        1       2");
                Console.WriteLine("0: " + "     |   "  + "    |   " );
                Console.WriteLine("   ----------------");
                Console.WriteLine("1: "+ "     |   " +  "    |   " );
                Console.WriteLine("   ----------------");
                Console.WriteLine("2: "  + "    |   " +  "    |   " );
                Console.WriteLine("Digite a linha para player de 0 a 2  " + player);
                int linha = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a coluna para player de 0 a 2 " + player);
                int coluna = int.Parse(Console.ReadLine());

                //Marca a posição escolhida
                matriz[linha, coluna] = player;

                //Alterna o player atual
                if (player == 'X')
                    player = 'O';
                else
                    player = 'X';

                if (VerificaSeAlguemGanhou(matriz) != '\0')
                {
                    Console.WriteLine("Jogador " + VerificaSeAlguemGanhou(matriz) + " ganhou!");
                    break;
                }
            }
        }

        static char VerificaSeAlguemGanhou(char[,] matriz)
        {
            //Verifico as linhas
            for (int linha = 0; linha < 3; linha++)
            {
                char player = matriz[linha, 0];
                bool ganhou = true;
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    if (matriz[linha, coluna] != player)
                    {
                        ganhou = false;
                        break;
                    }
                }
                if (ganhou)
                    return player;
            }

            //Verifica colunas
            for (int coluna = 0; coluna < 3; coluna++)
            {
                char player = matriz[0, coluna];
                bool ganhou = true;
                for (int linha = 0; linha < 3; linha++)
                {
                    if (matriz[linha, coluna] != player)
                    {
                        ganhou = false;
                        break;
                    }
                }
                if (ganhou)
                    return player;
            }

            //Verifica a Diagonal Principal
            char playerGeral = matriz[0, 0];
            bool ganhouGeral = true;
            for (int i = 0; i < 3; i++)
            {
                if (matriz[i, i] != playerGeral)
                {
                    ganhouGeral = false;
                    break;
                }
            }
            if (ganhouGeral)
                return playerGeral;

            //Verifica a outra Diagonal 
            if (matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0])
                return matriz[0, 2];

            bool deuVelha = true;
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    if (matriz[linha, coluna] == '\0'
                        || matriz[linha, coluna] == ' ')
                    {
                        deuVelha = false;
                        break;
                    }
                }
            }
            if (deuVelha)
                return 'V';

            return '0'; //Ninguém ganhou mas o jogo ainda não acabou
        }
    }
}