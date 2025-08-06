using Domin.Dtos.STD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction
{
    internal interface IWriteStdServ
    {
        Task<GetStudentDto> CreateStudentAsync(CreateStudentDto student);
        Task<GetStudentDto> UpdateStudentAsync(int id, UpdateStudentDto student);
        Task<bool> DeleteStudentAsync(int id);
    }
}
