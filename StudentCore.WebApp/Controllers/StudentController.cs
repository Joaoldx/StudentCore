using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using StudentCore.DomainModel.Entities;
using StudentCore.DomainService.Repositories;
using StudentCore.DomainService.Repositories.Core;

namespace StudentCore.WebApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentCoreRepository _repositopry = new StudentCoreRepository();

        [HttpGet]
        public async Task<IActionResult> Get() {
            try {
                var results = await _repositopry.GetAllStudentsAsync();
                return Ok(results);
            }
            catch (System.Exception) {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        } 

        [HttpGet("getById/{studentId}")]
        public async Task<Student> GetById(Guid studentId)
        {
            return await _repositopry.GetStudentByIdAsync(studentId);
        }

        [HttpGet("getByName/{studentName}")]
        public async Task<ICollection<Student>> GetByName(string studentName)
        {
            return await _repositopry.GetAllStudentsByNameAsync(studentName);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student){
            try {
                _repositopry.Add(student);
                if (await _repositopry.SaveChangesAsync()) {
                    return Created($"/api/student/{student.Id}", student);
                }
            }
            catch (System.Exception) {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
            return BadRequest();
        }


        [HttpPut]
        public async Task<IActionResult> Post(Guid studentId, Student model)
        {
            try
            {
                var student = await _repositopry.GetStudentByIdAsync(studentId);

                if (student == null) {
                    return NotFound();
                }
                
                _repositopry.Update(model);

                if (await _repositopry.SaveChangesAsync()) {
                    return Created($"/api/student/{model.Id}", model);
                }
            } 
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Post(Guid studentId)
        {
            try
            {
                var student = await _repositopry.GetStudentByIdAsync(studentId);
                if (student == null) {
                    return NotFound();
                }

                
                _repositopry.Delete(student);

                if (await _repositopry.SaveChangesAsync()) {
                    return Ok();
                }
            } 
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }

            return BadRequest();
        }
    }
}