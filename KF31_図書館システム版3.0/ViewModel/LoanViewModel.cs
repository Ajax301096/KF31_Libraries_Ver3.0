using KF31_図書館システム版3._0.Loan_Model;
using KF31_図書館システム版3._0.Main_Login_Model;
using KF31_図書館システム版3._0.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace KF31_図書館システム版3._0.ViewModel
{
    public class LoanViewModel : BaseViewModel
    {
        private ObservableCollection<Lend_table> _Lend { get; set; }
        public ObservableCollection<Lend_table> Lend { get => _Lend; set { _Lend = value; OnPropertyChanged(); } }
        private ObservableCollection<Lend_table> _Lend_Search { get; set; }
        public ObservableCollection<Lend_table> Lend_Search { get => _Lend_Search; set { _Lend_Search = value; OnPropertyChanged(); } }
        private ObservableCollection<Status_table> _Status { get; set; }
        public ObservableCollection<Status_table> Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }

        private Lend_table _SelectedItem {  get; set; }
        public Lend_table SelectedItem { get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if(_SelectedItem != null)
                {
                    LendID = SelectedItem.Lend_ID;
                    userID = SelectedItem.Yoyaku_table.userID;
                    stockID = SelectedItem.Yoyaku_table.StockID;
                    returnTime = SelectedItem.Return_Date;
                    SelectedStatusitem = SelectedItem.Status_table;
                }
            } }
        private Status_table _SelectedStatusitem {  get; set; }
        public Status_table SelectedStatusitem {  get => _SelectedStatusitem; set { _SelectedStatusitem = value;OnPropertyChanged(); } }
        private string _LendID {  get; set; }
        public string LendID {  get => _LendID; set { _LendID = value;OnPropertyChanged(); } }
        private string _userID {  get; set; }
        public string userID {  get=>_userID; set { _userID = value;OnPropertyChanged(); } }
        private string _stockID {  get; set; }
        public string stockID { get => _stockID; set { _stockID = value; OnPropertyChanged(); } }
        private string _title {  get; set; }
        public string title { get => _title; set {  _title = value;OnPropertyChanged(); } }
        private DateTime? _returnTime { get; set; }
        public DateTime? returnTime { get => _returnTime; set { _returnTime = value; OnPropertyChanged(); } }
        public DateTime DateTimeStart {  get; set; }
       private string _YoyakuID {  get; set; }
        public string YoyakuID { get =>_YoyakuID; set { _YoyakuID = value;OnPropertyChanged(); } }
        private bool _isDatePickerEnabled { get; set; }
        public bool IsDatePickerEnabled
        {
            get => _isDatePickerEnabled;
            set
            {
                _isDatePickerEnabled = value;
                OnPropertyChanged(nameof(IsDatePickerEnabled));
            }
        }
        public ICommand LoanOrderCommand { get; set; }
        public ICommand LoanListCommand { get; set; }
        public ICommand OrderConfirmCommand { get; set; }
        public ICommand SearchOrderCommand { get; set; }
        public ICommand BackMainCommand { get; set; }
        public ICommand EnableDatePickerCommand { get; set; }

        public LoanViewModel()
        {
            LoadWindow();
            IsDatePickerEnabled = false;
            BackMainCommand = new RelayCommand<Window>((p) => { return true; },
          (p) =>
          {
              MainWindow main = new MainWindow();
              p.Close();
              main.ShowDialog();
          });
            EnableDatePickerCommand = new RelayCommand<Window>(
                (p) => {
                    if (returnTime == null)
                    {
                        return false;
                    }
                    else
                        return true;
                }
                , (p) =>
            {
                EnableDatePicker();

            });
            DateTimeStart = DateTime.Today.AddDays(1);
            LoanOrderCommand = new RelayCommand<Window>((p) => true, (p) =>
            {
                LoadWindow();
                Loan_Order_Window loanorder = new Loan_Order_Window();
                p.Close();
                loanorder.ShowDialog();

            });
            LoanListCommand = new RelayCommand<Window>((p) => true, (p) =>
            {
                LoadWindow();
                Loan_ListAndSearchWindow loanorder = new Loan_ListAndSearchWindow();
                p.Close();
                loanorder.ShowDialog();

            });
            SearchOrderCommand = new RelayCommand<Window>(

                (p) =>
                {
                    if (string.IsNullOrEmpty(YoyakuID))
                    {
                        return false;
                    }
                    else
                        return true;
                },
                (p) =>
                {
                    var YoyakuItem = DataProvider.Ins.Db.Yoyaku_table.Where(x => x.YoyakuID == YoyakuID).FirstOrDefault();
                    if(YoyakuItem == null)
                    {
                        MessageBox.Show("入力された予約IDは存在していません","報告",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if(YoyakuItem.statusID == "KS01")
                    {
                        MessageBox.Show("予約アイテムはキャンセルされました！", "報告",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    userID = YoyakuItem.userID;
                    stockID = YoyakuItem.StockID;
                    title = YoyakuItem.Stock_table.Book_table.Book_title;
                    returnTime = YoyakuItem.ReturnTime.Value;
                    IsDatePickerEnabled = false;

                    OnPropertyChanged();


                });
            OrderConfirmCommand = new RelayCommand<Window>(

               (p) =>
               {
                   if (string.IsNullOrEmpty(YoyakuID) || string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(stockID) )
                   {
                       return false;
                   }
                   else
                       return true;
               },
               (p) =>
               {
                   var item = DataProvider.Ins.Db.Yoyaku_table.Where(x => x.YoyakuID == YoyakuID).FirstOrDefault();
                   if (item == null)
                   {
                       return;
                   }
                    var result =   MessageBox.Show("確認してもよろしいですか？","確認",
                           MessageBoxButton.OKCancel, MessageBoxImage.Information);
                   if (result == MessageBoxResult.Cancel)
                       return;
                   var lend_count = DataProvider.Ins.Db.Lend_table.Count();

                   var loan_item = new Lend_table()
                   {
                       Lend_ID = Employ_Data.Instance.LibratyID + "-" + item.YoyakuID + "-" + (lend_count + 1).ToString(),
                       YoyakuID = item.YoyakuID,
                       Rental_Date = DateTime.Now,
                       Return_Date = item.ReturnTime,
                       statusID = "KSD01",
                       EmployID = Employ_Data.Instance.Em_ID,
                       Upload_Date = DateTime.Now
                   };
                   item.statusID = loan_item.statusID;
                   DataProvider.Ins.Db.Lend_table.Add(loan_item);
                   DataProvider.Ins.Db.SaveChanges();
                   MessageBox.Show("完了しました！","報告",
                       MessageBoxButton.OK, MessageBoxImage.Information);
                   LoadWindow();


               });
        }
        private void EnableDatePicker()
        {
            IsDatePickerEnabled = true;
        }
        public void LoadWindow()
        {
            Lend = new ObservableCollection<Lend_table>(DataProvider.Ins.Db.Lend_table);
            Lend_Search = new ObservableCollection<Lend_table>(DataProvider.Ins.Db.Lend_table);
            Status = new ObservableCollection<Status_table>(DataProvider.Ins.Db.Status_table.Where(x=>x.statusID == "KS01" || x.statusID == "KSD01" || x.statusID == "YYK02"));

            Employ_Data.Instance.CheckStatusYoyaku();
            userID = string.Empty;
            stockID = string.Empty;
            title = string.Empty;
            returnTime = null;
            YoyakuID = string.Empty;
        }
       
    }
}
