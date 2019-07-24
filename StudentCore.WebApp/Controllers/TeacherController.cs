using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCore.DomainModel.Entities;
using StudentCore.DataAccess.Repositories;
using StudentCore.DataAccess.Repositories.Core;
using StudentCore.WebApp.Dtos;

namespace StudentCore.WebApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStudentCoreRepository _repository;
        
        public TeacherController(IMapper mapper, IStudentCoreRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetAllTeachersAsync();
                var teacherDtos = _mapper.Map<IEnumerable<TeacherDto>>(results);
                return Ok(teacherDtos);
                
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpGet("getById/{teacherId}")]
        public async Task<Teacher> GetById(Guid teacherId)
        {
            return await _repository.GetTeacherByIdAsync(teacherId);
        }

        [HttpGet("getByName/{teacherName}")]
        public async Task<ICollection<Teacher>> GetByName(string teacherName)
        {
            return await _repository.GetAllTeachersByNameAsync(teacherName);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Teacher teacher)
        {
            try
            {
                _repository.Add(teacher);
                if (await _repository.SaveChangesAsync())
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
        public async Task<IActionResult> Put(Guid teacherId, Teacher model)
        {
            try
            {
                var teacher = await _repository.GetTeacherByIdAsync(teacherId);

                if (teacher == null)
                {
                    return NotFound();
                }

                _repository.Update(model);

                if (await _repository.SaveChangesAsync())
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
        public async Task<IActionResult> Delete(Guid teacherId)
        {
            try
            {
                var teacher = await _repository.GetTeacherByIdAsync(teacherId);
                if (teacher == null)
                {
                    return NotFound();
                }

                _repository.Delete(teacher);

                if (await _repository.SaveChangesAsync())
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