using Birthday_guide.Models;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Birthday_guide
{
    internal class DBConnection
    {
        string conn;

        public DBConnection()
        {
            conn = "Server=DESKTOP-MV43C0T;Database=Contacts;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public DBConnection(string conn)
        {
            this.conn = conn;
        }

        public List<Friend> GetListFriends()
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                return db.GetAll<Friend>().ToList(); ;
            }
        }

        public Friend GetFriend(int Id)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                return db.Get<Friend>(Id);
            }
        }

        public void SaveFriend (Friend newFriend)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                db.Insert(newFriend);
            }
        }

        public void SaveListFriends(List<Friend> Friends)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                db.Insert(Friends);
            }
        }

        public void UpdateFriend(Friend newFriend)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                db.Update(newFriend);
            }
        }

        public void DeleteFriend (int IdFriend)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                db.Delete(new Friend { Id = IdFriend });
            }
        }

       
    }
}
