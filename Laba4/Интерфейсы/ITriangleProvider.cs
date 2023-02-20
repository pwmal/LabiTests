using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4.Интерфейсы
{
    public interface ITriangleProvider
    {
        Triangle GetById(int id);
        List<Triangle> GetAll();
        void Save(Triangle triangle);
    }
}
