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

        public string ToCsv()
        {
            return $"{Id},{Email},{PasswordHash}";
        }
    }
}
