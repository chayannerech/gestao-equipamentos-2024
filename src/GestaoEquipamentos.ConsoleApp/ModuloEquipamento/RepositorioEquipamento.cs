using System.Runtime.CompilerServices;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento
{
    internal class RepositorioEquipamento
    {
        int contador = 0, contadorID = 1; string mostraTexto = "não";
        Equipamento[] equipamentos;
        
        public RepositorioEquipamento()
        {
            equipamentos = new Equipamento[50];
            Array.Fill(equipamentos, new Equipamento("", "", "", "", "", 51));
        }
        
        public void Cadastrar(string nome, string precoAquisicao, string numeroSerie, string dataFabricacao, string fabricante)
        {
            equipamentos[contador] = new Equipamento(nome, precoAquisicao, numeroSerie, dataFabricacao, fabricante, contadorID);

            contador++;
            contadorID++;
        }
        public void MostrarEquipamentos(ref string opcaoSair)
        {
            if (equipamentos[0].id != 51)
            {
                Cabeçalho();
                ListarEquipamentos();
            }
            else opcaoSair = "vazio";
        }
        public void Editar(ref string opcaoEditar)
        {
            do
            {
                do
                {
                    MostrarAntesDeAlterar(ref opcaoEditar);
                    if (Sair(opcaoEditar, "S")) break;
                    if (opcaoEditar != "2" && opcaoEditar != "vazio")
                    {
                        string editarID = RecebeInformacao("\nQual o ID do equipamento que você deseja editar? ");
                        int editarIndex = EditarIndex(editarID);
                        MenuEdicao(ref opcaoEditar, editarIndex, editarID);
                    }
                }
                while (Sair(opcaoEditar, "R"));
            }
            while (opcaoEditar == "");
        }
        public void Excluir(ref string opcaoExcluir)
        {
            MostrarAntesDeAlterar(ref opcaoExcluir);
            if (opcaoExcluir != "2" && opcaoExcluir != "vazio" && !Sair(opcaoExcluir, "S"))
            {
                int removerID = Convert.ToInt32(RecebeInformacao("\nQual o ID do equipamento que você deseja remover? \n"));
                equipamentos = Array.FindAll(equipamentos, x => x.id != removerID);
                contador--;
            }
        }

        //Auxiliar
        public string RecebeInformacao(string texto)
        {
            Console.Write(texto);
            return Console.ReadLine();
        }
        public string TestaNome()
        {
            string nome = "";
            while (nome.Length < 6)
            {
                Console.Clear();
                nome = RecebeInformacao("Registrando um novo equipamento\n\nInforme o nome do equipamento: ");
                if (nome.Length < 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Inválido. Tente novamente\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
            }
            return nome;
        }
        public bool Sair(string opcao, string comparar) => opcao.ToUpper() == comparar;

        //Auxiliares para Mostrar Equipamentos
        public void Cabeçalho()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n  Id\t| Número\t| Nome\t\t\t| Preço\t\t| Fabricante\t\t| Data de fabricação\n  ----------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ListarEquipamentos()
        {
            for (int i = 0; i < contador; i++) Console.WriteLine($"  {equipamentos[i].id}\t| {equipamentos[i].numeroSerie}\t\t| {equipamentos[i].nome}\t\t| {equipamentos[i].precoAquisicao}\t\t| {equipamentos[i].fabricante}\t\t\t| {equipamentos[i].dataFabricacao}\n  ----------------------------------------------------------------------------------------------------------");
            if (mostraTexto == "não") Console.ReadLine();
        }

        //Auxiliares de Edição
        public void MostrarAntesDeAlterar(ref string opcaoSair)
        {
            mostraTexto = "sim";
            MostrarEquipamentos(ref opcaoSair);
            mostraTexto = "não";
        }
        public void MostrarEquipamentoParaEdicao(string editarID)
        {
            Console.Clear();
            var edicaoEquipamento = Array.Find(equipamentos, x => x.id == Convert.ToInt32(editarID));
            Cabeçalho();
            Console.WriteLine($"  {edicaoEquipamento.id}\t| {edicaoEquipamento.numeroSerie}\t\t| {edicaoEquipamento.nome}\t\t| {edicaoEquipamento.precoAquisicao}\t\t| {edicaoEquipamento.fabricante}\t\t\t| {edicaoEquipamento.dataFabricacao}\n  ----------------------------------------------------------------------------------------------------------\n");
        }
        public int EditarIndex(string editarID)
        {
            int index = 0;
            for (int i = 0; i < contador; i++) if (equipamentos[i].id == Convert.ToInt32(editarID)) index = i;
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
                else if (opcao == "2") equipamentos[editarIndex].nome = TestaNome();
                else if (opcao == "3") equipamentos[editarIndex].precoAquisicao = RecebeInformacao("Informe o novo preço de aquisição: ");
                else if (opcao == "5") equipamentos[editarIndex].dataFabricacao = RecebeInformacao("Informe a nova data de aquisição ");
                else if (!Sair(opcao, "R")) opcao = RecebeInformacao("Opção inválida. 'Enter' para tentar novamente ou 'S' para sair\n");
            }
            while (opcao == "");
            if (!Sair(opcao, "R") && !Sair(opcao, "S")) EditadoComSucesso();
        }
        private void EditadoComSucesso()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nEquipamento editado com sucesso!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
    }
}
