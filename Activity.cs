using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_4_Task_B
{
    class Activity : IComparable
    {
        private string description;
        private int startTime;
        private int endTime;

        public Activity(string description, int startTime, int endTime)
        {
            this.description = description;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public string Description
        {
            set { this.description = value; }
            get { return description; }
        }
        public int StartTime
        {
            set { this.startTime = value; }
            get { return startTime; }
        }
        public int EndTime
        {
            set { this.endTime = value; }
            get { return endTime; }
        }
        static public void InsertionSort(Activity[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != null)
                {
                    Activity value = a[i];
                    int j = i;

                    for (; j > 0 && (value.CompareTo(a[j - 1]) < 0); j--)
                    {
                        a[j] = a[j - 1];
                    }
                    a[j] = value;
                }
            }
        }

        public override string ToString()
        {
            return Description + " Time:" +  StartTime + " - " + EndTime;
        }

        public int CompareTo(object obj)
        {
            Activity other = (Activity)obj;
            return StartTime.CompareTo(other.StartTime);
        }
    }
}
