using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EverPresent.Models;
using EverPresent.Models.Enums;
using static EverPresent.Backend.StudentInterface;

namespace EverPresent.Backend
{

    public class StudentDataSourceMock : IStudentInterface
    {

        /// <summary>
        /// Make into a Singleton
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
        /// The Avatar List
        /// </summary>
        private List<StudentModel> studentList = new List<StudentModel>();

        /// <summary>
        /// Makes a new Mogwai
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Avatar Passed In</returns>
        public StudentModel Create(StudentModel data)
        {
            studentList.Add(data);
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

            var myReturn = studentList.Find(n => n.Id == id);
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
            var myReturn = studentList.Find(n => n.Id == data.Id);
            myReturn.Name = data.Name;
            myReturn.AvatarId = data.AvatarId;
            myReturn.Status = data.Status;

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

            var myData = studentList.Find(n => n.Id == Id);
            var myReturn = studentList.Remove(myData);
            return myReturn;
        }

        /// <summary>
        /// Return the full dataset
        /// </summary>
        /// <returns>List of Mogwai</returns>
        public List<StudentModel> Index()
        {
            return studentList;
        }

        /// <summary>
        /// Reset the Data, and reload it
        /// </summary>
        public void Reset()
        {
            studentList.Clear();
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

            
            studentList.Add(new StudentModel("pokemon_bee.svg", "John", studentStatusEnum1));
            studentList.Add(new StudentModel("pokemon_duck.svg", "Andrew", studentStatusEnum2));
            studentList.Add(new StudentModel("pokemon_old_guy.svg", "Jeff", studentStatusEnum1));
            studentList.Add(new StudentModel("pokemon-6.svg", "Megan", studentStatusEnum3));
            studentList.Add(new StudentModel("pokemon_bee.svg", "Britney", studentStatusEnum2));

        }
    }



}