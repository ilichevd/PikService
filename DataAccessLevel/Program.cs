using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLevel.UnitOfWork;
using DataAccessLevel.Models;

namespace DataAccessLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            // simple test
            using (var db = new PikDbContext())
            {
                Console.WriteLine("Каталогов: " + db.catalogs.Count());
                Console.ReadLine();

                db.catalogs.Add(new Catalog
                {
                    Name = "Test",
                    Descr = "Тестовый каталог"
                });
                db.SaveChanges();
                
                foreach (var catalog in db.catalogs)
                {
                    Console.WriteLine("Каталог: " + catalog.Name + catalog.Descr);
                }
                Console.WriteLine("Каталогов: " + db.catalogs.Count());
                Console.ReadLine();
            }
        }
    }
}
