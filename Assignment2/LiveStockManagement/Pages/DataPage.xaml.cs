namespace LiveStockManagement.Pages;

public partial class DataPage : ContentPage
{
	public ObservableCollection<Livestock> Livestock { get; set; } = [];

    public DataPage(DatabaseService dbs)
	{
		InitializeComponent();
		BindingContext = this;
		dbs.ReadItems().ForEach(item => Livestock.Add(item));


    }
}