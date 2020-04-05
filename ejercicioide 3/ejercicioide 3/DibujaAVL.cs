using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace ejercicioide_3
{
    class DibujaAVL
    {
        public tree raiz,aux;
        public bool compelim=true;
        public DibujaAVL()
        {
            aux = new tree();
        }
        public DibujaAVL(tree raiznueva)
        {
            raiz = raiznueva;
        }
        public void Insertar(char dato)
        {
            if (raiz == null)
                raiz = new tree(dato, null, null, null);
            else
                raiz = raiz.insertar(dato, raiz);
        }
        public void eliminar(char dato)
        {
            if (raiz == null)
                raiz = new tree(dato, null, null, null);
            else
                raiz.Eliminar(dato, ref raiz);

            if (!raiz.compelim)
            {
                compelim = false;
                raiz.compelim = true;
            }
        }
        private const int radio = 30;
        private const int distanciaH = 40;
        private const int distanciaV = 10;
        private int coordenadaX;
        private int coordenadaY;
        public void posicionnodorecorrido(ref int xmin,ref int ymin)
        {
            coordenadaY = (int)(ymin + radio / 2);
            coordenadaX = (int)(xmin + radio / 2);
            xmin += radio;
        }
        public void colorear(Graphics grafo, Font fuente, Brush relleno, Brush rellenofuente,Pen lapiz,tree raiz, bool post, bool inor, bool preor)
        {
            Brush entorno = Brushes.Red;
            if (inor == true)
            {
                if (raiz != null)
                {
                    colorear(grafo, fuente, Brushes.Blue, rellenofuente, lapiz, raiz.izquierdo, post, inor, preor);
                    raiz.colorear(grafo, fuente, entorno, rellenofuente, lapiz);
                    Thread.Sleep(500);
                    raiz.colorear(grafo, fuente, relleno, rellenofuente, lapiz);
                    colorear(grafo, fuente, relleno, rellenofuente, lapiz, raiz.derecho, post, inor, preor);

                }
            }
            else if(preor == true)
            {
                if(raiz != null)
                {
                    raiz.colorear(grafo, fuente, Brushes.Yellow, Brushes.Blue, Pens.Black);
                    Thread.Sleep(500);
                    raiz.colorear(grafo, fuente, Brushes.White, Brushes.Black, Pens.Black);
                    colorear(grafo, fuente, Brushes.Blue, rellenofuente, lapiz, raiz.izquierdo, post, inor, preor);
                    colorear(grafo, fuente, relleno, rellenofuente, lapiz, raiz.derecho, post, inor, preor);
                }
            }
            else if (post == true)
            {
                if(raiz != null)
                {
                    colorear(grafo, fuente, relleno, rellenofuente, lapiz, raiz.izquierdo, post, inor, preor);
                    colorear(grafo, fuente, relleno, rellenofuente, lapiz, raiz.derecho, post, inor, preor);
                    raiz.colorear(grafo, fuente, entorno, rellenofuente, lapiz);
                    Thread.Sleep(500);
                    raiz.colorear(grafo, fuente, entorno, rellenofuente, lapiz);
                }
            }
        }
        public void colorearB(Graphics grafo,Font fuente, Brush relleno, Brush rellenofuente,Pen lapiz,tree raiz, int busqueda)
        {
            Brush entorno = Brushes.Red;
            if (raiz != null)
            {
                raiz.colorear(grafo, fuente, entorno, rellenofuente, lapiz);
                if (busqueda < raiz.valor)
                {
                    Thread.Sleep(500);
                    raiz.colorear(grafo, fuente, entorno, Brushes.Blue, lapiz);
                    colorearB(grafo, fuente, relleno, rellenofuente, lapiz, raiz.izquierdo, busqueda);

                }
                else
                {
                    if (busqueda > raiz.valor)
                    {
                        Thread.Sleep(500);
                        raiz.colorear(grafo, fuente, entorno, rellenofuente, lapiz);
                        colorearB(grafo, fuente, relleno, rellenofuente, lapiz, raiz.derecho, busqueda);
                    }
                    else
                    {
                        raiz.colorear(grafo, fuente, entorno, rellenofuente, lapiz);
                        Thread.Sleep(500);
                    }
                }
            }
        }
        public void dibujararbol(Graphics grafo,Font fuente, Brush relleno, Brush rellenofuente,Pen lapiz,int dato, Brush encuentro)
        {
            int x = 250;
            int y = 75;
            if (raiz == null) return;
            raiz.posicionnodo(ref x, y);
            raiz.dibujarramas(grafo, lapiz);
            raiz.dibujarnodo(grafo, fuente, relleno, rellenofuente, lapiz, dato, encuentro);

        }
        public int x1 = 100;
        public int y2 = 75;
        public void restablecer_valores()
        {
            x1 = 100;
            y2 = 75;
        }
        public void buscar (char x)
        {
            if (raiz == null)
                MessageBox.Show("Arbol vacio", "Error", MessageBoxButtons.OK);
            else
                raiz.buscar(x, raiz);
        }
    }
}
