using System.Net;

namespace adiazS7.Vistas;

public partial class AgregarEstudiante : ContentPage
{
	public AgregarEstudiante()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
			cliente.UploadValues("http://192.168.56.1/moviles/post.php", "POST", parametros);
			Navigation.PushAsync(new Inicio());
        }
		catch (Exception ex)
		{

			DisplayAlert("ERROR", ex.Message, "CERRAR");
		}
    }
}