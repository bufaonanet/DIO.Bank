namespace DIO.Bank
{
    public class Conta
    {
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public bool Sacar(double valorSaque)
        {
            if (Saldo - valorSaque < (Credito * -1))
            {
                System.Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            Saldo -= valorSaque;
            System.Console.WriteLine("Saldo atual da conta de {0} é: {1}", Nome, Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;
            System.Console.WriteLine("Saldo atual da conta de {0} é: {1}", Nome, Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaTransferencia)
        {
            if (Sacar(valorTransferencia))
            {
                contaTransferencia.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            
            return $"Tipo da Conta:{TipoConta} | Nome:{Nome} | Saldo:{Saldo} | Crédito:{Credito}";            
        }


    }
}