﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Entidades;
namespace MainCorreo
{
    public partial class FrmPpal : Form
    {

        private Correo correo; 
        
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        #region Métodos

        private void ActualizarEstados()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();

            foreach (Paquete p in this.correo.Paquetes)
            {
                switch (p.Estado)
                {
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(p);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(p);
                        break;
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(p);
                        break;
                }
            }

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            Paquete paq = new Paquete(this.txtDireccion.Text, this.mtxTrackingID.Text);
            EventArgs info = new EventArgs();
            paq.InformaEstado += new Paquete.DelegadoEstado(this.paq_InformaEstado);
            try
            {
                this.correo += paq;
            }
            catch (TrackingIDRepetidoException error)
            {
                MessageBox.Show(error.Message, "ID repetido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception generic)
            {
                MessageBox.Show(generic.Message, "Base de datos error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.ActualizarEstados();
        }




        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        #endregion

        private void mostrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

    }
}
