using Microsoft.Win32;using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Aikido.DAO;
using System.IO;
using System.Drawing;


namespace Aikido.BLO
{
    class SettingImage_BLO
    {
        //Load Image from Folder Dialog
        public ImageBrush LoadImage_Button()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
                ImageBrush image = new ImageBrush();
                image.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName));

                return image;
            }
            return null;
        }
        //Load Image for view

        //Save Setting
        public void SaveImage_ToDB(byte[] arrImage)
        {
            SettingBackground_DAO settingBackground_DAO = new SettingBackground_DAO();
            settingBackground_DAO.SaveSetting(arrImage);
        }
        //Load Image from  Byte[] in DB
        public ImageBrush GetImage_FromDB()
        {
            SettingBackground_DAO settingBackground_DAO = new SettingBackground_DAO();
            byte[] arrimage = settingBackground_DAO.LoadImage_FromDB();
            ImageBrush image = new ImageBrush();
            image.ImageSource = ConvertByte_ToImage(arrimage);
            return image;
        }
        public Image getBackGround()
        {
            SettingBackground_DAO settingBackground_DAO = new SettingBackground_DAO();
            byte[] arrimage = settingBackground_DAO.LoadImage_FromDB();
            if (arrimage != null)
            {
                MemoryStream m = new MemoryStream(arrimage);
                Image image = Image.FromStream(m);
                return image;
            }
            return null;
        }
      
        public BitmapImage ConvertByte_ToImage(byte[] arrimage)
        {
            if (arrimage == null || arrimage.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(arrimage))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        //Convert Image to Byte
        public byte[] ConvertImage_ToBytes(ImageSource imageSource)
        {
            byte[] bytes = null;
            var bitmap = imageSource as BitmapSource;

            if (bitmap != null)
            {
                BitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    encoder.Save(ms);
                    bytes = ms.ToArray();
                }
            }
            return bytes;
        }
     
      
    }
}
