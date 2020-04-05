using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ejercicioide_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int cont = 0;
        int dato = 0;
        int datb = 0;
        int cont2 = 0;
        DibujaAVL arbolavl = new DibujaAVL(null);
        DibujaAVL arbolavl_letra = new DibujaAVL(null);
        Pila pila1=new Pila();
        Pila pila2 = new Pila();
        Graphics g;


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Form1_Paint(object sender, PaintEventArgs en)
        {
            en.Graphics.Clear(this.BackColor);
            en.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            en.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g = en.Graphics;
            arbolavl.dibujararbol(g, this.Font, Brushes.White, Brushes.Black, Pens.White, datb, Brushes.Black);
            datb = 0;
            if (pintar == 1)
            {
                arbolavl.colorear(g, this.Font, Brushes.Black, Brushes.Yellow, Pens.Blue, arbolavl.raiz, false,false, false);
                pintar = 0;
            }
            if (pintar == 2)
            {
                arbolavl.colorearB(g, this.Font, Brushes.White, Brushes.Red, Pens.White, arbolavl.raiz, int.Parse(valor.Text));
                pintar = 0;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errores.Clear();
            if (valor.Text == "")
            {
                errores.SetError(valor, "valor obligatorio");

            }
            else
            {

                pila1.push(Convert.ToChar(valor.Text));
                pila1.mostrar(pilasxd1);
                valor.Clear();
                valor.Focus();


            }
        }
        int pintar = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            //errores.Clear();
            //if (valor.Text == "")
            //{
            //    errores.SetError(valor, "valor obligatorio");
            //}
            //else
            //{
            //    try
            //    {
            //        datb = int.Parse(valor.Text);
            //        arbolavl.buscar(datb);
            //        pintar = 2;
            //        Refresh();
            //        valor.Clear();
            //    }
            //    catch
            //    {
            //        errores.SetError(valor, "debe ser numero mi pana, yo se que la letra es bonita pero por favor no la ponga");
            //    }
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            errores.Clear();
            if (valor.Text == "")
            {
                errores.SetError(valor, "valor obligatorio");
            }
            else
            {

                   
                    
                    arbolavl.eliminar(Convert.ToChar(valor.Text)); ;
                    lblaltura.Text = arbolavl.raiz.getAltura(arbolavl.raiz).ToString();
                if (!arbolavl.compelim)
                {
                    
                    arbolavl.compelim = true;
                }
                else
                {
                    pila2.push(Convert.ToChar(valor.Text));
                    pila2.mostrar(pilas2);
                }
                    Refresh();
                    Refresh();
                    cont2++;
        
            }
            Refresh();
            Refresh();
            Refresh();
            
        }

        private void valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                errores.Clear();
                if (valor.Text == "")
                {
                    errores.SetError(valor, "valor obligatorio");
                }
                else
                {
                    try
                    {
    
                            arbolavl.Insertar(Convert.ToChar(valor.Text));
                            valor.Clear();
                            valor.Focus();
                            lblaltura.Text = arbolavl.raiz.getAltura(arbolavl.raiz).ToString();
                            cont++;
                            Refresh();
                            Refresh();

                    }
                    catch
                    {
                        errores.SetError(valor, "debe ser letra mi pana, yo se que la cifra es bonita pero por favor no la ponga");
                    }
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pila1.tope != null) { 
            arbolavl.Insertar(pila1.tope.info);
            pila1.eliminarCABEZA();
            lblaltura.Text = arbolavl.raiz.getAltura(arbolavl.raiz).ToString();
            cont++;
            Refresh();
            Refresh();
            pila1.mostrar(pilasxd1);
            }
            else
            {
                MessageBox.Show("pila vacia","System32.Fatal.x0000e86",MessageBoxButtons.OK);
            }
        }
    }
}
