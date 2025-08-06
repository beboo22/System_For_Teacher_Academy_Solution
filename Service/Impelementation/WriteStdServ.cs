using Domin.Dtos.STD;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Impelementation
{
    internal class WriteStdServ : IWriteStdServ
    {
        public Task<GetStudentDto> CreateStudentAsync(CreateStudentDto student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetStudentDto> UpdateStudentAsync(int id, UpdateStudentDto student)
        {
            throw new NotImplementedException();
        }
    }
}
