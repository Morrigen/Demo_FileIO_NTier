using Demo_FileIO_NTier.Starter.BusinessLogicLayer;
using Demo_FileIO_NTier.Starter.PresentationLayer;
using Demo_FileIO_NTier.Starter.DataAccessLayer;

namespace Demo_FileIO_NTier
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService dataService = new CsvDataService();
            CharacterBLL charactersBLL = new CharacterBLL(dataService);
            Presenter presenter = new Presenter(charactersBLL);
        }
    }
} //STUCK: Can't access data file
