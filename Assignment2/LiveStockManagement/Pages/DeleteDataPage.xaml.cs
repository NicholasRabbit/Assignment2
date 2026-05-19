namespace LiveStockManagement.Pages;

public partial class DeleteDataPage : ContentPage
{
    private readonly DatabaseService _dbs;
    public List<string> AnimalTypes { get; set; } = ["Cow", "Sheep"];
    public DeleteDataPage(DatabaseService dbs)
    {
        InitializeComponent();
        _dbs = dbs;
        BindingContext = this;
    }

    private void Delete(object sender, EventArgs e)
    {
        //int Id_Received = int.Parse(Id_Entry.Text);
        //DeleteById(Id_Received);

        //Store? store = Stores.FirstOrDefault(s => s.Id == id);
        //if (store is not null)
        //{
        //    if (database.DeleteItem(store) > 0)
        //    {
        //        Stores.Remove(store);
        //        WriteLine($"Record deleted: {store}");
        //    }
        //}

        //if (AnimalPicker.SelectedItem is not string type)
        //{
        //    DisplayAlert("", "Must select animal type", "OK");
        //    return;
        //}
        //Livestock? s = type switch
        //{
        //    "Cow" => new Cow()
        //    {
        //        Expense = 0,
        //        Weight = 0,
        //        Colour = "Black",
        //        Milk = 0,
        //    },
        //    "Sheep" => new Sheep()
        //    {
        //        Expense = 0,
        //        Weight = 0,
        //        Colour = "Black",
        //        Wool = 0,
        //    },
        //    _ => null,
        //};
        //if (s is null) return;
        //int added = _dbs.InsertItem(s);
        //if (added > 0)
        //{
        //    DisplayAlert("", $"Added: {s.Expense}", "OK");
        //    WeakReferenceMessenger.Default.Send(new DBUpdatedMessage(true));
        //}
    }
    //public void DeleteById(int id)
    //{
    //    Livestock? livestock = AnimalTypes.FirstOrDefault(s => s.Id == id);
    //    if (livestock is not null)
    //    {
    //        if (database.DeleteItem(livestock) > 0)
    //        {
    //            Employees.Remove(employee);
    //            WriteLine($"Record deleted: {employee}");
    //        }
    //    }
    //}
}