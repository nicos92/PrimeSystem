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

namespace PrimeSystem.UI.Compras
{
    public partial class UCConsultaCompras : UserControl
    {
        private readonly IHComprasService _hComprasService;
        private readonly IHComprasDetalleService _hComprasDetalleService;
        private readonly IProveedoresService _proveedoresService;
        private readonly IUsuariosService _usuariosService;
        private readonly ILogger<UCConsultaCompras> _logger;
        private readonly CultureInfo _cultureArgentina = new("es-AR");
        private List<HCompras> _compras = [];
        private List<HComprasDetalle> _detallesCompra = [];
        private int _selectedCompraId = -1;

        public UCConsultaCompras(
            IHComprasService hComprasService,
            IHComprasDetalleService hComprasDetalleService,
            IProveedoresService proveedoresService,
            IUsuariosService usuariosService,
            ILogger<UCConsultaCompras> logger)
        {
            _hComprasService = hComprasService;
            _hComprasDetalleService = hComprasDetalleService;
            _proveedoresService = proveedoresService;
            _usuariosService = usuariosService;
            _logger = logger;

            InitializeComponent();
        }

        private async void UCConsultaCompras_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarControles();
                await CargarComprasAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar el control de consulta de compras");
                MessageBox.Show($"Error al cargar las compras: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarControles()
        {
            // Configurar DataGridView de compras
            DgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvCompras.MultiSelect = false;
            DgvCompras.ReadOnly = true;
            DgvCompras.AllowUserToAddRows = false;
            DgvCompras.AllowUserToDeleteRows = false;
            DgvCompras.RowHeadersVisible = false;
            DgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

        private async Task CargarComprasAsync()
        {
            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                var result = await Task.Run(() => _hComprasService.GetAll());

                if (result.IsSuccess)
                {
                    _compras.Clear();
                    _compras = result.Value;
                    ActualizarListaCompras();
                }
                else
                {
                    MessageBox.Show($"Error al cargar las compras: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar las compras");
                MessageBox.Show($"Error al cargar las compras: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private void ActualizarListaCompras()
        {
            DgvCompras.DataSource = null;
            DgvCompras.DataSource = _compras;

            // Configurar columnas
            if (DgvCompras.Columns.Contains("Id_Remito"))
            {
                DgvCompras.Columns["Id_Remito"].HeaderText = "Nº Remito";
                DgvCompras.Columns["Id_Remito"].FillWeight = 20;
            }
            
            if (DgvCompras.Columns.Contains("Fecha_Hora"))
            {
                DgvCompras.Columns["Fecha_Hora"].HeaderText = "Fecha";
                DgvCompras.Columns["Fecha_Hora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                DgvCompras.Columns["Fecha_Hora"].FillWeight = 30;
            }
            
            if (DgvCompras.Columns.Contains("Total"))
            {
                DgvCompras.Columns["Total"].HeaderText = "Total";
                DgvCompras.Columns["Total"].DefaultCellStyle.Format = "C2";
                DgvCompras.Columns["Total"].DefaultCellStyle.FormatProvider = _cultureArgentina;
                DgvCompras.Columns["Total"].FillWeight = 25;
            }

            // Ocultar columnas innecesarias
            var columnasOcultar = new[] { "Cod_Usuario", "Id_Proveedor", "Subtotal", "Descuento" };
            foreach (var columna in columnasOcultar)
            {
                if (DgvCompras.Columns.Contains(columna))
                    DgvCompras.Columns[columna].Visible = false;
            }
        }

        private async void DgvCompras_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvCompras.CurrentRow != null && DgvCompras.CurrentRow?.DataBoundItem is HCompras compra && compra != null)
            {
                _selectedCompraId = compra.Id_Remito;
                await CargarDetallesCompraAsync(compra.Id_Remito);
                MostrarDetallesCompra(compra);
            }
            else
            {
                _selectedCompraId = -1;
                LimpiarDetallesCompra();
            }
        }

        private async Task CargarDetallesCompraAsync(int idRemito)
        {
            try
            {
                var result = await Task.Run(() => _hComprasDetalleService.GetByRemitoId(idRemito));

                if (result.IsSuccess)
                {
                    _detallesCompra = result.Value;
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
                _logger.LogError(ex, "Error al cargar detalles de compra {IdRemito}", idRemito);
                MessageBox.Show($"Error al cargar detalles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarListaDetalles()
        {
            DgvDetalles.DataSource = null;
            DgvDetalles.DataSource = _detallesCompra;

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

        private async void MostrarDetallesCompra(HCompras compra)
        {
            LblIdRemito.Text = compra.Id_Remito.ToString();
            LblFecha.Text = compra.Fecha_Hora.ToString("dd/MM/yyyy HH:mm");
            LblSubtotal.Text = compra.Subtotal.ToString("C", _cultureArgentina);
            LblDescuento.Text = compra.Descuento.ToString("C", _cultureArgentina);
            LblTotal.Text = compra.Total.ToString("C", _cultureArgentina);
            
            
          
            await CargarInformacionAdicionalAsync(compra);
        }

        private async Task CargarInformacionAdicionalAsync(HCompras compra)
        {
            try
            {
                // Cargar información del proveedor
                var proveedorResult = _proveedoresService.GetById(compra.Id_Proveedor);
                if (proveedorResult.IsSuccess)
                {
                    LblProveedor.Text = proveedorResult.Value?.Nombre ?? "Proveedor no encontrado";
                }
                else
                {
                    LblProveedor.Text = "Error al cargar proveedor";
                }

                // Cargar información del usuario
                var usuarioResult = await _usuariosService.GetById(compra.Cod_Usuario);
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
                _logger.LogError(ex, "Error al cargar información adicional para compra {IdRemito}", compra.Id_Remito);
                LblProveedor.Text = "Error al cargar";
                LblUsuario.Text = "Error al cargar";
            }
        }

        private void LimpiarDetallesCompra()
        {
            LblIdRemito.Text = "";
            LblFecha.Text = "";
            LblProveedor.Text = "";
            LblUsuario.Text = "";
            LblSubtotal.Text = "";
            LblDescuento.Text = "";
            LblTotal.Text = "";
            
            DgvDetalles.DataSource = null;
            _detallesCompra.Clear();
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (_selectedCompraId <= 0)
            {
                MessageBox.Show("Por favor, seleccione una compra para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show("¿Está seguro que desea eliminar esta compra? Esta acción no se puede deshacer.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    PbProgreso.Visible = true;
                    PbProgreso.Style = ProgressBarStyle.Marquee;

                    var result = await Task.Run(() => _hComprasService.Delete(_selectedCompraId));

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Compra eliminada correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Recargar la lista de compras
                        await CargarComprasAsync();
                        LimpiarDetallesCompra();
                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar la compra: {result.Error}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al eliminar compra {IdRemito}", _selectedCompraId);
                    MessageBox.Show($"Error al eliminar la compra: {ex.Message}", "Error",
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
            await FiltrarComprasAsync();
        }

        private async Task FiltrarComprasAsync()
        {
            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                DateTime fechaDesde = DtpFechaDesde.Value.Date;
                DateTime fechaHasta = DtpFechaHasta.Value.Date.AddDays(1).AddTicks(-1); // Fin del día
                string proveedor = TxtProveedor.Text.Trim();
                string idRemitoText = TxtIdRemito.Text.Trim();
                
                // Intentar parsear el ID de remito si se proporciona
                int? idRemito = null;
                if (!string.IsNullOrEmpty(idRemitoText) && int.TryParse(idRemitoText, out int parsedId))
                {
                    idRemito = parsedId;
                }
                int? idpro = null;
                if (!string.IsNullOrEmpty(proveedor) && int.TryParse(proveedor, out int parsedPro))
                {
                    idpro = parsedPro;
                }

                var result = await Task.Run(() => _hComprasService.GetFiltered(fechaDesde, fechaHasta, idpro, idRemito));

                if (result.IsSuccess)
                {
                    _compras = result.Value;
                    ActualizarListaCompras();
                }
                else
                {
                    MessageBox.Show($"Error al filtrar compras: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al filtrar compras");
                MessageBox.Show($"Error al filtrar compras: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private async void BtnActualizar_Click(object sender, EventArgs e)
        {
            await CargarComprasAsync();
        }

        private async void BtnConfirmarCompra_Click(object sender, EventArgs e)
        {
            await ConfirmarCompraAsync();
        }

        private async Task ConfirmarCompraAsync()
        {
            if (_selectedCompraId <= 0)
            {
                MessageBox.Show("Por favor, seleccione una compra para confirmar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show("¿Está seguro que desea confirmar esta compra?", "Confirmar compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    PbProgreso.Visible = true;
                    PbProgreso.Style = ProgressBarStyle.Marquee;

                    var result = await Task.Run(() => _hComprasService.Confirmar(_selectedCompraId));

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Compra confirmada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarComprasAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Error al confirmar la compra: {result.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al confirmar compra {IdRemito}", _selectedCompraId);
                    MessageBox.Show($"Error al confirmar la compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    PbProgreso.Visible = false;
                }
            }
        }
    }
}