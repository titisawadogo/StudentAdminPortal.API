﻿using System;
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
    }
}
