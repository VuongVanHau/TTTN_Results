using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikido.DAO
{
    public class SaveMemberInfo_DAO
    {
        //Save New Member's Info
        public void SaveNewMember(string SKU, string Name, string Nation, string address, string Phone, DateTime RegisterDay, DateTime Birthday, string Birthplace, DateTime Day_Create, Boolean DeleteFlag, byte[] arrImage)
        {

            using (var db = new AccessDB_DAO())
            {
                if (arrImage == null) db.Students.Add(new Student() { FullName = Name, SKU = SKU, Nation = Nation, Address = address, PhoneNumber = Phone, Place_of_Birth = Birthplace, Day_Create = RegisterDay, Day_of_Birth = Birthday, Delete_Flag = DeleteFlag });
                else
                    db.Students.Add(new Student() { Image = arrImage, FullName = Name, SKU = SKU, Nation = Nation, Address = address, PhoneNumber = Phone, Place_of_Birth = Birthplace, Day_Create = RegisterDay, Day_of_Birth = Birthday, Delete_Flag = DeleteFlag });
                db.SaveChanges();
            }
        }
        public void EditMember(int RegisterNumber, string SKU, string Name, string Nation, string address, string Phone, DateTime RegisterDay,
            DateTime Birthday, string Birthplace, DateTime Day_Create, Boolean DeleteFlag, byte[] arrImage)
        {
            using (var db = new AccessDB_DAO())

            {
                var MemberUpdate = db.Students.Single(c => c.RegisterNumber == RegisterNumber);
                MemberUpdate.FullName = Name;
                MemberUpdate.SKU = SKU;
                MemberUpdate.Nation = Nation;
                MemberUpdate.Address = address;
                MemberUpdate.PhoneNumber = Phone;
                MemberUpdate.Place_of_Birth = Birthplace;
                MemberUpdate.Day_of_Birth = Birthday;
                MemberUpdate.Delete_Flag = DeleteFlag;
                MemberUpdate.Day_Update = DateTime.Now;
                MemberUpdate.Image = arrImage;
                MemberUpdate.Day_Create=RegisterDay;
                db.SaveChanges();
            }
        }
        //Return New Member Register ID to be a default ID
        public int RegisterNewMember()
        {
            using (var db = new AccessDB_DAO())
            {
                try
                {
                    return db.Students.Max(c => c.RegisterNumber);
                }
                catch { return 0; } //TH DS Hoi vien rong

            }
        }

        //Save Class which New Member register
        //public void SaveRegisterClass(int RegisterNumber, int ClassID, DateTime RegisterDay)
        //{
        //    using (var db = new AccessDB_DAO())
        //    {
        //        db.Learns.Add(new Learn() { ID_Class = ClassID, RegisterNumber = RegisterNumber, Fee_January = 0, Fee_February = 0, Fee_March = 0, Fee_April = 0, Fee_May = 0, Fee_June = 0, Fee_July = 0, Fee_August = 0, Fee_September = 0, Fee_October = 0, Fee_December = 0, Fee_November = 0, RegisterDay = RegisterDay, Day_Create = DateTime.Now, Delete_Flag = false });
        //        db.SaveChanges();
        //    }
        //}

        public void EditRegisterClass(int RegisterNumber, int ClassID, DateTime RegisterDay)
        {
            using (var db = new AccessDB_DAO())
            {
                var classUpdate = db.Fees.Where(c => c.RegisterNumber == RegisterNumber);
                List<Fee_Model> listFee = new List<Fee_Model>();
                listFee = classUpdate.ToList();
                foreach( var i in listFee)
                {
                    i.Day_Update = DateTime.Now;
                    i.ID_Class = ClassID;
                }
                db.SaveChanges();
            }

        }

        //Save Level Dai Dan Of Member
        public void SaveLevel(Dictionary<string, DateTime> listLevel, int RegisterNumber)
        {
            using (var db = new AccessDB_DAO())
            {
                foreach (var i in listLevel)
                {
                    if (i.Value != DateTime.MinValue)
                    {
                        int Level_ID = db.Dai_Dans.Where(x => x.Name.Contains(i.Key)).Select(c => c.ID).First();
                        db.Provide_Dai_Dans.Add(new Provide_DAI_DAN() { RegisterNumber = RegisterNumber, ID_DAI_DAN = Level_ID, Day_Provide = i.Value, Day_Create = DateTime.Now, Delete_FLag = false });
                        db.SaveChanges();
                    }

                }
            }

        }

        public void EditLevel(Dictionary<string, DateTime> listLevel, int RegisterNumber)
        {
            using (var db = new AccessDB_DAO())
            {
                foreach (var i in listLevel)
                {
                    //Add case
                    if (i.Value != DateTime.MinValue)
                    {
                        int Level_ID = db.Dai_Dans.Where(x => x.Name.Contains(i.Key)).Select(c => c.ID).First();
                        var LevelUpdate = db.Provide_Dai_Dans.SingleOrDefault(c => c.RegisterNumber == RegisterNumber && c.ID_DAI_DAN == Level_ID);
                        if (LevelUpdate == null)
                        {
                            db.Provide_Dai_Dans.Add(new Provide_DAI_DAN() { RegisterNumber = RegisterNumber, ID_DAI_DAN = Level_ID, Day_Provide = i.Value, Day_Create = DateTime.Now, Delete_FLag = false });
                        }
                        else
                        {
                            LevelUpdate.Day_Provide = i.Value;
                            LevelUpdate.Delete_FLag = false;
                            LevelUpdate.Day_Update = DateTime.Now;
                        }
                        db.SaveChanges();
                    }
                    else //Edit case
                    {
                        int Level_ID = db.Dai_Dans.Where(x => x.Name.Contains(i.Key)).Select(c => c.ID).First();
                        var LevelUpdate = db.Provide_Dai_Dans.SingleOrDefault(c => c.RegisterNumber == RegisterNumber && c.ID_DAI_DAN == Level_ID);
                        if (LevelUpdate != null)
                        {
                            LevelUpdate.Day_Provide = i.Value;
                            LevelUpdate.Delete_FLag = false;
                            LevelUpdate.Day_Update = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                }
            }
        }

        public Boolean Check_UniqueSKU_EditCase(string currentSKU, int RegisterNumber)   //check  Edit SKU
        {
            using (var db = new AccessDB_DAO())
            {
                var name = db.Students.SingleOrDefault(c => c.SKU == currentSKU && c.RegisterNumber != RegisterNumber);
                if (name == null)
                    return true;
            }
            return false;
        }
        public Boolean Check_UniqueSKU_AddCase(string currentSKU)   //check  Add SKU
         {
            using (var db = new AccessDB_DAO())
            {
                var name = db.Students.SingleOrDefault(c => c.SKU == currentSKU);
                if (name == null)
                    return true;
            }
            return false;
        }
    }
}
