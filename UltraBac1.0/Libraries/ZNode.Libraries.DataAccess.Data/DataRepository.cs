#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Data.Bases;

#endregion

namespace ZNode.Libraries.DataAccess.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("ZNode.Libraries.DataAccess.Data") as NetTiersServiceSection;
				}

				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
				return WebConfigurationManager.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;

			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			public ConnectionProvider(String connectionStringName)
			{
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		
		
		#region PortalProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Portal"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static PortalProviderBase PortalProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PortalProvider;
			}
		}
		
		#endregion
		
		
		
		#region ProductTypeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ProductTypeProviderBase ProductTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductTypeProvider;
			}
		}
		
		#endregion
		
		
		
		#region ProductCrossSellProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductCrossSell"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ProductCrossSellProviderBase ProductCrossSellProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductCrossSellProvider;
			}
		}
		
		#endregion
		
		
		
		#region ProductHighlightProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductHighlight"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ProductHighlightProviderBase ProductHighlightProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductHighlightProvider;
			}
		}
		
		#endregion
		
		
		
		#region ProductImageProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductImage"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ProductImageProviderBase ProductImageProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductImageProvider;
			}
		}
		
		#endregion
		
		
		
		#region ProductTypeAttributeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductTypeAttribute"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ProductTypeAttributeProviderBase ProductTypeAttributeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductTypeAttributeProvider;
			}
		}
		
		#endregion
		
		
		
		#region PaymentTypeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="PaymentType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static PaymentTypeProviderBase PaymentTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PaymentTypeProvider;
			}
		}
		
		#endregion
		
		
		
		#region ProductProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Product"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ProductProviderBase ProductProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductProvider;
			}
		}
		
		#endregion
		
		
		
		#region PaymentSettingProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="PaymentSetting"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static PaymentSettingProviderBase PaymentSettingProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PaymentSettingProvider;
			}
		}
		
		#endregion
		
		
		
		#region ProductAddOnProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductAddOn"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ProductAddOnProviderBase ProductAddOnProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductAddOnProvider;
			}
		}
		
		#endregion
		
		
		
		#region ProductCategoryProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ProductCategoryProviderBase ProductCategoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductCategoryProvider;
			}
		}
		
		#endregion
		
		
		
		#region ProductAttributeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductAttribute"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ProductAttributeProviderBase ProductAttributeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductAttributeProvider;
			}
		}
		
		#endregion
		
		
		
		#region ProfileProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Profile"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ProfileProviderBase ProfileProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProfileProvider;
			}
		}
		
		#endregion
		
		
		
		#region StateProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="State"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static StateProviderBase StateProvider
		{
			get 
			{
				LoadProviders();
				return _provider.StateProvider;
			}
		}
		
		#endregion
		
		
		
		#region SKUAttributeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SKUAttribute"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static SKUAttributeProviderBase SKUAttributeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SKUAttributeProvider;
			}
		}
		
		#endregion
		
		
		
		#region ShippingTypeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ShippingType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ShippingTypeProviderBase ShippingTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ShippingTypeProvider;
			}
		}
		
		#endregion
		
		
		
		#region TaxRuleProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TaxRule"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static TaxRuleProviderBase TaxRuleProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TaxRuleProvider;
			}
		}
		
		#endregion
		
		
		
		#region AccountTypeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AccountType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static AccountTypeProviderBase AccountTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AccountTypeProvider;
			}
		}
		
		#endregion
		
		
		
		#region StoreProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Store"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static StoreProviderBase StoreProvider
		{
			get 
			{
				LoadProviders();
				return _provider.StoreProvider;
			}
		}
		
		#endregion
		
		
		
		#region SKUProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SKU"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static SKUProviderBase SKUProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SKUProvider;
			}
		}
		
		#endregion
		
		
		
		#region ContactTemperatureProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ContactTemperature"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ContactTemperatureProviderBase ContactTemperatureProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ContactTemperatureProvider;
			}
		}
		
		#endregion
		
		
		
		#region ShippingProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Shipping"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ShippingProviderBase ShippingProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ShippingProvider;
			}
		}
		
		#endregion
		
		
		
		#region ShippingRuleProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ShippingRule"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ShippingRuleProviderBase ShippingRuleProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ShippingRuleProvider;
			}
		}
		
		#endregion
		
		
		
		#region ShippingServiceCodeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ShippingServiceCode"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ShippingServiceCodeProviderBase ShippingServiceCodeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ShippingServiceCodeProvider;
			}
		}
		
		#endregion
		
		
		
		#region ShippingRuleTypeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ShippingRuleType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ShippingRuleTypeProviderBase ShippingRuleTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ShippingRuleTypeProvider;
			}
		}
		
		#endregion
		
		
		
		#region CaseTypeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CaseType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static CaseTypeProviderBase CaseTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CaseTypeProvider;
			}
		}
		
		#endregion
		
		
		
		#region ContentPageProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ContentPage"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ContentPageProviderBase ContentPageProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ContentPageProvider;
			}
		}
		
		#endregion
		
		
		
		#region CaseStatusProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CaseStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static CaseStatusProviderBase CaseStatusProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CaseStatusProvider;
			}
		}
		
		#endregion
		
		
		
		#region ContentPageRevisionProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ContentPageRevision"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ContentPageRevisionProviderBase ContentPageRevisionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ContentPageRevisionProvider;
			}
		}
		
		#endregion
		
		
		
		#region CategoryProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Category"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static CategoryProviderBase CategoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CategoryProvider;
			}
		}
		
		#endregion
		
		
		
		#region CasePriorityProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CasePriority"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static CasePriorityProviderBase CasePriorityProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CasePriorityProvider;
			}
		}
		
		#endregion
		
		
		
		#region AddOnProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AddOn"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static AddOnProviderBase AddOnProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AddOnProvider;
			}
		}
		
		#endregion
		
		
		
		#region AccountProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Account"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static AccountProviderBase AccountProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AccountProvider;
			}
		}
		
		#endregion
		
		
		
		#region AddOnValueProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AddOnValue"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static AddOnValueProviderBase AddOnValueProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AddOnValueProvider;
			}
		}
		
		#endregion
		
		
		
		#region CaseProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Case"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static CaseProviderBase CaseProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CaseProvider;
			}
		}
		
		#endregion
		
		
		
		#region AttributeTypeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AttributeType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static AttributeTypeProviderBase AttributeTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AttributeTypeProvider;
			}
		}
		
		#endregion
		
		
		
		#region CountryProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Country"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static CountryProviderBase CountryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CountryProvider;
			}
		}
		
		#endregion
		
		
		
		#region OrderProcessingTypeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="OrderProcessingType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static OrderProcessingTypeProviderBase OrderProcessingTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OrderProcessingTypeProvider;
			}
		}
		
		#endregion
		
		
		
		#region NoteProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Note"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static NoteProviderBase NoteProvider
		{
			get 
			{
				LoadProviders();
				return _provider.NoteProvider;
			}
		}
		
		#endregion
		
		
		
		#region DiscountTypeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DiscountType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static DiscountTypeProviderBase DiscountTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DiscountTypeProvider;
			}
		}
		
		#endregion
		
		
		
		#region OrderStateProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="OrderState"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static OrderStateProviderBase OrderStateProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OrderStateProvider;
			}
		}
		
		#endregion
		
		
		
		#region DiscountTargetProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DiscountTarget"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static DiscountTargetProviderBase DiscountTargetProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DiscountTargetProvider;
			}
		}
		
		#endregion
		
		
		
		#region ManufacturerProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Manufacturer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static ManufacturerProviderBase ManufacturerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ManufacturerProvider;
			}
		}
		
		#endregion
		
		
		
		#region GatewayProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Gateway"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static GatewayProviderBase GatewayProvider
		{
			get 
			{
				LoadProviders();
				return _provider.GatewayProvider;
			}
		}
		
		#endregion
		
		
		
		#region CouponProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Coupon"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static CouponProviderBase CouponProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CouponProvider;
			}
		}
		
		#endregion
		
		
		
		#region OrderLineItemProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="OrderLineItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static OrderLineItemProviderBase OrderLineItemProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OrderLineItemProvider;
			}
		}
		
		#endregion
		
		
		
		#region HighlightProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Highlight"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static HighlightProviderBase HighlightProvider
		{
			get 
			{
				LoadProviders();
				return _provider.HighlightProvider;
			}
		}
		
		#endregion
		
		
		
		#region OrderProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Order"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public /*new*/ static OrderProviderBase OrderProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OrderProvider;
			}
		}
		
		#endregion
		
		
		
		#endregion
		
	}
}
