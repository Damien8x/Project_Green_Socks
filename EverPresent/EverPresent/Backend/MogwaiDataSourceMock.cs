using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _5051.Models;
namespace _5051.Backend
{
    /// <summary>
    /// Backend Mock DataSource for Mogwai, to manage them
    /// </summary>
    public class MogwaiDataSourceMock : IMogwaiInterface
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile MogwaiDataSourceMock instance;
        private static object syncRoot = new Object();

        private MogwaiDataSourceMock() { }

        public static MogwaiDataSourceMock Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MogwaiDataSourceMock();
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
        private List<MogwaiModel> mogwaiList = new List<MogwaiModel>();

        /// <summary>
        /// Makes a new Mogwai
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Avatar Passed In</returns>
        public MogwaiModel Create(MogwaiModel data)
        {
            mogwaiList.Add(data);
            return data;
        }

        /// <summary>
        /// Return the data for the id passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Null or valid data</returns>
        public MogwaiModel Read(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var myReturn = mogwaiList.Find(n => n.Id == id);
            return myReturn;
        }

        /// <summary>
        /// Update all attributes to be what is passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Null or updated data</returns>
        public MogwaiModel Update(MogwaiModel data)
        {
            if (data == null)
            {
                return null;
            }
            var myReturn = mogwaiList.Find(n => n.Id == data.Id);
            myReturn.Name = data.Name;
            myReturn.Description = data.Description;
            myReturn.Uri = data.Uri;

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

            var myData = mogwaiList.Find(n => n.Id == Id);
            var myReturn = mogwaiList.Remove(myData);
            return myReturn;
        }

        /// <summary>
        /// Return the full dataset
        /// </summary>
        /// <returns>List of Mogwai</returns>
        public List<MogwaiModel> Index()
        {
            return mogwaiList;
        }

        /// <summary>
        /// Reset the Data, and reload it
        /// </summary>
        public void Reset()
        {
            mogwaiList.Clear();
            Initialize();
        }

        /// <summary>
        /// Create Placeholder Initial Data
        /// </summary>
        public void Initialize()
        {
            var count = 0;
            Create(new MogwaiModel("avatar" + count++.ToString() + ".png", "Police", "Happy Officer"));
            Create(new MogwaiModel("avatar" + count++.ToString() + ".png", "Kunoichi", "Ninja Lady"));
            Create(new MogwaiModel("avatar" + count++.ToString() + ".png", "Angry", "Angry, but happy"));
            Create(new MogwaiModel("avatar" + count++.ToString() + ".png", "Playfull", "Anyone want a ride?"));
            Create(new MogwaiModel("avatar" + count++.ToString() + ".png", "Pirate", "Where is my ship?"));
            Create(new MogwaiModel("avatar" + count++.ToString() + ".png", "Blue", "Having a Blue Day"));
            Create(new MogwaiModel("avatar" + count++.ToString() + ".png", "Pigtails", "Love my hair"));
            Create(new MogwaiModel("avatar" + count++.ToString() + ".png", "Ninja", "Taste my Katana"));
            Create(new MogwaiModel("avatar" + count++.ToString() + ".png", "Circus", "Swinging from the Trapeese"));
            Create(new MogwaiModel("avatar" + count++.ToString() + ".png", "Chief", "I love to cook"));
        }
    }
}