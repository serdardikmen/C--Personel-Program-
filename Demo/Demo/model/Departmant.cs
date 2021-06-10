using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.model
{
    class Departmant
    {
        private int departmantID;
        private string title;
        private string manager;

        public string Title { get => title; set => title = value; }
        public string Manager { get => manager; set => manager = value; }
        public int DepartmantID { get => departmantID; set => departmantID = value; }

        public Departmant(int departmantID, string title, string manager)
        {
            this.DepartmantID = departmantID;
            this.Title = title ?? throw new ArgumentNullException(nameof(title));
            this.Manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
