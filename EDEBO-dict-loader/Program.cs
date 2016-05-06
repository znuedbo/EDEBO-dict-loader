using System;
using EDEBO_dict_loader.ua.edu.znu.edbo;

namespace EDEBO_dict_loader
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EdboGuidesProcessor guides = new EdboGuidesProcessor();
                //guides.Languages();
                //guides.Universities();
                //guides.UniversityFacultets();
                guides.Specialities(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
