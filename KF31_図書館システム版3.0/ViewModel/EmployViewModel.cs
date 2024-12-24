using KF31_図書館システム版3._0.Employ;
using KF31_図書館システム版3._0.Main_Login_Model;
using KF31_図書館システム版3._0.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows;
using ZXing;
using System.Windows.Controls;

namespace KF31_図書館システム版3._0.ViewModel
{

    class EmployViewModel : BaseViewModel
    {

        private ObservableCollection<Possition_table> _Possitions { get; set; }
        public ObservableCollection<Possition_table> Possitions { get => _Possitions; set { _Possitions = value; OnPropertyChanged(); } }
        private ObservableCollection<Employee_table> _Employs { get; set; }
        public ObservableCollection<Employee_table> Employs { get => _Employs; set { _Employs = value; OnPropertyChanged(); } }
        private ObservableCollection<Employee_table> _EmploysList { get; set; }
        public ObservableCollection<Employee_table> EmploysList { get => _EmploysList; set { _EmploysList = value; OnPropertyChanged(); } }

        private Possition_table _Select_Possition { get; set; }
        public Possition_table Select_Possition { get => _Select_Possition; set { _Select_Possition = value; OnPropertyChanged(); } }
        private Employee_table _Select_EmID { get; set; }
        public Employee_table Select_EmID
        {
            get => _Select_EmID;
            set
            {
                _Select_EmID = value; OnPropertyChanged();
                if (Select_EmID != null)
                {
                    Em_DisplayName = Select_EmID.Em_DisplayName;
                    Em_Email = Select_EmID.Em_Email;
                    Em_Address = Select_EmID.Em_Address;
                    Select_Possition = Select_EmID.Possition_table;
                    Em_Hiredate = Select_EmID.Em_Hiredate.Value;

                }
            }
        }
        private Employee_table _SelectedItem { get; set; }
        public Employee_table SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Select_EmID = _SelectedItem;
                    Em_DisplayName = _SelectedItem.Em_DisplayName;
                    Select_Possition = _SelectedItem.Possition_table;
                    SearchBirthday = _SelectedItem.Em_Birthday;
                    SearchHiredate = _SelectedItem.Em_Hiredate;
                    Em_Email = _SelectedItem.Em_Email;
                    Em_Address = _SelectedItem.Em_Address;
                    LastLogin = _SelectedItem.Em_Lastlogin;
                }
            }
        }

        //プロパティ
        private string _EmployID { get; set; }
        public string EmployID { get => _EmployID; set { _EmployID = value; OnPropertyChanged(); } }
        private string _Em_DisplayName { get; set; }
        public string Em_DisplayName { get => _Em_DisplayName; set { _Em_DisplayName = value; OnPropertyChanged(); } }
        private DateTime? _Em_Hiredate { get; set; }
        public DateTime? Em_Hiredate { get => _Em_Hiredate; set { _Em_Hiredate = value; OnPropertyChanged(); } }
        private DateTime? _Em_Birthday { get; set; }
        public DateTime? Em_Birthday { get => _Em_Birthday; set { _Em_Birthday = value; OnPropertyChanged(); } }
        private string _possitionID { get; set; }
        public string possitionID { get => _possitionID; set { _possitionID = value; OnPropertyChanged(); } }
        private string _Em_Email { get; set; }
        public string Em_Email { get => _Em_Email; set { _Em_Email = value; OnPropertyChanged(); } }
        private string _Em_Address { get; set; }
        public string Em_Address { get => _Em_Address; set { _Em_Address = value; OnPropertyChanged(); } }
        private string _Em_userName { get; set; }
        public string Em_userName { get => _Em_userName; set { _Em_userName = value; OnPropertyChanged(); } }
        private string _Em_password { get; set; }
        public string Em_password { get => _Em_password; set { _Em_password = value; OnPropertyChanged(); } }
        private string _Em_password_moto { get; set; }
        public string Em_password_moto { get => _Em_password_moto; set { _Em_password_moto = value; OnPropertyChanged(); } }
        private string _Em_password_shin { get; set; }
        public string Em_password_shin { get => _Em_password_shin; set { _Em_password_shin = value; OnPropertyChanged(); } }
        private string _Em_password_shin1 { get; set; }
        public string Em_password_shin1 { get => _Em_password_shin1; set { _Em_password_shin1 = value; OnPropertyChanged(); } }
        //一覧表示用意
        private DateTime? _SearchBirthday { get; set; }
        public DateTime? SearchBirthday { get => _SearchBirthday; set { _SearchBirthday = value; OnPropertyChanged(); } }
        private DateTime? _SearchHiredate { get; set; }
        public DateTime? SearchHiredate { get => _SearchHiredate; set { _SearchHiredate = value; OnPropertyChanged(); } }
        private DateTime? _LastLogin { get; set; }
        public DateTime? LastLogin { get => _LastLogin; set { _LastLogin = value; OnPropertyChanged(); } }


        // Window　コマンド
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand BackMainCommand { get; set; }
        public ICommand BackEmployCommand { get; set; }
        // 機能開くコマンド
        public ICommand Add_EmployWIndowCommand { get; set; }
        public ICommand PassUpdate_WindowCommand { get; set; }
        public ICommand Update_WindowCommand { get; set; }
        public ICommand List_Employ_WindowCommand { get; set; }
        public ICommand QRCode_WindowCommand { get; set; }

        // 機能処理コマンド

        public ICommand Add_EmployCommand { get; set; }
        public ICommand PassUpdate_Command { get; set; }
        public ICommand Update_Command { get; set; }
        public ICommand PasswordChangedCommand_moto { get; set; }
        public ICommand PasswordChangedCommand_shin { get; set; }
        public ICommand PasswordChangedCommand_shin1 { get; set; }
        public ICommand Search_Command { get; set; }
        public ICommand Delete_Window_Command { get; set; }
        public ICommand Delete_Command {  get; set; }

        private BitmapImage _qrCodeImage;
        public BitmapImage QRCodeImage
        {
            get { return _qrCodeImage; }
            set { _qrCodeImage = value; OnPropertyChanged(); }
        }


        public EmployViewModel()
        {

            Possitions = new ObservableCollection<Possition_table>(DataProvider.Ins.Db.Possition_table);
            Employs = new ObservableCollection<Employee_table>(DataProvider.Ins.Db.Employee_table.Where(x=>x.Em_flag==0));
            EmploysList = new ObservableCollection<Employee_table>(DataProvider.Ins.Db.Employee_table.Where(x => x.Em_flag == 0));

            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; },
                (p) =>
                {

                    Em_Birthday = DateTime.Now;
                    Em_Hiredate = DateTime.Now;
                    OnPropertyChanged();

                });
            BackMainCommand = new RelayCommand<Window>((p) => { return true; },
                (p) =>
                {
                    MainWindow main = new MainWindow();
                    p.Close();
                    main.ShowDialog();

                });
            BackEmployCommand = new RelayCommand<Window>((p) => { return true; },
               (p) =>
               {
                   LoadWindow();
                   Employ_Window employ = new Employ_Window();
                   p.Close();
                   employ.ShowDialog();
               });
            Add_EmployWIndowCommand = new RelayCommand<Window>((p) =>
            {
                if (Employ_Data.Instance.Possition_ID != "1_MNG")
                {
                    return false;
                }
                return true;
            }
            ,

               (p) =>
               {
                   LoadWindow();
                   Add_Employ_Window add_Employ_Window = new Add_Employ_Window();
                   p.Close();
                   add_Employ_Window.ShowDialog();
               });
            Update_WindowCommand = new RelayCommand<Window>(
                (p) =>
                {
                    if (Employ_Data.Instance.Possition_ID != "1_MNG")
                    {
                        return false;
                    }
                    return true;
                },

            (p) =>
            {
                LoadWindow();
                Update_Window update = new Update_Window();
                p.Close();
                update.ShowDialog();
            });
            Delete_Window_Command = new RelayCommand<Window>(
                (p) =>
                {
                    if (Employ_Data.Instance.Possition_ID != "1_MNG")
                    {
                        return false;
                    }
                    return true;
                },

            (p) =>
            {
               Employ_Delete_Window delete=new Employ_Delete_Window();
                p.Close();
                delete.ShowDialog();
            });
            List_Employ_WindowCommand = new RelayCommand<Window>(
                (p) =>
                {
                    return true;
                },

            (p) =>
            {
                LoadWindow();
                EmploysList = new ObservableCollection<Employee_table>(DataProvider.Ins.Db.Employee_table.Where(x => x.Em_flag == 0));
                Employ_ListandSearch_Window listandsearch = new Employ_ListandSearch_Window();
                p.Close();
                listandsearch.ShowDialog();
            });
            Delete_Command = new RelayCommand<Window>((p) =>
            {
                if (Select_EmID == null)
                {
                    return false;
                }
                return true;
            },

          (p) =>
          {
              
              var item = DataProvider.Ins.Db.Employee_table.FirstOrDefault(x => x.EmployID == Select_EmID.EmployID && x.possitionID != "1_MNG");
              if (item == null)
              {
                  MessageBox.Show("選択された社員IDは存在してませんまたは削除できません!", "報告",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                  return;
              }
              var result = MessageBox.Show("削除してもよろしいでしょうか？", "確認",
                  MessageBoxButton.OKCancel, MessageBoxImage.Question);
              if (result == MessageBoxResult.Cancel)
              {
                  return;
              }
              item.Em_flag = 1;
              DataProvider.Ins.Db.SaveChanges();
              MessageBox.Show("削除完了!", "確認",
                  MessageBoxButton.OK, MessageBoxImage.Information);
              LoadWindow();

          });

            PasswordChangedCommand_moto = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Em_password_moto = p.Password; });
            PasswordChangedCommand_shin = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Em_password_shin = p.Password; });
            PasswordChangedCommand_shin1 = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Em_password_shin1 = p.Password; });
            Add_EmployCommand = new RelayCommand<Window>(
    (p) =>
    {
        return true;
    },
    (p) =>
    {
        // 役職
        if (Select_Possition == null)
        {
            MessageBox.Show("役職がまだ選択されていない!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        //社員ID
        if (String.IsNullOrEmpty(EmployID))
        {
            MessageBox.Show("社員IDは必須科目です!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;

        }
        //社員名
        if (String.IsNullOrEmpty(Em_DisplayName))
        {
            MessageBox.Show("社員名は必須科目です!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (!CheckViewModel.IsJapaneseOrEnglishOnly(Em_DisplayName))
        {
            MessageBox.Show("社員名を正しく入力してください！","報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        //メール
        if (String.IsNullOrEmpty(Em_Email))
        {
            MessageBox.Show("メールは必須科目です!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (!CheckViewModel.IsValidEmail(Em_Email))
        {
            MessageBox.Show("メールを正しく入力してください！", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        //住所
        if (String.IsNullOrEmpty(Em_Address))
        {
            MessageBox.Show("住所は必須科目です!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (! CheckViewModel.IsValidAddress(Em_Address))
        {
            MessageBox.Show("住所は無効です。正しい形式で入力してください!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        //ユーザネーム
        if (String.IsNullOrEmpty(Em_userName))
        {
            MessageBox.Show("ユーザネームは必須科目です!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        //入社年月日
        if (Em_Hiredate == null)
        {
            MessageBox.Show("入社年月日は必須科目です!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        //生年月日
        if (Em_Birthday == null)
        {
            MessageBox.Show("生年月日は必須科目です!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;

        }
        var Em_Check = DataProvider.Ins.Db.Employee_table.FirstOrDefault(x => x.EmployID == EmployID);
        if (Em_Check != null)
        {
            MessageBox.Show("入力された社員IDは概に存在しました！", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        Employee_table Em = new Employee_table()
        {
            EmployID = EmployID,
            possitionID = Select_Possition.possitionID,
            Em_userName = Em_userName,
            Em_password = MD5Hash(Base64Encode("000000")),
            Em_Birthday = Em_Birthday,
            Em_Email = Em_Email,
            Em_Hiredate = Em_Hiredate,
            Em_Address = Em_Address,
            Em_DisplayName = Em_DisplayName,
            Em_Lastlogin = DateTime.Now,
            Em_flag = 0,
            Em_BarCode = GenerateEmployeeQRCode(EmployID, Em_DisplayName, Select_Possition.possitionName, Em_Email, "000000")


        };
        var result = MessageBox.Show("新社員を登録してもよろしいでしょうか？", "確認",
              MessageBoxButton.OKCancel, MessageBoxImage.Question);
        if (result == MessageBoxResult.Cancel)
            return;
        DataProvider.Ins.Db.Employee_table.Add(Em);
        DataProvider.Ins.Db.SaveChanges();
        MessageBox.Show("登録完了しました!", "報告",
            MessageBoxButton.OK, MessageBoxImage.Information);
        OnPropertyChanged("Employs");
        OnPropertyChanged("EmploysList");
        LoadWindow();

    }
    );
            Update_Command = new RelayCommand<Window>(
    (p) =>
    {
        return true;
    },
    (p) =>
    {

        if (Select_Possition == null) // 役職
        {
            MessageBox.Show("役職がまだ選択されていない!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (Select_EmID == null) // 社員ID
        {
            MessageBox.Show("社員IDがまだ選択されていない!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (String.IsNullOrEmpty(Em_DisplayName))//社員名
        {
            MessageBox.Show("社員名は必須科目です!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (!CheckViewModel.IsJapaneseOrEnglishOnly(Em_DisplayName))
        {
            MessageBox.Show("社員名を正しく入力してください！", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (String.IsNullOrEmpty(Em_Email))//メール
        {
            MessageBox.Show("メールは必須科目です!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (!CheckViewModel.IsValidEmail(Em_Email))
        {
            MessageBox.Show("メールを正しく入力してください！", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (String.IsNullOrEmpty(Em_Address))//住所
        {
            MessageBox.Show("住所は必須科目です!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (!CheckViewModel.IsValidAddress(Em_Address))
        {
            MessageBox.Show("住所は無効です。正しい形式で入力してください!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (Em_Hiredate == null)//入社年月日
        {
            MessageBox.Show("入社年月日は必須科目です!", "報告",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var result = MessageBox.Show("社員情報を更新してもよろしいでしょうか？", "確認",
             MessageBoxButton.OKCancel, MessageBoxImage.Question);
        if (result == MessageBoxResult.Cancel)
            return;
        var Em_Check = DataProvider.Ins.Db.Employee_table.FirstOrDefault(x => x.EmployID == Select_EmID.EmployID);

        Em_Check.Em_DisplayName = Em_DisplayName;
        Em_Check.Em_Email = Em_Email;
        Em_Check.Em_Hiredate = Em_Hiredate;
        Em_Check.Em_Address = Em_Address;
        Em_Check.possitionID = Select_Possition.possitionID;



        DataProvider.Ins.Db.SaveChanges();
        Employ_Data.Instance.Em_DisplayName = Em_DisplayName;
        Employ_Data.Instance.Possition_ID = Select_Possition.possitionID;
        Employ_Data.Instance.Possition_Name = Em_Check.Possition_table.possitionName;
        MessageBox.Show("更新完了しました!", "報告",
            MessageBoxButton.OK, MessageBoxImage.Information);
        LoadWindow();

    }
    );
            PassUpdate_Command = new RelayCommand<Window>(
               (p) => { return true; },

            (p) =>
            {
                //入力チェック
                if (string.IsNullOrEmpty(Em_password_moto))
                {
                    MessageBox.Show("元パスワードは必須項目です！", "報告",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(Em_password_shin))
                {
                    MessageBox.Show("新しいパスワードは必須項目です！", "報告",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(Em_password_shin1))
                {
                    MessageBox.Show("新しいパスワード(確認)は必須項目です！", "報告",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (MD5Hash(Base64Encode(Em_password_moto)) != Employ_Data.Instance.Em_Password)
                {
                    MessageBox.Show("元パスワードは間違います！", "報告",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (MD5Hash(Base64Encode(Em_password_shin)) != MD5Hash(Base64Encode(Em_password_shin1)))
                {
                    MessageBox.Show("新しいパスワード(確認)は間違います！", "報告",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                var result = MessageBox.Show("パスワードを更新してもよろしいでしょうか？", "確認",
                    MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Cancel)
                    return;

                var Employ = DataProvider.Ins.Db.Employee_table.FirstOrDefault(x => x.EmployID == Employ_Data.Instance.Em_ID);
                Employ.Em_password = MD5Hash(Base64Encode(Em_password_shin));
                Employ.Em_BarCode = GenerateEmployeeQRCode(Employ.EmployID, Employ.Em_DisplayName, Employ.Possition_table.possitionName, Employ.Em_Email, Em_password_shin);

                DataProvider.Ins.Db.SaveChanges();
                Employ_Data.Instance.Em_Password = MD5Hash(Base64Encode(Em_password_shin));
                MessageBox.Show("パスワード更新完了！", "報告",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                Account_Window account = new Account_Window();
                p.Close();
                OnPropertyChanged();
                account.ShowDialog();
            }

             );
            Search_Command = new RelayCommand<Window>(
             (p) =>
             {
                 if (Select_EmID == null && string.IsNullOrEmpty(Em_DisplayName) && Select_Possition == null
                 && SearchBirthday == null && SearchHiredate == null && string.IsNullOrEmpty(Em_Email) && string.IsNullOrEmpty(Em_Address) && LastLogin == null)
                 {
                     return false;
                 }
                 return true;
             },
             (p) =>
             {
                 EmploysList.Clear();
                 var Employ_list =
                      Employs.Where(x =>
                         (Select_EmID == null || x.EmployID == Select_EmID.EmployID) && // Giả sử Id là thuộc tính của Select_EmID
                         (string.IsNullOrEmpty(Em_DisplayName) || x.Em_DisplayName.Contains(Em_DisplayName)) &&
                         (Select_Possition == null || x.possitionID == Select_Possition.possitionID) &&
                         (SearchBirthday == null || x.Em_Birthday == SearchBirthday) &&
                         (SearchHiredate == null || x.Em_Hiredate == SearchHiredate) &&
                         (string.IsNullOrEmpty(Em_Email) || x.Em_Email.Contains(Em_Email)) &&
                         (string.IsNullOrEmpty(Em_Address) || x.Em_Address.Contains(Em_Address)) &&
                         (LastLogin == null || x.Em_Lastlogin == LastLogin)

                 ).ToList();
                 foreach (var employ in Employ_list)
                 {
                     EmploysList.Add(employ);
                 }

                 LoadWindow();

             }

                );

            QRCodeImage = GenerateQRCodeImage(Employ_Data.Instance.EmQRCode);
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
        public void LoadWindow()
        {
            Possitions = new ObservableCollection<Possition_table>(DataProvider.Ins.Db.Possition_table);
            Employs = new ObservableCollection<Employee_table>(DataProvider.Ins.Db.Employee_table.Where(x => x.Em_flag == 0));

            Select_EmID = null;
            EmployID = null;
            Em_DisplayName = String.Empty;
            Select_Possition = null;
            Em_Email = null;
            Em_Address = null;
            Em_userName = null;
            Em_Hiredate = DateTime.Now;
            Em_Birthday = DateTime.Now;

            SearchBirthday = null;
            SearchHiredate = null;

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
                    CharacterSet = "UTF-8" // Thiết lập UTF-8 cho tiếng Nhật
                }
            };
            using (var bitmap = writer.Write(json))
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return Convert.ToBase64String(stream.ToArray()); // Trả về Base64
            }
        }


    }
}
