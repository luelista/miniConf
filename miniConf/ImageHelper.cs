using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace miniConf
{
    public static class ImageHelper
    {

        public static string clipboardImageToFile() {
            try {
                string uploadfn = Program.dataDir + "Temporary Data\\upload";
                Image img = Clipboard.GetImage();
                var dobj = Clipboard.GetDataObject();
                Console.WriteLine(string.Join("\n", dobj.GetFormats()));

                string[] tryFormats = { "PNG", "JFIF", "DeviceIndependentBitmap" };
                int tryIdx = 0;
                while (img == null && tryIdx < tryFormats.Length) {
                    string fmt = tryFormats[tryIdx];
                    tryIdx++;
                    Console.WriteLine("img is null; checking format " + fmt + " ...");
                    if (dobj.GetDataPresent(fmt)) {
                        Console.WriteLine("getData ...");
                        MemoryStream obj = dobj.GetData(fmt) as MemoryStream;
                        if (obj == null) {
                            Console.WriteLine("NULL!");
                            continue;
                        }
                        img = Image.FromStream(obj);
                        break;
                    }
                }
                if (img == null) return null;
                SaveWithJpegQuality(img,uploadfn + ".jpg", 98);
                img.Save(uploadfn + ".png", System.Drawing.Imaging.ImageFormat.Png);
                long sizeJpg = new FileInfo(uploadfn + ".jpg").Length;
                long sizePng = new FileInfo(uploadfn + ".png").Length;
                for (int quality = 98; quality > 0 && Math.Min(sizeJpg, sizePng) >= ApplicationPreferences.FileUploadMaxSize; quality -= 5) {
                    Console.WriteLine("File size too big (" + sizeJpg + "), trying with reduced JPEG quality " + quality);
                    SaveWithJpegQuality(img, uploadfn + ".jpg", quality);
                    sizeJpg = new FileInfo(uploadfn + ".jpg").Length;
                }
                if (sizeJpg < sizePng) return uploadfn + ".jpg";
                else return uploadfn + ".png";
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public static void SaveWithJpegQuality(Image img, string FileName, int qualityLevel) {
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            // Create an Encoder object based on the GUID  
            // for the Quality parameter category.  
            System.Drawing.Imaging.Encoder myEncoder =
                System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object.  
            // An EncoderParameters object has an array of EncoderParameter  
            // objects. In this case, there is only one  
            // EncoderParameter object in the array.  
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, qualityLevel);
            myEncoderParameters.Param[0] = myEncoderParameter;
            img.Save(FileName, jpgEncoder, myEncoderParameters);
            
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format) {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs) {
                if (codec.FormatID == format.Guid) {
                    return codec;
                }
            }
            return null;
        }
    }
}
