using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BasicQueuingSystem
{
    public partial class CashierWindowQueue : Form
    {
        private readonly System.Windows.Forms.Timer timer;
        public event EventHandler ResetQueueEvent; // Event to communicate with other form
        public event EventHandler UpdateQueueProgress;

        public CashierWindowQueue()
        {
            InitializeComponent();

            listCashierQueue.RetrieveVirtualItem += ListCashierQueue_RetrieveVirtualItem;
            listCashierQueue.VirtualListSize = 0;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void ListCashierQueue_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex < CashierClass.CashierQueue.Count)
            {
                string itemText = CashierClass.CashierQueue.ElementAt(e.ItemIndex).ToString();
                ListViewItem item = new ListViewItem(itemText);
                item.ForeColor = Color.Black;
                item.Font = new Font("Arial", 10, FontStyle.Bold);
                e.Item = item;
            }
            else
            {
                // Return an empty item for indices beyond the data
                e.Item = new ListViewItem();
            }
        }

        private void UpdateVirtualListSize()
        {
            listCashierQueue.VirtualListSize = CashierClass.CashierQueue.Count;
            UpdateQueueProgress?.Invoke(this, EventArgs.Empty);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            UpdateVirtualListSize();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CashierClass.CashierQueue.Count > 0)
            {
                CashierClass.CashierQueue.Dequeue();
                UpdateVirtualListSize(); // Update the VirtualListSize after dequeueing
                if (listCashierQueue.Items.Count > 1)
                {
                    listCashierQueue.RedrawItems(0, CashierClass.CashierQueue.Count - 1, false);
                }
            }
        }

        
        private void btnReset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Confirm resetting the queue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                CashierClass.CashierQueue.Clear();
                ResetQueueEvent?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
