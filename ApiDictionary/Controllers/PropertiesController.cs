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
        // GET: api/Properties
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Properties/5
        [HttpGet("{id}", Name = "Get")]
        public PropertyModel Get(string id)
        {
            return propertyService.Find(id);
        }

        // POST: api/Properties
        [HttpPost]
        public void Post(PropertyModel propertyModel)
        {
            //PropertyModel propertyModel = new PropertyModel();

            //propertyModel.Name = "codigoDeCuenta";
            //propertyModel.PropertyType = "string";
            //propertyModel.Examples = new List<string>(new string[] { "ES9121000418450200051333", "ES6621000418401234567894" });

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
