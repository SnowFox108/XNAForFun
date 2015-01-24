using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ShooterForFunLibraries
{
    public class XMLManager<T>
    {
        //private const string rootPath = FileSystem.Current.LocalStorage.Path;
        private const string assemblyName = "ShooterForFunLibraries";

        public Type Type { get; set; }

        public XMLManager()
        {
            Type = typeof(T);
        }

        public T Load(string path)
        {
            T instance;

            using (TextReader reader = new StreamReader(Assembly.Load(new AssemblyName(assemblyName)).GetManifestResourceStream(string.Format("{0}.{1}", assemblyName, path))))
            {
                XmlSerializer xml = new XmlSerializer(Type);
                instance = (T)xml.Deserialize(reader);
            }

            return instance;
        }

        public void Save(string path, object obj)
        {
            using (TextWriter writer = new StreamWriter(Assembly.Load(new AssemblyName(assemblyName)).GetManifestResourceStream(string.Format("{0}.{1}", assemblyName, path))))
            {
                XmlSerializer xml = new XmlSerializer(Type);
                xml.Serialize(writer, obj);
            }
        }
    }
}
