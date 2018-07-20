using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTFFAPI.Services;
using MTFFAPI.Entity;

namespace MTFFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static SimpleDBClient dBClient = new SimpleDBClient();
        /// <summary>
        /// 构造函数
        /// </summary>
        public ValuesController()
        {
            var x = 3;
            x += 1;
        }

        /// <summary>
        /// 螺丝扣搭街坊看
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Test1", "Test2" };
        }

        /// <summary>
        /// 获取一个Supplier 通过ID
        /// </summary>
        /// <param name="id">目标SupplierID</param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetByID(string id)
        {
            Entity.Supplier result = dBClient.getSupplierByID(id.ToString());
            if (result.SupplierID == "-1")
                return NotFound();
            else
                return Ok(result);
        }

        /// <summary>
        /// 添加一个supplier
        /// </summary>
        /// <param name="newSup">要添加的supplier的内容</param>
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] SupplierCreation newSup)
        {
            if (newSup == null)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            dBClient.addSupplier(newSup);
            return Created("api/values/"+newSup.SupplierID,newSup);
        }

        /// <summary>
        /// 完整更新一个supplier
        /// </summary>
        /// <param name="supModified">修改后全部</param>
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] SupplierModification supModified)
        {
            int result = dBClient.updateSupplier(supModified);
            if (result == 0)
                return NotFound();
            else
                return NoContent();
             
        }

        /// <summary>
        /// 删除一个supplier 通过ID
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            int resultCode = dBClient.delSupplierByID(id);
            if (resultCode == 1)
                return NoContent();
            else
                return NotFound();
        }
    }
}
