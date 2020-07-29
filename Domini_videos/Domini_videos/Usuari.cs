using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domini_videos
{
    class Usuari
    {
        private string usuari, nom, cognom, password, data;
        
        public List<Video> mis_videos = new List<Video>();
        private Video video=new Video();

        public Usuari()
        {
            usuari = "Usuari";
            nom = "Nom";
            cognom = "Cognom";
            password = "Password";
            data = "Data";
            //mis_videos = new List<Video>();
        }

        public void setUsuari()
        {
            Console.Write("Introduce tu usuario: ");
            usuari = Console.ReadLine();
            if (usuari.Length == 0)
                throw new CampBuitException();
            Console.Write("Nombre: ");
            nom = Console.ReadLine();
            if (nom.Length == 0)
                throw new CampBuitException();
            Console.Write("Apellido: ");
            cognom = Console.ReadLine();
            if (cognom.Length == 0)
                throw new CampBuitException();
            Console.Write("Contraseña: ");
            password = Console.ReadLine();
            if (password.Length == 0)
                throw new CampBuitException();
            Console.Write("data: ");
            data = Console.ReadLine();
            if (data.Length == 0)
                throw new CampBuitException();
            mis_videos = new List<Video>();
        }                

        public void crearVideo ()
        {
            video = new Video();
            Console.WriteLine("Crear video");
            video.setVideo();
            mis_videos.Add(video);

            /*Console.WriteLine(" ");
            Console.WriteLine("*************");
            for (int i=0;i<mis_videos.Count;i++)
            {
                Console.WriteLine("Video Creado " +i);
                mis_videos[i].getVideo();
            }
            Console.WriteLine("*************");
            Console.WriteLine(" ");*/
        }
        
        public string getUsuario()
        {
            return usuari;
        }

        public string getPassword()
        {
            return password;
        }

        
    }
}
