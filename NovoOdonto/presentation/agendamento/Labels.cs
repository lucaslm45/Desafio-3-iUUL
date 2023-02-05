using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.presentation.agendamento
{
    /// <summary>
    /// Sem uso por enquanto, talvez não será usado
    /// </summary>
    public class Labels
    {
        public const string Sucesso = "\nAgendamento realizado com sucesso!";
        public const string PacienteNaoCadastrado = "\nErro: paciente não cadastrado";
        public const string PacienteJaCadastrado = "\nErro: paciente já está cadastrado";
        public const string DadosInvalidosPaciente = "\nErro: Dados do paciente inválidos";
        public const string ConsultaAgendada = Sucesso;
        public const string ConflitoAgendamento = "\n Erro: A data ou hora escolhida não está disponível";
        public const string AgendamentoNaoCadastrado = "\n Erro: Agendamento não cadastrado";
    }
}
