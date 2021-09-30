//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
    public class Agent
    {
        public int agentId {  get; set; }
        public string agentUri {  get; set; }

        public new string ToString()
        {
            return $"ID: {agentId}, Url: {agentUri}";
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random(); //для отладки
        string managerAddress = "https://localhost:44380"; //в дальнейшем брать значение из GUI
        public List<Agent> agentsList = new List<Agent>();
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

            agentsList = GetAgentsListFromManager(managerAddress);


        }

        private List<Agent> GetAgentsListFromManager(string managerAddress)
        {
            managerAddress += "/api/Agents/agentslist";
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(managerAddress));
            var response = new HttpClient().SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = response.Content.ReadAsStreamAsync().Result)
                {
                    return JsonSerializer.DeserializeAsync<List<Agent>>(responseStream, new JsonSerializerOptions(JsonSerializerDefaults.Web)).Result;
                }
            }
            return null;
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
            List<string> agents = new List<string>();
            foreach (var item in agentsList)
            {
                agents.Add(item.ToString());
            }
            comboBoxAgentsList.ItemsSource = agents;

        }
    }
}
