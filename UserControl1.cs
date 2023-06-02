using Birthday_guide.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Birthday_guide
{
    public partial class UserControl1 : UserControl
    {
        DBConnection conn = new DBConnection();
        public UserControl1()
        {
            InitializeComponent();
        }

        public UserControl1(Friend friend) : this()
        {
            lName.Text = friend.Name;
            lBirthday.Text = friend.DateString();
            lMonth.Text = "";
            lMonth.Font = new Font("Arial", 11);
        }

        public UserControl1(int month) : this()
        {
            string [] monthes = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            lName.Text = "";
            lBirthday.Text = "";
            lMonth.Text = monthes[month - 1];
            lMonth.Font = new Font("Arial", 11, FontStyle.Bold);
        }

        private void UserControl1_MouseLeave1(object sender, System.EventArgs e)
        {
            if (lMonth.Text == "")
            {
                this.BackColor = System.Drawing.SystemColors.Control;
                this.BorderStyle = BorderStyle.None;
            }
        }

        private void UserControl1_MouseHover1(object sender, System.EventArgs e)
        {
            if (lMonth.Text == "")
            {
                this.BackColor = System.Drawing.SystemColors.ControlDark;
                this.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void UserControl1_Click1(object sender, System.EventArgs e)
        {
            if (lMonth.Text == "")
            {
                DialogResult res = MessageBox.Show("if you want to delete item press Yes if you want to change press No", "Message", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    DialogResult res1 = MessageBox.Show("Do you really want to delete this friend?", "Message", MessageBoxButtons.YesNo);
                    if (res1 == DialogResult.Yes)
                    {
                        List<Friend> friends = conn.GetListFriends();
                        int IdFriend = friends.Find(ee => ee.Name.Equals(lName.Text)).Id;
                        conn.DeleteFriend(IdFriend);
                    }
                }
                else
                {
                    Form2 newForm = new Form2();
                    List<Friend> friends = conn.GetListFriends();
                    newForm.friend = friends.Find(ee => ee.Name.Equals(lName.Text));
                    newForm.AddChange = true;
                    newForm.Show();
                }
            }
        }
    }
}
