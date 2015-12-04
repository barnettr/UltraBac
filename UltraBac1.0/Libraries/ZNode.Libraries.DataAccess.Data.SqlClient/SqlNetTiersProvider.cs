
#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Data.Bases;

#endregion

namespace ZNode.Libraries.DataAccess.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : ZNode.Libraries.DataAccess.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
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
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "PortalProvider"
			
		private SqlPortalProvider innerSqlPortalProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Portal"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PortalProviderBase PortalProvider
		{
			get
			{
				if (innerSqlPortalProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlPortalProvider == null)
						{
							this.innerSqlPortalProvider = new SqlPortalProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlPortalProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlPortalProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlPortalProvider SqlPortalProvider
		{
			get {return PortalProvider as SqlPortalProvider;}
		}
		
		#endregion
		
		
		#region "ProductTypeProvider"
			
		private SqlProductTypeProvider innerSqlProductTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductTypeProviderBase ProductTypeProvider
		{
			get
			{
				if (innerSqlProductTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductTypeProvider == null)
						{
							this.innerSqlProductTypeProvider = new SqlProductTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProductTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductTypeProvider SqlProductTypeProvider
		{
			get {return ProductTypeProvider as SqlProductTypeProvider;}
		}
		
		#endregion
		
		
		#region "ProductCrossSellProvider"
			
		private SqlProductCrossSellProvider innerSqlProductCrossSellProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductCrossSell"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductCrossSellProviderBase ProductCrossSellProvider
		{
			get
			{
				if (innerSqlProductCrossSellProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductCrossSellProvider == null)
						{
							this.innerSqlProductCrossSellProvider = new SqlProductCrossSellProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductCrossSellProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProductCrossSellProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductCrossSellProvider SqlProductCrossSellProvider
		{
			get {return ProductCrossSellProvider as SqlProductCrossSellProvider;}
		}
		
		#endregion
		
		
		#region "ProductHighlightProvider"
			
		private SqlProductHighlightProvider innerSqlProductHighlightProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductHighlight"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductHighlightProviderBase ProductHighlightProvider
		{
			get
			{
				if (innerSqlProductHighlightProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductHighlightProvider == null)
						{
							this.innerSqlProductHighlightProvider = new SqlProductHighlightProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductHighlightProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProductHighlightProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductHighlightProvider SqlProductHighlightProvider
		{
			get {return ProductHighlightProvider as SqlProductHighlightProvider;}
		}
		
		#endregion
		
		
		#region "ProductImageProvider"
			
		private SqlProductImageProvider innerSqlProductImageProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductImage"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductImageProviderBase ProductImageProvider
		{
			get
			{
				if (innerSqlProductImageProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductImageProvider == null)
						{
							this.innerSqlProductImageProvider = new SqlProductImageProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductImageProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProductImageProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductImageProvider SqlProductImageProvider
		{
			get {return ProductImageProvider as SqlProductImageProvider;}
		}
		
		#endregion
		
		
		#region "ProductTypeAttributeProvider"
			
		private SqlProductTypeAttributeProvider innerSqlProductTypeAttributeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductTypeAttribute"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductTypeAttributeProviderBase ProductTypeAttributeProvider
		{
			get
			{
				if (innerSqlProductTypeAttributeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductTypeAttributeProvider == null)
						{
							this.innerSqlProductTypeAttributeProvider = new SqlProductTypeAttributeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductTypeAttributeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProductTypeAttributeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductTypeAttributeProvider SqlProductTypeAttributeProvider
		{
			get {return ProductTypeAttributeProvider as SqlProductTypeAttributeProvider;}
		}
		
		#endregion
		
		
		#region "PaymentTypeProvider"
			
		private SqlPaymentTypeProvider innerSqlPaymentTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="PaymentType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PaymentTypeProviderBase PaymentTypeProvider
		{
			get
			{
				if (innerSqlPaymentTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlPaymentTypeProvider == null)
						{
							this.innerSqlPaymentTypeProvider = new SqlPaymentTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlPaymentTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlPaymentTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlPaymentTypeProvider SqlPaymentTypeProvider
		{
			get {return PaymentTypeProvider as SqlPaymentTypeProvider;}
		}
		
		#endregion
		
		
		#region "ProductProvider"
			
		private SqlProductProvider innerSqlProductProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Product"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductProviderBase ProductProvider
		{
			get
			{
				if (innerSqlProductProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductProvider == null)
						{
							this.innerSqlProductProvider = new SqlProductProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProductProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductProvider SqlProductProvider
		{
			get {return ProductProvider as SqlProductProvider;}
		}
		
		#endregion
		
		
		#region "PaymentSettingProvider"
			
		private SqlPaymentSettingProvider innerSqlPaymentSettingProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="PaymentSetting"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PaymentSettingProviderBase PaymentSettingProvider
		{
			get
			{
				if (innerSqlPaymentSettingProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlPaymentSettingProvider == null)
						{
							this.innerSqlPaymentSettingProvider = new SqlPaymentSettingProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlPaymentSettingProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlPaymentSettingProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlPaymentSettingProvider SqlPaymentSettingProvider
		{
			get {return PaymentSettingProvider as SqlPaymentSettingProvider;}
		}
		
		#endregion
		
		
		#region "ProductAddOnProvider"
			
		private SqlProductAddOnProvider innerSqlProductAddOnProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductAddOn"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductAddOnProviderBase ProductAddOnProvider
		{
			get
			{
				if (innerSqlProductAddOnProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductAddOnProvider == null)
						{
							this.innerSqlProductAddOnProvider = new SqlProductAddOnProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductAddOnProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProductAddOnProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductAddOnProvider SqlProductAddOnProvider
		{
			get {return ProductAddOnProvider as SqlProductAddOnProvider;}
		}
		
		#endregion
		
		
		#region "ProductCategoryProvider"
			
		private SqlProductCategoryProvider innerSqlProductCategoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductCategoryProviderBase ProductCategoryProvider
		{
			get
			{
				if (innerSqlProductCategoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductCategoryProvider == null)
						{
							this.innerSqlProductCategoryProvider = new SqlProductCategoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductCategoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProductCategoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductCategoryProvider SqlProductCategoryProvider
		{
			get {return ProductCategoryProvider as SqlProductCategoryProvider;}
		}
		
		#endregion
		
		
		#region "ProductAttributeProvider"
			
		private SqlProductAttributeProvider innerSqlProductAttributeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductAttribute"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductAttributeProviderBase ProductAttributeProvider
		{
			get
			{
				if (innerSqlProductAttributeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductAttributeProvider == null)
						{
							this.innerSqlProductAttributeProvider = new SqlProductAttributeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductAttributeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProductAttributeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductAttributeProvider SqlProductAttributeProvider
		{
			get {return ProductAttributeProvider as SqlProductAttributeProvider;}
		}
		
		#endregion
		
		
		#region "ProfileProvider"
			
		private SqlProfileProvider innerSqlProfileProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Profile"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProfileProviderBase ProfileProvider
		{
			get
			{
				if (innerSqlProfileProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProfileProvider == null)
						{
							this.innerSqlProfileProvider = new SqlProfileProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProfileProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProfileProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProfileProvider SqlProfileProvider
		{
			get {return ProfileProvider as SqlProfileProvider;}
		}
		
		#endregion
		
		
		#region "StateProvider"
			
		private SqlStateProvider innerSqlStateProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="State"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override StateProviderBase StateProvider
		{
			get
			{
				if (innerSqlStateProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlStateProvider == null)
						{
							this.innerSqlStateProvider = new SqlStateProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlStateProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlStateProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlStateProvider SqlStateProvider
		{
			get {return StateProvider as SqlStateProvider;}
		}
		
		#endregion
		
		
		#region "SKUAttributeProvider"
			
		private SqlSKUAttributeProvider innerSqlSKUAttributeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SKUAttribute"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SKUAttributeProviderBase SKUAttributeProvider
		{
			get
			{
				if (innerSqlSKUAttributeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSKUAttributeProvider == null)
						{
							this.innerSqlSKUAttributeProvider = new SqlSKUAttributeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSKUAttributeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSKUAttributeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSKUAttributeProvider SqlSKUAttributeProvider
		{
			get {return SKUAttributeProvider as SqlSKUAttributeProvider;}
		}
		
		#endregion
		
		
		#region "ShippingTypeProvider"
			
		private SqlShippingTypeProvider innerSqlShippingTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ShippingType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ShippingTypeProviderBase ShippingTypeProvider
		{
			get
			{
				if (innerSqlShippingTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlShippingTypeProvider == null)
						{
							this.innerSqlShippingTypeProvider = new SqlShippingTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlShippingTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlShippingTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlShippingTypeProvider SqlShippingTypeProvider
		{
			get {return ShippingTypeProvider as SqlShippingTypeProvider;}
		}
		
		#endregion
		
		
		#region "TaxRuleProvider"
			
		private SqlTaxRuleProvider innerSqlTaxRuleProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TaxRule"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TaxRuleProviderBase TaxRuleProvider
		{
			get
			{
				if (innerSqlTaxRuleProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTaxRuleProvider == null)
						{
							this.innerSqlTaxRuleProvider = new SqlTaxRuleProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTaxRuleProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTaxRuleProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTaxRuleProvider SqlTaxRuleProvider
		{
			get {return TaxRuleProvider as SqlTaxRuleProvider;}
		}
		
		#endregion
		
		
		#region "AccountTypeProvider"
			
		private SqlAccountTypeProvider innerSqlAccountTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AccountType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AccountTypeProviderBase AccountTypeProvider
		{
			get
			{
				if (innerSqlAccountTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAccountTypeProvider == null)
						{
							this.innerSqlAccountTypeProvider = new SqlAccountTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAccountTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAccountTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAccountTypeProvider SqlAccountTypeProvider
		{
			get {return AccountTypeProvider as SqlAccountTypeProvider;}
		}
		
		#endregion
		
		
		#region "StoreProvider"
			
		private SqlStoreProvider innerSqlStoreProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Store"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override StoreProviderBase StoreProvider
		{
			get
			{
				if (innerSqlStoreProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlStoreProvider == null)
						{
							this.innerSqlStoreProvider = new SqlStoreProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlStoreProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlStoreProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlStoreProvider SqlStoreProvider
		{
			get {return StoreProvider as SqlStoreProvider;}
		}
		
		#endregion
		
		
		#region "SKUProvider"
			
		private SqlSKUProvider innerSqlSKUProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SKU"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SKUProviderBase SKUProvider
		{
			get
			{
				if (innerSqlSKUProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSKUProvider == null)
						{
							this.innerSqlSKUProvider = new SqlSKUProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSKUProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSKUProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSKUProvider SqlSKUProvider
		{
			get {return SKUProvider as SqlSKUProvider;}
		}
		
		#endregion
		
		
		#region "ContactTemperatureProvider"
			
		private SqlContactTemperatureProvider innerSqlContactTemperatureProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ContactTemperature"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ContactTemperatureProviderBase ContactTemperatureProvider
		{
			get
			{
				if (innerSqlContactTemperatureProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlContactTemperatureProvider == null)
						{
							this.innerSqlContactTemperatureProvider = new SqlContactTemperatureProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlContactTemperatureProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlContactTemperatureProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlContactTemperatureProvider SqlContactTemperatureProvider
		{
			get {return ContactTemperatureProvider as SqlContactTemperatureProvider;}
		}
		
		#endregion
		
		
		#region "ShippingProvider"
			
		private SqlShippingProvider innerSqlShippingProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Shipping"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ShippingProviderBase ShippingProvider
		{
			get
			{
				if (innerSqlShippingProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlShippingProvider == null)
						{
							this.innerSqlShippingProvider = new SqlShippingProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlShippingProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlShippingProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlShippingProvider SqlShippingProvider
		{
			get {return ShippingProvider as SqlShippingProvider;}
		}
		
		#endregion
		
		
		#region "ShippingRuleProvider"
			
		private SqlShippingRuleProvider innerSqlShippingRuleProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ShippingRule"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ShippingRuleProviderBase ShippingRuleProvider
		{
			get
			{
				if (innerSqlShippingRuleProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlShippingRuleProvider == null)
						{
							this.innerSqlShippingRuleProvider = new SqlShippingRuleProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlShippingRuleProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlShippingRuleProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlShippingRuleProvider SqlShippingRuleProvider
		{
			get {return ShippingRuleProvider as SqlShippingRuleProvider;}
		}
		
		#endregion
		
		
		#region "ShippingServiceCodeProvider"
			
		private SqlShippingServiceCodeProvider innerSqlShippingServiceCodeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ShippingServiceCode"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ShippingServiceCodeProviderBase ShippingServiceCodeProvider
		{
			get
			{
				if (innerSqlShippingServiceCodeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlShippingServiceCodeProvider == null)
						{
							this.innerSqlShippingServiceCodeProvider = new SqlShippingServiceCodeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlShippingServiceCodeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlShippingServiceCodeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlShippingServiceCodeProvider SqlShippingServiceCodeProvider
		{
			get {return ShippingServiceCodeProvider as SqlShippingServiceCodeProvider;}
		}
		
		#endregion
		
		
		#region "ShippingRuleTypeProvider"
			
		private SqlShippingRuleTypeProvider innerSqlShippingRuleTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ShippingRuleType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ShippingRuleTypeProviderBase ShippingRuleTypeProvider
		{
			get
			{
				if (innerSqlShippingRuleTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlShippingRuleTypeProvider == null)
						{
							this.innerSqlShippingRuleTypeProvider = new SqlShippingRuleTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlShippingRuleTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlShippingRuleTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlShippingRuleTypeProvider SqlShippingRuleTypeProvider
		{
			get {return ShippingRuleTypeProvider as SqlShippingRuleTypeProvider;}
		}
		
		#endregion
		
		
		#region "CaseTypeProvider"
			
		private SqlCaseTypeProvider innerSqlCaseTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CaseType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CaseTypeProviderBase CaseTypeProvider
		{
			get
			{
				if (innerSqlCaseTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCaseTypeProvider == null)
						{
							this.innerSqlCaseTypeProvider = new SqlCaseTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCaseTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCaseTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCaseTypeProvider SqlCaseTypeProvider
		{
			get {return CaseTypeProvider as SqlCaseTypeProvider;}
		}
		
		#endregion
		
		
		#region "ContentPageProvider"
			
		private SqlContentPageProvider innerSqlContentPageProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ContentPage"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ContentPageProviderBase ContentPageProvider
		{
			get
			{
				if (innerSqlContentPageProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlContentPageProvider == null)
						{
							this.innerSqlContentPageProvider = new SqlContentPageProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlContentPageProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlContentPageProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlContentPageProvider SqlContentPageProvider
		{
			get {return ContentPageProvider as SqlContentPageProvider;}
		}
		
		#endregion
		
		
		#region "CaseStatusProvider"
			
		private SqlCaseStatusProvider innerSqlCaseStatusProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CaseStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CaseStatusProviderBase CaseStatusProvider
		{
			get
			{
				if (innerSqlCaseStatusProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCaseStatusProvider == null)
						{
							this.innerSqlCaseStatusProvider = new SqlCaseStatusProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCaseStatusProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCaseStatusProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCaseStatusProvider SqlCaseStatusProvider
		{
			get {return CaseStatusProvider as SqlCaseStatusProvider;}
		}
		
		#endregion
		
		
		#region "ContentPageRevisionProvider"
			
		private SqlContentPageRevisionProvider innerSqlContentPageRevisionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ContentPageRevision"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ContentPageRevisionProviderBase ContentPageRevisionProvider
		{
			get
			{
				if (innerSqlContentPageRevisionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlContentPageRevisionProvider == null)
						{
							this.innerSqlContentPageRevisionProvider = new SqlContentPageRevisionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlContentPageRevisionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlContentPageRevisionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlContentPageRevisionProvider SqlContentPageRevisionProvider
		{
			get {return ContentPageRevisionProvider as SqlContentPageRevisionProvider;}
		}
		
		#endregion
		
		
		#region "CategoryProvider"
			
		private SqlCategoryProvider innerSqlCategoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Category"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CategoryProviderBase CategoryProvider
		{
			get
			{
				if (innerSqlCategoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCategoryProvider == null)
						{
							this.innerSqlCategoryProvider = new SqlCategoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCategoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCategoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCategoryProvider SqlCategoryProvider
		{
			get {return CategoryProvider as SqlCategoryProvider;}
		}
		
		#endregion
		
		
		#region "CasePriorityProvider"
			
		private SqlCasePriorityProvider innerSqlCasePriorityProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CasePriority"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CasePriorityProviderBase CasePriorityProvider
		{
			get
			{
				if (innerSqlCasePriorityProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCasePriorityProvider == null)
						{
							this.innerSqlCasePriorityProvider = new SqlCasePriorityProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCasePriorityProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCasePriorityProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCasePriorityProvider SqlCasePriorityProvider
		{
			get {return CasePriorityProvider as SqlCasePriorityProvider;}
		}
		
		#endregion
		
		
		#region "AddOnProvider"
			
		private SqlAddOnProvider innerSqlAddOnProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AddOn"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AddOnProviderBase AddOnProvider
		{
			get
			{
				if (innerSqlAddOnProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAddOnProvider == null)
						{
							this.innerSqlAddOnProvider = new SqlAddOnProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAddOnProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAddOnProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAddOnProvider SqlAddOnProvider
		{
			get {return AddOnProvider as SqlAddOnProvider;}
		}
		
		#endregion
		
		
		#region "AccountProvider"
			
		private SqlAccountProvider innerSqlAccountProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Account"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AccountProviderBase AccountProvider
		{
			get
			{
				if (innerSqlAccountProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAccountProvider == null)
						{
							this.innerSqlAccountProvider = new SqlAccountProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAccountProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAccountProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAccountProvider SqlAccountProvider
		{
			get {return AccountProvider as SqlAccountProvider;}
		}
		
		#endregion
		
		
		#region "AddOnValueProvider"
			
		private SqlAddOnValueProvider innerSqlAddOnValueProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AddOnValue"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AddOnValueProviderBase AddOnValueProvider
		{
			get
			{
				if (innerSqlAddOnValueProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAddOnValueProvider == null)
						{
							this.innerSqlAddOnValueProvider = new SqlAddOnValueProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAddOnValueProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAddOnValueProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAddOnValueProvider SqlAddOnValueProvider
		{
			get {return AddOnValueProvider as SqlAddOnValueProvider;}
		}
		
		#endregion
		
		
		#region "CaseProvider"
			
		private SqlCaseProvider innerSqlCaseProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Case"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CaseProviderBase CaseProvider
		{
			get
			{
				if (innerSqlCaseProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCaseProvider == null)
						{
							this.innerSqlCaseProvider = new SqlCaseProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCaseProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCaseProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCaseProvider SqlCaseProvider
		{
			get {return CaseProvider as SqlCaseProvider;}
		}
		
		#endregion
		
		
		#region "AttributeTypeProvider"
			
		private SqlAttributeTypeProvider innerSqlAttributeTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AttributeType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AttributeTypeProviderBase AttributeTypeProvider
		{
			get
			{
				if (innerSqlAttributeTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAttributeTypeProvider == null)
						{
							this.innerSqlAttributeTypeProvider = new SqlAttributeTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAttributeTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAttributeTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAttributeTypeProvider SqlAttributeTypeProvider
		{
			get {return AttributeTypeProvider as SqlAttributeTypeProvider;}
		}
		
		#endregion
		
		
		#region "CountryProvider"
			
		private SqlCountryProvider innerSqlCountryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Country"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CountryProviderBase CountryProvider
		{
			get
			{
				if (innerSqlCountryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCountryProvider == null)
						{
							this.innerSqlCountryProvider = new SqlCountryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCountryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCountryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCountryProvider SqlCountryProvider
		{
			get {return CountryProvider as SqlCountryProvider;}
		}
		
		#endregion
		
		
		#region "OrderProcessingTypeProvider"
			
		private SqlOrderProcessingTypeProvider innerSqlOrderProcessingTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OrderProcessingType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrderProcessingTypeProviderBase OrderProcessingTypeProvider
		{
			get
			{
				if (innerSqlOrderProcessingTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOrderProcessingTypeProvider == null)
						{
							this.innerSqlOrderProcessingTypeProvider = new SqlOrderProcessingTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOrderProcessingTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlOrderProcessingTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOrderProcessingTypeProvider SqlOrderProcessingTypeProvider
		{
			get {return OrderProcessingTypeProvider as SqlOrderProcessingTypeProvider;}
		}
		
		#endregion
		
		
		#region "NoteProvider"
			
		private SqlNoteProvider innerSqlNoteProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Note"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override NoteProviderBase NoteProvider
		{
			get
			{
				if (innerSqlNoteProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlNoteProvider == null)
						{
							this.innerSqlNoteProvider = new SqlNoteProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlNoteProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlNoteProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlNoteProvider SqlNoteProvider
		{
			get {return NoteProvider as SqlNoteProvider;}
		}
		
		#endregion
		
		
		#region "DiscountTypeProvider"
			
		private SqlDiscountTypeProvider innerSqlDiscountTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DiscountType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DiscountTypeProviderBase DiscountTypeProvider
		{
			get
			{
				if (innerSqlDiscountTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDiscountTypeProvider == null)
						{
							this.innerSqlDiscountTypeProvider = new SqlDiscountTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDiscountTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDiscountTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDiscountTypeProvider SqlDiscountTypeProvider
		{
			get {return DiscountTypeProvider as SqlDiscountTypeProvider;}
		}
		
		#endregion
		
		
		#region "OrderStateProvider"
			
		private SqlOrderStateProvider innerSqlOrderStateProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OrderState"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrderStateProviderBase OrderStateProvider
		{
			get
			{
				if (innerSqlOrderStateProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOrderStateProvider == null)
						{
							this.innerSqlOrderStateProvider = new SqlOrderStateProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOrderStateProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlOrderStateProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOrderStateProvider SqlOrderStateProvider
		{
			get {return OrderStateProvider as SqlOrderStateProvider;}
		}
		
		#endregion
		
		
		#region "DiscountTargetProvider"
			
		private SqlDiscountTargetProvider innerSqlDiscountTargetProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DiscountTarget"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DiscountTargetProviderBase DiscountTargetProvider
		{
			get
			{
				if (innerSqlDiscountTargetProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDiscountTargetProvider == null)
						{
							this.innerSqlDiscountTargetProvider = new SqlDiscountTargetProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDiscountTargetProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDiscountTargetProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDiscountTargetProvider SqlDiscountTargetProvider
		{
			get {return DiscountTargetProvider as SqlDiscountTargetProvider;}
		}
		
		#endregion
		
		
		#region "ManufacturerProvider"
			
		private SqlManufacturerProvider innerSqlManufacturerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Manufacturer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ManufacturerProviderBase ManufacturerProvider
		{
			get
			{
				if (innerSqlManufacturerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlManufacturerProvider == null)
						{
							this.innerSqlManufacturerProvider = new SqlManufacturerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlManufacturerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlManufacturerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlManufacturerProvider SqlManufacturerProvider
		{
			get {return ManufacturerProvider as SqlManufacturerProvider;}
		}
		
		#endregion
		
		
		#region "GatewayProvider"
			
		private SqlGatewayProvider innerSqlGatewayProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Gateway"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override GatewayProviderBase GatewayProvider
		{
			get
			{
				if (innerSqlGatewayProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlGatewayProvider == null)
						{
							this.innerSqlGatewayProvider = new SqlGatewayProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlGatewayProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlGatewayProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlGatewayProvider SqlGatewayProvider
		{
			get {return GatewayProvider as SqlGatewayProvider;}
		}
		
		#endregion
		
		
		#region "CouponProvider"
			
		private SqlCouponProvider innerSqlCouponProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Coupon"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CouponProviderBase CouponProvider
		{
			get
			{
				if (innerSqlCouponProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCouponProvider == null)
						{
							this.innerSqlCouponProvider = new SqlCouponProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCouponProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCouponProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCouponProvider SqlCouponProvider
		{
			get {return CouponProvider as SqlCouponProvider;}
		}
		
		#endregion
		
		
		#region "OrderLineItemProvider"
			
		private SqlOrderLineItemProvider innerSqlOrderLineItemProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OrderLineItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrderLineItemProviderBase OrderLineItemProvider
		{
			get
			{
				if (innerSqlOrderLineItemProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOrderLineItemProvider == null)
						{
							this.innerSqlOrderLineItemProvider = new SqlOrderLineItemProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOrderLineItemProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlOrderLineItemProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOrderLineItemProvider SqlOrderLineItemProvider
		{
			get {return OrderLineItemProvider as SqlOrderLineItemProvider;}
		}
		
		#endregion
		
		
		#region "HighlightProvider"
			
		private SqlHighlightProvider innerSqlHighlightProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Highlight"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override HighlightProviderBase HighlightProvider
		{
			get
			{
				if (innerSqlHighlightProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlHighlightProvider == null)
						{
							this.innerSqlHighlightProvider = new SqlHighlightProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlHighlightProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlHighlightProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlHighlightProvider SqlHighlightProvider
		{
			get {return HighlightProvider as SqlHighlightProvider;}
		}
		
		#endregion
		
		
		#region "OrderProvider"
			
		private SqlOrderProvider innerSqlOrderProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Order"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrderProviderBase OrderProvider
		{
			get
			{
				if (innerSqlOrderProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOrderProvider == null)
						{
							this.innerSqlOrderProvider = new SqlOrderProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOrderProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlOrderProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOrderProvider SqlOrderProvider
		{
			get {return OrderProvider as SqlOrderProvider;}
		}
		
		#endregion
		
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
