using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiassinmnts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    { 
        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public List<StudentModel> Get(int id)
        {
            StudentModel obj = new StudentModel();
            List<StudentModel> studentList = obj.GetDetails();
            return studentList;
        }

        // POST api/values
        [HttpPost]
        public List<StudentModel> Post([FromBody] StudentModel value)
        {
            StudentModel obj1 = new StudentModel();
            List<StudentModel> lsc=obj1.GetDetails();
            lsc.Add(value);
            return lsc;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public List<StudentModel> Put(int id, [FromBody] StudentModel value)
        {
            StudentModel obj2 = new StudentModel();
            List<StudentModel> lst=obj2.GetDetails();
            foreach(var val in lst)
            {
                
                if(val.Id == value.Id)
                {
                    val.FirstName = value.FirstName;
                    val.LastName = value.LastName;
                    val.Id = value.Id;
                    val.Division = value.Division;
                    val.Grade = value.Grade;

                }
            }
            return lst;
        }

        // DELETE api/values/5
        [HttpDelete]
        public List<StudentModel> Delete([FromBody]StudentModel value)
        {
            StudentModel obj3 = new StudentModel();
            List<StudentModel> list = obj3.GetDetails();
            int i;
            for(i=0;i<list.Count;i++)
            {
                if(list[i].Id==value.Id)
                {
                    break;

                }
            }
            list.RemoveAt(i);
            return list;
        }
    }

    public class StudentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public int Division { get; set; }
        public string Grade { get; set; }

        public List<StudentModel> obj = new List<StudentModel>();

        public List<StudentModel> GetDetails()
        { 
            obj.Add(new StudentModel { FirstName = "Anu", LastName = "Sharma", Id = 1, Division = 1, Grade = "A" });
            obj.Add(new StudentModel { FirstName = "Ankit", LastName = "Sharma", Id = 2, Division = 2, Grade = "B" });
            obj.Add(new StudentModel { FirstName = "Mohit", LastName = "Gupta", Id = 3, Division = 1, Grade = "A" });
            obj.Add(new StudentModel { FirstName = "Anil", LastName = "Thakur", Id = 4, Division = 3, Grade = "C" });
            obj.Add(new StudentModel { FirstName = "Ria", LastName = "Dey", Id = 5, Division = 2, Grade = "B" });

            return obj;
        }
        
    }

}
