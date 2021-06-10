using System;
using Demo.model;
using Demo.service;
using System.Collections.Generic;
using Nancy.Json;
using System.Collections;

namespace Demo
{
    class Program
    {
        static PersonServiceImpl personService = new PersonServiceImpl();
        static DepartmantServiceImpl departmantService = new DepartmantServiceImpl();
        static void Main(string[] args)
        {
            departmantSetup();
            personSetup();
            const string name = "admin";
            const string pass = "12345";

            string username, password;

            Console.Write("Kullanıcı adını giriniz: ");
            username = Console.ReadLine();
            Console.Write("Kullanıcı şifresini giriniz: ");
            password = Console.ReadLine();

            if (username.Equals(name) && password.Equals(pass))
            {
                Console.Clear();
                bool showMenu = true;
                while (showMenu)
                {
                    showMenu = MainMenu();
                }
            }
            else
            {
                Console.Write("Eslesen kullanici bulunamadi");
            }

        }
        private static bool personMenu()
        {
            Console.WriteLine("\n #### PERSONEL ISLEMLERI ####");
            Console.WriteLine("1-Personeli getir");
            Console.WriteLine("2-Tüm personelleri getir");
            Console.WriteLine("3-Personel ekle");
            Console.WriteLine("4-Personel guncelle");
            Console.WriteLine("5-Personel sil");
            Console.WriteLine("6-Personel izin ekle");
            Console.WriteLine("7-İzni yaklasan personelleri listele");
            Console.WriteLine("0-Ust menuye geri don");
            Console.WriteLine(" #############################");

            Console.WriteLine("Islem yapmak istediginiz degeri seciniz..");

            PersonServiceImpl personService = new PersonServiceImpl();
            int personID;
            string name;
            string surname;
            string idNumber;
            string birthDate;
            string basDate;
            string bitDate;

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.Write("Bilgisi getirilecek personelin IDsini giriniz:");
                    personID = int.Parse(Console.ReadLine());
                    Person p = personService.get(personID);
                    Console.WriteLine(new JavaScriptSerializer().Serialize(p));
                    return true;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Personeller listeleniyor...");
                    Hashtable data = personService.getAll();
                    objectToJsonDATA(data);
                    return true;

                case "3":
                    Console.Clear();
                    Console.Write("Personel IDsini giriniz:");
                    personID = int.Parse(Console.ReadLine());
                    Console.Write("Personel adini giriniz:");
                    name = Console.ReadLine();
                    Console.Write("Personel soyadini giriniz:");
                    surname = Console.ReadLine();
                    Console.Write("Personel T.C Kimlik Numarasını giriniz:");
                    idNumber = Console.ReadLine();
                    Console.Write("Personel dogum tarihini \"dd/MM/yyy\" formatında giriniz:");
                    birthDate = Console.ReadLine();

                    Console.Write("İzin baslangic tarihini \"dd/MM/yyyy\" formatında giriniz:");
                    basDate = Console.ReadLine();

                    Console.Write("İzin bitis tarihini \"dd/MM/yyyy\" formatında giriniz:");
                    bitDate = Console.ReadLine();

                    Console.WriteLine("Personelin Departman IDsini giriniz , Departman IDsini bilmiyorsanız listeden secemek icin [0] a basınız:");
                    int depID = int.Parse(Console.ReadLine());


                    Hashtable departmans = departmantService.getAll();
                    if (depID == 0)
                    {
                        objectToJsonDATA(departmans);
                        Console.WriteLine("Personelin Departman IDsini giriniz :");
                        depID = int.Parse(Console.ReadLine());
                    }


                    Person person = new Person(personID, name, surname, idNumber, birthDate, depID, basDate, bitDate);
                    personService.add(person);
                    return true;
                case "4":
                    Console.Clear();
                    Console.Write("Personel IDsini giriniz:");
                    personID = int.Parse(Console.ReadLine());
                    Console.Write("Personel adini giriniz:");
                    name = Console.ReadLine();
                    Console.Write("Personel soyadini giriniz:");
                    surname = Console.ReadLine();
                    Console.Write("Personel T.C Kimlik Numarasını giriniz:");
                    idNumber = Console.ReadLine();
                    Console.Write("Personel dogum tarihini \"dd/MM/yyyy\" formatında giriniz:");
                    birthDate = Console.ReadLine();

                    Console.Write("İzin baslangic tarihini \"dd/MM/yyyy\" formatında giriniz:");
                    basDate = Console.ReadLine();

                    Console.Write("İzin bitis tarihini \"dd/MM/yyyy\" formatında giriniz:");
                    bitDate = Console.ReadLine();

                    Console.WriteLine("Personelin Departman IDsini giriniz , Departman IDsini bilmiyorsanız listeden secemek icin [0] a basınız:");

                    int upDepID = int.Parse(Console.ReadLine());
                    departmans = departmantService.getAll();
                    if (upDepID == 0)
                    {
                        objectToJsonDATA(departmans);
                        Console.WriteLine("Personelin Departman IDsini giriniz :");
                        depID = int.Parse(Console.ReadLine());
                    }

                    Person updatePers = new Person(personID, name, surname, idNumber, birthDate, upDepID, basDate, bitDate);
                    personService.update(updatePers);
                    return true;
                case "5":
                    Console.Clear();
                    Console.Write("Bilgisi silinecek personelin IDsini giriniz:");
                    personID = int.Parse(Console.ReadLine());

                    Console.Write("Lütfen silme islemi için Evet(E) veya Hayır(H) seklinde onay veriniz.");
                    string secim = Console.ReadLine();
                    if (secim.Equals("E"))
                        personService.delete(personID);
                    else if (secim.Equals("H"))
                        return true;
                    else
                        Console.Write("Gecersiz islem girdiniz");
                    return true;
                case "6":
                    Console.Clear();
                    Console.Write("İzin eklenecek personelin IDsini giriniz:");
                    int id = int.Parse(Console.ReadLine());
                    Person pdata = personService.get(id);
                    //Console.WriteLine(new JavaScriptSerializer().Serialize(pdata));

                    Console.Write("İzin baslangic tarihini \"dd/MM/yyyy\" formatında giriniz:");
                    basDate = Console.ReadLine();

                    Console.Write("İzin bitis tarihini \"dd/MM/yyyy\" formatında giriniz:");
                    bitDate = Console.ReadLine();

                    pdata.PermitStart = DateTime.Parse(basDate);
                    pdata.PermitFinish = DateTime.Parse(bitDate);
                    personService.update(pdata);

                    return true;
                case "7":
                    Console.Clear();
                    Console.Write("Listelenecek izinlerin taranması icin gün sayısını giriniz:");
                    int scanDay = int.Parse(Console.ReadLine());
                    Hashtable offdutyPerson = personService.getPermits(scanDay);

                    foreach (object key in offdutyPerson.Keys)
                    {
                        Person offdutyP = (Person)offdutyPerson[key];
                        Console.WriteLine(String.Format("{0} - {1}", "PersonID:" + key, offdutyP.Name + " " + offdutyP.Surname));
                    }

                    return true;
                case "0":
                    Console.Clear();
                    return false;
                default:
                    Console.WriteLine("Gecersiz id girdiniz, Lutfen tekrar secim yapiniz !");
                    return true;
            }
        }
        private static bool departMenu()
        {
            Console.WriteLine("\n #### DEPARTMAN ISLEMLERI ####");
            Console.WriteLine("1-Departmanı getir");
            Console.WriteLine("2-Tüm departmanları listele");
            Console.WriteLine("3-Departman ekle");
            Console.WriteLine("4-Departman guncelle");
            Console.WriteLine("5-Departman sil");
            Console.WriteLine("6-Departman personellerini listele");
            Console.WriteLine("0-Ust menuye geri don");
            Console.WriteLine(" #############################");

            Console.WriteLine("Islem yapmak istediginiz degeri seciniz..");
            int departmantID;
            string title;
            string manager;
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.Write("Bilgisi getirilecek departmanın IDsini giriniz:");
                    departmantID = int.Parse(Console.ReadLine());
                    Departmant d = departmantService.get(departmantID);
                    Console.WriteLine(new JavaScriptSerializer().Serialize(d));
                    return true;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Departmanlar listeleniyor...");
                    Hashtable data = departmantService.getAll();
                    objectToJsonDATA(data);
                    return true;

                case "3":
                    Console.Clear();
                    Console.Write("Departman IDsini giriniz:");
                    departmantID = int.Parse(Console.ReadLine());
                    Console.Write("Departman adini giriniz:");
                    title = Console.ReadLine();
                    Console.Write("Departman yoneticisini giriniz:");
                    manager = Console.ReadLine();
                    Departmant departmant = new Departmant(departmantID, title, manager);
                    departmantService.add(departmant);
                    return true;
                case "4":
                    Console.Clear();
                    Console.Write("Departman IDsini giriniz:");
                    departmantID = int.Parse(Console.ReadLine());
                    Console.Write("Departman adini giriniz:");
                    title = Console.ReadLine();
                    Console.Write("Departman yoneticisini giriniz:");
                    manager = Console.ReadLine();
                    Departmant updateDep = new Departmant(departmantID, title, manager);
                    departmantService.update(updateDep);
                    return true;
                case "5":
                    Console.Clear();
                    Console.Write("Bilgisi silinecek departmanın IDsini giriniz:");
                    departmantID = int.Parse(Console.ReadLine());

                    Console.Write("Lütfen silme islemi için Evet(E) veya Hayır(H) seklinde onay veriniz.");
                    string secim = Console.ReadLine();
                    if (secim.Equals("E"))
                        departmantService.delete(departmantID);
                    else if (secim.Equals("H"))
                        return true;
                    else
                        Console.Write("Gecersiz islem girdiniz");
                    return true;
                case "0":
                    Console.Clear();
                    return false;
                case "6":
                    Console.Clear();
                    Console.WriteLine("Personelleri listelenecek departmanın  ID sini giriniz :");
                    int depID = int.Parse(Console.ReadLine());
                    Hashtable depPersons = personService.getPersonbyDepID(depID);
                    objectToJsonDATA(depPersons);
                    return true;
                default:
                    Console.WriteLine("Gecersiz id girdiniz, Lutfen tekrar secim yapiniz !");
                    return true;
            }
        }
        private static bool MainMenu()
        {
            Console.WriteLine(" ####### MENU ########");
            Console.WriteLine("1-Personel Islemleri");
            Console.WriteLine("2-Departman Islemleri");
            Console.WriteLine("3-Exit");
            Console.WriteLine(" #####################");
            Console.WriteLine("Merhaba, Islem yapmak istediginiz menuyu seciniz..");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    bool personelMenu = true;
                    while (personelMenu)
                    {
                        personelMenu = personMenu();
                    }
                    return true;
                case "2":
                    Console.Clear();
                    bool departmantMenu = true;
                    while (departmantMenu)
                    {
                        departmantMenu = departMenu();
                    }
                    return true;
                case "3":
                    return false;
                default:
                    Console.WriteLine("Gecersiz id girdiniz, Lutfen tekrar secim yapiniz !");
                    return true;
            }
        }

        static private void departmantSetup()
        {
            Departmant it = new Departmant(2, "IT", "Suleyman Taslı");
            Departmant developer = new Departmant(1, "Developer", "Emre Yildiz");
            Departmant ik = new Departmant(3, "Insan Kaynakları", "Yasemin Cakır");
            DepartmantServiceImpl departmantService = new DepartmantServiceImpl();
            departmantService.add(developer);
            departmantService.add(it);
            departmantService.add(ik);
        }

        static private void personSetup()
        {
            Person p1 = new Person(1, "Emre", "Yildiz", "12345678900", "01/01/1986", 1, "20/06/2021", "25/06/2021");
            Person p2 = new Person(2, "Suleyman", "Taslı", "55345678900", "05/11/1998", 2, "11/06/2021", "18/06/2021");
            Person p3 = new Person(3, "Yasemin", "Cakır", "42345678900", "27/05/1974", 3, "10/06/2021", "11/06/2021");
            Person p4 = new Person(4, "Itir", "Dere", "42345678900", "27/05/1974", 3, "05/06/2021", "15/06/2021");

            PersonServiceImpl personService = new PersonServiceImpl();
            personService.add(p1);
            personService.add(p2);
            personService.add(p3);
            personService.add(p4);
        }

        static private void objectToJsonDATA(Hashtable data)
        {
            foreach (object key in data.Keys)
            {
                Console.WriteLine(new JavaScriptSerializer().Serialize(data[key]) + "\n");
            }
        }
    }
}
