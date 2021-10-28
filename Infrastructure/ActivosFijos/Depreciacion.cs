using Domain.Entities.Activos;
using Domain.Enums.Activo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ActivosFijos
{
    public class Depreciacion
    {
        public decimal[] Depreciar(ActivoFijo af)
        {
            switch (af.MetodoDepreciacion)
            {
                case MetodoDepreciacion.LineaRecta:
                    return DepreciacionLineaRecta(af);
                case MetodoDepreciacion.SDA:
                    return DepreciacionSDA(af);
            }
            return null;
        }
        private decimal[] DepreciacionLineaRecta(ActivoFijo activoFijo)
        {
            int vidaUtil = VidaUtil(activoFijo.TipoActivoFijo);
            return Enumerable.Repeat(activoFijo.ValorActivo / vidaUtil, vidaUtil).ToArray();
        }

        private decimal[] DepreciacionSDA(ActivoFijo activoFijo)
        {
            return null;
        }

        private int VidaUtil(TipoActivoFijo tipoActivoFijo)
        {
            switch (tipoActivoFijo)
            {
                case TipoActivoFijo.Edificio:
                    return 25;
                case TipoActivoFijo.Maquinaria:
                    return 5;
                case TipoActivoFijo.EquipoDeComputo:
                    return 1;
                case TipoActivoFijo.Mobiliario:
                    return 2;
                case TipoActivoFijo.Vehiculo:
                    return 6;
                default:
                    throw new ArgumentException("Tipo de activo fijo no existe.");
            }
        }
    }
}
