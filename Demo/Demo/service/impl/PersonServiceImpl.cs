using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Demo.model;

namespace Demo.service
{
    class PersonServiceImpl : IPersonService
    {

        private static Hashtable personData = new Hashtable();

        public static Hashtable PersonData { get => personData; set => personData = value; }

        public bool add(Person person)
        {
            PersonData.Add(person.PersonID, person);
            return true;
        }

        public bool delete(int personID)
        {
            PersonData.Remove(personID);
            return true;
        }

        public Person get(int personID)
        {
            return (Person)PersonData[personID];
        }

        public Hashtable getAll()
        {
            return PersonData;
        }

        public bool update(Person person)
        {
            PersonData.Remove(person.PersonID);
            add(person);
            return true;
        }

        public Hashtable getPersonbyDepID(int depID)
        {
            Hashtable depPerson= new Hashtable();
            Hashtable persons=getAll();
            foreach (object key in persons.Keys)
            {
               Person p=(Person)persons[key];
                if (p.DepartmantIDFK.Equals(depID))
                    depPerson.Add(p.PersonID,p);

            }
            return depPerson;
        }
        public Hashtable getPermits(int scanDay)
        {
            DateTime nowDate = DateTime.Now;
            DateTime addedDate=nowDate.AddDays(scanDay);

            Hashtable offDutyPerson = new Hashtable();
            Hashtable persons = getAll();
            foreach (object key in persons.Keys)
            {
                Person p = (Person)persons[key];
                if (p.PermitStart > nowDate && p.PermitStart < addedDate)
                {
                    offDutyPerson.Add(p.PersonID+" Izni Yaklasiyor", p);
                }else if (p.PermitStart <= nowDate && p.PermitFinish >= nowDate)
                {
                    offDutyPerson.Add(p.PersonID + " Izinde", p);
                }
                    

            }
            return offDutyPerson;
        }
    }
}
