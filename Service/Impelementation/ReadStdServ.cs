using AutoMapper;
using Domin.Abstraction;
using Domin.Dtos.STD;
using Domin.Entity;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Impelementation
{
    internal class ReadStdServ : IReadStdServ
    {
        IReadUnitOfWork _readUnitOfWork;
        IMapper _mapper;

        public ReadStdServ(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetStudentDto>> GetAllStudentsAsync()
        {
            return _mapper.Map<List<GetStudentDto>, List<StudentEntity>>(_readUnitOfWork.GetReadGenericRepo<StudentEntity>().GetAll().ToList());
        }

        public Task<GetStudentDto> GetStudentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetStudentDto>> GetStudentsByCourseIdAsync(int classId)
        {
            throw new NotImplementedException();
        }
    }
}
