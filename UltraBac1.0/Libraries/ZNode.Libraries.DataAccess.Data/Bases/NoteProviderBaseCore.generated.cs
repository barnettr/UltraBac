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
	/// This class is the base class for any <see cref="NoteProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class NoteProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Note, ZNode.Libraries.DataAccess.Entities.NoteKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.NoteKey key)
		{
			return Delete(transactionManager, key.NoteID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="noteID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 noteID)
		{
			return Delete(null, noteID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="noteID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 noteID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Note_SC_Account key.
		///		FK_SC_Note_SC_Account Description: 
		/// </summary>
		/// <param name="accountID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Note objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Note> GetByAccountID(System.Int32? accountID)
		{
			int count = -1;
			return GetByAccountID(accountID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Note_SC_Account key.
		///		FK_SC_Note_SC_Account Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Note objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Note> GetByAccountID(TransactionManager transactionManager, System.Int32? accountID)
		{
			int count = -1;
			return GetByAccountID(transactionManager, accountID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Note_SC_Account key.
		///		FK_SC_Note_SC_Account Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Note objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Note> GetByAccountID(TransactionManager transactionManager, System.Int32? accountID, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountID(transactionManager, accountID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Note_SC_Account key.
		///		fKSCNoteSCAccount Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="accountID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Note objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Note> GetByAccountID(System.Int32? accountID, int start, int pageLength)
		{
			int count =  -1;
			return GetByAccountID(null, accountID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Note_SC_Account key.
		///		fKSCNoteSCAccount Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="accountID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Note objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Note> GetByAccountID(System.Int32? accountID, int start, int pageLength,out int count)
		{
			return GetByAccountID(null, accountID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Note_SC_Account key.
		///		FK_SC_Note_SC_Account Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Note objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Note> GetByAccountID(TransactionManager transactionManager, System.Int32? accountID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.Note Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.NoteKey key, int start, int pageLength)
		{
			return GetByNoteID(transactionManager, key.NoteID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_AccountNote index.
		/// </summary>
		/// <param name="noteID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Note"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Note GetByNoteID(System.Int32 noteID)
		{
			int count = -1;
			return GetByNoteID(null,noteID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AccountNote index.
		/// </summary>
		/// <param name="noteID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Note"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Note GetByNoteID(System.Int32 noteID, int start, int pageLength)
		{
			int count = -1;
			return GetByNoteID(null, noteID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AccountNote index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="noteID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Note"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Note GetByNoteID(TransactionManager transactionManager, System.Int32 noteID)
		{
			int count = -1;
			return GetByNoteID(transactionManager, noteID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AccountNote index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="noteID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Note"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Note GetByNoteID(TransactionManager transactionManager, System.Int32 noteID, int start, int pageLength)
		{
			int count = -1;
			return GetByNoteID(transactionManager, noteID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AccountNote index.
		/// </summary>
		/// <param name="noteID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Note"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Note GetByNoteID(System.Int32 noteID, int start, int pageLength, out int count)
		{
			return GetByNoteID(null, noteID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AccountNote index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="noteID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Note"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Note GetByNoteID(TransactionManager transactionManager, System.Int32 noteID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IN1 index.
		/// </summary>
		/// <param name="caseID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Note&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Note> GetByCaseID(System.Int32? caseID)
		{
			int count = -1;
			return GetByCaseID(null,caseID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IN1 index.
		/// </summary>
		/// <param name="caseID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Note&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Note> GetByCaseID(System.Int32? caseID, int start, int pageLength)
		{
			int count = -1;
			return GetByCaseID(null, caseID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IN1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Note&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Note> GetByCaseID(TransactionManager transactionManager, System.Int32? caseID)
		{
			int count = -1;
			return GetByCaseID(transactionManager, caseID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IN1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Note&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Note> GetByCaseID(TransactionManager transactionManager, System.Int32? caseID, int start, int pageLength)
		{
			int count = -1;
			return GetByCaseID(transactionManager, caseID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IN1 index.
		/// </summary>
		/// <param name="caseID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Note&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Note> GetByCaseID(System.Int32? caseID, int start, int pageLength, out int count)
		{
			return GetByCaseID(null, caseID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IN1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Note&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Note> GetByCaseID(TransactionManager transactionManager, System.Int32? caseID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Note&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Note&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Note> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Note> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.Note c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Note" 
							+ (reader.IsDBNull(reader.GetOrdinal("NoteID"))?(int)0:(System.Int32)reader["NoteID"]).ToString();

					c = EntityManager.LocateOrCreate<Note>(
						key.ToString(), // EntityTrackingKey 
						"Note",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Note();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.NoteID = (System.Int32)reader["NoteID"];
					c.CaseID = (reader.IsDBNull(reader.GetOrdinal("CaseID")))?null:(System.Int32?)reader["CaseID"];
					c.AccountID = (reader.IsDBNull(reader.GetOrdinal("AccountID")))?null:(System.Int32?)reader["AccountID"];
					c.NoteTitle = (System.String)reader["NoteTitle"];
					c.NoteBody = (reader.IsDBNull(reader.GetOrdinal("NoteBody")))?null:(System.String)reader["NoteBody"];
					c.CreateDte = (System.DateTime)reader["CreateDte"];
					c.CreateUser = (System.String)reader["CreateUser"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Note"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Note"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Note entity)
		{
			if (!reader.Read()) return;
			
			entity.NoteID = (System.Int32)reader["NoteID"];
			entity.CaseID = (reader.IsDBNull(reader.GetOrdinal("CaseID")))?null:(System.Int32?)reader["CaseID"];
			entity.AccountID = (reader.IsDBNull(reader.GetOrdinal("AccountID")))?null:(System.Int32?)reader["AccountID"];
			entity.NoteTitle = (System.String)reader["NoteTitle"];
			entity.NoteBody = (reader.IsDBNull(reader.GetOrdinal("NoteBody")))?null:(System.String)reader["NoteBody"];
			entity.CreateDte = (System.DateTime)reader["CreateDte"];
			entity.CreateUser = (System.String)reader["CreateUser"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Note"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Note"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Note entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.NoteID = (System.Int32)dataRow["NoteID"];
			entity.CaseID = (Convert.IsDBNull(dataRow["CaseID"]))?null:(System.Int32?)dataRow["CaseID"];
			entity.AccountID = (Convert.IsDBNull(dataRow["AccountID"]))?null:(System.Int32?)dataRow["AccountID"];
			entity.NoteTitle = (System.String)dataRow["NoteTitle"];
			entity.NoteBody = (Convert.IsDBNull(dataRow["NoteBody"]))?null:(System.String)dataRow["NoteBody"];
			entity.CreateDte = (System.DateTime)dataRow["CreateDte"];
			entity.CreateUser = (System.String)dataRow["CreateUser"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Note"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Note Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Note entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region AccountIDSource	
			if (CanDeepLoad(entity, "Account", "AccountIDSource", deepLoadType, innerList) 
				&& entity.AccountIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AccountID ?? (int)0);
				Account tmpEntity = EntityManager.LocateEntity<Account>(EntityLocator.ConstructKeyFromPkItems(typeof(Account), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AccountIDSource = tmpEntity;
				else
					entity.AccountIDSource = DataRepository.AccountProvider.GetByAccountID((entity.AccountID ?? (int)0));
			
				if (deep && entity.AccountIDSource != null)
				{
					DataRepository.AccountProvider.DeepLoad(transactionManager, entity.AccountIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion AccountIDSource

			#region CaseIDSource	
			if (CanDeepLoad(entity, "Case", "CaseIDSource", deepLoadType, innerList) 
				&& entity.CaseIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CaseID ?? (int)0);
				Case tmpEntity = EntityManager.LocateEntity<Case>(EntityLocator.ConstructKeyFromPkItems(typeof(Case), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CaseIDSource = tmpEntity;
				else
					entity.CaseIDSource = DataRepository.CaseProvider.GetByCaseID((entity.CaseID ?? (int)0));
			
				if (deep && entity.CaseIDSource != null)
				{
					DataRepository.CaseProvider.DeepLoad(transactionManager, entity.CaseIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion CaseIDSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Note object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Note instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Note Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Note entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AccountIDSource
			if (CanDeepSave(entity, "Account", "AccountIDSource", deepSaveType, innerList) 
				&& entity.AccountIDSource != null)
			{
				DataRepository.AccountProvider.Save(transactionManager, entity.AccountIDSource);
				entity.AccountID = entity.AccountIDSource.AccountID;
			}
			#endregion 
			
			#region CaseIDSource
			if (CanDeepSave(entity, "Case", "CaseIDSource", deepSaveType, innerList) 
				&& entity.CaseIDSource != null)
			{
				DataRepository.CaseProvider.Save(transactionManager, entity.CaseIDSource);
				entity.CaseID = entity.CaseIDSource.CaseID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region NoteChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Note</c>
	///</summary>
	public enum NoteChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Account</c> at AccountIDSource
		///</summary>
		[ChildEntityType(typeof(Account))]
		Account,
			
		///<summary>
		/// Composite Property for <c>Case</c> at CaseIDSource
		///</summary>
		[ChildEntityType(typeof(Case))]
		Case,
		}
	
	#endregion NoteChildEntityTypes
	
	#region NoteFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Note"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NoteFilterBuilder : SqlFilterBuilder<NoteColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NoteFilterBuilder class.
		/// </summary>
		public NoteFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NoteFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NoteFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NoteFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NoteFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NoteFilterBuilder
	
	#region NoteParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Note"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NoteParameterBuilder : ParameterizedSqlFilterBuilder<NoteColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NoteParameterBuilder class.
		/// </summary>
		public NoteParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the NoteParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NoteParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NoteParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NoteParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NoteParameterBuilder
} // end namespace
