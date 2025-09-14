using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeSystem.Modelo;
using PrimeSystem.Modelo.Entidades;

namespace PrimeSystem.Servicio
{
    public sealed class SingleListas
    {
        private static readonly Lazy<SingleListas> instance = new(() => new SingleListas());
        public static SingleListas Instance => instance.Value;
        private SingleListas()
        {
            // Inicializar las listas aquí si es necesario
            Clientes = [];
            Proveedores = [];
            Productos = [];
            Ventas = [];
            Compras = [];
            Categorias = [];
            ProductosSeleccionados = [];
            ProductoResumen = [];
        }
        public List<Clientes> Clientes { get; set; }
        public List<Proveedores> Proveedores { get; set; }
        public List<Articulos> Productos { get; set; }
        public List<HVentas> Ventas { get; set; }
        public List<HCompras> Compras { get; set; }
        public List<Categorias> Categorias { get; set; }
        public List<ArticuloStock> ProductosSeleccionados { get; set; }
        public List<ProductoResumen> ProductoResumen { get; set; }
    }


}
