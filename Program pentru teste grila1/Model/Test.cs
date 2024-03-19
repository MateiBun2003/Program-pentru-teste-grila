using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie.Model
{
    internal class Test
    {
        private int id;
        private List<Question> questions;

        public Test(int id)
        {
            this.id = id;
            this.questions = new List<Question>();
        }

        public int Id { get { return id; } set { id = value; } }
        public List<Question> Questions { get { return questions; } set { questions = value; } }
    }
}
