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
        //try
        //{

        //    Task.Run(() =>
        //    {
        //        var resultado = _articulosService.GetAll();
        //        this.Invoke((MethodInvoker)delegate
        //        {
        //            if (resultado.IsSuccess)
        //            {
        //                dataGridView1.DataSource = resultado.Value;
        //            }
        //            else
        //            {
        //                MessageBox.Show(resultado.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        });
        //    });
        //}
        //catch (ArgumentNullException ex)
        //{ 
        //    MessageBox.Show($"Error al cargar artículos: {ex.Message}", "Error UI",
        //        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show($"Error al cargar artículos: {ex.Message}", "Error UI",
        //        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        // GRISES AZULADOS
//        236, 239, 241
//207, 216, 220
//176, 190, 197
//144, 164, 174
//120, 144, 156
//96, 125, 139
//84, 110, 122
//69, 90, 100
//55, 71, 79
//38, 50, 56
    }
}