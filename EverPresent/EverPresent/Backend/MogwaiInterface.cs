using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _5051.Models;

namespace _5051.Backend
{

    /// <summary>
    /// Datasource Interface for Mogwais
    /// </summary>
    public interface IMogwaiInterface
    {
        MogwaiModel Create(MogwaiModel data);
        MogwaiModel Read(string id);
        MogwaiModel Update(MogwaiModel data);
        bool Delete(string id);
        List<MogwaiModel> Index();
        void Reset();
    }
}