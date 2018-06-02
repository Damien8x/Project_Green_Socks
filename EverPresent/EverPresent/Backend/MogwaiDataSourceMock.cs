using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EverPresent.Models;
namespace EverPresent.Backend
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
            myReturn.Family = data.Family;
            myReturn.Uri = data.Uri;
            myReturn.Cost = data.Cost;
            myReturn.Level = data.Level;
            myReturn.Rarity = data.Rarity;

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
            // Create 8 Mock Mogwai
            Create(new MogwaiModel("avatar9.png", "Jord", "Aegir", 100, 1, 1));
            Create(new MogwaiModel("avatar1.png", "Frey", "Aegir", 200, 2, 1));
            Create(new MogwaiModel("avatar2.png", "Hodr", "Tyr", 100, 1, 1));
            Create(new MogwaiModel("avatar3.png", "Vili", "Tyr", 300, 3, 4));
            Create(new MogwaiModel("avatar4.png", "Loki", "Odin", 500, 5, 1));
            Create(new MogwaiModel("avatar5.png", "Frigg", "Odin", 200, 2, 1));
            Create(new MogwaiModel("avatar6.png", "Sif", "Odin", 100, 4, 1));
            Create(new MogwaiModel("avatar7.png", "Burr", "Odin", 200, 1, 2));
        }
    }
}