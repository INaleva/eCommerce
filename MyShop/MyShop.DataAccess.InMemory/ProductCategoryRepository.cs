using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCatergory> productsCategories;

        public ProductCategoryRepository()
        {
            productsCategories = cache["productsCategories"] as List<ProductCatergory>;
            if (productsCategories == null)
            {
                productsCategories = new List<ProductCatergory>();
            }
        }

        public void Commit()
        {
            cache["productsCategories"] = productsCategories;
        }

        public void Insert(ProductCatergory p)
        {
            productsCategories.Add(p);
        }

        public void Update(ProductCatergory productCatergory)
        {
            ProductCatergory productCatergoryToUpdate = productsCategories.Find(p => p.Id == productCatergory.Id);

            if (productCatergoryToUpdate != null)
            {
                productCatergoryToUpdate = productCatergory;
            }
            else
            {
                throw new Exception("Product Category not found.");
            }
        }

        public ProductCatergory Find(string Id)
        {
            ProductCatergory productCatergory = productsCategories.Find(p => p.Id == Id);

            if (productCatergory != null)
            {
                return productCatergory;
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }

        public IQueryable<ProductCatergory> Collction()
        {
            return productsCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCatergory productCategoryToDelete = productsCategories.Find(p => p.Id == Id);

            if (productCategoryToDelete != null)
            {
                productsCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }
    }
}
