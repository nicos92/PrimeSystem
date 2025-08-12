using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrimeSystem.Contrato.Servicios;

namespace PrimeSystem.UI
{
    public class ServiceLocator
    {
        // poner como atrubutos los servicios que se quieran inyectar
        // ejemplo:
        // public IClienteService clienteService { get; }
        public IArticulosService ArticulosService { get; }
        public ICategoriasService CategoriasService { get; }
        public IClientesService ClienteRepository { get; }
        public IHComprasService ComprasService { get; }
        public IHComprasDetalleService ComprasDetalleService { get; }
        public IProveedoresService ProveedoresService { get; }
        public ISubcategoriaService SubcategoriasService { get; }
        public IUsuariosService UsuariosService { get; }
        public IUsuariosTipoService UsuariosTipoService { get; }
        public IHVentasService VentasService { get; }
        public IHVentasDetalleService VentasDetalleService { get; }
        public IInOutVariosService ReportesService { get; }
        public IHMovimientosService MovimientosService { get; }

        // Instanciar los Servicios y los repositorios en el constructor
        public ServiceLocator()
        {
            // Instanciar los repositorios
        }

    }
}