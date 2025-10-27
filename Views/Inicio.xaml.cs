namespace esanchezS2._1.Views;

public partial class Inicio : ContentPage
{
    public Inicio(string usuario, string contrasena)
    {
        InitializeComponent();
	}

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        try
		{
            string estudiante = pkEstudiante.Items[pkEstudiante.SelectedIndex].ToString();
            //asignacion de las notas
            double dato1 = Convert.ToDouble(txtNota1.Text);
			double dato2 = Convert.ToDouble(txtExamen1.Text);
			double dato3 = Convert.ToDouble(txtNota2.Text);
			double dato4 = Convert.ToDouble(txtExamen2.Text);

            //sentencia de la fecha
            DateTime fecha = DateTime.Now;
            txtFecha.Text =(""+fecha.ToString("g"));

            //calculo de notas
            double parcial1 = dato1 * 0.3;
			txtN1.Text = parcial1.ToString("N3");

            double examen1 = dato2 * 0.2;
			txtEP1.Text = examen1.ToString("N3");

            double parcial2 = dato3 * 0.3;
			txtN2.Text = parcial2.ToString("N3");

            double examen2 = dato4 * 0.2;
			txtEP2.Text = examen2.ToString("N3");

            double suma1 = parcial1 + examen1;
            txtTP1.Text = suma1.ToString("N3");

            double suma2 = parcial2 + examen2;
            txtTP2.Text = suma2.ToString("N3");

            double total = suma1 + suma2;
            txtResultado.Text = total.ToString("N3");

            if (string.IsNullOrWhiteSpace(txtNota1.Text))
            {
                DisplayAlert("ERROR", "El Campo Nota de Seguimiento 1 No Debe estar vacio", "REINTENTAR");
                txtNota1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtExamen1.Text))
            {
                DisplayAlert("ERROR", "El Campo Nota Examen P1 No Debe estar vacio", "REINTENTAR");
                txtExamen1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNota2.Text))
            {
                DisplayAlert("ERROR", "El Campo Nota de Seguimiento 2 No Debe estar vacio", "REINTENTAR");
                txtNota2.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtExamen2.Text))
            {
                DisplayAlert("ERROR", "El Campo Nota Examen P2 No Debe estar vacio", "REINTENTAR");
                txtExamen2.Focus();
                return;
            }            

            if (total >= 7)
            {
                txtNota.Text = "APROBADO";
            }

            else if (total >= 5 && total <= 6.9)
            {
                txtNota.Text = "COMPLEMENTARIO";
            }

            else
            {
                txtNota.Text = "REPROBADO";
            }

            DisplayAlert("RESUMEN", "Nombre: " + estudiante + "\nFecha: " + fecha +
                     "\nNota Parcial 1: " + suma1.ToString("N3") + "\nNota Parcial 2: " + suma2.ToString("N3") +
                     "\nNota Final: " + total.ToString("N2") + "\nEstado del Semestre: " + txtNota.Text, "CONTINUAR");
        }
        catch (Exception)
		{
            DisplayAlert("ALERTA", "Debe seleccionar un Estudiante", "REINTENTAR");
            pkEstudiante.SelectedIndex = -1;
            return;
        }
    }
}