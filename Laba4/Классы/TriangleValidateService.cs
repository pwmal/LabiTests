using Laba4.Интерфейсы;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    public class TriangleValidateService : ITriangleValidateService
    {
        private readonly ITriangleProvider TriangleProvider;
        private readonly ITriangleService TriangleService;

        public TriangleValidateService(ITriangleProvider TriangleProvider, ITriangleService TriangleService)
        {
            this.TriangleProvider = TriangleProvider;
            this.TriangleService = TriangleService;
        }

        public bool IsValid(int id)
        {
            bool x = false;
            Triangle tr = TriangleProvider.GetById(id);
            x = TriangleService.IsValidTriangle(tr.a, tr.b, tr.c);
            return x;
        }

        public bool IsAllValid()
        {
            List<Triangle> list = TriangleProvider.GetAll();
            bool x = true;

            if (list.Count == 0)
            {
                return false;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (TriangleService.IsValidTriangle(list[i].a, list[i].b, list[i].c) == false)
                {
                    x = false;
                    break;
                }
            }
            return x;
        }
    }
}
