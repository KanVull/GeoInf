using System;
using System.Runtime.InteropServices;
using Ingeo;
using System.Windows.Forms;

namespace IngeoClassLibrary
{
    // Модуль подключения ГИС
    [ComVisible(true)]
    public class MyModule
    {
        mainForm newForm; 

        public IIngeoApplication _fApplication;

        public void Init(IIngeoApplication app)
        {
            _fApplication = app;
        }

        public void Done()
        {
            _fApplication = null;
        }
        public void SelectionObjectsChange()
        {
            if (newForm != null)
                newForm.UpdateData();
        }

        // Метод отображения формы
        void ShowIngeoPopupForm(IIngeoApplication ingeo)
        {
            if (ingeo == null)
                MessageBox.Show("Модуль не инициализирован!");
            else
            {
                newForm = new mainForm(ingeo);
                newForm.Show(new IngeoMainWindowHandle(ingeo));
            }
        }

        public void ShowPopupForm()
        {
            ShowIngeoPopupForm(_fApplication);
        }
    }
    // Класс обработчика главной формы ГИС
    public class IngeoMainWindowHandle : IWin32Window
    {
        private readonly IntPtr _fIngeoMainWindowHandle;

        public IngeoMainWindowHandle(IIngeoApplication ingeo)
        {
            _fIngeoMainWindowHandle = new IntPtr(ingeo.MainWindow.Handle);
        }

        IntPtr IWin32Window.Handle
        {
            get { return _fIngeoMainWindowHandle; }
        }
    }
}
