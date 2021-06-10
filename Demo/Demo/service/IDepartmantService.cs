using System;
using System.Collections;
using System.Text;
using Demo.model;

namespace Demo.service
{
    interface IDepartmantService
    {
        public bool add(Departmant departmant );
        public bool delete(int departmantID);
        public bool update(Departmant departmant);
        public Departmant get(int departmantID);
        public Hashtable getAll();
    }
}
