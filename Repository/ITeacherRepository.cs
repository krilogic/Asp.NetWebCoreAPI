using Asp.NetWebCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetWebCoreAPI.Repository
{
    public interface ITeacherRepository
    {
        int Add(Teacher teacher);

        List<Teacher> GetList();

        Teacher GetTeacher(int id);

        int EditTeacher(Teacher teacher);

        int DeleteTeacher(int id);
    }
}
