using Laba4.Интерфейсы;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4.Классы
{
    public class TriangleProvider : ITriangleProvider
    {
        private readonly string path;
        public TriangleProvider(string path)
        {
            this.path = path;
        }
        public Triangle GetById(int id)
        {
            Triangle triangle = new Triangle();
            using (var con = new NpgsqlConnection(path))
            {
                con.Open();
                string sql = $"SELECT * FROM Triangles WHERE id = {id}";
                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    triangle.id = reader.GetInt32(reader.GetOrdinal("id"));
                    triangle.a = reader.GetDouble(reader.GetOrdinal("A"));
                    triangle.b = reader.GetDouble(reader.GetOrdinal("B"));
                    triangle.c = reader.GetDouble(reader.GetOrdinal("C"));
                    triangle.sq = reader.GetDouble(reader.GetOrdinal("Square"));
                    triangle.type = reader.GetString(reader.GetOrdinal("Type"));
                }
            }
            return triangle;
        }

        public List<Triangle> GetAll()
        {
            List<Triangle> triangle = new List<Triangle>();
            using (var con = new NpgsqlConnection(path))
            {
                con.Open();
                string sql = $"SELECT * FROM Triangles";
                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    triangle.Add(new Triangle(
                    reader.GetInt32(reader.GetOrdinal("id")),
                    reader.GetDouble(reader.GetOrdinal("A")),
                    reader.GetDouble(reader.GetOrdinal("B")),
                    reader.GetDouble(reader.GetOrdinal("C")),
                    reader.GetDouble(reader.GetOrdinal("Square")),
                    reader.GetString(reader.GetOrdinal("Type"))
                    ));
                }
            }
            return triangle;
        }

        public void Save(Triangle triangle)
        {
            using (var con = new NpgsqlConnection(path))
            {
                con.Open();
                string cmdText = $"INSERT INTO Triangles VALUES({triangle.id}, {triangle.a}, {triangle.b}, {triangle.c}, {triangle.sq}, '{triangle.type}')"; /*, { triangle.type}*/
                NpgsqlCommand cmd = new NpgsqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
