using LicznikJS4f;
using System.Collections.ObjectModel;

namespace LicznikJS4f;

public class CounterItem
{
	public string Name { get; set; }
	public int Value { get; set; }
}
public partial class CounterPage : ContentPage
{
	
	public ObservableCollection<CounterItem> Counters { get; set; } = new();

	public CounterPage()
	{
		InitializeComponent();
		CountersCollection.ItemsSource = Counters;
	}
    private void Button_add_Counter(object sender, EventArgs e)
    {
        string name = NewCounterEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            DisplayAlert("Błąd", "Wpisz nazwę licznika.", "OK");
			return;
        }
		int initialValue = 0;
        if (!string.IsNullOrWhiteSpace(InitialValueEntry.Text) &&
            !int.TryParse(InitialValueEntry.Text, out initialValue))
        {
            DisplayAlert("Błąd", "Wpisz poprawną liczbę całkowitą jako wartość początkową.", "OK");
            return;
        }

        Counters.Add(new CounterItem { Name = name, Value = initialValue });
        NewCounterEntry.Text = string.Empty;
        InitialValueEntry.Text = string.Empty;
    }
	private void OnIcrementClicked(object sender, EventArgs e)
	{
		if(sender is Button button && button.BindingContext is CounterItem item)
		{
			item.Value++;
			RefreshList();
		}
	}
    private void OnDecrementClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is CounterItem item)
        {
            item.Value--;
			RefreshList();
        }
    }
	private void RefreshList()
	{
		CountersCollection.ItemsSource = null;
		CountersCollection.ItemsSource = Counters;

    }

}
