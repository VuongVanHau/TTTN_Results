using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikido.DAO
{
    public class SettingBackground_DAO
    {
        public void SaveSetting(byte[] arrimage)
        {
            using (var db = new AccessDB_DAO())
            {
                if (arrimage != null)
                {
                    if (db.SettingImage.FirstOrDefault(c => c.key == 1) == null) db.SettingImage.Add(new StoreSettingImage_Model() { ImageSetting = arrimage });
                    else
                    {
                        var x = db.SettingImage.Single(c => c.key == 1);
                        x.ImageSetting = arrimage;
                    }
                }else
                    {
                        var x = db.SettingImage.Single(c => c.key == 1);
                        x.ImageSetting = null;
                    }
                db.SaveChanges();
            }
        }
        public byte[] LoadImage_FromDB()
        {
            using (var db = new AccessDB_DAO())
            {
                byte[] x = null;
                var r = db.SettingImage.FirstOrDefault(c => c.key == 1);

                if (r != null) x = db.SettingImage.Where(c => c.key == 1).Select(c => c.ImageSetting).First();
                return x;
            }
        }
    }
}
