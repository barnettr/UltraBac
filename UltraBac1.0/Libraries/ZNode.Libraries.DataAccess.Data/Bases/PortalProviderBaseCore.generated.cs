#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Data;

#endregion

namespace ZNode.Libraries.DataAccess.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="PortalProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PortalProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Portal, ZNode.Libraries.DataAccess.Entities.PortalKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.PortalKey key)
		{
			return Delete(transactionManager, key.PortalID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="portalID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 portalID)
		{
			return Delete(null, portalID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 portalID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override ZNode.Libraries.DataAccess.Entities.Portal Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.PortalKey key, int start, int pageLength)
		{
			return GetByPortalID(transactionManager, key.PortalID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Portals index.
		/// </summary>
		/// <param name="portalID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Portal"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Portal GetByPortalID(System.Int32 portalID)
		{
			int count = -1;
			return GetByPortalID(null,portalID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Portals index.
		/// </summary>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Portal"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Portal GetByPortalID(System.Int32 portalID, int start, int pageLength)
		{
			int count = -1;
			return GetByPortalID(null, portalID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Portals index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Portal"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Portal GetByPortalID(TransactionManager transactionManager, System.Int32 portalID)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Portals index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Portal"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Portal GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Portals index.
		/// </summary>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Portal"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Portal GetByPortalID(System.Int32 portalID, int start, int pageLength, out int count)
		{
			return GetByPortalID(null, portalID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Portals index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Portal"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Portal GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX1 index.
		/// </summary>
		/// <param name="activeInd"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Portal&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Portal> GetByActiveInd(System.Boolean activeInd)
		{
			int count = -1;
			return GetByActiveInd(null,activeInd, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="activeInd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Portal&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Portal> GetByActiveInd(System.Boolean activeInd, int start, int pageLength)
		{
			int count = -1;
			return GetByActiveInd(null, activeInd, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="activeInd"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Portal&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Portal> GetByActiveInd(TransactionManager transactionManager, System.Boolean activeInd)
		{
			int count = -1;
			return GetByActiveInd(transactionManager, activeInd, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="activeInd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Portal&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Portal> GetByActiveInd(TransactionManager transactionManager, System.Boolean activeInd, int start, int pageLength)
		{
			int count = -1;
			return GetByActiveInd(transactionManager, activeInd, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="activeInd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Portal&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Portal> GetByActiveInd(System.Boolean activeInd, int start, int pageLength, out int count)
		{
			return GetByActiveInd(null, activeInd, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="activeInd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Portal&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Portal> GetByActiveInd(TransactionManager transactionManager, System.Boolean activeInd, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Portal&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Portal&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Portal> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Portal> rows, int start, int pageLength)
		{
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
					return rows; // not enough rows, just return
			}

			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done

				string key = null;
				
				ZNode.Libraries.DataAccess.Entities.Portal c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Portal" 
							+ (reader.IsDBNull(reader.GetOrdinal("PortalID"))?(int)0:(System.Int32)reader["PortalID"]).ToString();

					c = EntityManager.LocateOrCreate<Portal>(
						key.ToString(), // EntityTrackingKey 
						"Portal",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Portal();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.PortalID = (System.Int32)reader["PortalID"];
					c.DomainName = (System.String)reader["DomainName"];
					c.CompanyName = (System.String)reader["CompanyName"];
					c.StoreName = (System.String)reader["StoreName"];
					c.LogoPath = (reader.IsDBNull(reader.GetOrdinal("LogoPath")))?null:(System.String)reader["LogoPath"];
					c.UseSSL = (System.Boolean)reader["UseSSL"];
					c.AdminEmail = (reader.IsDBNull(reader.GetOrdinal("AdminEmail")))?null:(System.String)reader["AdminEmail"];
					c.SalesEmail = (reader.IsDBNull(reader.GetOrdinal("SalesEmail")))?null:(System.String)reader["SalesEmail"];
					c.CustomerServiceEmail = (reader.IsDBNull(reader.GetOrdinal("CustomerServiceEmail")))?null:(System.String)reader["CustomerServiceEmail"];
					c.SalesPhoneNumber = (reader.IsDBNull(reader.GetOrdinal("SalesPhoneNumber")))?null:(System.String)reader["SalesPhoneNumber"];
					c.CustomerServicePhoneNumber = (reader.IsDBNull(reader.GetOrdinal("CustomerServicePhoneNumber")))?null:(System.String)reader["CustomerServicePhoneNumber"];
					c.ImageNotAvailablePath = (System.String)reader["ImageNotAvailablePath"];
					c.MaxCatalogDisplayColumns = (System.Byte)reader["MaxCatalogDisplayColumns"];
					c.MaxCatalogDisplayItems = (System.Int32)reader["MaxCatalogDisplayItems"];
					c.MaxCatalogItemSmallWidth = (System.Int32)reader["MaxCatalogItemSmallWidth"];
					c.MaxCatalogItemMediumWidth = (System.Int32)reader["MaxCatalogItemMediumWidth"];
					c.MaxCatalogItemThumbnailWidth = (System.Int32)reader["MaxCatalogItemThumbnailWidth"];
					c.MaxCatalogItemLargeWidth = (System.Int32)reader["MaxCatalogItemLargeWidth"];
					c.ActiveInd = (System.Boolean)reader["ActiveInd"];
					c.SMTPServer = (reader.IsDBNull(reader.GetOrdinal("SMTPServer")))?null:(System.String)reader["SMTPServer"];
					c.SMTPUserName = (reader.IsDBNull(reader.GetOrdinal("SMTPUserName")))?null:(System.String)reader["SMTPUserName"];
					c.SMTPPassword = (reader.IsDBNull(reader.GetOrdinal("SMTPPassword")))?null:(System.String)reader["SMTPPassword"];
					c.BottomScriptBlock = (reader.IsDBNull(reader.GetOrdinal("BottomScriptBlock")))?null:(System.String)reader["BottomScriptBlock"];
					c.UPSUserName = (reader.IsDBNull(reader.GetOrdinal("UPSUserName")))?null:(System.String)reader["UPSUserName"];
					c.UPSPassword = (reader.IsDBNull(reader.GetOrdinal("UPSPassword")))?null:(System.String)reader["UPSPassword"];
					c.UPSKey = (reader.IsDBNull(reader.GetOrdinal("UPSKey")))?null:(System.String)reader["UPSKey"];
					c.ShippingOriginZipCode = (reader.IsDBNull(reader.GetOrdinal("ShippingOriginZipCode")))?null:(System.String)reader["ShippingOriginZipCode"];
					c.Theme = (System.String)reader["Theme"];
					c.ShopByPriceMin = (System.Int32)reader["ShopByPriceMin"];
					c.ShopByPriceMax = (System.Int32)reader["ShopByPriceMax"];
					c.ShopByPriceIncrement = (System.Int32)reader["ShopByPriceIncrement"];
					c.FedExAccountNumber = (reader.IsDBNull(reader.GetOrdinal("FedExAccountNumber")))?null:(System.String)reader["FedExAccountNumber"];
					c.FedExMeterNumber = (reader.IsDBNull(reader.GetOrdinal("FedExMeterNumber")))?null:(System.String)reader["FedExMeterNumber"];
					c.FedExProductionKey = (reader.IsDBNull(reader.GetOrdinal("FedExProductionKey")))?null:(System.String)reader["FedExProductionKey"];
					c.FedExSecurityCode = (reader.IsDBNull(reader.GetOrdinal("FedExSecurityCode")))?null:(System.String)reader["FedExSecurityCode"];
					c.ShippingOriginStateCode = (reader.IsDBNull(reader.GetOrdinal("ShippingOriginStateCode")))?null:(System.String)reader["ShippingOriginStateCode"];
					c.ShippingOriginCountryCode = (reader.IsDBNull(reader.GetOrdinal("ShippingOriginCountryCode")))?null:(System.String)reader["ShippingOriginCountryCode"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Portal"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Portal"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Portal entity)
		{
			if (!reader.Read()) return;
			
			entity.PortalID = (System.Int32)reader["PortalID"];
			entity.DomainName = (System.String)reader["DomainName"];
			entity.CompanyName = (System.String)reader["CompanyName"];
			entity.StoreName = (System.String)reader["StoreName"];
			entity.LogoPath = (reader.IsDBNull(reader.GetOrdinal("LogoPath")))?null:(System.String)reader["LogoPath"];
			entity.UseSSL = (System.Boolean)reader["UseSSL"];
			entity.AdminEmail = (reader.IsDBNull(reader.GetOrdinal("AdminEmail")))?null:(System.String)reader["AdminEmail"];
			entity.SalesEmail = (reader.IsDBNull(reader.GetOrdinal("SalesEmail")))?null:(System.String)reader["SalesEmail"];
			entity.CustomerServiceEmail = (reader.IsDBNull(reader.GetOrdinal("CustomerServiceEmail")))?null:(System.String)reader["CustomerServiceEmail"];
			entity.SalesPhoneNumber = (reader.IsDBNull(reader.GetOrdinal("SalesPhoneNumber")))?null:(System.String)reader["SalesPhoneNumber"];
			entity.CustomerServicePhoneNumber = (reader.IsDBNull(reader.GetOrdinal("CustomerServicePhoneNumber")))?null:(System.String)reader["CustomerServicePhoneNumber"];
			entity.ImageNotAvailablePath = (System.String)reader["ImageNotAvailablePath"];
			entity.MaxCatalogDisplayColumns = (System.Byte)reader["MaxCatalogDisplayColumns"];
			entity.MaxCatalogDisplayItems = (System.Int32)reader["MaxCatalogDisplayItems"];
			entity.MaxCatalogItemSmallWidth = (System.Int32)reader["MaxCatalogItemSmallWidth"];
			entity.MaxCatalogItemMediumWidth = (System.Int32)reader["MaxCatalogItemMediumWidth"];
			entity.MaxCatalogItemThumbnailWidth = (System.Int32)reader["MaxCatalogItemThumbnailWidth"];
			entity.MaxCatalogItemLargeWidth = (System.Int32)reader["MaxCatalogItemLargeWidth"];
			entity.ActiveInd = (System.Boolean)reader["ActiveInd"];
			entity.SMTPServer = (reader.IsDBNull(reader.GetOrdinal("SMTPServer")))?null:(System.String)reader["SMTPServer"];
			entity.SMTPUserName = (reader.IsDBNull(reader.GetOrdinal("SMTPUserName")))?null:(System.String)reader["SMTPUserName"];
			entity.SMTPPassword = (reader.IsDBNull(reader.GetOrdinal("SMTPPassword")))?null:(System.String)reader["SMTPPassword"];
			entity.BottomScriptBlock = (reader.IsDBNull(reader.GetOrdinal("BottomScriptBlock")))?null:(System.String)reader["BottomScriptBlock"];
			entity.UPSUserName = (reader.IsDBNull(reader.GetOrdinal("UPSUserName")))?null:(System.String)reader["UPSUserName"];
			entity.UPSPassword = (reader.IsDBNull(reader.GetOrdinal("UPSPassword")))?null:(System.String)reader["UPSPassword"];
			entity.UPSKey = (reader.IsDBNull(reader.GetOrdinal("UPSKey")))?null:(System.String)reader["UPSKey"];
			entity.ShippingOriginZipCode = (reader.IsDBNull(reader.GetOrdinal("ShippingOriginZipCode")))?null:(System.String)reader["ShippingOriginZipCode"];
			entity.Theme = (System.String)reader["Theme"];
			entity.ShopByPriceMin = (System.Int32)reader["ShopByPriceMin"];
			entity.ShopByPriceMax = (System.Int32)reader["ShopByPriceMax"];
			entity.ShopByPriceIncrement = (System.Int32)reader["ShopByPriceIncrement"];
			entity.FedExAccountNumber = (reader.IsDBNull(reader.GetOrdinal("FedExAccountNumber")))?null:(System.String)reader["FedExAccountNumber"];
			entity.FedExMeterNumber = (reader.IsDBNull(reader.GetOrdinal("FedExMeterNumber")))?null:(System.String)reader["FedExMeterNumber"];
			entity.FedExProductionKey = (reader.IsDBNull(reader.GetOrdinal("FedExProductionKey")))?null:(System.String)reader["FedExProductionKey"];
			entity.FedExSecurityCode = (reader.IsDBNull(reader.GetOrdinal("FedExSecurityCode")))?null:(System.String)reader["FedExSecurityCode"];
			entity.ShippingOriginStateCode = (reader.IsDBNull(reader.GetOrdinal("ShippingOriginStateCode")))?null:(System.String)reader["ShippingOriginStateCode"];
			entity.ShippingOriginCountryCode = (reader.IsDBNull(reader.GetOrdinal("ShippingOriginCountryCode")))?null:(System.String)reader["ShippingOriginCountryCode"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Portal"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Portal"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Portal entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.PortalID = (System.Int32)dataRow["PortalID"];
			entity.DomainName = (System.String)dataRow["DomainName"];
			entity.CompanyName = (System.String)dataRow["CompanyName"];
			entity.StoreName = (System.String)dataRow["StoreName"];
			entity.LogoPath = (Convert.IsDBNull(dataRow["LogoPath"]))?null:(System.String)dataRow["LogoPath"];
			entity.UseSSL = (System.Boolean)dataRow["UseSSL"];
			entity.AdminEmail = (Convert.IsDBNull(dataRow["AdminEmail"]))?null:(System.String)dataRow["AdminEmail"];
			entity.SalesEmail = (Convert.IsDBNull(dataRow["SalesEmail"]))?null:(System.String)dataRow["SalesEmail"];
			entity.CustomerServiceEmail = (Convert.IsDBNull(dataRow["CustomerServiceEmail"]))?null:(System.String)dataRow["CustomerServiceEmail"];
			entity.SalesPhoneNumber = (Convert.IsDBNull(dataRow["SalesPhoneNumber"]))?null:(System.String)dataRow["SalesPhoneNumber"];
			entity.CustomerServicePhoneNumber = (Convert.IsDBNull(dataRow["CustomerServicePhoneNumber"]))?null:(System.String)dataRow["CustomerServicePhoneNumber"];
			entity.ImageNotAvailablePath = (System.String)dataRow["ImageNotAvailablePath"];
			entity.MaxCatalogDisplayColumns = (System.Byte)dataRow["MaxCatalogDisplayColumns"];
			entity.MaxCatalogDisplayItems = (System.Int32)dataRow["MaxCatalogDisplayItems"];
			entity.MaxCatalogItemSmallWidth = (System.Int32)dataRow["MaxCatalogItemSmallWidth"];
			entity.MaxCatalogItemMediumWidth = (System.Int32)dataRow["MaxCatalogItemMediumWidth"];
			entity.MaxCatalogItemThumbnailWidth = (System.Int32)dataRow["MaxCatalogItemThumbnailWidth"];
			entity.MaxCatalogItemLargeWidth = (System.Int32)dataRow["MaxCatalogItemLargeWidth"];
			entity.ActiveInd = (System.Boolean)dataRow["ActiveInd"];
			entity.SMTPServer = (Convert.IsDBNull(dataRow["SMTPServer"]))?null:(System.String)dataRow["SMTPServer"];
			entity.SMTPUserName = (Convert.IsDBNull(dataRow["SMTPUserName"]))?null:(System.String)dataRow["SMTPUserName"];
			entity.SMTPPassword = (Convert.IsDBNull(dataRow["SMTPPassword"]))?null:(System.String)dataRow["SMTPPassword"];
			entity.BottomScriptBlock = (Convert.IsDBNull(dataRow["BottomScriptBlock"]))?null:(System.String)dataRow["BottomScriptBlock"];
			entity.UPSUserName = (Convert.IsDBNull(dataRow["UPSUserName"]))?null:(System.String)dataRow["UPSUserName"];
			entity.UPSPassword = (Convert.IsDBNull(dataRow["UPSPassword"]))?null:(System.String)dataRow["UPSPassword"];
			entity.UPSKey = (Convert.IsDBNull(dataRow["UPSKey"]))?null:(System.String)dataRow["UPSKey"];
			entity.ShippingOriginZipCode = (Convert.IsDBNull(dataRow["ShippingOriginZipCode"]))?null:(System.String)dataRow["ShippingOriginZipCode"];
			entity.Theme = (System.String)dataRow["Theme"];
			entity.ShopByPriceMin = (System.Int32)dataRow["ShopByPriceMin"];
			entity.ShopByPriceMax = (System.Int32)dataRow["ShopByPriceMax"];
			entity.ShopByPriceIncrement = (System.Int32)dataRow["ShopByPriceIncrement"];
			entity.FedExAccountNumber = (Convert.IsDBNull(dataRow["FedExAccountNumber"]))?null:(System.String)dataRow["FedExAccountNumber"];
			entity.FedExMeterNumber = (Convert.IsDBNull(dataRow["FedExMeterNumber"]))?null:(System.String)dataRow["FedExMeterNumber"];
			entity.FedExProductionKey = (Convert.IsDBNull(dataRow["FedExProductionKey"]))?null:(System.String)dataRow["FedExProductionKey"];
			entity.FedExSecurityCode = (Convert.IsDBNull(dataRow["FedExSecurityCode"]))?null:(System.String)dataRow["FedExSecurityCode"];
			entity.ShippingOriginStateCode = (Convert.IsDBNull(dataRow["ShippingOriginStateCode"]))?null:(System.String)dataRow["ShippingOriginStateCode"];
			entity.ShippingOriginCountryCode = (Convert.IsDBNull(dataRow["ShippingOriginCountryCode"]))?null:(System.String)dataRow["ShippingOriginCountryCode"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Portal"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Portal Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Portal entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByPortalID methods when available
			
			#region TaxRuleCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<TaxRule>", "TaxRuleCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'TaxRuleCollection' loaded.");
				#endif 

				entity.TaxRuleCollection = DataRepository.TaxRuleProvider.GetByPortalID(transactionManager, entity.PortalID);

				if (deep && entity.TaxRuleCollection.Count > 0)
				{
					DataRepository.TaxRuleProvider.DeepLoad(transactionManager, entity.TaxRuleCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region AccountCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Account>", "AccountCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'AccountCollection' loaded.");
				#endif 

				entity.AccountCollection = DataRepository.AccountProvider.GetByPortalID(transactionManager, entity.PortalID);

				if (deep && entity.AccountCollection.Count > 0)
				{
					DataRepository.AccountProvider.DeepLoad(transactionManager, entity.AccountCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region CaseCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Case>", "CaseCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'CaseCollection' loaded.");
				#endif 

				entity.CaseCollection = DataRepository.CaseProvider.GetByPortalID(transactionManager, entity.PortalID);

				if (deep && entity.CaseCollection.Count > 0)
				{
					DataRepository.CaseProvider.DeepLoad(transactionManager, entity.CaseCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region CategoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Category>", "CategoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'CategoryCollection' loaded.");
				#endif 

				entity.CategoryCollection = DataRepository.CategoryProvider.GetByPortalID(transactionManager, entity.PortalID);

				if (deep && entity.CategoryCollection.Count > 0)
				{
					DataRepository.CategoryProvider.DeepLoad(transactionManager, entity.CategoryCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region OrderCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Order>", "OrderCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'OrderCollection' loaded.");
				#endif 

				entity.OrderCollection = DataRepository.OrderProvider.GetByPortalId(transactionManager, entity.PortalID);

				if (deep && entity.OrderCollection.Count > 0)
				{
					DataRepository.OrderProvider.DeepLoad(transactionManager, entity.OrderCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ProfileCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Profile>", "ProfileCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProfileCollection' loaded.");
				#endif 

				entity.ProfileCollection = DataRepository.ProfileProvider.GetByPortalID(transactionManager, entity.PortalID);

				if (deep && entity.ProfileCollection.Count > 0)
				{
					DataRepository.ProfileProvider.DeepLoad(transactionManager, entity.ProfileCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ContentPageCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ContentPage>", "ContentPageCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ContentPageCollection' loaded.");
				#endif 

				entity.ContentPageCollection = DataRepository.ContentPageProvider.GetByPortalID(transactionManager, entity.PortalID);

				if (deep && entity.ContentPageCollection.Count > 0)
				{
					DataRepository.ContentPageProvider.DeepLoad(transactionManager, entity.ContentPageCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ProductTypeCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductType>", "ProductTypeCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProductTypeCollection' loaded.");
				#endif 

				entity.ProductTypeCollection = DataRepository.ProductTypeProvider.GetByPortalId(transactionManager, entity.PortalID);

				if (deep && entity.ProductTypeCollection.Count > 0)
				{
					DataRepository.ProductTypeProvider.DeepLoad(transactionManager, entity.ProductTypeCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ManufacturerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Manufacturer>", "ManufacturerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ManufacturerCollection' loaded.");
				#endif 

				entity.ManufacturerCollection = DataRepository.ManufacturerProvider.GetByPortalID(transactionManager, entity.PortalID);

				if (deep && entity.ManufacturerCollection.Count > 0)
				{
					DataRepository.ManufacturerProvider.DeepLoad(transactionManager, entity.ManufacturerCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ProductCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Product>", "ProductCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProductCollection' loaded.");
				#endif 

				entity.ProductCollection = DataRepository.ProductProvider.GetByPortalID(transactionManager, entity.PortalID);

				if (deep && entity.ProductCollection.Count > 0)
				{
					DataRepository.ProductProvider.DeepLoad(transactionManager, entity.ProductCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Portal object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Portal instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Portal Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Portal entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			





















			#region List<TaxRule>
				if (CanDeepSave(entity, "List<TaxRule>", "TaxRuleCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(TaxRule child in entity.TaxRuleCollection)
					{
						child.PortalID = entity.PortalID;
					}
				
				if (entity.TaxRuleCollection.Count > 0 || entity.TaxRuleCollection.DeletedItems.Count > 0)
					DataRepository.TaxRuleProvider.DeepSave(transactionManager, entity.TaxRuleCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Account>
				if (CanDeepSave(entity, "List<Account>", "AccountCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Account child in entity.AccountCollection)
					{
						child.PortalID = entity.PortalID;
					}
				
				if (entity.AccountCollection.Count > 0 || entity.AccountCollection.DeletedItems.Count > 0)
					DataRepository.AccountProvider.DeepSave(transactionManager, entity.AccountCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Case>
				if (CanDeepSave(entity, "List<Case>", "CaseCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Case child in entity.CaseCollection)
					{
						child.PortalID = entity.PortalID;
					}
				
				if (entity.CaseCollection.Count > 0 || entity.CaseCollection.DeletedItems.Count > 0)
					DataRepository.CaseProvider.DeepSave(transactionManager, entity.CaseCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Category>
				if (CanDeepSave(entity, "List<Category>", "CategoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Category child in entity.CategoryCollection)
					{
						child.PortalID = entity.PortalID;
					}
				
				if (entity.CategoryCollection.Count > 0 || entity.CategoryCollection.DeletedItems.Count > 0)
					DataRepository.CategoryProvider.DeepSave(transactionManager, entity.CategoryCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Order>
				if (CanDeepSave(entity, "List<Order>", "OrderCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Order child in entity.OrderCollection)
					{
						child.PortalId = entity.PortalID;
					}
				
				if (entity.OrderCollection.Count > 0 || entity.OrderCollection.DeletedItems.Count > 0)
					DataRepository.OrderProvider.DeepSave(transactionManager, entity.OrderCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Profile>
				if (CanDeepSave(entity, "List<Profile>", "ProfileCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Profile child in entity.ProfileCollection)
					{
						child.PortalID = entity.PortalID;
					}
				
				if (entity.ProfileCollection.Count > 0 || entity.ProfileCollection.DeletedItems.Count > 0)
					DataRepository.ProfileProvider.DeepSave(transactionManager, entity.ProfileCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<ContentPage>
				if (CanDeepSave(entity, "List<ContentPage>", "ContentPageCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ContentPage child in entity.ContentPageCollection)
					{
						child.PortalID = entity.PortalID;
					}
				
				if (entity.ContentPageCollection.Count > 0 || entity.ContentPageCollection.DeletedItems.Count > 0)
					DataRepository.ContentPageProvider.DeepSave(transactionManager, entity.ContentPageCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<ProductType>
				if (CanDeepSave(entity, "List<ProductType>", "ProductTypeCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductType child in entity.ProductTypeCollection)
					{
						child.PortalId = entity.PortalID;
					}
				
				if (entity.ProductTypeCollection.Count > 0 || entity.ProductTypeCollection.DeletedItems.Count > 0)
					DataRepository.ProductTypeProvider.DeepSave(transactionManager, entity.ProductTypeCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Manufacturer>
				if (CanDeepSave(entity, "List<Manufacturer>", "ManufacturerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Manufacturer child in entity.ManufacturerCollection)
					{
						child.PortalID = entity.PortalID;
					}
				
				if (entity.ManufacturerCollection.Count > 0 || entity.ManufacturerCollection.DeletedItems.Count > 0)
					DataRepository.ManufacturerProvider.DeepSave(transactionManager, entity.ManufacturerCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Product>
				if (CanDeepSave(entity, "List<Product>", "ProductCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Product child in entity.ProductCollection)
					{
						child.PortalID = entity.PortalID;
					}
				
				if (entity.ProductCollection.Count > 0 || entity.ProductCollection.DeletedItems.Count > 0)
					DataRepository.ProductProvider.DeepSave(transactionManager, entity.ProductCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				










						
			return true;
		}
		#endregion
	} // end class
	
	#region PortalChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Portal</c>
	///</summary>
	public enum PortalChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Portal</c> as OneToMany for TaxRuleCollection
		///</summary>
		[ChildEntityType(typeof(TList<TaxRule>))]
		TaxRuleCollection,

		///<summary>
		/// Collection of <c>Portal</c> as OneToMany for AccountCollection
		///</summary>
		[ChildEntityType(typeof(TList<Account>))]
		AccountCollection,

		///<summary>
		/// Collection of <c>Portal</c> as OneToMany for CaseCollection
		///</summary>
		[ChildEntityType(typeof(TList<Case>))]
		CaseCollection,

		///<summary>
		/// Collection of <c>Portal</c> as OneToMany for CategoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<Category>))]
		CategoryCollection,

		///<summary>
		/// Collection of <c>Portal</c> as OneToMany for OrderCollection
		///</summary>
		[ChildEntityType(typeof(TList<Order>))]
		OrderCollection,

		///<summary>
		/// Collection of <c>Portal</c> as OneToMany for ProfileCollection
		///</summary>
		[ChildEntityType(typeof(TList<Profile>))]
		ProfileCollection,

		///<summary>
		/// Collection of <c>Portal</c> as OneToMany for ContentPageCollection
		///</summary>
		[ChildEntityType(typeof(TList<ContentPage>))]
		ContentPageCollection,

		///<summary>
		/// Collection of <c>Portal</c> as OneToMany for ProductTypeCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductType>))]
		ProductTypeCollection,

		///<summary>
		/// Collection of <c>Portal</c> as OneToMany for ManufacturerCollection
		///</summary>
		[ChildEntityType(typeof(TList<Manufacturer>))]
		ManufacturerCollection,

		///<summary>
		/// Collection of <c>Portal</c> as OneToMany for ProductCollection
		///</summary>
		[ChildEntityType(typeof(TList<Product>))]
		ProductCollection,
	}
	
	#endregion PortalChildEntityTypes
	
	#region PortalFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Portal"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PortalFilterBuilder : SqlFilterBuilder<PortalColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PortalFilterBuilder class.
		/// </summary>
		public PortalFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PortalFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PortalFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PortalFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PortalFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PortalFilterBuilder
	
	#region PortalParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Portal"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PortalParameterBuilder : ParameterizedSqlFilterBuilder<PortalColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PortalParameterBuilder class.
		/// </summary>
		public PortalParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PortalParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PortalParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PortalParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PortalParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PortalParameterBuilder
} // end namespace
