using KF31_図書館システム版3._0.Loan_Model;
using KF31_図書館システム版3._0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private string _userID {  get; set; }
        public string userID {  get=>_userID; set { _userID = value;OnPropertyChanged(); } }
        private string _stockID {  get; set; }
        public string stockID { get => _stockID; set { _stockID = value; OnPropertyChanged(); } }
        private string _title {  get; set; }
        public string title { get => _title; set {  _title = value;OnPropertyChanged(); } }
        private DateTime _returnTime { get; set; }
        public DateTime returnTime { get => _returnTime; set { _returnTime = value; OnPropertyChanged(); } }
        public DateTime DateTimeStart {  get; set; }
        private string _YoyakuID {  get; set; }
        public string YoyakuID { get =>_YoyakuID; set { _YoyakuID = value;OnPropertyChanged(); } }
        public ICommand LoanOrderCommand { get; set; }
        public ICommand SearchOrderCommand { get; set; }
        public LoanViewModel()
        {
            DateTimeStart = DateTime.Today.AddDays(1);
            LoanOrderCommand = new RelayCommand<Window>((p) => true, (p) =>
            {
                Loan_Order_Window loanorder = new Loan_Order_Window();
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
                        MessageBox.Show("入力された予約IDは存在していません?","報告",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    userID = YoyakuItem.userID;
                    stockID = YoyakuItem.StockID;
                    title = YoyakuItem.Stock_table.Book_table.Book_title;
                    returnTime = YoyakuItem.ReturnTime.Value;
                    OnPropertyChanged();


                });
        }
    }
}
