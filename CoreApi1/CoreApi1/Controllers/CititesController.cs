using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi1.Model;
namespace CoreApi1.Controllers
{
    [Route("api/cities")]
    public class CititesController: Controller
    {
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok(CitiesRepository.GetAll());
        }


        [HttpGet("{ctno}")]
        public IActionResult Get(int ctno)
        {
            var c = CitiesRepository.Get(ctno);
            if (c != null)
                return Ok(c);
            else
                return NotFound("No Such City");
         }
        [HttpPost("{ct}")]
        public IActionResult NewCity(City ct)
        {
            CitiesRepository.Add(ct);
            return Ok(ct);
        }

    }
}
