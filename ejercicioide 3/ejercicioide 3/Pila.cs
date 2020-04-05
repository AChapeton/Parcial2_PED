using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace ejercicioide_3
{
    class nodo 
    {
        public char info;
        public nodo sgte;
        //public void dibujarnodo(Graphics grafo, Font fuente, Brush relleno, Brush rellenofuente, Pen Lapiz, Brush encuentro)
        //{
        //    int x = 100, y = 75;
        //    Rectangle rect = new Rectangle(
        //        (int)(x - 30 / 2),
        //        (int)(y - 30 / 2), 30, 30);

        //    grafo.FillEllipse(encuentro, rect);
        //    grafo.FillEllipse(relleno, rect);

        //    grafo.DrawEllipse(Lapiz, rect);
        //    StringFormat formato = new StringFormat();
        //    formato.Alignment = StringAlignment.Center;
        //    formato.LineAlignment = StringAlignment.Center;
        //    grafo.DrawString(info.ToString(), fuente, Brushes.Black, x, y, formato);
        //    if (sgte != null)
        //    {
        //        sgte.dibujarnodo(grafo, fuente, Brushes.YellowGreen, rellenofuente, Lapiz, encuentro);

        //    }
        //    y += 75;

        //}
    }
    class Pila
    {
        public nodo tope;
        public Pila()
        {
            tope = null;
        }
    
         public void push(char valor)
         {
            nodo aux = new nodo();
            aux.info = valor;
            if (tope == null)
            {
            tope = aux;
                aux.sgte = null;
            }
            else
            {
                aux.sgte = tope;
                tope = aux;
            }
         }
        public int pop()
        {
            int valor=0;
            if (tope == null)
                MessageBox.Show("Ayyyy lmao pila vacia");
            else
            {
                valor = tope.info;
                tope = tope.sgte;
            }
            return valor;

        }
        public void mostrar(ListBox list)
        {
            list.Items.Clear();
            nodo puntero; puntero = tope;
            if (puntero == null)
            {
                list.Items.Clear();
            }
            else
            {
                list.Items.Add(puntero.info);
                while (puntero.sgte != null)
                {
                    puntero = puntero.sgte;
                    list.Items.Add(puntero.info);
                }
            }
            
        }
        public void eliminarCABEZA()
        {
            nodo aux = tope ;
            tope = aux.sgte;
        }
       

    }
}
