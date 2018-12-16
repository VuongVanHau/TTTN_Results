using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Aikido.DAO;
using Aikido.DAO.Model;

namespace Aikido.BLO
{
    public class RegisterMember_BLO
    {
        SaveMemberInfo_DAO SaveMember_DAO;
        SaveFee_DAO saveFee_DAO;
        public RegisterMember_BLO()
        {
             SaveMember_DAO = new SaveMemberInfo_DAO();
             saveFee_DAO = new SaveFee_DAO();
        }

        public void RegisterNewMember(MemberInfo_ViewModel info,Fee_Model fee,DateTime Day_Create)
        {

            //get Register New Member
            SaveMember_DAO.SaveNewMember(info.SKU, info.FullName, info.Nation, info.Address, info.PhoneNumber, info.Register_day, info.Day_of_Birth, info.Place_of_Birth, Day_Create, false, info.Image);
            saveFee_DAO.saveFee(fee);
            SaveMember_DAO.SaveLevel(info.listLevel, info.RegisterNumber);
       
           
        }
      
        //get new register member's number
        public int NewRegisterNumber()
        {
            int register_number;
           return  register_number= SaveMember_DAO.RegisterNewMember();
        }

        public void EditMember_Info(MemberInfo_ViewModel info, DateTime Day_Create)
        {
            {//get Register New Member
                SaveMember_DAO.EditMember(info.RegisterNumber, info.SKU, info.FullName, info.Nation, info.Address, info.PhoneNumber, info.Register_day, info.Day_of_Birth, info.Place_of_Birth, Day_Create, false, info.Image);
                SaveMember_DAO.EditRegisterClass(info.RegisterNumber, info.ID_Class, info.Register_day);
                SaveMember_DAO.EditLevel(info.listLevel, info.RegisterNumber);

            }
        }
        //
        public Boolean Check_UniqueSKU(string currentSKU, int RegisterMember)
        {
            
            SaveMemberInfo_DAO save = new SaveMemberInfo_DAO();
            if (RegisterMember != -1)
            {
                if (save.Check_UniqueSKU_EditCase(currentSKU, RegisterMember) == true) return true;
            }
            else {
               if(save.Check_UniqueSKU_AddCase(currentSKU) == true) return true;
            }
            return false;
        }

    }
}
