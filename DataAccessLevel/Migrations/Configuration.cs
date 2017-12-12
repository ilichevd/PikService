namespace DataAccessLevel.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLevel.Models.PikDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLevel.Models.PikDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // ������� 2 ������������
            context.users.AddOrUpdate(u => u.UserId,
                new User
                {
                    UserId = 1,
                    FIO = "����� ��������� ���������",
                    Login = "admin"
                },
                new User
                {
                    UserId = 2,
                    FIO = "������ �������� �������",
                    Login = "user"
                }
            );

            // ������� 3 ��������
            context.catalogs.AddOrUpdate(c => c.CatalogId,
                new Catalog
                {
                    CatalogId = 1,
                    Name = "Low priority",
                    Descr = "�������"
                },
                new Catalog
                {
                    CatalogId = 2,
                    Name = "Normal priority",
                    Descr = "������ �������"
                },
                new Catalog
                {
                    CatalogId = 3,
                    Name = "High priority",
                    Descr = "������ ����"
                }
            );

            // ������� �������
            context.tasks.AddOrUpdate(t => t.TaskId,
                new Task
                {
                    TaskId = 1,
                    Date = new DateTime(2017, 01, 03),
                    Name = "������ ��� �� ����",
                    UserId = 1,
                    CatalogId = 1
                },
                new Task
                {
                    TaskId = 2,
                    Date = new DateTime(2017, 10, 06),
                    Name = "����������",
                    UserId = 2,
                    CatalogId = 1
                },
                new Task
                {
                    TaskId = 3,
                    Date = new DateTime(2017, 11, 30),
                    Name = "�������������� Windows ������",
                    UserId = 1,
                    CatalogId = 2
                },
                new Task
                {
                    TaskId = 4,
                    Date = new DateTime(2017, 11, 30),
                    Name = "��������� Active Directory",
                    UserId = 2,
                    CatalogId = 2
                },
                new Task
                {
                    TaskId = 5,
                    Date = new DateTime(2017, 11, 08),
                    Name = "������ ���",
                    UserId = 2,
                    CatalogId = 2
                },
                new Task
                {
                    TaskId = 6,
                    Date = new DateTime(2017, 11, 04),
                    Name = "��������� �����",
                    UserId = 2,
                    CatalogId = 2
                },
                new Task
                {
                    TaskId = 7,
                    Date = DateTime.Now,
                    Name = "� ����-�� ������ � �� �������",
                    UserId = 1,
                    CatalogId = 3
                }
            );
            context.SaveChanges();
        }
    }
}
