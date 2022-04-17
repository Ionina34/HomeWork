using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Exam_2___Quiz
{
    class Methods
    {
        public void WriteUsers(string file,Users users)
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write))
                bin.Serialize(fs, users);
        }
        public Users ReadUsers(string file)
        {
            BinaryFormatter bin = new BinaryFormatter();
            Users users = null;
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Read))
                users = (Users)bin.Deserialize(fs);
            return users;
        }
    }
}
