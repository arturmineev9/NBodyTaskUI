using NBodyTaskContract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBodyTaskGUI
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }


        private bool CheckComplianceContract(Assembly realizationAssembly)
        {
            // Получаем все интерфейсы из первого проекта
            var interfaces = new Type[6];
            interfaces[0] = typeof(IBody); interfaces[1] = typeof(IBodyMover);
            interfaces[2] = typeof(IForceCalculator); interfaces[3] = typeof(IMyPoint);
            interfaces[4] = typeof(INBodySolver); interfaces[5] = typeof(IPhysics);

            // Получаем все нестатические классы из второго проекта
            var types = realizationAssembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && !t.IsSealed);

            foreach (var interfaceType in interfaces)
            {
                bool isImplemented = types.Any(t => interfaceType.IsAssignableFrom(t));

                if (!isImplemented)
                {
                    return false;
                }
            }

            return true;
        }

        private void buttonLoadDll_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "DLL Files (*.dll)|*.dll",
                Title = "Выберите файл DLL"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dllPath = openFileDialog.FileName;

                // Загружаем сборку
                Assembly realizationAssembly = Assembly.LoadFile(dllPath);

                // Проверяем сборку
                bool isCompliant = CheckComplianceContract(realizationAssembly);

                if (isCompliant)
                {
                    // Если сборка соответствует контракту, переходим к следующей форме
                    Form1 form1 = new Form1(realizationAssembly);
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    // Если сборка не соответствует контракту, показываем сообщение об ошибке
                    MessageBox.Show("Сборка не соответствует контракту. Пожалуйста, выберите другую сборку.");
                }
            }
        }
    }
}