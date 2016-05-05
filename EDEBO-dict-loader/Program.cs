using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDEBO_dict_loader.ua.edu.znu.edbo;

namespace EDEBO_dict_loader
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Guides...");
            EDBOGuides guides = new EDBOGuides();
            System.Console.WriteLine("Done.");
            System.Console.Write("Login...");
            string session = guides.Login("shevchenko.ruslana@edbo.gov.ua", "choporov007", 0, "Y0NzMXVGYnplb2lYZzhxVlA3ZUZ4eFJualhlNnowbkh2dmpTQ0FSNkc5U09iOW9yWExQUnVLZ1FWZVNIQmY5b2JMQ1ZaSHRvcmg5eFFka2pKWGlabUZvVnBFN3hTakZCYUROQkhEQ3FzQUFtTFQ5UzRKOE82a2NGeFJGdUs1rMC=");
            if (session.Length != 36)
            {
                System.Console.WriteLine(session);
                System.Console.ReadKey();
                return;
            }

            System.Console.WriteLine("Done.");
            System.Console.Write("Logout...");
            guides.Logout(session);
            System.Console.WriteLine("Done.");
            System.Console.WriteLine("Press any key");
            System.Console.ReadKey();
        }
    }
}
