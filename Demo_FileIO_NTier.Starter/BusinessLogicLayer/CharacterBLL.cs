using Demo_FileIO_NTier.Starter.Models;
using Demo_FileIO_NTier.Starter.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Demo_FileIO_NTier.Starter.BusinessLogicLayer
{
    class CharacterBLL
    {
        IDataService _dataService;
        List<Character> _characters;

        public CharacterBLL(IDataService dataService)
        {
            _dataService = dataService;
        }

        public IEnumerable<Character> GetCharacters(out bool success, out string message)
        {
            _characters = null;
            success = false;
            message = "";
            try
            {
                // _dataService = new CsvDataService();
                _dataService = new JsonDataService();
                //_dataService = new XmlDataService();
                _characters = _dataService.ReadAll() as List<Character>;
                _characters.OrderBy(c => c.Id);

                if(_characters.Count > 0)
                {
                    success = true;
                }
                else
                {
                    message = "It appears there is no data in the file.";
                }
            }
            catch (FileNotFoundException)
            {
                message = "Unable to locate the data file.";
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return _characters;
        }
    }
}
