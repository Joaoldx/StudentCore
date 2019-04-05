using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCore.DomainModel.Entities;
using StudentCore.DomainService.Repositories;
using StudentCore.DomainService.Repositories.Core;

namespace StudentCore.WebApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IStudentCoreRepository _repositopry = new StudentCoreRepository();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repositopry.GetAllTeachersAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        [HttpGet("getById/{teacherId}")]
        public async Task<Teacher> GetById(Guid teacherId)
        {
            return await _repositopry.GetTeacherByIdAsync(teacherId);
        }

        [HttpGet("getByName/{teacherName}")]
        public async Task<ICollection<Teacher>> GetByName(string teacherName)
        {
            return await _repositopry.GetAllTeachersByNameAsync(teacherName);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Teacher teacher)
        {
            try
            {
                _repositopry.Add(teacher);
                if (await _repositopry.SaveChangesAsync())
                {
                    return Created($"/api/teacher/{teacher.Id}", teacher);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Post(Guid teacherId, Teacher model)
        {
            try
            {
                var teacher = await _repositopry.GetTeacherByIdAsync(teacherId);

                if (teacher == null)
                {
                    return NotFound();
                }

                _repositopry.Update(model);

                if (await _repositopry.SaveChangesAsync())
                {
                    return Created($"/api/teacher/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Post(Guid teacherId)
        {
            try
            {
                var teacher = await _repositopry.GetTeacherByIdAsync(teacherId);
                if (teacher == null)
                {
                    return NotFound();
                }

                _repositopry.Delete(teacher);

                if (await _repositopry.SaveChangesAsync())
                {
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