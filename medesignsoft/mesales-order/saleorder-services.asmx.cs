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

namespace medesignsoft.mesales_order
{
    /// <summary>
    /// Summary description for saleorder_services
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class saleorder_services : System.Web.Services.WebService
    {
        dbConnection conn = new dbConnection();

        [WebMethod]
        public void getQuotationList(string empid)
        {
            List<cQuotationList> datas = new List<cQuotationList>();
            SqlCommand comm = new SqlCommand("spGetQuotationList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@empid", empid);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cQuotationList data = new cQuotationList();
                data.QtGid = rdr["QtGid"].ToString();
                data.imBranchGid = rdr["imBranchGid"].ToString();
                data.BranchName = rdr["BranchName"].ToString();
                data.adQTNO = rdr["adQTNO"].ToString();
                data.RefQTNO = rdr["RefQTNO"].ToString();
                data.ProjectName = rdr["ProjectName"].ToString();
                data.ProjectID = rdr["ProjectID"].ToString();
                data.ProjectDesc = rdr["ProjectDesc"].ToString();
                data.DocuDate = rdr["DocuDate"].ToString();
                data.DeliveryDate = rdr["DeliveryDate"].ToString();
                data.InYear = rdr["InYear"].ToString();
                data.VendorID = rdr["VendorID"].ToString();
                data.VendorName = rdr["VendorName"].ToString();
                data.ContactName = rdr["ContactName"].ToString();
                data.ContactTel = rdr["ContactTel"].ToString();
                data.CurrencyRate = rdr["CurrencyRate"].ToString();
                data.adCurrencyID = rdr["adCurrencyID"].ToString();
                data.CurrencyDesc = rdr["CurrencyDesc"].ToString();
                data.TotalAmount = rdr["TotalAmount"].ToString();
                data.VATAmount = rdr["VATAmount"].ToString();
                data.TotalAmountExcludeVAT = rdr["TotalAmountExcludeVAT"].ToString();
                data.DiscPercent = rdr["DiscPercent"].ToString();
                data.DiscAmount = rdr["DiscAmount"].ToString();
                data.DiscExtendPercent = rdr["DiscExtendPercent"].ToString();
                data.DiscExtendAmount = rdr["DiscExtendAmount"].ToString();
                data.AmountExtraDisc = rdr["AmountExtraDisc"].ToString();
                data.TotalAmountAfterDisc = rdr["TotalAmountAfterDisc"].ToString();
                data.QTRemark = rdr["QTRemark"].ToString();
                data.QTComment = rdr["QTComment"].ToString();
                data.imDeliveryID = rdr["imDeliveryID"].ToString();
                data.DeliveryName = rdr["DeliveryName"].ToString();
                data.adPaymentTypeID = rdr["adPaymentTypeID"].ToString();
                data.PaymentTypeDesc = rdr["PaymentTypeDesc"].ToString();
                data.imEmployeeGid = rdr["imEmployeeGid"].ToString();
                data.empFullName = rdr["empFullName"].ToString();
                data.SalePositionName = rdr["SalePositionName"].ToString();
                data.ApproveID = rdr["ApproveID"].ToString();
                data.ApproveName = rdr["ApproveName"].ToString();
                data.ApprovePositionID = rdr["ApprovePositionID"].ToString();
                data.ApprovePositionName = rdr["ApprovePositionName"].ToString();
                data.IsDelete = rdr["IsDelete"].ToString();
                data.FlagID = rdr["FlagID"].ToString();
                data.FlagDesc = rdr["FlagDesc"].ToString();
                data.CreatedBy = rdr["CreatedBy"].ToString();
                data.CreateName = rdr["CreateName"].ToString();
                data.CreateDate = rdr["CreateDate"].ToString();
                data.UpdatedBy = rdr["UpdatedBy"].ToString();
                data.UpdateDate = rdr["UpdateDate"].ToString();
                data.SaleEMail = rdr["SaleEMail"].ToString();
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
    }
}
