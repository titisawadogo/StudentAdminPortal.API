using System;
using AutoMapper;
using StudentAdminPortal.API.DomainsModels;
using DataModels = StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Profiles.AfterMaps
{
    public class UpdateStudentRequestAfterMap : IMappingAction<UpdateStudentRequest, DataModels.Student>
    {
        public void Process(UpdateStudentRequest source, DataModels.Student destination, ResolutionContext context)
        {
            destination.Address = new DataModels.Address()
            {
                PhysicalAdress = source.PhysicalAdress,
                PostalAdress = source.PostalAdress
            };
        }
    }
}
