using System;
using System.Windows.Forms;
using Ingeo;

namespace IngeoClassLibrary
{
    public partial class mainForm : Form
    {
        public static IngeoControl ingeoControl;

        public mainForm(IIngeoApplication fApplication)
        {
            ingeoControl = new IngeoControl(fApplication);
            InitializeComponent();
        }
        // Обработчик клика по кнопке: Получить идентификаторы объектов
        private void buttonGetObjects_Click(object sender, EventArgs e)
        {
            listBoxObjects.Items.Clear();
            listBoxObjects.Items.AddRange
                (ingeoControl.GetMapsInfo().ToArray());
        }
        // Обработчик клика по кнопке: Идентификатор выделенного объекта
        private void buttonGetSelected_Click(object sender, EventArgs e)
        {
            string status;
            textBoxIDSelectedObject.Text =
                ingeoControl.GetSelectObjectId(out status);
            MessageBox.Show(status);
        }
    }

}

