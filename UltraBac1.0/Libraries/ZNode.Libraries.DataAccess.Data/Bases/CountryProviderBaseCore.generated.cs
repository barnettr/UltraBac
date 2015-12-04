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
	/// This class is the base class for any <see cref="CountryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CountryProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Country, ZNode.Libraries.DataAccess.Entities.CountryKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.CountryKey key)
		{
			return Delete(transactionManager, key.Code);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="code">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String code)
		{
			return Delete(null, code);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="code">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String code);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.Country Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.CountryKey key, int start, int pageLength)
		{
			return GetByCode(transactionManager, key.Code, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ZNodeCountry index.
		/// </summary>
		/// <param name="code"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Country"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Country GetByCode(System.String code)
		{
			int count = -1;
			return GetByCode(null,code, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeCountry index.
		/// </summary>
		/// <param name="code"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Country"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Country GetByCode(System.String code, int start, int pageLength)
		{
			int count = -1;
			return GetByCode(null, code, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeCountry index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="code"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Country"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Country GetByCode(TransactionManager transactionManager, System.String code)
		{
			int count = -1;
			return GetByCode(transactionManager, code, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeCountry index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="code"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Country"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Country GetByCode(TransactionManager transactionManager, System.String code, int start, int pageLength)
		{
			int count = -1;
			return GetByCode(transactionManager, code, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeCountry index.
		/// </summary>
		/// <param name="code"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Country"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Country GetByCode(System.String code, int start, int pageLength, out int count)
		{
			return GetByCode(null, code, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeCountry index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="code"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Country"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Country GetByCode(TransactionManager transactionManager, System.String code, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX1 index.
		/// </summary>
		/// <param name="portalID"></param>
		/// <param name="activeInd"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Country&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Country> GetByPortalIDActiveInd(System.Int32? portalID, System.Boolean activeInd)
		{
			int count = -1;
			return GetByPortalIDActiveInd(null,portalID, activeInd, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="portalID"></param>
		/// <param name="activeInd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Country&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Country> GetByPortalIDActiveInd(System.Int32? portalID, System.Boolean activeInd, int start, int pageLength)
		{
			int count = -1;
			return GetByPortalIDActiveInd(null, portalID, activeInd, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="activeInd"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Country&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Country> GetByPortalIDActiveInd(TransactionManager transactionManager, System.Int32? portalID, System.Boolean activeInd)
		{
			int count = -1;
			return GetByPortalIDActiveInd(transactionManager, portalID, activeInd, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="activeInd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Country&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Country> GetByPortalIDActiveInd(TransactionManager transactionManager, System.Int32? portalID, System.Boolean activeInd, int start, int pageLength)
		{
			int count = -1;
			return GetByPortalIDActiveInd(transactionManager, portalID, activeInd, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="portalID"></param>
		/// <param name="activeInd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Country&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Country> GetByPortalIDActiveInd(System.Int32? portalID, System.Boolean activeInd, int start, int pageLength, out int count)
		{
			return GetByPortalIDActiveInd(null, portalID, activeInd, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="activeInd"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Country&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Country> GetByPortalIDActiveInd(TransactionManager transactionManager, System.Int32? portalID, System.Boolean activeInd, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Country&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Country&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Country> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Country> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.Country c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Country" 
							+ (reader.IsDBNull(reader.GetOrdinal("Code"))?string.Empty:(System.String)reader["Code"]).ToString();

					c = EntityManager.LocateOrCreate<Country>(
						key.ToString(), // EntityTrackingKey 
						"Country",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Country();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.Code = (System.String)reader["Code"];
					c.OriginalCode = c.Code; //(reader.IsDBNull(reader.GetOrdinal("Code")))?string.Empty:(System.String)reader["Code"];
					c.PortalID = (reader.IsDBNull(reader.GetOrdinal("PortalID")))?null:(System.Int32?)reader["PortalID"];
					c.Name = (System.String)reader["Name"];
					c.DisplayOrder = (System.Int32)reader["DisplayOrder"];
					c.ActiveInd = (System.Boolean)reader["ActiveInd"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Country"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Country"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Country entity)
		{
			if (!reader.Read()) return;
			
			entity.Code = (System.String)reader["Code"];
			entity.OriginalCode = (System.String)reader["Code"];
			entity.PortalID = (reader.IsDBNull(reader.GetOrdinal("PortalID")))?null:(System.Int32?)reader["PortalID"];
			entity.Name = (System.String)reader["Name"];
			entity.DisplayOrder = (System.Int32)reader["DisplayOrder"];
			entity.ActiveInd = (System.Boolean)reader["ActiveInd"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Country"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Country"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Country entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Code = (System.String)dataRow["Code"];
			entity.OriginalCode = (System.String)dataRow["Code"];
			entity.PortalID = (Convert.IsDBNull(dataRow["PortalID"]))?null:(System.Int32?)dataRow["PortalID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.DisplayOrder = (System.Int32)dataRow["DisplayOrder"];
			entity.ActiveInd = (System.Boolean)dataRow["ActiveInd"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Country"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Country Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Country entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByCode methods when available
			
			#region TaxRuleCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<TaxRule>", "TaxRuleCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'TaxRuleCollection' loaded.");
				#endif 

				entity.TaxRuleCollection = DataRepository.TaxRuleProvider.GetByDestinationCountryCode(transactionManager, entity.Code);

				if (deep && entity.TaxRuleCollection.Count > 0)
				{
					DataRepository.TaxRuleProvider.DeepLoad(transactionManager, entity.TaxRuleCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ShippingCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Shipping>", "ShippingCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ShippingCollection' loaded.");
				#endif 

				entity.ShippingCollection = DataRepository.ShippingProvider.GetByDestinationCountryCode(transactionManager, entity.Code);

				if (deep && entity.ShippingCollection.Count > 0)
				{
					DataRepository.ShippingProvider.DeepLoad(transactionManager, entity.ShippingCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Country object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Country instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Country Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Country entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
						child.DestinationCountryCode = entity.Code;
					}
				
				if (entity.TaxRuleCollection.Count > 0 || entity.TaxRuleCollection.DeletedItems.Count > 0)
					DataRepository.TaxRuleProvider.DeepSave(transactionManager, entity.TaxRuleCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Shipping>
				if (CanDeepSave(entity, "List<Shipping>", "ShippingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Shipping child in entity.ShippingCollection)
					{
						child.DestinationCountryCode = entity.Code;
					}
				
				if (entity.ShippingCollection.Count > 0 || entity.ShippingCollection.DeletedItems.Count > 0)
					DataRepository.ShippingProvider.DeepSave(transactionManager, entity.ShippingCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				


						
			return true;
		}
		#endregion
	} // end class
	
	#region CountryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Country</c>
	///</summary>
	public enum CountryChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Country</c> as OneToMany for TaxRuleCollection
		///</summary>
		[ChildEntityType(typeof(TList<TaxRule>))]
		TaxRuleCollection,

		///<summary>
		/// Collection of <c>Country</c> as OneToMany for ShippingCollection
		///</summary>
		[ChildEntityType(typeof(TList<Shipping>))]
		ShippingCollection,
	}
	
	#endregion CountryChildEntityTypes
	
	#region CountryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Country"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryFilterBuilder : SqlFilterBuilder<CountryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryFilterBuilder class.
		/// </summary>
		public CountryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountryFilterBuilder
	
	#region CountryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Country"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountryParameterBuilder : ParameterizedSqlFilterBuilder<CountryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountryParameterBuilder class.
		/// </summary>
		public CountryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountryParameterBuilder
} // end namespace
