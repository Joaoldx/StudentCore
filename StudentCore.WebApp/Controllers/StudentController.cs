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
    }
}