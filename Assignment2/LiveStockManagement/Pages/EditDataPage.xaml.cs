namespace LiveStockManagement.Pages;

public partial class EditDataPage : ContentPage
{
    private readonly DatabaseService _dbs;
    public List<string> AnimalTypes { get; set; } = ["Cow", "Sheep"];
    public EditDataPage(DatabaseService dbs)
    {
        InitializeComponent();
        _dbs = dbs;
        BindingContext = this;
    }

    private void Add(object sender, EventArgs e)
    {
        if (AnimalPicker.SelectedItem is not string type)
        {
            DisplayAlert("", "Must select animal type", "OK");
            return;
        }
        Livestock? s = type switch
        {
            "Cow" => new Cow()
            {
                Expense = 0,
                Weight = 0,
                Colour = "Black",
                Milk = 0,
            },
            "Sheep" => new Sheep()
            {
                Expense = 0,
                Weight = 0,
                Colour = "Black",
                Wool = 0,
            },
            _ => null,
        };
        if (s is null) return;
        int added = _dbs.InsertItem(s);
        //if (added > 0)
        //{
        //    DisplayAlert("", $"Added: {s.Expense}", "OK");
        //    WeakReferenceMessenger.Default.Send(new DBUpdatedMessage(true));
        //}
    }
}