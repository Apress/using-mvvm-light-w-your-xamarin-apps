using Windows.UI.Xaml.Controls;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace TimeOfDeath.WinPhone.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Conditions : Page
    {
        StateFoundViewModel ViewModel;

        public Conditions()
        {
            this.InitializeComponent();
            ViewModel = DataContext as StateFoundViewModel;                                          
        }                                 

        void SpinnerChanged(object sender, SelectionChangedEventArgs e)
        {
            var spinner = sender as ListBox;
            switch(spinner.Name)
            {
                case "BodyCond":
                    ViewModel.BodyCondition = ViewModel.GetBodyLayers[spinner.SelectedIndex];
                    break;
            }
        }
    }
}
