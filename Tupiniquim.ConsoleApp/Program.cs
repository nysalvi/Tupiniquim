using System;
using System.Text.RegularExpressions;

namespace Tupiniquim.ConsoleApp
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            int xLimit, yLimit, direcaoAtual;
            int xCoor, yCoor;
            string[] comandos, direcoes = {"O", "N", "L", "S"};
            char[] comandoChar;
            string comandoTemp;
            while (true) {
                Console.WriteLine("Digite o valor máximo da coordenada X : ");
                if (!int.TryParse(Console.ReadLine(), out xLimit) || xLimit < 0) {
                    Console.WriteLine("Caracter inválido !!! \n\tDigite apenas números Inteiros Maiores que Zero!!!");
                    continue;
                }
                Console.WriteLine("Digite o valor máximo da coordenada Y : ");
                if (!int.TryParse(Console.ReadLine(), out yLimit) || yLimit < 0) {
                    Console.WriteLine("Caracter inválido !!! \n\tDigite apenas números Inteiros Maiores que Zero!!!");
                    continue;
                }
                break;
            }
            while (true) {
                Console.WriteLine("Digite a posição inicial e direção do robô : ");
                comandoTemp = Console.ReadLine();
                if (!Regex.IsMatch(comandoTemp, @"^[0-9] [0-9] (O|N|S|L)$")) {
                    Console.WriteLine("Erro!!!\nVocê deve digitar seguindo o padrão :\n\t1 - Um número(positivo)" +
                        "\n\t2 - Um espaço\n\t3 - Um número(positivo)\n\t4 - Um espaço\n\t5 - O ou N ou L ou S");
                    continue;
                }
                comandos = comandoTemp.Split(' ');
                (xCoor, yCoor) = (int.Parse(comandos[0]), int.Parse(comandos[1]));
                direcaoAtual = Array.IndexOf(direcoes, comandos[2]);

                Console.WriteLine("Digite os comandos de movimentos para o robô : ");
                comandoChar = Console.ReadLine().ToCharArray();
                if (Array.TrueForAll(comandoChar, x => x != 'E' && x != 'D' && x != 'M')) {
                    Console.WriteLine("Os comandos aceitos são : \n\tE - Virar à Esquerda\tD - Virar à Direita" +
                        "\tM - Mover");
                    continue;
                }
                foreach (char c in comandoChar) {
                    if (c == 'E') {
                        if (direcaoAtual == 0)
                            direcaoAtual = 3;                        
                        else 
                            direcaoAtual--;
                    }
                    else if (c == 'D') {
                        if (direcaoAtual == 3)
                            direcaoAtual = 0;
                        else
                            direcaoAtual++;
                    }
                    else {
                        if (direcoes[direcaoAtual] == "N") {
                            if (yCoor < yLimit)
                                yCoor++;
                        }
                        else if (direcoes[direcaoAtual] == "S") {
                            if (yCoor > 0)
                                yCoor--;
                        }
                        else if (direcoes[direcaoAtual] == "O") {
                                if (xCoor > 0)
                                    xCoor--;
                        }
                        else if (direcoes[direcaoAtual] == "L") {
                            if (xCoor < xLimit)
                                xCoor++;
                        }
                    }
                }
                Console.WriteLine("x : {0}\ny : {1}\nDireção : {2}", xCoor, yCoor, direcoes[direcaoAtual]);
                Console.WriteLine("Deseja continuar ?\n\tPressione 'N' para sair");
                if (Console.ReadLine() == "N")
                    break;                
            }
            Console.ReadLine();
        }
    }
}
