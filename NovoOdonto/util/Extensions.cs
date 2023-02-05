using NovoOdonto.data;
using NovoOdonto.presentation;
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
        public static void CabecalhoListaPacientes()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.Write("CPF".PadRight((int)Espacos.CPF));
            Console.Write("Nome".PadRight((int)Espacos.Nome));
            Console.Write("Dt. Nasc.".PadRight((int)Espacos.Nascimento));
            Console.WriteLine("Idade".PadLeft((int)Espacos.Idade));
            Console.WriteLine("------------------------------------------------------------");
        }
        public static void RodapeListaPacientes()
        {
            Console.WriteLine("------------------------------------------------------------\n");
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
                throw new Exception("Data deve estar no formato ddMMaaaa");

            return consulta;
        }
        public static DateTime FormataStringEmData(this string data)
        {
            return DateTime.ParseExact(data, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
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
        public static bool ExisteNoDicionario<TKey, TValor>(this Dictionary<TKey, TValor> dicionario, TKey chave)
        {
            return dicionario != null && dicionario.ContainsKey(chave);
        }
    }
}
