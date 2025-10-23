using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class FileToApi
    {
        public Guid ImageID { get; set; }
        public string? ExistingFilePath { get; set; }
        public Guid? MovieID { get; set; }
        public bool? IsPoster { get; set; } //Määrab ära kas pilt on poster või mitte
    }
}
