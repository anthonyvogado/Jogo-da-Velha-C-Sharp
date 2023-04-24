namespace Jogo_da_Velha
{
    internal class Program
    {

        public static int verificaEmpate(string[,] matriz)
        {
            int resultado = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (string.IsNullOrWhiteSpace(matriz[i, j]))
                    {
                        resultado = 1;
                    }
                }
            }
            if (resultado == 0)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }

        public static string[,] zerarMatriz(string[,] matriz)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matriz[i, j] = " ";
                }
            }
            return matriz;
        }

        public static int verificaMatriz(string[,] matriz)
        {
            int vencedor = 0;
            int contadorLinhaX, contadorLinhaO;

            //Verificador de Linhas
            for (int i = 0; i < 3; i++)
            {
                contadorLinhaX = 0;
                contadorLinhaO = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (matriz[i, j] == "X")
                    {
                        contadorLinhaX++;
                    }
                    else if (matriz[i, j] == "O")
                    {
                        contadorLinhaO++;
                    }
                }
                if (contadorLinhaX == 3)
                {
                    vencedor = 1;
                    break;
                }
                if (contadorLinhaO == 3)
                {
                    vencedor = 2;
                    break;
                }
            }
            //Verificador de Colunas
            for (int i = 0; i < 3; i++)
            {
                contadorLinhaX = 0;
                contadorLinhaO = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (matriz[j, i] == "X")
                    {
                        contadorLinhaX++;
                    }
                    else if (matriz[j, i] == "O")
                    {
                        contadorLinhaO++;
                    }
                }
                if (contadorLinhaX == 3)
                {
                    vencedor = 1;
                    break;
                }
                if (contadorLinhaO == 3)
                {
                    vencedor = 2;
                    break;
                }
            }

            //cadeia de IF para diagonal esquerda pra direita

            //diagonal esquerda pra direita conferindo "X"
            if (vencedor == 0)
            {
                if (matriz[0, 0] == "X" && matriz[1, 1] == "X" && matriz[2, 2] == "X")
                    vencedor = 1;

                //diagonal esquerda pra direita conferindo "O"
                else if (matriz[0, 0] == "O" && matriz[1, 1] == "O" && matriz[2, 2] == "O")
                    vencedor = 2;
                //fim da cadeia de diagonal esquerda pra direita

                //cadeia de IF para diagonal direita pra esquerda

                //diagonal direita pra esquerda conferindo "X"
                else if (matriz[2, 0] == "X" && matriz[1, 1] == "X" && matriz[0, 2] == "X")
                    vencedor = 1;

                //diagonal direita pra esquerda conferindo "O"
                else if (matriz[2, 0] == "O" && matriz[1, 1] == "O" && matriz[0, 2] == "O")
                    vencedor = 2;
                else
                    vencedor = verificaEmpate(matriz);
            }


            return vencedor;
        }

        public static void mostrarMatriz(string[,] matriz)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", matriz[0, 0], matriz[0, 1], matriz[0, 2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", matriz[1, 0], matriz[1, 1], matriz[1, 2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", matriz[2, 0], matriz[2, 1], matriz[2, 2]);
            Console.WriteLine("     |     |      ");

        }
        static void Main(string[] args)
        {
            int linha, coluna, vencedor = 0;
            string[,] matriz = new string[3, 3];
            bool jogadaValida = false;
            Console.WriteLine("Iniciando jogo da velha");
            Thread.Sleep(2000);

            //estetica da matriz
            matriz = zerarMatriz(matriz);

            Console.Clear();

            mostrarMatriz(matriz);

                do
                {
                    if (vencedor != 1 && vencedor != 2 && vencedor != 3)
                    {
                        do
                        {
                            Console.WriteLine("\nVez do jogador 1 (X): ");
                            Console.Write("Linha: ");
                            linha = int.Parse(Console.ReadLine());
                            Console.Write("Coluna: ");
                            coluna = int.Parse(Console.ReadLine());
                            if (matriz[linha, coluna] != " ")
                                Console.WriteLine("\nPosição já ocupada, jogue novamente");
                        } while (matriz[linha, coluna] != " ");

                        matriz[linha, coluna] = "X";

                        //mostrar a matriz
                        Console.Clear();
                        mostrarMatriz(matriz);
                    }
                    vencedor = verificaMatriz(matriz);
                    if (vencedor != 1 && vencedor != 2 && vencedor != 3)
                    {
                        do
                        {
                            Console.WriteLine("\nVez do jogador 2 (O): ");
                            Console.Write("Linha: ");
                            linha = int.Parse(Console.ReadLine());
                            Console.Write("Coluna: ");
                            coluna = int.Parse(Console.ReadLine());
                            if (matriz[linha, coluna] != " ")
                                Console.WriteLine("\nPosição já ocupada, jogue novamente");
                        } while (matriz[linha, coluna] != " ");

                        matriz[linha, coluna] = "O";

                        //mostrar a matriz
                        Console.Clear();
                        mostrarMatriz(matriz);
                    }
                    vencedor = verificaMatriz(matriz);
                    if (vencedor == 3)
                    {
                        Console.WriteLine("\nO JOGO EMPATOU!");
                        Console.WriteLine("Reiniciando...");
                        Thread.Sleep(2000);
                        Console.Clear();
                        vencedor = 0;
                        matriz = zerarMatriz(matriz);
                        mostrarMatriz(matriz);

                    }
                } while (vencedor == 0);

                if (vencedor == 1)
                    Console.WriteLine("\nO jogador 1 venceu!");
                if (vencedor == 2)
                    Console.WriteLine("\nO jogador 2 venceu!");
            
        }
    }
}