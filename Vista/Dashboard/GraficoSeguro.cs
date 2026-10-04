using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Vista.Dashboard
{
    /// <summary>
    /// Chart que nunca acepta un ancho o alto de cero: el control original lanza "El valor de Height debe ser mayor que 0px"
    /// cuando el diseño lo dimensiona antes de que su contenedor tenga tamaño real.
    /// </summary>
    public class GraficoSeguro : Chart
    {
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width < 1 ? 1 : width, height < 1 ? 1 : height, specified);
        }
    }
}
