using System;
using System.Collections.Generic;

namespace SqlIntro
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductWithReview();
        IEnumerable<Product> GetProductAndReview();
        void DeleteProduct(int id);
        void InsertProduct(String Name);
        void UpdateProduct(string ProductName, int ProductId);

    }
}