using KF31_図書館システム版3._0.Main_Login_Model;
using KF31_図書館システム版3._0.Model;
using KF31_図書館システム版3._0.Pushlisher_Model;
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
    class PushlisherViewModel : BaseViewModel
    {
        private ObservableCollection<Publisher_table> _Pushlisher { get; set; }
        public ObservableCollection<Publisher_table> Pushlisher { get => _Pushlisher; set { _Pushlisher = value; OnPropertyChanged(); } }
        private ObservableCollection<Publisher_table> _Pushlisher_List { get; set; }
        public ObservableCollection<Publisher_table> PushlisherList { get => _Pushlisher_List; set { _Pushlisher_List = value; OnPropertyChanged(); } }

        //プロパティ
        private string _PublisherID { get; set; }
        public string PublisherID { get => _PublisherID; set { _PublisherID = value; OnPropertyChanged(); } }
        private string _PublisherName { get; set; }
        public string PublisherName { get => _PublisherName; set { _PublisherName = value; OnPropertyChanged(); } }
        private string _Publisher_email { get; set; }
        public string Publisher_email { get => _Publisher_email; set { _Publisher_email = value; OnPropertyChanged(); } }
        private string _Publisher_Phone { get; set; }
        public string Publisher_Phone { get => _Publisher_Phone; set { _Publisher_Phone = value; OnPropertyChanged(); } }

        private Publisher_table _Select_PusID { get; set; }
        public Publisher_table Select_PusID
        {
            get => _Select_PusID;
            set
            {
                _Select_PusID = value; OnPropertyChanged();
                if (Select_PusID != null)
                {
                    PublisherName = Select_PusID.PublisherName;
                    Publisher_email = Select_PusID.Publisher_email;
                    Publisher_Phone = Select_PusID.Publisher_Phone;

                }
            }
        }
        private Publisher_table _SelectedItem { get; set; }
        public Publisher_table SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Select_PusID = SelectedItem;
                    PublisherName = SelectedItem.PublisherName;
                    Publisher_email = SelectedItem.Publisher_email;
                    Publisher_Phone = SelectedItem.Publisher_Phone;
                }

            }
        }


        //Window開くコマンド
        public ICommand BackMainCommand { get; set; }
        public ICommand BackPushlisherCommand { get; set; }
        public ICommand Add_Pushlisher_WindowCommand { get; set; }
        public ICommand Update_Pushlisher_WindowCommand { get; set; }
        public ICommand ListandSearch_Pushlisher_WindowCommand { get; set; }
        //機能処理コマンド
        public ICommand Add_PushlisherCommand { get; set; }
        public ICommand Update_PushlisherCommand { get; set; }
        public ICommand Search_PushlisherCommand { get; set; }

        public PushlisherViewModel()
        {

            Pushlisher = new ObservableCollection<Publisher_table>(DataProvider.Ins.Db.Publisher_table);
            PushlisherList = new ObservableCollection<Publisher_table>(DataProvider.Ins.Db.Publisher_table);
            //Window開くコマンド
            BackMainCommand = new RelayCommand<Window>((p) => { return true; },
            (p) =>
            {
                p.Close();
                var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                if (mainWindow != null)
                {
                    mainWindow.ShowDialog();
                }
            });
            BackPushlisherCommand = new RelayCommand<Window>((p) => { return true; },
                (p) =>
                {
                    Pushliser_window pushlisher = new Pushliser_window();
                    p.Close();
                    pushlisher.ShowDialog();
                }
            );
            Add_Pushlisher_WindowCommand = new RelayCommand<Window>((p) =>
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
                Pushlisher_Add_window pushadd = new Pushlisher_Add_window();
                p.Close();
                pushadd.ShowDialog();
            }
            );
            Update_Pushlisher_WindowCommand = new RelayCommand<Window>((p) =>
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
               Pushlisher_update_window pushupdate = new Pushlisher_update_window();
               p.Close();
               pushupdate.ShowDialog();
           }
           );
            ListandSearch_Pushlisher_WindowCommand = new RelayCommand<Window>((p) =>
            {

                return true;
            },
         (p) =>
         {
             LoadWindow();
             PushlisherList = new ObservableCollection<Publisher_table>(DataProvider.Ins.Db.Publisher_table);
             Pushlisher_listandsearch_window listandsearch = new Pushlisher_listandsearch_window();
             p.Close();
             listandsearch.ShowDialog();
         }
         );

            //機能処理のコマンド
            Add_PushlisherCommand = new RelayCommand<Window>((p) =>
            {
                if (String.IsNullOrEmpty(PublisherID))
                {
                    return false;
                }
                if (String.IsNullOrEmpty(PublisherName))
                {
                    return false;
                }
                if (String.IsNullOrEmpty(Publisher_email))
                {
                    return false;
                }
                if (String.IsNullOrEmpty(Publisher_Phone))
                {
                    return false;
                }
                return true;
            },
                (p) =>
                {
                    var pushlisher = DataProvider.Ins.Db.Publisher_table.FirstOrDefault(x => x.PublisherID == PublisherID);
                    if (pushlisher != null)
                    {
                        MessageBox.Show("出版社IDは概に存在しました！", "報告",
                            MessageBoxButton.OKCancel, MessageBoxImage.Error);
                        return;
                    }
                    var result = MessageBox.Show("新しい出版社を登録してもよろしいでしょうか？", "確認",
                        MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Cancel)
                        return;
                    Publisher_table add_pushlisher = new Publisher_table()
                    {
                        PublisherID = PublisherID,
                        PublisherName = PublisherName,
                        Publisher_email = Publisher_email,
                        Publisher_Phone = Publisher_Phone
                    };
                    DataProvider.Ins.Db.Publisher_table.Add(add_pushlisher);
                    DataProvider.Ins.Db.SaveChanges();
                    MessageBox.Show("登録完了しました！", "報告",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    OnPropertyChanged("Pushlisher");
                    OnPropertyChanged("PushlisherList");
                    LoadWindow();


                }
                );
            Update_PushlisherCommand = new RelayCommand<Window>((p) =>
            {
                if (Select_PusID == null)
                {
                    return false;
                }
                if (String.IsNullOrEmpty(PublisherName))
                {
                    return false;
                }
                if (String.IsNullOrEmpty(Publisher_email))
                {
                    return false;
                }
                if (String.IsNullOrEmpty(Publisher_Phone))
                {
                    return false;
                }
                return true;
            },
             (p) =>
             {
                 var pushlisher = DataProvider.Ins.Db.Publisher_table.FirstOrDefault(x => x.PublisherID == Select_PusID.PublisherID);

                 var result = MessageBox.Show("出版社情報を更新してもよろしいでしょうか？", "確認",
                     MessageBoxButton.OKCancel, MessageBoxImage.Question);
                 if (result == MessageBoxResult.Cancel)
                     return;
                 pushlisher.PublisherName = PublisherName;
                 pushlisher.Publisher_email = Publisher_email;
                 pushlisher.Publisher_Phone = Publisher_Phone;
                 DataProvider.Ins.Db.SaveChanges();
                 MessageBox.Show("更新完了しました！", "報告",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                 OnPropertyChanged("Pushlisher");
                 LoadWindow();


             }
             );
            Search_PushlisherCommand = new RelayCommand<Window>(
            (p) =>
            {
                if (Select_PusID == null && string.IsNullOrEmpty(PublisherName) && string.IsNullOrEmpty(Publisher_email) && string.IsNullOrEmpty(Publisher_Phone))
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                PushlisherList.Clear();
                var Publisher_List = Pushlisher.Where(x =>
                (Select_PusID == null || x.PublisherID == Select_PusID.PublisherID) &&
                (string.IsNullOrEmpty(PublisherName) || x.PublisherName.Contains(PublisherName)) &&
                (string.IsNullOrEmpty(Publisher_email) || x.Publisher_email.Contains(Publisher_email)) &&
                (string.IsNullOrEmpty(Publisher_Phone) || x.Publisher_Phone.Contains(Publisher_Phone))
                ).ToList();
                foreach (var publish in Publisher_List)
                {
                    PushlisherList.Add(publish);
                }
                LoadWindow();
            }

               );
        }
        public void LoadWindow()
        {
            Pushlisher = new ObservableCollection<Publisher_table>(DataProvider.Ins.Db.Publisher_table);

            PublisherID = string.Empty;
            PublisherName = string.Empty;
            Publisher_email = string.Empty;
            Select_PusID = null;
            Publisher_Phone = string.Empty;
        }

    }
}
