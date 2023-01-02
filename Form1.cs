using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week_4_Task_B
{
    public partial class box : Form
    {
        Activity[] activityList;
        Activity[] availableActivities;
        int z;
        int size;

        public box()
        {
            size = 10;
            InitializeComponent();
            activityList = new Activity[size];
            z = 0;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {         
            startBox.Text = "2400";
            endBox.Text = "2400";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(startBox.Text) > 2400 || Convert.ToInt32(endBox.Text) > 2400 || Convert.ToInt32(startBox.Text) > Convert.ToInt32(endBox.Text))
            {
                PopUp popup = new PopUp();
                DialogResult dialogresult = popup.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    popup.Dispose();
                }
            }
            else
            {
                if (Convert.ToInt32(startBox.Text) < 2400 || Convert.ToInt32(endBox.Text) < 2400 || descBox.Text != null)
                {
                    Activity myActivity = new Activity(descBox.Text, Convert.ToInt32(startBox.Text), Convert.ToInt32(endBox.Text));
                    activityList[z] = myActivity;
                    listBox.Items.Add(activityList[z].ToString());
                    listBox.Sorted = true;
                    z++;
                }
                else
                {
                    startBox.Clear();
                    endBox.Clear();
                    descBox.Clear();
                }
            }
            
        }

        private void startBox_Enter(object sender, EventArgs e)
        {
            if (startBox.Text == "2400")
            {
                startBox.Clear();
            }
        }

        private void startBox_Leave(object sender, EventArgs e)
        {
            if (startBox.Text.Trim() == "")
            {
                startBox.Text = "2400";
            }
        }

        private void endBox_Enter(object sender, EventArgs e)
        {
            if (endBox.Text == "2400")
            {
                endBox.Clear();
            }
        }

        private void endBox_Leave(object sender, EventArgs e)
        {
            if (endBox.Text.Trim() == "")
            {
                endBox.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int j = 0;
            Activity.InsertionSort(activityList);
            availableActivities = new Activity[size];
            listBox.Items.Clear();
            for (int i = 0; i < activityList.Length-1; i++)
            {
                if (activityList[i+1] != null)
                {
                    if (activityList[i].EndTime <= activityList[i + 1].StartTime)
                    {
                        availableActivities[j] = activityList[i];
                        listBox.Items.Add(availableActivities[j]);
                        j++;
                        availableActivities[j] = activityList[i+1];
                    }
                    
                }
            }
            listBox.Items.Add(availableActivities[j]);
        }
    }
}
