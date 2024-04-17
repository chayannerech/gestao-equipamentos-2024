using System.ComponentModel.Design;
namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gestão conjuntoEquipamentos = new Gestão();
            conjuntoEquipamentos.PreencherArray();
            string opcaoMenu = "neutra";

            do Menu(ref opcaoMenu, conjuntoEquipamentos);
            while (!Sair(opcaoMenu));
        }

        static void Menu(ref string opcaoMenu, Gestão conjuntoEquipamentos)
        {
            do
            {
                Console.Clear();
                opcaoMenu = RecebeInformacao("Gestão de Equipamentos\n\nDigite 1 para o Cadastro de Equipamentos\nDigite 2 para o Controle de Chamados\nDigite S para sair\n");
                
                if (opcaoMenu == "1") conjuntoEquipamentos.MenuCadastroDeEquipamentos(ref opcaoMenu);
                else if (opcaoMenu == "2") Console.WriteLine("Ainda não sei");
                else if (!Sair(opcaoMenu)) opcaoMenu = RecebeInformacao("Opção inválida. 'Enter' para tentar novamente ou 'S' para sair");
            }
            while (opcaoMenu == "");
        }
        static string RecebeInformacao(string texto)
        {
            Console.WriteLine(texto);
            return Console.ReadLine();
        }
        static bool Sair(string opcao)
        {
            return opcao == "s" || opcao == "S";
        }
    }
}
