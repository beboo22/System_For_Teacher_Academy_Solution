using Domin.Dtos.STD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction
{
    public interface IReadStdServ
    {
        Task<List<GetStudentDto>> GetAllStudentsAsync();
        Task<GetStudentDto> GetStudentByIdAsync(int id);

        Task<List<GetStudentDto>> GetStudentsByCourseIdAsync(int classId);
    }
}
