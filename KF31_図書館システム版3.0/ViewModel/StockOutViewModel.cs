using KF31_図書館システム版3._0.Main_Login_Model;
using KF31_図書館システム版3._0.Model;
using KF31_図書館システム版3._0.Output_Model;
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
    public class StockOutViewModel : BaseViewModel
    {
        //データテーブル
        private ObservableCollection<Book_table> _Books { get; set; }
        public ObservableCollection<Book_table> Books { get => _Books; set { _Books = value; OnPropertyChanged(); } }
        private ObservableCollection<Libraty_table> _libraty { get; set; }
        public ObservableCollection<Libraty_table> Libraty { get => _libraty; set { _libraty = value; OnPropertyChanged(); } }
        private ObservableCollection<Stock_table> _Stocks { get; set; }
        public ObservableCollection<Stock_table> Stocks { get => _Stocks; set { _Stocks = value; OnPropertyChanged(); } }

        private ObservableCollection<Status_table> _Status { get; set; }
        public ObservableCollection<Status_table> Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }
        private ObservableCollection<StockOut_table> _StockOut { get; set; }
        public ObservableCollection<StockOut_table> StockOut { get => _StockOut; set { _StockOut = value; OnPropertyChanged(); } }
        private ObservableCollection<StockOut_Detail_table> _StockOutDetailList { get; set; }
        public ObservableCollection<StockOut_Detail_table> StockOutDetailList { get => _StockOutDetailList; set { _StockOutDetailList = value; OnPropertyChanged(); } }
        private ObservableCollection<StockOut_Detail_table> _StockOutDetail { get; set; }
        public ObservableCollection<StockOut_Detail_table> StockOutDetail { get => _StockOutDetail; set { _StockOutDetail = value; OnPropertyChanged(); } }
        private ObservableCollection<StockOut_table> _StockOutSearch { get; set; }
        public ObservableCollection<StockOut_table> StockOutSearch { get => _StockOutSearch; set { _StockOutSearch = value; OnPropertyChanged(); } }



        //プロパティ
        private StockOut_table _SelectStockOut { get; set; }
        public StockOut_table SelectStockOut
        {
            get => _SelectStockOut; set
            {
                _SelectStockOut = value;
                IsSelectStockInSelected = _SelectStockOut == null ? false : true;
                OnPropertyChanged();
                if (_SelectStockOut != null)
                {
                    SelectStatus = _SelectStockOut.Status_table;
                    IsSelectStockInSelected = SelectStatus.statusID == "SKR02" ? false : true;
                    IsSelectStockBookSelected = SelectStockOut.statusID == "SKR02" ? false : true;

                    StockOutDetail.Clear();
                    var Detail_List = StockOutDetailList.Where(x => x.StockOut_ID == SelectStockOut.StockOut_ID);
                    foreach (var item in Detail_List)
                    {
                        StockOutDetail.Add(item);
                    }
                    if (SelectStockOut.statusID == "SKR02")
                    {
                        SelectLibraty = SelectStockOut.Libraty_table;
                        IsSelectStatusSelected = false;
                    }
                    else
                    {
                        //IsSelectStatusSelected = SelectStatus.statusID == "SKR02" ? false : true;

                        SelectLibraty = null;
                    }
                }
            }
        }
        private StockOut_table _SelectStockOut_Search { get; set; }
        public StockOut_table SelectStockOut_Search
        {
            get => _SelectStockOut_Search; set
            {
                _SelectStockOut_Search = value;
                OnPropertyChanged();
            }
        }

        private StockOut_table _SelectItemList { get; set; }
        public StockOut_table SelectItemList
        {
            get => _SelectItemList; set
            {
                _SelectItemList = value;
                OnPropertyChanged();
                if (SelectItemList != null)
                {
                    SelectStatus = SelectItemList.Status_table;
                    SelectStockOut_Search = SelectItemList;
                    SelectLibraty = SelectItemList.Libraty_table;
                    StockOutDetail.Clear();
                    var Detail_List = StockOutDetailList.Where(x => x.StockOut_ID == SelectItemList.StockOut_ID);
                    foreach (var item in Detail_List)
                    {
                        StockOutDetail.Add(item);
                    }
                }
            }
        }
        private Status_table _SelectStatus { get; set; }
        public Status_table SelectStatus
        {
            get => _SelectStatus;
            set
            {

                _SelectStatus = value; OnPropertyChanged();
                IsSelectStatusSelected = _SelectStatus != DataProvider.Ins.Db.Status_table.FirstOrDefault(x => x.statusID == "SKR02") ? false : true;

            }
        }
        private Stock_table _SelectBook { get; set; }
        public Stock_table SelectBook
        {
            get => _SelectBook;
            set
            {
                _SelectBook = value;
                IsSelectStockBookSelected = _SelectStockOut == null ? false : true;
                OnPropertyChanged();

                if (SelectBook != null)
                {
                    Title = SelectBook.Book_table.Book_title;
                    var stockitem = DataProvider.Ins.Db.Stock_table.Where(x => x.BookID == SelectBook.BookID && x.LibratyID == Employ_Data.Instance.LibratyID).FirstOrDefault();
                    if(stockitem != null)
                    {
                        MaxOutValue = stockitem.Quantity;
                    }
                    var checkitem = DataProvider.Ins.Db.StockOut_Detail_table.FirstOrDefault(x => x.BookID == SelectBook.BookID && x.StockOut_ID == SelectStockOut.StockOut_ID);
                    if (checkitem != null)
                    {
                        OutValue = checkitem.StockOut_Quantity.Value;
                    }
                    else
                        OutValue = 0;
                }
            }
        }
        private Libraty_table _SelectLibraty { get; set; }
        public Libraty_table SelectLibraty
        {
            get => _SelectLibraty;
            set
            {
                _SelectLibraty = value;
                OnPropertyChanged();

            }
        }

        private string _Title { get; set; }
        public string Title { get => _Title; set { _Title = value; OnPropertyChanged(); } }
        private int _OutValue { get; set; }
        public int OutValue { get => _OutValue; set { _OutValue = value; OnPropertyChanged(); } }

        private bool _isSelectStockInSelected;
        public bool IsSelectStockInSelected
        {
            get => _isSelectStockInSelected;
            set
            {
                if (_isSelectStockInSelected != value)
                {
                    _isSelectStockInSelected = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsEnabled_Command)); //状態更新
                }

            }
        }

        private bool _isSelectStockBookSelected;
        public bool IsSelectStockBookSelected
        {
            get => _isSelectStockBookSelected;
            set
            {
                if (_isSelectStockBookSelected != value)
                {
                    _isSelectStockBookSelected = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsEnabledInValue_Command)); //状態更新
                }

            }
        }
        private bool _isSelectStatus_Selected;
        public bool IsSelectStatusSelected
        {
            get => _isSelectStatus_Selected;
            set
            {
                if (_isSelectStatus_Selected != value)
                {
                    _isSelectStatus_Selected = value;
                    SelectBook = null;
                    Title = string.Empty;
                    OutValue = 0;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsEnabledLibraty_Command)); //状態更新
                }

            }
        }
        private int? _MaxOutValue { get; set; }
        public int? MaxOutValue { get => _MaxOutValue; set { _MaxOutValue = value;OnPropertyChanged(); } }
        //Window開くのコマンド
        public ICommand Add_WindowCommand { get; set; }
        public ICommand ListAndSearchWindowCommand { get; set; }
        public ICommand BackMain_WindowCommand { get; set; }

        //機能処理のコマンド
        public ICommand Add_OutputDetailCommand { get; set; }
        public ICommand Add_OutputCommand { get; set; }
        public ICommand Delete_Command { get; set; }
        public ICommand UpdateStatus_Command { get; set; }
        public ICommand Update_OutputDetailCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        //✓コマンド
        private bool _IsEnabled_Command;
        public bool IsEnabled_Command
        {
            get => IsSelectStockInSelected ? true : false;
            set
            {
                if (_IsEnabled_Command != value)
                {
                    _IsEnabled_Command = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _IsEnabledInvalue_Command;
        public bool IsEnabledInValue_Command
        {
            get => IsSelectStockBookSelected ? true : false;
            set
            {
                if (_IsEnabledInvalue_Command != value)
                {
                    _IsEnabledInvalue_Command = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool _IsEnabledLibraty_Command;
        public bool IsEnabledLibraty_Command
        {
            get => IsSelectStatusSelected ? true : false;
            set
            {
                if (_IsEnabledLibraty_Command != value)
                {
                    _IsEnabledLibraty_Command = value;
                    OnPropertyChanged();
                }
            }
        }
        public StockOutViewModel()
        {
            LoadWindow();
            Add_WindowCommand = new RelayCommand<Window>((p) => { return true; },
                (p) =>
                {
                    LoadWindow();
                    AddOutput_Window addoutput = new AddOutput_Window();
                    p.Close();
                    addoutput.ShowDialog();
                });
            BackMain_WindowCommand = new RelayCommand<Window>((p) => { return true; },
                (p) =>
                {
                    LoadWindow();
                    MainWindow back = new MainWindow();
                    p.Close();
                    back.ShowDialog();
                });
            ListAndSearchWindowCommand = new RelayCommand<Window>((p) => { return true; },
                (p) =>
                {
                    LoadWindow();
                    Output_ListAndSearch_Window list = new Output_ListAndSearch_Window();
                    p.Close();
                    list.ShowDialog();
                });

            ClearCommand = new RelayCommand<Window>((p) => { return true; },
                (p) =>
                {
                    if (SelectStockOut != null)
                    {
                        var checkStockOut = DataProvider.Ins.Db.StockOut_Detail_table.Where(x => x.StockOut_ID == SelectStockOut.StockOut_ID).Count();
                        if (checkStockOut > 0)
                        {
                            LoadDetailWindow();
                            LoadWindow();
                        }
                        else
                        {
                            var stockOut = DataProvider.Ins.Db.StockOut_table.FirstOrDefault(x => x.StockOut_ID == SelectStockOut.StockOut_ID);
                            DataProvider.Ins.Db.StockOut_table.Remove(stockOut);
                            DataProvider.Ins.Db.SaveChanges();
                            LoadWindow();
                        }
                    }
                });
            Add_OutputCommand = new RelayCommand<Window>(
           (p) =>
           {
               if (SelectStockOut != null)
               {
                   return false;
               }
               return true;
           },
           (p) =>
           {
               var stockOutID = "";
               var in_count = DataProvider.Ins.Db.StockOut_table.Count();
               if (in_count > 0)
               {
                   if (in_count < 9)
                   {
                       stockOutID = "SK" + DateTime.Now.Year.ToString() + "M" + DateTime.Now.Month.ToString() + "00" + (in_count + 1).ToString();

                   }
                   else
                   {
                       stockOutID = "SK" + DateTime.Now.Year.ToString() + "M" + DateTime.Now.Month.ToString() + "0" + (in_count + 1).ToString();

                   }
               }
               else
               {
                   stockOutID = "SK" + DateTime.Now.Year.ToString() + "M" + DateTime.Now.Month.ToString() + "001";
               }
               var StockOut_item = new StockOut_table()
               {
                   StockOut_ID = stockOutID,
                   statusID = "YT01",
                   stockOut_Count = 0,
                   stockOut_Date = DateTime.Now
               };
               DataProvider.Ins.Db.StockOut_table.Add(StockOut_item);
               DataProvider.Ins.Db.SaveChanges();
               LoadWindow();
               SelectStockOut = DataProvider.Ins.Db.StockOut_table.FirstOrDefault(x => x.StockOut_ID == stockOutID);



           });
            Add_OutputDetailCommand = new RelayCommand<Window>(
               (p) =>
               {
                   if (SelectStockOut == null || SelectBook == null || OutValue == 0 || string.IsNullOrEmpty(Title) || (SelectStatus.statusID == "SKR02"))
                   {
                       return false;
                   }
                   var checkitem = DataProvider.Ins.Db.StockOut_Detail_table.FirstOrDefault(x => x.BookID == SelectBook.BookID && x.StockOut_ID == SelectStockOut.StockOut_ID);
                   if (checkitem != null)
                   {
                       return false;
                   }
                   return true;
               },
               (p) =>
               {
                   var Detail_ItemID = "";
                   var detailcount = DataProvider.Ins.Db.StockOut_Detail_table.Where(x => x.StockOut_ID == SelectStockOut.StockOut_ID).Count();
                   var stockOut_item = DataProvider.Ins.Db.StockOut_table.FirstOrDefault(x => x.StockOut_ID == SelectStockOut.StockOut_ID);

                   Detail_ItemID = SelectStockOut.StockOut_ID.Substring(4) + "MD" + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + (detailcount + 1).ToString();

                   var Detail_Item = new StockOut_Detail_table()
                   {
                       StockOutDetail_ID = Detail_ItemID,
                       StockOut_ID = SelectStockOut.StockOut_ID,
                       BookID = SelectBook.BookID,
                       EmployID = Employ_Data.Instance.Em_ID,
                       StockOut_Quantity = OutValue,

                   };
                   stockOut_item.stockOut_Date = DateTime.Now;
                   stockOut_item.stockOut_Count = stockOut_item.stockOut_Count + Detail_Item.StockOut_Quantity;
                   DataProvider.Ins.Db.StockOut_Detail_table.Add(Detail_Item);
                   DataProvider.Ins.Db.SaveChanges();

                   LoadDetailWindow();

               });
            Update_OutputDetailCommand = new RelayCommand<Window>(
                (p) =>
                {
                    if (SelectStockOut == null || SelectBook == null || OutValue == 0 || string.IsNullOrEmpty(Title) || (SelectStatus.statusID == "SKR02"))
                    {
                        return false;
                    }
                    var checkitem = DataProvider.Ins.Db.StockOut_Detail_table.FirstOrDefault(x => x.BookID == SelectBook.BookID && x.StockOut_ID == SelectStockOut.StockOut_ID);
                    if (checkitem == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (checkitem.StockOut_Quantity == OutValue)
                        {
                            return false;
                        }
                    }
                    return true;
                },
                (p) =>
                {

                    var detail_item = DataProvider.Ins.Db.StockOut_Detail_table.FirstOrDefault(x => x.BookID == SelectBook.BookID && x.StockOut_ID == SelectStockOut.StockOut_ID);
                    var moto_quantity = detail_item.StockOut_Quantity;
                    var stockOut_item = DataProvider.Ins.Db.StockOut_table.FirstOrDefault(x => x.StockOut_ID == SelectStockOut.StockOut_ID);
                    detail_item.StockOut_Quantity = OutValue;
                    detail_item.EmployID = Employ_Data.Instance.Em_ID;
                    stockOut_item.stockOut_Count = stockOut_item.stockOut_Count - moto_quantity + OutValue;
                    stockOut_item.stockOut_Date = DateTime.Now;
                    DataProvider.Ins.Db.SaveChanges();
                    LoadDetailWindow();

                });
            Delete_Command = new RelayCommand<Window>(
               (p) =>
               {

                   if (SelectStockOut == null || SelectBook == null || OutValue == 0 || string.IsNullOrEmpty(Title) || (SelectStatus.statusID == "SKR02"))
                   {
                       return false;
                   }
                   var checkitem = DataProvider.Ins.Db.StockOut_Detail_table.FirstOrDefault(x => x.BookID == SelectBook.BookID && x.StockOut_ID == SelectStockOut.StockOut_ID);
                   if (checkitem == null)
                   {
                       return false;
                   }
                   else
                   {
                       if (checkitem.StockOut_Quantity != OutValue)
                       {
                           return false;
                       }
                   }
                   return true;
               },
               (p) =>
               {
                   var checkitem = DataProvider.Ins.Db.StockOut_Detail_table.FirstOrDefault(x => x.BookID == SelectBook.BookID && x.StockOut_ID == SelectStockOut.StockOut_ID);
                   var stockOut_item = DataProvider.Ins.Db.StockOut_table.FirstOrDefault(x => x.StockOut_ID == SelectStockOut.StockOut_ID);
                   stockOut_item.stockOut_Date = DateTime.Now;
                   stockOut_item.stockOut_Count = stockOut_item.stockOut_Count - checkitem.StockOut_Quantity;
                   DataProvider.Ins.Db.StockOut_Detail_table.Remove(checkitem);
                   DataProvider.Ins.Db.SaveChanges();
                   LoadDetailWindow();
               });
            UpdateStatus_Command = new RelayCommand<Window>(
              (p) =>
              {
                  if (SelectStockOut == null)
                  {
                      return false;
                  }
                  var checkitem = DataProvider.Ins.Db.StockOut_table.FirstOrDefault(x => x.StockOut_ID == SelectStockOut.StockOut_ID && x.statusID == SelectStatus.statusID);
                  if (checkitem != null)
                  {
                      return false;
                  }
                  return true;
              },
              (p) =>
              {
                  if (SelectStatus.statusID == "SKR02")
                  {
                      var stock_Out = DataProvider.Ins.Db.StockOut_table.FirstOrDefault(x => x.StockOut_ID == SelectStockOut.StockOut_ID);
                      var checkStockOut = DataProvider.Ins.Db.StockOut_Detail_table.Where(x => x.StockOut_ID == SelectStockOut.StockOut_ID).Count();
                      if (checkStockOut == 0)
                      {
                          MessageBox.Show("選択された出庫IDは出庫商品が登録されていないので、\n状態更新できません！", "報告",
                              MessageBoxButton.OK, MessageBoxImage.Information);
                          return;
                      }
                      if (SelectLibraty == null)
                      {
                          MessageBox.Show("図書館IDが選択されていません!", "報告",
                          MessageBoxButton.OK, MessageBoxImage.Information);
                          return;
                      }
                      var result = MessageBox.Show("確認してから、追加できません。\n確認してもよろしいでしょうか？", "確認",
                          MessageBoxButton.OKCancel, MessageBoxImage.Question);
                      if (result == MessageBoxResult.Cancel)
                      {
                          return;
                      }
                      var StockOut_List = DataProvider.Ins.Db.StockOut_Detail_table.Where(x => x.StockOut_ID == SelectStockOut.StockOut_ID).ToList();
                      foreach (var stockOut in StockOut_List)
                      {
                          var stock = DataProvider.Ins.Db.Stock_table.FirstOrDefault(x => x.BookID == stockOut.BookID && x.LibratyID == Employ_Data.Instance.LibratyID);
                          if (stock != null)
                          {
                              stock.Quantity = stock.Quantity - stockOut.StockOut_Quantity;
                          }


                      }
                      stock_Out.statusID = SelectStatus.statusID;
                      stock_Out.LibratyID = SelectLibraty.LibratyID;
                      stock_Out.stockOut_Date = DateTime.Now;
                      DataProvider.Ins.Db.SaveChanges();
                      LoadWindow();

                  }
                  else
                  {

                      if (SelectStatus.statusID == "KS01")
                      {
                          var stock_Out = DataProvider.Ins.Db.StockOut_table.FirstOrDefault(x => x.StockOut_ID == SelectStockOut.StockOut_ID);
                          var checkStockOut = DataProvider.Ins.Db.StockOut_Detail_table.Where(x => x.StockOut_ID == SelectStockOut.StockOut_ID).Count();
                          if (checkStockOut == 0)
                          {
                              DataProvider.Ins.Db.StockOut_table.Remove(stock_Out);
                          }
                          else
                          {
                              var result = MessageBox.Show("確認してから、更新できません。\n削除してもよろしいでしょうか？", "確認",
                             MessageBoxButton.OKCancel, MessageBoxImage.Question);
                              if (result == MessageBoxResult.Cancel)
                              {
                                  return;
                              }
                              var StockOut_List = DataProvider.Ins.Db.StockOut_Detail_table.Where(x => x.StockOut_ID == SelectStockOut.StockOut_ID).ToList();
                              foreach (var stockOut in StockOut_List)
                              {
                                  DataProvider.Ins.Db.StockOut_Detail_table.Remove(stockOut);

                              }
                              DataProvider.Ins.Db.StockOut_table.Remove(stock_Out);
                          }


                          DataProvider.Ins.Db.SaveChanges();
                          LoadWindow();

                      }
                  }
              });

            SearchCommand = new RelayCommand<Window>((p) =>
            {
                if (SelectStockOut_Search == null && SelectStatus == null && SelectLibraty == null)
                {
                    return false;
                }
                else
                    return true;
            },
            (p) =>
            {
                StockOutSearch.Clear();
                var SearchList = StockOut.Where(x =>
                (SelectStockOut_Search == null || x.StockOut_ID == SelectStockOut_Search.StockOut_ID)
                && (SelectStatus == null || x.statusID == SelectStatus.statusID)
                && (SelectLibraty == null || x.LibratyID == SelectLibraty.LibratyID)
                ).ToList();
                foreach (var item in SearchList)
                {
                    StockOutSearch.Add(item);

                }
                LoadSearchWindow();
            });
        }
        public void LoadSearchWindow()
        {
            StockOut = new ObservableCollection<StockOut_table>(DataProvider.Ins.Db.StockOut_table);
            Status = new ObservableCollection<Status_table>(DataProvider.Ins.Db.Status_table.Where(x => x.statusID == "YT01" || x.statusID == "SKR02" || x.statusID == "KS01"));

            SelectLibraty = null;
            SelectStockOut_Search = null;
            SelectStatus = null;
            StockOutDetail.Clear();

        }
        public void LoadWindow()
        {
            Status = new ObservableCollection<Status_table>(DataProvider.Ins.Db.Status_table.Where(x => x.statusID == "YT01" || x.statusID == "SKR02" || x.statusID == "KS01"));
            StockOut = new ObservableCollection<StockOut_table>(DataProvider.Ins.Db.StockOut_table);
            StockOutSearch = new ObservableCollection<StockOut_table>(DataProvider.Ins.Db.StockOut_table);
            Books = new ObservableCollection<Book_table>(DataProvider.Ins.Db.Book_table);
            StockOutDetailList = new ObservableCollection<StockOut_Detail_table>(DataProvider.Ins.Db.StockOut_Detail_table);
            StockOutDetail = new ObservableCollection<StockOut_Detail_table>(DataProvider.Ins.Db.StockOut_Detail_table);
            Libraty = new ObservableCollection<Libraty_table>(DataProvider.Ins.Db.Libraty_table.Where(x => x.LibratyID != Employ_Data.Instance.LibratyID));
            Stocks = new ObservableCollection<Stock_table>(DataProvider.Ins.Db.Stock_table.Where(x => x.LibratyID == Employ_Data.Instance.LibratyID));

            StockOutDetail.Clear();
            SelectStockOut_Search = null;
            SelectStockOut = null;
            SelectBook = null;
            SelectStatus = null;
            SelectLibraty = null;
            Title = string.Empty;
            OutValue = 0;

        }
        public void LoadDetailWindow()
        {
            Employ_Data.Instance.CheckStatusYoyaku();
            Status = new ObservableCollection<Status_table>(DataProvider.Ins.Db.Status_table.Where(x => x.statusID == "YT01" || x.statusID == "SKR02" || x.statusID == "KS01"));
            StockOut = new ObservableCollection<StockOut_table>(DataProvider.Ins.Db.StockOut_table);
            Books = new ObservableCollection<Book_table>(DataProvider.Ins.Db.Book_table);
            StockOutDetailList = new ObservableCollection<StockOut_Detail_table>(DataProvider.Ins.Db.StockOut_Detail_table);

            StockOutDetail.Clear();
            var Detail_List = StockOutDetailList.Where(x => x.StockOut_ID == SelectStockOut.StockOut_ID);
            foreach (var item in Detail_List)
            {
                StockOutDetail.Add(item);
            }
            SelectBook = null;
            Title = string.Empty;
            OutValue = 0;
            IsSelectStockBookSelected = false;

        }


    }
}