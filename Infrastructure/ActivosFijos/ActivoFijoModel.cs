using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ActivosFijos
{
    public class ActivoFijoModel : IModel<ActivoFijoModel>
    {
        protected ActivoFijoModel[] data;

        public void Add(ActivoFijoModel t, ref ActivoFijoModel[] data)
        {
            if (data == null)
            {
                data = new ActivoFijoModel[1];
                data[0] = t;
                return;
            }

            ActivoFijoModel[] tmp = new ActivoFijoModel[data.Length + 1];
            Array.Copy(data, tmp, data.Length);
            tmp[tmp.Length - 1] = t;
            data = tmp;
        }      

        public void Create(ActivoFijoModel t)
        {
            Add(t, ref data);
        }

        ActivoFijoModel[] IModel<ActivoFijoModel>.FindAll()
        {
            return data;
        }
    }
}
