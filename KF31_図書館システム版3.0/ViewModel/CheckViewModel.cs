using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KF31_図書館システム版3._0.ViewModel
{
     class CheckViewModel
    {
        //住所チェック
        public static bool IsValidAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return false;

            if (address.Length < 10)
                return false;

            var regex = @"^(?=.*[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}a-zA-Z])[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}a-zA-Z0-9\s\-.,、]+$";

            return System.Text.RegularExpressions.Regex.IsMatch(address, regex);

        }
        //社員名チェック
        public static bool IsJapaneseOrEnglishOnly(string input)
        {
            var regex = @"^[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}a-zA-Z\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(input, regex);
        }

        // メールチェック
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            var regex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, regex);
        }
    }
}
