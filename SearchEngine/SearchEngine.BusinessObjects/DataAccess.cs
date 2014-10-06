using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections;

namespace SearchEngine.BusinessObjects
{
    /// <summary>
    ///  Responsible for serialising and deserialising to / from the database (which is a file)
    /// </summary>
    public class DataAccess
    {
        string path = @"c:\temp\data\";
        string fileName = "Data.xml";

        public DataCollection LoadDataBase()
        {
            return DeserialiseObject(path);
        }

        public void SaveDataBase(DataCollection col)
        {
            SerialiseObject(col, path);
        }

        private void SerialiseObject(DataCollection col, string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            try
            {
                System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(DataCollection));
                System.IO.TextWriter writer =
                new System.IO.StreamWriter(path + "\\" + fileName, false);
                serializer.Serialize(writer, col);
                writer.Close();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        private DataCollection DeserialiseObject(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            try
            {
                System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(DataCollection));
                System.IO.TextReader reader =
                new System.IO.StreamReader(path + "\\" + fileName);
                DataCollection ObjItems = (DataCollection)serializer.Deserialize(reader);
                reader.Close();    
                return ObjItems;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}
