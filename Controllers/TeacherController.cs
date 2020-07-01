using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetWebCoreAPI.Models;
using Asp.NetWebCoreAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.NetWebCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        // GET: api/<TeacherController>
        [HttpGet]
        public IEnumerable<Teacher> Get()
        {
            return _teacherRepository.GetList(); ;
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Teacher teacherInfo = _teacherRepository.GetTeacher(id);
            if (teacherInfo == null)
                return NotFound();
            else
                return new ObjectResult(teacherInfo);
        }

        // POST api/<TeacherController>
        [HttpPost]
        public IActionResult Post([FromBody] Teacher teacher)
        {
            if (teacher == null) 
                return BadRequest();
            int retVal = _teacherRepository.Add(teacher);
            if (retVal > 0) 
                return Ok(); 
            else 
                return NotFound();
        }

        // PUT api/<TeacherController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] Teacher teacher)
        [HttpPut]
        public IActionResult Put([FromBody] Teacher teacher)
        {
            //if (teacher == null || id != teacher.Id) return BadRequest();
            if (teacher == null)
                return BadRequest();

            if (_teacherRepository.GetTeacher(teacher.Id) == null) return NotFound();
            int retVal = _teacherRepository.EditTeacher(teacher);
            if (retVal > 0) return Ok(); else return NotFound();
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int retVal = _teacherRepository.DeleteTeacher(id);
            if (retVal > 0) return Ok(); else return NotFound();
        }
    }
}
