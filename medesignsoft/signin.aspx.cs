﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Text;

namespace medesignsoft
{
    public partial class signin : System.Web.UI.Page
    {
        dbConnection dbConn = new dbConnection();

        string ssql;
        DataTable dt = new DataTable();

        public static string strErorConn = "";

        SqlConnection Conn = new SqlConnection();
        SqlCommand Comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlTransaction transac;

        public string strMsgAlert = "";
        public string strTblDetail = "";
        public string strTblActive = "";
        public string strErrorConn = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Remove("UserID");
            //Session.Remove("imEmployeeGid");
            //Session.Remove("FirstName");
            //Session.Remove("LastName");
            //Session.Remove("UserName");
            //Session.Remove("UserPassword");
            //Session.Remove("UserTypeID");
            //Session.Remove("UserTypeDesc");
            //Session.Remove("ActiveID");
            //Session.Remove("activename");
            //Session.Remove("CreatedBy");
            //Session.Remove("CreatedDate");
            //Session.Remove("UpdatedBy");
            //Session.Remove("UpdateDate");
            //Session.Remove("imPositionID");
            //Session.Remove("PositionName");
            //Session.Remove("imDepartmentID");
            //Session.Remove("DepartmentDesc");
            //Session.Remove("imSectionID");
            //Session.Remove("SectionDesc");
            //Session.Remove("EMail");
            //Session.Remove("imBranchGID");
            //Session.Remove("BranchName");
            //Session.Remove("adCompanyID");
            //Session.Remove("CompanyNameTh");

            

            if (!IsPostBack) {
                strErrorConn = "";

                Session.Abandon();
            }
        }

        protected void btnLogin_click (object sender, EventArgs e) {
            try
            {
                string strUserName = Request.Form["inpUserName"];
                string strPassWord = Request.Form["inpPassWord"];

                //string encassword = encryptpass(strPassWord);

                ssql = "exec spGetUserLogin '"+ strUserName + "', '"+ strPassWord + "' ";
                dt = new DataTable();
                dt = dbConn.GetDataTable(ssql);

                if (dt.Rows.Count != 0)
                {

                    Session["UserID"] = dt.Rows[0]["UserID"].ToString();
                    Session["imEmployeeGid"] = dt.Rows[0]["imEmployeeGid"].ToString();
                    Session["FirstName"] = dt.Rows[0]["FirstName"].ToString();
                    Session["LastName"] = dt.Rows[0]["LastName"].ToString();
                    Session["UserName"] = dt.Rows[0]["UserName"].ToString();
                    Session["UserPassword"] = dt.Rows[0]["UserPassword"].ToString();
                    Session["UserTypeID"] = dt.Rows[0]["UserTypeID"].ToString();
                    Session["UserTypeDesc"] = dt.Rows[0]["UserTypeDesc"].ToString();
                    Session["ActiveID"] = dt.Rows[0]["ActiveID"].ToString();
                    Session["activename"] = dt.Rows[0]["activename"].ToString();
                    Session["CreatedBy"] = dt.Rows[0]["CreatedBy"].ToString();
                    Session["CreatedDate"] = dt.Rows[0]["CreatedDate"].ToString();
                    Session["UpdatedBy"] = dt.Rows[0]["UpdatedBy"].ToString();
                    Session["UpdateDate"] = dt.Rows[0]["UpdateDate"].ToString();
                    Session["imPositionID"] = dt.Rows[0]["imPositionID"].ToString();
                    Session["PositionName"] = dt.Rows[0]["PositionName"].ToString();
                    Session["imDepartmentID"] = dt.Rows[0]["imDepartmentID"].ToString();
                    Session["DepartmentDesc"] = dt.Rows[0]["DepartmentDesc"].ToString();
                    Session["imSectionID"] = dt.Rows[0]["imSectionID"].ToString();
                    Session["SectionDesc"] = dt.Rows[0]["SectionDesc"].ToString();
                    Session["EMail"] = dt.Rows[0]["EMail"].ToString();
                    Session["imBranchGID"] = dt.Rows[0]["imBranchGID"].ToString();
                    Session["BranchName"] = dt.Rows[0]["BranchName"].ToString();
                    Session["adCompanyID"] = dt.Rows[0]["adCompanyID"].ToString();
                    Session["CompanyNameTh"] = dt.Rows[0]["CompanyNameTh"].ToString();

                    Response.Redirect("~/index.aspx");                  
                }
                else
                {

                    //Session["isLogin"] = Convert.ToInt32(Session["isLogin"].ToString()) + 1;

                    //if (Convert.ToInt32(Session["isLogin"]) == 3)
                    //{
                    //    strErorConn = " <div class=\"fad fad-in alert alert-danger input-sm\"> " +
                    //            "   <strong>Warning!</strong><br />Password is wrong 3 times, this account is locked please contact administrator..!</div>";
                    //}
                    //else
                    //{
                    //    strErorConn = " <div class=\"fad fad-in alert alert-danger input-sm\"> " +
                    //            "   <strong>Warning!</strong><br />Incorrect username or password..!</div>";
                    //}

                    strErorConn = " <div class=\"fad fad-in alert alert-danger input-sm\"> " +
                                "   <strong>Warning!</strong><br />Find not found username or password please check..!</div> ";

                    //Response.Redirect("signin.aspx");

                    return;
                }
            }
            catch (Exception ex)
            {
                strErorConn = " <div class=\"fad fad-in alert alert-danger input-sm\"> " +
                                "   <strong>Warning!</strong><br />Incorrect username or password <br /> " + ex.Message + "</div> ";
                //divWraning.Visible = true;
            }
        }


    }
}