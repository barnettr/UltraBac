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
	/// This class is the base class for any <see cref="ManufacturerProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ManufacturerProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Manufacturer, ZNode.Libraries.DataAccess.Entities.ManufacturerKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ManufacturerKey key)
		{
			return Delete(transactionManager, key.ManufacturerID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="manufacturerID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 manufacturerID)
		{
			return Delete(null, manufacturerID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="manufacturerID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 manufacturerID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Manufacturer_Portals key.
		///		FK_SC_Manufacturer_Portals Description: 
		/// </summary>
		/// <param name="portalID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Manufacturer objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Manufacturer> GetByPortalID(System.Int32? portalID)
		{
			int count = -1;
			return GetByPortalID(portalID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Manufacturer_Portals key.
		///		FK_SC_Manufacturer_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Manufacturer objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Manufacturer> GetByPortalID(TransactionManager transactionManager, System.Int32? portalID)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Manufacturer_Portals key.
		///		FK_SC_Manufacturer_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Manufacturer objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Manufacturer> GetByPortalID(TransactionManager transactionManager, System.Int32? portalID, int start, int pageLength)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Manufacturer_Portals key.
		///		fKSCManufacturerPortals Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Manufacturer objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Manufacturer> GetByPortalID(System.Int32? portalID, int start, int pageLength)
		{
			int count =  -1;
			return GetByPortalID(null, portalID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Manufacturer_Portals key.
		///		fKSCManufacturerPortals Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Manufacturer objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Manufacturer> GetByPortalID(System.Int32? portalID, int start, int pageLength,out int count)
		{
			return GetByPortalID(null, portalID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Manufacturer_Portals key.
		///		FK_SC_Manufacturer_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Manufacturer objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Manufacturer> GetByPortalID(TransactionManager transactionManager, System.Int32? portalID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.Manufacturer Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ManufacturerKey key, int start, int pageLength)
		{
			return GetByManufacturerID(transactionManager, key.ManufacturerID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_Manufacturer index.
		/// </summary>
		/// <param name="manufacturerID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Manufacturer"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Manufacturer GetByManufacturerID(System.Int32 manufacturerID)
		{
			int count = -1;
			return GetByManufacturerID(null,manufacturerID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Manufacturer index.
		/// </summary>
		/// <param name="manufacturerID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Manufacturer"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Manufacturer GetByManufacturerID(System.Int32 manufacturerID, int start, int pageLength)
		{
			int count = -1;
			return GetByManufacturerID(null, manufacturerID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Manufacturer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="manufacturerID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Manufacturer"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Manufacturer GetByManufacturerID(TransactionManager transactionManager, System.Int32 manufacturerID)
		{
			int count = -1;
			return GetByManufacturerID(transactionManager, manufacturerID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Manufacturer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="manufacturerID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Manufacturer"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Manufacturer GetByManufacturerID(TransactionManager transactionManager, System.Int32 manufacturerID, int start, int pageLength)
		{
			int count = -1;
			return GetByManufacturerID(transactionManager, manufacturerID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Manufacturer index.
		/// </summary>
		/// <param name="manufacturerID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Manufacturer"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Manufacturer GetByManufacturerID(System.Int32 manufacturerID, int start, int pageLength, out int count)
		{
			return GetByManufacturerID(null, manufacturerID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Manufacturer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="manufacturerID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Manufacturer"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Manufacturer GetByManufacturerID(TransactionManager transactionManager, System.Int32 manufacturerID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Manufacturer&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Manufacturer&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Manufacturer> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Manufacturer> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.Manufacturer c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Manufacturer" 
							+ (reader.IsDBNull(reader.GetOrdinal("ManufacturerID"))?(int)0:(System.Int32)reader["ManufacturerID"]).ToString();

					c = EntityManager.LocateOrCreate<Manufacturer>(
						key.ToString(), // EntityTrackingKey 
						"Manufacturer",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Manufacturer();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ManufacturerID = (System.Int32)reader["ManufacturerID"];
					c.PortalID = (reader.IsDBNull(reader.GetOrdinal("PortalID")))?null:(System.Int32?)reader["PortalID"];
					c.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.ActiveInd = (System.Boolean)reader["ActiveInd"];
					c.Custom1 = (reader.IsDBNull(reader.GetOrdinal("Custom1")))?null:(System.String)reader["Custom1"];
					c.Custom2 = (reader.IsDBNull(reader.GetOrdinal("Custom2")))?null:(System.String)reader["Custom2"];
					c.Custom3 = (reader.IsDBNull(reader.GetOrdinal("Custom3")))?null:(System.String)reader["Custom3"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Manufacturer"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Manufacturer"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Manufacturer entity)
		{
			if (!reader.Read()) return;
			
			entity.ManufacturerID = (System.Int32)reader["ManufacturerID"];
			entity.PortalID = (reader.IsDBNull(reader.GetOrdinal("PortalID")))?null:(System.Int32?)reader["PortalID"];
			entity.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.ActiveInd = (System.Boolean)reader["ActiveInd"];
			entity.Custom1 = (reader.IsDBNull(reader.GetOrdinal("Custom1")))?null:(System.String)reader["Custom1"];
			entity.Custom2 = (reader.IsDBNull(reader.GetOrdinal("Custom2")))?null:(System.String)reader["Custom2"];
			entity.Custom3 = (reader.IsDBNull(reader.GetOrdinal("Custom3")))?null:(System.String)reader["Custom3"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Manufacturer"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Manufacturer"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Manufacturer entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ManufacturerID = (System.Int32)dataRow["ManufacturerID"];
			entity.PortalID = (Convert.IsDBNull(dataRow["PortalID"]))?null:(System.Int32?)dataRow["PortalID"];
			entity.Name = (Convert.IsDBNull(dataRow["Name"]))?null:(System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.ActiveInd = (System.Boolean)dataRow["ActiveInd"];
			entity.Custom1 = (Convert.IsDBNull(dataRow["Custom1"]))?null:(System.String)dataRow["Custom1"];
			entity.Custom2 = (Convert.IsDBNull(dataRow["Custom2"]))?null:(System.String)dataRow["Custom2"];
			entity.Custom3 = (Convert.IsDBNull(dataRow["Custom3"]))?null:(System.String)dataRow["Custom3"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Manufacturer"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Manufacturer Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Manufacturer entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region PortalIDSource	
			if (CanDeepLoad(entity, "Portal", "PortalIDSource", deepLoadType, innerList) 
				&& entity.PortalIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.PortalID ?? (int)0);
				Portal tmpEntity = EntityManager.LocateEntity<Portal>(EntityLocator.ConstructKeyFromPkItems(typeof(Portal), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PortalIDSource = tmpEntity;
				else
					entity.PortalIDSource = DataRepository.PortalProvider.GetByPortalID((entity.PortalID ?? (int)0));
			
				if (deep && entity.PortalIDSource != null)
				{
					DataRepository.PortalProvider.DeepLoad(transactionManager, entity.PortalIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion PortalIDSource
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByManufacturerID methods when available
			
			#region ProductCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Product>", "ProductCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProductCollection' loaded.");
				#endif 

				entity.ProductCollection = DataRepository.ProductProvider.GetByManufacturerID(transactionManager, entity.ManufacturerID);

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
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Manufacturer object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Manufacturer instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Manufacturer Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Manufacturer entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<Product>
				if (CanDeepSave(entity, "List<Product>", "ProductCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Product child in entity.ProductCollection)
					{
						child.ManufacturerID = entity.ManufacturerID;
					}
				
				if (entity.ProductCollection.Count > 0 || entity.ProductCollection.DeletedItems.Count > 0)
					DataRepository.ProductProvider.DeepSave(transactionManager, entity.ProductCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region ManufacturerChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Manufacturer</c>
	///</summary>
	public enum ManufacturerChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Portal</c> at PortalIDSource
		///</summary>
		[ChildEntityType(typeof(Portal))]
		Portal,
	
		///<summary>
		/// Collection of <c>Manufacturer</c> as OneToMany for ProductCollection
		///</summary>
		[ChildEntityType(typeof(TList<Product>))]
		ProductCollection,
	}
	
	#endregion ManufacturerChildEntityTypes
	
	#region ManufacturerFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Manufacturer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ManufacturerFilterBuilder : SqlFilterBuilder<ManufacturerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ManufacturerFilterBuilder class.
		/// </summary>
		public ManufacturerFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ManufacturerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ManufacturerFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ManufacturerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ManufacturerFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ManufacturerFilterBuilder
	
	#region ManufacturerParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Manufacturer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ManufacturerParameterBuilder : ParameterizedSqlFilterBuilder<ManufacturerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ManufacturerParameterBuilder class.
		/// </summary>
		public ManufacturerParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ManufacturerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ManufacturerParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ManufacturerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ManufacturerParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ManufacturerParameterBuilder
} // end namespace
