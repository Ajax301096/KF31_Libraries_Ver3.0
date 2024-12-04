using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KF31_図書館システム版3._0.Model
{
    public class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new DataProvider();
                }
                return _ins;
            }
            set
            {
                _ins = value;

            }
        }
        public KF31_LliM5_DataBaseEntities Db { get; set; }//プロパティの基本設計
        private DataProvider()
        {
            Db = new KF31_LliM5_DataBaseEntities();
        }

    }
}

