﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using application.Entity;

namespace application.BL
{
    public class ProductosService : IProductosService
    {

        private DAC.IProductosRepositorio ProductoRespositorio = new DAC.ProductosRepositorio();

        public IList<JsonBasico2> BL_JsonProductos(string Codigo)
        {
            return this.ProductoRespositorio.DAC_JsonProducto(Codigo);
        }


        public IList<GridCabComp> BL_ListaCabCompro()
        {
            return this.ProductoRespositorio.DAC_ListaCabCompro();
        }


        public IList<GridDetComp> BL_ListaDetCompro()
        {
            return this.ProductoRespositorio.DAC_ListaDetCompro();
        }
    }
}
