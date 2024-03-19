using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicatie.Model;

namespace Aplicatie
{
    internal class MyFileReader
    {
        private string filePath;

        public MyFileReader(string filePath)
        {
            this.filePath = filePath;
        }

        public String FilePath {get{ return filePath; } set { filePath = value; } }

        public List<Test> ReadTestFromFile()
        {
            Console.WriteLine(filePath);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file does not exist", filePath);
            }
            List<Test> result = new List<Test>();//Initializez rezultatul (lista de teste)
            //Initializez testul si intrebarea curenta
            Test currentTest = null;
            Question currentQuestion = null;
            using (StreamReader sr = new StreamReader(filePath)) { //Creaza un streamReader
                while(!sr.EndOfStream) {//cat timp nu sutem la final 
                    string line = sr.ReadLine();//citim linie cu linie 
                    if (line == null)
                    {
                        break;
                    }
                    //Console.WriteLine(line);
                    if (line.StartsWith("Test:"))
                    {
                        currentTest = new Test (int.Parse(line.Substring(5).Trim()));//trim taie spatiile
                        result.Add (currentTest);//adaug la lista de  teste
                    }
                    if (line.StartsWith("Question:"))
                    {
                        currentQuestion = new Question(line.Substring(9).Trim(),"",new List<Answer>());//o noua intrebare 
                        currentTest?.Questions.Add(currentQuestion);//Adaug  la lista de intrebari a testului curent
                    }
                    if (line.StartsWith("Answer:"))
                    {
                        bool isCorrect;
                        char c=line.ElementAt(8);
                        if (c == 'T')
                        {
                            isCorrect = true;
                        }
                        else
                        {
                            isCorrect = false;
                        }
                        currentQuestion?.Answers.Add(new Answer(line.Substring(9).Trim(),isCorrect));//substring = ia stringul de la elementul al 7 lea la final 
                                                                                                    //Adaug noul raspuns la lista de raspunsuri a intrebarii curente
                    }
                    if (line.StartsWith("Image:"))
                    {
                        if (currentQuestion == null)
                        {
                            break;
                        }
                        currentQuestion.Image = line.Substring(6).Trim();//Adaug imaginea intreabarii
                    }

                }
            }
            return result; //returnez lista de teste
        }
    }
}