using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie.Model
{
    internal class Question
    {
        private string description;
        private string image;
        private List<Answer> answers;

        public Question(string description, string image, List<Answer> answers)  //Constructor
        {
            this.description = description;
            this.image = image;
            this.answers = answers;
        }
        public string Description { get { return description; } set { description = value; } }
        public string Image { get { return image; } set { image = value; } }
        public List<Answer> Answers { get { return answers; } set { answers = value; } }
    }
}
