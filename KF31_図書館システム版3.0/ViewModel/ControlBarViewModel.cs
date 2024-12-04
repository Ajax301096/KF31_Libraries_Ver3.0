using KF31_図書館システム版3._0.Main_Login_Model;
using KF31_図書館システム版3._0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace KF31_図書館システム版3._0.ViewModel
{
    public class ControlBarViewModel : BaseViewModel
    {

        #region command
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MaximizeWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand HomeBackCommand { get; set; }
        public ICommand AccountCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        #endregion

        public ControlBarViewModel()
        {
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetParent(p);
                var w = window as Window;
                if (w != null)
                {
                    var employ = DataProvider.Ins.Db.Employee_table.FirstOrDefault(x => x.EmployID == Employ_Data.Instance.Em_ID);
                    if (employ != null)
                    {
                        employ.Em_Lastlogin = DateTime.Now;
                        DataProvider.Ins.Db.SaveChanges();
                    }
                    w.Close();
                }
            });
            MaximizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetParent(p);
                var w = window as Window;
                if (w != null)
                {
                    if (w.WindowState != WindowState.Maximized)
                    {
                        w.WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        w.WindowState = WindowState.Normal;
                    }
                }
            });
            MinimizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetParent(p);
                var w = window as Window;
                if (w != null)
                {
                    if (w.WindowState != WindowState.Minimized)
                    {
                        w.WindowState = WindowState.Minimized;
                    }
                }
            });
            MouseMoveWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetParent(p);
                var w = window as Window;
                if (w != null)
                {
                    w.DragMove();
                }
            });
            HomeBackCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) => {

                FrameworkElement window = GetParent(p);
                var w = window as Window;
                if (w != null)
                {
                    MainWindow mainWindow = new MainWindow();
                    w.Close();
                    mainWindow.ShowDialog();
                }


            });
            AccountCommand = new RelayCommand<UserControl>((p) => { return true; },
                    (p) =>
                    {
                        Account_Window acc = new Account_Window();
                        acc.ShowDialog();
                    });
            LogOutCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
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
                FrameworkElement window = GetParent(p);
                var w = window as Window;
                if (w != null)
                {
                    Login_Window loginwindow = new Login_Window();
                    w.Close();
                    loginwindow.ShowDialog();
                }

            });
        }

        FrameworkElement GetParent(UserControl p)
        {
            FrameworkElement parent = p;
            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }
            return parent;
        }
    }
}
