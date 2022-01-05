using System;
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

    }
}
