namespace Examen;
using Examen.Models;
public partial class Pedidos : ContentPage
{
    private string ApiUrl = "https://appwebutn2.azurewebsites.net/api/Pedidos";
    public Pedidos()
    {
        InitializeComponent();
    }

    private void cmdCreatePed_Clicked(object sender, EventArgs e)
    {
        var resultado = APIConsumer.Crud<Pedido>.Create(ApiUrl, new Pedido
        {
            Id = 0,
            Descripcion = txtDescripcionPedido.Text,
            Fecha = txtDescripcionFecha.Text,
            Total = double.Parse(txtDescripcionTotal.Text),
            ClienteId = int.Parse(txtClienteID.Text)
        });
        if (resultado != null)
        {
            txtIdPedido.Text = resultado.Id.ToString();
            DisplayAlert("Éxito", "El pedido ha sido creado correctamente.", "OK");
        }
        else
        {
            DisplayAlert("Error", "No se pudo crear el pedido.", "OK");
        }
    }

    private void cmdLeerPed_Clicked(object sender, EventArgs e)
    {
        var resultado = APIConsumer.Crud<Pedido>.Read_ById(ApiUrl, int.Parse(txtIdPedido.Text));
        if (resultado != null)
        {
            txtDescripcionPedido.Text = resultado.Descripcion.ToString();
            txtDescripcionFecha.Text = resultado.Fecha.ToString();
            txtDescripcionTotal.Text = resultado.Total.ToString();
            txtClienteID.Text = resultado.ClienteId.ToString();
        }
        else
        {
            DisplayAlert("Error", "No se pudo leer el pedido.", "OK");
        }
    }

    private void cmdUpdatePed_Clicked(object sender, EventArgs e)
    {
        try
        {
            APIConsumer.Crud<Pedido>.Update(ApiUrl, int.Parse(txtIdPedido.Text), new Pedido
            {
                Id = int.Parse(txtIdPedido.Text),
                Descripcion = txtDescripcionPedido.Text,
                Fecha = txtDescripcionFecha.Text,
                Total = double.Parse(txtDescripcionTotal.Text),
                ClienteId = int.Parse(txtClienteID.Text)
            });
            DisplayAlert("Éxito", "El pedido ha sido actualizado correctamente.", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", "No se pudo actualizar el pedido.", "OK");
        }
    }
    private void cmdRegresar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Clientes());
    }

    private void cmdMenu_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }

    private void cmdDeleteProd_Clicked(object sender, EventArgs e)
    {
        try
        {
            APIConsumer.Crud<Pedido>.Delete(ApiUrl, int.Parse(txtIdPedido.Text));
            txtIdPedido.Text = "";
            txtDescripcionPedido.Text = "";
            txtDescripcionFecha.Text = "";
            txtDescripcionTotal.Text = "";
            txtClienteID.Text = "";
            DisplayAlert("Éxito", "El pedido ha sido eliminado correctamente.", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", "No se pudo eliminar el pedido.", "OK");
        }
    }
}