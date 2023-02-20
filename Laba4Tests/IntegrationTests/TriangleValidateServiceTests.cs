using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Laba4.Интерфейсы;
using Laba4.Классы;
using Laba4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4Tests.NewFolder2
{
    [TestClass]
    public class TriangleValidateServiceIntegrationTests
    {
        private ITriangleProvider triangleProvider;
        private ITriangleService triangleService;
        private ITriangleValidateService triangleValidateService;
        private readonly TestcontainerDatabase testcontainers = new ContainerBuilder<PostgreSqlTestcontainer>()
       .WithDatabase(new PostgreSqlTestcontainerConfiguration
       {
           Database = "db",
           Username = "postgres",
           Password = "postgres",
       })
       .Build();

        [TestInitialize]
        public void TestInitialize()
        {

            testcontainers.StartAsync().Wait();
            using (var con = new NpgsqlConnection(testcontainers.ConnectionString))
            {
                con.Open();
                string sql = "CREATE TABLE Triangles(id INTEGER NOT NULL PRIMARY KEY, A REAL NOT NULL, B REAL NOT NULL, C REAL NOT NULL, Square REAL NOT NULL, Type VARCHAR(30) NOT NULL)"; /*, Type TEXT NOT NULL*/
                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                command.ExecuteNonQuery();
            }
            triangleProvider = new TriangleProvider(testcontainers.ConnectionString);
            triangleService = new TriangleService();
            triangleValidateService = new TriangleValidateService(triangleProvider, triangleService);
        }


        [TestMethod]
        public void IsValid_true()
        {
            triangleProvider.Save(new Triangle(3, 4, 4, 4, 13, "разносторонний"));
            Assert.AreEqual(true, triangleValidateService.IsValid(3));
        }

        [TestMethod]
        public void IsValid_false()
        {
            triangleProvider.Save(new Triangle(3, 4, 20, 4, 13, "разносторонний"));
            Assert.AreEqual(false, triangleValidateService.IsValid(3));
        }

        [TestMethod]
        public void IsValid_false_EmptyTriangle()
        {
            triangleProvider.Save(new Triangle());
            Assert.AreEqual(false, triangleValidateService.IsValid(3));
        }

        [TestMethod]
        public void IsValid_false_EmptyDB()
        {
            Assert.AreEqual(false, triangleValidateService.IsValid(3));
        }

        [TestMethod]
        public void IsAllValid_true()
        {
            triangleProvider.Save(new Triangle(1, 5, 6, 7, 21, "разносторонний"));
            triangleProvider.Save(new Triangle(2, 7, 8, 9, 30, "разносторонний"));
            Assert.AreEqual(true, triangleValidateService.IsAllValid());
        }

        [TestMethod]
        public void IsAllValid_false()
        {
            triangleProvider.Save(new Triangle(1, 45, 20, 7, 21, "разносторонний"));
            triangleProvider.Save(new Triangle(2, 7, 6, 9, 30, "разносторонний"));
            Assert.AreEqual(false, triangleValidateService.IsAllValid());
        }

        [TestMethod]
        public void IsAllValid_true_5Triangle()
        {
            triangleProvider.Save(new Triangle(1, 5, 6, 7, 21, "разносторонний"));
            triangleProvider.Save(new Triangle(2, 7, 8, 9, 30, "разносторонний"));
            triangleProvider.Save(new Triangle(3, 7, 8, 9, 30, "разносторонний"));
            triangleProvider.Save(new Triangle(4, 7, 8, 9, 30, "разносторонний"));
            triangleProvider.Save(new Triangle(5, 7, 8, 9, 30, "разносторонний"));
            Assert.AreEqual(true, triangleValidateService.IsAllValid());
        }

        [TestMethod]
        public void IsAllValid_false_EmptyTriangle()
        {
            triangleProvider.Save(new Triangle());
            Assert.AreEqual(false, triangleValidateService.IsAllValid());
        }

        [TestMethod]
        public void IsAllValid_false_EmptyDB()
        {
            Assert.AreEqual(false, triangleValidateService.IsAllValid());
        }
    }
}
