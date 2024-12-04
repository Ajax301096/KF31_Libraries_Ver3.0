using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KF31_図書館システム版3._0.ViewModel
{
    class Employ_Data : BaseViewModel
    {
        private static Employ_Data _instance;
        private static readonly object _lock = new object();

        private string _Em_ID { get; set; }
        public string Em_ID { get => _Em_ID; set { _Em_ID = value; OnPropertyChanged(); } }
        private string _Em_UserName { get; set; }
        public string Em_UserName { get => _Em_UserName; set { _Em_UserName = value; OnPropertyChanged(); } }
        private string _Em_Password { get; set; }
        public string Em_Password { get => _Em_Password; set { _Em_Password = value; OnPropertyChanged(); } }
        private string _Em_DisplayName { get; set; }
        public string Em_DisplayName { get => _Em_DisplayName; set { _Em_DisplayName = value; OnPropertyChanged(); } }
        private string _Possition_Name { get; set; }
        public string Possition_Name { get => _Possition_Name; set { _Possition_Name = value; OnPropertyChanged(); } }
        private string _Possition_ID { get; set; }
        public string Possition_ID { get => _Possition_ID; set { _Possition_ID = value; OnPropertyChanged(); } }
        private string _EmQRCode { get; set; }
        public string EmQRCode { get => _EmQRCode; set { _EmQRCode = value; OnPropertyChanged(); } }
        private DateTime _Birthday { get; set; }
        public DateTime Birthday { get => _Birthday; set { _Birthday = value; OnPropertyChanged(); } }
        private DateTime _Hiredate { get; set; }
        public DateTime Hiredate { get => _Hiredate; set { _Hiredate = value; OnPropertyChanged(); } }
        private string _Email { get; set; }
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _Address { get; set; }
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        private string _LibratyID { get; set; }
        public string LibratyID { get => _LibratyID; set { _LibratyID = value; OnPropertyChanged(); } }

        private Employ_Data() { }

        public static Employ_Data Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Employ_Data();
                    }
                    return _instance;
                }
            }
        }

    }
}