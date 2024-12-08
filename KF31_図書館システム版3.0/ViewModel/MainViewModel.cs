using KF31_図書館システム版3._0.BooKModel;
using KF31_図書館システム版3._0.Employ;
using KF31_図書館システム版3._0.Input_Model;
using KF31_図書館システム版3._0.Model;
using KF31_図書館システム版3._0.Output_Model;
using KF31_図書館システム版3._0.Pushlisher_Model;
using KF31_図書館システム版3._0.Stock_Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows;
using KF31_図書館システム版3._0.Loan_Model;

namespace KF31_図書館システム版3._0.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        private string _Employ_ID { get; set; }
        public string Employ_ID { get => _Employ_ID; set { _Employ_ID = value; OnPropertyChanged(); } }
        private string _Employ_Name { get; set; }
        public string Employ_Name { get => _Employ_Name; set { _Employ_Name = value; OnPropertyChanged(); } }
        private string _Possition_Name { get; set; }
        public string Possition_Name { get => _Possition_Name; set { _Possition_Name = value; OnPropertyChanged(); } }
        private string _Email { get; set; }
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _Address { get; set; }
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        private string _Birthday { get; set; }
        public string Birthday { get => _Birthday; set { _Birthday = value; OnPropertyChanged(); } }
        private string _Hiredate { get; set; }
        public string Hiredate { get => _Hiredate; set { _Hiredate = value; OnPropertyChanged(); } }

        private string _stock_Count {  get; set; }
        public string stock_Count { get => _stock_Count; set { _stock_Count = value;OnPropertyChanged(); } }
        private string _Employ_Count {  get; set; }
        public string Employ_Count {  get=>_Employ_Count; set { _Employ_Count = value;OnPropertyChanged(); } }
        private BitmapImage _qrCodeImage;
        public BitmapImage QRCodeImage
        {
            get { return _qrCodeImage; }
            set { _qrCodeImage = value; OnPropertyChanged(); }
        }

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand EmployWindowCommand { get; set; } // 社員管理
        public ICommand PushlisherWindowCommand { get; set; } // 社員管理
        public ICommand BookWindowCommand { get; set; }//本管理
        public ICommand LogOutCommand { get; set; }
        public ICommand PassUpdate_WindowCommand { get; set; }//
        public ICommand StockInWindowCommand { get; set; } // 入庫管理
        public ICommand StockOutWindowCommand { get; set; } // 出庫管理
        public ICommand StockWindowCommand { get; set; } // 在庫管理
        public ICommand LoanWindowCommand { get; set; } // 貸出管理




        public MainViewModel()
        {
            LoadWindow();
           PushlisherWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Hide();
                Pushliser_window pushliser = new Pushliser_window();
                pushliser.ShowDialog();
            });
            EmployWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Employ_Window pushliser = new Employ_Window();
                p.Close();
                pushliser.ShowDialog();
            });
            BookWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Book_Window book = new Book_Window();
                p.Close();
                book.ShowDialog();
            });
            PassUpdate_WindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Employ_PasswordChange_Window pass = new Employ_PasswordChange_Window();
                p.Close();
                pass.ShowDialog();
            });
            StockInWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Add_InputDetailWindow add_input = new Add_InputDetailWindow();
                p.Close();
                add_input.ShowDialog();
            });
            StockOutWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                AddOutput_Window add_output = new AddOutput_Window();
                p.Close();
                add_output.ShowDialog();
            });
            StockWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Stock stock = new Stock();
                p.Close();
                stock.ShowDialog();
            });
            LoanWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Loan_Window loan = new Loan_Window();
                p.Close();
                loan.ShowDialog();
            });
            LogOutCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                var question = MessageBox.Show("ログアウトしてもよろしいでしょうか？", "確認",
                    MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (question == MessageBoxResult.Cancel)
                    return;
                var employ = DataProvider.Ins.Db.Employee_table.FirstOrDefault(x => x.EmployID == Employ_Data.Instance.Em_ID);
                if (employ != null)
                {
                    employ.Em_Lastlogin = DateTime.Now;
                    DataProvider.Ins.Db.SaveChanges();
                }
                Login_Window loginwindow = new Login_Window();
                p.Close();
                loginwindow.ShowDialog();
            });
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Employ_ID = "ID : " + Employ_Data.Instance.Em_ID;
                Employ_Name = "名前： " + Employ_Data.Instance.Em_DisplayName;
                Possition_Name = "役職: " + Employ_Data.Instance.Possition_Name;

                OnPropertyChanged();
            });
            QRCodeImage = GenerateQRCodeImage(Employ_Data.Instance.EmQRCode);

        }
        public void LoadWindow()
        {
            Employ_Data.Instance.CheckStatusYoyaku();
            Employ_ID = "ID : " + Employ_Data.Instance.Em_ID;
            Employ_Name = "名前： " + Employ_Data.Instance.Em_DisplayName;
            Possition_Name = "役職: " + Employ_Data.Instance.Possition_Name;
            Birthday = "生年月日: " + Employ_Data.Instance.Birthday.ToString("yyyy/MM/dd");
            Hiredate = "入社日付: " + Employ_Data.Instance.Hiredate.ToString("yyyy/MM/dd");
            Email = "メール: " + Employ_Data.Instance.Email.ToString();
            Address = "住所: " + Employ_Data.Instance.Address.ToString();
            int? stockcount = 0;
            var stocklist = DataProvider.Ins.Db.Stock_table.Where(x => x.Libraty_table.LibratyID == Employ_Data.Instance.LibratyID);
            foreach ( var stock in stocklist)
            {
                stockcount += stock.Quantity;
            }
            stock_Count = stockcount.ToString();
            Employ_Count = DataProvider.Ins.Db.Employee_table.Count().ToString();
           

        }
        public BitmapImage GenerateQRCodeImage(string qrCodeBase64)
        {

            var bitmap = new BitmapImage();
            byte[] binaryData = Convert.FromBase64String(qrCodeBase64);
            using (var stream = new MemoryStream(binaryData))
            {
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
            }
            return bitmap;
        }
    }
}
