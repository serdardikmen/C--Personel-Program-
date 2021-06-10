using System;
using System.Collections;
using System.Text;
using Demo.model;
using System.Collections.Generic;

namespace Demo.service
{
    interface IPersonService
    {
        public bool add(Person person);
        public bool update(Person person);
        public bool delete(int personID);
        public Person get(int personID);
        public Hashtable getAll();
        public Hashtable getPermits(int scanDay);
        public Hashtable getPersonbyDepID(int depID);
    }
}
