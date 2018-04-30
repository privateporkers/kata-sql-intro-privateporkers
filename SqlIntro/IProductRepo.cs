using System;
using System.Collections.Generic;

namespace SqlIntro
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetProducts();
        void DeleteProduct(int id);
        void InsertProduct(String Name);
    }
}