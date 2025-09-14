using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.UI.Articulos
{
    public partial class UCGestionCategorias : UserControl
    {
        private readonly ICategoriasService _categoriasService;
        private readonly ISubcategoriaService _subcategoriasService;
        private readonly ILogger<UCGestionCategorias> _logger;
        private List<Categorias> _categorias = new List<Categorias>();
        private List<Subcategoria> _subcategorias = new List<Subcategoria>();
        private int _selectedCategoriaId = -1;
        private int _selectedSubcategoriaId = -1;

        public UCGestionCategorias(
            ICategoriasService categoriasService,
            ISubcategoriaService subcategoriasService,
            ILogger<UCGestionCategorias> logger)
        {
            _categoriasService = categoriasService;
            _subcategoriasService = subcategoriasService;
            _logger = logger;

            InitializeComponent();
        }

        private async void UCGestionCategorias_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarControles();
                await CargarCategoriasAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar el control de gestión de categorías");
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarControles()
        {
            // Configurar DataGridView de categorías
            DgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvCategorias.MultiSelect = false;
            DgvCategorias.ReadOnly = true;
            DgvCategorias.AllowUserToAddRows = false;
            DgvCategorias.AllowUserToDeleteRows = false;
            DgvCategorias.RowHeadersVisible = false;
            DgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar DataGridView de subcategorías
            DgvSubcategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvSubcategorias.MultiSelect = false;
            DgvSubcategorias.ReadOnly = true;
            DgvSubcategorias.AllowUserToAddRows = false;
            DgvSubcategorias.AllowUserToDeleteRows = false;
            DgvSubcategorias.RowHeadersVisible = false;
            DgvSubcategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar estilos
            AplicarEstilos();
        }

        private void AplicarEstilos()
        {
            // Aplicar colores consistentes con la aplicación
            this.BackColor = Color.FromArgb(249, 249, 251);

            // Estilo para los GroupBox
            GBCategorias.ForeColor = Color.FromArgb(7, 100, 147);
            GBSubcategorias.ForeColor = Color.FromArgb(7, 100, 147);
            GBFormCategoria.ForeColor = Color.FromArgb(7, 100, 147);
            GBFormSubcategoria.ForeColor = Color.FromArgb(7, 100, 147);

            // Estilo para las etiquetas
            foreach (Control control in GBFormCategoria.Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = Color.FromArgb(26, 28, 30);
                }
            }

            foreach (Control control in GBFormSubcategoria.Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = Color.FromArgb(26, 28, 30);
                }
            }
        }

        private async Task CargarCategoriasAsync()
        {
            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                var result = await TareasLargas.EjecutarAsync(
                    () => _categoriasService.GetAll().Result,
                    "Cargando categorías...");

                if (result.IsSuccess)
                {
                    _categorias = result.Value;
                    ActualizarListaCategorias();
                }
                else
                {
                    MessageBox.Show($"Error al cargar las categorías: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar las categorías");
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private async Task CargarSubcategoriasAsync()
        {
            try
            {
                if (_selectedCategoriaId <= 0)
                {
                    _subcategorias.Clear();
                    ActualizarListaSubcategorias();
                    return;
                }

                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                var result = await TareasLargas.EjecutarAsync(
                    () => _subcategoriasService.GetAllxCategoria(_selectedCategoriaId).Result,
                    "Cargando subcategorías...");

                if (result.IsSuccess)
                {
                    _subcategorias = result.Value;
                    ActualizarListaSubcategorias();
                }
                else
                {
                    MessageBox.Show($"Error al cargar las subcategorías: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar las subcategorías");
                MessageBox.Show($"Error al cargar las subcategorías: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private void ActualizarListaCategorias()
        {
            DgvCategorias.DataSource = null;
            DgvCategorias.DataSource = _categorias;

            // Configurar columnas
            if (DgvCategorias.Columns.Contains("Id_categoria"))
            {
                DgvCategorias.Columns["Id_categoria"].HeaderText = "ID";
                DgvCategorias.Columns["Id_categoria"].FillWeight = 20;
            }

            if (DgvCategorias.Columns.Contains("Categoria"))
            {
                DgvCategorias.Columns["Categoria"].HeaderText = "Categoría";
                DgvCategorias.Columns["Categoria"].FillWeight = 80;
            }
        }

        private void ActualizarListaSubcategorias()
        {
            DgvSubcategorias.DataSource = null;
            DgvSubcategorias.DataSource = _subcategorias;

            // Configurar columnas
            if (DgvSubcategorias.Columns.Contains("Id_Subcategoria"))
            {
                DgvSubcategorias.Columns["Id_Subcategoria"].HeaderText = "ID";
                DgvSubcategorias.Columns["Id_Subcategoria"].FillWeight = 20;
            }

            if (DgvSubcategorias.Columns.Contains("Sub_categoria"))
            {
                DgvSubcategorias.Columns["Sub_categoria"].HeaderText = "Subcategoría";
                DgvSubcategorias.Columns["Sub_categoria"].FillWeight = 80;
            }

            // Ocultar columnas innecesarias
            if (DgvSubcategorias.Columns.Contains("Id_Categoria"))
            {
                DgvSubcategorias.Columns["Id_Categoria"].Visible = false;
            }
        }

        private void DgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvCategorias.CurrentRow?.DataBoundItem is Categorias categoria)
            {
                _selectedCategoriaId = categoria.Id_categoria;
                TxtCategoria.Text = categoria.Categoria ?? "";
                LblCategoriaSeleccionada.Text = categoria.Categoria ?? "";
                _ = CargarSubcategoriasAsync();
            }
            else
            {
                _selectedCategoriaId = -1;
                TxtCategoria.Text = "";
                LblCategoriaSeleccionada.Text = "Ninguna";
                _subcategorias.Clear();
                ActualizarListaSubcategorias();
            }
        }

        private void DgvSubcategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvSubcategorias.CurrentRow?.DataBoundItem is Subcategoria subcategoria)
            {
                _selectedSubcategoriaId = subcategoria.Id_Subcategoria;
                TxtSubcategoria.Text = subcategoria.Sub_categoria ?? "";
            }
            else
            {
                _selectedSubcategoriaId = -1;
                TxtSubcategoria.Text = "";
            }
        }

        private async void BtnNuevaCategoria_Click(object sender, EventArgs e)
        {
            // Solicitar el nombre de la nueva categoría usando un diálogo simple
            string nombreCategoria = Prompt.ShowDialog("Ingrese el nombre de la nueva categoría:", "Nueva Categoría");

            // Verificar que se haya ingresado un nombre
            if (string.IsNullOrWhiteSpace(nombreCategoria))
            {
                return;
            }

            // Limpiar espacios
            nombreCategoria = nombreCategoria.Trim();

            // Verificar si ya existe una categoría con el mismo nombre
            var categoriaExistente = _categorias.FirstOrDefault(c => 
                c.Categoria.Equals(nombreCategoria, StringComparison.OrdinalIgnoreCase));

            if (categoriaExistente != null)
            {
                MessageBox.Show($"Ya existe una categoría con el nombre '{nombreCategoria}'.", 
                    "Categoría existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                // Crear nueva categoría
                var categoria = new Categorias
                {
                    Categoria = nombreCategoria
                };

                var result = await TareasLargas.EjecutarAsync(
                    () => _categoriasService.Add(categoria),
                    "Agregando categoría...");

                if (result.IsSuccess)
                {
                    MessageBox.Show("Categoría agregada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar lista de categorías
                    await CargarCategoriasAsync();
                }
                else
                {
                    MessageBox.Show($"Error al agregar la categoría: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar categoría");
                MessageBox.Show($"Error al agregar la categoría: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private async void BtnGuardarCategoria_Click(object sender, EventArgs e)
        {
            // El botón guardar ahora solo actualizará la categoría seleccionada
            if (_selectedCategoriaId <= 0)
            {
                MessageBox.Show("Por favor, seleccione una categoría para actualizar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtCategoria.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre de la categoría.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtCategoria.Focus();
                return;
            }

            string nombreCategoria = TxtCategoria.Text.Trim();

            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                // Actualizar categoría existente
                var categoria = new Categorias
                {
                    Id_categoria = _selectedCategoriaId,
                    Categoria = nombreCategoria
                };

                var result = await TareasLargas.EjecutarAsync(
                    () => _categoriasService.Update(categoria),
                    "Actualizando categoría...");

                if (result.IsSuccess)
                {
                    MessageBox.Show("Categoría actualizada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar lista de categorías
                    await CargarCategoriasAsync();
                }
                else
                {
                    MessageBox.Show($"Error al actualizar la categoría: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar categoría");
                MessageBox.Show($"Error al actualizar la categoría: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private async void BtnEliminarCategoria_Click(object sender, EventArgs e)
        {
            if (_selectedCategoriaId <= 0)
            {
                MessageBox.Show("Por favor, seleccione una categoría para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si hay subcategorías asociadas
            var subcategoriasResult = _subcategoriasService.GetAllxCategoria(_selectedCategoriaId).Result;
            if (subcategoriasResult.IsSuccess && subcategoriasResult.Value.Any())
            {
                MessageBox.Show("No se puede eliminar la categoría porque tiene subcategorías asociadas. Elimine primero las subcategorías.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show("¿Está seguro que desea eliminar esta categoría? Esta acción no se puede deshacer.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    PbProgreso.Visible = true;
                    PbProgreso.Style = ProgressBarStyle.Marquee;

                    // CORRECCIÓN: Usar await en lugar de .Result para evitar el congelamiento
                    var result = await TareasLargas.EjecutarAsync(
                        () => _categoriasService.Delete(_selectedCategoriaId),
                        "Eliminando categoría...");

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Categoría eliminada correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiar formulario y recargar lista
                        TxtCategoria.Text = "";
                        _selectedCategoriaId = -1;
                        await CargarCategoriasAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar la categoría: {result.Error}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al eliminar categoría {IdCategoria}", _selectedCategoriaId);
                    MessageBox.Show($"Error al eliminar la categoría: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    PbProgreso.Visible = false;
                }
            }
        }

        private async void BtnNuevaSubcategoria_Click(object sender, EventArgs e)
        {
            if (_selectedCategoriaId <= 0)
            {
                MessageBox.Show("Por favor, seleccione una categoría primero.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Solicitar el nombre de la nueva subcategoría usando un diálogo simple
            string nombreSubcategoria = Prompt.ShowDialog("Ingrese el nombre de la nueva subcategoría:", "Nueva Subcategoría");

            // Verificar que se haya ingresado un nombre
            if (string.IsNullOrWhiteSpace(nombreSubcategoria))
            {
                return;
            }

            // Limpiar espacios
            nombreSubcategoria = nombreSubcategoria.Trim();

            // Verificar si ya existe una subcategoría con el mismo nombre en la misma categoría
            var subcategoriaExistente = _subcategorias.FirstOrDefault(s => 
                s.Sub_categoria.Equals(nombreSubcategoria, StringComparison.OrdinalIgnoreCase));

            if (subcategoriaExistente != null)
            {
                MessageBox.Show($"Ya existe una subcategoría con el nombre '{nombreSubcategoria}' en esta categoría.", 
                    "Subcategoría existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                // Crear nueva subcategoría
                var subcategoria = new Subcategoria
                {
                    Sub_categoria = nombreSubcategoria,
                    Id_Categoria = _selectedCategoriaId
                };

                var result = await TareasLargas.EjecutarAsync(
                    () => _subcategoriasService.Add(subcategoria),
                    "Agregando subcategoría...");

                if (result.IsSuccess)
                {
                    MessageBox.Show("Subcategoría agregada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar lista de subcategorías
                    await CargarSubcategoriasAsync();
                }
                else
                {
                    MessageBox.Show($"Error al agregar la subcategoría: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar subcategoría");
                MessageBox.Show($"Error al agregar la subcategoría: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private async void BtnGuardarSubcategoria_Click(object sender, EventArgs e)
        {
            // El botón guardar ahora solo actualizará la subcategoría seleccionada
            if (_selectedSubcategoriaId <= 0)
            {
                MessageBox.Show("Por favor, seleccione una subcategoría para actualizar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedCategoriaId <= 0)
            {
                MessageBox.Show("Por favor, seleccione una categoría primero.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtSubcategoria.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre de la subcategoría.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtSubcategoria.Focus();
                return;
            }

            string nombreSubcategoria = TxtSubcategoria.Text.Trim();

            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                // Actualizar subcategoría existente
                var subcategoria = new Subcategoria
                {
                    Id_Subcategoria = _selectedSubcategoriaId,
                    Sub_categoria = nombreSubcategoria,
                    Id_Categoria = _selectedCategoriaId
                };

                var result = await TareasLargas.EjecutarAsync(
                    () => _subcategoriasService.Update(subcategoria),
                    "Actualizando subcategoría...");

                if (result.IsSuccess)
                {
                    MessageBox.Show("Subcategoría actualizada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar lista de subcategorías
                    await CargarSubcategoriasAsync();
                }
                else
                {
                    MessageBox.Show($"Error al actualizar la subcategoría: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar subcategoría");
                MessageBox.Show($"Error al actualizar la subcategoría: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private async void BtnEliminarSubcategoria_Click(object sender, EventArgs e)
        {
            if (_selectedSubcategoriaId <= 0)
            {
                MessageBox.Show("Por favor, seleccione una subcategoría para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show("¿Está seguro que desea eliminar esta subcategoría? Esta acción no se puede deshacer.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    PbProgreso.Visible = true;
                    PbProgreso.Style = ProgressBarStyle.Marquee;

                    // CORRECCIÓN: Usar await en lugar de .Result para evitar el congelamiento
                    var result = await TareasLargas.EjecutarAsync(
                        () => _subcategoriasService.Delete(_selectedSubcategoriaId),
                        "Eliminando subcategoría...");

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Subcategoría eliminada correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiar formulario y recargar lista
                        TxtSubcategoria.Text = "";
                        _selectedSubcategoriaId = -1;
                        await CargarSubcategoriasAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar la subcategoría: {result.Error}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al eliminar subcategoría {IdSubcategoria}", _selectedSubcategoriaId);
                    MessageBox.Show($"Error al eliminar la subcategoría: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    PbProgreso.Visible = false;
                }
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            _ = CargarCategoriasAsync();
        }
    }

    // Clase auxiliar para mostrar diálogos de entrada
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 350 };
            Button confirmation = new Button() { Text = "Aceptar", Left = 200, Width = 80, Top = 80, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Cancelar", Left = 290, Width = 80, Top = 80, DialogResult = DialogResult.Cancel };
            
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { prompt.Close(); };
            
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}