﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace medesignsoft.meenterprise_management
{
    /// <summary>
    /// Summary description for general_services
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class general_services : System.Web.Services.WebService
    {
        dbConnection conn = new dbConnection();

        [WebMethod]
        public void getCompany()
        {
            List<cCompany> datas = new List<cCompany>();
            SqlCommand comm = new SqlCommand("spGetCompanyList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cCompany data = new cCompany();
                data.Gid = rdr["Gid"].ToString();
                data.adCompanyID = rdr["adCompanyID"].ToString();
                data.CompanyNameTh = rdr["CompanyNameTh"].ToString();
                data.CompanyNameEn = rdr["CompanyNameEn"].ToString();
                data.CompanyShortNameTh = rdr["CompanyShortNameTh"].ToString();
                data.CompanyShortNameEn = rdr["CompanyShortNameEn"].ToString();
                data.AddTh1 = rdr["AddTh1"].ToString();
                data.AddTh2 = rdr["AddTh2"].ToString();
                data.AddTh3 = rdr["AddTh3"].ToString();
                data.AddEn1 = rdr["AddEn1"].ToString();
                data.AddEn2 = rdr["AddEn2"].ToString();
                data.AddEn3 = rdr["AddEn3"].ToString();
                data.adProvinceID = rdr["adProvinceID"].ToString();
                data.ProvinceName = rdr["ProvinceName"].ToString();
                data.PostalCode = rdr["PostalCode"].ToString();
                data.adCountryID = rdr["adCountryID"].ToString();
                data.CountryName = rdr["CountryName"].ToString();
                data.Phone = rdr["Phone"].ToString();
                data.Fax = rdr["Fax"].ToString();
                data.EMail = rdr["EMail"].ToString();
                data.OwnerName = rdr["OwnerName"].ToString();
                data.TaxID = rdr["TaxID"].ToString();
                data.BFAccountBalanceDate = rdr["BFAccountBalanceDate"].ToString();
                data.Logo = rdr["Logo"].ToString();
                data.Active = rdr["Active"].ToString();
                data.EffectDate = rdr["EffectDate"].ToString();
                data.ExpireDate = rdr["ExpireDate"].ToString();
                data.IsHaveBranch = rdr["IsHaveBranch"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getCompanyById(string gid)
        {
            List<cCompany> datas = new List<cCompany>();
            SqlCommand comm = new SqlCommand("spGetCompanyById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cCompany data = new cCompany();
                data.Gid = rdr["Gid"].ToString();
                data.adCompanyID = rdr["adCompanyID"].ToString();
                data.CompanyNameTh = rdr["CompanyNameTh"].ToString();
                data.CompanyNameEn = rdr["CompanyNameEn"].ToString();
                data.CompanyShortNameTh = rdr["CompanyShortNameTh"].ToString();
                data.CompanyShortNameEn = rdr["CompanyShortNameEn"].ToString();
                data.AddTh1 = rdr["AddTh1"].ToString();
                data.AddTh2 = rdr["AddTh2"].ToString();
                data.AddTh3 = rdr["AddTh3"].ToString();
                data.AddEn1 = rdr["AddEn1"].ToString();
                data.AddEn2 = rdr["AddEn2"].ToString();
                data.AddEn3 = rdr["AddEn3"].ToString();
                data.adProvinceID = rdr["adProvinceID"].ToString();
                data.ProvinceName = rdr["ProvinceName"].ToString();
                data.PostalCode = rdr["PostalCode"].ToString();
                data.adCountryID = rdr["adCountryID"].ToString();
                data.CountryName = rdr["CountryName"].ToString();
                data.Phone = rdr["Phone"].ToString();
                data.Fax = rdr["Fax"].ToString();
                data.EMail = rdr["EMail"].ToString();
                data.OwnerName = rdr["OwnerName"].ToString();
                data.TaxID = rdr["TaxID"].ToString();
                data.BFAccountBalanceDate = rdr["BFAccountBalanceDate"].ToString();
                data.Logo = rdr["Logo"].ToString();
                data.Active = rdr["Active"].ToString();
                data.EffectDate = rdr["EffectDate"].ToString();
                data.ExpireDate = rdr["ExpireDate"].ToString();
                data.IsHaveBranch = rdr["IsHaveBranch"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getBranch() {
            List<cBranch> datas = new List<cBranch>();
            SqlCommand comm = new SqlCommand("spGetBranchList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cBranch data = new cBranch();
                data.imBranchGid = rdr["imBranchGid"].ToString();
                data.imBranchID = rdr["imBranchID"].ToString();
                data.BranchName = rdr["BranchName"].ToString();
                data.ShortBranchName = rdr["ShortBranchName"].ToString();
                data.adCompanyID = rdr["adCompanyID"].ToString();
                data.CompanyNameTh = rdr["CompanyNameTh"].ToString();
                data.TaxID = rdr["TaxID"].ToString();
                data.Add1 = rdr["Add1"].ToString();
                data.Add2 = rdr["Add2"].ToString();
                data.Add3 = rdr["Add3"].ToString();
                data.adProvinceID = rdr["adProvinceID"].ToString();
                data.ProvinceName = rdr["ProvinceName"].ToString();
                data.PostalCode = rdr["PostalCode"].ToString();
                data.adCountryID = rdr["adCountryID"].ToString();
                data.CountryName = rdr["CountryName"].ToString();
                data.Phone = rdr["Phone"].ToString();
                data.Fax = rdr["Fax"].ToString();
                data.WebSite = rdr["WebSite"].ToString();
                data.ContactID = rdr["ContactID"].ToString();
                data.ContactTel = rdr["ContactTel"].ToString();
                data.ContactEMail = rdr["ContactEMail"].ToString();
                data.Logo = rdr["Logo"].ToString();
                data.Active = rdr["Active"].ToString();
                data.EffectDate = rdr["EffectDate"].ToString();
                data.ExpireDate = rdr["ExpireDate"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();



        }

        [WebMethod]
        public void getBranchById(string gid)
        {
            List<cBranch> datas = new List<cBranch>();
            SqlCommand comm = new SqlCommand("spGetBranchById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cBranch data = new cBranch();
                data.imBranchGid = rdr["imBranchGid"].ToString();
                data.imBranchID = rdr["imBranchID"].ToString();
                data.BranchName = rdr["BranchName"].ToString();
                data.ShortBranchName = rdr["ShortBranchName"].ToString();
                data.adCompanyID = rdr["adCompanyID"].ToString();
                data.CompanyNameTh = rdr["CompanyNameTh"].ToString();
                data.TaxID = rdr["TaxID"].ToString();
                data.Add1 = rdr["Add1"].ToString();
                data.Add2 = rdr["Add2"].ToString();
                data.Add3 = rdr["Add3"].ToString();
                data.adProvinceID = rdr["adProvinceID"].ToString();
                data.ProvinceName = rdr["ProvinceName"].ToString();
                data.PostalCode = rdr["PostalCode"].ToString();
                data.adCountryID = rdr["adCountryID"].ToString();
                data.CountryName = rdr["CountryName"].ToString();
                data.Phone = rdr["Phone"].ToString();
                data.Fax = rdr["Fax"].ToString();
                data.WebSite = rdr["WebSite"].ToString();
                data.ContactID = rdr["ContactID"].ToString();
                data.ContactTel = rdr["ContactTel"].ToString();
                data.ContactEMail = rdr["ContactEMail"].ToString();
                data.Logo = rdr["Logo"].ToString();
                data.Active = rdr["Active"].ToString();
                data.EffectDate = rdr["EffectDate"].ToString();
                data.ExpireDate = rdr["ExpireDate"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getemployees()
        {
            List<cEmployees> datas = new List<cEmployees>();
            SqlCommand comm = new SqlCommand("spGetEmployees", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cEmployees data = new cEmployees();
                data.imEmployeeGid = rdr["imEmployeeGid"].ToString();
                data.EmployeeName = rdr["EmployeeName"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getEmployeesList() {
            List<cEmployeesList> datas = new List<cEmployeesList>();
            SqlCommand comm = new SqlCommand("spGetEmployeesList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandTimeout = 3600;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cEmployeesList data = new cEmployeesList();
                data.imEmployeeGid = rdr["imEmployeeGid"].ToString();

                data.imBranchGID = rdr["imBranchGID"].ToString();
                data.BranchName = rdr["BranchName"].ToString();
                data.imEmployeeID = rdr["imEmployeeID"].ToString();
                data.imTitleID = rdr["imTitleID"].ToString();
                data.TitleName = rdr["TitleName"].ToString();
                data.FirstName = rdr["FirstName"].ToString();
                data.MiddleName = rdr["MiddleName"].ToString();
                data.LastName = rdr["LastName"].ToString();
                data.NickName = rdr["NickName"].ToString();
                data.imPositionID = rdr["imPositionID"].ToString();
                data.PositionName = rdr["PositionName"].ToString();
                data.imDepartmentID = rdr["imDepartmentID"].ToString();
                data.DepartmentDesc = rdr["DepartmentDesc"].ToString();
                data.imSectionID = rdr["imSectionID"].ToString();
                data.SectionDesc = rdr["SectionDesc"].ToString();
                data.imDivisionID = rdr["imDivisionID"].ToString();
                data.DivisionDesc = rdr["DivisionDesc"].ToString();
                data.Add1 = rdr["Add1"].ToString();
                data.Add2 = rdr["Add2"].ToString();
                data.Add3 = rdr["Add3"].ToString();
                data.adProvinceID = rdr["adProvinceID"].ToString();
                data.ProvinceName = rdr["ProvinceName"].ToString();
                data.PostalCode = rdr["PostalCode"].ToString();
                data.adCountryID = rdr["adCountryID"].ToString();
                data.IDCardNO = rdr["IDCardNO"].ToString();
                data.imMaritalStatusID = rdr["imMaritalStatusID"].ToString();
                data.MaritalStatusDesc = rdr["MaritalStatusDesc"].ToString();
                data.imLivingStatusID = rdr["imLivingStatusID"].ToString();
                data.LivingStatusDesc = rdr["LivingStatusDesc"].ToString();
                data.imReligionID = rdr["imReligionID"].ToString();
                data.ReligionDesc = rdr["ReligionDesc"].ToString();
                data.imSexID = rdr["imSexID"].ToString();
                data.Birthday = rdr["Birthday"].ToString();
                data.Tel = rdr["Tel"].ToString();
                data.Mobile = rdr["Mobile"].ToString();
                data.Picture = rdr["Picture"].ToString();
                data.EMail = rdr["EMail"].ToString();
                data.Remark = rdr["Remark"].ToString();
                data.Active = rdr["Active"].ToString();
                data.activename = rdr["activename"].ToString();
                data.EffecDate = rdr["EffecDate"].ToString();
                data.ExpireDate = rdr["ExpireDate"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                data.changpass = rdr["changpass"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getEmployeesById(string gid)
        {
            List<cEmployeesList> datas = new List<cEmployeesList>();
            SqlCommand comm = new SqlCommand("spGetEmployeesById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);
            comm.CommandTimeout = 3600;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cEmployeesList data = new cEmployeesList();
                data.imEmployeeGid = rdr["imEmployeeGid"].ToString();
                data.imBranchID = rdr["imBranchID"].ToString();
                data.imBranchGID = rdr["imBranchGID"].ToString();
                data.imEmployeeID = rdr["imEmployeeID"].ToString();
                data.imTitleID = rdr["imTitleID"].ToString();
                data.TitleName = rdr["TitleName"].ToString();
                data.FirstName = rdr["FirstName"].ToString();
                data.MiddleName = rdr["MiddleName"].ToString();
                data.LastName = rdr["LastName"].ToString();
                data.NickName = rdr["NickName"].ToString();
                data.imPositionID = rdr["imPositionID"].ToString();
                data.PositionName = rdr["PositionName"].ToString();
                data.imDepartmentID = rdr["imDepartmentID"].ToString();
                data.DepartmentDesc = rdr["DepartmentDesc"].ToString();
                data.imSectionID = rdr["imSectionID"].ToString();
                data.SectionDesc = rdr["SectionDesc"].ToString();
                data.imDivisionID = rdr["imDivisionID"].ToString();
                data.DivisionDesc = rdr["DivisionDesc"].ToString();
                data.Add1 = rdr["Add1"].ToString();
                data.Add2 = rdr["Add2"].ToString();
                data.Add3 = rdr["Add3"].ToString();
                data.adProvinceID = rdr["adProvinceID"].ToString();
                data.ProvinceName = rdr["ProvinceName"].ToString();
                data.PostalCode = rdr["PostalCode"].ToString();
                data.adCountryID = rdr["adCountryID"].ToString();
                data.IDCardNO = rdr["IDCardNO"].ToString();
                data.imMaritalStatusID = rdr["imMaritalStatusID"].ToString();
                data.MaritalStatusDesc = rdr["MaritalStatusDesc"].ToString();
                data.imLivingStatusID = rdr["imLivingStatusID"].ToString();
                data.LivingStatusDesc = rdr["LivingStatusDesc"].ToString();
                data.imReligionID = rdr["imReligionID"].ToString();
                data.ReligionDesc = rdr["ReligionDesc"].ToString();
                data.imSexID = rdr["imSexID"].ToString();
                data.Birthday = rdr["Birthday"].ToString();
                data.Tel = rdr["Tel"].ToString();
                data.Mobile = rdr["Mobile"].ToString();
                data.Picture = rdr["Picture"].ToString();
                data.EMail = rdr["EMail"].ToString();
                data.Remark = rdr["Remark"].ToString();
                data.Active = rdr["Active"].ToString();
                data.activename = rdr["activename"].ToString();
                data.EffecDate = rdr["EffecDate"].ToString();
                data.ExpireDate = rdr["ExpireDate"].ToString();
                data.UserName = rdr["UserName"].ToString();
                data.UserTypeID = rdr["UserTypeID"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getEmployeesUpdateEntry(string acttrans, string Gid, string imBranchID, string imEmployeeID, string imTitleID, string FirstName
            , string LastName, string NickName, string imPositionID, string imDepartmentID, string imSectionID, string imDivisionID, string Add1, string Add2
            , string Add3, string adProvinceID, string PostalCode, string adCountryID, string IDCardNO, string imMaritalStatusID, string imLivingStatusID
            , string imReligionID, string imSexID, string Birthday, string Tel, string Mobile, string EMail, string Remark, string Active, string EffecDate, string ExpireDate) {


            SqlCommand comm = new SqlCommand("spGetEmployeesUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@Gid", Gid);
            comm.Parameters.AddWithValue("@imBranchID", imBranchID);
            comm.Parameters.AddWithValue("@imEmployeeID", imEmployeeID);
            comm.Parameters.AddWithValue("@imTitleID", imTitleID);
            comm.Parameters.AddWithValue("@FirstName", FirstName);
            comm.Parameters.AddWithValue("@LastName", LastName);
            comm.Parameters.AddWithValue("@NickName", NickName);
            comm.Parameters.AddWithValue("@imPositionID", imPositionID);
            comm.Parameters.AddWithValue("@imDepartmentID", imDepartmentID);
            comm.Parameters.AddWithValue("@imSectionID", imSectionID);
            comm.Parameters.AddWithValue("@imDivisionID", imDivisionID);
            comm.Parameters.AddWithValue("@Add1", Add1);
            comm.Parameters.AddWithValue("@Add2", Add2);
            comm.Parameters.AddWithValue("@Add3", Add3);
            comm.Parameters.AddWithValue("@adProvinceID", adProvinceID);
            comm.Parameters.AddWithValue("@PostalCode", PostalCode);
            comm.Parameters.AddWithValue("@adCountryID", adCountryID);
            comm.Parameters.AddWithValue("@IDCardNO", IDCardNO);
            comm.Parameters.AddWithValue("@imMaritalStatusID", imMaritalStatusID);
            comm.Parameters.AddWithValue("@imLivingStatusID", imLivingStatusID);
            comm.Parameters.AddWithValue("@imReligionID", imReligionID);
            comm.Parameters.AddWithValue("@imSexID", imSexID);
            comm.Parameters.AddWithValue("@Birthday", Birthday);
            comm.Parameters.AddWithValue("@Tel", Tel);
            comm.Parameters.AddWithValue("@Mobile", Mobile);
            comm.Parameters.AddWithValue("@EMail", EMail);
            comm.Parameters.AddWithValue("@Remark", Remark);
            comm.Parameters.AddWithValue("@Active", Active);
            comm.Parameters.AddWithValue("@EffecDate", EffecDate);
            comm.Parameters.AddWithValue("@ExpireDate", ExpireDate);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }


        [WebMethod]
        public void getprovince() {
            List<cProvince> datas = new List<cProvince>();
            SqlCommand comm = new SqlCommand("spGetProvince", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cProvince data = new cProvince();
                data.adProvinceID = rdr["adProvinceID"].ToString();
                data.ProvinceName = rdr["ProvinceName"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getcountry()
        {
            List<cCountries> datas = new List<cCountries>();
            SqlCommand comm = new SqlCommand("spGetCountry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cCountries data = new cCountries();
                data.adCountryID = rdr["adCountryID"].ToString();
                data.CountryName = rdr["CountryName"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getTitlename() {
            List<cTitlename> datas = new List<cTitlename>();
            SqlCommand comm = new SqlCommand("spGetTitleName", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cTitlename data = new cTitlename();
                data.imTitleGid = rdr["imTitleGid"].ToString();
                data.TitleName = rdr["TitleName"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getPosition() {
            List<cPosition> datas = new List<cPosition>();
            SqlCommand comm = new SqlCommand("spGetPosition", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cPosition data = new cPosition();
                data.imPositionID = rdr["imPositionID"].ToString();
                data.PositionName = rdr["PositionName"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getDivision() {
            List<cDivision> datas = new List<cDivision>();
            SqlCommand comm = new SqlCommand("spGetDivision", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cDivision data = new cDivision();
                data.imDivisionID = rdr["imDivisionID"].ToString();
                data.DivisionDesc = rdr["DivisionDesc"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getMarry()
        {
            List<cMarry> datas = new List<cMarry>();
            SqlCommand comm = new SqlCommand("spGetMarry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cMarry data = new cMarry();
                data.imMaritalStatusID = rdr["imMaritalStatusID"].ToString();
                data.MaritalStatusDesc = rdr["MaritalStatusDesc"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getLivingStatus()
        {
            List<cLivingStatus> datas = new List<cLivingStatus>();
            SqlCommand comm = new SqlCommand("spGetLivingStatus", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cLivingStatus data = new cLivingStatus();
                data.imLivingStatusID = rdr["imLivingStatusID"].ToString();
                data.LivingStatusDesc = rdr["LivingStatusDesc"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getReligion()
        {
            List<cReligion> datas = new List<cReligion>();
            SqlCommand comm = new SqlCommand("spGetReligion", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cReligion data = new cReligion();
                data.imReligionID = rdr["imReligionID"].ToString();
                data.ReligionDesc = rdr["ReligionDesc"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getSex()
        {
            List<cSex> datas = new List<cSex>();
            SqlCommand comm = new SqlCommand("spGetSex", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cSex data = new cSex();
                data.imSexID = rdr["imSexID"].ToString();
                data.SexDesc = rdr["SexDesc"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getactive()
        {
            List<cIsActive> datas = new List<cIsActive>();
            SqlCommand comm = new SqlCommand("spGetActive", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cIsActive data = new cIsActive();
                data.activeid = rdr["activeid"].ToString();
                data.activename = rdr["activename"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getSectionList() {
            List<cSectionList> datas = new List<cSectionList>();
            SqlCommand comm = new SqlCommand("spGetSectionList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cSectionList data = new cSectionList();
                data.Gid = rdr["Gid"].ToString();
                data.imSectionID = rdr["imSectionID"].ToString();
                data.SectionDesc = rdr["SectionDesc"].ToString();
                data.SectionDesc2 = rdr["SectionDesc2"].ToString();
                data.Active = rdr["Active"].ToString();
                data.ActiveName = rdr["ActiveName"].ToString();
                data.EffectDate = rdr["EffectDate"].ToString();
                data.ExpireDate = rdr["ExpireDate"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getSectionById(string gid) {
            List<cSectionList> datas = new List<cSectionList>();
            SqlCommand comm = new SqlCommand("spGetSectionById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cSectionList data = new cSectionList();
                data.Gid = rdr["Gid"].ToString();
                data.imSectionID = rdr["imSectionID"].ToString();
                data.SectionDesc = rdr["SectionDesc"].ToString();
                data.SectionDesc2 = rdr["SectionDesc2"].ToString();
                data.Active = rdr["Active"].ToString();
                data.EffectDate = rdr["EffectDate"].ToString();
                data.ExpireDate = rdr["ExpireDate"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getSectionUpdateEntry(string acttrans, string Gid, string imSectionID, string SectionDesc, string SectionDesc2, string Active, string EffectDate, string ExpireDate)
        {
            SqlCommand comm = new SqlCommand("spGetSectionUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@Gid", Gid);
            comm.Parameters.AddWithValue("@imSectionID", imSectionID);
            comm.Parameters.AddWithValue("@SectionDesc", SectionDesc);
            comm.Parameters.AddWithValue("@SectionDesc2", SectionDesc2);
            comm.Parameters.AddWithValue("@Active", Active);
            comm.Parameters.AddWithValue("@EffectDate", EffectDate);
            comm.Parameters.AddWithValue("@ExpireDate", ExpireDate);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void getDepartmentList()
        {
            List<cDepartmentList> datas = new List<cDepartmentList>();
            SqlCommand comm = new SqlCommand("spGetDepartmentList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cDepartmentList data = new cDepartmentList();
                data.Gid = rdr["Gid"].ToString();
                data.imDepartmentID = rdr["imDepartmentID"].ToString();
                data.DepartmentDesc = rdr["DepartmentDesc"].ToString();
                data.DepartmentDesc2 = rdr["DepartmentDesc2"].ToString();
                data.Active = rdr["Active"].ToString();
                data.ActiveName = rdr["ActiveName"].ToString();
                data.EffectDate = rdr["EffectDate"].ToString();
                data.ExpireDate = rdr["ExpireDate"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getDepartmentById(string gid)
        {
            List<cDepartmentList> datas = new List<cDepartmentList>();
            SqlCommand comm = new SqlCommand("spGetDepartmentById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cDepartmentList data = new cDepartmentList();
                data.Gid = rdr["Gid"].ToString();
                data.imDepartmentID = rdr["imDepartmentID"].ToString();
                data.DepartmentDesc = rdr["DepartmentDesc"].ToString();
                data.DepartmentDesc2 = rdr["DepartmentDesc2"].ToString();
                data.Active = rdr["Active"].ToString();
                data.EffectDate = rdr["EffectDate"].ToString();
                data.ExpireDate = rdr["ExpireDate"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getDepartmentUpdateEntry(string acttrans, string Gid, string imDepartmentID, string DepartmentDesc, string DepartmentDesc2, string Active, string EffectDate, string ExpireDate) {
            SqlCommand comm = new SqlCommand("spGetDepartmentUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@Gid", Gid);
            comm.Parameters.AddWithValue("@imDepartmentID", imDepartmentID);
            comm.Parameters.AddWithValue("@DepartmentDesc", DepartmentDesc);
            comm.Parameters.AddWithValue("@DepartmentDesc2", DepartmentDesc2);
            comm.Parameters.AddWithValue("@Active", Active);
            comm.Parameters.AddWithValue("@EffectDate", EffectDate);
            comm.Parameters.AddWithValue("@ExpireDate", ExpireDate);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void getCompanyUpdateEntry(string acttrans, string Gid, string adCompanyID, string CompanyNameTh, string CompanyNameEn, string CompanyShortNameTh
                                        , string CompanyShortNameEn, string AddTh1, string AddTh2, string AddTh3, string AddEn1, string AddEn2, string AddEn3
                                        , string adProvinceID, string PostalCode, string adCountryID, string Phone, string Fax, string EMail
                                        , string OwnerName, string TaxID, string BFAccountBalanceDate, string Logo, string Active, string EffectDate
                                        , string ExpireDate, string IsHaveBranch)
        {

            SqlCommand comm = new SqlCommand("spGetCompanyUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@Gid", Gid);
            comm.Parameters.AddWithValue("@adCompanyID", adCompanyID);
            comm.Parameters.AddWithValue("@CompanyNameTh", CompanyNameTh);
            comm.Parameters.AddWithValue("@CompanyNameEn", CompanyNameEn);
            comm.Parameters.AddWithValue("@CompanyShortNameTh", CompanyShortNameTh);
            comm.Parameters.AddWithValue("@CompanyShortNameEn", CompanyShortNameEn);
            comm.Parameters.AddWithValue("@AddTh1", AddTh1);
            comm.Parameters.AddWithValue("@AddTh2", AddTh2);
            comm.Parameters.AddWithValue("@AddTh3", AddTh3);
            comm.Parameters.AddWithValue("@AddEn1", AddEn1);
            comm.Parameters.AddWithValue("@AddEn2", AddEn2);
            comm.Parameters.AddWithValue("@AddEn3", AddEn3);
            comm.Parameters.AddWithValue("@adProvinceID", adProvinceID);
            comm.Parameters.AddWithValue("@PostalCode", PostalCode);
            comm.Parameters.AddWithValue("@adCountryID", adCountryID);
            comm.Parameters.AddWithValue("@Phone", Phone);
            comm.Parameters.AddWithValue("@Fax", Fax);
            comm.Parameters.AddWithValue("@EMail", EMail);
            comm.Parameters.AddWithValue("@OwnerName", OwnerName);
            comm.Parameters.AddWithValue("@TaxID", TaxID);
            comm.Parameters.AddWithValue("@BFAccountBalanceDate", BFAccountBalanceDate);
            comm.Parameters.AddWithValue("@Logo", Logo);
            comm.Parameters.AddWithValue("@Active", Active);
            comm.Parameters.AddWithValue("@EffectDate", EffectDate);
            comm.Parameters.AddWithValue("@ExpireDate", ExpireDate);
            comm.Parameters.AddWithValue("@IsHaveBranch", IsHaveBranch);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void getBranchUpdateEntry(string acttrans, string Gid, string imBranchID, string BranchName, string ShortBranchName, string adCompanyID, string TaxID, string Add1
                                        , string Add2, string Add3, string adProvinceID, string PostalCode, string adCountryID, string Phone, string Fax, string WebSite
                                        , string ContactID, string ContactTel, string ContactEMail, string Logo, string Active, string EffectDate, string ExpireDate) {
            SqlCommand comm = new SqlCommand("spGetBranchUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@Gid", Gid);
            comm.Parameters.AddWithValue("@imBranchID", imBranchID);
            comm.Parameters.AddWithValue("@BranchName", BranchName);
            comm.Parameters.AddWithValue("@ShortBranchName", ShortBranchName);
            comm.Parameters.AddWithValue("@adCompanyID", adCompanyID);
            comm.Parameters.AddWithValue("@TaxID", TaxID);
            comm.Parameters.AddWithValue("@Add1", Add1);
            comm.Parameters.AddWithValue("@Add2", Add2);
            comm.Parameters.AddWithValue("@Add3", Add3);
            comm.Parameters.AddWithValue("@adProvinceID", adProvinceID);
            comm.Parameters.AddWithValue("@PostalCode", PostalCode);
            comm.Parameters.AddWithValue("@adCountryID", adCountryID);
            comm.Parameters.AddWithValue("@Phone", Phone);
            comm.Parameters.AddWithValue("@Fax", Fax);
            comm.Parameters.AddWithValue("@WebSite", WebSite);
            comm.Parameters.AddWithValue("@ContactID", ContactID);
            comm.Parameters.AddWithValue("@ContactTel", ContactTel);
            comm.Parameters.AddWithValue("@ContactEMail", ContactEMail);
            comm.Parameters.AddWithValue("@Logo", Logo);
            comm.Parameters.AddWithValue("@Active", Active);
            comm.Parameters.AddWithValue("@EffectDate", EffectDate);
            comm.Parameters.AddWithValue("@ExpireDate", ExpireDate);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void getAutorunList() {
            List<cAutorunList> datas = new List<cAutorunList>();
            SqlCommand comm = new SqlCommand("spGetAutorunList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cAutorunList data = new cAutorunList();
                data.AutoRunID = rdr["AutoRunID"].ToString();
                data.AutoRunCode = rdr["AutoRunCode"].ToString();
                data.AutoRunDesc = rdr["AutoRunDesc"].ToString();
                data.imBranchGid = rdr["imBranchGid"].ToString();
                data.BranchName = rdr["BranchName"].ToString();
                data.AutoRunFormat = rdr["AutoRunFormat"].ToString();
                data.AutoRunTitle = rdr["AutoRunTitle"].ToString();
                data.AutoRunYear = rdr["AutoRunYear"].ToString();
                data.AutoRunSplit = rdr["AutoRunSplit"].ToString();
                data.AutoRunNo = rdr["AutoRunNo"].ToString();
                data.DocuNo = rdr["DocuNo"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getAutorunById(string gid) {
            List<cAutorunList> datas = new List<cAutorunList>();
            SqlCommand comm = new SqlCommand("spGetAutorunById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cAutorunList data = new cAutorunList();
                data.AutoRunID = rdr["AutoRunID"].ToString();
                data.AutoRunCode = rdr["AutoRunCode"].ToString();
                data.AutoRunDesc = rdr["AutoRunDesc"].ToString();
                data.imBranchGid = rdr["imBranchGid"].ToString();
                data.BranchName = rdr["BranchName"].ToString();
                data.AutoRunFormat = rdr["AutoRunFormat"].ToString();
                data.AutoRunTitle = rdr["AutoRunTitle"].ToString();
                data.AutoRunYear = rdr["AutoRunYear"].ToString();
                data.AutoRunSplit = rdr["AutoRunSplit"].ToString();
                data.AutoRunNo = rdr["AutoRunNo"].ToString();
                data.DocuNo = rdr["DocuNo"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getAutorunUpdateEntry(string acttrans, string Gid, string AutoRunCode, string AutoRunDesc, string imBranchGid, string AutoRunFormat
                                            , string AutoRunTitle, string AutoRunYear, string AutoRunSplit, string AutoRunNo, string CreateUserID
                                            , string CreateDate, string CreateTime, string adUserID, string Lastdate, string LastTime) {
            SqlCommand comm = new SqlCommand("spGetAutorunUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@Gid", Gid);
            comm.Parameters.AddWithValue("@AutoRunCode", AutoRunCode);
            comm.Parameters.AddWithValue("@AutoRunDesc", AutoRunDesc);
            comm.Parameters.AddWithValue("@imBranchGid", imBranchGid);
            comm.Parameters.AddWithValue("@AutoRunFormat", AutoRunFormat);
            comm.Parameters.AddWithValue("@AutoRunTitle", AutoRunTitle);
            comm.Parameters.AddWithValue("@AutoRunYear", AutoRunYear);
            comm.Parameters.AddWithValue("@AutoRunSplit", AutoRunSplit);
            comm.Parameters.AddWithValue("@AutoRunNo", AutoRunNo);
            comm.Parameters.AddWithValue("@CreateUserID", CreateUserID);
            comm.Parameters.AddWithValue("@CreateDate", CreateDate);
            comm.Parameters.AddWithValue("@CreateTime", CreateTime);
            comm.Parameters.AddWithValue("@adUserID", adUserID);
            comm.Parameters.AddWithValue("@Lastdate", Lastdate);
            comm.Parameters.AddWithValue("@LastTime", LastTime);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void getUsertype() {
            List<cUserType> datas = new List<cUserType>();
            SqlCommand comm = new SqlCommand("spGetUserType", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cUserType data = new cUserType();
                data.UserTypeID = rdr["UserTypeID"].ToString();
                data.UserTypeDesc = rdr["UserTypeDesc"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getUserLoginUpdateEntry(string acttrans, string Gid, string UserID, string imEmployeeGid, string FirstName, string LastName, string UserName, string UserPassword,
                                            string UserTypeID, string ActiveID, string CreatedBy, string CreatedDate, string UpdatedBy, string UpdateDate) {
            SqlCommand comm = new SqlCommand("spGetUserLoginUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@Gid", Gid);
            comm.Parameters.AddWithValue("@UserID", UserID);
            comm.Parameters.AddWithValue("@imEmployeeGid", imEmployeeGid);
            comm.Parameters.AddWithValue("@FirstName", FirstName);
            comm.Parameters.AddWithValue("@LastName", LastName);
            comm.Parameters.AddWithValue("@UserName", UserName);
            comm.Parameters.AddWithValue("@UserPassword", UserPassword);
            comm.Parameters.AddWithValue("@UserTypeID", UserTypeID);
            comm.Parameters.AddWithValue("@ActiveID", ActiveID);
            comm.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            comm.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            comm.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
            comm.Parameters.AddWithValue("@UpdateDate", UpdateDate);

            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void getTermsList()
        {
            List<cTermsList> datas = new List<cTermsList>();
            SqlCommand comm = new SqlCommand("spGetTermsList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cTermsList data = new cTermsList();
                data.adPaymentTypeID = rdr["adPaymentTypeID"].ToString();
                data.PaymentTypeDesc = rdr["PaymentTypeDesc"].ToString();
                data.PaymentTypeDesc2 = rdr["PaymentTypeDesc2"].ToString();
                data.Active = rdr["Active"].ToString();
                data.activename = rdr["activename"].ToString();
                data.EffectDate = rdr["EffectDate"].ToString();
                data.ExpireDate = rdr["ExpireDate"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getTermsById(string gid) {
            List<cTermsList> datas = new List<cTermsList>();
            SqlCommand comm = new SqlCommand("spGetTermsById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cTermsList data = new cTermsList();
                data.adPaymentTypeID = rdr["adPaymentTypeID"].ToString();
                data.PaymentTypeDesc = rdr["PaymentTypeDesc"].ToString();
                data.PaymentTypeDesc2 = rdr["PaymentTypeDesc2"].ToString();
                data.Active = rdr["Active"].ToString();
                data.activename = rdr["activename"].ToString();
                data.EffectDate = rdr["EffectDate"].ToString();
                data.ExpireDate = rdr["ExpireDate"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getTermsUpdateEntry(string acttrans, string Gid, string adPaymentTypeID, string PaymentTypeDesc, string PaymentTypeDesc2,
                                        string Active, string EffectDate, string ExpireDate) {

            SqlCommand comm = new SqlCommand("spGetTermsUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@Gid", Gid);
            comm.Parameters.AddWithValue("@adPaymentTypeID", adPaymentTypeID);
            comm.Parameters.AddWithValue("@PaymentTypeDesc", PaymentTypeDesc);
            comm.Parameters.AddWithValue("@PaymentTypeDesc2", PaymentTypeDesc2);
            comm.Parameters.AddWithValue("@Active", Active);
            comm.Parameters.AddWithValue("@EffectDate", EffectDate);
            comm.Parameters.AddWithValue("@ExpireDate", ExpireDate);
            comm.ExecuteNonQuery();
            conn.CloseConn();

        }

        [WebMethod]
        public void getOndeliveryList() {
            List<cDeliveryList> datas = new List<cDeliveryList>();
            SqlCommand comm = new SqlCommand("spGetDeliveryList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cDeliveryList data = new cDeliveryList();
                data.imDeliveryID = rdr["imDeliveryID"].ToString();
                data.DeliveryName = rdr["DeliveryName"].ToString();
                data.DeliveryName2 = rdr["DeliveryName2"].ToString();
                data.Active = rdr["Active"].ToString();
                data.activename = rdr["activename"].ToString();
                data.EffectDate = rdr["EffectDate"].ToString();
                data.ExpireDate = rdr["ExpireDate"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getDeliveryById(string gid) {
            List<cDeliveryList> datas = new List<cDeliveryList>();
            SqlCommand comm = new SqlCommand("spGetDeliveryById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cDeliveryList data = new cDeliveryList();
                data.imDeliveryID = rdr["imDeliveryID"].ToString();
                data.DeliveryName = rdr["DeliveryName"].ToString();
                data.DeliveryName2 = rdr["DeliveryName2"].ToString();
                data.Active = rdr["Active"].ToString();
                data.activename = rdr["activename"].ToString();
                data.EffectDate = rdr["EffectDate"].ToString();
                data.ExpireDate = rdr["ExpireDate"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getDeliveryUpdateEntry(string acttrans, string Gid, string imDeliveryID, string DeliveryName, string DeliveryName2,
                                        string Active, string EffectDate, string ExpireDate)
        {
            SqlCommand comm = new SqlCommand("spGetDeliveryUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@Gid", Gid);
            comm.Parameters.AddWithValue("@imDeliveryID", imDeliveryID);
            comm.Parameters.AddWithValue("@DeliveryName", DeliveryName);
            comm.Parameters.AddWithValue("@DeliveryName2", DeliveryName2);
            comm.Parameters.AddWithValue("@Active", Active);
            comm.Parameters.AddWithValue("@EffectDate", EffectDate);
            comm.Parameters.AddWithValue("@ExpireDate", ExpireDate);
            comm.ExecuteNonQuery();
            conn.CloseConn();

        }

        [WebMethod]
        public void getVendorGroupList() {
            List<cVendorGroupList> datas = new List<cVendorGroupList>();
            SqlCommand comm = new SqlCommand("spGetVendorGroupList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cVendorGroupList data = new cVendorGroupList();
                data.VendorGroupID = rdr["VendorGroupID"].ToString();
                data.VendorGroupCode = rdr["VendorGroupCode"].ToString();
                data.VendorGroupName = rdr["VendorGroupName"].ToString();
                data.VendorGroupNameEng = rdr["VendorGroupNameEng"].ToString();
                data.Remark = rdr["Remark"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getVendorGroupById(string gid) {
            List<cVendorGroupList> datas = new List<cVendorGroupList>();
            SqlCommand comm = new SqlCommand("spGetVendorGroupById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cVendorGroupList data = new cVendorGroupList();
                data.VendorGroupID = rdr["VendorGroupID"].ToString();
                data.VendorGroupCode = rdr["VendorGroupCode"].ToString();
                data.VendorGroupName = rdr["VendorGroupName"].ToString();
                data.VendorGroupNameEng = rdr["VendorGroupNameEng"].ToString();
                data.Remark = rdr["Remark"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

       [WebMethod]
        public void getVendorGroupUpdateEntry(string acttrans, string gid, string VendorGroupID, string VendorGroupCode, string VendorGroupName, string VendorGroupNameEng, string Remark) {
            SqlCommand comm = new SqlCommand("spGetVendorGroupUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@gid", gid);
            comm.Parameters.AddWithValue("@VendorGroupID", VendorGroupID);
            comm.Parameters.AddWithValue("@VendorGroupCode", VendorGroupCode);
            comm.Parameters.AddWithValue("@VendorGroupName", VendorGroupName);
            comm.Parameters.AddWithValue("@VendorGroupNameEng", VendorGroupNameEng);
            comm.Parameters.AddWithValue("@Remark", Remark);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void getVendorList() {
            List<cVendorList> datas = new List<cVendorList>();
            SqlCommand comm = new SqlCommand("spGetVendorList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cVendorList data = new cVendorList();
                data.VendorID = rdr["VendorID"].ToString();
                data.VendorCode = rdr["VendorCode"].ToString();
                data.VendorName = rdr["VendorName"].ToString();
                data.VendorNameEng = rdr["VendorNameEng"].ToString();
                data.ShortName = rdr["ShortName"].ToString();
                data.VendorStartDate = rdr["VendorStartDate"].ToString();
                data.VendorGroupID = rdr["VendorGroupID"].ToString();
                data.VendorGroupName = rdr["VendorGroupName"].ToString();
                data.Active = rdr["Active"].ToString();
                data.activename = rdr["activename"].ToString();
                data.InactiveDate = rdr["InactiveDate"].ToString();
                data.adPaymentTypeID = rdr["adPaymentTypeID"].ToString();
                data.PaymentTypeDesc = rdr["PaymentTypeDesc"].ToString();
                data.VendorTypeID = rdr["VendorTypeID"].ToString();
                data.VendorTypeName = rdr["VendorTypeName"].ToString();
                data.TaxId = rdr["TaxId"].ToString();
                data.VendorAddr1 = rdr["VendorAddr1"].ToString();
                data.VendorAddr2 = rdr["VendorAddr2"].ToString();
                data.District = rdr["District"].ToString();
                data.Amphur = rdr["Amphur"].ToString();
                data.adProvinceID = rdr["adProvinceID"].ToString();
                data.ProvinceName = rdr["ProvinceName"].ToString();
                data.PostCode = rdr["PostCode"].ToString();
                data.ContAddr1 = rdr["ContAddr1"].ToString();
                data.ContAddr2 = rdr["ContAddr2"].ToString();
                data.ContDistrict = rdr["ContDistrict"].ToString();
                data.ContAmphur = rdr["ContAmphur"].ToString();
                data.ContProvince = rdr["ContProvince"].ToString();
                data.ContPostCode = rdr["ContPostCode"].ToString();
                data.ContHomePage = rdr["ContHomePage"].ToString();
                data.ContTel = rdr["ContTel"].ToString();
                data.ContFax = rdr["ContFax"].ToString();
                data.CardNo = rdr["CardNo"].ToString();
                data.VATGroupID = rdr["VATGroupID"].ToString();
                data.VATGroupDesc = rdr["VATGroupDesc"].ToString();
                data.Birthdate = rdr["Birthdate"].ToString();
                data.ContTelExtend1 = rdr["ContTelExtend1"].ToString();
                data.ContTelExtend2 = rdr["ContTelExtend2"].ToString();
                data.imBranchID = rdr["imBranchID"].ToString();
                data.BranchCode = rdr["BranchCode"].ToString();
                data.BranchName = rdr["BranchName"].ToString();
                data.CreditDays = rdr["CreditDays"].ToString();
                data.CreditAmnt = rdr["CreditAmnt"].ToString();
                data.CreatedBy = rdr["CreatedBy"].ToString();
                data.CreatedDate = rdr["CreatedDate"].ToString();
                data.UpdatedBy = rdr["UpdatedBy"].ToString();
                data.UpdateDate = rdr["UpdateDate"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getVendorType()
        {
            List<cVendorType> datas = new List<cVendorType>();
            SqlCommand comm = new SqlCommand("spGetVendorType", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cVendorType data = new cVendorType();
                data.VendorTypeID = rdr["VendorTypeID"].ToString();
                data.VendorTypeCode = rdr["VendorTypeCode"].ToString();
                data.VendorTypeName = rdr["VendorTypeName"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getVendorTypeList()
        {
            List<cVendorType> datas = new List<cVendorType>();
            SqlCommand comm = new SqlCommand("spGetVendorTypeList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cVendorType data = new cVendorType();
                data.VendorTypeID = rdr["VendorTypeID"].ToString();
                data.VendorTypeCode = rdr["VendorTypeCode"].ToString();
                data.VendorTypeName = rdr["VendorTypeName"].ToString();
                data.VendorTypeNameEng = rdr["VendorTypeNameEng"].ToString();
                data.Remark = rdr["Remark"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getVendorTypeById(string gid) {
            List<cVendorType> datas = new List<cVendorType>();
            SqlCommand comm = new SqlCommand("spGetVendorTypeById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cVendorType data = new cVendorType();
                data.VendorTypeID = rdr["VendorTypeID"].ToString();
                data.VendorTypeCode = rdr["VendorTypeCode"].ToString();
                data.VendorTypeName = rdr["VendorTypeName"].ToString();
                data.VendorTypeNameEng = rdr["VendorTypeNameEng"].ToString();
                data.Remark = rdr["Remark"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getVendorTypeUpdateEntry(string acttrans, string gid, string VendorTypeID, string VendorTypeCode, string VendorTypeName, string VendorTypeNameEng, string Remark) {
            SqlCommand comm = new SqlCommand("spGetVendorTypeUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@gid", gid);
            comm.Parameters.AddWithValue("@VendorTypeID", VendorTypeID);
            comm.Parameters.AddWithValue("@VendorTypeCode", VendorTypeCode);
            comm.Parameters.AddWithValue("@VendorTypeName", VendorTypeName);
            comm.Parameters.AddWithValue("@VendorTypeNameEng", VendorTypeNameEng);
            comm.Parameters.AddWithValue("@Remark", Remark);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void getVendorById(string gid)
        {
            List<cVendorsById> datas = new List<cVendorsById>();
            SqlCommand comm = new SqlCommand("spGetVendorById2", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cVendorsById data = new cVendorsById();

                data.VendorID = rdr["VendorID"].ToString();
                data.VendorGroupID = rdr["VendorGroupID"].ToString();
                data.VendorGroupName = rdr["VendorGroupName"].ToString();
                data.VendorCode = rdr["VendorCode"].ToString();
                data.VendorName = rdr["VendorName"].ToString();
                data.VendorNameEng = rdr["VendorNameEng"].ToString();
                data.ShortName = rdr["ShortName"].ToString();
                data.VendorStartDate = rdr["VendorStartDate"].ToString();
                data.Active = rdr["Active"].ToString();
                data.activename = rdr["activename"].ToString();
                data.InactiveDate = rdr["InactiveDate"].ToString();
                data.adPaymentTypeID = rdr["adPaymentTypeID"].ToString();
                data.PaymentTypeDesc = rdr["PaymentTypeDesc"].ToString();
                data.VendorTypeID = rdr["VendorTypeID"].ToString();
                data.VendorTypeName = rdr["VendorTypeName"].ToString();
                data.TaxId = rdr["TaxId"].ToString();
                data.VendorAddr1 = rdr["VendorAddr1"].ToString();
                data.VendorAddr2 = rdr["VendorAddr2"].ToString();
                data.District = rdr["District"].ToString();
                data.Amphur = rdr["Amphur"].ToString();
                data.adProvinceID = rdr["adProvinceID"].ToString();
                data.ProvinceName = rdr["ProvinceName"].ToString();
                data.PostCode = rdr["PostCode"].ToString();
                data.ContAddr1 = rdr["ContAddr1"].ToString();
                data.ContAddr2 = rdr["ContAddr2"].ToString();
                data.ContDistrict = rdr["ContDistrict"].ToString();
                data.ContAmphur = rdr["ContAmphur"].ToString();
                data.ContProvince = rdr["ContProvince"].ToString();
                data.ConProvinceName = rdr["ConProvinceName"].ToString();
                data.ContPostCode = rdr["ContPostCode"].ToString();
                data.ContHomePage = rdr["ContHomePage"].ToString();
                data.ContTel = rdr["ContTel"].ToString();
                data.ContFax = rdr["ContFax"].ToString();
                data.CardNo = rdr["CardNo"].ToString();
                data.VATGroupID = rdr["VATGroupID"].ToString();
                data.VATGroupDesc = rdr["VATGroupDesc"].ToString();
                data.imBranchID = rdr["imBranchID"].ToString();
                data.Birthdate = rdr["Birthdate"].ToString();
                data.ContTelExtend1 = rdr["ContTelExtend1"].ToString();
                data.ContTelExtend2 = rdr["ContTelExtend2"].ToString();
                data.BranchCode = rdr["BranchCode"].ToString();
                data.BranchName = rdr["BranchName"].ToString();
                data.CreditDays = rdr["CreditDays"].ToString();
                data.CreditAmnt = rdr["CreditAmnt"].ToString();
                data.CreatedBy = rdr["CreatedBy"].ToString();
                data.CreatedDate = rdr["CreatedDate"].ToString();
                data.UpdatedBy = rdr["UpdatedBy"].ToString();
                data.UpdateDate = rdr["UpdateDate"].ToString();
                data.SalesCode = rdr["SalesCode"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getVatGroup()
        {
            List<cVatGroup> datas = new List<cVatGroup>();
            SqlCommand comm = new SqlCommand("spGetVatGroup", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cVatGroup data = new cVatGroup();
                data.VATGroupID = rdr["VATGroupID"].ToString();
                data.VATGroupDesc = rdr["VATGroupDesc"].ToString();
                data.VatRate = rdr["VatRate"].ToString();
                data.VatType = rdr["VatType"].ToString();
                data.Remark = rdr["Remark"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getVendorUpdateEntry(string acttrans, string gid, string VendorID, string VendorGroupID, string VendorCode, string VendorName, string VendorNameEng, string ShortName, string VendorStartDate
                    , string Active, string InactiveDate, string adPaymentTypeID, string VendorTypeID, string TaxId, string VendorAddr1, string VendorAddr2, string District, string Amphur, string adProvinceID
                    , string PostCode, string ContAddr1, string ContAddr2, string ContDistrict, string ContAmphur, string ContProvince, string ContPostCode, string ContHomePage, string ContTel, string ContFax
                    , string CardNo, string VATGroupID, string imBranchID, string Birthdate, string ContTelExtend1, string ContTelExtend2, string BranchCode, string BranchName, string CreditDays, string CreditAmnt
                    , string CreatedBy, string CreatedDate, string UpdatedBy, string UpdateDate, string SalesCode)
        {
            SqlCommand comm = new SqlCommand("spGetVendorUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            //comm.Parameters.AddWithValue("@acttrans", acttrans);
            //comm.Parameters.AddWithValue("@Gid", gid);

            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@gid", gid);
            comm.Parameters.AddWithValue("@VendorID", VendorID);
            comm.Parameters.AddWithValue("@VendorGroupID", VendorGroupID);
            comm.Parameters.AddWithValue("@VendorCode", VendorCode);
            comm.Parameters.AddWithValue("@VendorName", VendorName);
            comm.Parameters.AddWithValue("@VendorNameEng", VendorNameEng);
            comm.Parameters.AddWithValue("@ShortName", ShortName);
            comm.Parameters.AddWithValue("@VendorStartDate", VendorStartDate);
            comm.Parameters.AddWithValue("@Active", Active);
            comm.Parameters.AddWithValue("@InactiveDate", InactiveDate);
            comm.Parameters.AddWithValue("@adPaymentTypeID", adPaymentTypeID);
            comm.Parameters.AddWithValue("@VendorTypeID", VendorTypeID);
            comm.Parameters.AddWithValue("@TaxId", TaxId);
            comm.Parameters.AddWithValue("@VendorAddr1", VendorAddr1);
            comm.Parameters.AddWithValue("@VendorAddr2", VendorAddr2);
            comm.Parameters.AddWithValue("@District", District);
            comm.Parameters.AddWithValue("@Amphur", Amphur);
            comm.Parameters.AddWithValue("@adProvinceID", adProvinceID);
            comm.Parameters.AddWithValue("@PostCode", PostCode);
            comm.Parameters.AddWithValue("@ContAddr1", ContAddr1);
            comm.Parameters.AddWithValue("@ContAddr2", ContAddr2);
            comm.Parameters.AddWithValue("@ContDistrict", ContDistrict);
            comm.Parameters.AddWithValue("@ContAmphur", ContAmphur);
            comm.Parameters.AddWithValue("@ContProvince", ContProvince);
            comm.Parameters.AddWithValue("@ContPostCode", ContPostCode);
            comm.Parameters.AddWithValue("@ContHomePage", ContHomePage);
            comm.Parameters.AddWithValue("@ContTel", ContTel);
            comm.Parameters.AddWithValue("@ContFax", ContFax);
            comm.Parameters.AddWithValue("@CardNo", CardNo);
            comm.Parameters.AddWithValue("@VATGroupID", VATGroupID);
            comm.Parameters.AddWithValue("@imBranchID", imBranchID);
            comm.Parameters.AddWithValue("@Birthdate", Birthdate);
            comm.Parameters.AddWithValue("@ContTelExtend1", ContTelExtend1);
            comm.Parameters.AddWithValue("@ContTelExtend2", ContTelExtend2);
            comm.Parameters.AddWithValue("@BranchCode", BranchCode);
            comm.Parameters.AddWithValue("@BranchName", BranchName);
            comm.Parameters.AddWithValue("@CreditDays", CreditDays);
            comm.Parameters.AddWithValue("@CreditAmnt", CreditAmnt);
            comm.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            comm.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            comm.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
            comm.Parameters.AddWithValue("@UpdateDate", UpdateDate);
            comm.Parameters.AddWithValue("@SalesCode", SalesCode);

            comm.ExecuteNonQuery();
            conn.CloseConn();

        }

        [WebMethod]
        public void getShipmentList()
        {
            List<cShipment> datas = new List<cShipment>();
            SqlCommand comm = new SqlCommand("spGetShipmentList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cShipment data = new cShipment();
                data.ShipmentID = rdr["ShipmentID"].ToString();
                data.ShipmentCode = rdr["ShipmentCode"].ToString();
                data.ShipmentName = rdr["ShipmentName"].ToString();
                data.ShipmentNameEng = rdr["ShipmentNameEng"].ToString();
                data.Remark = rdr["Remark"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getShipmentById(string gid)
        {
            List<cShipment> datas = new List<cShipment>();
            SqlCommand comm = new SqlCommand("spGetShipmentById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cShipment data = new cShipment();
                data.ShipmentID = rdr["ShipmentID"].ToString();
                data.ShipmentCode = rdr["ShipmentCode"].ToString();
                data.ShipmentName = rdr["ShipmentName"].ToString();
                data.ShipmentNameEng = rdr["ShipmentNameEng"].ToString();
                data.Remark = rdr["Remark"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getShipmentUpdateEntry(string acttrans, string gid, string ShipmentID, string ShipmentCode, string ShipmentName, string ShipmentNameEng, string Remark)
        {
            SqlCommand comm = new SqlCommand("spGetShipmentUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@gid", gid);
            comm.Parameters.AddWithValue("@ShipmentID", ShipmentID);
            comm.Parameters.AddWithValue("@ShipmentCode", ShipmentCode);
            comm.Parameters.AddWithValue("@ShipmentName", ShipmentName);
            comm.Parameters.AddWithValue("@ShipmentNameEng", ShipmentNameEng);
            comm.Parameters.AddWithValue("@Remark", Remark);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void getWarehouseList() {
            List<cWarehouseList> datas = new List<cWarehouseList>();
            SqlCommand comm = new SqlCommand("spGetWarehouseList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cWarehouseList data = new cWarehouseList();
                data.WhID = rdr["WhID"].ToString();
                data.WhCode = rdr["WhCode"].ToString();
                data.WhDesc = rdr["WhDesc"].ToString();              
                data.Remark = rdr["Remark"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getWarehouseById(string gid) {
            List<cWarehouseList> datas = new List<cWarehouseList>();
            SqlCommand comm = new SqlCommand("spGetWarehouseById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cWarehouseList data = new cWarehouseList();
                data.WhID = rdr["WhID"].ToString();
                data.WhCode = rdr["WhCode"].ToString();
                data.WhDesc = rdr["WhDesc"].ToString();
                data.Remark = rdr["Remark"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getWarehouseUpdateEntry(string acttrans, string gid, string WhID, string WhCode, string WhDesc, string Remark)
        {
            SqlCommand comm = new SqlCommand("spGetWarehouseUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@gid", gid);
            comm.Parameters.AddWithValue("@WhID", WhID);
            comm.Parameters.AddWithValue("@WhCode", WhCode);
            comm.Parameters.AddWithValue("@WhDesc", WhDesc);
            comm.Parameters.AddWithValue("@Remark", Remark);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }

        [WebMethod]
        public void getWarehouseZoneList()
        {
            List<cWarehouseZoneList> datas = new List<cWarehouseZoneList>();
            SqlCommand comm = new SqlCommand("spGetWarehouseZoneList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cWarehouseZoneList data = new cWarehouseZoneList();
                data.WhZoneID = rdr["WhZoneID"].ToString();
                data.WhID = rdr["WhID"].ToString();
                data.WhDesc = rdr["WhDesc"].ToString();
                data.WhZoneCode = rdr["WhZoneCode"].ToString();
                data.WhZoneDesc = rdr["WhZoneDesc"].ToString();
                data.Remark = rdr["Remark"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }
        
        [WebMethod]
        public void getWarehouseZoneById(string gid)
        {
            List<cWarehouseZoneList> datas = new List<cWarehouseZoneList>();
            SqlCommand comm = new SqlCommand("spGetWarehouseZoneById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cWarehouseZoneList data = new cWarehouseZoneList();
                data.WhZoneID = rdr["WhZoneID"].ToString();
                data.WhID = rdr["WhID"].ToString();
                data.WhZoneCode = rdr["WhZoneCode"].ToString();
                data.WhZoneDesc = rdr["WhZoneDesc"].ToString();
                data.Remark = rdr["Remark"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getWarehouseZoneUpdateEntry(string acttrans, string gid, string WhZoneID, string WhID, string WhZoneCode, string WhZoneDesc, string Remark)
        {
            SqlCommand comm = new SqlCommand("spGetWarehouseZoneUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@gid", gid);
            comm.Parameters.AddWithValue("@WhZoneID", WhZoneID);
            comm.Parameters.AddWithValue("@WhID", WhID);
            comm.Parameters.AddWithValue("@WhZoneCode", WhZoneCode);
            comm.Parameters.AddWithValue("@WhZoneDesc", WhZoneDesc);
            comm.Parameters.AddWithValue("@Remark", Remark);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }
        
        [WebMethod]
        public void getGoodGroupList()
        {
            List<cGoodGroupList> datas = new List<cGoodGroupList>();
            SqlCommand comm = new SqlCommand("spGetGoodGroupList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cGoodGroupList data = new cGoodGroupList();
                data.GoodGroupID = rdr["GoodGroupID"].ToString();
                data.GoodGroupCode = rdr["GoodGroupCode"].ToString();
                data.GoodGroupDesc = rdr["GoodGroupDesc"].ToString();
                data.Remark = rdr["Remark"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getGoodGroupById(string gid)
        {
            List<cGoodGroupList> datas = new List<cGoodGroupList>();
            SqlCommand comm = new SqlCommand("spGetGoodGroupById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cGoodGroupList data = new cGoodGroupList();
                data.GoodGroupID = rdr["GoodGroupID"].ToString();
                data.GoodGroupCode = rdr["GoodGroupCode"].ToString();
                data.GoodGroupDesc = rdr["GoodGroupDesc"].ToString();
                data.Remark = rdr["Remark"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getGoodGroupUpdateEntry(string acttrans, string gid, string GoodGroupID, string GoodGroupCode, string GoodGroupDesc, string Remark)
        {
            SqlCommand comm = new SqlCommand("spGetGoodGroupUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@gid", gid);
            comm.Parameters.AddWithValue("@GoodGroupID", GoodGroupID);
            comm.Parameters.AddWithValue("@GoodGroupCode", GoodGroupCode);
            comm.Parameters.AddWithValue("@GoodGroupDesc", GoodGroupDesc);
            comm.Parameters.AddWithValue("@Remark", Remark);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }
        
        [WebMethod]
        public void getGoodTypeList()
        {
            List<cGoodTypeList> datas = new List<cGoodTypeList>();
            SqlCommand comm = new SqlCommand("spGetGoodTypeList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cGoodTypeList data = new cGoodTypeList();
                data.GoodTypeID = rdr["GoodTypeID"].ToString();
                data.GoodGroupID = rdr["GoodGroupID"].ToString();
                data.GoodGroupDesc = rdr["GoodGroupDesc"].ToString();
                data.GoodTypeCode = rdr["GoodTypeCode"].ToString();
                data.GoodTypeDesc = rdr["GoodTypeDesc"].ToString();
                data.Remark = rdr["Remark"].ToString();
                data.edit = rdr["edit"].ToString();
                data.trash = rdr["trash"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getGoodTypeById(string gid)
        {
            List<cGoodTypeList> datas = new List<cGoodTypeList>();
            SqlCommand comm = new SqlCommand("spGetGoodTypeById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@gid", gid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cGoodTypeList data = new cGoodTypeList();
                data.GoodTypeID = rdr["GoodTypeID"].ToString();
                data.GoodGroupID = rdr["GoodGroupID"].ToString();
                data.GoodGroupDesc = rdr["GoodGroupDesc"].ToString();
                data.GoodTypeCode = rdr["GoodTypeCode"].ToString();
                data.GoodTypeDesc = rdr["GoodTypeDesc"].ToString();
                data.Remark = rdr["Remark"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

        [WebMethod]
        public void getGoodTypeUpdateEntry(string acttrans, string gid, string GoodTypeID, string GoodGroupID, string GoodTypeCode, string GoodTypeDesc, string Remark)
        {
            SqlCommand comm = new SqlCommand("spGetGoodTypeUpdateEntry", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@acttrans", acttrans);
            comm.Parameters.AddWithValue("@gid", gid);
            comm.Parameters.AddWithValue("@GoodTypeID", GoodTypeID);
            comm.Parameters.AddWithValue("@GoodGroupID", GoodGroupID);
            comm.Parameters.AddWithValue("@GoodTypeCode", GoodTypeCode);
            comm.Parameters.AddWithValue("@GoodTypeDesc", GoodTypeDesc);
            comm.Parameters.AddWithValue("@Remark", Remark);
            comm.ExecuteNonQuery();
            conn.CloseConn();
        }


    }
}
