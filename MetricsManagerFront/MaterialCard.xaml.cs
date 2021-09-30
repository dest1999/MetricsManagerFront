using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MetricsManagerFront
{
    /// <summary>
    /// Interaction logic for MaterialCard.xaml
    /// </summary>
    public partial class MaterialCard : UserControl, INotifyPropertyChanged
    {

        public MaterialCard()
        {
            InitializeComponent();

            ColumnSeriesValues = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<double> {  }
                }
            };

            DataContext = this;
        }

        public SeriesCollection ColumnSeriesValues { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateOnСlick(object sender, RoutedEventArgs e)
        {
            TimePowerChart.Update(true);
        }
    }
}

