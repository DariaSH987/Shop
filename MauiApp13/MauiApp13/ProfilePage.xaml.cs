using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace MauiApp13;

public partial class ProfilePage : ContentPage
{
    public ObservableCollection<Order> Orders { get; set; }
    public ICommand ViewOrderCommand { get; }
    public ProfilePage()
	{
		InitializeComponent();
        Orders = new ObservableCollection<Order>();
        ViewOrderCommand = new Command<Order>(ViewOrder);
        BindingContext = this;

        LoadOrders();
    }

    private void LoadOrders()
    {
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "orders.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            var orders = JsonSerializer.Deserialize<List<Order>>(json);
            foreach (var order in orders)
            {
                Orders.Add(order);
            }
        }
    }

    private async void ViewOrder(Order order)
    {
        await Navigation.PushAsync(new OrderDetailsPage(order));
    }
}