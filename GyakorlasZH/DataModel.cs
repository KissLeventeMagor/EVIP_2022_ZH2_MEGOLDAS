using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GyakorlasZH
{
    public class DataModel : INotifyPropertyChanged
    {
        private ObservableCollection<Car> _cars { get; set; }
        public ObservableCollection<Car> cars 
        {
            get => _cars;
            set
            {
                if (_cars != value)
                {
                    _cars = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _brand { get; set; }
        public string Brand
        {
            get => _brand;
            set
            {
                if (_brand != value)
                {
                    _brand = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _maxprice { get; set; }
        public int MaxPrice
        {
            get => _maxprice;
            set
            {
                if( _maxprice != value)
                {
                    _maxprice = value;
                    OnPropertyChanged();
                    command?.RaiseCanExecuteChanged();
                }
            }
        }
        private string _selectedtype { get; set; }
        public string SelectedType
        {
            get => _selectedtype;
            set
            {
                if (_selectedtype != value)
                {
                    _selectedtype = value;
                    OnPropertyChanged();
                    command?.RaiseCanExecuteChanged(); // Az új metódus hívása
                }
            }
        }
        private int _days { get; set; }
        public int Days
        {
            get => _days;
            set
            {
                if (value != _days)
                {
                    _days = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Summary { get; set; }

        public SearchCommand command { get; } 
        public DataModel()
        {
            cars = new ObservableCollection<Car>();
            command = new SearchCommand(this);
        }

        public void AddCar(Car input)
        {
            _cars.Add(input);
        }

        public string SummaryToString()
        {
            return $"{Brand} típusú {SelectedType} autó, összesen {Days} napra, napi maximum {MaxPrice} Ft.";
        }

        public async Task Search()
        {
            var allCars = new List<Car>
            {
                new Car("Toyota Yaris", 2000, "kicsi"),
                new Car("Ford Fiesta", 1500, "kicsi"),
                new Car("BMW X5", 3000, "nagy"),
                new Car("Audi Q7", 3200, "nagy"),
                new Car("Honda Civic", 1800, "közepes"),
                new Car("Tesla Model 3", 3500, "közepes"),
                new Car("Volkswagen Golf", 2200, "közepes"),
                new Car("Skoda Octavia", 2500, "közepes"),
                new Car("Mercedes-Benz GLC", 4000, "nagy")
            };

            var carsToReturn = allCars.Where(
                x => x.Name.Contains(Brand, StringComparison.OrdinalIgnoreCase) &&
                     x.Price <= MaxPrice &&
                     x.Type.Equals(SelectedType, StringComparison.OrdinalIgnoreCase)
            );

            cars.Clear();
            foreach (var car in carsToReturn)
            {
                await Task.Delay(1000);
                cars.Add(car);
            }

            Summary = SummaryToString();
            OnPropertyChanged(nameof(Summary));
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
