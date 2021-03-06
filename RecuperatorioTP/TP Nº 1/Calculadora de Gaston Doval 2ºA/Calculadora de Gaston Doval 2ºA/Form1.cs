﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Calculadora_de_Gaston_Doval_2ºA
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = this.txtNumero1.Text;
            string num2 = this.txtNumero2.Text;
            string operador = this.cmbOperador.Text;
            double resp = LaCalculadora.Operar(num1, num2, operador);
            string muestra = Convert.ToString(resp);
            this.lblResultado.Text = muestra;
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        /// <summary>
        /// Realiza la operacion matematica correspondiente al operador que se pasa como parametro
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string num1, string num2, string operador)
        {
            Calculadora calcu = new Calculadora();
            Numero numero1 = new Numero(num1);
            Numero numero2 = new Numero(num2);
            double resp = calcu.Operar(numero1, numero2, operador);
            return resp;
        }



        private void btnBinarioADecimal_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "")
            {
                string resp = Numero.BinarioDecimal(this.lblResultado.Text);
                if (resp == "")
                    MessageBox.Show("El numero ingresado no es binario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    this.lblResultado.Text = resp;
            }else
                MessageBox.Show("No hay numero para convertir", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDecimalABinario_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "")
            {
                string resp = Numero.DecimalBinario(Convert.ToDouble(this.lblResultado.Text));
                this.lblResultado.Text = resp;
            }else
                MessageBox.Show("No hay numero para convertir", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LaCalculadora_Load(object sender, EventArgs e)
        {

        }
    }
}
