using PrimeSystem.Contrato.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace PrimeSystem.UI;

public partial class FormPrincipal : Form
{
    private readonly IArticulosService _articulosService;
    public FormPrincipal(IArticulosService articulosService)
    {
        _articulosService = articulosService;
        InitializeComponent();
    }

    private void FormPrincipal_Load(object sender, EventArgs e)
    {
        try
        {
            var resultado =  _articulosService.GetAll();

            this.Invoke((MethodInvoker)delegate
            {
                if (resultado.IsSuccess)
                {
                    //_bindingSource.DataSource = resultado.Value;
                    dataGridView1.DataSource = resultado.Value;
                }
                else
                {
                    MessageBox.Show(resultado.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }
        catch (Exception ex)
        {
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show($"Error al cargar artículos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }
    }
}