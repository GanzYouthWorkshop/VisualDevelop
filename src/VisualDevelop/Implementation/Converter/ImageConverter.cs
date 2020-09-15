using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GEV.VisualDevelop.Implementation.Converter
{
    public class ImageConverter
    {
        public static Bitmap ConvertObjectToBitmap(object obj)
        {
            if (obj is Bitmap)
            {
                return obj as Bitmap;
            }
            //else if(obj is ImageData)
            //{
            //    return SemilabConvert(obj as ImageData);
            //}
            else
            {
                return ReflectionConvert(obj, "ToBitmap");
            }
        }

        //private static Bitmap SemilabConvert(ImageData obj)
        //{
        //    Bitmap result = new Bitmap(obj.Width, obj.Height);

        //    //[KG] Ez minden csak nem precíz de egyelőre "jóvanazúgy"
        //    PixelFormat newFormat;
        //    int bpp = obj.Stride / obj.Width;
        //    switch(bpp)
        //    {
        //        case 1: newFormat = PixelFormat.Format8bppIndexed; break;
        //        case 2: newFormat = PixelFormat.Format16bppGrayScale; break;
        //        case 3: newFormat = PixelFormat.Format24bppRgb; break;
        //        case 4: newFormat = PixelFormat.Format32bppRgb; break;
        //        case 6: newFormat = PixelFormat.Format48bppRgb; break;
        //        case 8: newFormat = PixelFormat.Format64bppArgb; break;

        //        default: return null;
        //    }

        //    BitmapData bmpData = result.LockBits(new Rectangle(new Point(), result.Size), ImageLockMode.ReadWrite, newFormat);
        //    IntPtr destination = bmpData.Scan0;
        //    Marshal.Copy(obj.GetByteBuf1D(), 0, destination, obj.Stride * obj.Height);
        //    result.UnlockBits(bmpData);

        //    return result;
        //}

        private static Bitmap ReflectionConvert(object obj, string invokable)
        {
            MethodInfo method = obj.GetType().GetMethod(invokable, new Type[] { });
            if (method != null)
            {
                Bitmap result = method.Invoke(obj, null) as Bitmap;

                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new ArgumentException("Result is null without internal exceptions!");
                }
            }
            else
            {
                throw new ArgumentException($"Object has no {invokable}() method!");
            }
        }
    }
}
