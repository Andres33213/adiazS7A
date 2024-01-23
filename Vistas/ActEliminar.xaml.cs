using adiazS7.Modelos;
using System.Net;

namespace adiazS7.Vistas;

public partial class ActEliminar : ContentPage
{
	public ActEliminar(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();
	}

    private void btnACtualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string edad = txtEdad.Text;

            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues("http://192.168.56.1/moviles/post.php?codigo="+codigo+"&nombre="+nombre+"&apellido="+apellido+"&edad="+edad,"PUT", parametros);
            Navigation.PushAsync(new Inicio());

        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text;

            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues("http://192.168.56.1/moviles/post.php?codigo="+codigo,"DELETE", parametros);
            Navigation.PushAsync(new Inicio());

        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }
}