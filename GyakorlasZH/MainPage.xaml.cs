namespace GyakorlasZH
{
    public partial class MainPage : ContentPage
    {
        public DataModel cars;

        public MainPage()
        {
            InitializeComponent();
            cars = new DataModel();
            BindingContext = cars;
        }
    }

}