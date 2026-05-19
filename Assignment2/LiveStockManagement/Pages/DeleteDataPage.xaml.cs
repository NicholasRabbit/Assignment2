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

    private async void Delete(object sender, EventArgs e)
    {
        string input = Id_Entry.Text?.Trim();

        // Requirement 4: Validate format — must be a non-empty integer
        if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int id))
        {
            ShowError("Invalid input. Please enter a valid numeric Livestock ID.");
            return;
        }

        // Requirement 3: Validate existence
        var existing = _dbs.ReadItems().FirstOrDefault(x => x.Id == id);
        if (existing is null)
        {
            ShowError($"Non-existent livestock ID: {id}.");
            return;
        }

        // Requirement 2: Confirm before deleting
        bool confirmed = await DisplayAlert(
            "Confirm Deletion",
            $"Are you sure you want to delete livestock record with ID {id}? This cannot be undone.",
            "Delete",
            "Cancel");

        if (!confirmed)
            return;

        // Requirement 5 & 6: Delete from DB and notify observers (DataPage listens via messenger)
        _dbs.DeleteItem(id);
        WeakReferenceMessenger.Default.Send(new DBUpdatedMessage());

        HideError();
        Id_Entry.Text = string.Empty;
        await DisplayAlert("Success", $"Livestock record {id} has been deleted.", "OK");
    }

    private void ShowError(string message)
    {
        ErrorLabel.Text = message;
        ErrorLabel.IsVisible = true;
    }

    private void HideError()
    {
        ErrorLabel.Text = string.Empty;
        ErrorLabel.IsVisible = false;
    }
}
