using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domini_videos
{
    public class CampBuitException:Exception
    {
        public CampBuitException()
        {
            Console.Write("Excepción de campo vacio");
        }
    }
}
