using KF31_図書館システム版3._0.Main_Login_Model;
using KF31_図書館システム版3._0.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using ZXing;
using ZXing.Common;



namespace KF31_図書館システム版3._0.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        public bool IsShowPassword { get; set; } = false;
        public bool IsLogin { get; set; }
        public string _UserName { get; set; }
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        public string _PassWord { get; set; }
        public string PassWord { get => _PassWord; set { _PassWord = value; OnPropertyChanged(); } }

        private Visibility _buttonVisibility;
        public Visibility ButtonVisibility
        {
            get => _buttonVisibility;
            set { _buttonVisibility = value; OnPropertyChanged(); }
        }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand Check_PasswordCommand { get; set; }


        public LoginViewModel()
        {
            IsLogin = false;
            UserName = null;
            PassWord = null;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { PassWord = p.Password; });
            Check_PasswordCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { CheckPassword(p); });


            ButtonVisibility = CheckIfDataExists() ? Visibility.Collapsed : Visibility.Visible;
            //サンブルデータ登録



        }
        void Login(Window p)
        {
            if (p == null)
                return;

            /*
             admin
             admin

            staff
            staff
             */

            string passEncode = MD5Hash(Base64Encode(PassWord));
            var Employ = DataProvider.Ins.Db.Employee_table.FirstOrDefault(x => x.Em_userName == UserName && x.Em_password == passEncode && x.Em_flag == 0);


            if (Employ != null)
            {
                IsLogin = true;
                Employ_Data.Instance.Em_ID = Employ.EmployID;
                Employ_Data.Instance.Em_DisplayName = Employ.Em_DisplayName;
                Employ_Data.Instance.Possition_Name = Employ.Possition_table.possitionName;
                Employ_Data.Instance.Possition_ID = Employ.possitionID;
                Employ_Data.Instance.Em_Password = MD5Hash(Base64Encode(PassWord));
                Employ_Data.Instance.EmQRCode = Employ.Em_BarCode;
                Employ_Data.Instance.Birthday = Employ.Em_Birthday.Value;
                Employ_Data.Instance.Hiredate = Employ.Em_Hiredate.Value;
                Employ_Data.Instance.Email = Employ.Em_Email;
                Employ_Data.Instance.Address = Employ.Em_Address;
                Employ_Data.Instance.LibratyID = "L1";
                MainWindow mainwindow = new MainWindow();
                p.Close();

                mainwindow.ShowDialog();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("ユーザ名またはパスワードが間違います！");
            }
        }

        //データ存在するかどうかチェック
        private bool CheckIfDataExists()
        {

            using (var context = new KF31_LliM5_DataBaseEntities())
            {
                //データ存在チェック
                return context.Book_table.Any() ||
                       context.Category_table.Any() ||
                       context.Employee_table.Any() ||
                       false;
            }
        }
        private void DeleteAllData()
        {
            using (var context = new KF31_LliM5_DataBaseEntities())
            {
                // データを全部削除
                context.Employee_table.RemoveRange(context.Employee_table);
                context.Publisher_table.RemoveRange(context.Publisher_table);
                context.Category_table.RemoveRange(context.Category_table);
                context.Book_table.RemoveRange(context.Book_table);
                context.Possition_table.RemoveRange(context.Possition_table);
                context.Libraty_table.RemoveRange(context.Libraty_table);
                context.StockIN_Table.RemoveRange(context.StockIN_Table);
                context.StockIn_Detail_table.RemoveRange(context.StockIn_Detail_table);
                context.StockOut_table.RemoveRange(context.StockOut_table);
                context.StockOut_Detail_table.RemoveRange(context.StockOut_Detail_table);
                context.Stock_table.RemoveRange(context.Stock_table);
                context.User_table.RemoveRange(context.User_table);
                context.Yoyaku_table.RemoveRange(context.Yoyaku_table);
                context.Lend_table.RemoveRange(context.Lend_table);
                context.Status_table.RemoveRange(context.Status_table);

                context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                MessageBox.Show("データ削除完了！");
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }


        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        private void CheckPassword(PasswordBox passwordBox)
        {
            if (passwordBox == null)
            {
                return;
            }
            // Thay đổi nội dung của PasswordBox dựa trên trạng thái IsShowPassword
            passwordBox.Password = IsShowPassword ? PassWord : "";

        }


        //QRCode 作成(社員)
        private string GenerateEmployeeQRCode(string employID, string displayName, string position, string email, string password)
        {
            var employeeData = new
            {
                EmployID = employID,
                DisplayName = displayName,
                Position = position,
                Email = email,
                Password = password
            };
            string json = JsonConvert.SerializeObject(employeeData);

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.QrCode.QrCodeEncodingOptions
                {
                    Height = 250,
                    Width = 250,
                    Margin = 1,
                    CharacterSet = "UTF-8" // Thiết lập UTF-8
                }
            };

            Bitmap bitmap = writer.Write(json);

            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        // Barcode
        private string GenerateBarcode(string data)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 100,
                    Width = 300,
                    Margin = 1
                }
            };

            Bitmap bitmap = writer.Write(data);

            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return Convert.ToBase64String(stream.ToArray());
            }
        }

    }
}

