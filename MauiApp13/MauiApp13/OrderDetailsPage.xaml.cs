namespace MauiApp13;

public partial class OrderDetailsPage : ContentPage
{
    public Order Order { get; set; }
    public OrderDetailsPage(Order order)
	{
		InitializeComponent();
        Order = order;
        BindingContext = this;
    }
}