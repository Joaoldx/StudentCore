using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using StudentCore.DataAccess.Context;
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
        private readonly IStudentCoreRepository _repository;
        private readonly IMapper _mapper;
        public StudentController(IMapper mapper, IStudentCoreRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            try {
                var results = await _repository.GetAllStudentsAsync();
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
            return await _repository.GetStudentByIdAsync(studentId);
        }

        [HttpGet("getByName/{studentName}")]
        public async Task<ICollection<Student>> GetByName(string studentName)
        {
            return await _repository.GetAllStudentsByNameAsync(studentName);
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentDto model){
            try
            {
                var student = _mapper.Map<Student>(model);    
                
                _repository.Add(student);
                
                if (await _repository.SaveChangesAsync()) {
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
                var student = await _repository.GetStudentByIdAsync(studentId);

                if (student == null) {
                    return NotFound();
                }

                _mapper.Map(model, student);
                
                _repository.Update(student);

                if (await _repository.SaveChangesAsync()) {
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
                var student = await _repository.GetStudentByIdAsync(studentId);
                if (student == null) {
                    return NotFound();
                }

                
                _repository.Delete(student);

                if (await _repository.SaveChangesAsync()) {
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