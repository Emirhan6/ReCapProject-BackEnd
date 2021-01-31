using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Cars> GetAll();
        List<Cars> GetById(int productId);
        void Add(Cars cars);
        void Update(Cars cars);
        void Delete(Cars cars);

    }
}
