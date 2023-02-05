﻿using NovoOdonto.data;
using NovoOdonto.data.validator;
using NovoOdonto.presentation.agendamento;

namespace NovoOdonto.controller
{
    public class AgendamentoConsultaController
    {
        private AgendamentoConsultaForm Form { get; set; } = new AgendamentoConsultaForm();
        private AgendamentoValidador Validador { get; set; } = new AgendamentoValidador();
        protected bool isValid { get; set; }
        public static void Inicia(OdontoDbContext contexto)
        {
            var isValid = false;
            var Form = new AgendamentoConsultaForm();
            var Validador = new AgendamentoValidador();

            Console.WriteLine("AgendamentoConsultaController not implemented\n");
        }
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

            Console.WriteLine("Agendamento realizado com sucesso!");
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
