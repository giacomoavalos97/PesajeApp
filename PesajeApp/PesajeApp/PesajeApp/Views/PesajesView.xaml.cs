using System.Windows;
using PesajeApp.Services;

namespace PesajeApp.Views;

public partial class PesajesView : Window
{
    private readonly PesajeService _pesajeService;

    public PesajesView()
    {
        InitializeComponent();

        _pesajeService = new PesajeService();

        Loaded += PesajesView_Loaded;
    }

    private async void PesajesView_Loaded(object sender, RoutedEventArgs e)
    {
        await CargarPesajesAsync();
    }

    private async Task CargarPesajesAsync()
    {
        try
        {
            PesajesDataGrid.ItemsSource =
                await _pesajeService.ObtenerTodosAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"No se pudieron cargar los pesajes.\n\n{ex.Message}",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }
}