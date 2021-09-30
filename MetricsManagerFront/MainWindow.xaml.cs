using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random(); //для отладки
        Uri managerUri = new Uri("localhost:44380"); //в дальнейшем брать значение из GUI
        List<string> agentsList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            InitOnRun();
        }

        private void InitOnRun()
        {
            CpuChart.CaptionName.Text = "Cpu Load";
            CpuChart.PercentTextBlock.Text = "...";
            RamChart.CaptionName.Text = "Ram Load";
            RamChart.PercentTextBlock.Text = "...";

            agentsList = GetAgentsListFromManager(managerUri);

        }

        private List<string> GetAgentsListFromManager(Uri managerUri)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            #region Try to fun

            List<double> collection = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                collection.Add(rnd.Next(100));
            }


            #endregion
            CpuChart.ColumnSeriesValues[0].Values.Add(48d);

            
            foreach (var item in collection)
            {
                RamChart.ColumnSeriesValues[0].Values.Add(item);

            }

            //RamChart.ColumnSeriesValues.AddRange((IEnumerable<object>)collection);
        }

        private void comboBoxAgentsList_DropDownOpened(object sender, EventArgs e)
        {

        }
    }
}
