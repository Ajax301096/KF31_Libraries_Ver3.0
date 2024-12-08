using KF31_図書館システム版3._0.BooKModel;
using KF31_図書館システム版3._0.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ZXing.Common;
using ZXing;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using Microsoft.Win32;


namespace KF31_図書館システム版3._0.ViewModel
{
    public class BookViewModel : BaseViewModel
    {
        private ObservableCollection<Book_table> _Books { get; set; }
        public ObservableCollection<Book_table> Books { get => _Books; set { _Books = value; OnPropertyChanged(); } }
        private ObservableCollection<Book_table> _BooksList { get; set; }
        public ObservableCollection<Book_table> BooksList { get => _BooksList; set { _BooksList = value; OnPropertyChanged(); } }

        private ObservableCollection<Category_table> _Category { get; set; }
        public ObservableCollection<Category_table> Category { get => _Category; set { _Category = value; OnPropertyChanged(); } }
        private ObservableCollection<Publisher_table> _Publisher { get; set; }
        public ObservableCollection<Publisher_table> Publisher { get => _Publisher; set { _Publisher = value; OnPropertyChanged(); } }
        private Category_table _Selection_Category { get; set; }
        public Category_table Selection_Category { get => _Selection_Category; set { _Selection_Category = value; OnPropertyChanged(); } }
        private Publisher_table _Selection_Publisher { get; set; }
        public Publisher_table Selection_Publisher { get => _Selection_Publisher; set { _Selection_Publisher = value; OnPropertyChanged(); } }
        private Book_table _Selection_Book { get; set; }
        public Book_table Selection_Book
        {
            get => _Selection_Book;
            set
            {
                _Selection_Book = value; OnPropertyChanged();

                if (Selection_Book != null)
                {
                    Title = Selection_Book.Book_title;
                    Selection_Category = Selection_Book.Category_table;
                    Author = Selection_Book.Book_Author;
                    Selection_Publisher = Selection_Book.Publisher_table;
                    CategoryName = Selection_Book.Category_table.CategoryName;
                    PublisherName = Selection_Book.Publisher_table.PublisherName;
                }

            }
        }

        private string _Title { get; set; }
        public string Title { get => _Title; set { _Title = value; OnPropertyChanged(); } }
        private string _Author { get; set; }
        public string Author { get => _Author; set { _Author = value; OnPropertyChanged(); } }
        private string _KeySearch { get; set; }
        public string KeySearch { get => _KeySearch; set { _KeySearch = value; OnPropertyChanged(); } }
        private string _CategoryName { get; set; }
        public string CategoryName { get => _CategoryName; set { _CategoryName = value; OnPropertyChanged(); } }
        private string _PublisherName { get; set; }
        public string PublisherName { get => _PublisherName; set { _PublisherName = value; OnPropertyChanged(); } }
        // 画像

        private string _imageFileName;
        public string ImageFileName
        {
            get { return _imageFileName; }
            set
            {
                _imageFileName = value;
                OnPropertyChanged(nameof(ImageFileName));
            }
        }

        private string _selectedImagePath;
        public string SelectedImagePath
        {
            get { return _selectedImagePath; }
            set
            {
                _selectedImagePath = value;
                OnPropertyChanged(nameof(SelectedImagePath));
            }
        }

        public ICommand ChooseImageCommand { get; set; }

        public ICommand BackBookCommand { get; set; }
        public ICommand BookAddWindowCommand { get; set; }
        public ICommand BookUpdateWindowCommand { get; set; }
        public ICommand BookListAndSearchWindowCommand { get; set; }
        public ICommand BookDeleteWindowCommand { get; set; }

        //機能処理コマンド
        public ICommand BookAddCommand { get; set; }
        public ICommand BookUpdateCommand { get; set; }
        public ICommand BookSearchCommand { get; set; }
        public ICommand BookDeleteCommand { get; set; }



        public BookViewModel()
        {
            ChooseImageCommand = new RelayCommand<Window>((p) => true,
                (p) =>
                {
                    ChooseImage();
                });
            Employ_Data.Instance.CheckStatusYoyaku();
            Category = new ObservableCollection<Category_table>(DataProvider.Ins.Db.Category_table);
            Publisher = new ObservableCollection<Publisher_table>(DataProvider.Ins.Db.Publisher_table);
            Books = new ObservableCollection<Book_table>(DataProvider.Ins.Db.Book_table);
            BooksList = new ObservableCollection<Book_table>(DataProvider.Ins.Db.Book_table);


            //Window開くコマンド
            BackBookCommand = new RelayCommand<Window>((p) => { return true; },
                (p) =>
                {
                    Book_Window book = new Book_Window();
                    p.Close();
                    book.ShowDialog();
                });
            BookAddWindowCommand = new RelayCommand<Window>((p) => { return true; },
              (p) =>
              {
                  LoadWindow();
                  Book_AddWindow bookadd = new Book_AddWindow();
                  p.Close();
                  bookadd.ShowDialog();
              });
            BookUpdateWindowCommand = new RelayCommand<Window>((p) =>
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
                  Book_UpdateWindow bookupdate = new Book_UpdateWindow();
                  p.Close();
                  bookupdate.ShowDialog();
              });
            BookListAndSearchWindowCommand = new RelayCommand<Window>(
                (p) =>
                { return true; },
            (p) =>
            {
                LoadWindow();
                BooksList = new ObservableCollection<Book_table>(DataProvider.Ins.Db.Book_table);
                Book_ListAndSearch_WIndow booklist = new Book_ListAndSearch_WIndow();
                p.Close();
                booklist.ShowDialog();
            });
            BookDeleteWindowCommand = new RelayCommand<Window>((p) =>
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
                    Book_DeleteWindow bookdelete = new Book_DeleteWindow();
                    p.Close();
                    bookdelete.ShowDialog();
                }
                );

            //機能処理コマンド
            BookAddCommand = new RelayCommand<Window>((p) =>
            {
                if (Selection_Category == null
                  || Selection_Publisher == null
                  || String.IsNullOrEmpty(Title)
                  || String.IsNullOrEmpty(Author))
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var book = DataProvider.Ins.Db.Book_table.FirstOrDefault(x =>
                   x.Book_Author == Author && x.Book_title == Title
                   && x.CategoryID == Selection_Category.CategoryID
                   && x.PublisherID == Selection_Publisher.PublisherID
                );
                if (book != null)
                {
                    MessageBox.Show("入力された本情報は概に登録されました！",
                        "報告", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var result = MessageBox.Show("登録してもよろしいでしょうか?", "確認",
                    MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Cancel)
                { return; }
                var category = DataProvider.Ins.Db.Book_table.Where(x => x.CategoryID == Selection_Category.CategoryID);
                int category_count;
                if (category != null)
                {
                    category_count = category.Count() + 1;
                }
                else
                {
                    category_count = 1;
                }
                var item = new Book_table()
                {
                    BookID = DateTime.Now.Year.ToString() + Selection_Category.CategoryID + category_count.ToString(),
                    Book_Author = Author,
                    Book_title = Title,
                    PublisherID = Selection_Publisher.PublisherID,
                    CategoryID = Selection_Category.CategoryID,
                    Book_BarCode = GenerateBarcode(DateTime.Now.Year.ToString() + Selection_Category.CategoryID + category_count.ToString())
                };
                DataProvider.Ins.Db.Book_table.Add(item);
                DataProvider.Ins.Db.SaveChanges();
                MessageBox.Show("登録完了！", "報告",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                OnPropertyChanged("Books");
                LoadWindow();
            });
            BookUpdateCommand = new RelayCommand<Window>((p) =>
            {
                if (Selection_Category == null
                  || Selection_Publisher == null
                  || String.IsNullOrEmpty(Title)
                  || String.IsNullOrEmpty(Author)
                  || Selection_Book == null)
                {
                    return false;
                }
                return true;
            },
(p) =>
{
    var book = DataProvider.Ins.Db.Book_table.FirstOrDefault(x =>
      x.BookID == Selection_Book.BookID
    );
    if (book == null)
    {
        MessageBox.Show("入力された本IDは概に存在しません！",
            "報告", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
    }
    var result = MessageBox.Show("更新してもよろしいでしょうか?", "確認",
        MessageBoxButton.OKCancel, MessageBoxImage.Question);
    if (result == MessageBoxResult.Cancel)
    { return; }


    book.Book_title = Title;
    book.Book_Author = Author;
    book.CategoryID = Selection_Category.CategoryID;
    book.PublisherID = Selection_Publisher.PublisherID;
    DataProvider.Ins.Db.SaveChanges();
    MessageBox.Show("更新完了！", "報告",
            MessageBoxButton.OK, MessageBoxImage.Information);
    OnPropertyChanged("Books");
    LoadWindow();
});
            BookSearchCommand = new RelayCommand<Window>((p) =>
            {
                if (Selection_Category == null
                  && String.IsNullOrEmpty(KeySearch))
                {
                    return false;
                }
                return true;
            },

          (p) =>
          {
              BooksList.Clear();
              var Searchlist = Books.Where(x =>
              (Selection_Category == null || x.CategoryID == Selection_Category.CategoryID) &&
              (string.IsNullOrEmpty(KeySearch) || (x.BookID.Contains(KeySearch)
              || x.Book_title.Contains(KeySearch)
              || x.Book_Author.Contains(KeySearch)
              || x.Publisher_table.PublisherName.Contains(KeySearch))
              ));
              if (Searchlist != null)
              {
                  foreach (var item in Searchlist)
                  {
                      BooksList.Add(item);
                  }
              }
              LoadWindow();

          });
            BookDeleteCommand = new RelayCommand<Window>((p) =>
            {
                if (Selection_Book == null)
                {
                    return false;
                }
                return true;
            },

          (p) =>
          {
              var stock_check = DataProvider.Ins.Db.Stock_table.Where(x => x.BookID == Selection_Book.BookID).Count();
              if (stock_check != 0)
              {
                  MessageBox.Show("選択された本IDは在庫データに連携されましたので、削除できません！", "報告",
                      MessageBoxButton.OK, MessageBoxImage.Information);
                  return;
              }
              var stockIn_check = DataProvider.Ins.Db.StockIn_Detail_table.Where(x => x.BookID == Selection_Book.BookID).Count();

              if (stockIn_check != 0)
              {
                  MessageBox.Show("選択された本IDは入庫データに連携されましたので、削除できません！", "報告",
                      MessageBoxButton.OK, MessageBoxImage.Information);
                  return;
              }
              var stockOut_check = DataProvider.Ins.Db.StockOut_Detail_table.Where(x => x.BookID == Selection_Book.BookID).Count();

              if (stockOut_check != 0)
              {
                  MessageBox.Show("選択された本IDは出庫データに連携されましたので、削除できません！", "報告",
                      MessageBoxButton.OK, MessageBoxImage.Information);
                  return;
              }
              var yoyaku_check = DataProvider.Ins.Db.Yoyaku_table.Where(x => x.Stock_table.BookID == Selection_Book.BookID).Count();

              if (yoyaku_check != 0)
              {
                  MessageBox.Show("選択された本IDは予約詳細データに連携されましたので、削除できません！", "報告",
                      MessageBoxButton.OK, MessageBoxImage.Information);
                  return;
              }
              var item = DataProvider.Ins.Db.Book_table.FirstOrDefault(x => x.BookID == Selection_Book.BookID);
              if (item == null)
              {
                  MessageBox.Show("入力された本IDは存在してません!", "報告",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                  return;
              }
              var result = MessageBox.Show("削除してもよろしいでしょうか？", "確認",
                  MessageBoxButton.OKCancel, MessageBoxImage.Question);
              if (result == MessageBoxResult.Cancel)
              {
                  return;
              }
              DataProvider.Ins.Db.Book_table.Remove(item);
              DataProvider.Ins.Db.SaveChanges();
              MessageBox.Show("削除完了!", "確認",
                  MessageBoxButton.OK, MessageBoxImage.Information);
              LoadWindow();

          });

        }
        private void ChooseImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (.jpeg;)|*.jpeg;"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                SelectedImagePath = openFileDialog.FileName;
                ImageFileName = Path.GetFileName(SelectedImagePath); 
            }
        }
        //本のバーコード作成
        private string GenerateBarcode(string data)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,  // Định dạng CODE_128 phổ biến cho barcode
                Options = new EncodingOptions { Height = 100, Width = 300, Margin = 1 }
            };

            using (var bitmap = writer.Write(data))
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return Convert.ToBase64String(stream.ToArray()); // Trả về chuỗi Base64
            }
        }
        public BitmapImage GenerateBarcodeImage(string barcodeBase64)
        {
            var bitmap = new BitmapImage();
            byte[] binaryData = Convert.FromBase64String(barcodeBase64);
            using (var stream = new MemoryStream(binaryData))
            {
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
            }
            return bitmap;
        }
        public void LoadWindow()
        {
            Books = new ObservableCollection<Book_table>(DataProvider.Ins.Db.Book_table);
            Selection_Book = null;
            Selection_Category = null;
            Selection_Publisher = null;
            Author = string.Empty;
            Title = string.Empty;
            KeySearch = string.Empty;
            CategoryName = string.Empty;
            PublisherName = string.Empty;
        }
    }

}
