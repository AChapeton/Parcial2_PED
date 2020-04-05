using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; 
using System.Linq;
using System.Text;
using System.Threading; 
using System.Windows.Forms;

namespace Arbol_Binario
{
    class Nodo_Arbol
    {
        public int info; 
        public Nodo_Arbol Izquierdo; 
        public Nodo_Arbol Derecho; 
        public Nodo_Arbol Padre; 
        public int altura;
        public int nivel;
        public Rectangle nodo;
        public List<int> suma = new List<int>();
        public int contador;

        private const int Radio = 30;
        private const int DistanciaH = 80;
        private const int DistanciaV = 10;
        private int CoordenadaX;
        private int CoordenadaY;
        Graphics col;
        private Arbol_Binario arbol; 
        public Nodo_Arbol() 
        {
        }

        public Arbol_Binario Arbol
        {
            get
            { return arbol; }
            set
            { arbol = value; }
        }

        public Nodo_Arbol(int nueva_info, Nodo_Arbol izquierdo, Nodo_Arbol derecho, Nodo_Arbol padre)
        {
            info = nueva_info;
            Izquierdo = izquierdo;
            Derecho = derecho;
            Padre = padre;
            altura = 0;
        }

        public Nodo_Arbol Insertar(int x, Nodo_Arbol t, int Level)
        {
            if (t == null)
            {
                t = new Nodo_Arbol(x, null, null, null);
                t.nivel = Level;
            }
            else if (x < t.info)
            {
                Level++;
                t.Izquierdo = Insertar(x, t.Izquierdo, Level);
            }
            else if (x > t.info)
            {
                Level++;
                t.Derecho = Insertar(x, t.Derecho, Level);
            }
            else
            {
                MessageBox.Show("Dato existente en el Arbol", "Error de Ingreso");
            }
            return t;
        }

        public void Eliminar(int x, ref Nodo_Arbol t)
        {
            if (t != null)
            {
                if (x < t.info)
                {
                    Eliminar(x, ref t.Izquierdo);
                }
                else
                {
                    if (x > t.info) 
                    {
                        Eliminar(x, ref t.Derecho);
                    }                    else
                    {
                        Nodo_Arbol NodoEliminar = t;
                        if (NodoEliminar.Derecho == null)
                        {
                            t = NodoEliminar.Izquierdo;
                        }
                        else
                        {
                            if (NodoEliminar.Izquierdo == null)
                            {
                                t = NodoEliminar.Derecho;
                            }
                            else
                            {
                                if (Alturas(t.Izquierdo) - Alturas(t.Derecho) > 0)
                                {
                                    Nodo_Arbol AuxiliarNodo = null;
                                    Nodo_Arbol Auxiliar = t.Izquierdo;
                                    bool bandera = false;
                                    while (Auxiliar.Derecho != null)
                                    {
                                        AuxiliarNodo = Auxiliar;
                                        Auxiliar = Auxiliar.Derecho;
                                        bandera = true;
                                    }

                                    t.info = Auxiliar.info;
                                    NodoEliminar = Auxiliar;
                                    if (bandera == true)
                                    {
                                        AuxiliarNodo.Derecho = Auxiliar.Izquierdo;
                                    }
                                    else
                                    {
                                        t.Izquierdo = Auxiliar.Izquierdo;
                                    }
                                }
                                else
                                {
                                    if (Alturas(t.Derecho) - Alturas(t.Izquierdo) > 0)
                                    {
                                        Nodo_Arbol AuxiliarNodo = null;
                                        Nodo_Arbol Auxiliar = t.Derecho;
                                        bool bandera = false;
                                        while (Auxiliar.Izquierdo != null)
                                        {
                                            AuxiliarNodo = Auxiliar;
                                            Auxiliar = Auxiliar.Izquierdo;
                                            bandera = true;
                                        }
                                        t.info = Auxiliar.info;
                                        NodoEliminar = Auxiliar;
                                        if (bandera == true)
                                        {
                                            AuxiliarNodo.Izquierdo = Auxiliar.Derecho;
                                        }
                                        else
                                        {
                                            t.Derecho = Auxiliar.Derecho;
                                        }
                                    }
                                    else
                                    {
                                        if (Alturas(t.Derecho) - Alturas(t.Izquierdo) == 0)
                                        {
                                            Nodo_Arbol AuxiliarNodo = null;
                                            Nodo_Arbol Auxiliar = t.Izquierdo;
                                            bool bandera = false;
                                            while (Auxiliar.Derecho != null)
                                            {
                                                AuxiliarNodo = Auxiliar;
                                                Auxiliar = Auxiliar.Derecho;
                                                bandera = true;
                                            }
                                            t.info = Auxiliar.info;
                                            NodoEliminar = Auxiliar;
                                            if (bandera == true)
                                            {
                                                AuxiliarNodo.Derecho = Auxiliar.Izquierdo;
                                            }
                                            else
                                            {
                                                t.Izquierdo = Auxiliar.Izquierdo;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nodo NO existente el Arbol", "Error de eliminación");
            }
        }

        public void buscar(int x, Nodo_Arbol t)
        {
            if (t != null)
            {
                if (x == t.info)
                {

                    MessageBox.Show("Profundidad: " + t.nivel);
                    encontrado(t);
                }
                else
                {
                    if (x < t.info) //búsqueda en el subárbol izquierdo
                    {
                        buscar(x, t.Izquierdo);
                    }
                    else
                    {
                        
                        if (x > t.info) //búsqueda en el subárbol derecho
                        {
                            buscar(x, t.Derecho);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nodo NO encontrado", "Error de búsqueda");
            }
        }

        public void PosicionNodo(ref int xmin, int ymin)
        {
            int aux1, aux2;
            CoordenadaY = (int)(ymin + Radio / 2);
            
            if (Izquierdo != null)
            {
                Izquierdo.PosicionNodo(ref xmin, ymin + Radio + DistanciaV);
            }
            if ((Izquierdo != null) && (Derecho != null))
            {
                xmin += DistanciaH;
            }
            
            if (Derecho != null)
            {
                Derecho.PosicionNodo(ref xmin, ymin + Radio + DistanciaV);
            }
            if (Izquierdo != null && Derecho != null)
                CoordenadaX = (int)((Izquierdo.CoordenadaX + Derecho.CoordenadaX) / 2);
            else
            if (Izquierdo != null)
            {
                aux1 = Izquierdo.CoordenadaX;
                Izquierdo.CoordenadaX = CoordenadaX - 80;
                CoordenadaX = aux1;
            }
            else
                if (Derecho != null)
                {
                    aux2 = Derecho.CoordenadaX;
                    Derecho.CoordenadaX = CoordenadaX + 80;
                    CoordenadaX = aux2;
                }
                else
                {
                    CoordenadaX = (int)(xmin + Radio / 2); xmin += Radio;
                }
        }

        public void DibujarRamas(Graphics grafo, Pen Lapiz)
        {
            if(Izquierdo != null)
            {
                grafo.DrawLine(Lapiz, CoordenadaX, CoordenadaY,
               Izquierdo.CoordenadaX, Izquierdo.CoordenadaY);
                Izquierdo.DibujarRamas(grafo, Lapiz);
            }
            if(Derecho != null)
            {
                grafo.DrawLine(Lapiz, CoordenadaX, CoordenadaY,
               Derecho.CoordenadaX, Derecho.CoordenadaY);
                Derecho.DibujarRamas(grafo, Lapiz);
            }
        }

        public void DibujarNodo(Graphics grafo, Font fuente, Brush Relleno, Brush
        RellenoFuente, Pen Lapiz, Brush encuentro)
        {
            col = grafo;
            
            Rectangle rect = new Rectangle((int)(CoordenadaX - Radio / 2), (
           int)(CoordenadaY - Radio / 2), Radio, Radio);
            Rectangle prueba = new Rectangle((int)(CoordenadaX - Radio / 2),
           (int)(CoordenadaY - Radio / 2), Radio, Radio);
            grafo.FillEllipse(encuentro, rect);
            grafo.FillEllipse(Relleno, rect);
            grafo.DrawEllipse(Lapiz, rect);
            
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;
            grafo.DrawString(info.ToString(), fuente, RellenoFuente, CoordenadaX, CoordenadaY,
           formato);
            if (Izquierdo != null)
            {
                Izquierdo.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz,
               encuentro);
            }
            if (Derecho != null)
            {
                Derecho.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);
            }
        }        public void colorear(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen
Lapiz)
        {
            
            Rectangle rect = new Rectangle((int)(CoordenadaX - Radio / 2), (
           int)(CoordenadaY - Radio / 2), Radio, Radio);
            Rectangle prueba = new Rectangle((int)(CoordenadaX - Radio / 2), (int)(CoordenadaY
           - Radio / 2), Radio, Radio);
            grafo.FillEllipse(Relleno, rect);
            grafo.DrawEllipse(Lapiz, rect);
            
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;
            grafo.DrawString(info.ToString(), fuente, RellenoFuente, CoordenadaX, CoordenadaY,
           formato);
        }

        private static int Alturas(Nodo_Arbol t)
        {
            return t == null ? -1 : t.altura;
        }

        public int AlturaArbol(Nodo_Arbol raiz)
        {
            if (raiz == null)
                return 0;
            else
                return 1 + Math.Max(AlturaArbol(raiz.Izquierdo), AlturaArbol(raiz.Derecho));
        }

        public int SumaValores(Nodo_Arbol raiz)
        {
            if(raiz != null)
            {
                int centro = raiz.info;
                int izq = SumaValores(raiz.Izquierdo);
                int der = SumaValores(raiz.Derecho);
                return centro + izq + der;
            }
            return 0;
        }

        public void encontrado(Nodo_Arbol t)
        {
            Rectangle rec = new Rectangle(t.CoordenadaX, t.CoordenadaY, 40, 40);
        }
    }
}
