using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EverPresent.Models
{
    /// <summary>
    /// The Mock Status
    /// </summary>
    public enum DataSourceEnum
    {
        // Not specified
        Unknown = 0,

        // Mock Dataset
        Mock = 1,

        // SQL Dataset
        SQL = 2
    }
}