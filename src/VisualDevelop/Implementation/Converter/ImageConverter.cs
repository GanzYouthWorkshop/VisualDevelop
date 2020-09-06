using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            else
            {
                return ReflectionConvert(obj, "ToBitmap");
            }
        }

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
