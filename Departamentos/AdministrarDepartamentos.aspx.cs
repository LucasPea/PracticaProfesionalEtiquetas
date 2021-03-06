﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_de_etiquetas.Departamentos
{
    public partial class AdministrarDepartamentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Conexion cn = new Conexion();
                cn.MostrarDatosDepartamentos(gvDepartamentos);
            }
        }

        protected void gvDepartamentos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Conexion cn = new Conexion();

            gvDepartamentos.EditIndex = e.NewEditIndex;

            cn.MostrarDatosDepartamentos(gvDepartamentos);

            TextBox IdDepartamento = (TextBox)gvDepartamentos.Rows[e.NewEditIndex].Cells[1].Controls[0];
            IdDepartamento.ReadOnly = true;
            TextBox Descripcion = (TextBox)gvDepartamentos.Rows[e.NewEditIndex].Cells[2].Controls[0];
            Descripcion.ReadOnly = false;
        }

        protected void gvDepartamentos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Conexion cn = new Conexion();
            GridViewRow fila = gvDepartamentos.Rows[e.RowIndex];

            int IdDepartamento = Convert.ToInt32(((TextBox)(fila.Cells[1].Controls[0])).Text);
            string Descripcion = ((TextBox)(fila.Cells[2].Controls[0])).Text;


            cn.ModificarDepartamento(IdDepartamento, Descripcion);
            gvDepartamentos.EditIndex = -1;
            cn.MostrarDatosDepartamentos(gvDepartamentos);
            gvDepartamentos.DataBind();
        }

        protected void gvDepartamentos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            Conexion cn = new Conexion();
            GridViewRow fila = gvDepartamentos.Rows[e.RowIndex];
            int NroDoc = Convert.ToInt32(gvDepartamentos.Rows[e.RowIndex].Cells[1].Text);

            cn.EliminarDepartamento(NroDoc);
            gvDepartamentos.EditIndex = -1;
            cn.MostrarDatosDepartamentos(gvDepartamentos);
            gvDepartamentos.DataBind();


        }

        protected void gvDepartamentos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Conexion cn = new Conexion();
            gvDepartamentos.EditIndex = -1;
            cn.MostrarDatosDepartamentos(gvDepartamentos);
        }



    }
}