using KF31_図書館システム版3._0.Input_Model;
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
    public class StockInViewModel : BaseViewModel
    {
        //データテーブル
        private ObservableCollection<Book_table> _Books { get; set; }
        public ObservableCollection<Book_table> Books { get => _Books; set { _Books = value; OnPropertyChanged(); } }
        private ObservableCollection<Status_table> _Status { get; set; }
        public ObservableCollection<Status_table> Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }
        private ObservableCollection<StockIN_Table> _StockIn { get; set; }
        public ObservableCollection<StockIN_Table> StockIn { get => _StockIn; set { _StockIn = value; OnPropertyChanged(); } }
        private ObservableCollection<StockIn_Detail_table> _StockInDetailList { get; set; }
        public ObservableCollection<StockIn_Detail_table> StockInDetailList { get => _StockInDetailList; set { _StockInDetailList = value; OnPropertyChanged(); } }
        private ObservableCollection<StockIn_Detail_table> _StockInDetail { get; set; }
        public ObservableCollection<StockIn_Detail_table> StockInDetail { get => _StockInDetail; set { _StockInDetail = value; OnPropertyChanged(); } }
        private ObservableCollection<StockIN_Table> _StockInSearch { get; set; }
        public ObservableCollection<StockIN_Table> StockInSearch { get => _StockInSearch; set { _StockInSearch = value; OnPropertyChanged(); } }



        //プロパティ
        private StockIN_Table _SelectStockIn { get; set; }
        public StockIN_Table SelectStockIn
        {
            get => _SelectStockIn; set
            {
                _SelectStockIn = value;
                IsSelectStockInSelected = _SelectStockIn == null ? false : true;
                if (_SelectStockIn == null)
                {
                    IsSelectStockInSelected = false;

                }
                else
                    IsSelectStockInSelected = true;
                OnPropertyChanged();
                if (_SelectStockIn != null)
                {
                    SelectStatus = _SelectStockIn.Status_table;
                    IsSelectStockInSelected = SelectStatus.statusID == "NKR01" ? false : true;
                    StockInDetail.Clear();
                    var Detail_List = StockInDetailList.Where(x => x.StockIn_ID == SelectStockIn.StockIN_ID);
                    foreach (var item in Detail_List)
                    {
                        StockInDetail.Add(item);
                    }

                }
            }
        }
        private StockIN_Table _SelectItemList { get; set; }
        public StockIN_Table SelectItemList
        {
            get => _SelectItemList; set
            {
                _SelectItemList = value;
                OnPropertyChanged();
                if (SelectItemList != null)
                {
                    SelectStatus = SelectItemList.Status_table;
                    SelectStockIn = SelectItemList;

                    StockInDetail.Clear();
                    var Detail_List = StockInDetailList.Where(x => x.StockIn_ID == SelectStockIn.StockIN_ID);
                    foreach (var item in Detail_List)
                    {
                        StockInDetail.Add(item);
                    }
                }
            }
        }
        private Status_table _SelectStatus { get; set; }
        public Status_table SelectStatus { get => _SelectStatus; set { _SelectStatus = value; OnPropertyChanged(); } }
        private Book_table _SelectBook { get; set; }
        public Book_table SelectBook
        {
            get => _SelectBook;
            set
            {
                _SelectBook = value;
                IsSelectStockBookSelected = _SelectStockIn == null ? false : true;
                OnPropertyChanged();

                if (SelectBook != null)
                {
                    Title = SelectBook.Book_title;
                    var checkitem = DataProvider.Ins.Db.StockIn_Detail_table.FirstOrDefault(x => x.BookID == SelectBook.BookID && x.StockIn_ID == SelectStockIn.StockIN_ID);
                    if (checkitem != null)
                    {
                        InValue = checkitem.StockIn_Quantity.Value;
                    }
                    else
                        InValue = 0;
                }
            }
        }
        private StockIn_Detail_table _SelectItem { get; set; }
        public StockIn_Detail_table SelectItem
        {
            get => _SelectItem;
            set
            {
                _SelectItem = value;
                OnPropertyChanged();

                if (SelectItem != null)
                {
                    SelectBook = SelectItem.Book_table;

                }
            }
        }

        private string _Title { get; set; }
        public string Title { get => _Title; set { _Title = value; OnPropertyChanged(); } }
        private int _InValue { get; set; }
        public int InValue { get => _InValue; set { _InValue = value; OnPropertyChanged(); } }

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
        //Window開くのコマンド
        public ICommand Add_WindowCommand { get; set; }
        public ICommand ListAndSearchWindowCommand { get; set; }
        public ICommand BackMain_WindowCommand { get; set; }

        //機能処理のコマンド
        public ICommand Add_InputDetailCommand { get; set; }
        public ICommand Add_InputCommand { get; set; }
        public ICommand Delete_Command { get; set; }
        public ICommand UpdateStatus_Command { get; set; }
        public ICommand Update_InputDetailCommand { get; set; }
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



        public StockInViewModel()
        {
            LoadWindow();

            ClearCommand = new RelayCommand<Window>((p) => { return true; },
                (p) =>
                {
                    if (SelectStockIn != null)
                    {
                        var checkStockIn = DataProvider.Ins.Db.StockIn_Detail_table.Where(x => x.StockIn_ID == SelectStockIn.StockIN_ID).Count();
                        if (checkStockIn > 0)
                        {
                            LoadDetailWindow();
                            LoadWindow();
                        }
                        else
                        {
                            var stockIn = DataProvider.Ins.Db.StockIN_Table.FirstOrDefault(x => x.StockIN_ID == SelectStockIn.StockIN_ID);
                            DataProvider.Ins.Db.StockIN_Table.Remove(stockIn);
                            DataProvider.Ins.Db.SaveChanges();
                            LoadWindow();
                        }
                    }
                });
            Add_WindowCommand = new RelayCommand<Window>((p) => { return true; },
                (p) =>
                {
                    LoadWindow();
                    Add_InputDetailWindow addinput = new Add_InputDetailWindow();
                    p.Close();
                    addinput.ShowDialog();
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
                    input_ListandSearch_Window list = new input_ListandSearch_Window();
                    p.Close();
                    list.ShowDialog();
                });

            Add_InputDetailCommand = new RelayCommand<Window>(
                (p) =>
                {
                    if (SelectStockIn == null || SelectBook == null || InValue == 0 || string.IsNullOrEmpty(Title) || (SelectStatus.statusID == "NKR01"))
                    {
                        return false;
                    }
                    var checkitem = DataProvider.Ins.Db.StockIn_Detail_table.FirstOrDefault(x => x.BookID == SelectBook.BookID && x.StockIn_ID == SelectStockIn.StockIN_ID);
                    if (checkitem != null)
                    {
                        return false;
                    }
                    return true;
                },
                (p) =>
                {
                    var Detail_ItemID = "";
                    var detailcount = DataProvider.Ins.Db.StockIn_Detail_table.Where(x => x.StockIn_ID == SelectStockIn.StockIN_ID).Count();
                    var stockIn_item = DataProvider.Ins.Db.StockIN_Table.FirstOrDefault(x => x.StockIN_ID == SelectStockIn.StockIN_ID);

                    Detail_ItemID = SelectStockIn.StockIN_ID.Substring(4) + "MD" + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + (detailcount + 1).ToString();

                    var Detail_Item = new StockIn_Detail_table()
                    {
                        StockInDetailID = Detail_ItemID,
                        StockIn_ID = SelectStockIn.StockIN_ID,
                        BookID = SelectBook.BookID,
                        EmployID = Employ_Data.Instance.Em_ID,
                        StockIn_Quantity = InValue
                    };
                    stockIn_item.stockIn_Date = DateTime.Now;
                    stockIn_item.stockIn_Count = stockIn_item.stockIn_Count + Detail_Item.StockIn_Quantity;
                    DataProvider.Ins.Db.StockIn_Detail_table.Add(Detail_Item);
                    DataProvider.Ins.Db.SaveChanges();
                    LoadDetailWindow();

                });
            Update_InputDetailCommand = new RelayCommand<Window>(
                (p) =>
                {
                    if (SelectStockIn == null || SelectBook == null || InValue == 0 || string.IsNullOrEmpty(Title) || (SelectStatus.statusID == "NKR01"))
                    {
                        return false;
                    }
                    var checkitem = DataProvider.Ins.Db.StockIn_Detail_table.FirstOrDefault(x => x.BookID == SelectBook.BookID && x.StockIn_ID == SelectStockIn.StockIN_ID);
                    if (checkitem == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (checkitem.StockIn_Quantity == InValue)
                        {
                            return false;
                        }
                    }
                    return true;
                },
                (p) =>
                {

                    var detail_item = DataProvider.Ins.Db.StockIn_Detail_table.FirstOrDefault(x => x.BookID == SelectBook.BookID && x.StockIn_ID == SelectStockIn.StockIN_ID);
                    var moto_quantity = detail_item.StockIn_Quantity;
                    var stockIn_item = DataProvider.Ins.Db.StockIN_Table.FirstOrDefault(x => x.StockIN_ID == SelectStockIn.StockIN_ID);
                    detail_item.StockIn_Quantity = InValue;
                    detail_item.EmployID = Employ_Data.Instance.Em_ID;
                    stockIn_item.stockIn_Count = stockIn_item.stockIn_Count - moto_quantity + InValue;
                    stockIn_item.stockIn_Date = DateTime.Now;
                    DataProvider.Ins.Db.SaveChanges();

                    LoadDetailWindow();

                });
            Delete_Command = new RelayCommand<Window>(
               (p) =>
               {

                   if (SelectStockIn == null || SelectBook == null || InValue == 0 || string.IsNullOrEmpty(Title) || (SelectStatus.statusID == "NKR01"))
                   {
                       return false;
                   }
                   var checkitem = DataProvider.Ins.Db.StockIn_Detail_table.FirstOrDefault(x => x.BookID == SelectBook.BookID && x.StockIn_ID == SelectStockIn.StockIN_ID);
                   if (checkitem == null)
                   {
                       return false;
                   }
                   else
                   {
                       if (checkitem.StockIn_Quantity != InValue)
                       {
                           return false;
                       }
                   }
                   return true;
               },
               (p) =>
               {
                   var checkitem = DataProvider.Ins.Db.StockIn_Detail_table.FirstOrDefault(x => x.BookID == SelectBook.BookID && x.StockIn_ID == SelectStockIn.StockIN_ID);
                   var stockIn_item = DataProvider.Ins.Db.StockIN_Table.FirstOrDefault(x => x.StockIN_ID == SelectStockIn.StockIN_ID);
                   stockIn_item.stockIn_Date = DateTime.Now;
                   stockIn_item.stockIn_Count = stockIn_item.stockIn_Count - checkitem.StockIn_Quantity;
                   DataProvider.Ins.Db.StockIn_Detail_table.Remove(checkitem);
                   DataProvider.Ins.Db.SaveChanges();

                   LoadDetailWindow();
               });
            UpdateStatus_Command = new RelayCommand<Window>(
              (p) =>
              {
                  if (SelectStockIn == null)
                  {
                      return false;
                  }
                  var checkitem = DataProvider.Ins.Db.StockIN_Table.FirstOrDefault(x => x.StockIN_ID == SelectStockIn.StockIN_ID && x.statusID == SelectStatus.statusID);
                  if (checkitem != null)
                  {
                      return false;
                  }
                  return true;
              },
              (p) =>
              {
                  if (SelectStatus.statusID == "NKR01")
                  {
                      var stock_In = DataProvider.Ins.Db.StockIN_Table.FirstOrDefault(x => x.StockIN_ID == SelectStockIn.StockIN_ID);
                      var checkStockIn = DataProvider.Ins.Db.StockIn_Detail_table.Where(x => x.StockIn_ID == SelectStockIn.StockIN_ID).Count();
                      if (checkStockIn == 0)
                      {
                          MessageBox.Show("選択された入庫IDは入庫商品が登録されていないので、\n状態更新できません！", "報告",
                              MessageBoxButton.OK, MessageBoxImage.Information);
                          return;
                      }

                      var result = MessageBox.Show("確認してから、追加できません。\n確認してもよろしいでしょうか？", "確認",
                          MessageBoxButton.OKCancel, MessageBoxImage.Question);
                      if (result == MessageBoxResult.Cancel)
                      {
                          return;
                      }
                      var StockIn_List = DataProvider.Ins.Db.StockIn_Detail_table.Where(x => x.StockIn_ID == SelectStockIn.StockIN_ID).ToList();
                      foreach (var stockIn in StockIn_List)
                      {
                          var stock = DataProvider.Ins.Db.Stock_table.FirstOrDefault(x => x.BookID == stockIn.BookID && x.LibratyID == Employ_Data.Instance.LibratyID);
                          if (stock != null)
                          {
                              stock.Quantity = stock.Quantity + stockIn.StockIn_Quantity;
                          }
                          else
                          {
                              var stockID = "";
                              var stockCount = DataProvider.Ins.Db.Stock_table.Where(x => x.LibratyID == Employ_Data.Instance.LibratyID).Count();
                              stockID = "ZK" + Employ_Data.Instance.LibratyID + (stockCount + 1).ToString();
                              var stockItem = new Stock_table()
                              {
                                  StockID = stockID,
                                  BookID = stockIn.BookID,
                                  Quantity = stockIn.StockIn_Quantity,
                                  LibratyID = Employ_Data.Instance.LibratyID
                              };
                              DataProvider.Ins.Db.Stock_table.Add(stockItem);
                          }

                      }
                      stock_In.statusID = SelectStatus.statusID;
                      stock_In.stockIn_Date = DateTime.Now;
                      DataProvider.Ins.Db.SaveChanges();

                      LoadWindow();

                  }
                  else
                  {

                      if (SelectStatus.statusID == "KS01")
                      {
                          var stock_In = DataProvider.Ins.Db.StockIN_Table.FirstOrDefault(x => x.StockIN_ID == SelectStockIn.StockIN_ID);
                          var checkStockIn = DataProvider.Ins.Db.StockIn_Detail_table.Where(x => x.StockIn_ID == SelectStockIn.StockIN_ID).Count();
                          if (checkStockIn == 0)
                          {
                              DataProvider.Ins.Db.StockIN_Table.Remove(stock_In);
                          }
                          else
                          {
                              var result = MessageBox.Show("確認してから、更新できません。\n削除してもよろしいでしょうか？", "確認",
                             MessageBoxButton.OKCancel, MessageBoxImage.Question);
                              if (result == MessageBoxResult.Cancel)
                              {
                                  return;
                              }
                              var StockIn_List = DataProvider.Ins.Db.StockIn_Detail_table.Where(x => x.StockIn_ID == SelectStockIn.StockIN_ID).ToList();
                              foreach (var stockIn in StockIn_List)
                              {
                                  DataProvider.Ins.Db.StockIn_Detail_table.Remove(stockIn);

                              }
                              DataProvider.Ins.Db.StockIN_Table.Remove(stock_In);
                          }


                          DataProvider.Ins.Db.SaveChanges();

                          LoadWindow();
                          DataProvider.Ins.Db.Dispose();

                      }
                  }
              });
            SearchCommand = new RelayCommand<Window>(
              (p) =>
              {
                  if (SelectStockIn == null && SelectStatus == null)
                  {
                      return false;
                  }
                  return true;
              },
              (p) =>
              {
                  StockInSearch.Clear();
                  var SearchList = StockIn.Where(x =>
                  (SelectStockIn == null || x.StockIN_ID == SelectStockIn.StockIN_ID)
                  && (SelectStatus == null || x.statusID == SelectStatus.statusID)
                  ).ToList();
                  foreach (var item in SearchList)
                  {
                      StockInSearch.Add(item);

                  }
                  LoadSearchWindow();
              });
            Add_InputCommand = new RelayCommand<Window>(
              (p) =>
              {
                  if (SelectStockIn != null)
                  {
                      return false;
                  }
                  return true;
              },
              (p) =>
              {
                  var stockInID = "";
                  var in_count = DataProvider.Ins.Db.StockIN_Table.Count();
                  if (in_count > 0)
                  {
                      if (in_count < 9)
                      {
                          stockInID = "NK" + DateTime.Now.Year.ToString() + "M" + DateTime.Now.Month.ToString() + "00" + (in_count + 1).ToString();

                      }
                      else
                      {
                          stockInID = "NK" + DateTime.Now.Year.ToString() + "M" + DateTime.Now.Month.ToString() + "0" + (in_count + 1).ToString();

                      }
                  }
                  else
                  {
                      stockInID = "NK" + DateTime.Now.Year.ToString() + "M" + DateTime.Now.Month.ToString() + "001";
                  }
                  var StockIn_item = new StockIN_Table()
                  {
                      StockIN_ID = stockInID,
                      statusID = "YT01",
                      stockIn_Count = 0,
                      stockIn_Date = DateTime.Now
                  };
                  DataProvider.Ins.Db.StockIN_Table.Add(StockIn_item);
                  DataProvider.Ins.Db.SaveChanges();

                  LoadWindow();
                  SelectStockIn = DataProvider.Ins.Db.StockIN_Table.FirstOrDefault(x => x.StockIN_ID == stockInID);



              });

        }
        public void LoadSearchWindow()
        {
            StockIn = new ObservableCollection<StockIN_Table>(DataProvider.Ins.Db.StockIN_Table);
            Status = new ObservableCollection<Status_table>(DataProvider.Ins.Db.Status_table.Where(x => x.statusID == "YT01" || x.statusID == "NKR01" || x.statusID == "KS01"));
            SelectStockIn = null;
            SelectStatus = null;
            StockInDetail.Clear();

        }
        public void LoadWindow()
        {
            Status = new ObservableCollection<Status_table>(DataProvider.Ins.Db.Status_table.Where(x => x.statusID == "YT01" || x.statusID == "NKR01" || x.statusID == "KS01"));
            StockIn = new ObservableCollection<StockIN_Table>(DataProvider.Ins.Db.StockIN_Table);
            StockInSearch = new ObservableCollection<StockIN_Table>(DataProvider.Ins.Db.StockIN_Table);
            Books = new ObservableCollection<Book_table>(DataProvider.Ins.Db.Book_table);
            StockInDetailList = new ObservableCollection<StockIn_Detail_table>(DataProvider.Ins.Db.StockIn_Detail_table);
            StockInDetail = new ObservableCollection<StockIn_Detail_table>(DataProvider.Ins.Db.StockIn_Detail_table);

            StockInDetail.Clear();
            SelectStockIn = null;
            SelectBook = null;
            SelectStatus = null;
            Title = string.Empty;
            InValue = 0;

        }
        public void LoadDetailWindow()
        {
            Employ_Data.Instance.CheckStatusYoyaku();
            Status = new ObservableCollection<Status_table>(DataProvider.Ins.Db.Status_table.Where(x => x.statusID == "YT01" || x.statusID == "NKR01" || x.statusID == "KS01"));
            StockIn = new ObservableCollection<StockIN_Table>(DataProvider.Ins.Db.StockIN_Table);
            Books = new ObservableCollection<Book_table>(DataProvider.Ins.Db.Book_table);
            StockInDetailList = new ObservableCollection<StockIn_Detail_table>(DataProvider.Ins.Db.StockIn_Detail_table);

            StockInDetail.Clear();
            var Detail_List = StockInDetailList.Where(x => x.StockIn_ID == SelectStockIn.StockIN_ID);
            foreach (var item in Detail_List)
            {
                StockInDetail.Add(item);
            }
            SelectBook = null;
            Title = string.Empty;
            InValue = 0;
            IsSelectStockBookSelected = false;

        }
        public bool CheckStockInSelect()
        {
            if (SelectStockIn == null)
            {
                return false;
            }
            else
                return true;
        }
    }
}
