using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Abakon15.Utility;
using System.Windows.Data;
using Abakon15.Infrastructure;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Media;
using AbakonDataModel;


namespace Abakon15.ViewModels
{
    public class GraphsElementVM : ViewModelBase
    {
        EquipmentGraph _currentEquipmentGraph;
        public EquipmentGraph CurrentEquipmentGraph
        {
            get
            {
                if (_currentEquipmentGraph == null) { _currentEquipmentGraph = new EquipmentGraph(); };
                return _currentEquipmentGraph;
            }
            set { SetField(ref _currentEquipmentGraph, value, () => CurrentEquipmentGraph); }
        }

        public List<int> YearsList { get; set; }

        public PrzyrzadPomiarowy CurrentPrzyrzadPomiarowy
        { get; set; }

        int selectedYear;
        public int SelectedYear
        {
            get { return selectedYear; }
            set { SetField(ref selectedYear, value, () => SelectedYear); }
        }

        public string isColLimitsSymmetricText
        {
            get { return CurrentEquipmentGraph.isSymmetric ? "±" : "·"; }
        }

        bool isopenMainExpander = false;
        public bool isOpenMainExpander
        {
            get { return isopenMainExpander; }
            set { SetField(ref isopenMainExpander, value, () => isOpenMainExpander); }
        }

        bool isopenSubExpander = false;
        public bool isOpenSubExpander
        {
            get { return isopenSubExpander; }
            set { SetField(ref isopenSubExpander, value, () => isOpenSubExpander); }
        }

        Chart _myChart;
        public Chart MyChart
        {
            get { return _myChart; }
            set { SetField(ref _myChart, value, () => MyChart); }
        }

        DataGrid _mydataGrid;
        public DataGrid MyDataGrid
        {
            get { return _mydataGrid; }
            set { SetField(ref _mydataGrid, value, () => MyDataGrid); }
        }


        string _excelFile = string.Empty;
        public string ExcelFile
        {
            get { return _excelFile; }
            set { SetField(ref _excelFile, value, () => ExcelFile); }
        }

        List<string> _excelSheets;
        public List<string> ExcelSheets
        {
            get { return _excelSheets; }
            set { SetField(ref _excelSheets, value, () => ExcelSheets); }
        }

        string _selectedExcelSheet;
        public string SelectedExcelSheet
        {
            get { return _selectedExcelSheet; }
            set { SetField(ref _selectedExcelSheet, value, () => SelectedExcelSheet); }
        }

        double sqSumOfLimits = 0.0;
        Dictionary<int, double> sqSumOfErrors = new Dictionary<int, double>();

        public GraphsElementVM(PrzyrzadPomiarowy equipment, string _ExcelFile)
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                CurrentPrzyrzadPomiarowy = equipment;
                if (_ExcelFile != null)
                {
                    ExcelFile = _ExcelFile;
                    ExcelSheets = Abakon15.Reports.ExcelDocument.GetSheetsNames(ExcelFile);
                    if (ExcelSheets.Any()) SelectedExcelSheet = ExcelSheets.Last();
                }

                int CurrYear = DateTime.Today.Year;
                selectedYear = CurrYear;
                YearsList = new List<int>();
                for (int i = 0; i < 5; i++)
                {
                    YearsList.Add(CurrYear - i);
                }
            }
        }

        public GraphsElementVM(EquipmentGraph _Graph)
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                int CurrYear = DateTime.Today.Year;
                selectedYear = CurrYear;
                YearsList = new List<int>();
                for (int i = 0; i < 5; i++)
                {
                    YearsList.Add(CurrYear - i);
                }

                ExcelFile = _Graph.document.filePath.Path + @"\" + _Graph.document.FileName;
                ExcelSheets = Abakon15.Reports.ExcelDocument.GetSheetsNames(ExcelFile);
                if (ExcelSheets.Any()) SelectedExcelSheet = ExcelSheets.Last();

                isOpenMainExpander = true;
                isOpenSubExpander = false;
                CurrentEquipmentGraph = _Graph;
                CurrentPrzyrzadPomiarowy = _Graph.equipment;
                RaisePropertyChanged(() => CurrentEquipmentGraph);
            }
        }

        public GraphsElementVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                int CurrYear = DateTime.Today.Year;
                selectedYear = CurrYear;
                YearsList = new List<int>();
                for (int i = 0; i < 5; i++)
                {
                    YearsList.Add(CurrYear - i);
                }
            }
        }

        public void DataGridBuilder(DataGrid dataGrid = null)
        {

            if (dataGrid != null)
            {
                if (dataGrid != null) { MyDataGrid = dataGrid; }
                if (MyDataGrid != null)
                {
                    if (MyDataGrid.Columns.Count == 0)
                    {
                        BuildDataGridColumns(MyDataGrid, CurrentEquipmentGraph.getColumnHeadersTable());
                    }
                }
                DataTable table = CurrentEquipmentGraph.getDataSourceCollection();
                string ser = "Kol_" + CurrentEquipmentGraph.NumbOfColMeas.ToString();
                table.DefaultView.Sort = "Kol_0 DESC, " + ser + " ASC ";
                MyDataGrid.ItemsSource = table.DefaultView;
                MyDataGrid.Items.Refresh();
            }
        }

        public void ChartBuilder(Chart _chart = null)
        {
            // ColMeasSeries
            //Limits series ColMeasSeries
            if (_chart != null) { MyChart = _chart; }
            MyChart.Series.Clear();

            AreaSeries a1 = new AreaSeries();
            AreaSeries a2 = new AreaSeries();
            AreaSeries a3 = new AreaSeries();

            AreaSeries a1Neg = new AreaSeries();
            AreaSeries a2Neg = new AreaSeries();
            AreaSeries a3Neg = new AreaSeries();

            a1.Title = "Limit";
            a1Neg.Title = "-Limit";
            a2.Title = "0.75Limit";
            a2Neg.Title = "-0.75Limit";
            a3.Title = "0.25Limit";
            a3Neg.Title = "-0.25Limit";

            if (CurrentEquipmentGraph.isSymmetric)
            { ((LinearAxis)MyChart.Axes[0]).Minimum = null; }
            else
            {
                { ((LinearAxis)MyChart.Axes[0]).Minimum = 0; }
            }

            List<KeyValuePair<double, double>> a1List = new List<KeyValuePair<double, double>>();
            List<KeyValuePair<double, double>> a2List = new List<KeyValuePair<double, double>>();
            List<KeyValuePair<double, double>> a3List = new List<KeyValuePair<double, double>>();
            List<KeyValuePair<double, double>> a1NegList = new List<KeyValuePair<double, double>>();
            List<KeyValuePair<double, double>> a2NegList = new List<KeyValuePair<double, double>>();
            List<KeyValuePair<double, double>> a3NegList = new List<KeyValuePair<double, double>>();

            Dictionary<int, List<KeyValuePair<double, double>>> errorSeriesList = new Dictionary<int, List<KeyValuePair<double, double>>>();

            sqSumOfErrors = new Dictionary<int, double>();
            sqSumOfLimits = 0.0;
            var DataSourceCollection = CurrentEquipmentGraph.getDataSourceCollection();
            for (int i = 0; i < DataSourceCollection.Rows.Count; i++)
            {
                int y;
                if (int.TryParse(DataSourceCollection.Rows[i].ItemArray[0].ToString(), out y))
                {
                    if (!errorSeriesList.Keys.Contains(y))
                    {
                        errorSeriesList.Add(y, new List<KeyValuePair<double, double>>());
                        sqSumOfErrors.Add(y, 0.0);

                    }
                }
            }

            int ostYear = sqSumOfErrors.Keys.Max();


            for (int i = 0; i < DataSourceCollection.Rows.Count; i++)
            {
                double p1, p2, err;
                int _year;

                if (
                double.TryParse(DataSourceCollection.Rows[i].ItemArray[CurrentEquipmentGraph.NumbOfColMeas].ToString(), out p1) &&
                                double.TryParse(DataSourceCollection.Rows[i].ItemArray[CurrentEquipmentGraph.NumbOfColLimits].ToString(), out p2) &&
                                int.TryParse(DataSourceCollection.Rows[i].ItemArray[0].ToString(), out _year))
                {
                    if (ostYear == _year)
                    {
                        a1List.Add(new KeyValuePair<double, double>(p1, p2));
                        sqSumOfLimits += p2 * p2;
                        a2List.Add(new KeyValuePair<double, double>(p1, 0.75 * p2));
                        a3List.Add(new KeyValuePair<double, double>(p1, 0.25 * p2));
                        if (CurrentEquipmentGraph.isSymmetric)
                        {
                            a1NegList.Add(new KeyValuePair<double, double>(p1, -1 * p2));
                            a2NegList.Add(new KeyValuePair<double, double>(p1, -0.75 * p2));
                            a3NegList.Add(new KeyValuePair<double, double>(p1, -0.25 * p2));
                        }
                    }
                    if (double.TryParse(DataSourceCollection.Rows[i].ItemArray[CurrentEquipmentGraph.NumbOfColErrors].ToString(), out err))
                    {
                        ((List<KeyValuePair<double, double>>)errorSeriesList[_year]).Add(new KeyValuePair<double, double>(p1, err));
                        sqSumOfErrors[_year] += err * err;
                    }
                }
            }
            a1.ItemsSource = a1List;
            a1.DependentValuePath = "Value";
            a1.IndependentValuePath = "Key";
            if (CurrentEquipmentGraph.isSymmetric)
            {
                a1Neg.ItemsSource = a1NegList;
                a1Neg.DependentValuePath = "Value";
                a1Neg.IndependentValuePath = "Key";
            }

            a2.ItemsSource = a2List;
            a2.DependentValuePath = "Value";
            a2.IndependentValuePath = "Key";
            if (CurrentEquipmentGraph.isSymmetric)
            {
                a2Neg.ItemsSource = a2NegList;
                a2Neg.DependentValuePath = "Value";
                a2Neg.IndependentValuePath = "Key";
            }

            a3.ItemsSource = a3List;
            a3.DependentValuePath = "Value";
            a3.IndependentValuePath = "Key";
            if (CurrentEquipmentGraph.isSymmetric)
            {
                a3Neg.ItemsSource = a3NegList;
                a3Neg.DependentValuePath = "Value";
                a3Neg.IndependentValuePath = "Key";
            }

            #region Styling

            var legendNullStyle = new Style(typeof(LegendItem));
            legendNullStyle.Setters.Add(new Setter(LegendItem.VisibilityProperty, Visibility.Collapsed));
            a1Neg.LegendItemStyle = legendNullStyle;
            a2Neg.LegendItemStyle = legendNullStyle;
            a3Neg.LegendItemStyle = legendNullStyle;

            var a1Style = new Style(typeof(DataPoint));
            a1Style.Setters.Add(new Setter(Chart.BackgroundProperty, (LinearGradientBrush)Application.Current.Resources["ChartLimitBrush"]));
            var a1NegStyle = new Style(typeof(DataPoint));
            a1NegStyle.Setters.Add(new Setter(Chart.BackgroundProperty, (LinearGradientBrush)Application.Current.Resources["ChartLimitNegativeBrush"]));

            a1.DataPointStyle = a1Style;
            a1Neg.DataPointStyle = a1NegStyle;

            var a2Style = new Style(typeof(DataPoint));
            a2Style.Setters.Add(new Setter(Chart.BackgroundProperty, (LinearGradientBrush)Application.Current.Resources["ChartLimit1Brush"]));
            var a2NegStyle = new Style(typeof(DataPoint));
            a2NegStyle.Setters.Add(new Setter(Chart.BackgroundProperty, (LinearGradientBrush)Application.Current.Resources["ChartLimit1NegativeBrush"]));

            a2.DataPointStyle = a2Style;
            a2Neg.DataPointStyle = a2NegStyle;

            var a3Style = new Style(typeof(DataPoint));
            a3Style.Setters.Add(new Setter(Chart.BackgroundProperty, (SolidColorBrush)Application.Current.Resources["ChartLimit2Brush"]));
            a3.DataPointStyle = a3Style;
            a3Neg.DataPointStyle = a3Style;

            Style[] errStyles = new Style[5];
            errStyles[0] = new Style(typeof(DataPoint));
            errStyles[0].Setters.Add(new Setter(Chart.BackgroundProperty, new SolidColorBrush(Colors.Yellow)));

            errStyles[1] = new Style(typeof(DataPoint));
            errStyles[1].Setters.Add(new Setter(Chart.BackgroundProperty, new SolidColorBrush(Colors.Orange)));
            errStyles[2] = new Style(typeof(DataPoint));
            errStyles[2].Setters.Add(new Setter(Chart.BackgroundProperty, new SolidColorBrush(Colors.Purple)));
            errStyles[3] = new Style(typeof(DataPoint));
            errStyles[3].Setters.Add(new Setter(Chart.BackgroundProperty, new SolidColorBrush(Colors.Blue)));
            errStyles[4] = new Style(typeof(DataPoint));
            errStyles[4].Setters.Add(new Setter(Chart.BackgroundProperty, new SolidColorBrush(Colors.Green)));

            #endregion



            MyChart.Series.Add(a1);
            if (CurrentEquipmentGraph.isSymmetric) MyChart.Series.Add(a1Neg);
            MyChart.Series.Add(a2);
            if (CurrentEquipmentGraph.isSymmetric) MyChart.Series.Add(a2Neg);
            MyChart.Series.Add(a3);
            if (CurrentEquipmentGraph.isSymmetric) MyChart.Series.Add(a3Neg);
            int k = errorSeriesList.Keys.Count - 1;
            foreach (var item in errorSeriesList.OrderBy(s => s.Key).Select(sk => sk.Key))
            {
                LineSeries ls = new LineSeries();
                ls.ItemsSource = errorSeriesList[item];
                ls.DependentValuePath = "Value";
                ls.IndependentValuePath = "Key";
                ls.Title = "_year_Label".Translate() + " " + item.ToString() + System.Environment.NewLine + "_devDegree".Translate() + DevDegree(item);
                ls.DataPointStyle = errStyles[k--];
                MyChart.Series.Add(ls);
            }

        }

        private string DevDegree(int year)
        {
            double deg = 1;
            if (sqSumOfLimits > 0.0)
            {
                deg = Math.Sqrt(sqSumOfErrors[year] / sqSumOfLimits);
            }
            return deg.ToString("#0.###");
        }

        protected override void SaveToDB(object param = null)
        {
            DataGrid dataGrid = param as DataGrid;

            CurrentEquipmentGraph.ColumnWidhts = "";
            foreach (var item in dataGrid.Columns)
            {
                CurrentEquipmentGraph.ColumnWidhts += item.ActualWidth.ToString() + "\t";
            }

            if (CurrentPrzyrzadPomiarowy != null && !CurrentPrzyrzadPomiarowy.graphs.Contains(CurrentEquipmentGraph))
            {
                CurrentPrzyrzadPomiarowy.graphs.Add(CurrentEquipmentGraph);
            }
            if (CurrentPrzyrzadPomiarowy.AktualnaKalibracja != null &&
                CurrentPrzyrzadPomiarowy.AktualnaKalibracja.ExcelFile != null &&
                !CurrentPrzyrzadPomiarowy.AktualnaKalibracja.ExcelFile.graphs.Contains(CurrentEquipmentGraph))
            {
                CurrentPrzyrzadPomiarowy.AktualnaKalibracja.ExcelFile.graphs.Add(CurrentEquipmentGraph);
            }
            base.SaveToDB(param);
        }

        protected override void AddFromClipboard(object param, bool init = true)
        {
            if (init)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Range range = ClipboardExcel.GetRange();
                    if (range != null)
                    {
                        CurrentEquipmentGraph.SheetRange = range.get_Address(false, false, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
                        RaisePropertyChanged(() => CurrentEquipmentGraph);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "_error".Translate(), MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                CurrentEquipmentGraph.SheetRangeHasHeaders = true;
            }

            string[][] clipboardData = ClipboardUtility.ClipboardTable();
            int cols = clipboardData[0].Length + 1;
            int rows = clipboardData.Length;
            string[][] clipboardDataWithYear = new string[rows][];
            clipboardDataWithYear[0] = new string[cols];
            clipboardDataWithYear[0][0] = "_year_Label".Translate();
            clipboardData[0].CopyTo(clipboardDataWithYear[0], 1);
            for (int i = 1; i < rows; i++)
            {
                clipboardDataWithYear[i] = new string[cols];
                clipboardDataWithYear[i][0] = selectedYear.ToString();
                clipboardData[i].CopyTo(clipboardDataWithYear[i], 1);
            }

            DataGrid dataGrid = param as DataGrid;

            if (dataGrid != null)
            {
                if (dataGrid.Columns.Count == 0)
                {
                    CurrentEquipmentGraph.setColumnHeaders(clipboardDataWithYear[0]);
                    BuildDataGridColumns(dataGrid, CurrentEquipmentGraph.getColumnHeadersTable());
                    CurrentEquipmentGraph.setDataSourceCollection(clipboardDataWithYear);
                }
                else
                {
                    if (CurrentEquipmentGraph.IsHeadersCompatible(clipboardDataWithYear[0]))
                    {
                        CurrentEquipmentGraph.setDataSourceCollection(clipboardDataWithYear);
                    }
                    else
                    {
                        MessageBox.Show("_incompatibleColumns".Translate(), "_error".Translate(), MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            //  SelectCellByIndex(dataGrid, 0, 0); 
            dataGrid.ItemsSource = CurrentEquipmentGraph.getDataSourceCollection().DefaultView;
            dataGrid.Items.Refresh();
        }

        private void AddFromClipboardWithoutHeaders(object param, bool init = true)
        {
            if (init)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Range range = ClipboardExcel.GetRange();
                    if (range != null)
                    {
                        CurrentEquipmentGraph.SheetRange = range.get_Address(false, false, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
                        RaisePropertyChanged(() => CurrentEquipmentGraph);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "_error".Translate(), MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                CurrentEquipmentGraph.SheetRangeHasHeaders = false;
            }

            string[] ColumnHeaders = CurrentEquipmentGraph.getColumnHeadersTable();

            string clipboardString = (string)Clipboard.GetData(DataFormats.Text);
            string[][] clipboardData = ClipboardUtility.ClipboardTable();
            int cols = clipboardData[0].Length + 1;
            int rows = clipboardData.Length;
            string[][] clipboardDataWithYear = new string[rows][];
            for (int i = 0; i < rows; i++)
            {
                clipboardDataWithYear[i] = new string[cols];
                clipboardDataWithYear[i][0] = selectedYear.ToString();
                clipboardData[i].CopyTo(clipboardDataWithYear[i], 1);
            }

            DataGrid dataGrid = param as DataGrid;
            if (CurrentEquipmentGraph.IsHeadersCompatible(clipboardDataWithYear[0].Length))
            {
                CurrentEquipmentGraph.setDataSourceCollection(clipboardDataWithYear, false);
            }
            else
            {
                MessageBox.Show("_incompatibleColumns".Translate(), "_error".Translate(), MessageBoxButton.OK, MessageBoxImage.Error);
            }

            dataGrid.ItemsSource = CurrentEquipmentGraph.getDataSourceCollection().DefaultView;
            dataGrid.Items.Refresh();
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {

                case "CurrentEquipmentGraph":
                    {
                        break;
                    }

                default:
                    break;
            }
        }


        RelayCommand m_appendFromClipboardCommand;
        public RelayCommand AppendFromClipboardCommand
        {
            get
            {
                if (m_appendFromClipboardCommand == null)
                {
                    m_appendFromClipboardCommand = new RelayCommand(
                        param => AddFromClipboardWithoutHeaders(param),
                        param => (param as DataGrid) != null && (param as DataGrid).Columns.Count > 0
                        );
                }
                return m_appendFromClipboardCommand;
            }
        }

        RelayCommand m_appendFromClipboardByRangeCommand;
        public RelayCommand AppendFromClipboardByRangeCommand
        {
            get
            {
                if (m_appendFromClipboardByRangeCommand == null)
                {
                    m_appendFromClipboardByRangeCommand = new RelayCommand(
                        param =>
                        {
                            Abakon15.Reports.ExcelDocument.CopyRangeToClipboard(ExcelFile, SelectedExcelSheet, CurrentEquipmentGraph.SheetRange);
                            if (CurrentEquipmentGraph.SheetRangeHasHeaders)
                            {
                                AddFromClipboard(param, false);
                            }
                            else
                            {
                                AddFromClipboardWithoutHeaders(param, false);
                            }
                        },
                        param => (param as DataGrid) != null && (param as DataGrid).Columns.Count > 0
                        );
                }
                return m_appendFromClipboardByRangeCommand;
            }
        }


        private void BuildDataGridColumns(DataGrid dataGrid, string[] columns)
        {
            if (CurrentEquipmentGraph.ColumnWidhts == null || CurrentEquipmentGraph.ColumnWidhts == "")
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    CurrentEquipmentGraph.ColumnWidhts += "Auto\t";
                }
            }
            string[] _columnWidhts = CurrentEquipmentGraph.ColumnWidhts.Split('\t');
            var ColumnHeaders = new string[columns.Length];
            columns.CopyTo(ColumnHeaders, 0);
            for (int i = 0; i < columns.Length; i++)
            {
                DataGridTextColumn newCol = new DataGridTextColumn();
                newCol.Header = columns[i];
                double _columWidth = 0;
                if (double.TryParse(_columnWidhts[i], out _columWidth))
                {
                    newCol.Width = _columWidth;
                }


                newCol.MaxWidth = 120;

                newCol.Binding = new Binding("Kol_" + i.ToString());
                dataGrid.Columns.Add(newCol);

            }
            CurrentEquipmentGraph.setColumnHeaders(ColumnHeaders);
        }


        RelayCommand m_SetColMeasSeriesCommand = null;
        public RelayCommand SetColMeasSeriesCommand
        {
            get
            {
                if (m_SetColMeasSeriesCommand == null)
                {
                    m_SetColMeasSeriesCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        if ((param as DataGrid) != null)
                                                        {
                                                            DataGrid dg = param as DataGrid;

                                                            var sC = dg.SelectedCells.ToArray<DataGridCellInfo>();
                                                            if (sC.Select(c => c.Column).Distinct().Count() == 1)
                                                            {
                                                                var selColumn = sC.Select(c => c.Column).Distinct().FirstOrDefault();
                                                                CurrentEquipmentGraph.NumbOfColMeas = selColumn.DisplayIndex;
                                                                CurrentEquipmentGraph.ColMeasSeriesHeader = selColumn.Header.ToString();
                                                                RaisePropertyChanged(() => CurrentEquipmentGraph);
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("_onlyOneColumnCanSelect".Translate());
                                                            }
                                                        }

                                                    },
                                                     param => true
                                                    );
                }
                return m_SetColMeasSeriesCommand;
            }
        }

        RelayCommand m_SetColErrorsCommand = null;
        public RelayCommand SetColErrorsCommand
        {
            get
            {
                if (m_SetColErrorsCommand == null)
                {
                    m_SetColErrorsCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        if ((param as DataGrid) != null)
                                                        {
                                                            DataGrid dg = param as DataGrid;

                                                            var sC = dg.SelectedCells.ToArray<DataGridCellInfo>();
                                                            if (sC.Select(c => c.Column).Distinct().Count() == 1)
                                                            {
                                                                var selColumn = sC.Select(c => c.Column).Distinct().FirstOrDefault();
                                                                CurrentEquipmentGraph.NumbOfColErrors = selColumn.DisplayIndex;
                                                                CurrentEquipmentGraph.ColErrorsHeader = selColumn.Header.ToString();
                                                                RaisePropertyChanged(() => CurrentEquipmentGraph);
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("_onlyOneColumnCanSelect".Translate());
                                                            }
                                                        }

                                                    },
                                                     param => true
                                                    );
                }
                return m_SetColErrorsCommand;
            }
        }

        RelayCommand m_SetColLimitsCommand = null;
        public RelayCommand SetColLimitsCommand
        {
            get
            {
                if (m_SetColLimitsCommand == null)
                {
                    m_SetColLimitsCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        if ((param as DataGrid) != null)
                                                        {
                                                            DataGrid dg = param as DataGrid;

                                                            var sC = dg.SelectedCells.ToArray<DataGridCellInfo>();
                                                            if (sC.Select(c => c.Column).Distinct().Count() == 1)
                                                            {
                                                                var selColumn = sC.Select(c => c.Column).Distinct().FirstOrDefault();
                                                                CurrentEquipmentGraph.NumbOfColLimits = selColumn.DisplayIndex;
                                                                CurrentEquipmentGraph.ColLimitsHeader = selColumn.Header.ToString();
                                                                RaisePropertyChanged(() => CurrentEquipmentGraph);
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("_onlyOneColumnCanSelect".Translate());
                                                            }
                                                        }

                                                    },
                                                     param => true
                                                    );
                }
                return m_SetColLimitsCommand;
            }
        }

        RelayCommand m_PaintGraphCommand = null;
        public RelayCommand PaintGraphCommand
        {
            get
            {
                if (m_PaintGraphCommand == null)
                {
                    m_PaintGraphCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        ChartBuilder();
                                                    },
                                                     param => true
                                                    );
                }
                return m_PaintGraphCommand;
            }
        }

        RelayCommand m_RemoveYearCommand = null;
        public RelayCommand RemoveYearCommand
        {
            get
            {
                if (m_RemoveYearCommand == null)
                {
                    m_RemoveYearCommand = new RelayCommand(
                                                    param =>
                                                    {
                                                        CurrentEquipmentGraph.RemoveYear(selectedYear);
                                                        DataGridBuilder();
                                                        try
                                                        {
                                                            ChartBuilder();
                                                        }
                                                        catch (Exception)
                                                        {
                                                        }
                                                    },
                                                     param => true
                                                    );
                }
                return m_RemoveYearCommand;
            }
        }

    }
}
