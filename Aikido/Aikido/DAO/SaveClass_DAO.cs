using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aikido.DAO.Model;
namespace Aikido.DAO
{
    public class SaveClass_DAO
    {
        public void saveClass(Dictionary<int,dgvClass_ViewModel> datadgvAdd, Dictionary<int,dgvClass_ViewModel> datadgvUpdate)
        {
            using (var dataContext = new AccessDB_DAO())
            {
                 
                int IdClass;
                try
                {
                  IdClass= dataContext.Classes.Max(s => s.ID_Class);
                }
                catch { IdClass= 0; }
                foreach (var dataClass in datadgvAdd)
                {
                    Class data = new Class();
                    data.ID_Class = ++IdClass;
                    data.Class_Name = dataClass.Value.txtName;
                    data.Start_Time = DateTime.Parse(dataClass.Value.txtStartTime);
                    data.End_Time = DateTime.Parse(dataClass.Value.txtFinishTime);
                    data.Monday = dataClass.Value.cbMonday;
                    data.Tuesday = dataClass.Value.cbTuesday;
                    data.Wednesday = dataClass.Value.cbWednesday;
                    data.Thursday = dataClass.Value.cbThursday;
                    data.Friday = dataClass.Value.cbFriday;
                    data.Saturday = dataClass.Value.cbSarturday;
                    data.Sunday = dataClass.Value.cbSunday;
                    data.Day_Create = DateTime.Now;
                    data.Day_Update = DateTime.MinValue;
                    data.Delete_Flag = false;
                    dataContext.Classes.Add(data);
                    dataContext.SaveChanges();
                }
                foreach (var dataClass in datadgvUpdate)
                {
                    Class data = dataContext.Classes.FirstOrDefault(s => s.ID_Class == dataClass.Value.ID);
                    data.Class_Name = dataClass.Value.txtName;
                    data.Start_Time = DateTime.Parse(dataClass.Value.txtStartTime);
                    data.End_Time = DateTime.Parse(dataClass.Value.txtFinishTime);
                    data.Monday = dataClass.Value.cbMonday;
                    data.Tuesday = dataClass.Value.cbTuesday;
                    data.Wednesday = dataClass.Value.cbWednesday;
                    data.Thursday = dataClass.Value.cbThursday;
                    data.Friday = dataClass.Value.cbFriday;
                    data.Saturday = dataClass.Value.cbSarturday;
                    data.Sunday = dataClass.Value.cbSunday;
                    data.Day_Update = DateTime.Now;
                    dataContext.Classes.Update(data);
                    dataContext.SaveChanges();
                }
            }
        }
    }
}
