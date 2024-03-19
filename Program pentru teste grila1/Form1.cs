using Aplicatie.Model;
using System;
using System.Windows.Forms;

namespace Program_pentru_teste_grila
{
    public partial class Form1 : Form
    {
        //Initializez form cu un Layout Panel si un buton de start
        private FlowLayoutPanel flowLayoutPanel1;
        public Form1()
        {
            InitializeComponent();
            flowLayoutPanel1 = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown
            };

            Controls.Add(flowLayoutPanel1);
            var button = new Button
            {
                Text = "Start Test",
                Width = 100,
                Height = 30
            };

            button.Click += TestButton_Click;       //Ii adaug o functie  TestButton_Click care va fi apelata cand el va fi apasat
            flowLayoutPanel1.Controls.Add(button);
        }
        private void TestButton_Click(object sender,EventArgs e)  //Imi creeaza un form 2
        {
            var button = (Button)sender;
            var form2 = new Form2();
            form2.ShowDialog();
        }
        private void InitializeazaComponente()
        {
            var button = new Button
            {
                Text = $"Start Test",
                Width = 100,
                Height = 30
            };
            button.Click += TestButton_Click;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}