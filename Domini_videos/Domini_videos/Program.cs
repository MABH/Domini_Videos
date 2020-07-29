using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domini_videos
{
    class Program
    {
        public enum Accions { SELECCIONAR=1, AÑADIR=2, REPRODUIR=3, PARAR=4, PAUSA=5, ANTERIOR=6 };
        static string opcio="";

        static List<Usuari> usuaris=new List<Usuari>();
        static List<Video> videos = new List<Video>();

        static Usuari mi_usuari=new Usuari();
        static bool logued = false;

        static bool hayVideo = false;

        static string log_usuario, password_usuario;
        static string aux_usuario, aux_password;

        static void Main(string[] args)
        {
            Menu();
        }

        static public void Menu()
        {        
            while (opcio != "1" && opcio != "2" && opcio != "3" || opcio == "0")
            {
                Console.Clear();
                Console.WriteLine("1.- Crear usuario");
                Console.WriteLine("2.- Login");
                Console.WriteLine("3.- Salir");
                opcio = Console.ReadLine();
                
                switch (opcio)
                {
                    case "1":
                        mi_usuari = new Usuari();
                        mi_usuari.setUsuari();
                        usuaris.Add(mi_usuari);
                        opcio = "0";

                        /*Console.WriteLine(" ");
                        Console.WriteLine("*************");
                        for (int i=0;i< usuaris.Count;i++)
                        {
                            Console.WriteLine("Usuario Creado " +i);
                            Console.WriteLine(usuaris[i].getUsuario());
                        }
                        Console.WriteLine("*************");
                        Console.WriteLine(" ");*/
                        Console.WriteLine("Usuario creado");
                        Console.WriteLine("Pulsa una tecla para continuar");
                        Console.ReadKey();
                        break;

                    case "2":
                        login();
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opción incorrecta");
                        break;
                }
            }
        }

        static public void Menu_Usuario()
        {
            opcio = "0";
            while (opcio != "1" && opcio != "2" && opcio != "3" && opcio != "4" || opcio == "0")
            {
                Console.Clear();
                Console.WriteLine("1.- Crear video");
                Console.WriteLine("2.- Ver lista de videos");
                Console.WriteLine("3.- Menu Video");
                Console.WriteLine("4.- Menu Anterior");
                opcio = Console.ReadLine();

                switch (opcio)
                {
                    case "1":
                        
                        for (int i=0;i<usuaris.Count;i++)
                        {
                            aux_usuario = usuaris[i].getUsuario();
                            aux_password = usuaris[i].getPassword();

                            /*Console.WriteLine(" ");
                            Console.WriteLine("*************");
                            Console.WriteLine("aux_usuario: "+ aux_usuario+ "log usuario: "+ log_usuario);
                            Console.WriteLine("aux_password: " + aux_password + "password_usuario: " + password_usuario);                            
                            Console.WriteLine("*************");
                            Console.WriteLine(" "); */

                            if (log_usuario == aux_usuario && password_usuario == aux_password)
                            {
                                usuaris[i].crearVideo();
                                Console.WriteLine("Video Creado");
                                Console.WriteLine("Pulsa una tecla para continuar");
                                Console.ReadKey();
                            }                                
                        }

                        
                        opcio = "0";
                        break;

                    case "2":
                        videos = new List<Video>();
                        for (int i = 0; i < usuaris.Count; i++)
                        {
                            aux_usuario = usuaris[i].getUsuario();
                            aux_password = usuaris[i].getPassword();
                            if (log_usuario == aux_usuario && password_usuario == aux_password)
                                videos=usuaris[i].mis_videos;
                        }
                        
                        for (int i = 0; i < videos.Count; i++)
                        {
                            videos[i].getVideo();
                        }
                        Console.WriteLine("Pulsa una tecla para continuar");
                        Console.ReadKey();
                        opcio = "0";
                        break;

                    case "3":
                        Menu_Video();
                        break;

                    case "4":
                        Menu();
                        break;

                    default:
                        Console.WriteLine("Opción incorrecta");
                        opcio = "0";
                        break;
                }
            }
        }

        static void Menu_Video()
        {
            string aux_titol;
            bool trobat = false;
            int indice_user = 0;
            int indice_video = 0;
            int mi_enum=0;

            while (mi_enum != (int)Accions.SELECCIONAR && mi_enum != (int)Accions.AÑADIR && mi_enum != (int)Accions.REPRODUIR &&
                mi_enum != (int)Accions.PARAR && mi_enum != (int)Accions.PAUSA && mi_enum != (int)Accions.ANTERIOR)
            {
                Console.Clear();
                Console.WriteLine("1.- Seleccionar video");
                Console.WriteLine("2.- Añadir Tags");
                Console.WriteLine("3.- Reproducir video");
                Console.WriteLine("4.- Parar video");
                Console.WriteLine("5.- Pausar Video");
                Console.WriteLine("6.- Menu Anterior");
                
                opcio = Console.ReadLine();
                if (opcio != "1" && opcio != "2" && opcio != "3" && opcio != "4" && opcio != "5" && opcio != "6")
                    mi_enum = 0;
                else
                    mi_enum = Int32.Parse(opcio);
                               
                switch (mi_enum)
                {
                    case (int)Accions.SELECCIONAR:
                        Console.WriteLine("Introduce el título del video");
                        aux_titol = Console.ReadLine();
                        if (aux_titol.Length == 0)
                            throw new CampBuitException();

                        for (int i = 0; i < usuaris.Count; i++)
                        {
                            aux_usuario = mi_usuari.getUsuario();
                            aux_password = mi_usuari.getPassword();
                            if (log_usuario == aux_usuario && password_usuario == aux_password)
                            {
                                videos = usuaris[i].mis_videos;
                                indice_user = i;
                            }
                        }

                        for (int i = 0; i < videos.Count; i++)
                        {
                            if (videos[i].getTitol() == aux_titol)
                            {
                                trobat = true;
                                indice_video = i;
                            }
                        }

                        if (trobat)
                        {
                            Console.WriteLine("Video seleccionado");
                            trobat = false;
                            hayVideo = true;
                        }
                        else
                        {
                            Console.WriteLine("El video no está en la lista");
                            hayVideo = false;
                        }

                        Console.WriteLine("Pulsa una tecla para continuar");
                        Console.ReadKey();
                        Menu_Video();
                        break;

                    case (int)Accions.AÑADIR:
                        string seguir = "s";
                        string tag_video;
                        

                        if (hayVideo)
                        {
                            while (seguir == "s" || seguir == "S")
                            {
                                Console.Write("Introduce un Tag: ");
                                tag_video = Console.ReadLine();
                                usuaris[indice_user].mis_videos[indice_video].setTag(tag_video);

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
                            
                        else
                            Console.WriteLine("Primero tienes que seleccionar un video");

                        Console.WriteLine("Pulsa una tecla para continuar");
                        Console.ReadKey();
                        Menu_Video();
                        break;

                    case (int)Accions.REPRODUIR:
                        if (hayVideo)
                        {
                            videos[indice_video].Reproduir();                            
                        }
                        else
                            Console.WriteLine("Primero tienes que seleccionar un video");

                        Console.WriteLine("Pulsa una tecla para continuar");
                        Console.ReadKey();
                        Menu_Video();
                        break;

                    case (int)Accions.PARAR:
                        if (hayVideo)
                        {
                            videos[indice_video].Parar();
                        }
                        else
                            Console.WriteLine("Primero tienes que seleccionar un video");

                        Console.WriteLine("Pulsa una tecla para continuar");
                        Console.ReadKey();
                        Menu_Video();
                        break;

                    case (int)Accions.PAUSA:
                        if (hayVideo)
                        {
                            videos[indice_video].Pausar();
                        }
                        else
                            Console.WriteLine("Primero tienes que seleccionar un video");

                        Console.WriteLine("Pulsa una tecla para continuar");
                        Console.ReadKey();
                        Menu_Video();
                        break;

                    case (int)Accions.ANTERIOR:
                        hayVideo = false;
                        Menu_Usuario();
                        break;

                    default:
                        Console.WriteLine("Opción incorrecta");
                        Console.WriteLine("Pulsa una tecla para continuar");
                        Console.ReadKey();
                        Menu_Video();
                        break;
                }
            }
        }

        static void login()
        {
            Console.WriteLine("Introduce tu usuario: ");
            log_usuario = Console.ReadLine();
            if (log_usuario.Length == 0)
                throw new CampBuitException();

            Console.WriteLine("Introduce tu contraseña: ");
            password_usuario = Console.ReadLine();
            if (password_usuario.Length == 0)
                throw new CampBuitException();

            for (int i = 0; i < usuaris.Count; i++)
            {
                aux_usuario = usuaris[i].getUsuario();
                aux_password = usuaris[i].getPassword();

                if (aux_usuario == log_usuario && aux_password == password_usuario)
                {
                    logued = true;
                    mi_usuari = usuaris[i];

                }
            }

            Console.Clear();
            if (!logued)
            {
                Console.WriteLine("No se ha encontrado el usuario");
                Menu();
            }
            else
                Menu_Usuario();
        }
    }
}
