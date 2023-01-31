using AutoMapper;
using NovoOdonto.data;
using NovoOdonto.data.validator;
using NovoOdonto.presentation.agendamento;
using NovoOdonto.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.controller
{
    public class AgendamentoConsultaController
    {
        private AgendamentoConsultaForm Form { get; set; } = new AgendamentoConsultaForm();
        private AgendamentoValidator Validator { get; set; } = new AgendamentoValidator();
        private StatusOperacao status;

        private OdontoDbContext _context;
        private IMapper _mapper;

        public AgendamentoConsultaController(OdontoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Inicia()
        {
            // CPF
            do
            {
                Form.SolicitarCPF();
                status = Validator.IsValidCPF(Form.Agendamento.CPF);
                //ToDo : Validar se o CPF possui 11 digitos, se é de verdade e por último validar no Banco de Dados

                if (status != StatusOperacao.Sucesso)
                    Form.Process(status);

            } while (status != StatusOperacao.Sucesso);

            // Data de Consulta
            do
            {
                Form.SolicitarDataConsulta();
                status = Validator.IsValidDataConsulta(Form.Agendamento.DataConsulta);

                if (status == StatusOperacao.Sucesso)
                // Todo: e se não houver nenhum horário disponível para a data escolhida? Nunca vai sair do loop
                //Sugestão: Numero de tentativas excedidas, forneça novamente a da data ou tente uma nova data
                {
                    var tentativas = 3;
                    do
                    {

                        tentativas--;
                        if (tentativas < 1)
                        {
                            Console.WriteLine("Numero de tentativas excedidas, forneça novamente a da data ou tente uma nova data.");
                            break;
                        }

                        /// Hora de Inicio
                        SolicitarHoraInicio();

                        //if (Validator.Agendamento.HoraInicio != Validator.FechaAs)
                        status = SolicitarHoraFim();

                    } while (status != StatusOperacao.Sucesso);
                }

            } while (status != StatusOperacao.Sucesso);


            SolicitarDataHoraConsulta();

            Console.WriteLine("AgendamentoConsultaController Executado");
        }

        private StatusOperacao SolicitarHoraFim()
        {
            throw new NotImplementedException();
        }

        private void SolicitarCPFConsulta()
        {
            // CPF
            do
            {
                Form.SolicitarCPF();
                status = Validator.IsValidCPF(Form.Agendamento.CPF);
                //ToDo : Validar se o CPF possui 11 digitos, se é de verdade e por último validar no Banco de Dados

                if (status != StatusOperacao.Sucesso)
                    Form.Process(status);

            } while (status != StatusOperacao.Sucesso);
        }

        private void SolicitarDataHoraConsulta()
        {
            try
            {
                Form.SolicitarDataConsulta();
                Validator.IsValidDataConsulta(Form.Agendamento.DataConsulta);

                // Todo: e se não houver nenhum horário disponível para a data escolhida? Nunca vai sair do loop
                //Sugestão: Numero de tentativas excedidas, forneça novamente a da data ou tente uma nova data
                bool isValidHora = false;
                do
                {
                    SolicitarHoraInicio();
                    //if (Validator.Agendamento.HoraInicio != Validator.FechaAs)
                    //    SolicitarHoraFim();

                    isValidHora = true;// Validator.IsHorarioDisponivelInicio(ListaAgendamento.Agendamentos);

                } while (!isValidHora);

                // Agendar Consulta para o Paciente
                //var auxiliarConsulta = Validator.Agendamento;
                //var consulta = new Agendamento(auxiliarConsulta, ListaPacientes.Pacientes[auxiliarConsulta.Paciente.CPF]);
                //ListaAgendamento.AdicionarNaLista(consulta);
                //ListaPacientes.Pacientes[auxiliarConsulta.Paciente.CPF].AdicionarConsulta(consulta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SolicitarDataHoraConsulta();
            }
        }

        private void SolicitarHoraInicio()
        {
            // Hora Inicio Consulta
            do
            {
                Form.SolicitarHoraInicio();
                status = Validator.IsValidHoraInicio(Form.Agendamento.HoraInicio);

                if (status != StatusOperacao.Sucesso)
                    Form.Process(status);

            } while (status != StatusOperacao.Sucesso);
        }
    }
}
