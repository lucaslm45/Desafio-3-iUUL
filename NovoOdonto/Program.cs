using NovoOdonto.controller;

namespace NovoOdonto
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ListaPacientes lista = new ListaPacientes();
            //Paciente p1 = new Paciente(62813265047, "Marcos", "17/07/2001");
            //lista.AdicionarNaLista(p1);

            //Paciente p2 = new Paciente(92188860020, "Larissa", "01/02/2000");
            //lista.AdicionarNaLista(p2);

            ////Paciente p3 = new Paciente(92188860020, "Maria Helena", "04/10/1999");
            ////lista.AdicionarNaLista(p3);

            ////lista.RemoverDaLista(p3);

            //lista.ListarPacientes();

            MainController controlador = new MainController();

            controlador.Inicia();
        }

    }


}