using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.UI.Ventas
{
    public partial class UCConsultaVentas : UserControl
    {
        private readonly IHVentasService _hVentasService;
        private readonly IHVentasDetalleService _hVentasDetalleService;
        private readonly IClientesService _clientesService;
        private readonly IUsuariosService _usuariosService;
        private readonly ILogger<UCConsultaVentas> _logger;
        private readonly CultureInfo _cultureArgentina = new("es-AR");
        private List<HVentas> _ventas = [];
        private List<HVentasDetalle> _detallesVenta = [];
        private int _selectedVentaId = -1;

        public UCConsultaVentas(
            IHVentasService hVentasService,
            IHVentasDetalleService hVentasDetalleService,
            IClientesService clientesService,
            IUsuariosService usuariosService,
            ILogger<UCConsultaVentas> logger)
        {
            _hVentasService = hVentasService;
            _hVentasDetalleService = hVentasDetalleService;
            _clientesService = clientesService;
            _usuariosService = usuariosService;
            _logger = logger;

            InitializeComponent();
        }

        private async void UCConsultaVentas_Load(object sender, EventArgs e)
        {
            // TODO: CAMBIAR TEXTBOX DE CLIENTE POR UN COMBO BOX
            try
            {
                ConfigurarControles();
                await CargarVentasAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar el control de consulta de ventas");
                MessageBox.Show($"Error al cargar las ventas: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarControles()
        {
            // Configurar DataGridView de ventas
            DgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvVentas.MultiSelect = false;
            DgvVentas.ReadOnly = true;
            DgvVentas.AllowUserToAddRows = false;
            DgvVentas.AllowUserToDeleteRows = false;
            DgvVentas.RowHeadersVisible = false;
            DgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar DataGridView de detalles
            DgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDetalles.MultiSelect = false;
            DgvDetalles.ReadOnly = true;
            DgvDetalles.AllowUserToAddRows = false;
            DgvDetalles.AllowUserToDeleteRows = false;
            DgvDetalles.RowHeadersVisible = false;
            DgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar fechas por defecto
            DtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            DtpFechaHasta.Value = DateTime.Today;

            // Configurar estilos
            AplicarEstilos();
        }

        private void AplicarEstilos()
        {
            // Aplicar colores consistentes con la aplicación
            this.BackColor = Color.FromArgb(218, 218, 220);
            
            // Estilo para los GroupBox
            GBLista.ForeColor = Color.FromArgb(7, 100, 147);
            GBForm.ForeColor = Color.FromArgb(7, 100, 147);
            
            // Estilo para las etiquetas
            foreach (Control control in GBForm.Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = Color.FromArgb(26, 28, 30);
                }
                else if (control is TableLayoutPanel panel)
                {
                    foreach (Control subControl in panel.Controls)
                    {
                        if (subControl is Label subLabel)
                        {
                            subLabel.ForeColor = Color.FromArgb(26, 28, 30);
                        }
                    }
                }
            }
            
            // Configurar formato de moneda para las etiquetas de totales
            LblSubtotal.Text = (0).ToString("C", _cultureArgentina);
            LblDescuento.Text = (0).ToString("C", _cultureArgentina);
            LblTotal.Text = (0).ToString("C", _cultureArgentina);
        }

        private async Task CargarVentasAsync()
        {
            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                var result = await Task.Run(() => _hVentasService.GetAll());

                if (result.IsSuccess)
                {
                    _ventas = result.Value;
                    ActualizarListaVentas();
                }
                else
                {
                    MessageBox.Show($"Error al cargar las ventas: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar las ventas");
                MessageBox.Show($"Error al cargar las ventas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private void ActualizarListaVentas()
        {
            DgvVentas.DataSource = null;
            DgvVentas.DataSource = _ventas;

            // Configurar columnas
            if (DgvVentas.Columns.Contains("Id_Remito"))
            {
                DgvVentas.Columns["Id_Remito"].HeaderText = "Nº Remito";
                DgvVentas.Columns["Id_Remito"].FillWeight = 20;
            }
            
            if (DgvVentas.Columns.Contains("Fecha_Hora"))
            {
                DgvVentas.Columns["Fecha_Hora"].HeaderText = "Fecha";
                DgvVentas.Columns["Fecha_Hora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                DgvVentas.Columns["Fecha_Hora"].FillWeight = 30;
            }
            
            if (DgvVentas.Columns.Contains("Total"))
            {
                DgvVentas.Columns["Total"].HeaderText = "Total";
                DgvVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
                DgvVentas.Columns["Total"].DefaultCellStyle.FormatProvider = _cultureArgentina;
                DgvVentas.Columns["Total"].FillWeight = 25;
            }

            // Ocultar columnas innecesarias
            var columnasOcultar = new[] { "Cod_Usuario", "Id_Cliente", "Subtotal", "Descu" };
            foreach (var columna in columnasOcultar)
            {
                if (DgvVentas.Columns.Contains(columna))
                    DgvVentas.Columns[columna].Visible = false;
            }
        }

        private async void DgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvVentas.CurrentRow?.DataBoundItem is HVentas venta)
            {
                _selectedVentaId = venta.Id_Remito;
                await CargarDetallesVentaAsync(venta.Id_Remito);
                MostrarDetallesVenta(venta);
            }
            else
            {
                _selectedVentaId = -1;
                LimpiarDetallesVenta();
            }
        }

        private async Task CargarDetallesVentaAsync(int idRemito)
        {
            try
            {
                var result = await Task.Run(() => _hVentasDetalleService.GetByRemitoId(idRemito));

                if (result.IsSuccess)
                {
                    _detallesVenta = result.Value;
                    ActualizarListaDetalles();
                }
                else
                {
                    MessageBox.Show($"Error al cargar detalles: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar detalles de venta {IdRemito}", idRemito);
                MessageBox.Show($"Error al cargar detalles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarListaDetalles()
        {
            DgvDetalles.DataSource = null;
            DgvDetalles.DataSource = _detallesVenta;

            // Ocultar columnas innecesarias
            var columnasOcultar = new[] { "Id_Det_Remito", "Id_Remito" };
            foreach (var columna in columnasOcultar)
            {
                if (DgvDetalles.Columns.Contains(columna))
                    DgvDetalles.Columns[columna].Visible = false;
            }
                
            // Configurar columnas visibles
            if (DgvDetalles.Columns.Contains("Cod_Art"))
            {
                DgvDetalles.Columns["Cod_Art"].HeaderText = "Código";
                DgvDetalles.Columns["Cod_Art"].FillWeight = 15;
            }
                
            if (DgvDetalles.Columns.Contains("Descr"))
            {
                DgvDetalles.Columns["Descr"].HeaderText = "Descripción";
                DgvDetalles.Columns["Descr"].FillWeight = 40;
            }
                
            if (DgvDetalles.Columns.Contains("P_Unit"))
            {
                DgvDetalles.Columns["P_Unit"].HeaderText = "Precio Unit.";
                DgvDetalles.Columns["P_Unit"].DefaultCellStyle.Format = "C2";
                DgvDetalles.Columns["P_Unit"].DefaultCellStyle.FormatProvider = _cultureArgentina;
                DgvDetalles.Columns["P_Unit"].FillWeight = 15;
            }
                
            if (DgvDetalles.Columns.Contains("Cant"))
            {
                DgvDetalles.Columns["Cant"].HeaderText = "Cantidad";
                DgvDetalles.Columns["Cant"].FillWeight = 10;
            }
                
            if (DgvDetalles.Columns.Contains("P_X_Cant"))
            {
                DgvDetalles.Columns["P_X_Cant"].HeaderText = "Total";
                DgvDetalles.Columns["P_X_Cant"].DefaultCellStyle.Format = "C2";
                DgvDetalles.Columns["P_X_Cant"].DefaultCellStyle.FormatProvider = _cultureArgentina;
                DgvDetalles.Columns["P_X_Cant"].FillWeight = 15;
            }
        }

        private void MostrarDetallesVenta(HVentas venta)
        {
            LblIdRemito.Text = venta.Id_Remito.ToString();
            LblFecha.Text = venta.Fecha_Hora.ToString("dd/MM/yyyy HH:mm");
            LblSubtotal.Text = venta.Subtotal.ToString("C", _cultureArgentina);
            LblDescuento.Text = venta.Descu.ToString("C", _cultureArgentina);
            LblTotal.Text = venta.Total.ToString("C", _cultureArgentina);
            
            // Cargar información adicional (cliente, usuario) de forma asíncrona
            _ = CargarInformacionAdicionalAsync(venta);
        }

        private async Task CargarInformacionAdicionalAsync(HVentas venta)
        {
            try
            {
                // Cargar información del cliente
                var clienteResult = await _clientesService.GetById(venta.Id_Cliente);
                if (clienteResult.IsSuccess)
                {
                    LblCliente.Text = clienteResult.Value?.Nombre ?? "Cliente no encontrado";
                }
                else
                {
                    LblCliente.Text = "Error al cargar cliente";
                }

                // Cargar información del usuario
                var usuarioResult = await _usuariosService.GetById(venta.Cod_Usuario);
                if (usuarioResult.IsSuccess)
                {
                    LblUsuario.Text = usuarioResult.Value?.Nombre ?? "Usuario no encontrado";
                }
                else
                {
                    LblUsuario.Text = "Error al cargar usuario";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar información adicional para venta {IdRemito}", venta.Id_Remito);
                LblCliente.Text = "Error al cargar";
                LblUsuario.Text = "Error al cargar";
            }
        }

        private void LimpiarDetallesVenta()
        {
            LblIdRemito.Text = "";
            LblFecha.Text = "";
            LblCliente.Text = "";
            LblUsuario.Text = "";
            LblSubtotal.Text = "";
            LblDescuento.Text = "";
            LblTotal.Text = "";
            
            DgvDetalles.DataSource = null;
            _detallesVenta.Clear();
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (_selectedVentaId <= 0)
            {
                MessageBox.Show("Por favor, seleccione una venta para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show("¿Está seguro que desea eliminar esta venta? Esta acción no se puede deshacer.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    PbProgreso.Visible = true;
                    PbProgreso.Style = ProgressBarStyle.Marquee;

                    var result = await Task.Run(() => _hVentasService.Delete(_selectedVentaId));

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Venta eliminada correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Recargar la lista de ventas
                        await CargarVentasAsync();
                        LimpiarDetallesVenta();
                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar la venta: {result.Error}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al eliminar venta {IdRemito}", _selectedVentaId);
                    MessageBox.Show($"Error al eliminar la venta: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    PbProgreso.Visible = false;
                }
            }
        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            await FiltrarVentasAsync();
        }

        private async Task FiltrarVentasAsync()
        {
            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                DateTime fechaDesde = DtpFechaDesde.Value.Date;
                DateTime fechaHasta = DtpFechaHasta.Value.Date.AddDays(1).AddTicks(-1); // Fin del día
                string cliente = TxtCliente.Text.Trim();
                string idRemitoText = TxtIdRemito.Text.Trim();
                
                // Intentar parsear el ID de remito si se proporciona
                int? idRemito = null;
                if (!string.IsNullOrEmpty(idRemitoText) && int.TryParse(idRemitoText, out int parsedId))
                {
                    idRemito = parsedId;
                }

                var result = await Task.Run(() => _hVentasService.GetFiltered(fechaDesde, fechaHasta, cliente, idRemito));

                if (result.IsSuccess)
                {
                    _ventas = result.Value;
                    ActualizarListaVentas();
                }
                else
                {
                    MessageBox.Show($"Error al filtrar ventas: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al filtrar ventas");
                MessageBox.Show($"Error al filtrar ventas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

     

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            _ = CargarVentasAsync();
        }
    }
}