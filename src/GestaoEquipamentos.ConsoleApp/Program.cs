using System.ComponentModel.Design;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;
namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcao = "neutra";
            TelaCadastroEquipamento telaEquipamento = new TelaCadastroEquipamento();

            do MenuPrincipal(ref opcao, telaEquipamento);
            while (opcao.ToUpper() != "S");
        }

        static void MenuPrincipal(ref string opcao, TelaCadastroEquipamento telaEquipamento)
        {
            do
            {
                Console.Clear();
                opcao = telaEquipamento.RecebeInformacao("Gestão de Equipamentos\n\nDigite 1 para a gerir equipamentos\nDigite 2 para o gerir chamados\nDigite S para sair\n\nDigite: ");

                if (opcao == "1") telaEquipamento.MenuEquipamentos(ref opcao);
                else if (opcao == "2") Console.WriteLine("MenuChamados");
                else telaEquipamento.OpcaoInvalida(ref opcao);
            }
            while (opcao == "");
        }
    }
}
