using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StudentAdminPortal.API.Repositories
{
    public interface IImageRepository
    {
        Task<String> Upload(IFormFile file, string fileName);
    }
}
