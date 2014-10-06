using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchEngine.BusinessObjects
{
    public class DataEntity
    {
        public string EntityName { get; set; }
        public string Content   { get; set; }
    }

    public class DataCollection
    {
        public List<DataEntity> Entities { get; set; }
    }  
}
