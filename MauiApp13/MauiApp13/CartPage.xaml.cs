using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;
using Windows.Networking.NetworkOperators;

namespace MauiApp13;

public partial class CartPage : ContentPage
{
    public ObservableCollection<Product> Cart { get; set; }
    public ICommand RemoveFromCartCommand { get; }
    public ICommand PlaceOrderCommand { get; }

    public CartPage(ObservableCollection<Product> cart)
	{
		InitializeComponent();
        Cart = cart;
        RemoveFromCartCommand = new Command<Product>(RemoveFromCart);
        PlaceOrderCommand = new Command(PlaceOrder);
        BindingContext = this;
    }

    private void RemoveFromCart(Product product)
    {
        Cart.Remove(product);
    }

    private async void PlaceOrder()
    {
        var order = new Order
        {
            Products = new List<Product>(Cart),
            Status = "Новый"
        };

        // Сохранение заказа в JSON
        string json = JsonSerializer.Serialize(order);
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "orders.json");
        File.AppendAllText(filePath, json + Environment.NewLine);

        await Navigation.PushAsync(new ProfilePage());
    }
}