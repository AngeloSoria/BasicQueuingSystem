using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicQueuingSystem
{
    public partial class CustomerViewForm : Form
    {
        private CashierWindowQueue cashierForm;
        private QueuingForm queuingForm;
        public CustomerViewForm(CashierWindowQueue cf, QueuingForm qf)
        {
            InitializeComponent();

            // Get old instances.
            cashierForm = cf;
            queuingForm = qf;

            // Events subscription
            cashierForm.UpdateQueueProgress += CashierForm_UpdateQueueProgress;
            cashierForm.ResetQueueEvent += CashierForm_UpdateQueueProgress;
        }

        private void CashierForm_UpdateQueueProgress(object sender, EventArgs e)
        {
            // doesnt get invoked.
            lblCurrentServing.Text = CashierClass.CashierQueue.Count > 0 ? CashierClass.CashierQueue.Peek() : "---";
        }
    }
}
