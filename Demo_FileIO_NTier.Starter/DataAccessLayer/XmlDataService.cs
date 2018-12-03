using System;
using System.Collections.Generic;
using Demo_FileIO_NTier.Starter.Models;
using System.Xml.Serialization;
using System.IO;

namespace Demo_FileIO_NTier.Starter.DataAccessLayer
{
    class XmlDataService : IDataService
    {
        private string _dataFilePath;

        public XmlDataService()
        {
            _dataFilePath = DataSettings.dataFilePath;
        }

        public IEnumerable<Character> ReadAll()
        {
            List<Character> characters = new List<Character>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Character>), new XmlRootAttribute("Characters"));

            try
            {
                using (StreamReader sr = new StreamReader(_dataFilePath))
                {
                    characters = (List<Character>)serializer.Deserialize(sr);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return characters;
        }

        public void WriteAll(IEnumerable<Character> characters)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Character>), new XmlRootAttribute("Characters"));

            try
            {
                using (StreamWriter sw = new StreamWriter(_dataFilePath))
                {
                    serializer.Serialize(sw, characters);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
