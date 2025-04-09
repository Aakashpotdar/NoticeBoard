using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    /// <summary>
    /// interface DB connection settings
    /// </summary>
    public interface INoticeBoardDBConnection
    {
        /// <summary>
        /// interface for connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// interface for database name
        /// </summary>
        public string dbName { get; set; }
    }
}
