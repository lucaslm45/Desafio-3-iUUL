using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.util
{
    /// <summary>
    /// Define um Intervalo de Tempo entre duas datas e/ou horários
    /// </summary>
    public class Intervalo
    {
        public DateTime DataHoraInicial { get; private set; }
        public DateTime DataHoraFinal { get; private set; }

        /// <summary>
        /// Cria uma instância de um Intervalo.
        /// </summary>
        /// <param name="inicial">Esse valor deve ser menor que o valor final.</param>
        /// <param name="final">Esse valor deve ser maior que o valor inicial.</param>
        public Intervalo(DateTime inicial, DateTime final)
        {
            DataHoraInicial = inicial;
            DataHoraFinal = final;
        }
        /// <summary>
        /// Verifica se um Intervalo (Data e Hora) tem sopreposição com outro Intervalo.
        /// </summary>
        /// <param name="intervalo"></param>
        /// <param name="outroIntervalo"></param>
        /// <returns>Retorna verdaidado se houver sopreposição.</returns>
        public bool TemIntersecao(Intervalo outroIntervalo)
        {
            // ref: https://stackoverflow.com/questions/13513932/algorithm-to-detect-overlapping-periods
            return DataHoraInicial < outroIntervalo.DataHoraFinal && outroIntervalo.DataHoraInicial < DataHoraFinal;
        }
    }
}
