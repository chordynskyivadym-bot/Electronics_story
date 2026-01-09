using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics_store
{
    public struct User
    {
        public string Email;
        public string PasswordHash;
        public int Id;

        /// <summary>
        /// Перетворює об'єкт товару у рядок формату CSV для запису у файл.
        /// </summary>
        /// <returns>Рядок, де поля розділені комами.</returns>
        public string ToCsv()
        {
            return $"{Id},{Email},{PasswordHash}";
        }
    }
}
