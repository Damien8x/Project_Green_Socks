using EverPresent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EverPresent.Backend
{
    /// <summary>
    /// Mogwai Backend handles the business logic and data for Mogwai
    /// </summary>
    public class StudentBackend
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile StudentBackend instance;
        private static object syncRoot = new Object();

        private StudentBackend() { }

        public static StudentBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new StudentBackend();
                            SetDataSource(SystemGlobals.Instance.DataSourceValue);
                        }
                    }
                }

                return instance;
            }
        }

        // Get the Datasource to use
       private static StudentInterface.IStudentInterface DataSource;

        /// <summary>
        /// Sets the Datasource to be Mock or SQL
        /// </summary>
        /// <param name="dataSourceEnum"></param>
        public static void SetDataSource(DataSourceEnum dataSourceEnum)
        {
            if (dataSourceEnum == DataSourceEnum.SQL)
            {
                // SQL not hooked up yet...
                throw new NotImplementedException();
            }

            // Default is to use the Mock
            DataSource = StudentDataSourceMock.Instance;
        }

        /// <summary>
        /// Makes a new Mogwai
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Avatar Passed In</returns>
        public StudentModel Create(StudentModel data)
        {
            DataSource.Create(data);
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

            var myReturn = DataSource.Read(id);
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

            var myReturn = DataSource.Update(data);

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

            var myReturn = DataSource.Delete(Id);
            return myReturn;
        }

        /// <summary>
        /// Return the full dataset
        /// </summary>
        /// <returns>List of Avatars</returns>
        public List<StudentModel> Index()
        {
            var myData = DataSource.Index();
            return myData;
        }

        /// <summary>
        /// Helper that returns the First Mogwai ID in the list, this will be used for creating new avatars if no mogwaiID is specified
        /// </summary>
        /// <returns>Null, or Mogwai ID of the first avatar in the list.</returns>
        public string GetFirstStudentId()
        {
            string myReturn = null;

            var myData = DataSource.Index().ToList().FirstOrDefault();
            if (myData != null)
            {
                myReturn = myData.Id;
            }

            return myReturn;
        }

        /// <summary>
        /// Helper function that returns the Mogwai Image URI
        /// </summary>
        /// <param name="data">The mogwaiId to look up</param>
        /// <returns>null, or the mogwai image URI</returns>
        public string GetAvatarId(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            string myReturn = null;

            var myData = DataSource.Read(data);
            if (myData != null)
            {
                myReturn = myData.AvatarId;
            }

            return myReturn;
        }

        /// <summary>
        /// Helper that gets the list of Items, and converst them to a SelectList, so they can show in a Drop Down List box
        /// </summary>
        /// <param name="id">optional paramater, of the Item that is currently selected</param>
        /// <returns>List of SelectListItems as a SelectList</returns>
        public List<SelectListItem> GetStudentListItem(string id = null)
        {
            var myDataList = DataSource.Index();

            //  var myReturn = new SelectList(myDataList);

            var myReturn = myDataList.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id,
                Selected = (a.Id == id),
            }).ToList();

            return myReturn;

        }

        /// <summary>
        /// Helper function that resets the DataSource, and rereads it.
        /// </summary>
        public void Reset()
        {
            DataSource.Reset();
        }
    }
}