﻿using Microsoft.EntityFrameworkCore;
using NovoOdonto.data;
using NovoOdonto.model;
using NovoOdonto.presentation;
using NovoOdonto.presentation.agendamento;
using NovoOdonto.presentation.paciente;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.util
{
    public static class Extensions
    {
        /// <summary>
        /// Cria o cabeçalho da lista de pacientes
        /// </summary>
        public static void CabecalhoListaPacientes()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.Write("CPF".PadRight((int)Espacos.CPF));
            Console.Write("Nome".PadRight((int)Espacos.Nome));
            Console.Write("Dt. Nasc.".PadRight((int)Espacos.Nascimento));
            Console.WriteLine("Idade".PadLeft((int)Espacos.Idade));
            Console.WriteLine("------------------------------------------------------------");
        }
        /// <summary>
        /// Cria o rodape da lista de pacientes
        /// </summary>
        public static void RodapeListaPacientes()
        {
            Console.WriteLine("------------------------------------------------------------");
        }
        /// <summary>
        /// Cria o cabeçalho da lista agenda
        /// </summary>
        public static void CabecalhoListaAgenda()
        {
            Console.WriteLine("-------------------------------------------------------------");

            Console.Write("Data".PadCenter((int)EspacosAgenda.Data));
            Console.Write("H.Ini".PadCenter((int)EspacosAgenda.Tempo));
            Console.Write("H.Fim".PadCenter((int)EspacosAgenda.Tempo));
            Console.Write("Tempo".PadCenter((int)EspacosAgenda.Tempo));
            Console.Write("Nome".PadRight((int)EspacosAgenda.Nome));
            Console.WriteLine("Dt.Nasc.".PadCenter((int)EspacosAgenda.Data));

            Console.WriteLine("-------------------------------------------------------------");
        }
        /// <summary>
        /// Cria o rodapé da lista agenda
        /// </summary>
        public static void RodapeListaAgenda()
        {
            Console.WriteLine("-------------------------------------------------------------");
        }
        //Ref: https://stackoverflow.com/questions/17590528/pad-left-pad-right-pad-center-string
        /// <summary>
        /// Faz com que um texto qualquer seja escrita de forma centralizada usando um número específico de espaços
        /// </summary>
        /// <param name="str">Texto que será escrito</param>
        /// <param name="length">Espaço disponível para escrita</param>
        /// <returns>Retorna um texto centralizado com espaços em branco nos espaços disponíveis</returns>
        public static string PadCenter(this string str, int length)
        {
            int spaces = length - str.Length;
            int padLeft = spaces / 2 + str.Length;
            return str.PadLeft(padLeft).PadRight(length);
        }
        /// <summary>
        /// Verifica se uma escolha não é válida
        /// </summary>
        /// <param name="escolha"></param>
        /// <param name="menu"></param>
        /// <returns>Retorna um valor verdadeiro quando a escolha não é valida.</returns>
        public static bool NaoEhEscolhaValida(this string escolha, Menu menu)
        {
            switch (menu)
            {
                case Menu.Principal:
                    return !EscolhaUmDoisTres(escolha);
                case Menu.Cadastra:
                    return !(EscolhaUmDoisTres(escolha) || escolha == "4" || escolha == "5");
                case Menu.Agenda:
                    return !(EscolhaUmDoisTres(escolha) || escolha == "4");
                case Menu.ListarAgenda:
                    return !EscolhaUmDoisTres(escolha);
                default: return false;
            }
        }
        public static bool EscolhaUmDoisTres(string escolha)
        {
            return escolha == "1" || escolha == "2" || escolha == "3";
        }
        /// <summary>
        /// Valida se um texto é um CPF válido.
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool IsCpf(this string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            //cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// Retorna um valor verdadeiro se o paciente já está cadastrado, senão retorna falso
        /// </summary>
        /// <param name="context">A classe de contexto respons
        /// ável pela conexão com o banco pelo entity framework</param>
        /// <param name="chave"></param>
        /// <returns>True ou False</returns>
        public static bool PacienteExisteNoBanco(this OdontoDbContext context, string chave)
        {
            var paciente = context.Pacientes.FirstOrDefault(p => p.CPF == chave);

            return paciente == null ? false : true;
        }
        /// <summary>
        /// Fornece ao usuário a mensagem de erro.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>Retorna um valor falso.</returns>
        public static bool EncerrarProcessoComErro(this Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        /// <summary>
        /// Verifica se uma data qualquer está no formato (ddMMaaaa), sendo dd = dia com 2 digitos, MM = mes com 2 digitos, aaaa = ano com 4 digitos.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna uma data pronta para uso.</returns>
        /// <exception cref="Exception">Retorna um erro caso a data não esteja no formato correto ou não seja válida</exception>
        public static DateTime VerificaData(this string data)
        {
            if (!DateTime.TryParseExact(data, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime consulta))
                throw new Exception("Erro: Data deve estar no formato ddMMaaaa");

            return consulta;
        }
        /// <summary>
        /// Verifica se a hora informada está no formato correto e se os minutos são múltiplos de 15 minutos
        /// </summary>
        /// <param name="hora"></param>
        /// <returns>Retorna a hora no formato correto para a aplicação.</returns>
        /// <exception cref="Exception"></exception>
        public static TimeSpan VerificaHora(this string hora)
        {
            if (!DateTime.TryParseExact(hora, "HHmm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime horario))
                throw new Exception("Erro: O formato de hora deve estar em HHmm");

            var Minutos = horario.TimeOfDay.Minutes;

            return !(Minutos == 0 || Minutos % 15 == 0)
                ? throw new Exception("Erro: Os minutos devem ser de 15 em 15 minutos")
                : horario.TimeOfDay;
        }
        public static DateTime FormataStringEmData(this string data)
        {
            return DateTime.ParseExact(data, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToUniversalTime();
        }
        public static TimeSpan FormataStringEmHora(this string hora)
        {
            return DateTime.ParseExact(hora, "HHmm", CultureInfo.InvariantCulture, DateTimeStyles.None).TimeOfDay;
        }
        // Ref: https://stackoverflow.com/questions/2194999/how-to-calculate-an-age-based-on-a-birthday
        /// <summary>
        /// Calcula a Idade de uma pessoa a partir da data de aniversário fornecida.
        /// </summary>
        /// <param name="aniversario"></param>
        /// <returns>Retorna um número inteiro que representa a idade.</returns>
        public static int Idade(this DateTime aniversario)
        {
            DateTime now = DateTime.Today;
            int idade = now.Year - aniversario.Year;
            if (now < aniversario.AddYears(idade))
            {
                idade--;
            }

            return idade;
        }

        public static bool PacienteTemAgendamentoFuturo(this string CPF, OdontoDbContext contexto)
        {
            // Obtem uma lista com todos os agendamentos de pacientes
            var values = contexto.Agendamentos.Include(p => p.Paciente);

            // Filtra apenas pelos agendamentos do paciente em datas e horários futuros
            var hojeData = DateTime.Now;

            var dataAtual = hojeData.ToUniversalTime();
            var horaAtual = hojeData.TimeOfDay;

            var agendamentos = values.Where(a => a.Paciente.CPF == CPF &&
                                            ((a.DataConsulta > dataAtual) ||
                                             (a.DataConsulta == dataAtual && a.HoraInicio > horaAtual)));
            if (!agendamentos.Any())
            {
                Console.WriteLine("Paciente não tem nenhum agendamento futuro.");
                return false;
            }
            else
            {
                Console.WriteLine($"\nAgendamentos Futuros do Paciente {CPF}: \n");

                CabecalhoListaAgenda();

                foreach (var consulta in agendamentos)
                    Console.WriteLine(consulta);

                RodapeListaAgenda();
            }
            return true;
        }
        public static bool NaoExisteAgendamentoFuturo(this string CPF, OdontoDbContext contexto)
        {
            // Obtem uma lista com todos os agendamentos de pacientes
            var values = contexto.Agendamentos.Include(p => p.Paciente);

            // Filtra apenas pelos agendamentos do paciente em datas e horários futuros
            var hojeData = DateTime.Now;

            var dataAtual = hojeData.ToUniversalTime();
            var horaAtual = hojeData.TimeOfDay;

            var agendamentos = values.Where(a => a.Paciente.CPF == CPF &&
                                            ((a.DataConsulta > dataAtual) ||
                                             (a.DataConsulta == dataAtual && a.HoraInicio > horaAtual)));

            if (agendamentos.Count() == 1)
                throw new Exception("Erro: Existe apenas um paciente cadastrado e ele já possui um agendamento futuro");

            var PossuiAgendamentoFuturo = agendamentos.Any();


            if (PossuiAgendamentoFuturo)
                Console.WriteLine($"O paciente {CPF} possui um agendamento futuro.");

            return !PossuiAgendamentoFuturo;
        }
    }
}
