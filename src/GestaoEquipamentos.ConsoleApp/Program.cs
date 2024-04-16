using System.ComponentModel.Design;

namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int contador = 0, contadorID = 1;

            Equipamento[] equipamento = new Equipamento[100];
            Array.Fill(equipamento, new Equipamento(101));

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Gestão de Equipamentos\n\nDigite 1 para o Cadastro de Equipamentos\nDigite 2 para o Controle de Chamados\nDigite S para sair");
                string opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Cadastro de Equipamentos\n\nDigite 1 para inserir novo equipamento\nDigite 2 para visualisar equipamentos\nDigite 3 para editar um equipamento\nDigite 4 para excluir um equipamento\nDigite S para sair");
                    opcao = Console.ReadLine();

                    if (opcao == "1")
                    {
                        Console.Clear();
                        equipamento[contador] = new Equipamento(contadorID);
                        equipamento[contador].Cadastrar(ref contador, ref contadorID);
                    }
                    else if (opcao == "2")
                    {
                        MostrarEquipamentos(equipamento, contador);
                    }
                    else if (opcao == "3")
                    {
                        MostrarEquipamentos(equipamento, contador);
                        Console.Write("\nQual o ID do equipamento que você deseja editar? ");

                    }
                    else if (opcao == "4")
                    {
                        Excluir(ref equipamento, ref contador);
                    }
                    else if (opcao == "s" || opcao == "S") break;
                }
                else if (opcao == "2") { }
                else if (opcao == "s" || opcao == "S") break;
                else Console.WriteLine("Opção inválida. Tente novamente.");
                Console.ReadLine();
            }
        }


        static void MostrarEquipamentos(Equipamento[] equipamento, int contador)
        {
            Console.WriteLine("\n  Id\t| Número\t| Nome\t\t| Preço\t\t| Fabricante\t\t| Data de fabricação\n  -----------------------------------------------------------------------------------------------------");
            for (int i = 0; i < contador; i++) Console.WriteLine($"  {equipamento[i].id}\t| {equipamento[i].numeroSerie}\t\t| {equipamento[i].nome}\t\t| {equipamento[i].precoAquisicao}\t\t| {equipamento[i].fabricante}\t\t\t| {equipamento[i].dataFabricacao}\n  -----------------------------------------------------------------------------------------------------");
        }

        static void Excluir(ref Equipamento[] equipamento, ref int contador)
        {
            Console.Clear();
            MostrarEquipamentos(equipamento, contador);
            Console.Write("\nQual o ID do equipamento que você deseja remover? ");
            int a = Convert.ToInt32(Console.ReadLine());

            var remover = Array.FindAll(equipamento, x => x != null);
            remover = Array.FindAll(remover, x => x.id != a);
            contador--;

            equipamento = remover;
        }
    }
}
