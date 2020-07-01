using Asp.NetWebCoreAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetWebCoreAPI.Repository
{
    public class SqlHelper : ISqlHelper
    {
        IConfiguration _configuration;
        public string constring;

        public SqlHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            constring = _configuration["ConnectionStrings:DefaultConnection"];
        }
        public int ExecuteCurdQuery(string strSql)
        {
            int count = 0;
            using (SqlConnection con = new SqlConnection(constring))
            {
                //string sql = $"Insert into Teacher(Name, Skills, TotalStudents, Salary, AddedOn) values('{teacher.Name}','{teacher.Skills}','{teacher.TotalStudents}','{teacher.Salary}','{teacher.AddedOn}')";
                string sql = strSql;
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    count = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return count;
        }

        public DataTable ExecuteSelectQuery(string strSql)
        {
            DataTable dt = null;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                //string sql = "Select * From Teacher";
                string sql = strSql;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (!(dt.Rows.Count > 0))
                    dt = null;

                //using (SqlDataReader dr = cmd.ExecuteReader())
                //{
                //    while (dr.Read())
                //    {
                //        Teacher teacher = new Teacher();
                //        teacher.Id = Convert.ToInt32(dr["Id"]);
                //        teacher.Name = Convert.ToString(dr["Name"]);
                //        teacher.Salary = Convert.ToDecimal(dr["Salary"]);
                //        teacher.Skills = Convert.ToString(dr["Skills"]);
                //        teacher.TotalStudents = Convert.ToInt32(dr["TotalStudents"]);
                //        teacher.AddedOn = Convert.ToDateTime(dr["AddedOn"]);

                //        teacherList.Add(teacher);
                //    }
                //}
                return dt;
            }
        }

        public Teacher GetTeacherInfoByRow(DataRow dr)
        {
            Teacher teacher = new Teacher();
            teacher.Id = Convert.ToInt32(dr["Id"]);
            teacher.Name = Convert.ToString(dr["Name"]);
            teacher.Salary = Convert.ToDecimal(dr["Salary"]);
            teacher.Skills = Convert.ToString(dr["Skills"]);
            teacher.TotalStudents = Convert.ToInt32(dr["TotalStudents"]);
            teacher.AddedOn = Convert.ToDateTime(dr["AddedOn"]);
            return teacher;
        }
    }
}
