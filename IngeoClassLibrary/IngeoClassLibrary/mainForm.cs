using System.Windows.Forms;
using Ingeo;

namespace IngeoClassLibrary
{
    public partial class mainForm : Form
    {
        public IIngeoApplication FApplication;
        // конструктор главной формы
        public mainForm(IIngeoApplication fApplication)
        {
            FApplication = fApplication;
            InitializeComponent();
        }
    }
}

