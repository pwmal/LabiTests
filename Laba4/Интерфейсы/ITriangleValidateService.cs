using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4.Интерфейсы
{
    public interface ITriangleValidateService
    {
        bool IsAllValid();
        bool IsValid(int id);
    }
}
