namespace esanchezS2._1.Views;

public partial class LogIn : ContentPage
{

	string[] usser = { "Carlos", "Ana", "Jose" };
	string[] clave = { "carlos123", "ana123", "jose123" };
	public LogIn()
	{
		InitializeComponent();
	}

    private void btnIngresar_Clicked(object sender, EventArgs e)
    {
		try
		{
			//datos de acceso
			string usuario = txtUsuario.Text;
			string contrasena = txtContrasena.Text;
			bool acceso = false;

			for (int i = 0; i < 3; i++)
			{
				if (usuario == usser[i] && contrasena == clave[i])
				{
					Navigation.PushAsync(new Views.Inicio(usuario, contrasena));
					acceso = true;
					break;
				}
			}

			if (acceso)
			{
                DisplayAlert("Bienvenido", "Usuario: " + usuario + " \nEn Linea", "CONTINUAR");
            }
            else
            {
                DisplayAlert("ERROR", "Usuario o Contraseña Incorrectos", "OK");
            }
        }
		catch (Exception ex)
		{
            Console.WriteLine(ex.Message);
        }

    }
}