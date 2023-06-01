using Birthday_guide.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Birthday_guide
{
    public partial class Form1 : Form
    {
        Panel panel;
        DBConnection conn = new DBConnection();
        List<Friend> friends = new List<Friend>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel = new Panel();
            panel.SuspendLayout();
            panel.Location = new Point(5, 50);
            panel.Size = new Size(this.Width - 160, this.Height - 100);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.AutoScroll = true;
            panel.VerticalScroll.Enabled = true;
            panel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            Controls.Add(panel);

            comboBox1.SelectedItem = "All";
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            friends = conn.GetListFriends();
            friends = MonthSorted(friends);

            Show(friends);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Friend> newList = new List<Friend>();
            if (comboBox1.SelectedIndex < 12)
            {
                foreach (Friend friend in friends)
                {
                    if (friend.Birthday.Month == comboBox1.SelectedIndex + 1)
                        newList.Add(friend);
                }
            }
            else
                newList = friends;
            if (newList.Count == 0)
                panel.Controls.Clear();
            else
                Show(newList);
        }

        private void Show(List<Friend> friends)
        {
            friends = MonthSorted(friends);
            panel.Controls.Clear();
            int y = 0;
            int month = 0;
            var item = new UserControl1(friends[0].Birthday.Month);
            item.Location = new Point(0, (y * item.Height));
            item.BackColor = SystemColors.ControlLight;
            item.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel.Controls.Add(item);
            y++;
            month = friends[0].Birthday.Month;
            for (int i = 0; i < friends.Count; i++)
            {
                if (month == friends[i].Birthday.Month)
                {
                    item = new UserControl1(friends[i]);
                    item.Location = new Point(0, (y * item.Height));
                    item.BackColor = SystemColors.Control;
                    item.Anchor = AnchorStyles.Left | AnchorStyles.Right;

                    y++;
                    panel.Controls.Add(item);
                }
                else
                {
                    item = new UserControl1(friends[i].Birthday.Month);
                    item.Location = new Point(0, (y * item.Height));
                    item.BackColor = SystemColors.ControlLight;
                    item.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    panel.Controls.Add(item);
                    y++;
                    month = friends[i].Birthday.Month;
                    item = new UserControl1(friends[i]);
                    item.Location = new Point(0, (y * item.Height));
                    item.BackColor = SystemColors.Control;
                    item.Anchor = AnchorStyles.Left | AnchorStyles.Right;

                    y++;
                    panel.Controls.Add(item);
                }
            }
        }

        private List<Friend> MonthSorted(List<Friend> friends)
        {
            List<Friend> result = new List<Friend>();
            for (int i = 1; i <= 12; i++)
            {
                foreach(var item in friends)
                {
                    if (item.Birthday.Month == i)
                        result.Add(item);
                }
            }
            return result;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.AddChange=false;
            newForm.friend = new Friend();
            newForm.Show();
            newForm.Deactivate += (s, ee) =>
            {
                friends.Clear();
                friends = conn.GetListFriends();
                Show (friends);
            };
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
