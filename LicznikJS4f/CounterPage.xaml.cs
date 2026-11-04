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
        string name = NewCounterEntry.Text;

        if (string.IsNullOrWhiteSpace(name))
        {
            DisplayAlert("Adding error", "B³¹d, wpisz poprawn¹ nazwe licznika ", "sprubuje jeszcze raz");
			return;
        }
		Counters.Add(new CounterItem { Name = name, Value = 0 });
		NewCounterEntry.Text = string.Empty;
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