using Birthday_guide.Models;
using System;
using System.Windows.Forms;

namespace Birthday_guide
{
    public partial class Form2 : Form
    {
        public Friend friend;
        public string name;
        public DateTime date;
        public bool AddChange = true;   //If true than update else change
        DBConnection conn = new DBConnection();
        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            Date.Format = DateTimePickerFormat.Custom;
            Date.CustomFormat = "ddd   dd.MM.yyyy";
            Name.Text = friend.Name;
            Date.Value = friend.Birthday;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (AddChange)
            {
                if (!string.IsNullOrEmpty(Name.Text) && Date.Value != null)
                {
                    friend.Name = Name.Text;
                    friend.Birthday = Date.Value;
                    conn.UpdateFriend(friend);
                }
                else
                    MessageBox.Show("You need to fill in all fields of the form!");
            }
            else
            {

                if (!string.IsNullOrEmpty(Name.Text) && Date.Value != null)
                {
                    friend = new Friend();
                    friend.Name = Name.Text;
                    friend.Birthday = Date.Value;
                    conn.SaveFriend(friend);
                }
                else
                    MessageBox.Show("You need to fill in all fields of the form!");
            }
            this.Close();
        }

    }
}
