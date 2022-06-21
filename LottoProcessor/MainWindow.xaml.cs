using Lotto.Models.Dtos.LottoDrawings;
using Lotto.Services.Interfaces;
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

namespace LottoProcessor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILottoDrawingsService _lottoDrawingsService;
        private readonly ISkipService _skipService;
        private readonly IRelationshipService _relationshipService;

        public bool High = true;

        public List<LottoDrawingsDto> Data { get; set; } = new List<LottoDrawingsDto>();

        public MainWindow()
        {
            InitializeComponent();

            // Resolve injections here
            _lottoDrawingsService = App.Container.GetInstance<ILottoDrawingsService>();
            _skipService = App.Container.GetInstance<ISkipService>();
            _relationshipService = App.Container.GetInstance<IRelationshipService>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataForTabViews();
        }

        private void LoadDataForTabViews() 
        {
            LoadDrawingsAndSkips();
            LoadRelationshipNumbers();
        }

        private void LoadDrawingsAndSkips() 
        {
            var drawings = _lottoDrawingsService.GetAllDrawings();
            var skips = _skipService.GetSkipCountForAllNumbers();

            Task.WaitAll(new Task[] { drawings, skips });

            DrawingsDataGrid.ItemsSource = drawings.Result;
            SkipsDataGrid.ItemsSource = skips.Result;
        }

        private void LoadRelationshipNumbers() 
        {
            for (int i = 1; i <= 70; i++) 
            {
                LottoNumbersListBox.Items.Add(i);
            }
        }

        private void LottoNumbersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int mcp = _relationshipService.MostPairedWith((int)e.AddedItems[0]).Result;

            MCPLabel.Content = "Most Common Pair: " + mcp.ToString();
        }
    }
}
