using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainsModels;
using StudentAdminPortal.API.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]

    public class GenderController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public GenderController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]

        public async Task<IActionResult> GetAllGenders()
        {
            var genderList = await studentRepository.GetGenderAsync();

            if(genderList == null || !genderList.Any())
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<Gender>>(genderList));
        }
    }
}
