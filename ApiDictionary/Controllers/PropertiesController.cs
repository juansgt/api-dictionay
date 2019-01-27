using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDictionary.Models;
using ApiDictionary.Services.PropertyService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDictionary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private IPropertyService propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }

        [HttpGet]
        public IEnumerable<PropertyModel> FindAllPropertiesFilter(string propertyType, string name, string description, string operand)
        {
            PropertyFilter propertyFilter = new PropertyFilter(propertyType, name, description);

            return propertyService.FindAllFilter(propertyFilter, PropertyFilter.Operand.AND);
        }

        //// GET: api/Properties
        //[HttpGet]
        //public IEnumerable<PropertyModel> GetAllPropertiesByName(string name)
        //{
        //    return propertyService.FindAllByName(name);
        //}

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public PropertyModel Get(string id)
        {
            return propertyService.Find(id);
        }

        // POST: api/Properties
        [HttpPost]
        public void Post(PropertyModel propertyModel)
        {
            propertyService.CreateProperty(propertyModel);
        }

        // PUT: api/Properties/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
