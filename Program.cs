using System;
using System.Collections.Generic;

internal class Program
{
    public class Canasta
    {
        List<Fruta> frutas;

        public Canasta()
        {
            frutas = new List<Fruta>();
        }

        public List<Fruta> IngresarFrutas()
        {
            Console.WriteLine("Ingresa cuántas frutas deseas insertar en la canasta:");
            int can;
            can = int.Parse(Console.ReadLine() ?? "0");
            Console.Clear();

            for (int i = 0; i < can; i++)
            {
                Fruta ph = new Fruta();

                Console.Write("Ingresar nombre de la fruta:");
                string nom = (Console.ReadLine() ?? "0");
                ph.setn(nom);
                Console.Write("Ingresar precio de la fruta:");
                double precio = double.Parse(Console.ReadLine() ?? "0");
                ph.setp(precio);
                Console.Write("Ingresar descripcion de la fruta:");
                string des = (Console.ReadLine() ?? "0");
                ph.setd(des);

                frutas.Add(ph);
                Console.Clear();
            }

            return frutas;
        }

        public void MostrarCanasta()
        {
            foreach (Fruta fruta in frutas)
            {
                Console.WriteLine($"El nombre del producto: {fruta.getn()}");
                Console.WriteLine($"Precio del producto: {fruta.getp()}");
                Console.WriteLine($"Descripción del producto: {fruta.getd()}");
                Console.WriteLine("**************************************************************");
            }
        }

        public bool EliminarFruta(string nombreFruta)
        {
            Fruta frutaAEliminar = frutas.Find(f => f.getn() == nombreFruta);

            if (frutaAEliminar != null)
            {
                frutas.Remove(frutaAEliminar);
                return true;
            }

            return false;
        }
    }

    public class Fruta
    {
        private double precio;
        private string nombre;
        private string descrip;

        public Fruta()
        {
            precio = 0;
            nombre = "";
            descrip = "";
        }

        public double getp()
        {
            return precio;
        }

        public void setp(double p)
        {
            precio = p;
        }

        public string getn()
        {
            return nombre;
        }

        public void setn(string n)
        {
            nombre = n;
        }

        public string getd()
        {
            return descrip;
        }

        public void setd(string des)
        {
            descrip = des;
        }
    }

    public static void Main()
    {
        List<Canasta> canastas = new List<Canasta>();
        Console.Clear();

        while (true)
        {

            Console.WriteLine("MENU FRUTERIA LA MANZANA PODRIDA.");
            Console.WriteLine("1. Para generar canasta.");
            Console.WriteLine("2. Ver canastas.");
            Console.WriteLine("0. Salir.");
            int op;
            op = int.Parse(Console.ReadLine() ?? "0");
            Console.Clear();

            if (op == 1)
            {
                Canasta miCanasta = new Canasta(); // Crear una nueva instancia de Canasta

                while(true){

                    Console.WriteLine("MENU DE CANASTA - FRUTERIA LA MANZANA PODRIDA");
                    Console.WriteLine("1. Para ingresar fruta");
                    Console.WriteLine("2.Eliminar fruta");
                    Console.WriteLine("0.Salir");
                    op = int.Parse(Console.ReadLine() ?? "0");
                    Console.Clear();

                    if (op == 1)
                    {
                        miCanasta.IngresarFrutas();   
                    }
                    if(op==2){
                        Console.Write("Ingresa el nombre de la fruta que deseas eliminar:");
                        string fe=Console.ReadLine() ?? "0";
                        miCanasta.EliminarFruta(fe);
                        Console.Clear();
                    }
                    else if (op == 0)
                    {
                        canastas.Add(miCanasta);
                        break;
                    }
                }
                }
            else if (op == 2)
            {
                if (canastas.Count > 0)
                {
                    Console.WriteLine("CANASTAS DISPONIBLES:");
                    for (int i = 0; i < canastas.Count; i++)
                    {

                        Console.WriteLine($"Canasta {i + 1}:");
                        canastas[i].MostrarCanasta();
                        Console.WriteLine("********************");
                        Thread.Sleep(TimeSpan.FromMinutes(0.1));
                        Console.Clear();
                    }
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("No se han ingresado canastas.");
                    Thread.Sleep(TimeSpan.FromMinutes(0.1));
                    Console.Clear();
                }
            }
            else if(op==0){
                break;
            }

        }
    }
}
