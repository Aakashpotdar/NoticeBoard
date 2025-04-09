using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::Model.Interface;

namespace Model.Model
{
    /// <summary>
    /// class for Database connection
    /// </summary>
    public class NoticeBoardDBConnection:INoticeBoardDBConnection
    {
        /// <summary>
        /// for connection string
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// for database name
        /// </summary>
        public string dbName { get; set; }
    }
}
