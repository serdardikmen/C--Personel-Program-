using System;
using System.Collections.Generic;

namespace Demo.model
{
    class Person
    {
        private int personID;
        private string name;
        private string surname;
        private string idNumber;
        private DateTime birthDate;
        private int departmantIDFK;
        private DateTime permitStart;
        private DateTime permitFinish;


        public Person(int personID, string name, string surname, string idNumber, string birthDate, int departmantIDFK,string permitStart, string permitFinish)
        {
            this.PersonID = personID;
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            this.IdNumber = idNumber ?? throw new ArgumentNullException(nameof(idNumber));
            this.BirthDate = DateTime.Parse(birthDate);
            this.DepartmantIDFK = departmantIDFK;
            this.PermitStart = DateTime.Parse(permitStart);
            this.PermitFinish = DateTime.Parse(permitFinish);
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string IdNumber { get => idNumber; set => idNumber = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public int PersonID { get => personID; set => personID = value; }
        public int DepartmantIDFK { get => departmantIDFK; set => departmantIDFK = value; }
        public DateTime PermitStart { get => permitStart; set => permitStart = value; }
        public DateTime PermitFinish { get => permitFinish; set => permitFinish = value; }
    }
}
