using Examen.Models;

namespace Examen;

public partial class Clientes : ContentPage
{
    private string ApiUrl = "https://appwebutn2.azurewebsites.net/api/Clientes";
    public Clientes()
	{
		InitializeComponent();
	}

    private void cmdCreateCli_Clicked(object sender, EventArgs e)
    {
        var resultado = APIConsumer.Crud<Cliente>.Create(ApiUrl, new Cliente
        {
            Id = 0,
            Nombre = txtNombre.Text,
            Apellido = txtApellido.Text,
            Direccion = txtDireccion.Text,
            Telefono = txtTelefono.Text
        });

        if (resultado != null)
        {
            txtIdCliente.Text = resultado.Id.ToString();
            // Mostrar un mensaje de éxito al usuario
            DisplayAlert("Éxito", "El Cliente ha sido creado correctamente.", "OK");
        }
        else
        {
            // Opcionalmente, puedes manejar la situación de que resultado es null (es decir, la creación falló)
            DisplayAlert("Error", "No se pudo crear el Cliente.", "OK");
        }
    }

    private void cmdLeerCli_Clicked(object sender, EventArgs e)
    {
        var resultado = APIConsumer.Crud<Cliente>.Read_ById(ApiUrl, int.Parse(txtIdCliente.Text));
        txtIdCliente.Text = resultado.Id.ToString();
        txtNombre.Text = resultado.Nombre.ToString();
        txtApellido.Text = resultado.Apellido.ToString();
        txtDireccion.Text = resultado.Direccion.ToString();
        txtTelefono.Text = resultado.Telefono.ToString();
    }

    private void cmdUpdateCli_Clicked(object sender, EventArgs e)
    {
        try
        {
            APIConsumer.Crud<Cliente>.Update(ApiUrl, int.Parse(txtIdCliente.Text), new Cliente
            {
                Id = int.Parse(txtIdCliente.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text

            });
            // Mostrar mensaje de éxito
            DisplayAlert("Éxito", "Producto actualizado correctamente", "OK");
        }
        catch (Exception ex)
        {
            // Mostrar mensaje de error en caso de que la actualización falle
            DisplayAlert("Error", "Ocurrio un problema para actualizar", "OK");
        }
    }

    private void cmdDeleteCli_Clicked(object sender, EventArgs e)
    {
        try
        {
            APIConsumer.Crud<Cliente>.Delete(ApiUrl, int.Parse(txtIdCliente.Text));
            txtIdCliente.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            // Mostrar mensaje de éxito
            DisplayAlert("Éxito", "Cliente eliminado correctamente", "OK");
        }
        catch (Exception ex)
        {
            // Mostrar mensaje de error en caso de que la eliminación falle
            DisplayAlert("Error", "Ocurrio un problema para eliminar", "OK");
        }
    }

    private void cmdRegresar_Clicked(object sender, EventArgs e)
    {

    }

    private void cmdRegresar_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Pedidos());
    }

    private void cmdMenu_Clicked(object sender, EventArgs e)
    {

    }

    private void cmdMenu_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}