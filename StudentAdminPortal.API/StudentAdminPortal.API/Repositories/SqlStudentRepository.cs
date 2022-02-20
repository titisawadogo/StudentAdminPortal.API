using System;
using System.Collections.Generic;
using System.Linq;
using StudentAdminPortal.API.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext context;

        public SqlStudentRepository(StudentAdminContext context)
        {
            this.context = context;
        }

       
        public async Task<List<Student>> GetStudentsAsync() // add async
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync(); // add async and ToListAsync
        }


        public async Task<Student> GetStudentAsync(Guid studentId)
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<List<Gender>> GetGenderAsync()
        {
            return await context.Gender.ToListAsync();
        }


        //From there is to update
        public async Task<bool> Exists(Guid studentId)
        {
            return await context.Student.AnyAsync(x => x.Id == studentId);
        }

        public async Task<Student> UpdateStudent(Guid studentId, Student request)
        {
            var existingStudent = await GetStudentAsync(studentId);
            if(existingStudent != null)
            {
                existingStudent.FirstName = request.FirstName;
                existingStudent.LastName = request.LastName;
                existingStudent.DateOfBirth = request.DateOfBirth;
                existingStudent.Email = request.Email;
                existingStudent.Mobile = request.Mobile;
                existingStudent.GenderId = request.GenderId;
                existingStudent.Address.PhysicalAdress = request.Address.PhysicalAdress;
                existingStudent.Address.PostalAdress = request.Address.PostalAdress;


                await context.SaveChangesAsync();
                return existingStudent;
            }

            return null;
        }
    }
}
