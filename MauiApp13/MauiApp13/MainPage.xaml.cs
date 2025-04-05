using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiApp13
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> Cart { get; set; }
        public ICommand AddToCartCommand { get; }
        public ICommand NavigateToCartCommand { get; }

        public MainPage()
        {
            InitializeComponent();
            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Хлопья", Price = 110 },
                new Product { Name = "Макароны", Price = 150 },
                new Product { Name = "Молоко", Price = 80 },
                 new Product { Name = "Кефир", Price = 90 }
            };
            Cart = new ObservableCollection<Product>();
            AddToCartCommand = new Command<Product>(AddToCart);
            NavigateToCartCommand = new Command(NavigateToCart);
            BindingContext = this;
        }

        private void AddToCart(Product product)
        {
            if (product.Quantity > 0)
            {
                Cart.Add(new Product { Name = product.Name, Price = product.Price, Quantity = product.Quantity });
            }
        }

        private async void NavigateToCart()
        {
            await Navigation.PushAsync(new CartPage(Cart));
        }
    }
}