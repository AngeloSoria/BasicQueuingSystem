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
    public partial class QueuingForm : Form
    {
        private readonly CashierClass cashier;
        private CashierWindowQueue cashierForm;
        private CustomerViewForm customerViewForm;

        public QueuingForm()
        {
            InitializeComponent();
            cashier = new CashierClass();
            cashierForm = new CashierWindowQueue();
            customerViewForm = new CustomerViewForm(cashierForm, this);


            cashierForm.Show();
            customerViewForm.Show();
            cashierForm.ResetQueueEvent += CashierForm_ResetQueueEvent;
        }

        private void CashierForm_ResetQueueEvent(object sender, EventArgs e)
        {
            cashier.Reset();
            lblQueue.Text = cashier.CashierGeneratedNumber("P - ");
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            lblQueue.Text = cashier.CashierGeneratedNumber("P - ");
            CashierClass.getNumberInQueue = lblQueue.Text;
            CashierClass.CashierQueue.Enqueue(CashierClass.getNumberInQueue);

            if (new FormState().isFormShown(cashierForm) == false)
            {
                cashierForm = new CashierWindowQueue();
                cashierForm.Show();
            }
        }
    }
}
