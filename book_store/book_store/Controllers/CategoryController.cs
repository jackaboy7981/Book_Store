using book_store.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace book_store.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers:"*", methods:"*")]
    public class CategoryController : ApiController
    {

        private ICategoryRepository repository;

        public CategoryController()
        {
            repository = new CategorySqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Getallcategories()
        {
            List<Category> data = repository.GetAllCategories();
            Debug.WriteLine("\ndata1  = ",data[0].Categoryname,"\n");
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Getcategorybyid(string id)
        {
            var data = repository.GetCategoryById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Addnewcategory(Category category)
        {
            var data = repository.AddCategory(category);
            return Ok(data);
        }

        // PUT api/values/5
        public IHttpActionResult Updatecategory(string id, [FromBody] Category category)
        {
            var data = repository.UpdateCategory(id, category);
            
            return Ok(data);
        }

        // DELETE api/values/5
        public IHttpActionResult Deletecategory(string id)
        {
            var data = repository.DeleteCategory(id);

            return Ok(data);
        }
    }
}
