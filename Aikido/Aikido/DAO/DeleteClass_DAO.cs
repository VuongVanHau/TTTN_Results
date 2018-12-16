using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikido.DAO
{
    public class DeleteClass_DAO
    {
        public void deleteClass(int ID)
        {
            using (var dataContext = new AccessDB_DAO())
            {

                Class upClass = dataContext.Classes.FirstOrDefault(s => s.ID_Class == ID);
                upClass.Delete_Flag = true;
                dataContext.Classes.Update(upClass);
                dataContext.SaveChanges();
            }
        }
    }
}
