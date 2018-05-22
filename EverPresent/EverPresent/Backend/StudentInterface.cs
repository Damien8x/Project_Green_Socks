using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EverPresent.Models;

namespace EverPresent.Backend
{
    public class StudentInterface
    {

        
        public interface IStudentInterface
        {
            StudentModel Create(StudentModel data);
            StudentModel Read(string id);
            StudentModel Update(StudentModel data);
            bool Delete(string id);
            List<StudentModel> Index();
            void Reset();
        }



    }
}

