using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace ejercicioide_3
{
    class tree
    {
        public char valor;
        public tree izquierdo;
        public tree derecho;
        public tree papa;
        public int altura;
        public Rectangle prueba;
        private DibujaAVL arbol;
        public bool compelim=true;
        
        public tree()
        {
        }
        public DibujaAVL Arbol
        {
            get { return arbol; }
            set { arbol = value; }
        }
        public tree(char niu, tree izq, tree der, tree dad)
        {
            valor = niu;
            izquierdo = izq;
            derecho = der;
            papa = dad;
            altura = 0;
        }

        public tree insertar(char niu, tree root)
        {
            if (root == null)
            {
                root = new tree(niu, null, null, null);
            }
            else if (niu < root.valor)
            {
                root.izquierdo = insertar(niu, root.izquierdo);
            }
            else if(niu>root.valor)
            {
                root.derecho = insertar(niu, root.derecho);
            }



            if (Alturas(root.izquierdo) - Alturas(root.derecho) == 2)
            {
                if (niu < root.izquierdo.valor)
                    root = RotIzqSim(root);
                else
                    root = RotIzqDob(root);
            }
            if (Alturas(root.derecho) - Alturas(root.izquierdo) == 2)
            {
                if (niu > root.derecho.valor)
                    root = RotDerSim(root);
                else
                    root = RotDerDob(root);
            }
            root.altura = max(Alturas(root.izquierdo), Alturas(root.derecho)) + 1;
            return root;
        }
        private static int max(int lhs, int rhs)
        {
            return lhs > rhs ? lhs : rhs;
        }
        private static int Alturas(tree root)
        {
            return root == null ? -1 : root.altura;
        }
        tree nodoe, nodop;
        public tree Eliminar(int valorEliminar, ref tree root)
        {
            if (root != null)
            {
                if (valorEliminar < root.valor)
                {
                    nodoe = root;
                    Eliminar(valorEliminar, ref root.izquierdo);
                }
                else
                {
                    if (valorEliminar > root.valor)
                    {
                        nodoe = root;
                        Eliminar(valorEliminar, ref root.derecho);
                    }
                    else
                    {
                        tree nodoeliminar = root;
                        if (nodoeliminar.derecho == null)
                        {
                            root = nodoeliminar.izquierdo;
                            if (Alturas(nodoe.izquierdo) - Alturas(nodoe.derecho) == 2)
                            {
                                if (valorEliminar < nodoe.valor)
                                    nodop = RotDerSim(nodoe);
                                else
                                    nodoe = RotDerSim(nodoe);
                            }
                            if (Alturas(nodoe.derecho) - Alturas(nodoe.izquierdo) == 2)
                            {
                                if (valorEliminar > nodoe.derecho.valor)
                                    nodoe = RotDerSim(nodoe);
                                else
                                    nodoe = RotDerDob(nodoe);
                                nodop = RotDerSim(nodoe);
                            }
                        }
                        else
                        {
                            if (nodoeliminar.izquierdo == null)
                            {
                                root = nodoeliminar.derecho;
                            }
                            else
                            {
                                if (Alturas(root.izquierdo) - Alturas(root.derecho) > 0)
                                {
                                    tree auxiliarnodo = null;
                                    tree auxiliar = root.izquierdo;
                                    bool bandera = false;
                                    while (auxiliar.derecho != null)
                                    {
                                        auxiliarnodo = auxiliar;
                                        auxiliar = auxiliar.derecho;
                                        bandera = true;
                                    }
                                    root.valor = auxiliar.valor;
                                    nodoeliminar = auxiliar;
                                    if (bandera == true)
                                    {
                                        auxiliarnodo.derecho = auxiliar.izquierdo;
                                    }
                                    else
                                    {
                                        root.izquierdo = auxiliar.izquierdo;
                                    }

                                }
                                else
                                {
                                    if (Alturas(root.derecho) - Alturas(root.izquierdo) > 0)
                                    {
                                        tree auxiliarnodo = null;
                                        tree auxiliar = root.derecho;
                                        bool bandera = false;
                                        while (auxiliar.izquierdo != null)
                                        {
                                            auxiliarnodo = auxiliar;
                                            auxiliar = auxiliar.izquierdo;
                                            bandera = true;
                                        }
                                        root.valor = auxiliar.valor;
                                        nodoeliminar = auxiliar;
                                        if (bandera)
                                        {
                                            auxiliarnodo.izquierdo = auxiliar.derecho;
                                        }
                                        else
                                        {
                                            root.derecho = auxiliar.derecho;
                                        }
                                    }
                                    else
                                    {
                                        if (Alturas(root.derecho) - Alturas(root.izquierdo) == 0)
                                        {
                                            tree auxiliarnodo = null;
                                            tree auxiliar = root.derecho;
                                            bool bandera = false;
                                            while (auxiliar.derecho != null)
                                            {
                                                auxiliarnodo = auxiliar;
                                                auxiliar = auxiliar.derecho;
                                                bandera = true;
                                            }
                                            root.valor = auxiliar.valor;
                                            nodoeliminar = auxiliar;
                                            if (bandera)
                                            {
                                                auxiliarnodo.derecho = auxiliar.izquierdo;
                                            }
                                            else
                                            {
                                                root.izquierdo = auxiliar.izquierdo;
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
                MessageBox.Show("Nodo inexistente en el arbol", "Error", MessageBoxButtons.OK);
                compelim = false;
                
            }
            return nodop;
        }
        private static tree RotIzqSim(tree k2)
        {
            tree k1 = k2.izquierdo;
            k2.izquierdo = k1.derecho;
            k1.derecho = k2;
            k2.altura = max(Alturas(k2.izquierdo), Alturas(k2.derecho)) + 1;
            k1.altura = max(Alturas(k1.izquierdo), k2.altura) + 1;
            return k1;
        }
        private static tree RotDerSim(tree k1)
        {
            tree k2 = k1.derecho;
            k1.derecho = k2.izquierdo;
            k2.izquierdo = k1;
            k1.altura = max(Alturas(k1.izquierdo), Alturas(k1.derecho)) + 1;
            k2.altura = max(Alturas(k2.derecho), k1.altura) + 1;
            return k2;
        }
        private static tree RotIzqDob(tree k3)
        {
            k3.izquierdo = RotDerSim(k3.izquierdo);
            return RotIzqSim(k3);
        }
        private static tree RotDerDob(tree k1)
        {
            k1.derecho = RotIzqSim(k1.derecho);
            return RotDerSim(k1);
        }
        public int getAltura(tree nodoactual)
        {
            if (nodoactual == null)
                return 0;
            else
                return 1 + Math.Max(getAltura(nodoactual.izquierdo), getAltura(nodoactual.derecho));
        }
        public void buscar(char valorBuscar,tree root)
        {
            if(root != null)
            {
                if (valorBuscar < root.valor)
                {
                    buscar(valorBuscar, root.izquierdo);
                }
                else
                {
                    if (valorBuscar < root.valor)
                    {
                        buscar(valorBuscar, root.derecho);
                    }
                
                }
            }
            else
            {
                MessageBox.Show("no se encontro, mi pana", "error", MessageBoxButtons.OK);
            }
        }
        private const int Radio = 30;
        private const int DistanciaH = 40;
        private const int distanciaV = 10;
        private int coordenadaX;
        private int coordenadaY;
        
        public void posicionnodo(ref int xmin, int ymin)
        {
            int aux1, aux2;
            coordenadaY = (int)(ymin + Radio / 2);
            if (izquierdo != null)
            {
                izquierdo.posicionnodo(ref xmin, ymin + Radio + distanciaV);
            }
            if ((izquierdo != null) && (derecho != null))
            {
                xmin += DistanciaH;
            }
            if (derecho != null)
            {
                derecho.posicionnodo(ref xmin, ymin + Radio + distanciaV);
            }
            if (izquierdo != null)
            {
                if (derecho != null)
                {
                    coordenadaX = (int)((izquierdo.coordenadaX + derecho.coordenadaX) / 2);

                }
                else
                {
                    aux1 = izquierdo.coordenadaX;
                    izquierdo.coordenadaX = coordenadaX - 40;
                    coordenadaX = aux1;
                }
            }
            else if (derecho != null)
            {
                aux2 = derecho.coordenadaX;
                derecho.coordenadaX = coordenadaX + 40;
                coordenadaX = aux2;
            }
            else
            {
                coordenadaX = (int)(xmin + Radio / 2);
                xmin += Radio;
            }
        }
        public void dibujarramas(Graphics grafo,Pen Lapiz)
        {
            if (izquierdo != null)
            {
                grafo.DrawLine(Lapiz, coordenadaX, coordenadaY, izquierdo.coordenadaX, izquierdo.coordenadaY);
                izquierdo.dibujarramas(grafo, Lapiz);
            }
        }
    public void dibujarnodo(Graphics grafo,Font fuente,Brush relleno,Brush rellenofuente,Pen Lapiz, int dato, Brush encuentro)
        {
            Rectangle rect = new Rectangle(
                (int)(coordenadaX - Radio / 2),
                (int)(coordenadaY - Radio / 2), Radio, Radio);
            if (valor == dato)
            {
                grafo.FillEllipse(encuentro, rect);
            }
            else
            {
                grafo.FillEllipse(encuentro, rect);
                grafo.FillEllipse(relleno, rect);
            }
            grafo.DrawEllipse(Lapiz, rect);
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;
            grafo.DrawString(valor.ToString(), fuente, Brushes.Black, coordenadaX, coordenadaY, formato);
            if (izquierdo != null)
            {
                izquierdo.dibujarnodo(grafo, fuente, Brushes.YellowGreen, rellenofuente, Lapiz, dato, encuentro);

            }
            if (derecho != null)
            {
                derecho.dibujarnodo(grafo, fuente, Brushes.Yellow, rellenofuente, Lapiz, dato, encuentro);

            }
        }
        public void colorear(Graphics grafo, Font fuente,Brush rellno, Brush rellenofuente,Pen Lapiz)
        {
            Rectangle rect = new Rectangle(
                (int)(coordenadaX - Radio / 2),
                (int)(coordenadaY - Radio / 2), Radio, Radio);
            prueba = new Rectangle((int)(coordenadaX - Radio / 2), (int)(coordenadaY - Radio / 2), Radio, Radio);
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;
            grafo.DrawEllipse(Lapiz, rect);
            grafo.FillEllipse(Brushes.PaleVioletRed, rect);
            grafo.DrawString(valor.ToString(), fuente, Brushes.Black, coordenadaX, coordenadaY, formato);
                
        }
    }
}
