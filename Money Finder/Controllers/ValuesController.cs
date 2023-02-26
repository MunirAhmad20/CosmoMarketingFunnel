using Microsoft.AspNetCore.Mvc;
using Money_Finder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Money_Finder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        AppDBContext d = new AppDBContext();
        // GET: api/<ValuesController>
        
        [HttpGet]
        public List<DneDataBase> Get()
        {
            return d.DneDataBase.ToList();
        }
        //public IEnumerable<string> Get()
        //{


        //    return new string[] { "usman", "value2" };
        //}

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]

        public ActionResult<DneDataBase> Get(int id)
        {
            var del = d.DneDataBase.Where(o => o.DneDataBaseId == id).FirstOrDefault();
            d.DneDataBase.Remove(del);
           /// DNEdatabase cust = d.DNEdatabase.Find(id);
            //if (cust == null)
            //{
            //    return NotFound();
            //}
            return Ok(""+del.Gmail +" deleted successfully!!!!");
           
        }
        //public ActionResult<DNEdatabase> Get(string id)
        //{

        //    var dt = d.DNEdatabase.ToList();
        //   // DNEdatabase dt = new DNEdatabase(); 
        //   /// var employee = new DNEdatabase() { Id = 1, Name = "Nitish" }; // Get the data from db  
        //   /// return employee;
        //    return dt ;
        //    ///  return "'"+site.ToList()+"'";
        //    // return "'"+id+"'";
        //}

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string gmail)
        {
            Console.WriteLine(gmail);
           // DNEdatabase t = new DNEdatabase();
           // t.gmail = gmail;
           // d.DNEdatabase.Add(t);
           // d.SaveChanges();
           //return Ok ("Record save successfully!!!");
          // return Ok("" + gmail + " save successfully thanks for using our api");
         
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
