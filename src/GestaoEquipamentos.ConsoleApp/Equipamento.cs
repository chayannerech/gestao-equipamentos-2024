namespace GestaoEquipamentos.ConsoleApp
{
    internal class Equipamento
    {
        //Todos string pois não vou fazer operações numéricas (somar ou afins)
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
            nome = RecebeInformacao("Registrando um novo equipamento\n\nInforme o nome do equipamento: ");
            precoAquisicao = RecebeInformacao("Informe o preço de aquisição: R$ ");
            numeroSerie = RecebeInformacao("Informe o número de série: ");
            dataFabricacao = RecebeInformacao("Informe a data de fabricação: ");
            fabricante = RecebeInformacao("Informe o fabricante: ");

            CadastradoComSucesso();
        }
        public string RecebeInformacao(string texto)
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