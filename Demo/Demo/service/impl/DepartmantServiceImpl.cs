using Demo.model;
using System;
using System.Collections;
using System.Text;

namespace Demo.service
{
    class DepartmantServiceImpl : IDepartmantService
    {

        private static Hashtable departmanData = new Hashtable();
        public static Hashtable DepartmanData { get => departmanData; set => departmanData = value; }


        public bool add(Departmant departmant)
        {
            DepartmanData.Add(departmant.DepartmantID, departmant);
            return true;
        }

        public bool delete(int departmantID)
        {
            DepartmanData.Remove(departmantID);
            return true;
        }

        public Departmant get(int departmantID)
        {
            return (Departmant)DepartmanData[1];
        }

        public Hashtable getAll()
        {
            return DepartmanData;
        }

        public bool update(Departmant departmant)
        {
            DepartmanData.Remove(departmant.DepartmantID);
            add(departmant);
            return true;
        }
    }
}
