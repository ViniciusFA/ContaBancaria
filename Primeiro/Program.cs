using System;

namespace Primeiro
{
    class Program
    {
        public String Titular { get; set; }
        private double _saldo = 0.0;
        private double _limite = 0.0;
        private double _saldoLimite = 0.0;
        private double _sobraRetirada = 0.0;

        public void Deposito(double quantia)
        {
            _saldo += quantia;
            Limite(_saldo);
        }

        public void Retirada(double quantia)
        {
            if (quantia > _saldoLimite)
                Console.WriteLine("Saldo insuficiente.");
            else
            {
                _saldoLimite -= quantia;
                if (quantia > _saldo)
                {
                    _sobraRetirada = _saldo - quantia;
                    if (_sobraRetirada < 0)
                    {
                        _saldo = 0.0;
                        _limite += _sobraRetirada;
                    }
                    else
                    {
                        _saldo -= _sobraRetirada;
                    }
                }
                else
                {
                    _saldo -= quantia;
                }
            }
        }

        public void Emprestimo(double quantia)
        {
            if (quantia > _limite)
                Console.WriteLine("Quantia acima do limite permitido.");
            else
                _saldo -= quantia;
        }

        public void Limite(double quantia)
        {
            _limite = _saldo * 0.5;
            _saldoLimite = _saldo + _limite;
        }

        public double GetLimite()
        {
            return _limite;
        }

        public double GetSaldo()
        {
            return _saldo;
        }

        public double GetSaldoLimite()
        {
            return _saldoLimite;
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            int retirada = 300;

            p.Deposito(200);
            Console.WriteLine("Limite Inicial: " + p.GetLimite());
            Console.WriteLine("Saldo Inicial: " + p.GetSaldo());
            Console.WriteLine("Saldo Inicial + limite Inicial: " + p.GetSaldoLimite());
            Console.WriteLine("\n");

            p.Retirada(retirada);
            Console.WriteLine("**************** \n Retirada :" + retirada + "\n****************\n");           

            Console.WriteLine("Limite Final: " + p.GetLimite());
            Console.WriteLine("Saldo Final: " + p.GetSaldo());
            Console.WriteLine("Saldo Final + limite Final: " + p.GetSaldoLimite());

            //p.Retirada(300);
            Console.WriteLine("\n");

        }
    }
}
