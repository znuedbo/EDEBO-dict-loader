using System;
using EDEBO_dict_loader.ua.edu.znu.edbo;

namespace EDEBO_dict_loader
{
    class EdboGuidesProcessor
    {
        private string actualDate;
        private EDBOGuides guides;
        private string session;
        private EdboLoginInfo info;
        private Guid guid;

        public EdboGuidesProcessor()
        {
            actualDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            Console.WriteLine(actualDate);
            Console.Write("Login...");
            guides = new EDBOGuides();
            info = new EdboLoginInfo();
            session = guides.Login(info.Login, info.Password, 0, info.ApplicationKey);
            if (session.Length != 36)
            {
                throw new Exception(session);
            }
            guid = new Guid(session);
            Console.WriteLine("Done");
        }

        ~EdboGuidesProcessor()
        {
            guides.Logout(session);
        }
        /// <summary>
        /// Обработчик ошибок ЄДЕБО
        /// </summary>
        public void ProcessErrors()
        {
            dLastError[] errors = guides.GetLastError(session);
            String msgs = "";
            foreach (dLastError e in errors)
                msgs = msgs + e.LastErrorCode + " " + e.LastErrorDescription + "\n";
            throw new Exception(msgs);
        }
        /// <summary>
        /// Список доступных языков
        /// </summary>
        public void Languages()
        {
            dLanguages[] languages = guides.LanguagesGet(session);
            if (languages == null) ProcessErrors();
            foreach (dLanguages lang in languages)
            {
                Console.WriteLine(lang.Id_Language + " " + lang.Code + " " + lang.NameLanguage);
            }
        }
        /// <summary>
        /// Список подразделений университета
        /// </summary>
        public void Universities()
        {
            dUniversities[] universities = guides.UniversitiesGet(session, "", info.IdLanguage, actualDate, "");
            if (universities == null) ProcessErrors();
            foreach (dUniversities univer in universities)
            {
                Console.WriteLine(univer.UniversityFullName + " " + univer.UniversityKode);
            }
        }
        /// <summary>
        /// Список факультетов университета
        /// </summary>
        public void UniversityFacultets()
        {
            dUniversityFacultets[] facultets = guides.UniversityFacultetsGet(session, info.UniversityKode, "", info.IdLanguage, actualDate, 1, "20", 1, -1, 0, -1);
            if (facultets == null) ProcessErrors();
            foreach (dUniversityFacultets faculty in facultets)
            {
                Console.WriteLine(faculty.Id_UniversityFacultet + " " + faculty.UniversityFacultetFullName + " " + faculty.UniversityFacultetKode);
            }
        }
        /// <summary>
        /// Список специальностей университета
        /// </summary>
        /// <param name="IdPersonEducationForm">Идентификатор формы образования: 1 - дневная, 2 - заочная, 3 - екстернат, 4 - вечер, 5 - дистанционная</param>
        public void Specialities(int IdPersonEducationForm)
        {
            dUniversityFacultets[] facultets = guides.UniversityFacultetsGet(session, info.UniversityKode, "", info.IdLanguage, actualDate, 1, "20", 1, -1, 0, -1);
            if (facultets == null) ProcessErrors();
            foreach (dUniversityFacultets faculty in facultets)
            {
                Console.WriteLine(faculty.Id_UniversityFacultet + " " + faculty.UniversityFacultetFullName + " " + faculty.UniversityFacultetKode);
                dUniversityFacultetSpecialities[] specialities = guides.UniversityFacultetSpecialitiesGet(session, info.UniversityKode, faculty.UniversityFacultetKode, "", info.IdLanguage, actualDate, info.IdSeason, IdPersonEducationForm, "", "", "", "");
                if (specialities == null) ProcessErrors();
                foreach (dUniversityFacultetSpecialities speciality in specialities)
                {
                    Console.WriteLine(speciality.Id_UniversitySpecialities + " " + speciality.SpecSpecialityName + " " + speciality.SpecDirectionName + " " + speciality.SpecSpecializationName);
                }
            }
        }
    }
}
