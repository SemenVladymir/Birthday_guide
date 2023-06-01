using System;

namespace Birthday_guide.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }

        public Friend()
        {
            Id = 0;
            Name = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            Birthday = DateTime.Now;
        }

        public Friend(int id, string name, string address, string phone, string email, DateTime birthday)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
            Birthday = birthday;  
        }

        public string DateString()
        {
            string date;
            if (Birthday.Day > 9 && Birthday.Month > 9)
                date = $"{Birthday.Day}.{Birthday.Month}.{Birthday.Year}";
            else if (Birthday.Month > 9)
                date = $"0{Birthday.Day}.{Birthday.Month}.{Birthday.Year}";
            else if (Birthday.Day > 9)
                date = $"{Birthday.Day}.0{Birthday.Month}.{Birthday.Year}";
            else
                date = $"0{Birthday.Day}.0{Birthday.Month}.{Birthday.Year}";
            return date;
        }
    }
}
