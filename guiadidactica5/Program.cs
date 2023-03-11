using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace guiadidactica5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear tiendas
            Tienda tienda1 = new Tienda("ADOC", "Plaza Mundo Soyapango");
            Tienda tienda2 = new Tienda("Par2", "Metrocentro");
            Tienda tienda3 = new Tienda("Tianguis", "Colonia Escalon");

            // Agregar zapatos a tiendas
            tienda1.AgregarZapato(new Zapato("Tacones", "Beauty", "Mujer", 9.5, 30.00, 0.15));
            tienda1.AgregarZapato(new Zapato("Tennis", "Beauty", "Mujer", 7.5, 25.00, 0));
            tienda1.AgregarZapato(new Zapato("Sandalias", "Gucci", "Mujer", 9.0, 100.00, 0.50));
            tienda1.AgregarZapato(new Zapato("Zapato deportivos", "Nike", "Hombre", 8.0, 40.00, 0.25));
            tienda1.AgregarZapato(new Zapato("Zapatillas", "Reebook", "Hombre", 7.0, 12.00, 0));
            tienda1.AgregarZapato(new Zapato("Sapitos", "NIke", "Mujer", 8.0, 7.00, 0));


            tienda2.AgregarZapato(new Zapato("Zapatillas", "Reebook", "Hombre", 9.0, 12.50, 0));
            tienda1.AgregarZapato(new Zapato("Sandalias", "Gucci", "Mujer", 9.0, 40.99, 0));
            tienda2.AgregarZapato(new Zapato("Sapitos", "NIke", "Hombre", 7.5, 20.00, 20));
            tienda2.AgregarZapato(new Zapato("Botas", "Prada", "Mujer", 8.5, 80.00, 20));
            tienda1.AgregarZapato(new Zapato("Tacones", "Beauty", "Mujer", 9.5, 30.00, 0.15));
            tienda3.AgregarZapato(new Zapato("Zapato deportivos", "Nike", "Mujer", 8.5, 25.00, 0));


            tienda3.AgregarZapato(new Zapato("Tacones", "Rebook", "Mujer", 9.5, 30.00, 0.15));
            tienda3.AgregarZapato(new Zapato("Zapato deportivos", "Nike", "Hombre", 8.0, 40.00, 0.25));
            tienda3.AgregarZapato(new Zapato("Tennis", "Beauty", "Mujer", 8.5, 25.00, 0));
            tienda3.AgregarZapato(new Zapato("Sandalias", "Gucci", "Mujer", 9.0, 100.00, 0.50));
            tienda3.AgregarZapato(new Zapato("Sapitos", "NIke", "Mujer", 8.0, 7.00, 0));
            tienda3.AgregarZapato(new Zapato("Zapatillas", "Beauty", "Hombre", 7.0, 12.00, 0));
            

            // Crear lista de tiendas
            List<Tienda> tiendas = new List<Tienda>();
            tiendas.Add(tienda1);
            tiendas.Add(tienda2);
            tiendas.Add(tienda3);

            // Mostrar menú de opciones
            while (true)
            {
                //Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------Bienvenido/a------");
                Console.WriteLine();
                Console.WriteLine("*****************************HECHO POR: JORDY & WENDY");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Seleccione una tienda:");
                for (int i = 0; i < tiendas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tiendas[i].Nombre} - {tiendas[i].Direccion}  - {tiendas[i].Direccion}");
                }
                Console.WriteLine("0. Salir");
                Console.WriteLine();
                Console.ResetColor();

                
                int opcion;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    if (opcion == 0)
                    {
                        break;
                    }
                    else if (opcion > 0 && opcion <= tiendas.Count)
                    {
                        // Mostrar catálogo de zapatos
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Tienda tiendaSeleccionada = tiendas[opcion - 1];
                        Console.WriteLine($"Catálogo de {tiendaSeleccionada.Nombre}:");
                        Console.WriteLine();
                        foreach (Zapato zapato in tiendaSeleccionada.Zapatos)
                        {
                            Console.WriteLine($"Nombre: {zapato.Nombre}, Marca:({zapato.Marca}), Talla: {zapato.Talla}- Genero: {zapato.Genero} - Precio: ${zapato.Precio} - Descuento: {(zapato.Descuento > 0 ? $"({zapato.Descuento}% descuento)" : "")}");
                        }

                        // Realizar compra
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Seleccione un zapato para comprar:");
                        int indiceZapato;
                        if (int.TryParse(Console.ReadLine(), out indiceZapato))
                        {
                            if (indiceZapato > 0 && indiceZapato <= tiendaSeleccionada.Zapatos.Count)
                            {
                                Zapato zapatoSeleccionado = tiendaSeleccionada.Zapatos[indiceZapato - 1];
                                Console.WriteLine($"Compra realizada: {zapatoSeleccionado.Nombre} ({zapatoSeleccionado.Marca}) - {zapatoSeleccionado.Talla} - {zapatoSeleccionado.Genero} - ${zapatoSeleccionado.Precio - (zapatoSeleccionado.Precio * zapatoSeleccionado.Descuento / 100)}");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Opción inválida.");
                                Console.WriteLine();
                            }
                        }
                        //Console.Clear();
                    }
                }
            }
        }
        public class Tienda
        {
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public List<Zapato> Zapatos { get; set; }

            public Tienda(string nombre, string direccion)
            {
                Nombre = nombre;
                Direccion = direccion;
                Zapatos = new List<Zapato>();
            }

            public void AgregarZapato(Zapato zapato)
            {
                Zapatos.Add(zapato);
            }
        }

        public class Zapato
        {
            public string Nombre { get; set; }
            public string Marca { get; set; }
            public string Genero { get; set; }
            public double Talla { get; set; }
            public double Precio { get; set; }
            public double Descuento { get; set; }

            public Zapato(string nombre, string marca, string genero, double talla, double precio, double descuento)
            {
                Nombre = nombre;
                Marca = marca;
                Genero = genero;
                Talla = talla;
                Precio = precio;
                Descuento = descuento;
            }
        }
    }
}