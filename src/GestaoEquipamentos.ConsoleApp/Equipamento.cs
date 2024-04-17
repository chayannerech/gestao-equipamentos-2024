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
            Console.Clear();
            Console.WriteLine("Registrando um novo equipamento\n");
            nome = TestaNome();
            precoAquisicao = RecebeInformacao("Informe o preço de aquisição: R$ ");
            numeroSerie = RecebeInformacao("Informe o número de série: ");
            dataFabricacao = RecebeInformacao("Informe a data de fabricação: ");
            fabricante = RecebeInformacao("Informe o fabricante: ");

            CadastradoComSucesso();
        }
        public string TestaNome()
        {
            do
            {
                nome = RecebeInformacao("Informe o nome do equipamento: ");
                if (nome.Length < 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Inválido. Tente novamente\n");
                    Console.ForegroundColor = ConsoleColor.White;
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