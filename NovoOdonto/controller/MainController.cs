using NovoOdonto.data;
using NovoOdonto.presentation.paciente;
using NovoOdonto.presentation.agendamento;

namespace NovoOdonto.controller
{
    public class MainController
    {
        private readonly MenusPacienteForm PacienteForm;
        private readonly MenusAgendaForm AgendaForm;
        private OdontoDbContext Contexto { get; set; }
        public MainController(OdontoDbContext contexto)
        {
            Contexto = contexto;
            AgendaForm = new();
            PacienteForm = new();
        }
        /// <summary>
        /// Inicia a aplicação chamando o método que abre o menu principal (MenuPrincipal())
        /// </summary>
        public void Inicia()
        {
            MenuPrincipal();
        }
        /// <summary>
        /// Método que inicía o menu principal
        /// </summary>
        private void MenuPrincipal()
        {
            switch (PacienteForm.MenuPrincipal())
            {
                case "1":
                    MenuCadastraPaciente();
                    break;
                case "2":
                    MenuAgenda();
                    break;
                case "3":
                    Console.WriteLine("\nFim");
                    return;
            }
            MenuPrincipal();
        }
        /// <summary>
        /// Método responsável pelo submenu que manipula a lista pacientes
        /// </summary>
        private void MenuCadastraPaciente()
        {
            switch (PacienteForm.MenuCadastraPaciente())
            {
                case "1":
                    InclusaoPacienteController.Inicia(Contexto);
                    break;
                case "2":
                    ExclusaoPacienteController.Inicia(Contexto);
                    break;
                case "3":
                    ConsultarPacientesController.ListarPorCPF(Contexto);
                    break;
                case "4":
                    ConsultarPacientesController.ListarPorNome(Contexto);
                    break;
                case "5":
                    return;
            }
            MenuCadastraPaciente();
        }
        /// <summary>
        /// Inicia submenu responsável por manipular a Agenda
        /// </summary>
        private void MenuAgenda()
        {
            switch (AgendaForm.MenuAgenda())
            {
                case "1":
                    AgendamentoConsultaController.Inicia(Contexto);
                    break;
                case "2":
                    CancelamentoConsultaController.Inicia(Contexto);
                    break;
                case "3":
                    MenuListarAgenda();
                    break;
                case "4":
                    return;
            }
            MenuAgenda();
        }

        /// <summary>
        /// Inicia submenu responsável por perguntar ao usuário como a lista deve ser ordenada
        /// </summary>
        private void MenuListarAgenda()
        {
            switch (AgendaForm.MenuListarAgenda())
            {
                case "1":
                    ConsultarAgendaController.Inicia(Contexto);
                    break;
                case "2":
                    ConsultarAgendaController.IniciaPorPeriodo(Contexto);
                    break;
                case "3":
                    return;

            }
            MenuListarAgenda();
        }
    }
}
