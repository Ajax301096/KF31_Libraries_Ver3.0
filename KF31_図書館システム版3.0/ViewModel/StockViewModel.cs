using KF31_図書館システム版3._0.Main_Login_Model;
using KF31_図書館システム版3._0.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace KF31_図書館システム版3._0.ViewModel
{

    public class StockViewModel : BaseViewModel
    {
        private ObservableCollection<Stock_table> _Stocks { get; set; }
        public ObservableCollection<Stock_table> Stocks { get => _Stocks; set { _Stocks = value; OnPropertyChanged(); } }
        private ObservableCollection<Stock_table> _Stocks_Search { get; set; }
        public ObservableCollection<Stock_table> Stocks_Search { get => _Stocks_Search; set { _Stocks_Search = value; OnPropertyChanged(); } }

        private Stock_table _Selected_Stock { get; set; }
        public Stock_table Selected_Stock { get => _Selected_Stock; set { _Selected_Stock = value; OnPropertyChanged(); } }
        private string _Title { get; set; }
        public string Title { get => _Title; set { _Title = value; OnPropertyChanged(); } }
        private int _Value { get; set; }
        public int Value { get => _Value; set { _Value = value; OnPropertyChanged(); } }
        public ICommand SearchCommand { get; set; }
        public ICommand BackMainWindowCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public StockViewModel()
        {
            LoadWindow();


            BackMainWindowCommand = new RelayCommand<Window>((p) => { return true; },
                (p) =>
                {
                    LoadWindow();
                    MainWindow main = new MainWindow();
                    p.Close();
                    main.ShowDialog();
                });
            ClearCommand = new RelayCommand<Window>((p) =>
            {
                if (Selected_Stock == null && string.IsNullOrEmpty(Title) && Value == 0)
                {
                    return false;
                }
                else
                    return true;
            },
            (p) =>
            {
                LoadWindow();
            });
            SearchCommand = new RelayCommand<Window>(
                (p) =>
                {
                    if (Selected_Stock == null && Title == null)
                    {
                        return false;
                    }
                    else
                        return true;
                },
                (p) =>
                {
                    Stocks_Search.Clear();
                    var SearchList = Stocks.Where(x =>
                    (Selected_Stock == null || x.StockID == Selected_Stock.StockID)
                    && (string.IsNullOrEmpty(Title) || x.Book_table.Book_title.Contains(Title))
                    && (Value == 0 || x.Quantity == Value)
                    ).ToList();
                    foreach (var item in SearchList)
                    {
                        Stocks_Search.Add(item);

                    }
                    LoadSearchWindow();
                }
                );
        }
        public void LoadWindow()
        {
            Stocks = new ObservableCollection<Stock_table>(DataProvider.Ins.Db.Stock_table.Where(x => x.LibratyID == Employ_Data.Instance.LibratyID));
            Stocks_Search = new ObservableCollection<Stock_table>(DataProvider.Ins.Db.Stock_table.Where(x => x.LibratyID == Employ_Data.Instance.LibratyID));
            Title = string.Empty;
            Selected_Stock = null;
            Value = 0;
        }
        public void LoadSearchWindow()
        {
            Stocks = new ObservableCollection<Stock_table>(DataProvider.Ins.Db.Stock_table.Where(x => x.LibratyID == Employ_Data.Instance.LibratyID));
            Title = string.Empty;
            Selected_Stock = null;
            Value = 0;
        }

    }
}

