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
	/// This class is the base class for any <see cref="ShippingProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ShippingProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Shipping, ZNode.Libraries.DataAccess.Entities.ShippingKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingKey key)
		{
			return Delete(transactionManager, key.ShippingID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="shippingID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 shippingID)
		{
			return Delete(null, shippingID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 shippingID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeShipping_ZNodeCountry key.
		///		FK_ZNodeShipping_ZNodeCountry Description: 
		/// </summary>
		/// <param name="destinationCountryCode"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Shipping objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByDestinationCountryCode(System.String destinationCountryCode)
		{
			int count = -1;
			return GetByDestinationCountryCode(destinationCountryCode, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeShipping_ZNodeCountry key.
		///		FK_ZNodeShipping_ZNodeCountry Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="destinationCountryCode"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Shipping objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByDestinationCountryCode(TransactionManager transactionManager, System.String destinationCountryCode)
		{
			int count = -1;
			return GetByDestinationCountryCode(transactionManager, destinationCountryCode, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeShipping_ZNodeCountry key.
		///		FK_ZNodeShipping_ZNodeCountry Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="destinationCountryCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Shipping objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByDestinationCountryCode(TransactionManager transactionManager, System.String destinationCountryCode, int start, int pageLength)
		{
			int count = -1;
			return GetByDestinationCountryCode(transactionManager, destinationCountryCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeShipping_ZNodeCountry key.
		///		fKZNodeShippingZNodeCountry Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="destinationCountryCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Shipping objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByDestinationCountryCode(System.String destinationCountryCode, int start, int pageLength)
		{
			int count =  -1;
			return GetByDestinationCountryCode(null, destinationCountryCode, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeShipping_ZNodeCountry key.
		///		fKZNodeShippingZNodeCountry Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="destinationCountryCode"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Shipping objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByDestinationCountryCode(System.String destinationCountryCode, int start, int pageLength,out int count)
		{
			return GetByDestinationCountryCode(null, destinationCountryCode, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeShipping_ZNodeCountry key.
		///		FK_ZNodeShipping_ZNodeCountry Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="destinationCountryCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Shipping objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByDestinationCountryCode(TransactionManager transactionManager, System.String destinationCountryCode, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.Shipping Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingKey key, int start, int pageLength)
		{
			return GetByShippingID(transactionManager, key.ShippingID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_Shipping index.
		/// </summary>
		/// <param name="shippingID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Shipping"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Shipping GetByShippingID(System.Int32 shippingID)
		{
			int count = -1;
			return GetByShippingID(null,shippingID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Shipping index.
		/// </summary>
		/// <param name="shippingID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Shipping"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Shipping GetByShippingID(System.Int32 shippingID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingID(null, shippingID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Shipping index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Shipping"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Shipping GetByShippingID(TransactionManager transactionManager, System.Int32 shippingID)
		{
			int count = -1;
			return GetByShippingID(transactionManager, shippingID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Shipping index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Shipping"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Shipping GetByShippingID(TransactionManager transactionManager, System.Int32 shippingID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingID(transactionManager, shippingID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Shipping index.
		/// </summary>
		/// <param name="shippingID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Shipping"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Shipping GetByShippingID(System.Int32 shippingID, int start, int pageLength, out int count)
		{
			return GetByShippingID(null, shippingID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Shipping index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Shipping"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Shipping GetByShippingID(TransactionManager transactionManager, System.Int32 shippingID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_SC_Shipping index.
		/// </summary>
		/// <param name="shippingTypeID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Shipping&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByShippingTypeID(System.Int32 shippingTypeID)
		{
			int count = -1;
			return GetByShippingTypeID(null,shippingTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SC_Shipping index.
		/// </summary>
		/// <param name="shippingTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Shipping&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByShippingTypeID(System.Int32 shippingTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingTypeID(null, shippingTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SC_Shipping index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Shipping&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByShippingTypeID(TransactionManager transactionManager, System.Int32 shippingTypeID)
		{
			int count = -1;
			return GetByShippingTypeID(transactionManager, shippingTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SC_Shipping index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Shipping&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByShippingTypeID(TransactionManager transactionManager, System.Int32 shippingTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingTypeID(transactionManager, shippingTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SC_Shipping index.
		/// </summary>
		/// <param name="shippingTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Shipping&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByShippingTypeID(System.Int32 shippingTypeID, int start, int pageLength, out int count)
		{
			return GetByShippingTypeID(null, shippingTypeID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SC_Shipping index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Shipping&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByShippingTypeID(TransactionManager transactionManager, System.Int32 shippingTypeID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX1 index.
		/// </summary>
		/// <param name="profileID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Shipping&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByProfileID(System.Int32? profileID)
		{
			int count = -1;
			return GetByProfileID(null,profileID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="profileID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Shipping&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByProfileID(System.Int32? profileID, int start, int pageLength)
		{
			int count = -1;
			return GetByProfileID(null, profileID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Shipping&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByProfileID(TransactionManager transactionManager, System.Int32? profileID)
		{
			int count = -1;
			return GetByProfileID(transactionManager, profileID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Shipping&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByProfileID(TransactionManager transactionManager, System.Int32? profileID, int start, int pageLength)
		{
			int count = -1;
			return GetByProfileID(transactionManager, profileID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="profileID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Shipping&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByProfileID(System.Int32? profileID, int start, int pageLength, out int count)
		{
			return GetByProfileID(null, profileID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Shipping&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Shipping> GetByProfileID(TransactionManager transactionManager, System.Int32? profileID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Shipping&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Shipping&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Shipping> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Shipping> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.Shipping c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Shipping" 
							+ (reader.IsDBNull(reader.GetOrdinal("ShippingID"))?(int)0:(System.Int32)reader["ShippingID"]).ToString();

					c = EntityManager.LocateOrCreate<Shipping>(
						key.ToString(), // EntityTrackingKey 
						"Shipping",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Shipping();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ShippingID = (System.Int32)reader["ShippingID"];
					c.ShippingTypeID = (System.Int32)reader["ShippingTypeID"];
					c.ProfileID = (reader.IsDBNull(reader.GetOrdinal("ProfileID")))?null:(System.Int32?)reader["ProfileID"];
					c.ShippingCode = (System.String)reader["ShippingCode"];
					c.HandlingCharge = (System.Decimal)reader["HandlingCharge"];
					c.DestinationCountryCode = (reader.IsDBNull(reader.GetOrdinal("DestinationCountryCode")))?null:(System.String)reader["DestinationCountryCode"];
					c.Description = (System.String)reader["Description"];
					c.ActiveInd = (System.Boolean)reader["ActiveInd"];
					c.DisplayOrder = (System.Int32)reader["DisplayOrder"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Shipping"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Shipping"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Shipping entity)
		{
			if (!reader.Read()) return;
			
			entity.ShippingID = (System.Int32)reader["ShippingID"];
			entity.ShippingTypeID = (System.Int32)reader["ShippingTypeID"];
			entity.ProfileID = (reader.IsDBNull(reader.GetOrdinal("ProfileID")))?null:(System.Int32?)reader["ProfileID"];
			entity.ShippingCode = (System.String)reader["ShippingCode"];
			entity.HandlingCharge = (System.Decimal)reader["HandlingCharge"];
			entity.DestinationCountryCode = (reader.IsDBNull(reader.GetOrdinal("DestinationCountryCode")))?null:(System.String)reader["DestinationCountryCode"];
			entity.Description = (System.String)reader["Description"];
			entity.ActiveInd = (System.Boolean)reader["ActiveInd"];
			entity.DisplayOrder = (System.Int32)reader["DisplayOrder"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Shipping"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Shipping"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Shipping entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ShippingID = (System.Int32)dataRow["ShippingID"];
			entity.ShippingTypeID = (System.Int32)dataRow["ShippingTypeID"];
			entity.ProfileID = (Convert.IsDBNull(dataRow["ProfileID"]))?null:(System.Int32?)dataRow["ProfileID"];
			entity.ShippingCode = (System.String)dataRow["ShippingCode"];
			entity.HandlingCharge = (System.Decimal)dataRow["HandlingCharge"];
			entity.DestinationCountryCode = (Convert.IsDBNull(dataRow["DestinationCountryCode"]))?null:(System.String)dataRow["DestinationCountryCode"];
			entity.Description = (System.String)dataRow["Description"];
			entity.ActiveInd = (System.Boolean)dataRow["ActiveInd"];
			entity.DisplayOrder = (System.Int32)dataRow["DisplayOrder"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Shipping"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Shipping Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Shipping entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region ProfileIDSource	
			if (CanDeepLoad(entity, "Profile", "ProfileIDSource", deepLoadType, innerList) 
				&& entity.ProfileIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ProfileID ?? (int)0);
				Profile tmpEntity = EntityManager.LocateEntity<Profile>(EntityLocator.ConstructKeyFromPkItems(typeof(Profile), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProfileIDSource = tmpEntity;
				else
					entity.ProfileIDSource = DataRepository.ProfileProvider.GetByProfileID((entity.ProfileID ?? (int)0));
			
				if (deep && entity.ProfileIDSource != null)
				{
					DataRepository.ProfileProvider.DeepLoad(transactionManager, entity.ProfileIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ProfileIDSource

			#region ShippingTypeIDSource	
			if (CanDeepLoad(entity, "ShippingType", "ShippingTypeIDSource", deepLoadType, innerList) 
				&& entity.ShippingTypeIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ShippingTypeID;
				ShippingType tmpEntity = EntityManager.LocateEntity<ShippingType>(EntityLocator.ConstructKeyFromPkItems(typeof(ShippingType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ShippingTypeIDSource = tmpEntity;
				else
					entity.ShippingTypeIDSource = DataRepository.ShippingTypeProvider.GetByShippingTypeID(entity.ShippingTypeID);
			
				if (deep && entity.ShippingTypeIDSource != null)
				{
					DataRepository.ShippingTypeProvider.DeepLoad(transactionManager, entity.ShippingTypeIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ShippingTypeIDSource

			#region DestinationCountryCodeSource	
			if (CanDeepLoad(entity, "Country", "DestinationCountryCodeSource", deepLoadType, innerList) 
				&& entity.DestinationCountryCodeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.DestinationCountryCode ?? string.Empty);
				Country tmpEntity = EntityManager.LocateEntity<Country>(EntityLocator.ConstructKeyFromPkItems(typeof(Country), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DestinationCountryCodeSource = tmpEntity;
				else
					entity.DestinationCountryCodeSource = DataRepository.CountryProvider.GetByCode((entity.DestinationCountryCode ?? string.Empty));
			
				if (deep && entity.DestinationCountryCodeSource != null)
				{
					DataRepository.CountryProvider.DeepLoad(transactionManager, entity.DestinationCountryCodeSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion DestinationCountryCodeSource
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByShippingID methods when available
			
			#region OrderCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Order>", "OrderCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'OrderCollection' loaded.");
				#endif 

				entity.OrderCollection = DataRepository.OrderProvider.GetByShippingID(transactionManager, entity.ShippingID);

				if (deep && entity.OrderCollection.Count > 0)
				{
					DataRepository.OrderProvider.DeepLoad(transactionManager, entity.OrderCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ShippingRuleCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ShippingRule>", "ShippingRuleCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ShippingRuleCollection' loaded.");
				#endif 

				entity.ShippingRuleCollection = DataRepository.ShippingRuleProvider.GetByShippingID(transactionManager, entity.ShippingID);

				if (deep && entity.ShippingRuleCollection.Count > 0)
				{
					DataRepository.ShippingRuleProvider.DeepLoad(transactionManager, entity.ShippingRuleCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Shipping object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Shipping instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Shipping Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Shipping entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ProfileIDSource
			if (CanDeepSave(entity, "Profile", "ProfileIDSource", deepSaveType, innerList) 
				&& entity.ProfileIDSource != null)
			{
				DataRepository.ProfileProvider.Save(transactionManager, entity.ProfileIDSource);
				entity.ProfileID = entity.ProfileIDSource.ProfileID;
			}
			#endregion 
			
			#region ShippingTypeIDSource
			if (CanDeepSave(entity, "ShippingType", "ShippingTypeIDSource", deepSaveType, innerList) 
				&& entity.ShippingTypeIDSource != null)
			{
				DataRepository.ShippingTypeProvider.Save(transactionManager, entity.ShippingTypeIDSource);
				entity.ShippingTypeID = entity.ShippingTypeIDSource.ShippingTypeID;
			}
			#endregion 
			
			#region DestinationCountryCodeSource
			if (CanDeepSave(entity, "Country", "DestinationCountryCodeSource", deepSaveType, innerList) 
				&& entity.DestinationCountryCodeSource != null)
			{
				DataRepository.CountryProvider.Save(transactionManager, entity.DestinationCountryCodeSource);
				entity.DestinationCountryCode = entity.DestinationCountryCodeSource.Code;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			





			#region List<Order>
				if (CanDeepSave(entity, "List<Order>", "OrderCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Order child in entity.OrderCollection)
					{
						child.ShippingID = entity.ShippingID;
					}
				
				if (entity.OrderCollection.Count > 0 || entity.OrderCollection.DeletedItems.Count > 0)
					DataRepository.OrderProvider.DeepSave(transactionManager, entity.OrderCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<ShippingRule>
				if (CanDeepSave(entity, "List<ShippingRule>", "ShippingRuleCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ShippingRule child in entity.ShippingRuleCollection)
					{
						child.ShippingID = entity.ShippingID;
					}
				
				if (entity.ShippingRuleCollection.Count > 0 || entity.ShippingRuleCollection.DeletedItems.Count > 0)
					DataRepository.ShippingRuleProvider.DeepSave(transactionManager, entity.ShippingRuleCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				


						
			return true;
		}
		#endregion
	} // end class
	
	#region ShippingChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Shipping</c>
	///</summary>
	public enum ShippingChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Profile</c> at ProfileIDSource
		///</summary>
		[ChildEntityType(typeof(Profile))]
		Profile,
			
		///<summary>
		/// Composite Property for <c>ShippingType</c> at ShippingTypeIDSource
		///</summary>
		[ChildEntityType(typeof(ShippingType))]
		ShippingType,
			
		///<summary>
		/// Composite Property for <c>Country</c> at DestinationCountryCodeSource
		///</summary>
		[ChildEntityType(typeof(Country))]
		Country,
	
		///<summary>
		/// Collection of <c>Shipping</c> as OneToMany for OrderCollection
		///</summary>
		[ChildEntityType(typeof(TList<Order>))]
		OrderCollection,

		///<summary>
		/// Collection of <c>Shipping</c> as OneToMany for ShippingRuleCollection
		///</summary>
		[ChildEntityType(typeof(TList<ShippingRule>))]
		ShippingRuleCollection,
	}
	
	#endregion ShippingChildEntityTypes
	
	#region ShippingFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Shipping"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShippingFilterBuilder : SqlFilterBuilder<ShippingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShippingFilterBuilder class.
		/// </summary>
		public ShippingFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShippingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShippingFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShippingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShippingFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShippingFilterBuilder
	
	#region ShippingParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Shipping"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShippingParameterBuilder : ParameterizedSqlFilterBuilder<ShippingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShippingParameterBuilder class.
		/// </summary>
		public ShippingParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShippingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShippingParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShippingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShippingParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShippingParameterBuilder
} // end namespace
