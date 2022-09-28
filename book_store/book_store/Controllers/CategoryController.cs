using book_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace book_store.Controllers
{
    public class CategoryController : ApiController
    {

        private ICategoryRepository repository;

        public CategoryController()
        {
            repository = new CategorySqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCategories();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            var data = repository.GetCategoryById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Category category)
        {
            var data = repository.AddCategory(category);
            return Ok(data);
        }

        // PUT api/values/5
        public IHttpActionResult Put(string id, [FromBody] Category category)
        {
            var data = repository.UpdateCategory(id, category);
            
            return Ok(data);
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(string id)
        {
            var data = repository.DeleteCategory(id);

            return Ok(data);
        }
    }
}
