using NovoOdonto.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.presentation.agendamento
{
    public class MenusAgendaForm
    {
        /// <summary>
        /// Mostra ao usuário todas as opções disponíveis em relação ao formato de listagem da Agenda
        /// </summary>
        /// <returns>Retorna a escolha do usuário</returns>
        public string MenuListarAgenda()
        {
            string escolha;

            do
            {
                Console.WriteLine("\nListar Agenda");
                Console.WriteLine("1-Listar toda a agenda");
                Console.WriteLine("2-Listar agenda de um período");
                Console.WriteLine("3-Voltar p/ Menu Agenda");
                Console.Write("Digite sua escolha: ");

                escolha = Console.ReadLine();

            } while (escolha.NaoEhEscolhaValida(Menu.ListarAgenda));

            return escolha;
        }
        public string MenuAgenda()
        {
            string escolha;

            do
            {
                Console.WriteLine("\nAgenda");
                Console.WriteLine("1-Agendar consulta");
                Console.WriteLine("2-Cancelar agendamento");
                Console.WriteLine("3-Listar agenda");
                Console.WriteLine("4-Voltar p/ menu principal");
                Console.Write("Digite sua escolha: ");

                escolha = Console.ReadLine();

            } while (escolha.NaoEhEscolhaValida(Menu.Agenda));

            return escolha;
        }
    }
}
