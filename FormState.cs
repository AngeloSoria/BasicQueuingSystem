using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicQueuingSystem
{
    internal class FormState
    {
        public bool isFormShown(Form argForm)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == argForm.Name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
