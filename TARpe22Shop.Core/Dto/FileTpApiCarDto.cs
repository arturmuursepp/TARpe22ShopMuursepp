using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe22ShopMyyrsepp.Core.Dto
{
    public class FileToApiCarDto
    {
        public Guid Id { get; set; }
        public string ExistingFilePath { get; set; }
        public Guid? CarId { get; set; }
    }
}
