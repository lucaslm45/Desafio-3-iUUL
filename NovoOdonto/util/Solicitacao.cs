using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.util
{
    public class Solicitacao
    {
        public string? Solicitar(string solicitacao)
        {
            Console.WriteLine(solicitacao);
            return Console.ReadLine();
        }
    }
}
