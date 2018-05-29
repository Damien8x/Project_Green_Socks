using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EverPresent.Models;
using EverPresent.Models.Enums;
using static EverPresent.Backend.StudentInterface;

namespace EverPresent.Backend
{
    /// <summary>
    /// Holds the Student Data as a Mock Data set, used for Unit Testing, System Testing, Offline Development etc.
    /// </summary>
    public class StudentDataSourceMock : IStudentInterface
    {
        /// <summary>
        /// Make into a singleton
        /// </summary>
        private static volatile StudentDataSourceMock instance;
        private static object syncRoot = new Object();

        private StudentDataSourceMock() { }

        public static StudentDataSourceMock Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new StudentDataSourceMock();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The Data for the Students
        /// </summary>
        private List<StudentModel> StudentList = new List<StudentModel>();

        /// <summary>
        /// Makes a new Student
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Student Passed In</returns>
        public StudentModel Create(StudentModel data)
        {
            StudentList.Add(data);
            return data;
        }

        /// <summary>
        /// Return the data for the id passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Null or valid data</returns>
        public StudentModel Read(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var myReturn = StudentList.Find(n => n.Id == id);
            return myReturn;
        }

        /// <summary>
        /// Update all attributes to be what is passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Null or updated data</returns>
        public StudentModel Update(StudentModel data)
        {
            if (data == null)
            {
                return null;
            }
            var myReturn = StudentList.Find(n => n.Id == data.Id);

            myReturn.Update(data);

            return myReturn;
        }

        /// <summary>
        /// Remove the Data item if it is in the list
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True for success, else false</returns>
        public bool Delete(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return false;
            }

            var myData = StudentList.Find(n => n.Id == Id);
            var myReturn = StudentList.Remove(myData);
            return myReturn;
        }

        /// <summary>
        /// Return the full dataset
        /// </summary>
        /// <returns>List of Students</returns>
        public List<StudentModel> Index()
        {
            return StudentList;
        }

        /// <summary>
        /// Reset the Data, and reload it
        /// </summary>
        public void Reset()
        {
            StudentList.Clear();
            Initialize();
        }

        /// <summary>
        /// Create Placeholder Initial Data
        /// </summary>
        public void Initialize()
        {
            StudentStatusEnum studentStatusEnum1 = StudentStatusEnum.Hold;
            StudentStatusEnum studentStatusEnum2 = StudentStatusEnum.In;
            StudentStatusEnum studentStatusEnum3 = StudentStatusEnum.Out;

            
            StudentList.Add(new StudentModel("1" ,"pokemon_bee.svg", "Andrew", studentStatusEnum3, 1200));
            StudentList.Add(new StudentModel("pokemon_duck.svg", "Bernard", studentStatusEnum3, 700));
            StudentList.Add(new StudentModel("pokemon_old_guy.svg", "Jeff", studentStatusEnum3, 500));
            StudentList.Add(new StudentModel("pokemon-6.svg", "Megan", studentStatusEnum3, 300));
            StudentList.Add(new StudentModel("pokemon_bee.svg", "Britney", studentStatusEnum3, 1100));
            StudentList.Add(new StudentModel("2", "avatar4.png", "Dane", studentStatusEnum1, 0));
            StudentList.Add(new StudentModel("3", "avatar5.png", "Daniel", studentStatusEnum1, 0));
            StudentList.Add(new StudentModel("4", "avatar6.png", "Shelly", studentStatusEnum1, 0));
            StudentList.Add(new StudentModel("5", "avatar7.png", "Sarah", studentStatusEnum1, 0));

        }
    }



}