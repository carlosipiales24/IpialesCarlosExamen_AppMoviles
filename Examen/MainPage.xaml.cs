namespace Examen
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        

        private void cmdClientes_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Clientes());
        }

        private void cmdPedidos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pedidos());
        }
    }

}
