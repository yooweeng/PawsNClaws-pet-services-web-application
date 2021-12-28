﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PE_Final_Assignment
{
    public partial class ViewReservation : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            getReservationList();
        }

        public void getReservationList()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //dog reservation table
                SqlCommand cmd = new SqlCommand("SELECT * from serviceReservation_table where reservation_pet = 'dog'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                String services;
                List<String> serviceList = new List<string>();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Columns.Add("Date");
                    dt.Columns.Add("Size");
                    dt.Columns.Add("Services");
                    dt.Columns.Add("Price");
                    dt.Columns.Add("Id");
                    dt.NewRow();
                    while (dr.Read())
                    {
                        serviceList.Clear();
                        serviceList.Add(dr["reservation_bath"].ToString());
                        serviceList.Add(dr["reservation_cut"].ToString());
                        serviceList.Add(dr["reservation_dogAroma"].ToString());
                        serviceList.Add(dr["reservation_dogMassage"].ToString());
                        serviceList.Add(dr["reservation_tick"].ToString());
                        serviceList.Add(dr["reservation_sciCut"].ToString());
                        serviceList.Add(dr["reservation_detangling"].ToString());
                        services = getDogServices(serviceList);

                        dt.Rows.Add(dr["reservation_date"].ToString(), dr["reservation_dogSize"].ToString(), services, dr["reservation_price"].ToString(), dr["reservation_id"].ToString());
                    }
                }
                dogDatalist.DataSource = dt;
                dogDatalist.DataBind();
                con.Close();


                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //cat reservation table
                SqlCommand cmd1 = new SqlCommand("SELECT * from serviceReservation_table where reservation_pet = 'cat'", con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                String services1;
                List<String> serviceList1 = new List<string>();
                DataTable dt1 = new DataTable();
                if (dr1.HasRows)
                {
                    dt1.Columns.Add("Date");
                    dt1.Columns.Add("Size");
                    dt1.Columns.Add("Services");
                    dt1.Columns.Add("Price");
                    dt1.Columns.Add("Id");
                    dt1.NewRow();
                    while (dr1.Read())
                    {
                        serviceList1.Clear();
                        serviceList1.Add(dr1["reservation_bath"].ToString());
                        serviceList1.Add(dr1["reservation_cut"].ToString());
                        serviceList1.Add(dr1["reservation_tick"].ToString());
                        serviceList1.Add(dr1["reservation_sciCut"].ToString());
                        serviceList1.Add(dr1["reservation_detangling"].ToString());
                        services1 = getCatServices(serviceList1);

                        dt1.Rows.Add(dr1["reservation_date"].ToString(), dr1["reservation_dogSize"].ToString(), services1, dr1["reservation_price"].ToString(), dr1["reservation_id"].ToString());
                    }
                }
                catDatalist.DataSource = dt1;
                catDatalist.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error" + ex);
            }
        }

        public String getDogServices(List<String> serviceList)
        {
            String services="";
            String[] service = {"Bath","Cut","Aromatherapy System","Aroma Oil Massage","Tick Treatment","Scissor Cut","Detangling"};

            for(int i=0;i<serviceList.Count;i++)
            {
                if (serviceList[i].Equals("True"))
                {
                    services = services + "<br/> "+ service[i];
                }
            }

            return services;
        }

        public String getCatServices(List<String> serviceList)
        {
            String services = "";
            String[] service = { "Bath", "Cut", "Tick Treatment", "Scissor Cut", "Detangling" };

            for (int i = 0; i < serviceList.Count; i++)
            {
                if (serviceList[i].Equals("True"))
                {
                    services = services + "<br/> " + service[i];
                }
            }

            return services;
        }

        protected void dogDatalist_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                HiddenField hf = (HiddenField)(e.Item.FindControl("HiddenFieldDogId"));

                SqlCommand cmd = new SqlCommand("delete from serviceReservation_table where reservation_id = @id", con);
                cmd.Parameters.AddWithValue("@id", int.Parse(hf.Value));
                cmd.ExecuteNonQuery();
                con.Close();
                getReservationList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error" + ex);
            }
        }

        protected void catDatalist_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                HiddenField hf = (HiddenField)(e.Item.FindControl("HiddenFieldCatId"));

                SqlCommand cmd = new SqlCommand("delete from serviceReservation_table where reservation_id = @id", con);
                cmd.Parameters.AddWithValue("@id", int.Parse(hf.Value));
                cmd.ExecuteNonQuery();
                con.Close();
                getReservationList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error" + ex);
            }
        }
    }
}