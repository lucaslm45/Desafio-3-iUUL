using AutoMapper;
using NovoOdonto.data;
using NovoOdonto.data.validator;
using NovoOdonto.Infrastructure;
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
        private AgendamentoValidador Validador { get; set; } = new AgendamentoValidador();
        protected bool isValid { get; set; }

        public void Inicia()
        {
            // CPF
            do
            {
                Form.SolicitarCPF();
                isValid = Validador.IsValidCPF(Form.Agendamento.CPF);
                //ToDo : Validar se o CPF possui 11 digitos, se é de verdade e por último validar no Banco de Dados

            } while (!isValid);

            // Data de Consulta
            do
            {
                Form.SolicitarDataConsulta();
                isValid = Validador.IsValidDataConsulta(Form.Agendamento.DataConsulta);

                //if (isValid == StatusOperacao.Sucesso)
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
                        isValid = SolicitarHoraFim();

                    } while (!isValid);
                }

            } while (!isValid);


            SolicitarDataHoraConsulta();

            Console.WriteLine("AgendamentoConsultaController Executado");
        }

        private bool SolicitarHoraFim()
        {
            throw new NotImplementedException();
        }

        private void SolicitarCPFConsulta()
        {
            // CPF
            do
            {
                Form.SolicitarCPF();
                isValid = Validador.IsValidCPF(Form.Agendamento.CPF);
                //ToDo : Validar se o CPF possui 11 digitos, se é de verdade e por último validar no Banco de Dados

            } while (!isValid);
        }

        private void SolicitarDataHoraConsulta()
        {
            try
            {
                Form.SolicitarDataConsulta();
                isValid = Validador.IsValidDataConsulta(Form.Agendamento.DataConsulta);

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
                isValid = Validador.IsValidHoraInicio(Form.Agendamento.HoraInicio);

            } while (!isValid);
        }
    }
}
