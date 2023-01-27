using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.util
{
    public enum StatusOperacao
    {
        Sucesso,
        PacienteNaoCadastrado,
        PacienteJaCadastrado,
        DadosInvalidosPaciente,
        ConsultaAgendada,
        ConflitoAgendamento,
        AgendamentoNaoCadastrado
    }
}
