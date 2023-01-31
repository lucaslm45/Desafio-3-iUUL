using NovoOdonto.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.data.validator
{
    public class AgendamentoValidator
    {
        public StatusOperacao IsValidCPF(string value)
        {
            return StatusOperacao.Sucesso;
        }

        public StatusOperacao IsValidDataConsulta(string value)
        {
            throw new NotImplementedException();
        }

        public StatusOperacao IsValidHoraInicio(string value)
        {
            throw new NotImplementedException();
        }
    }
}
