using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.data.dto
{
    public class PacienteDTO
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; internal set; }
    }
}
