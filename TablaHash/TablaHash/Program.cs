using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablaHash
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable Registro = new Hashtable();
            int op = 0;
            do
            {
                Console.WriteLine("----- MENÚ -----");
                Console.WriteLine("1. Agregar dato");
                Console.WriteLine("2. Actualizar dato");
                Console.WriteLine("3. Eliminar dato");
                Console.WriteLine("4. Mostrar todos los datos");
                Console.WriteLine("5. Consultar dato");
                Console.WriteLine("6. Salir");
                Console.Write("Elija una opción: ");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("AGREGAR DATO");
                        string DUI, nombre;
                        Console.Write("Ingrese su DUI: [########-#] ");
                        DUI = Console.ReadLine();
                        Console.Write("Ingrese su nombre: ");
                        nombre = Console.ReadLine();
                        try
                        {
                            Registro.Add(DUI, nombre);
                            Console.WriteLine("Dato registrado");
                            Console.WriteLine("ENTER para continuar");
                        }
                        catch
                        {
                            Console.WriteLine("Ya existe un registro con la clave {0}, ENTER para continuar", DUI);
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        DUI = "";
                        nombre = "";
                        Console.WriteLine("ACTUALIZAR DATO");
                        Console.Write("DUI: ");
                        DUI = Console.ReadLine();
                        try
                        {
                            if(Registro[DUI] == null)
                            {
                                Console.WriteLine("No existe un dato con la clave {0}, ENTER para continuar", DUI);
                            }
                            else
                            {
                                Console.WriteLine("Nombre actual: {0}", Registro[DUI]);
                                Console.Write("Nuevo nombre: ");
                                nombre = Console.ReadLine();
                                Registro[DUI] = nombre;
                                Console.WriteLine("Dato actualizado");
                                Console.WriteLine("ENTER para continuar");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("No existe un dato con la clave {0}, ENTER para continuar", DUI);
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        DUI = "";
                        Console.WriteLine("ELIMINAR DATO");
                        Console.WriteLine("DUI ");
                        DUI = Console.ReadLine();
                        try
                        {
                            if (Registro[DUI] == null)
                            {
                                Console.WriteLine("No existe un dato con la clave {0}, ENTER para continuar", DUI);
                            }
                            else
                            {
                                Registro.Remove(DUI);
                                Console.WriteLine("Dato eliminado");
                                Console.WriteLine("ENTER para continuar");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("No existe un dato con la clave {0}, ENTER para continuar", DUI);
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("LISTA DE DATOS");
                        if(Registro.Count == 0)
                        {
                            Console.WriteLine("Aún no hay registros.");
                        }
                        else
                        {
                            foreach (DictionaryEntry dato in Registro)
                            {
                                Console.WriteLine("DUI: {0} || Nombre: {1}", dato.Key, dato.Value);
                            }
                        }
                        Console.WriteLine("ENTER para continuar");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        DUI = "";
                        Console.WriteLine("CONSULTAR DATOS");
                        Console.Write("DUI: ");
                        DUI = Console.ReadLine();
                        try
                        {
                            if (Registro[DUI] == null)
                            {
                                Console.WriteLine("No existe un dato con la clave {0}, ENTER para continuar", DUI);
                            }
                            else
                            {
                                Console.WriteLine("Dato encontrado");
                                Console.WriteLine("Nombre: {0}", Registro[DUI]);
                                Console.WriteLine("ENTER para continuar");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("No existe un dato con la clave {0}, ENTER para continuar", DUI);
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Opción no disponible");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            } while (op != 6);

        }
    }
}
