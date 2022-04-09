using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class Method
    {
       public string Format(string slovo)
        {
            char[] form = slovo.ToCharArray();
            form[0] = char.ToUpper(form[0]);
            return String.Concat<char>(form);
        }
    }
}