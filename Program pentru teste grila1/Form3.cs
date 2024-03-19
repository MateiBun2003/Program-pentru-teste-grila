using Aplicatie.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_pentru_teste_grila
{
    public partial class Form3 : Form
    {
        private FlowLayoutPanel flowLayoutPanel1;
        internal Form3(Test test)
        {
            InitializeComponent();
            InitializeazaComponente();
            LoadTest(test);
        }
        private void InitializeazaComponente()
        {
            flowLayoutPanel1 = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown
            };
            Controls.Add(flowLayoutPanel1);
        }
        private void LoadTest(Test test)
        {
            //Afisez id testului
            var textField = new TextBox
            {
                Text = $"Test number {test.Id}",
                ReadOnly = true,                   // Fac caseta de text doar pentru citire
                BorderStyle = BorderStyle.None,
                BackColor = this.BackColor,       // Setez culoarea de fundal pentru a se potrivi cu fundalul formularului
                TextAlign = HorizontalAlignment.Center,  // Alinierea centrală a textului
                Width = 800,
                Height = 30
            };
            flowLayoutPanel1.Controls.Add(textField);
            foreach (var question in test.Questions)   //Pentru fiecare intrebare ii afisez descrierea
            {
                var questionField = new TextBox
                {
                    Text = $"Question: {question.Description}",
                    ReadOnly = true,         // Fac caseta de text doar pentru citire
                    BorderStyle = BorderStyle.None,
                    BackColor = this.BackColor,     // Setez culoarea de fundal pentru a se potrivi cu fundalul formularului
                    TextAlign = HorizontalAlignment.Center, // Alinierea centrală a textului
                    Width = 800,
                    Height = 30
                };
                flowLayoutPanel1.Controls.Add(questionField);
                //Adaug un PictureBox pentru afisarea imaginii
                PictureBox pictureBox = new PictureBox
                {
                    Width = 800,
                    Height = 150,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                // Setez imaginea în functie de calea fisierului
                if (!string.IsNullOrEmpty(question.Image) && File.Exists(question.Image))
                {
                    pictureBox.Image = Image.FromFile(question.Image);
                }

                flowLayoutPanel1.Controls.Add(pictureBox);
                foreach (var answer in question.Answers) {
                    //Adaug un CheckBox pentru ca utilizatorul sa bifeze raspunsul corect 
                    CheckBox checkBox = new CheckBox();
                    checkBox.Text = $"{answer.Description}";
                    checkBox.Tag = question;
                    checkBox.TextAlign=ContentAlignment.MiddleCenter;
                    checkBox.Anchor = AnchorStyles.None;
                    flowLayoutPanel1.Controls.Add(checkBox);
                }
                //Adaug un CheckBox pentru ca utilizatorul sa isi poate scrie raspunsul
            }
            var button = new Button   // Butonul de apasat la sfarsitul testului
            {
                Text = "Submit",
                Tag = test,//asociez obiectul testul cu butonul sau
                Width = 800,
                Height = 60
            };
            button.Click += TestButton_Click;
            flowLayoutPanel1.Controls.Add(button);
        }
        private void TestButton_Click(object sender, EventArgs e)  //Calculez scorul si ii afisez un mesaj
        {
            float score = 0;  //nr de intrebari corecte
            int nrQuestion = 0; // Numarul total de intrebari

            var test = (Test)((Button)sender).Tag; //Obtin testul
            foreach (var question in test.Questions)
            {
                nrQuestion++; //Incrementam numarul total de intrebari
                float nrCorectAnswer = 0;
                foreach (var answer in question.Answers)
                {
                    if (answer.IsCorrect)
                    {
                        nrCorectAnswer++;
                    }
                }
                float scorepernrCorectAnswer = 1 / nrCorectAnswer;
                //Selectam din Layout Panel raspunsul corespunzator intrebarii
                var answerFields = flowLayoutPanel1.Controls.OfType<CheckBox>()
                      .Where(checkBox => checkBox.Tag == question);
                int count1 = 0;
                foreach(var answer in answerFields)
                {
                    if (answer.Checked)
                    {
                        count1++;
                    }
                }
                if(count1 >nrCorectAnswer)
                {
                    continue;
                }
                foreach(var answerField in answerFields)
                {
                   bool isCorect = answerField.Checked && question.Answers.Any(answer =>
                            string.Equals(answer.Description, answerField.Text, StringComparison.OrdinalIgnoreCase) && answer.IsCorrect);
                    if(isCorect) 
                    {
                        score+=scorepernrCorectAnswer;
                    }
                }
            }
            MessageBox.Show($"Your score is {score}/{nrQuestion}!");  // $ e folosit pentru a pune o valoare in mesajul  afisat la final
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
