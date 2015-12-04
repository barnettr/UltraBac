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
	/// This class is the base class for any <see cref="ProductProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Product, ZNode.Libraries.DataAccess.Entities.ProductKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductKey key)
		{
			return Delete(transactionManager, key.ProductID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="productID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 productID)
		{
			return Delete(null, productID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 productID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_Manufacturer key.
		///		FK_SC_Product_SC_Manufacturer Description: 
		/// </summary>
		/// <param name="manufacturerID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByManufacturerID(System.Int32? manufacturerID)
		{
			int count = -1;
			return GetByManufacturerID(manufacturerID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_Manufacturer key.
		///		FK_SC_Product_SC_Manufacturer Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="manufacturerID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByManufacturerID(TransactionManager transactionManager, System.Int32? manufacturerID)
		{
			int count = -1;
			return GetByManufacturerID(transactionManager, manufacturerID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_Manufacturer key.
		///		FK_SC_Product_SC_Manufacturer Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="manufacturerID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByManufacturerID(TransactionManager transactionManager, System.Int32? manufacturerID, int start, int pageLength)
		{
			int count = -1;
			return GetByManufacturerID(transactionManager, manufacturerID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_Manufacturer key.
		///		fKSCProductSCManufacturer Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="manufacturerID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByManufacturerID(System.Int32? manufacturerID, int start, int pageLength)
		{
			int count =  -1;
			return GetByManufacturerID(null, manufacturerID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_Manufacturer key.
		///		fKSCProductSCManufacturer Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="manufacturerID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByManufacturerID(System.Int32? manufacturerID, int start, int pageLength,out int count)
		{
			return GetByManufacturerID(null, manufacturerID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_Manufacturer key.
		///		FK_SC_Product_SC_Manufacturer Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="manufacturerID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Product> GetByManufacturerID(TransactionManager transactionManager, System.Int32? manufacturerID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_ProductType key.
		///		FK_SC_Product_SC_ProductType Description: 
		/// </summary>
		/// <param name="productTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByProductTypeID(System.Int32 productTypeID)
		{
			int count = -1;
			return GetByProductTypeID(productTypeID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_ProductType key.
		///		FK_SC_Product_SC_ProductType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByProductTypeID(TransactionManager transactionManager, System.Int32 productTypeID)
		{
			int count = -1;
			return GetByProductTypeID(transactionManager, productTypeID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_ProductType key.
		///		FK_SC_Product_SC_ProductType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByProductTypeID(TransactionManager transactionManager, System.Int32 productTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductTypeID(transactionManager, productTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_ProductType key.
		///		fKSCProductSCProductType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="productTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByProductTypeID(System.Int32 productTypeID, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductTypeID(null, productTypeID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_ProductType key.
		///		fKSCProductSCProductType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="productTypeID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByProductTypeID(System.Int32 productTypeID, int start, int pageLength,out int count)
		{
			return GetByProductTypeID(null, productTypeID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_ProductType key.
		///		FK_SC_Product_SC_ProductType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Product> GetByProductTypeID(TransactionManager transactionManager, System.Int32 productTypeID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_ShippingRuleType key.
		///		FK_SC_Product_SC_ShippingRuleType Description: 
		/// </summary>
		/// <param name="shippingRuleTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByShippingRuleTypeID(System.Int32? shippingRuleTypeID)
		{
			int count = -1;
			return GetByShippingRuleTypeID(shippingRuleTypeID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_ShippingRuleType key.
		///		FK_SC_Product_SC_ShippingRuleType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingRuleTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByShippingRuleTypeID(TransactionManager transactionManager, System.Int32? shippingRuleTypeID)
		{
			int count = -1;
			return GetByShippingRuleTypeID(transactionManager, shippingRuleTypeID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_ShippingRuleType key.
		///		FK_SC_Product_SC_ShippingRuleType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingRuleTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByShippingRuleTypeID(TransactionManager transactionManager, System.Int32? shippingRuleTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingRuleTypeID(transactionManager, shippingRuleTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_ShippingRuleType key.
		///		fKSCProductSCShippingRuleType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="shippingRuleTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByShippingRuleTypeID(System.Int32? shippingRuleTypeID, int start, int pageLength)
		{
			int count =  -1;
			return GetByShippingRuleTypeID(null, shippingRuleTypeID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_ShippingRuleType key.
		///		fKSCProductSCShippingRuleType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="shippingRuleTypeID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByShippingRuleTypeID(System.Int32? shippingRuleTypeID, int start, int pageLength,out int count)
		{
			return GetByShippingRuleTypeID(null, shippingRuleTypeID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Product_SC_ShippingRuleType key.
		///		FK_SC_Product_SC_ShippingRuleType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingRuleTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Product objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Product> GetByShippingRuleTypeID(TransactionManager transactionManager, System.Int32? shippingRuleTypeID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.Product Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductKey key, int start, int pageLength)
		{
			return GetByProductID(transactionManager, key.ProductID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key SC_Product_PK index.
		/// </summary>
		/// <param name="productID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Product"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Product GetByProductID(System.Int32 productID)
		{
			int count = -1;
			return GetByProductID(null,productID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_Product_PK index.
		/// </summary>
		/// <param name="productID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Product"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Product GetByProductID(System.Int32 productID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductID(null, productID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_Product_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Product"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Product GetByProductID(TransactionManager transactionManager, System.Int32 productID)
		{
			int count = -1;
			return GetByProductID(transactionManager, productID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_Product_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Product"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Product GetByProductID(TransactionManager transactionManager, System.Int32 productID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductID(transactionManager, productID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_Product_PK index.
		/// </summary>
		/// <param name="productID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Product"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Product GetByProductID(System.Int32 productID, int start, int pageLength, out int count)
		{
			return GetByProductID(null, productID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_Product_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Product"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Product GetByProductID(TransactionManager transactionManager, System.Int32 productID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX1 index.
		/// </summary>
		/// <param name="portalID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByPortalID(System.Int32 portalID)
		{
			int count = -1;
			return GetByPortalID(null,portalID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByPortalID(System.Int32 portalID, int start, int pageLength)
		{
			int count = -1;
			return GetByPortalID(null, portalID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByPortalID(System.Int32 portalID, int start, int pageLength, out int count)
		{
			return GetByPortalID(null, portalID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Product> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX4 index.
		/// </summary>
		/// <param name="homepageSpecial"></param>
		/// <param name="portalID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByHomepageSpecialPortalID(System.Boolean homepageSpecial, System.Int32 portalID)
		{
			int count = -1;
			return GetByHomepageSpecialPortalID(null,homepageSpecial, portalID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX4 index.
		/// </summary>
		/// <param name="homepageSpecial"></param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByHomepageSpecialPortalID(System.Boolean homepageSpecial, System.Int32 portalID, int start, int pageLength)
		{
			int count = -1;
			return GetByHomepageSpecialPortalID(null, homepageSpecial, portalID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="homepageSpecial"></param>
		/// <param name="portalID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByHomepageSpecialPortalID(TransactionManager transactionManager, System.Boolean homepageSpecial, System.Int32 portalID)
		{
			int count = -1;
			return GetByHomepageSpecialPortalID(transactionManager, homepageSpecial, portalID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="homepageSpecial"></param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByHomepageSpecialPortalID(TransactionManager transactionManager, System.Boolean homepageSpecial, System.Int32 portalID, int start, int pageLength)
		{
			int count = -1;
			return GetByHomepageSpecialPortalID(transactionManager, homepageSpecial, portalID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX4 index.
		/// </summary>
		/// <param name="homepageSpecial"></param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByHomepageSpecialPortalID(System.Boolean homepageSpecial, System.Int32 portalID, int start, int pageLength, out int count)
		{
			return GetByHomepageSpecialPortalID(null, homepageSpecial, portalID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="homepageSpecial"></param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Product> GetByHomepageSpecialPortalID(TransactionManager transactionManager, System.Boolean homepageSpecial, System.Int32 portalID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX3 index.
		/// </summary>
		/// <param name="activeInd"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByActiveInd(System.Boolean activeInd)
		{
			int count = -1;
			return GetByActiveInd(null,activeInd, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX3 index.
		/// </summary>
		/// <param name="activeInd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByActiveInd(System.Boolean activeInd, int start, int pageLength)
		{
			int count = -1;
			return GetByActiveInd(null, activeInd, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX3 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="activeInd"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByActiveInd(TransactionManager transactionManager, System.Boolean activeInd)
		{
			int count = -1;
			return GetByActiveInd(transactionManager, activeInd, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX3 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="activeInd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByActiveInd(TransactionManager transactionManager, System.Boolean activeInd, int start, int pageLength)
		{
			int count = -1;
			return GetByActiveInd(transactionManager, activeInd, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX3 index.
		/// </summary>
		/// <param name="activeInd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Product> GetByActiveInd(System.Boolean activeInd, int start, int pageLength, out int count)
		{
			return GetByActiveInd(null, activeInd, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX3 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="activeInd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Product> GetByActiveInd(TransactionManager transactionManager, System.Boolean activeInd, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Product&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Product> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Product> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.Product c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Product" 
							+ (reader.IsDBNull(reader.GetOrdinal("ProductID"))?(int)0:(System.Int32)reader["ProductID"]).ToString();

					c = EntityManager.LocateOrCreate<Product>(
						key.ToString(), // EntityTrackingKey 
						"Product",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Product();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ProductID = (System.Int32)reader["ProductID"];
					c.PortalID = (System.Int32)reader["PortalID"];
					c.Name = (System.String)reader["Name"];
					c.ShortDescription = (reader.IsDBNull(reader.GetOrdinal("ShortDescription")))?null:(System.String)reader["ShortDescription"];
					c.Description = (System.String)reader["Description"];
					c.FeaturesDesc = (reader.IsDBNull(reader.GetOrdinal("FeaturesDesc")))?null:(System.String)reader["FeaturesDesc"];
					c.ProductNum = (System.String)reader["ProductNum"];
					c.ProductTypeID = (System.Int32)reader["ProductTypeID"];
					c.RetailPrice = (reader.IsDBNull(reader.GetOrdinal("RetailPrice")))?null:(System.Decimal?)reader["RetailPrice"];
					c.WholesalePrice = (reader.IsDBNull(reader.GetOrdinal("WholesalePrice")))?null:(System.Decimal?)reader["WholesalePrice"];
					c.SalePrice = (reader.IsDBNull(reader.GetOrdinal("SalePrice")))?null:(System.Decimal?)reader["SalePrice"];
					c.ImageFile = (reader.IsDBNull(reader.GetOrdinal("ImageFile")))?null:(System.String)reader["ImageFile"];
					c.Weight = (reader.IsDBNull(reader.GetOrdinal("Weight")))?null:(System.Decimal?)reader["Weight"];
					c.ActiveInd = (System.Boolean)reader["ActiveInd"];
					c.DisplayOrder = (System.Int32)reader["DisplayOrder"];
					c.CallForPricing = (System.Boolean)reader["CallForPricing"];
					c.HomepageSpecial = (System.Boolean)reader["HomepageSpecial"];
					c.CategorySpecial = (System.Boolean)reader["CategorySpecial"];
					c.InventoryDisplay = (System.Byte)reader["InventoryDisplay"];
					c.Keywords = (reader.IsDBNull(reader.GetOrdinal("Keywords")))?null:(System.String)reader["Keywords"];
					c.ManufacturerID = (reader.IsDBNull(reader.GetOrdinal("ManufacturerID")))?null:(System.Int32?)reader["ManufacturerID"];
					c.AdditionalInfoLink = (reader.IsDBNull(reader.GetOrdinal("AdditionalInfoLink")))?null:(System.String)reader["AdditionalInfoLink"];
					c.AdditionalInfoLinkLabel = (reader.IsDBNull(reader.GetOrdinal("AdditionalInfoLinkLabel")))?null:(System.String)reader["AdditionalInfoLinkLabel"];
					c.ShippingRuleTypeID = (reader.IsDBNull(reader.GetOrdinal("ShippingRuleTypeID")))?null:(System.Int32?)reader["ShippingRuleTypeID"];
					c.SEOTitle = (reader.IsDBNull(reader.GetOrdinal("SEOTitle")))?null:(System.String)reader["SEOTitle"];
					c.SEOKeywords = (reader.IsDBNull(reader.GetOrdinal("SEOKeywords")))?null:(System.String)reader["SEOKeywords"];
					c.SEODescription = (reader.IsDBNull(reader.GetOrdinal("SEODescription")))?null:(System.String)reader["SEODescription"];
					c.Custom1 = (reader.IsDBNull(reader.GetOrdinal("Custom1")))?null:(System.String)reader["Custom1"];
					c.Custom2 = (reader.IsDBNull(reader.GetOrdinal("Custom2")))?null:(System.String)reader["Custom2"];
					c.Custom3 = (reader.IsDBNull(reader.GetOrdinal("Custom3")))?null:(System.String)reader["Custom3"];
					c.ShipEachItemSeparately = (reader.IsDBNull(reader.GetOrdinal("ShipEachItemSeparately")))?null:(System.Boolean?)reader["ShipEachItemSeparately"];
					c.SKU = (reader.IsDBNull(reader.GetOrdinal("SKU")))?null:(System.String)reader["SKU"];
					c.QuantityOnHand = (reader.IsDBNull(reader.GetOrdinal("QuantityOnHand")))?null:(System.Int32?)reader["QuantityOnHand"];
					c.AllowBackOrder = (reader.IsDBNull(reader.GetOrdinal("AllowBackOrder")))?null:(System.Boolean?)reader["AllowBackOrder"];
					c.BackOrderMsg = (reader.IsDBNull(reader.GetOrdinal("BackOrderMsg")))?null:(System.String)reader["BackOrderMsg"];
					c.DropShipInd = (reader.IsDBNull(reader.GetOrdinal("DropShipInd")))?null:(System.Boolean?)reader["DropShipInd"];
					c.DropShipEmailID = (reader.IsDBNull(reader.GetOrdinal("DropShipEmailID")))?null:(System.String)reader["DropShipEmailID"];
					c.Specifications = (reader.IsDBNull(reader.GetOrdinal("Specifications")))?null:(System.String)reader["Specifications"];
					c.AdditionalInformation = (reader.IsDBNull(reader.GetOrdinal("AdditionalInformation")))?null:(System.String)reader["AdditionalInformation"];
					c.InStockMsg = (reader.IsDBNull(reader.GetOrdinal("InStockMsg")))?null:(System.String)reader["InStockMsg"];
					c.OutOfStockMsg = (reader.IsDBNull(reader.GetOrdinal("OutOfStockMsg")))?null:(System.String)reader["OutOfStockMsg"];
					c.TrackInventoryInd = (reader.IsDBNull(reader.GetOrdinal("TrackInventoryInd")))?null:(System.Boolean?)reader["TrackInventoryInd"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Product"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Product"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Product entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductID = (System.Int32)reader["ProductID"];
			entity.PortalID = (System.Int32)reader["PortalID"];
			entity.Name = (System.String)reader["Name"];
			entity.ShortDescription = (reader.IsDBNull(reader.GetOrdinal("ShortDescription")))?null:(System.String)reader["ShortDescription"];
			entity.Description = (System.String)reader["Description"];
			entity.FeaturesDesc = (reader.IsDBNull(reader.GetOrdinal("FeaturesDesc")))?null:(System.String)reader["FeaturesDesc"];
			entity.ProductNum = (System.String)reader["ProductNum"];
			entity.ProductTypeID = (System.Int32)reader["ProductTypeID"];
			entity.RetailPrice = (reader.IsDBNull(reader.GetOrdinal("RetailPrice")))?null:(System.Decimal?)reader["RetailPrice"];
			entity.WholesalePrice = (reader.IsDBNull(reader.GetOrdinal("WholesalePrice")))?null:(System.Decimal?)reader["WholesalePrice"];
			entity.SalePrice = (reader.IsDBNull(reader.GetOrdinal("SalePrice")))?null:(System.Decimal?)reader["SalePrice"];
			entity.ImageFile = (reader.IsDBNull(reader.GetOrdinal("ImageFile")))?null:(System.String)reader["ImageFile"];
			entity.Weight = (reader.IsDBNull(reader.GetOrdinal("Weight")))?null:(System.Decimal?)reader["Weight"];
			entity.ActiveInd = (System.Boolean)reader["ActiveInd"];
			entity.DisplayOrder = (System.Int32)reader["DisplayOrder"];
			entity.CallForPricing = (System.Boolean)reader["CallForPricing"];
			entity.HomepageSpecial = (System.Boolean)reader["HomepageSpecial"];
			entity.CategorySpecial = (System.Boolean)reader["CategorySpecial"];
			entity.InventoryDisplay = (System.Byte)reader["InventoryDisplay"];
			entity.Keywords = (reader.IsDBNull(reader.GetOrdinal("Keywords")))?null:(System.String)reader["Keywords"];
			entity.ManufacturerID = (reader.IsDBNull(reader.GetOrdinal("ManufacturerID")))?null:(System.Int32?)reader["ManufacturerID"];
			entity.AdditionalInfoLink = (reader.IsDBNull(reader.GetOrdinal("AdditionalInfoLink")))?null:(System.String)reader["AdditionalInfoLink"];
			entity.AdditionalInfoLinkLabel = (reader.IsDBNull(reader.GetOrdinal("AdditionalInfoLinkLabel")))?null:(System.String)reader["AdditionalInfoLinkLabel"];
			entity.ShippingRuleTypeID = (reader.IsDBNull(reader.GetOrdinal("ShippingRuleTypeID")))?null:(System.Int32?)reader["ShippingRuleTypeID"];
			entity.SEOTitle = (reader.IsDBNull(reader.GetOrdinal("SEOTitle")))?null:(System.String)reader["SEOTitle"];
			entity.SEOKeywords = (reader.IsDBNull(reader.GetOrdinal("SEOKeywords")))?null:(System.String)reader["SEOKeywords"];
			entity.SEODescription = (reader.IsDBNull(reader.GetOrdinal("SEODescription")))?null:(System.String)reader["SEODescription"];
			entity.Custom1 = (reader.IsDBNull(reader.GetOrdinal("Custom1")))?null:(System.String)reader["Custom1"];
			entity.Custom2 = (reader.IsDBNull(reader.GetOrdinal("Custom2")))?null:(System.String)reader["Custom2"];
			entity.Custom3 = (reader.IsDBNull(reader.GetOrdinal("Custom3")))?null:(System.String)reader["Custom3"];
			entity.ShipEachItemSeparately = (reader.IsDBNull(reader.GetOrdinal("ShipEachItemSeparately")))?null:(System.Boolean?)reader["ShipEachItemSeparately"];
			entity.SKU = (reader.IsDBNull(reader.GetOrdinal("SKU")))?null:(System.String)reader["SKU"];
			entity.QuantityOnHand = (reader.IsDBNull(reader.GetOrdinal("QuantityOnHand")))?null:(System.Int32?)reader["QuantityOnHand"];
			entity.AllowBackOrder = (reader.IsDBNull(reader.GetOrdinal("AllowBackOrder")))?null:(System.Boolean?)reader["AllowBackOrder"];
			entity.BackOrderMsg = (reader.IsDBNull(reader.GetOrdinal("BackOrderMsg")))?null:(System.String)reader["BackOrderMsg"];
			entity.DropShipInd = (reader.IsDBNull(reader.GetOrdinal("DropShipInd")))?null:(System.Boolean?)reader["DropShipInd"];
			entity.DropShipEmailID = (reader.IsDBNull(reader.GetOrdinal("DropShipEmailID")))?null:(System.String)reader["DropShipEmailID"];
			entity.Specifications = (reader.IsDBNull(reader.GetOrdinal("Specifications")))?null:(System.String)reader["Specifications"];
			entity.AdditionalInformation = (reader.IsDBNull(reader.GetOrdinal("AdditionalInformation")))?null:(System.String)reader["AdditionalInformation"];
			entity.InStockMsg = (reader.IsDBNull(reader.GetOrdinal("InStockMsg")))?null:(System.String)reader["InStockMsg"];
			entity.OutOfStockMsg = (reader.IsDBNull(reader.GetOrdinal("OutOfStockMsg")))?null:(System.String)reader["OutOfStockMsg"];
			entity.TrackInventoryInd = (reader.IsDBNull(reader.GetOrdinal("TrackInventoryInd")))?null:(System.Boolean?)reader["TrackInventoryInd"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Product"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Product"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Product entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductID = (System.Int32)dataRow["ProductID"];
			entity.PortalID = (System.Int32)dataRow["PortalID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.ShortDescription = (Convert.IsDBNull(dataRow["ShortDescription"]))?null:(System.String)dataRow["ShortDescription"];
			entity.Description = (System.String)dataRow["Description"];
			entity.FeaturesDesc = (Convert.IsDBNull(dataRow["FeaturesDesc"]))?null:(System.String)dataRow["FeaturesDesc"];
			entity.ProductNum = (System.String)dataRow["ProductNum"];
			entity.ProductTypeID = (System.Int32)dataRow["ProductTypeID"];
			entity.RetailPrice = (Convert.IsDBNull(dataRow["RetailPrice"]))?null:(System.Decimal?)dataRow["RetailPrice"];
			entity.WholesalePrice = (Convert.IsDBNull(dataRow["WholesalePrice"]))?null:(System.Decimal?)dataRow["WholesalePrice"];
			entity.SalePrice = (Convert.IsDBNull(dataRow["SalePrice"]))?null:(System.Decimal?)dataRow["SalePrice"];
			entity.ImageFile = (Convert.IsDBNull(dataRow["ImageFile"]))?null:(System.String)dataRow["ImageFile"];
			entity.Weight = (Convert.IsDBNull(dataRow["Weight"]))?null:(System.Decimal?)dataRow["Weight"];
			entity.ActiveInd = (System.Boolean)dataRow["ActiveInd"];
			entity.DisplayOrder = (System.Int32)dataRow["DisplayOrder"];
			entity.CallForPricing = (System.Boolean)dataRow["CallForPricing"];
			entity.HomepageSpecial = (System.Boolean)dataRow["HomepageSpecial"];
			entity.CategorySpecial = (System.Boolean)dataRow["CategorySpecial"];
			entity.InventoryDisplay = (System.Byte)dataRow["InventoryDisplay"];
			entity.Keywords = (Convert.IsDBNull(dataRow["Keywords"]))?null:(System.String)dataRow["Keywords"];
			entity.ManufacturerID = (Convert.IsDBNull(dataRow["ManufacturerID"]))?null:(System.Int32?)dataRow["ManufacturerID"];
			entity.AdditionalInfoLink = (Convert.IsDBNull(dataRow["AdditionalInfoLink"]))?null:(System.String)dataRow["AdditionalInfoLink"];
			entity.AdditionalInfoLinkLabel = (Convert.IsDBNull(dataRow["AdditionalInfoLinkLabel"]))?null:(System.String)dataRow["AdditionalInfoLinkLabel"];
			entity.ShippingRuleTypeID = (Convert.IsDBNull(dataRow["ShippingRuleTypeID"]))?null:(System.Int32?)dataRow["ShippingRuleTypeID"];
			entity.SEOTitle = (Convert.IsDBNull(dataRow["SEOTitle"]))?null:(System.String)dataRow["SEOTitle"];
			entity.SEOKeywords = (Convert.IsDBNull(dataRow["SEOKeywords"]))?null:(System.String)dataRow["SEOKeywords"];
			entity.SEODescription = (Convert.IsDBNull(dataRow["SEODescription"]))?null:(System.String)dataRow["SEODescription"];
			entity.Custom1 = (Convert.IsDBNull(dataRow["Custom1"]))?null:(System.String)dataRow["Custom1"];
			entity.Custom2 = (Convert.IsDBNull(dataRow["Custom2"]))?null:(System.String)dataRow["Custom2"];
			entity.Custom3 = (Convert.IsDBNull(dataRow["Custom3"]))?null:(System.String)dataRow["Custom3"];
			entity.ShipEachItemSeparately = (Convert.IsDBNull(dataRow["ShipEachItemSeparately"]))?null:(System.Boolean?)dataRow["ShipEachItemSeparately"];
			entity.SKU = (Convert.IsDBNull(dataRow["SKU"]))?null:(System.String)dataRow["SKU"];
			entity.QuantityOnHand = (Convert.IsDBNull(dataRow["QuantityOnHand"]))?null:(System.Int32?)dataRow["QuantityOnHand"];
			entity.AllowBackOrder = (Convert.IsDBNull(dataRow["AllowBackOrder"]))?null:(System.Boolean?)dataRow["AllowBackOrder"];
			entity.BackOrderMsg = (Convert.IsDBNull(dataRow["BackOrderMsg"]))?null:(System.String)dataRow["BackOrderMsg"];
			entity.DropShipInd = (Convert.IsDBNull(dataRow["DropShipInd"]))?null:(System.Boolean?)dataRow["DropShipInd"];
			entity.DropShipEmailID = (Convert.IsDBNull(dataRow["DropShipEmailID"]))?null:(System.String)dataRow["DropShipEmailID"];
			entity.Specifications = (Convert.IsDBNull(dataRow["Specifications"]))?null:(System.String)dataRow["Specifications"];
			entity.AdditionalInformation = (Convert.IsDBNull(dataRow["AdditionalInformation"]))?null:(System.String)dataRow["AdditionalInformation"];
			entity.InStockMsg = (Convert.IsDBNull(dataRow["InStockMsg"]))?null:(System.String)dataRow["InStockMsg"];
			entity.OutOfStockMsg = (Convert.IsDBNull(dataRow["OutOfStockMsg"]))?null:(System.String)dataRow["OutOfStockMsg"];
			entity.TrackInventoryInd = (Convert.IsDBNull(dataRow["TrackInventoryInd"]))?null:(System.Boolean?)dataRow["TrackInventoryInd"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Product"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Product Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Product entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region PortalIDSource	
			if (CanDeepLoad(entity, "Portal", "PortalIDSource", deepLoadType, innerList) 
				&& entity.PortalIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.PortalID;
				Portal tmpEntity = EntityManager.LocateEntity<Portal>(EntityLocator.ConstructKeyFromPkItems(typeof(Portal), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PortalIDSource = tmpEntity;
				else
					entity.PortalIDSource = DataRepository.PortalProvider.GetByPortalID(entity.PortalID);
			
				if (deep && entity.PortalIDSource != null)
				{
					DataRepository.PortalProvider.DeepLoad(transactionManager, entity.PortalIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion PortalIDSource

			#region ManufacturerIDSource	
			if (CanDeepLoad(entity, "Manufacturer", "ManufacturerIDSource", deepLoadType, innerList) 
				&& entity.ManufacturerIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ManufacturerID ?? (int)0);
				Manufacturer tmpEntity = EntityManager.LocateEntity<Manufacturer>(EntityLocator.ConstructKeyFromPkItems(typeof(Manufacturer), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ManufacturerIDSource = tmpEntity;
				else
					entity.ManufacturerIDSource = DataRepository.ManufacturerProvider.GetByManufacturerID((entity.ManufacturerID ?? (int)0));
			
				if (deep && entity.ManufacturerIDSource != null)
				{
					DataRepository.ManufacturerProvider.DeepLoad(transactionManager, entity.ManufacturerIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ManufacturerIDSource

			#region ProductTypeIDSource	
			if (CanDeepLoad(entity, "ProductType", "ProductTypeIDSource", deepLoadType, innerList) 
				&& entity.ProductTypeIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductTypeID;
				ProductType tmpEntity = EntityManager.LocateEntity<ProductType>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductTypeIDSource = tmpEntity;
				else
					entity.ProductTypeIDSource = DataRepository.ProductTypeProvider.GetByProductTypeId(entity.ProductTypeID);
			
				if (deep && entity.ProductTypeIDSource != null)
				{
					DataRepository.ProductTypeProvider.DeepLoad(transactionManager, entity.ProductTypeIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ProductTypeIDSource

			#region ShippingRuleTypeIDSource	
			if (CanDeepLoad(entity, "ShippingRuleType", "ShippingRuleTypeIDSource", deepLoadType, innerList) 
				&& entity.ShippingRuleTypeIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ShippingRuleTypeID ?? (int)0);
				ShippingRuleType tmpEntity = EntityManager.LocateEntity<ShippingRuleType>(EntityLocator.ConstructKeyFromPkItems(typeof(ShippingRuleType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ShippingRuleTypeIDSource = tmpEntity;
				else
					entity.ShippingRuleTypeIDSource = DataRepository.ShippingRuleTypeProvider.GetByShippingRuleTypeID((entity.ShippingRuleTypeID ?? (int)0));
			
				if (deep && entity.ShippingRuleTypeIDSource != null)
				{
					DataRepository.ShippingRuleTypeProvider.DeepLoad(transactionManager, entity.ShippingRuleTypeIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ShippingRuleTypeIDSource
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByProductID methods when available
			
			#region ProductImageCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductImage>", "ProductImageCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProductImageCollection' loaded.");
				#endif 

				entity.ProductImageCollection = DataRepository.ProductImageProvider.GetByProductID(transactionManager, entity.ProductID);

				if (deep && entity.ProductImageCollection.Count > 0)
				{
					DataRepository.ProductImageProvider.DeepLoad(transactionManager, entity.ProductImageCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ProductCategoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductCategory>", "ProductCategoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProductCategoryCollection' loaded.");
				#endif 

				entity.ProductCategoryCollection = DataRepository.ProductCategoryProvider.GetByProductID(transactionManager, entity.ProductID);

				if (deep && entity.ProductCategoryCollection.Count > 0)
				{
					DataRepository.ProductCategoryProvider.DeepLoad(transactionManager, entity.ProductCategoryCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ProductCrossSellCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductCrossSell>", "ProductCrossSellCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProductCrossSellCollection' loaded.");
				#endif 

				entity.ProductCrossSellCollection = DataRepository.ProductCrossSellProvider.GetByProductId(transactionManager, entity.ProductID);

				if (deep && entity.ProductCrossSellCollection.Count > 0)
				{
					DataRepository.ProductCrossSellProvider.DeepLoad(transactionManager, entity.ProductCrossSellCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region SKUCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SKU>", "SKUCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'SKUCollection' loaded.");
				#endif 

				entity.SKUCollection = DataRepository.SKUProvider.GetByProductID(transactionManager, entity.ProductID);

				if (deep && entity.SKUCollection.Count > 0)
				{
					DataRepository.SKUProvider.DeepLoad(transactionManager, entity.SKUCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ProductHighlightCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductHighlight>", "ProductHighlightCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProductHighlightCollection' loaded.");
				#endif 

				entity.ProductHighlightCollection = DataRepository.ProductHighlightProvider.GetByProductID(transactionManager, entity.ProductID);

				if (deep && entity.ProductHighlightCollection.Count > 0)
				{
					DataRepository.ProductHighlightProvider.DeepLoad(transactionManager, entity.ProductHighlightCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ProductAddOnCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductAddOn>", "ProductAddOnCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProductAddOnCollection' loaded.");
				#endif 

				entity.ProductAddOnCollection = DataRepository.ProductAddOnProvider.GetByProductID(transactionManager, entity.ProductID);

				if (deep && entity.ProductAddOnCollection.Count > 0)
				{
					DataRepository.ProductAddOnProvider.DeepLoad(transactionManager, entity.ProductAddOnCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Product object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Product instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Product Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Product entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region PortalIDSource
			if (CanDeepSave(entity, "Portal", "PortalIDSource", deepSaveType, innerList) 
				&& entity.PortalIDSource != null)
			{
				DataRepository.PortalProvider.Save(transactionManager, entity.PortalIDSource);
				entity.PortalID = entity.PortalIDSource.PortalID;
			}
			#endregion 
			
			#region ManufacturerIDSource
			if (CanDeepSave(entity, "Manufacturer", "ManufacturerIDSource", deepSaveType, innerList) 
				&& entity.ManufacturerIDSource != null)
			{
				DataRepository.ManufacturerProvider.Save(transactionManager, entity.ManufacturerIDSource);
				entity.ManufacturerID = entity.ManufacturerIDSource.ManufacturerID;
			}
			#endregion 
			
			#region ProductTypeIDSource
			if (CanDeepSave(entity, "ProductType", "ProductTypeIDSource", deepSaveType, innerList) 
				&& entity.ProductTypeIDSource != null)
			{
				DataRepository.ProductTypeProvider.Save(transactionManager, entity.ProductTypeIDSource);
				entity.ProductTypeID = entity.ProductTypeIDSource.ProductTypeId;
			}
			#endregion 
			
			#region ShippingRuleTypeIDSource
			if (CanDeepSave(entity, "ShippingRuleType", "ShippingRuleTypeIDSource", deepSaveType, innerList) 
				&& entity.ShippingRuleTypeIDSource != null)
			{
				DataRepository.ShippingRuleTypeProvider.Save(transactionManager, entity.ShippingRuleTypeIDSource);
				entity.ShippingRuleTypeID = entity.ShippingRuleTypeIDSource.ShippingRuleTypeID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			













			#region List<ProductImage>
				if (CanDeepSave(entity, "List<ProductImage>", "ProductImageCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductImage child in entity.ProductImageCollection)
					{
						child.ProductID = entity.ProductID;
					}
				
				if (entity.ProductImageCollection.Count > 0 || entity.ProductImageCollection.DeletedItems.Count > 0)
					DataRepository.ProductImageProvider.DeepSave(transactionManager, entity.ProductImageCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<ProductCategory>
				if (CanDeepSave(entity, "List<ProductCategory>", "ProductCategoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductCategory child in entity.ProductCategoryCollection)
					{
						child.ProductID = entity.ProductID;
					}
				
				if (entity.ProductCategoryCollection.Count > 0 || entity.ProductCategoryCollection.DeletedItems.Count > 0)
					DataRepository.ProductCategoryProvider.DeepSave(transactionManager, entity.ProductCategoryCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<ProductCrossSell>
				if (CanDeepSave(entity, "List<ProductCrossSell>", "ProductCrossSellCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductCrossSell child in entity.ProductCrossSellCollection)
					{
						child.ProductId = entity.ProductID;
					}
				
				if (entity.ProductCrossSellCollection.Count > 0 || entity.ProductCrossSellCollection.DeletedItems.Count > 0)
					DataRepository.ProductCrossSellProvider.DeepSave(transactionManager, entity.ProductCrossSellCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<SKU>
				if (CanDeepSave(entity, "List<SKU>", "SKUCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SKU child in entity.SKUCollection)
					{
						child.ProductID = entity.ProductID;
					}
				
				if (entity.SKUCollection.Count > 0 || entity.SKUCollection.DeletedItems.Count > 0)
					DataRepository.SKUProvider.DeepSave(transactionManager, entity.SKUCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<ProductHighlight>
				if (CanDeepSave(entity, "List<ProductHighlight>", "ProductHighlightCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductHighlight child in entity.ProductHighlightCollection)
					{
						child.ProductID = entity.ProductID;
					}
				
				if (entity.ProductHighlightCollection.Count > 0 || entity.ProductHighlightCollection.DeletedItems.Count > 0)
					DataRepository.ProductHighlightProvider.DeepSave(transactionManager, entity.ProductHighlightCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<ProductAddOn>
				if (CanDeepSave(entity, "List<ProductAddOn>", "ProductAddOnCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductAddOn child in entity.ProductAddOnCollection)
					{
						child.ProductID = entity.ProductID;
					}
				
				if (entity.ProductAddOnCollection.Count > 0 || entity.ProductAddOnCollection.DeletedItems.Count > 0)
					DataRepository.ProductAddOnProvider.DeepSave(transactionManager, entity.ProductAddOnCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				






						
			return true;
		}
		#endregion
	} // end class
	
	#region ProductChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Product</c>
	///</summary>
	public enum ProductChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Portal</c> at PortalIDSource
		///</summary>
		[ChildEntityType(typeof(Portal))]
		Portal,
			
		///<summary>
		/// Composite Property for <c>Manufacturer</c> at ManufacturerIDSource
		///</summary>
		[ChildEntityType(typeof(Manufacturer))]
		Manufacturer,
			
		///<summary>
		/// Composite Property for <c>ProductType</c> at ProductTypeIDSource
		///</summary>
		[ChildEntityType(typeof(ProductType))]
		ProductType,
			
		///<summary>
		/// Composite Property for <c>ShippingRuleType</c> at ShippingRuleTypeIDSource
		///</summary>
		[ChildEntityType(typeof(ShippingRuleType))]
		ShippingRuleType,
	
		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ProductImageCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductImage>))]
		ProductImageCollection,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ProductCategoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductCategory>))]
		ProductCategoryCollection,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ProductCrossSellCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductCrossSell>))]
		ProductCrossSellCollection,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for SKUCollection
		///</summary>
		[ChildEntityType(typeof(TList<SKU>))]
		SKUCollection,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ProductHighlightCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductHighlight>))]
		ProductHighlightCollection,

		///<summary>
		/// Collection of <c>Product</c> as OneToMany for ProductAddOnCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductAddOn>))]
		ProductAddOnCollection,
	}
	
	#endregion ProductChildEntityTypes
	
	#region ProductFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductFilterBuilder : SqlFilterBuilder<ProductColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductFilterBuilder class.
		/// </summary>
		public ProductFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductFilterBuilder
	
	#region ProductParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Product"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductParameterBuilder : ParameterizedSqlFilterBuilder<ProductColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductParameterBuilder class.
		/// </summary>
		public ProductParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductParameterBuilder
} // end namespace
