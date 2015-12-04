using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// Provides method to hold values of the Dash board items
    /// </summary>
    public class DashboardAdmin:ZNodeBusinessBase 
    {

        public int TotalProducts;
        public int TotalCategories;
        public int TotalInventory;
        public int TotalOutOfStock;

        public decimal YTDRevenue;        
        public int TotalNewOrders;
        public int TotalPaymentPendingOrders;
        public int TotalSubmittedOrders;
        public int TotalShippedOrders;

        public int TotalAccounts;
        public int TotalPages;
        public int TotalShippingOptions;
        public string PaymentGateway;

        public string StatusMessage;

        /// <summary>
        /// Gets dashboard items
        /// </summary>
        /// <returns></returns>
        public void GetDashboardItems()
        {
            DashboardHelper dash = new DashboardHelper();
            DataSet ds = dash.GetDashboardItemsByPortal(ZNodeConfigManager.SiteConfig.PortalID);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TotalProducts = (int)dr["TotalProducts"];
                TotalCategories = (int)dr["TotalCategories"];
                TotalInventory = (int)dr["TotalInventory"];
                TotalOutOfStock = (int)dr["TotalOutOfStock"];

                YTDRevenue = (decimal)dr["YTDRevenue"];
                TotalNewOrders = (int)dr["TotalNewOrders"];
                TotalPaymentPendingOrders = (int)dr["TotalPaymentPendingOrders"];
                TotalSubmittedOrders = (int)dr["TotalSubmittedOrders"];
                TotalShippedOrders = (int)dr["TotalShippedOrders"];
                TotalAccounts = (int)dr["TotalAccounts"];

                TotalPages = (int)dr["TotalPages"];
                TotalShippingOptions = (int)dr["TotalShippingOptions"];
                PaymentGateway = (string)dr["PaymentGateway"];
            }
            
            //get license status
            ZNode.Libraries.Framework.Business.ZNodeLicenseManager lm = new ZNodeLicenseManager();
            lm.Validate();

            StatusMessage = lm.GetStatusDescription();
            
        }
    }
}
