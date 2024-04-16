namespace GestaoEquipamentos.ConsoleApp
{
    internal class Gestão
    {
        int contador = 0, contadorID = 1;
        string excluir = "não";
        public Equipamento[] equipamentos = new Equipamento[50];

        public void CadastroDeEquipamentos(ref string opcao)
        {
            Console.Clear();
            opcao = equipamentos[0].RecebeInformacao("Cadastro de Equipamentos\n\nDigite 1 para inserir novo equipamento\nDigite 2 para visualisar equipamentos\nDigite 3 para editar um equipamento\nDigite 4 para excluir um equipamento\nDigite S para sair\n");
            if (opcao == "1") Cadastrar();
            else if (opcao == "2") MostrarEquipamentos();
            else if (opcao == "3") Editar();
            else if (opcao == "4") Excluir();
        }

        public void Cadastrar()
        {
            Console.Clear();
            equipamentos[contador] = new Equipamento(contadorID);
            equipamentos[contador].NovoEquipamento(ref contador, ref contadorID);
            Console.ReadLine();
        }
        public void MostrarEquipamentos()
        {
            Console.Clear();
            Console.WriteLine("\n  Id\t| Número\t| Nome\t\t| Preço\t\t| Fabricante\t\t| Data de fabricação\n  -----------------------------------------------------------------------------------------------------");
            for (int i = 0; i < contador; i++) Console.WriteLine($"  {equipamentos[i].id}\t| {equipamentos[i].numeroSerie}\t\t| {equipamentos[i].nome}\t\t| {equipamentos[i].precoAquisicao}\t\t| {equipamentos[i].fabricante}\t\t\t| {equipamentos[i].dataFabricacao}\n  -----------------------------------------------------------------------------------------------------");
            if (excluir != "sim") Console.ReadLine();
        }
        public void Editar()
        {
            MostrarEquipamentos();
            Console.Write("\nQual o ID do equipamento que você deseja editar? ");
            Console.ReadLine();
        }
        public void Excluir()
        {
            Console.Clear();
            excluir = "sim";
            MostrarEquipamentos();
            excluir = "não";
            int removerID = Convert.ToInt32(equipamentos[0].RecebeInformacao("\nQual o ID do equipamento que você deseja remover? "));

            equipamentos = Array.FindAll(equipamentos, x => x.id != removerID);
            contador--;
        }

        //Auxiliar
        public void PreencherArray()
        {
            Array.Fill(equipamentos, new Equipamento(51));
        }
    }
}
