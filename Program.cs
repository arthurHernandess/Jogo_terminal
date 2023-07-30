using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Player player = new Player("Arthu", 20, 110, null);

                Bau bau1 = new Bau(true, false, 100);
                Bau bau2 = new Bau(false, false, 50);
                Bau bau3 = new Bau(false, true, 0);

                List<Bau> baus = new List<Bau>();
                baus.Add(bau1);
                baus.Add(bau2);
                baus.Add(bau3);
                
                int rdm_vl = 0;
                Random random = new Random();
                rdm_vl = random.Next(1, baus.Count + 1);

                Item pocao = new Item("Poção de regeneração", 10);
                Item chave = new Item("Chave do bau " + rdm_vl, 1);

                List<Item> sacola = new List<Item>();
                sacola.Add(pocao);
                sacola.Add(chave);
                

                ConsoleKeyInfo Tecla;

                int i = 0;
                int j = 1;

                while (i != 1)
                {
                    #region Load inicial padrão
                    string P_Item = "";
                    if (player.item == null)
                    {
                        P_Item = "Vazio";
                    }
                    else
                    {
                        P_Item = player.item.Nome;
                    }

                    Console.WriteLine("Nome: " + player.Nome + " | HP: " + player.Vida + " | Moedas: " + player.Moedas + " | Inventário: " + P_Item);
                    Console.WriteLine("");
                    #endregion

                    #region Sacola
                    if (j % 2 == 0)
                    {
                        Console.WriteLine("Você encontrou uma sacola de itens: ");
                        for (int g = 0; g < sacola.Count; g++)
                        {
                            Console.WriteLine(g + 1 + " - " + sacola[g].Nome);
                        }

                        Console.WriteLine($"Recolha um item (digite 1 ou 2) ou digite {sacola.Count + 1} para ignorar");
                        string itemEscolhido = Console.ReadLine();
                        int indiceItem = 0;

                        if (int.Parse(itemEscolhido) != sacola.Count + 1)
                        {
                            try
                            {
                                while (int.Parse(itemEscolhido) > sacola.Count)
                                {
                                    Console.WriteLine("Só existem " + sacola.Count + " Itens na sacola");
                                    itemEscolhido = Console.ReadLine();
                                }

                                indiceItem = int.Parse(itemEscolhido) - 1;

                                Console.WriteLine("");
                                Console.WriteLine("Você recebeu: " + sacola[indiceItem].Nome);
                                player.item = sacola[indiceItem];

                                if (player.item.Nome == "Poção de regeneração")
                                {
                                    Console.WriteLine("usar | guardar");

                                    string acaoItem = Console.ReadLine().ToUpper();

                                    while (acaoItem != "USAR" && acaoItem != "GUARDAR")
                                    {
                                        Console.WriteLine("escolha usar ou guardar: ");
                                        acaoItem = Console.ReadLine().ToUpper();
                                    }

                                    if (acaoItem == "USAR")
                                    {
                                        player.Vida = player.Vida + player.item.Valor;
                                        player.item = null;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Procure um baú para tentar destrancar");
                                    Console.ReadKey();
                                }
                            }
                            catch (Exception erro)
                            {
                                throw erro;
                            }
                        }
                        rdm_vl = random.Next(1, baus.Count + 1);
                        sacola.RemoveAt(1);
                        chave = new Item("Chave do bau " + rdm_vl, 1);
                        sacola.Add(chave);
                        j = 1;
                        Console.Clear();
                    }
                    #endregion
                    #region Baú
                    else
                    {
                        Console.WriteLine("(baú até n° " + baus.Count + ") | (Abrir ou destrancar)");

                        Console.WriteLine("Escolha o baú: ");
                        string NumeroBau = Console.ReadLine();
                        int bauIndx = int.Parse(NumeroBau) - 1;

                        while (NumeroBau != "1" && NumeroBau != "2" && NumeroBau != "3")
                        {
                            Console.WriteLine("Só existem " + baus.Count + " Baús");
                            NumeroBau = Console.ReadLine();
                            bauIndx = int.Parse(NumeroBau)-1;
                        }

                        Console.WriteLine("Escolha a ação: ");
                        string acaoBau = Console.ReadLine().ToUpper();

                        while (acaoBau != "ABRIR" && acaoBau != "DESTRANCAR")
                        {
                            Console.WriteLine("a ação deve ser abrir ou destrancar!");
                            acaoBau = Console.ReadLine().ToUpper();
                        }

                        if (acaoBau == "ABRIR")
                        {
                            int resposta = baus[bauIndx].abrir();
                            if (resposta >= 0)
                            {
                                player.Moedas = player.Moedas + baus[bauIndx].ValorMoedas;
                                Console.WriteLine("Você recebeu " + baus[bauIndx].ValorMoedas + " moedas");
                                baus[bauIndx].ValorMoedas = 0;
                            }
                            else
                            {
                                if (resposta == -1)
                                {
                                    Console.WriteLine("Bau está trancado");
                                }
                                else
                                {
                                    Console.WriteLine("Bau já está aberto");
                                }
                            }
                        }
                        else
                        {
                            baus[bauIndx].destrancar(player, NumeroBau);
                        }
                        //Console.WriteLine("moedas player: " + player.Moedas);
                        //Console.WriteLine("bau moedas " + baus[int.Parse(NumeroBau) - 1].ValorMoedas);
                        Console.ReadKey();

                        j = 2;
                        Console.Clear();
                    }
                    #endregion
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
