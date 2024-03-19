using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie.Model
{
    internal class Answer
    {
        private string description;
        private bool isCorrect;
        public Answer(string description,bool isCorrect)
        {
            this.description = description;
            this.isCorrect = isCorrect;
        }
        public string Description { get { return description; } set { description = value; } }
        public bool IsCorrect { get {  return isCorrect; } set { isCorrect = value; } }    
    }
}
