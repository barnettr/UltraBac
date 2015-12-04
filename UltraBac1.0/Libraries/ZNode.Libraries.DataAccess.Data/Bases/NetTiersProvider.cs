
#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using ZNode.Libraries.DataAccess.Entities;

#endregion

namespace ZNode.Libraries.DataAccess.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : System.Configuration.Provider.ProviderBase
	{
		private Type entityCreationalFactoryType = null;
        private static object syncObject = new object();
        private bool enableEntityTracking = true;
        private bool enableListTracking = false;
        private bool useEntityFactory = true;
		private bool enableMethodAuthorization = false;
        private int defaultCommandTimeout = 30;

	    /// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
        public override void Initialize(string name, NameValueCollection config)
	    {
	        base.Initialize(name, config);
	        
            string entityCreationalFactoryTypeString = config["entityFactoryType"];

	        lock(syncObject)
            {
                if (string.IsNullOrEmpty(entityCreationalFactoryTypeString))
				{
                    entityCreationalFactoryType = typeof(ZNode.Libraries.DataAccess.Entities.EntityFactory);
				}
				else
				{
					foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
					{
						if (assembly.FullName.Split(',')[0] == entityCreationalFactoryTypeString.Substring(0, entityCreationalFactoryTypeString.LastIndexOf('.')))
						{
							entityCreationalFactoryType = assembly.GetType(entityCreationalFactoryTypeString, false, true);
							break;
						}
					}
				}
				
                if (entityCreationalFactoryType == null)
                {
                    System.Reflection.Assembly entityLibrary = null;
                    //assembly still not found, try loading the assembly.  It's possible it's not referenced.
                    try
                    {
                        //entityLibrary = AppDomain.CurrentDomain.Load(string.Format("{0}.dll", entityCreationalFactoryType.Substring(0, entityCreationalFactoryType.LastIndexOf('.'))));
                        entityLibrary = System.Reflection.Assembly.Load(
                            entityCreationalFactoryTypeString.Substring(0, entityCreationalFactoryTypeString.LastIndexOf('.')));
                    }
                    catch
                    {
                        //throws file not found exception
                    }

                    if (entityLibrary != null)
                    {
                        entityCreationalFactoryType = entityLibrary.GetType(entityCreationalFactoryTypeString, false, true);
                    }
                }
                if (entityCreationalFactoryType == null)
                    throw new ArgumentNullException("Could not find a valid entity factory configured in assemblies.  .netTiers can not continue.");
                
                bool.TryParse(config["enableEntityTracking"], out this.enableEntityTracking);

                bool.TryParse(config["enableListTracking"], out this.enableListTracking);

                bool.TryParse(config["useEntityFactory"], out this.useEntityFactory);
				
				bool.TryParse(config["enableMethodAuthorization"], out this.enableMethodAuthorization);
				
				int.TryParse(config["defaultCommandTimeout"], out this.defaultCommandTimeout);
				
			}   
         }
	    
        /// <summary>
        /// Gets or sets the Creational Entity Factory Type.
        /// </summary>
        /// <value>The entity factory type.</value>
        public virtual Type EntityCreationalFactoryType
        {
            get
            {
                return entityCreationalFactoryType;
            }
            set
            {
                entityCreationalFactoryType = value;
            }
        }

        /// <summary>
        /// Gets or sets the ability to track entities.
        /// </summary>
        /// <value>true/false.</value>
        public virtual bool EnableEntityTracking
        {
            get
            {
                return enableEntityTracking;
            }
            set { enableEntityTracking = value; }
        }

        /// <summary>
        /// Gets or sets the Entity Factory Type.
        /// </summary>
        /// <value>The entity factory type.</value>
        public virtual bool EnableListTracking
        {
            get
            {
                return enableListTracking;
            }
            set 
            {
                enableListTracking = value; 
            }
        }

        /// <summary>
        /// Gets or sets the use entity factory property to enable the usage of the EntityFactory and it's type cache.
        /// </summary>
        /// <value>bool value</value>
        public virtual bool UseEntityFactory
        {
            get
            {
                return useEntityFactory;
            }
            set 
            {
                useEntityFactory = value; 
            }
        }

        /// <summary>
        /// Gets or sets the use Enable Method Authorization to enable the usage of the Microsoft Patterns and Practices 
		/// IAuthorizationRuleProvider for code level authorization.
		/// </summary>
        /// <value>A bool value.</value>
        public virtual bool EnableMethodAuthorization
        {
            get
            {
                return enableMethodAuthorization;
            }
            set 
            {
                enableMethodAuthorization = value; 
            }
        }

        /// <summary>
        /// Gets or sets the default timeout for every command
        /// </summary>
        /// <value>integer value in seconds.</value>
        public virtual int DefaultCommandTimeout
        {
            get
            {
                return defaultCommandTimeout;
            }
            set
            {
                defaultCommandTimeout = value;
            }
        }
		
		
		///<summary>
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation is supporting Transactions.
		///</summary>
		public abstract bool IsTransactionSupported{get;}
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public virtual TransactionManager CreateTransaction() {throw new NotSupportedException();}
		
		
		///<summary>
		/// Current PortalProviderBase instance.
		///</summary>
		public virtual PortalProviderBase PortalProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductTypeProviderBase instance.
		///</summary>
		public virtual ProductTypeProviderBase ProductTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductCrossSellProviderBase instance.
		///</summary>
		public virtual ProductCrossSellProviderBase ProductCrossSellProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductHighlightProviderBase instance.
		///</summary>
		public virtual ProductHighlightProviderBase ProductHighlightProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductImageProviderBase instance.
		///</summary>
		public virtual ProductImageProviderBase ProductImageProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductTypeAttributeProviderBase instance.
		///</summary>
		public virtual ProductTypeAttributeProviderBase ProductTypeAttributeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current PaymentTypeProviderBase instance.
		///</summary>
		public virtual PaymentTypeProviderBase PaymentTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductProviderBase instance.
		///</summary>
		public virtual ProductProviderBase ProductProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current PaymentSettingProviderBase instance.
		///</summary>
		public virtual PaymentSettingProviderBase PaymentSettingProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductAddOnProviderBase instance.
		///</summary>
		public virtual ProductAddOnProviderBase ProductAddOnProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductCategoryProviderBase instance.
		///</summary>
		public virtual ProductCategoryProviderBase ProductCategoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductAttributeProviderBase instance.
		///</summary>
		public virtual ProductAttributeProviderBase ProductAttributeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProfileProviderBase instance.
		///</summary>
		public virtual ProfileProviderBase ProfileProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current StateProviderBase instance.
		///</summary>
		public virtual StateProviderBase StateProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SKUAttributeProviderBase instance.
		///</summary>
		public virtual SKUAttributeProviderBase SKUAttributeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ShippingTypeProviderBase instance.
		///</summary>
		public virtual ShippingTypeProviderBase ShippingTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TaxRuleProviderBase instance.
		///</summary>
		public virtual TaxRuleProviderBase TaxRuleProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AccountTypeProviderBase instance.
		///</summary>
		public virtual AccountTypeProviderBase AccountTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current StoreProviderBase instance.
		///</summary>
		public virtual StoreProviderBase StoreProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SKUProviderBase instance.
		///</summary>
		public virtual SKUProviderBase SKUProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ContactTemperatureProviderBase instance.
		///</summary>
		public virtual ContactTemperatureProviderBase ContactTemperatureProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ShippingProviderBase instance.
		///</summary>
		public virtual ShippingProviderBase ShippingProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ShippingRuleProviderBase instance.
		///</summary>
		public virtual ShippingRuleProviderBase ShippingRuleProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ShippingServiceCodeProviderBase instance.
		///</summary>
		public virtual ShippingServiceCodeProviderBase ShippingServiceCodeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ShippingRuleTypeProviderBase instance.
		///</summary>
		public virtual ShippingRuleTypeProviderBase ShippingRuleTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CaseTypeProviderBase instance.
		///</summary>
		public virtual CaseTypeProviderBase CaseTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ContentPageProviderBase instance.
		///</summary>
		public virtual ContentPageProviderBase ContentPageProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CaseStatusProviderBase instance.
		///</summary>
		public virtual CaseStatusProviderBase CaseStatusProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ContentPageRevisionProviderBase instance.
		///</summary>
		public virtual ContentPageRevisionProviderBase ContentPageRevisionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CategoryProviderBase instance.
		///</summary>
		public virtual CategoryProviderBase CategoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CasePriorityProviderBase instance.
		///</summary>
		public virtual CasePriorityProviderBase CasePriorityProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AddOnProviderBase instance.
		///</summary>
		public virtual AddOnProviderBase AddOnProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AccountProviderBase instance.
		///</summary>
		public virtual AccountProviderBase AccountProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AddOnValueProviderBase instance.
		///</summary>
		public virtual AddOnValueProviderBase AddOnValueProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CaseProviderBase instance.
		///</summary>
		public virtual CaseProviderBase CaseProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AttributeTypeProviderBase instance.
		///</summary>
		public virtual AttributeTypeProviderBase AttributeTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CountryProviderBase instance.
		///</summary>
		public virtual CountryProviderBase CountryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OrderProcessingTypeProviderBase instance.
		///</summary>
		public virtual OrderProcessingTypeProviderBase OrderProcessingTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current NoteProviderBase instance.
		///</summary>
		public virtual NoteProviderBase NoteProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DiscountTypeProviderBase instance.
		///</summary>
		public virtual DiscountTypeProviderBase DiscountTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OrderStateProviderBase instance.
		///</summary>
		public virtual OrderStateProviderBase OrderStateProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DiscountTargetProviderBase instance.
		///</summary>
		public virtual DiscountTargetProviderBase DiscountTargetProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ManufacturerProviderBase instance.
		///</summary>
		public virtual ManufacturerProviderBase ManufacturerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current GatewayProviderBase instance.
		///</summary>
		public virtual GatewayProviderBase GatewayProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CouponProviderBase instance.
		///</summary>
		public virtual CouponProviderBase CouponProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OrderLineItemProviderBase instance.
		///</summary>
		public virtual OrderLineItemProviderBase OrderLineItemProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current HighlightProviderBase instance.
		///</summary>
		public virtual HighlightProviderBase HighlightProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OrderProviderBase instance.
		///</summary>
		public virtual OrderProviderBase OrderProvider{get {throw new NotImplementedException();}}
		
		
					
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public abstract void ExecuteNonQuery(DbCommand commandWrapper);
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public abstract void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion

		#region "ExecuteReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(DbCommand commandWrapper);
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(DbCommand commandWrapper);
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(DbCommand commandWrapper);
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion
		
		#endregion
	}
}
