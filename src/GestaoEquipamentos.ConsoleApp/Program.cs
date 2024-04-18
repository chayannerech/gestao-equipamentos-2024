using System.ComponentModel.Design;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;
namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaCadastroEquipamento telaEquipamento = new TelaCadastroEquipamento();

            string opcaoMenu = "neutra";

            do telaEquipamento.Menu(ref opcaoMenu);
            while (!telaEquipamento.inventario.Sair(opcaoMenu, "S"));
        }
    }
}
