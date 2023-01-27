using NovoOdonto.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.model.validator
{
    public class AgendamentoValidator
    {
        public StatusOperacao IsValidCPF(object cPF)
        {
            return StatusOperacao.Sucesso;
        }

        public StatusOperacao IsValidDataConsulta(string? dataConsulta)
        {
            throw new NotImplementedException();
        }

        public StatusOperacao IsValidHoraInicio(object inicio)
        {
            throw new NotImplementedException();
        }
    }
}
