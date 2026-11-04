using LicznikJS4f.Models;
using LicznikJS4f.PageModels;

namespace LicznikJS4f.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}