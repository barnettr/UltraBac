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
	/// This class is the base class for any <see cref="CaseProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CaseProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Case, ZNode.Libraries.DataAccess.Entities.CaseKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.CaseKey key)
		{
			return Delete(transactionManager, key.CaseID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="caseID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 caseID)
		{
			return Delete(null, caseID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 caseID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Case_Portals key.
		///		FK_Case_Portals Description: 
		/// </summary>
		/// <param name="portalID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByPortalID(System.Int32 portalID)
		{
			int count = -1;
			return GetByPortalID(portalID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Case_Portals key.
		///		FK_Case_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Case_Portals key.
		///		FK_Case_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Case_Portals key.
		///		fKCasePortals Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByPortalID(System.Int32 portalID, int start, int pageLength)
		{
			int count =  -1;
			return GetByPortalID(null, portalID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Case_Portals key.
		///		fKCasePortals Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByPortalID(System.Int32 portalID, int start, int pageLength,out int count)
		{
			return GetByPortalID(null, portalID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Case_Portals key.
		///		FK_Case_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Case> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Case_SC_Account key.
		///		FK_SC_Case_SC_Account Description: 
		/// </summary>
		/// <param name="accountID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByAccountID(System.Int32? accountID)
		{
			int count = -1;
			return GetByAccountID(accountID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Case_SC_Account key.
		///		FK_SC_Case_SC_Account Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByAccountID(TransactionManager transactionManager, System.Int32? accountID)
		{
			int count = -1;
			return GetByAccountID(transactionManager, accountID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Case_SC_Account key.
		///		FK_SC_Case_SC_Account Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByAccountID(TransactionManager transactionManager, System.Int32? accountID, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountID(transactionManager, accountID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Case_SC_Account key.
		///		fKSCCaseSCAccount Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="accountID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByAccountID(System.Int32? accountID, int start, int pageLength)
		{
			int count =  -1;
			return GetByAccountID(null, accountID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Case_SC_Account key.
		///		fKSCCaseSCAccount Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="accountID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByAccountID(System.Int32? accountID, int start, int pageLength,out int count)
		{
			return GetByAccountID(null, accountID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Case_SC_Account key.
		///		FK_SC_Case_SC_Account Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Case> GetByAccountID(TransactionManager transactionManager, System.Int32? accountID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Case_CaseType key.
		///		FK_Case_CaseType Description: 
		/// </summary>
		/// <param name="caseTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCaseTypeID(System.Int32 caseTypeID)
		{
			int count = -1;
			return GetByCaseTypeID(caseTypeID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Case_CaseType key.
		///		FK_Case_CaseType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCaseTypeID(TransactionManager transactionManager, System.Int32 caseTypeID)
		{
			int count = -1;
			return GetByCaseTypeID(transactionManager, caseTypeID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Case_CaseType key.
		///		FK_Case_CaseType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCaseTypeID(TransactionManager transactionManager, System.Int32 caseTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByCaseTypeID(transactionManager, caseTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Case_CaseType key.
		///		fKCaseCaseType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="caseTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCaseTypeID(System.Int32 caseTypeID, int start, int pageLength)
		{
			int count =  -1;
			return GetByCaseTypeID(null, caseTypeID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Case_CaseType key.
		///		fKCaseCaseType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="caseTypeID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCaseTypeID(System.Int32 caseTypeID, int start, int pageLength,out int count)
		{
			return GetByCaseTypeID(null, caseTypeID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Case_CaseType key.
		///		FK_Case_CaseType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCaseTypeID(TransactionManager transactionManager, System.Int32 caseTypeID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Case_SC_CasePriority key.
		///		FK_SC_Case_SC_CasePriority Description: 
		/// </summary>
		/// <param name="casePriorityID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCasePriorityID(System.Int32 casePriorityID)
		{
			int count = -1;
			return GetByCasePriorityID(casePriorityID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Case_SC_CasePriority key.
		///		FK_SC_Case_SC_CasePriority Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="casePriorityID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCasePriorityID(TransactionManager transactionManager, System.Int32 casePriorityID)
		{
			int count = -1;
			return GetByCasePriorityID(transactionManager, casePriorityID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Case_SC_CasePriority key.
		///		FK_SC_Case_SC_CasePriority Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="casePriorityID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCasePriorityID(TransactionManager transactionManager, System.Int32 casePriorityID, int start, int pageLength)
		{
			int count = -1;
			return GetByCasePriorityID(transactionManager, casePriorityID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Case_SC_CasePriority key.
		///		fKSCCaseSCCasePriority Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="casePriorityID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCasePriorityID(System.Int32 casePriorityID, int start, int pageLength)
		{
			int count =  -1;
			return GetByCasePriorityID(null, casePriorityID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Case_SC_CasePriority key.
		///		fKSCCaseSCCasePriority Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="casePriorityID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCasePriorityID(System.Int32 casePriorityID, int start, int pageLength,out int count)
		{
			return GetByCasePriorityID(null, casePriorityID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Case_SC_CasePriority key.
		///		FK_SC_Case_SC_CasePriority Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="casePriorityID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Case objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCasePriorityID(TransactionManager transactionManager, System.Int32 casePriorityID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.Case Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.CaseKey key, int start, int pageLength)
		{
			return GetByCaseID(transactionManager, key.CaseID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Case index.
		/// </summary>
		/// <param name="caseID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Case"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Case GetByCaseID(System.Int32 caseID)
		{
			int count = -1;
			return GetByCaseID(null,caseID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Case index.
		/// </summary>
		/// <param name="caseID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Case"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Case GetByCaseID(System.Int32 caseID, int start, int pageLength)
		{
			int count = -1;
			return GetByCaseID(null, caseID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Case index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Case"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Case GetByCaseID(TransactionManager transactionManager, System.Int32 caseID)
		{
			int count = -1;
			return GetByCaseID(transactionManager, caseID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Case index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Case"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Case GetByCaseID(TransactionManager transactionManager, System.Int32 caseID, int start, int pageLength)
		{
			int count = -1;
			return GetByCaseID(transactionManager, caseID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Case index.
		/// </summary>
		/// <param name="caseID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Case"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Case GetByCaseID(System.Int32 caseID, int start, int pageLength, out int count)
		{
			return GetByCaseID(null, caseID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Case index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Case"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Case GetByCaseID(TransactionManager transactionManager, System.Int32 caseID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX4 index.
		/// </summary>
		/// <param name="accountID"></param>
		/// <param name="caseTypeID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByAccountIDCaseTypeID(System.Int32? accountID, System.Int32 caseTypeID)
		{
			int count = -1;
			return GetByAccountIDCaseTypeID(null,accountID, caseTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX4 index.
		/// </summary>
		/// <param name="accountID"></param>
		/// <param name="caseTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByAccountIDCaseTypeID(System.Int32? accountID, System.Int32 caseTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountIDCaseTypeID(null, accountID, caseTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID"></param>
		/// <param name="caseTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByAccountIDCaseTypeID(TransactionManager transactionManager, System.Int32? accountID, System.Int32 caseTypeID)
		{
			int count = -1;
			return GetByAccountIDCaseTypeID(transactionManager, accountID, caseTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID"></param>
		/// <param name="caseTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByAccountIDCaseTypeID(TransactionManager transactionManager, System.Int32? accountID, System.Int32 caseTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountIDCaseTypeID(transactionManager, accountID, caseTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX4 index.
		/// </summary>
		/// <param name="accountID"></param>
		/// <param name="caseTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByAccountIDCaseTypeID(System.Int32? accountID, System.Int32 caseTypeID, int start, int pageLength, out int count)
		{
			return GetByAccountIDCaseTypeID(null, accountID, caseTypeID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX4 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID"></param>
		/// <param name="caseTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Case> GetByAccountIDCaseTypeID(TransactionManager transactionManager, System.Int32? accountID, System.Int32 caseTypeID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX1 index.
		/// </summary>
		/// <param name="ownerAccountID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByOwnerAccountID(System.Int32? ownerAccountID)
		{
			int count = -1;
			return GetByOwnerAccountID(null,ownerAccountID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="ownerAccountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByOwnerAccountID(System.Int32? ownerAccountID, int start, int pageLength)
		{
			int count = -1;
			return GetByOwnerAccountID(null, ownerAccountID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="ownerAccountID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByOwnerAccountID(TransactionManager transactionManager, System.Int32? ownerAccountID)
		{
			int count = -1;
			return GetByOwnerAccountID(transactionManager, ownerAccountID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="ownerAccountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByOwnerAccountID(TransactionManager transactionManager, System.Int32? ownerAccountID, int start, int pageLength)
		{
			int count = -1;
			return GetByOwnerAccountID(transactionManager, ownerAccountID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="ownerAccountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByOwnerAccountID(System.Int32? ownerAccountID, int start, int pageLength, out int count)
		{
			return GetByOwnerAccountID(null, ownerAccountID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="ownerAccountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Case> GetByOwnerAccountID(TransactionManager transactionManager, System.Int32? ownerAccountID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX3 index.
		/// </summary>
		/// <param name="caseStatusID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCaseStatusID(System.Int32 caseStatusID)
		{
			int count = -1;
			return GetByCaseStatusID(null,caseStatusID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX3 index.
		/// </summary>
		/// <param name="caseStatusID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCaseStatusID(System.Int32 caseStatusID, int start, int pageLength)
		{
			int count = -1;
			return GetByCaseStatusID(null, caseStatusID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX3 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseStatusID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCaseStatusID(TransactionManager transactionManager, System.Int32 caseStatusID)
		{
			int count = -1;
			return GetByCaseStatusID(transactionManager, caseStatusID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX3 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseStatusID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCaseStatusID(TransactionManager transactionManager, System.Int32 caseStatusID, int start, int pageLength)
		{
			int count = -1;
			return GetByCaseStatusID(transactionManager, caseStatusID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX3 index.
		/// </summary>
		/// <param name="caseStatusID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCaseStatusID(System.Int32 caseStatusID, int start, int pageLength, out int count)
		{
			return GetByCaseStatusID(null, caseStatusID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX3 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseStatusID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Case> GetByCaseStatusID(TransactionManager transactionManager, System.Int32 caseStatusID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX2 index.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="companyName"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByTitleFirstNameLastNameCompanyName(System.String title, System.String firstName, System.String lastName, System.String companyName)
		{
			int count = -1;
			return GetByTitleFirstNameLastNameCompanyName(null,title, firstName, lastName, companyName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX2 index.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="companyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByTitleFirstNameLastNameCompanyName(System.String title, System.String firstName, System.String lastName, System.String companyName, int start, int pageLength)
		{
			int count = -1;
			return GetByTitleFirstNameLastNameCompanyName(null, title, firstName, lastName, companyName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="title"></param>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="companyName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByTitleFirstNameLastNameCompanyName(TransactionManager transactionManager, System.String title, System.String firstName, System.String lastName, System.String companyName)
		{
			int count = -1;
			return GetByTitleFirstNameLastNameCompanyName(transactionManager, title, firstName, lastName, companyName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="title"></param>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="companyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByTitleFirstNameLastNameCompanyName(TransactionManager transactionManager, System.String title, System.String firstName, System.String lastName, System.String companyName, int start, int pageLength)
		{
			int count = -1;
			return GetByTitleFirstNameLastNameCompanyName(transactionManager, title, firstName, lastName, companyName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX2 index.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="companyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Case> GetByTitleFirstNameLastNameCompanyName(System.String title, System.String firstName, System.String lastName, System.String companyName, int start, int pageLength, out int count)
		{
			return GetByTitleFirstNameLastNameCompanyName(null, title, firstName, lastName, companyName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="title"></param>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="companyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Case> GetByTitleFirstNameLastNameCompanyName(TransactionManager transactionManager, System.String title, System.String firstName, System.String lastName, System.String companyName, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Case&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Case> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Case> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.Case c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Case" 
							+ (reader.IsDBNull(reader.GetOrdinal("CaseID"))?(int)0:(System.Int32)reader["CaseID"]).ToString();

					c = EntityManager.LocateOrCreate<Case>(
						key.ToString(), // EntityTrackingKey 
						"Case",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Case();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.CaseID = (System.Int32)reader["CaseID"];
					c.PortalID = (System.Int32)reader["PortalID"];
					c.AccountID = (reader.IsDBNull(reader.GetOrdinal("AccountID")))?null:(System.Int32?)reader["AccountID"];
					c.OwnerAccountID = (reader.IsDBNull(reader.GetOrdinal("OwnerAccountID")))?null:(System.Int32?)reader["OwnerAccountID"];
					c.CaseStatusID = (System.Int32)reader["CaseStatusID"];
					c.CasePriorityID = (System.Int32)reader["CasePriorityID"];
					c.CaseTypeID = (System.Int32)reader["CaseTypeID"];
					c.CaseOrigin = (reader.IsDBNull(reader.GetOrdinal("CaseOrigin")))?null:(System.String)reader["CaseOrigin"];
					c.Title = (System.String)reader["Title"];
					c.Description = (System.String)reader["Description"];
					c.FirstName = (reader.IsDBNull(reader.GetOrdinal("FirstName")))?null:(System.String)reader["FirstName"];
					c.LastName = (reader.IsDBNull(reader.GetOrdinal("LastName")))?null:(System.String)reader["LastName"];
					c.CompanyName = (reader.IsDBNull(reader.GetOrdinal("CompanyName")))?null:(System.String)reader["CompanyName"];
					c.EmailID = (reader.IsDBNull(reader.GetOrdinal("EmailID")))?null:(System.String)reader["EmailID"];
					c.PhoneNumber = (reader.IsDBNull(reader.GetOrdinal("PhoneNumber")))?null:(System.String)reader["PhoneNumber"];
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
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Case"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Case"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Case entity)
		{
			if (!reader.Read()) return;
			
			entity.CaseID = (System.Int32)reader["CaseID"];
			entity.PortalID = (System.Int32)reader["PortalID"];
			entity.AccountID = (reader.IsDBNull(reader.GetOrdinal("AccountID")))?null:(System.Int32?)reader["AccountID"];
			entity.OwnerAccountID = (reader.IsDBNull(reader.GetOrdinal("OwnerAccountID")))?null:(System.Int32?)reader["OwnerAccountID"];
			entity.CaseStatusID = (System.Int32)reader["CaseStatusID"];
			entity.CasePriorityID = (System.Int32)reader["CasePriorityID"];
			entity.CaseTypeID = (System.Int32)reader["CaseTypeID"];
			entity.CaseOrigin = (reader.IsDBNull(reader.GetOrdinal("CaseOrigin")))?null:(System.String)reader["CaseOrigin"];
			entity.Title = (System.String)reader["Title"];
			entity.Description = (System.String)reader["Description"];
			entity.FirstName = (reader.IsDBNull(reader.GetOrdinal("FirstName")))?null:(System.String)reader["FirstName"];
			entity.LastName = (reader.IsDBNull(reader.GetOrdinal("LastName")))?null:(System.String)reader["LastName"];
			entity.CompanyName = (reader.IsDBNull(reader.GetOrdinal("CompanyName")))?null:(System.String)reader["CompanyName"];
			entity.EmailID = (reader.IsDBNull(reader.GetOrdinal("EmailID")))?null:(System.String)reader["EmailID"];
			entity.PhoneNumber = (reader.IsDBNull(reader.GetOrdinal("PhoneNumber")))?null:(System.String)reader["PhoneNumber"];
			entity.CreateDte = (System.DateTime)reader["CreateDte"];
			entity.CreateUser = (System.String)reader["CreateUser"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Case"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Case"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Case entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CaseID = (System.Int32)dataRow["CaseID"];
			entity.PortalID = (System.Int32)dataRow["PortalID"];
			entity.AccountID = (Convert.IsDBNull(dataRow["AccountID"]))?null:(System.Int32?)dataRow["AccountID"];
			entity.OwnerAccountID = (Convert.IsDBNull(dataRow["OwnerAccountID"]))?null:(System.Int32?)dataRow["OwnerAccountID"];
			entity.CaseStatusID = (System.Int32)dataRow["CaseStatusID"];
			entity.CasePriorityID = (System.Int32)dataRow["CasePriorityID"];
			entity.CaseTypeID = (System.Int32)dataRow["CaseTypeID"];
			entity.CaseOrigin = (Convert.IsDBNull(dataRow["CaseOrigin"]))?null:(System.String)dataRow["CaseOrigin"];
			entity.Title = (System.String)dataRow["Title"];
			entity.Description = (System.String)dataRow["Description"];
			entity.FirstName = (Convert.IsDBNull(dataRow["FirstName"]))?null:(System.String)dataRow["FirstName"];
			entity.LastName = (Convert.IsDBNull(dataRow["LastName"]))?null:(System.String)dataRow["LastName"];
			entity.CompanyName = (Convert.IsDBNull(dataRow["CompanyName"]))?null:(System.String)dataRow["CompanyName"];
			entity.EmailID = (Convert.IsDBNull(dataRow["EmailID"]))?null:(System.String)dataRow["EmailID"];
			entity.PhoneNumber = (Convert.IsDBNull(dataRow["PhoneNumber"]))?null:(System.String)dataRow["PhoneNumber"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Case"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Case Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Case entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
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

			#region OwnerAccountIDSource	
			if (CanDeepLoad(entity, "Account", "OwnerAccountIDSource", deepLoadType, innerList) 
				&& entity.OwnerAccountIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.OwnerAccountID ?? (int)0);
				Account tmpEntity = EntityManager.LocateEntity<Account>(EntityLocator.ConstructKeyFromPkItems(typeof(Account), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.OwnerAccountIDSource = tmpEntity;
				else
					entity.OwnerAccountIDSource = DataRepository.AccountProvider.GetByAccountID((entity.OwnerAccountID ?? (int)0));
			
				if (deep && entity.OwnerAccountIDSource != null)
				{
					DataRepository.AccountProvider.DeepLoad(transactionManager, entity.OwnerAccountIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion OwnerAccountIDSource

			#region CaseTypeIDSource	
			if (CanDeepLoad(entity, "CaseType", "CaseTypeIDSource", deepLoadType, innerList) 
				&& entity.CaseTypeIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CaseTypeID;
				CaseType tmpEntity = EntityManager.LocateEntity<CaseType>(EntityLocator.ConstructKeyFromPkItems(typeof(CaseType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CaseTypeIDSource = tmpEntity;
				else
					entity.CaseTypeIDSource = DataRepository.CaseTypeProvider.GetByCaseTypeID(entity.CaseTypeID);
			
				if (deep && entity.CaseTypeIDSource != null)
				{
					DataRepository.CaseTypeProvider.DeepLoad(transactionManager, entity.CaseTypeIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion CaseTypeIDSource

			#region CaseStatusIDSource	
			if (CanDeepLoad(entity, "CaseStatus", "CaseStatusIDSource", deepLoadType, innerList) 
				&& entity.CaseStatusIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CaseStatusID;
				CaseStatus tmpEntity = EntityManager.LocateEntity<CaseStatus>(EntityLocator.ConstructKeyFromPkItems(typeof(CaseStatus), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CaseStatusIDSource = tmpEntity;
				else
					entity.CaseStatusIDSource = DataRepository.CaseStatusProvider.GetByCaseStatusID(entity.CaseStatusID);
			
				if (deep && entity.CaseStatusIDSource != null)
				{
					DataRepository.CaseStatusProvider.DeepLoad(transactionManager, entity.CaseStatusIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion CaseStatusIDSource

			#region CasePriorityIDSource	
			if (CanDeepLoad(entity, "CasePriority", "CasePriorityIDSource", deepLoadType, innerList) 
				&& entity.CasePriorityIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CasePriorityID;
				CasePriority tmpEntity = EntityManager.LocateEntity<CasePriority>(EntityLocator.ConstructKeyFromPkItems(typeof(CasePriority), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CasePriorityIDSource = tmpEntity;
				else
					entity.CasePriorityIDSource = DataRepository.CasePriorityProvider.GetByCasePriorityID(entity.CasePriorityID);
			
				if (deep && entity.CasePriorityIDSource != null)
				{
					DataRepository.CasePriorityProvider.DeepLoad(transactionManager, entity.CasePriorityIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion CasePriorityIDSource
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByCaseID methods when available
			
			#region NoteCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Note>", "NoteCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'NoteCollection' loaded.");
				#endif 

				entity.NoteCollection = DataRepository.NoteProvider.GetByCaseID(transactionManager, entity.CaseID);

				if (deep && entity.NoteCollection.Count > 0)
				{
					DataRepository.NoteProvider.DeepLoad(transactionManager, entity.NoteCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Case object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Case instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Case Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Case entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
			
			#region AccountIDSource
			if (CanDeepSave(entity, "Account", "AccountIDSource", deepSaveType, innerList) 
				&& entity.AccountIDSource != null)
			{
				DataRepository.AccountProvider.Save(transactionManager, entity.AccountIDSource);
				entity.AccountID = entity.AccountIDSource.AccountID;
			}
			#endregion 
			
			#region OwnerAccountIDSource
			if (CanDeepSave(entity, "Account", "OwnerAccountIDSource", deepSaveType, innerList) 
				&& entity.OwnerAccountIDSource != null)
			{
				DataRepository.AccountProvider.Save(transactionManager, entity.OwnerAccountIDSource);
				entity.OwnerAccountID = entity.OwnerAccountIDSource.AccountID;
			}
			#endregion 
			
			#region CaseTypeIDSource
			if (CanDeepSave(entity, "CaseType", "CaseTypeIDSource", deepSaveType, innerList) 
				&& entity.CaseTypeIDSource != null)
			{
				DataRepository.CaseTypeProvider.Save(transactionManager, entity.CaseTypeIDSource);
				entity.CaseTypeID = entity.CaseTypeIDSource.CaseTypeID;
			}
			#endregion 
			
			#region CaseStatusIDSource
			if (CanDeepSave(entity, "CaseStatus", "CaseStatusIDSource", deepSaveType, innerList) 
				&& entity.CaseStatusIDSource != null)
			{
				DataRepository.CaseStatusProvider.Save(transactionManager, entity.CaseStatusIDSource);
				entity.CaseStatusID = entity.CaseStatusIDSource.CaseStatusID;
			}
			#endregion 
			
			#region CasePriorityIDSource
			if (CanDeepSave(entity, "CasePriority", "CasePriorityIDSource", deepSaveType, innerList) 
				&& entity.CasePriorityIDSource != null)
			{
				DataRepository.CasePriorityProvider.Save(transactionManager, entity.CasePriorityIDSource);
				entity.CasePriorityID = entity.CasePriorityIDSource.CasePriorityID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<Note>
				if (CanDeepSave(entity, "List<Note>", "NoteCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Note child in entity.NoteCollection)
					{
						child.CaseID = entity.CaseID;
					}
				
				if (entity.NoteCollection.Count > 0 || entity.NoteCollection.DeletedItems.Count > 0)
					DataRepository.NoteProvider.DeepSave(transactionManager, entity.NoteCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region CaseChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Case</c>
	///</summary>
	public enum CaseChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Portal</c> at PortalIDSource
		///</summary>
		[ChildEntityType(typeof(Portal))]
		Portal,
			
		///<summary>
		/// Composite Property for <c>Account</c> at AccountIDSource
		///</summary>
		[ChildEntityType(typeof(Account))]
		Account,
			
		///<summary>
		/// Composite Property for <c>CaseType</c> at CaseTypeIDSource
		///</summary>
		[ChildEntityType(typeof(CaseType))]
		CaseType,
			
		///<summary>
		/// Composite Property for <c>CaseStatus</c> at CaseStatusIDSource
		///</summary>
		[ChildEntityType(typeof(CaseStatus))]
		CaseStatus,
			
		///<summary>
		/// Composite Property for <c>CasePriority</c> at CasePriorityIDSource
		///</summary>
		[ChildEntityType(typeof(CasePriority))]
		CasePriority,
	
		///<summary>
		/// Collection of <c>Case</c> as OneToMany for NoteCollection
		///</summary>
		[ChildEntityType(typeof(TList<Note>))]
		NoteCollection,
	}
	
	#endregion CaseChildEntityTypes
	
	#region CaseFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Case"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CaseFilterBuilder : SqlFilterBuilder<CaseColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CaseFilterBuilder class.
		/// </summary>
		public CaseFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CaseFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CaseFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CaseFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CaseFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CaseFilterBuilder
	
	#region CaseParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Case"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CaseParameterBuilder : ParameterizedSqlFilterBuilder<CaseColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CaseParameterBuilder class.
		/// </summary>
		public CaseParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CaseParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CaseParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CaseParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CaseParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CaseParameterBuilder
} // end namespace
