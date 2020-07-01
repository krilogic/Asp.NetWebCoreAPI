using Asp.NetWebCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetWebCoreAPI.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        ISqlHelper _sqlHelper;
        public TeacherRepository(ISqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }
        public int Add(Teacher teacher)
        {
            string sql = $"Insert into Teacher(Name, Skills, TotalStudents, Salary, AddedOn) values('{teacher.Name}','{teacher.Skills}','{teacher.TotalStudents}','{teacher.Salary}','{teacher.AddedOn}')";
            int retVal = _sqlHelper.ExecuteCurdQuery(sql);
            return retVal;
        }

        public int DeleteTeacher(int id)
        {
            string sql = $"Delete from Teacher where Id = {id}";
            int retVal = _sqlHelper.ExecuteCurdQuery(sql);
            return retVal;
        }

        public int EditTeacher(Teacher teacher)
        {
            string sql = $"update Teacher set Name = '{teacher.Name}', Skills = '{teacher.Skills}', TotalStudents = '{teacher.TotalStudents}', Salary ='{teacher.Salary}' , AddedOn ='{teacher.AddedOn}'  where Id = '{teacher.Id}'";
            int retVal = _sqlHelper.ExecuteCurdQuery(sql);
            return retVal;
        }

        public List<Teacher> GetList()
        {
            List<Teacher> teacherList = new List<Teacher>();
            string sql = "Select * From Teacher";
            DataTable dtTeacherInfo = _sqlHelper.ExecuteSelectQuery(sql);
            if (dtTeacherInfo != null)
            {
                teacherList = new List<Teacher>();
                foreach (DataRow dr in dtTeacherInfo.Rows)
                    teacherList.Add(_sqlHelper.GetTeacherInfoByRow(dr));
            }
            return teacherList;
        }

        public Teacher GetTeacher(int id)
        {
            Teacher teacherInfo = null;
            string sQry = $"select * from Teacher where Id= {id}";
            DataTable dtTeacherInfo = _sqlHelper.ExecuteSelectQuery(sQry);
            if (dtTeacherInfo != null)
            {
                DataRow dr = dtTeacherInfo.Rows[0];
                teacherInfo = _sqlHelper.GetTeacherInfoByRow(dr);
            }
            return teacherInfo;
        }
    }
}
