using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{

    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        //Delegado
        public delegate void DelegadoEstado(object sender, EventArgs e);
        //Evento
        public event DelegadoEstado InformaEstado;

        #region Constructores

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        #endregion

        #region Propiedades

        public string DireccionEntrega { get { return this.direccionEntrega; } set { this.direccionEntrega = value;} }

        public EEstado Estado { get { return this.estado; } set { this.estado = value;} }

        public string TrackingID { get { return this.trackingID; } set { this.trackingID = value;} }

        #endregion

        #region Metodos

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string resp = "";
            Paquete p = (Paquete) elemento;
            resp = String.Format("{0} para {1}", p.TrackingID, p.DireccionEntrega);
            return resp; 
        }

        
        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(10000);
                this.Estado += 1;
                this.InformaEstado(this, new EventArgs());
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
             
            }
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Sobrecargas de Operadores

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool resp = false;
            if (p1.TrackingID == p2.TrackingID)
                resp = true;
            return resp;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        { return !(p1 == p2); }

        #endregion

    }
}
