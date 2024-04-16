using System.Runtime.CompilerServices;

namespace GestaoEquipamentos.ConsoleApp
{
    internal class Gestão
    {
        int contador = 0, contadorID = 1;
        string mostraTexto = "não";
        public Equipamento[] equipamentos = new Equipamento[50];

        public void CadastroDeEquipamentos(ref string opcao)
        {
            do
            {
                Console.Clear();
                opcao = RecebeInformacao("Cadastro de Equipamentos\n\nDigite 1 para inserir novo equipamento\nDigite 2 para visualisar equipamentos\nDigite 3 para editar um equipamento\nDigite 4 para excluir um equipamento\nDigite S para sair\n\n");

                if (opcao == "1") Cadastrar();
                else if (opcao == "2") MostrarEquipamentos();
                else if (opcao == "3") Editar(ref opcao);
                else if (opcao == "4") Excluir();
                else if (!Sair(opcao, "S")) opcao = RecebeInformacao("Opção inválida. 'Enter' para tentar novamente ou 'S' para sair\n");
            }
            while (opcao == "");
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
            Console.WriteLine(Visualizar(-1));
            for (int i = 0; i < contador; i++) Console.WriteLine(Visualizar(i));

            if (mostraTexto == "não") Console.ReadLine();
        }
        public void Editar(ref string opcao)
        {
            string opcaoEditar = "neutra";
            do
            {
                do
                {
                    MostrarEquipamentosAntesDeAlterar();
                    string editarID = RecebeInformacao("\nQual o ID do equipamento que você deseja editar? ");
                    int editarIndex = EditarIndex(editarID);
                    MenuEdicao(ref opcaoEditar, editarIndex, editarID);
                }
                while (Sair(opcaoEditar, "R"));
            }
            while (opcaoEditar == "");

            if (Sair(opcaoEditar, "S")) opcao = "S";
            else EditadoComSucesso();
        }
        public void Excluir()
        {
            MostrarEquipamentosAntesDeAlterar();
            int removerID = Convert.ToInt32(RecebeInformacao("\nQual o ID do equipamento que você deseja remover? "));

            equipamentos = Array.FindAll(equipamentos, x => x.id != removerID);
            contador--;
        }

        //Auxiliar
        public void PreencherArray()
        {
            Array.Fill(equipamentos, new Equipamento(51));
        }
        public string RecebeInformacao(string texto)
        {
            Console.Write(texto);
            return Console.ReadLine();
        }
        public string Visualizar(int i)
        {
            if (i == -1) return "\n  Id\t| Número\t| Nome\t\t\t| Preço\t\t| Fabricante\t\t| Data de fabricação\n  ----------------------------------------------------------------------------------------------------------";
            else return $"  {equipamentos[i].id}\t| {equipamentos[i].numeroSerie}\t\t| {equipamentos[i].nome}\t\t| {equipamentos[i].precoAquisicao}\t\t| {equipamentos[i].fabricante}\t\t\t| {equipamentos[i].dataFabricacao}\n  ----------------------------------------------------------------------------------------------------------";
        }
        public void MostrarEquipamentosAntesDeAlterar()
        {
            mostraTexto = "sim";
            MostrarEquipamentos();
            mostraTexto = "não";
        }
        public void MostrarEquipamentoParaEdicao(string editarID)
        {
            Console.Clear();
            var edicaoEquipamento = Array.Find(equipamentos, x => x.id == Convert.ToInt32(editarID));
            Console.WriteLine($"{Visualizar(-1)}\n  {edicaoEquipamento.id}\t| {edicaoEquipamento.numeroSerie}\t\t| {edicaoEquipamento.nome}\t\t| {edicaoEquipamento.precoAquisicao}\t\t| {edicaoEquipamento.fabricante}\t\t\t| {edicaoEquipamento.dataFabricacao}\n  ----------------------------------------------------------------------------------------------------------\n");
        }
        public int EditarIndex(string editarID)
        {
            int index = 0;

            for (int i = 0; i < contador; i++)
            {
                if (equipamentos[i].id == Convert.ToInt32(editarID)) index = i;
            }

            return index;
        }
        public void MenuEdicao(ref string opcao, int editarIndex, string editarID)
        {
            do
            {
                Console.Clear();
                MostrarEquipamentoParaEdicao(editarID);
                opcao = RecebeInformacao("Digite 1 para editar o Número de Série\nDigite 2 para editar o Nome\nDigite 3 para editar o Preço\nDigite 4 para editar o Fabricante\nDigite 5 para editar a Data de fabricação\nDigite R para retornar\n\n");

                if (opcao == "1") equipamentos[editarIndex].numeroSerie = RecebeInformacao("Informe o novo número de série: ");
                else if (opcao == "2") equipamentos[editarIndex].nome = RecebeInformacao("Informe o novo nome: ");
                else if (opcao == "3") equipamentos[editarIndex].precoAquisicao = RecebeInformacao("Informe o novo preço de aquisição: ");
                else if (opcao == "5") equipamentos[editarIndex].dataFabricacao = RecebeInformacao("Informe a nova data de aquisição ");
                else if (!Sair(opcao, "R")) opcao = RecebeInformacao("Opção inválida. 'Enter' para tentar novamente ou 'S' para sair\n");
            }
            while (opcao == "");
        }
        private void EditadoComSucesso()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nEquipamento editado com sucesso!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        public bool Sair(string opcao, string comparar)
        {
            return opcao.ToUpper() == comparar;
        }
    }
}
