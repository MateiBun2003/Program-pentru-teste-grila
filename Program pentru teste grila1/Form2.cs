using Aplicatie;
using Aplicatie.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_pentru_teste_grila
{
    public partial class Form2 : Form
    {
        private FlowLayoutPanel flowLayoutPanel1;
        public Form2()
        {
            InitializeComponent();
            InitializeazaComponente();
            LoadTest();
        }
        private void InitializeazaComponente() {
            //Initializeaza Layout Panel
            flowLayoutPanel1 = new FlowLayoutPanel
            {
                //Optiunile pentru Layout Panel
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown
            };
            Controls.Add(flowLayoutPanel1);
                
        }
        private void LoadTest()
        {
            //Folosesc FileReader  ca sa obtinem testele din input
            MyFileReader filereader = new MyFileReader("Input.txt");
            List<Test> tests = filereader.ReadTestFromFile();
            foreach (var test in tests)
            {
                //Pentru fiecare test creez un buton
                var button = new Button
                {
                    Text = $"Test {test.Id}",
                    Tag=test,//asociez obiectul test cu butonul sau
                    Width = 40,
                    Height = 80
                };
                button.Click += TestButton_Click;
                flowLayoutPanel1.Controls.Add(button);//Adaug butonul la Layout Panel
            }
        }
        private void TestButton_Click(object sender, EventArgs e)
        {
            var button =(Button) sender; 
            var selectedTest=(Test) button.Tag;
            //Am obtinut testul corespunzator butonului apasat
            var testDetailsForm = new Form3(selectedTest);// Creez un form 3 si ii pasez testul corespunzator
            testDetailsForm.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
