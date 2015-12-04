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
	/// This class is the base class for any <see cref="ProductAttributeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductAttributeProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.ProductAttribute, ZNode.Libraries.DataAccess.Entities.ProductAttributeKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductAttributeKey key)
		{
			return Delete(transactionManager, key.AttributeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="attributeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 attributeId)
		{
			return Delete(null, attributeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="attributeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 attributeId);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.ProductAttribute Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductAttributeKey key, int start, int pageLength)
		{
			return GetByAttributeId(transactionManager, key.AttributeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_Attribute index.
		/// </summary>
		/// <param name="attributeId"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAttribute"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductAttribute GetByAttributeId(System.Int32 attributeId)
		{
			int count = -1;
			return GetByAttributeId(null,attributeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Attribute index.
		/// </summary>
		/// <param name="attributeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAttribute"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductAttribute GetByAttributeId(System.Int32 attributeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAttributeId(null, attributeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Attribute index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="attributeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAttribute"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductAttribute GetByAttributeId(TransactionManager transactionManager, System.Int32 attributeId)
		{
			int count = -1;
			return GetByAttributeId(transactionManager, attributeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Attribute index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="attributeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAttribute"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductAttribute GetByAttributeId(TransactionManager transactionManager, System.Int32 attributeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAttributeId(transactionManager, attributeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Attribute index.
		/// </summary>
		/// <param name="attributeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAttribute"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductAttribute GetByAttributeId(System.Int32 attributeId, int start, int pageLength, out int count)
		{
			return GetByAttributeId(null, attributeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Attribute index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="attributeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAttribute"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.ProductAttribute GetByAttributeId(TransactionManager transactionManager, System.Int32 attributeId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_1 index.
		/// </summary>
		/// <param name="attributeTypeId"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ProductAttribute&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductAttribute> GetByAttributeTypeId(System.Int32 attributeTypeId)
		{
			int count = -1;
			return GetByAttributeTypeId(null,attributeTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_1 index.
		/// </summary>
		/// <param name="attributeTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ProductAttribute&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductAttribute> GetByAttributeTypeId(System.Int32 attributeTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAttributeTypeId(null, attributeTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="attributeTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ProductAttribute&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductAttribute> GetByAttributeTypeId(TransactionManager transactionManager, System.Int32 attributeTypeId)
		{
			int count = -1;
			return GetByAttributeTypeId(transactionManager, attributeTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="attributeTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ProductAttribute&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductAttribute> GetByAttributeTypeId(TransactionManager transactionManager, System.Int32 attributeTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAttributeTypeId(transactionManager, attributeTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_1 index.
		/// </summary>
		/// <param name="attributeTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ProductAttribute&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductAttribute> GetByAttributeTypeId(System.Int32 attributeTypeId, int start, int pageLength, out int count)
		{
			return GetByAttributeTypeId(null, attributeTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="attributeTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ProductAttribute&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<ProductAttribute> GetByAttributeTypeId(TransactionManager transactionManager, System.Int32 attributeTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;ProductAttribute&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ProductAttribute&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<ProductAttribute> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<ProductAttribute> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.ProductAttribute c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ProductAttribute" 
							+ (reader.IsDBNull(reader.GetOrdinal("AttributeId"))?(int)0:(System.Int32)reader["AttributeId"]).ToString();

					c = EntityManager.LocateOrCreate<ProductAttribute>(
						key.ToString(), // EntityTrackingKey 
						"ProductAttribute",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.ProductAttribute();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.AttributeId = (System.Int32)reader["AttributeId"];
					c.AttributeTypeId = (System.Int32)reader["AttributeTypeId"];
					c.Name = (System.String)reader["Name"];
					c.ExternalId = (reader.IsDBNull(reader.GetOrdinal("ExternalId")))?null:(System.String)reader["ExternalId"];
					c.DisplayOrder = (System.Int32)reader["DisplayOrder"];
					c.IsActive = (System.Boolean)reader["IsActive"];
					c.OldAttributeId = (reader.IsDBNull(reader.GetOrdinal("OldAttributeId")))?null:(System.Int32?)reader["OldAttributeId"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAttribute"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductAttribute"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.ProductAttribute entity)
		{
			if (!reader.Read()) return;
			
			entity.AttributeId = (System.Int32)reader["AttributeId"];
			entity.AttributeTypeId = (System.Int32)reader["AttributeTypeId"];
			entity.Name = (System.String)reader["Name"];
			entity.ExternalId = (reader.IsDBNull(reader.GetOrdinal("ExternalId")))?null:(System.String)reader["ExternalId"];
			entity.DisplayOrder = (System.Int32)reader["DisplayOrder"];
			entity.IsActive = (System.Boolean)reader["IsActive"];
			entity.OldAttributeId = (reader.IsDBNull(reader.GetOrdinal("OldAttributeId")))?null:(System.Int32?)reader["OldAttributeId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAttribute"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductAttribute"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.ProductAttribute entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AttributeId = (System.Int32)dataRow["AttributeId"];
			entity.AttributeTypeId = (System.Int32)dataRow["AttributeTypeId"];
			entity.Name = (System.String)dataRow["Name"];
			entity.ExternalId = (Convert.IsDBNull(dataRow["ExternalId"]))?null:(System.String)dataRow["ExternalId"];
			entity.DisplayOrder = (System.Int32)dataRow["DisplayOrder"];
			entity.IsActive = (System.Boolean)dataRow["IsActive"];
			entity.OldAttributeId = (Convert.IsDBNull(dataRow["OldAttributeId"]))?null:(System.Int32?)dataRow["OldAttributeId"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductAttribute"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ProductAttribute Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductAttribute entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByAttributeId methods when available
			
			#region SKUAttributeCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SKUAttribute>", "SKUAttributeCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'SKUAttributeCollection' loaded.");
				#endif 

				entity.SKUAttributeCollection = DataRepository.SKUAttributeProvider.GetByAttributeId(transactionManager, entity.AttributeId);

				if (deep && entity.SKUAttributeCollection.Count > 0)
				{
					DataRepository.SKUAttributeProvider.DeepLoad(transactionManager, entity.SKUAttributeCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.ProductAttribute object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.ProductAttribute instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ProductAttribute Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductAttribute entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<SKUAttribute>
				if (CanDeepSave(entity, "List<SKUAttribute>", "SKUAttributeCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SKUAttribute child in entity.SKUAttributeCollection)
					{
						child.AttributeId = entity.AttributeId;
					}
				
				if (entity.SKUAttributeCollection.Count > 0 || entity.SKUAttributeCollection.DeletedItems.Count > 0)
					DataRepository.SKUAttributeProvider.DeepSave(transactionManager, entity.SKUAttributeCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region ProductAttributeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.ProductAttribute</c>
	///</summary>
	public enum ProductAttributeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ProductAttribute</c> as OneToMany for SKUAttributeCollection
		///</summary>
		[ChildEntityType(typeof(TList<SKUAttribute>))]
		SKUAttributeCollection,
	}
	
	#endregion ProductAttributeChildEntityTypes
	
	#region ProductAttributeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductAttribute"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductAttributeFilterBuilder : SqlFilterBuilder<ProductAttributeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductAttributeFilterBuilder class.
		/// </summary>
		public ProductAttributeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductAttributeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductAttributeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductAttributeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductAttributeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductAttributeFilterBuilder
	
	#region ProductAttributeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductAttribute"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductAttributeParameterBuilder : ParameterizedSqlFilterBuilder<ProductAttributeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductAttributeParameterBuilder class.
		/// </summary>
		public ProductAttributeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductAttributeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductAttributeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductAttributeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductAttributeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductAttributeParameterBuilder
} // end namespace
