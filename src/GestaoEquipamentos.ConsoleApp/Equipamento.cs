namespace GestaoEquipamentos.ConsoleApp
{
    internal class Equipamento
    {
        public string nome, dataFabricacao, fabricante, numeroSerie, precoAquisicao;
        public int id;
        public Equipamento(int id)
        {
            this.id = id;
        }

        public void NovoEquipamento(ref int contador, ref int contadorID)
        {
            IniciaEquipamento();
            contador++;
            contadorID++;
        }

        //Auxiliares
        private void IniciaEquipamento()
        {
            nome = TestaNome();
            precoAquisicao = RecebeInformacao("Informe o preço de aquisição: R$ ");
            numeroSerie = RecebeInformacao("Informe o número de série: ");
            dataFabricacao = RecebeInformacao("Informe a data de fabricação: ");
            fabricante = RecebeInformacao("Informe o fabricante: ");

            CadastradoComSucesso();
        }
        private string TestaNome()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Registrando um novo equipamento\n");
                nome = RecebeInformacao("Informe o nome do equipamento: ");
                if (nome.Length < 6)
                {
                    Console.WriteLine("Inválido. Tente novamente");
                    Console.ReadLine();
                }
            }
            while (nome.Length < 6);
            return nome;
        }
        private string RecebeInformacao(string texto)
        {
            Console.Write(texto);
            return Console.ReadLine();
        }
        private void CadastradoComSucesso()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nEquipamento cadastrado com sucesso!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}