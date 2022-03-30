using System.IO;
using System;
namespace Generador
{
    public class Lexico:Toke
    {
        protected int linea;
        const int  E=-2;//negativo por si crece el automata 
        const int  F=-1;
        int[,] TranD =
        {
        };
        private StreamReader archivo;
        protected StreamWriter log;
        protected StreamWriter gen;
        public Lexico()
        {
            linea=1;
            archivo = new StreamReader("D:\\Archivos\\Gramatica.txt");
            log = new StreamWriter("D:\\Archivos\\Lenguaje.Log");
            gen = new StreamWriter("D:\\Archivos\\Lenguaje.cs");
            log.AutoFlush=true;
            gen.AutoFlush=true;
            log.WriteLine("Instituo Tecnologico de Queretaro");
            log.WriteLine("Miguel Angel Ibarra Basaldua");
            log.WriteLine("-----------------------------------");
            log.WriteLine("Contenido de Prueba.cs: ");
            string time = DateTime.Now.ToString("hh:mm:ss tt"); // hora
            string Date = DateTime.Now.ToString("dd-MM-yyyy"); //fecha 
            log.WriteLine(time);
            log.WriteLine(Date);
            log.WriteLine("-----------------------------------");
            
            gen.WriteLine("// Instituo Tecnologico de Queretaro");
            gen.WriteLine("// Miguel Angel Ibarra Basaldua");
            gen.WriteLine("// -----------------------------------");
            gen.WriteLine("// Contenido de la clase Lenguaje.cs: ");
            gen.WriteLine("// " + time);
            gen.WriteLine("// " + Date);
            gen.WriteLine("// -----------------------------------");
            gen.WriteLine("using System;");
            gen.WriteLine("namespace Sintaxis_1");
            gen.WriteLine("{");
        }
        public void CerrarArchivos()
        { 
            archivo.Close();
            log.Close();
            gen.Close();
        }
        private int Columna(char Trancision)
        {
            return 0;
        }

        private void Clasifica(int Estado)
        {
            /*switch(Estado)
            {
               
            }*/
        }
        public void NextToken()
        {
            char c;
            string Buffer="";
            int Estado=0;
            while(Estado>=0)
            {
                c=(char)archivo.Peek();
                Estado=TranD[Estado,Columna(c)]; 
                if(Estado>=0)
                {
                    archivo.Read();
                    if(c=='\n')// para contar lineas 
                    { 
                        linea++;
                    }
                    if(Estado>0)
                    { 
                        Clasifica(Estado);
                        Buffer+=c;
                    }
                    else
                    { 
                        Buffer=""; //cadena vacia
                    }
                }
            }
            if(Estado == E)
            {
                   
            }
            setContenido(Buffer);
            if(!FinAchivo())
            {
                log.WriteLine(getContenido()+" = "+getClasificacion());
            }
        }
        public bool FinAchivo()
        {
            return archivo.EndOfStream;
        }
    }
}