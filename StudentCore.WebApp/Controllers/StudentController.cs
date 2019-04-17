using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using StudentCore.DomainModel.Entities;
using StudentCore.DomainService.Repositories;
using StudentCore.DomainService.Repositories.Core;
using StudentCore.WebApp.Dtos;
using StudentCore.WebApp.Helpers;

namespace StudentCore.WebApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentCoreRepository _repositopry = new StudentCoreRepository();
        private readonly IMapper _mapper;
        public StudentController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            try {
                var results = await _repositopry.GetAllStudentsAsync();
                var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(results);
                return Ok(studentDtos);
            }
            catch (System.Exception ex) {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
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
        public async Task<IActionResult> Post(StudentDto model){
            try
            {
                var student = _mapper.Map<Student>(model);    
                
                _repositopry.Add(student);
                
                if (await _repositopry.SaveChangesAsync()) {
                    return Created($"/api/student/{model.Id}", _mapper.Map<StudentDto>(student));
                }
            }
            catch (System.Exception ex) {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
            return BadRequest();
        }


        [HttpPut("{StudentId}")]
        public async Task<IActionResult> Put(Guid studentId, StudentDto model)
        {
            try
            {
                var student = await _repositopry.GetStudentByIdAsync(studentId);

                if (student == null) {
                    return NotFound();
                }

                _mapper.Map(model, student);
                
                _repositopry.Update(student);

                if (await _repositopry.SaveChangesAsync()) {
                    return Created($"/api/student/{model.Id}", _mapper.Map<StudentDto>(student));
                }
            } 
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{StudentId}")]
        public async Task<IActionResult> Delete(Guid studentId)
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