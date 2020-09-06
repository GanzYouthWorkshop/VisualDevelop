using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEV.VisualDevelop.Implementation.VisualComments
{
    public class ImageCache
    {
        private static Lazy<ImageCache> _instance = new Lazy<ImageCache>(() => new ImageCache());

        public static ImageCache Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private ConcurrentDictionary<string, string> m_ImageMap = new ConcurrentDictionary<string, string>();

        public ImageCache()
        {
        }

        ~ImageCache()
        {
            foreach (var path in m_ImageMap.Values)
            {
                try
                {
                    File.Delete(path);
                }
                catch
                {
                    //TODO
                }
            }
        }

        public void Add(string uri, string local)
        {
            m_ImageMap.GetOrAdd(uri, local);
        }

        public bool TryGetValue(string uri, out string local)
        {
            return m_ImageMap.TryGetValue(uri, out local);
        }
    }
}
