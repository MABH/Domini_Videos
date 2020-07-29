using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domini_videos
{
    class Video
    {
        private string titol, URL;
        private List<string> tags;

        public Video()
        {
            titol = "Titol";
            URL = "URL";
            tags = new List<string>();
        }

        public void setVideo()
        {
            Console.Write("Introduce el título del video: ");
            titol = Console.ReadLine();
            if (titol.Length == 0)
                throw new CampBuitException();
            Console.Write("Introduce la URL: ");
            URL = Console.ReadLine();
            if (URL.Length == 0)
                throw new CampBuitException();
            setListaTags(tags);
        }

        private void setListaTags(List<string> lista_tags_video)
        {
            string seguir="s";
            string tag_video;

            while (seguir == "s" || seguir == "S")
            {
                Console.Write("Introduce un Tag: ");
                tag_video = Console.ReadLine();
                if (tag_video.Length == 0)
                    throw new CampBuitException();
                lista_tags_video.Add(tag_video);

                Console.Write("Quieres introducir otro tag? (s/n) ");
                seguir = Console.ReadLine();

                if (seguir != "s" && seguir != "S" && seguir != "n" && seguir != "N")
                {
                    Console.WriteLine("Respuesta incorrecta¡¡");
                    Console.Write("Quieres introducir otro tag? (s/n) ");
                    seguir = Console.ReadLine();
                }
            }
        }

        public void setTag (string tag)
        {
            tags.Add(tag);
        }

        public void getVideo()
        {
            Console.WriteLine("Titol: " + titol);
            Console.WriteLine("URL: " + URL);
            Console.WriteLine("Tags:");
            for(int i=0;i<tags.Count;i++)
            {
                Console.Write(tags[i]+", ");
            }
            Console.WriteLine("  ");
            Console.WriteLine("  ");
        }

        public void Reproduir()
        {
            Console.WriteLine("Reproduciendo video " + titol);
        }

        public void Parar()
        {
            Console.WriteLine("Parando video " + titol);
        }

        public void Pausar()
        {
            Console.WriteLine("Pausando video " + titol);
        }

        public string getTitol()
        {
            return titol;
        }
    }
}
