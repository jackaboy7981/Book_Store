using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_store.Models
{
    internal interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(string id);
        Category AddCategory(Category category);
        int UpdateCategory(string id, Category category);
        void DeleteCategory(int id);
    }
}
