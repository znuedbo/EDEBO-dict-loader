namespace EDEBO_dict_loader
{
    /// <summary>
    /// Данные, необходимые для подключения к сервисам ЄДЕБО
    /// </summary>
    class EdboLoginInfo
    {
        private string login = "shevchenko.ruslana@edbo.gov.ua";
        private string password = "choporov007";
        private int idLanguage = 1;
        private string universityKode = "ab1bc732-51f3-475c-bcfe-368363369020";
        private string applicationKey = "Y0NzMXVGYnplb2lYZzhxVlA3ZUZ4eFJualhlNnowbkh2dmpTQ0FSNkc5U09iOW9yWExQUnVLZ1FWZVNIQmY5b2JMQ1ZaSHRvcmg5eFFka2pKWGlabUZvVnBFN3hTakZCYUROQkhEQ3FzQUFtTFQ5UzRKOE82a2NGeFJGdUs1rMC=";
        private int idSeason = 6; // 2 - 2012, 3 - 2013, ...

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public int IdLanguage
        {
            get
            {
                return idLanguage;
            }

            set
            {
                idLanguage = value;
            }
        }

        public string UniversityKode
        {
            get
            {
                return universityKode;
            }

            set
            {
                universityKode = value;
            }
        }

        public string ApplicationKey
        {
            get
            {
                return applicationKey;
            }

            set
            {
                applicationKey = value;
            }
        }

        public int IdSeason
        {
            get
            {
                return idSeason;
            }

            set
            {
                idSeason = value;
            }
        }
    }
}
