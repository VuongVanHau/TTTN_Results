
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Aikido.VIEW;
using System.Security.AccessControl;

namespace Aikido.DAO
{
    public class AccessDB_DAO : DbContext

    {
        string url;
        //private static bool _created = false;
        public AccessDB_DAO()
        {
            url = AppDomain.CurrentDomain.BaseDirectory;
            url = url + "DB.db";
            if (File.Exists(@"" + url) == false)
            {
                //System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(url);
                //FileSystemAccessRule authorization = new FileSystemAccessRule("Users", FileSystemRights.FullControl, AccessControlType.Allow);
                //DirectorySecurity ds = null;

                //ds = di.GetAccessControl();
                //ds.AddAccessRule(authorization);
                //di.SetAccessControl(ds); // nothing happens until you do this
                ////_created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();


            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            //System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(url);
            //FileSystemAccessRule authorization = new FileSystemAccessRule("Users", FileSystemRights.FullControl, AccessControlType.Allow);
            //DirectorySecurity ds = null;
            //ds = di.GetAccessControl();
            //ds.AddAccessRule(authorization);
            //di.SetAccessControl(ds); // nothing happens until you do this
            optionbuilder.UseSqlite(@"Data Source=" + url);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<DAI_DAN> Dai_Dans { get; set; }
        public DbSet<Fee_Model> Fees { get; set; }
        public DbSet<Provide_DAI_DAN> Provide_Dai_Dans { get; set; }
        public DbSet<StoreSettingImage_Model> SettingImage { get; set; }

    }
}
