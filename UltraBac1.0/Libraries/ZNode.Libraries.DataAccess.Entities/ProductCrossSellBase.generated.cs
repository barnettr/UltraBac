﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Thursday, October 18, 2007
	Important: Do not modify this file. Edit the file ProductCrossSell.cs instead.
*/

#region using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;

#endregion

namespace ZNode.Libraries.DataAccess.Entities
{
	#region ProductCrossSellEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="ProductCrossSell"/> object.
	/// </remarks>
	public class ProductCrossSellEventArgs : System.EventArgs
	{
		private ProductCrossSellColumn column;
		private object value;
		
		
		///<summary>
		/// Initalizes a new Instance of the ProductCrossSellEventArgs class.
		///</summary>
		public ProductCrossSellEventArgs(ProductCrossSellColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the ProductCrossSellEventArgs class.
		///</summary>
		public ProductCrossSellEventArgs(ProductCrossSellColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		
		///<summary>
		/// The ProductCrossSellColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="ProductCrossSellColumn" />
		public ProductCrossSellColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all ProductCrossSell related events.
	///</summary>
	public delegate void ProductCrossSellEventHandler(object sender, ProductCrossSellEventArgs e);
	
	///<summary>
	/// An object representation of the 'ZNodeProductCrossSell' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(ProductCrossSell))]
	public abstract partial class ProductCrossSellBase : EntityBase, IEntityId<ProductCrossSellKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private ProductCrossSellEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//ProductCrossSellEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private ProductCrossSellEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<ProductCrossSell> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event ProductCrossSellEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event ProductCrossSellEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="ProductCrossSellBase"/> instance.
		///</summary>
		public ProductCrossSellBase()
		{
			this.entityData = new ProductCrossSellEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="ProductCrossSellBase"/> instance.
		///</summary>
		///<param name="productCrossSellPortalId"></param>
		///<param name="productCrossSellProductId"></param>
		///<param name="productCrossSellRelatedProductId"></param>
		///<param name="productCrossSellDisplayOrder"></param>
		public ProductCrossSellBase(System.Int32 productCrossSellPortalId, System.Int32 productCrossSellProductId, 
			System.Int32 productCrossSellRelatedProductId, System.Int32? productCrossSellDisplayOrder)
		{
			this.entityData = new ProductCrossSellEntityData();
			this.backupData = null;

			this.PortalId = productCrossSellPortalId;
			this.ProductId = productCrossSellProductId;
			this.RelatedProductId = productCrossSellRelatedProductId;
			this.DisplayOrder = productCrossSellDisplayOrder;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="ProductCrossSell"/> instance.
		///</summary>
		///<param name="productCrossSellPortalId"></param>
		///<param name="productCrossSellProductId"></param>
		///<param name="productCrossSellRelatedProductId"></param>
		///<param name="productCrossSellDisplayOrder"></param>
		public static ProductCrossSell CreateProductCrossSell(System.Int32 productCrossSellPortalId, System.Int32 productCrossSellProductId, 
			System.Int32 productCrossSellRelatedProductId, System.Int32? productCrossSellDisplayOrder)
		{
			ProductCrossSell newProductCrossSell = new ProductCrossSell();
			newProductCrossSell.PortalId = productCrossSellPortalId;
			newProductCrossSell.ProductId = productCrossSellProductId;
			newProductCrossSell.RelatedProductId = productCrossSellRelatedProductId;
			newProductCrossSell.DisplayOrder = productCrossSellDisplayOrder;
			return newProductCrossSell;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ProductCrossSellColumn"/> which has raised the event.</param>
		public void OnColumnChanging(ProductCrossSellColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ProductCrossSellColumn"/> which has raised the event.</param>
		public void OnColumnChanged(ProductCrossSellColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ProductCrossSellColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(ProductCrossSellColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				ProductCrossSellEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new ProductCrossSellEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ProductCrossSellColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(ProductCrossSellColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				ProductCrossSellEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new ProductCrossSellEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the ProductCrossSellTypeId property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[ReadOnlyAttribute(false)/*, XmlIgnoreAttribute()*/, DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true, true, false)]
		public virtual System.Int32 ProductCrossSellTypeId
		{
			get
			{
				return this.entityData.ProductCrossSellTypeId; 
			}
			
			set
			{
				if (this.entityData.ProductCrossSellTypeId == value)
					return;
					
					
				OnColumnChanging(ProductCrossSellColumn.ProductCrossSellTypeId, this.entityData.ProductCrossSellTypeId);
				this.entityData.ProductCrossSellTypeId = value;
				this.EntityId.ProductCrossSellTypeId = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ProductCrossSellColumn.ProductCrossSellTypeId, this.entityData.ProductCrossSellTypeId);
				OnPropertyChanged("ProductCrossSellTypeId");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the PortalId property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Int32 PortalId
		{
			get
			{
				return this.entityData.PortalId; 
			}
			
			set
			{
				if (this.entityData.PortalId == value)
					return;
					
					
				OnColumnChanging(ProductCrossSellColumn.PortalId, this.entityData.PortalId);
				this.entityData.PortalId = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ProductCrossSellColumn.PortalId, this.entityData.PortalId);
				OnPropertyChanged("PortalId");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the ProductId property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Int32 ProductId
		{
			get
			{
				return this.entityData.ProductId; 
			}
			
			set
			{
				if (this.entityData.ProductId == value)
					return;
					
					
				OnColumnChanging(ProductCrossSellColumn.ProductId, this.entityData.ProductId);
				this.entityData.ProductId = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ProductCrossSellColumn.ProductId, this.entityData.ProductId);
				OnPropertyChanged("ProductId");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the RelatedProductId property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Int32 RelatedProductId
		{
			get
			{
				return this.entityData.RelatedProductId; 
			}
			
			set
			{
				if (this.entityData.RelatedProductId == value)
					return;
					
					
				OnColumnChanging(ProductCrossSellColumn.RelatedProductId, this.entityData.RelatedProductId);
				this.entityData.RelatedProductId = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ProductCrossSellColumn.RelatedProductId, this.entityData.RelatedProductId);
				OnPropertyChanged("RelatedProductId");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the DisplayOrder property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return (int)0. It is up to the developer
		/// to check the value of IsDisplayOrderNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, true)]
		public virtual System.Int32? DisplayOrder
		{
			get
			{
				return this.entityData.DisplayOrder; 
			}
			
			set
			{
				if (this.entityData.DisplayOrder == value)
					return;
					
					
				OnColumnChanging(ProductCrossSellColumn.DisplayOrder, this.entityData.DisplayOrder);
				this.entityData.DisplayOrder = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ProductCrossSellColumn.DisplayOrder, this.entityData.DisplayOrder);
				OnPropertyChanged("DisplayOrder");
			}
		}
		

		#region Source Foreign Key Property
				
		private Product _productIdSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="Product"/>.
		/// </summary>
		/// <value>The source Product for ProductId.</value>
        [XmlIgnore()]
		[Browsable(false), BindableAttribute()]
		public virtual Product ProductIdSource
      	{
            get { return this._productIdSource; }
            set { this._productIdSource = value; }
      	}
		#endregion
			
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "ZNodeProductCrossSell"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"ProductCrossSellTypeId", "PortalId", "ProductId", "RelatedProductId", "DisplayOrder"};
			}
		}
		#endregion 
		
		
		#endregion
		
		#region IEditableObject
		
		#region  CancelAddNew Event
		/// <summary>
        /// The delegate for the CancelAddNew event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public delegate void CancelAddNewEventHandler(object sender, EventArgs e);
    
    	/// <summary>
		/// The CancelAddNew event.
		/// </summary>
		[field:NonSerialized]
		public event CancelAddNewEventHandler CancelAddNew ;

		/// <summary>
        /// Called when [cancel add new].
        /// </summary>
        public void OnCancelAddNew()
        {    
			if (!SuppressEntityEvents)
			{
	            CancelAddNewEventHandler handler = CancelAddNew ;
            	if (handler != null)
	            {    
    	            handler(this, EventArgs.Empty) ;
        	    }
	        }
        }
		#endregion 
		
		/// <summary>
		/// Begins an edit on an object.
		/// </summary>
		void IEditableObject.BeginEdit() 
	    {
	        //Console.WriteLine("Start BeginEdit");
	        if (!inTxn) 
	        {
	            this.backupData = this.entityData.Clone() as ProductCrossSellEntityData;
	            inTxn = true;
	            //Console.WriteLine("BeginEdit");
	        }
	        //Console.WriteLine("End BeginEdit");
	    }
	
		/// <summary>
		/// Discards changes since the last <c>BeginEdit</c> call.
		/// </summary>
	    void IEditableObject.CancelEdit() 
	    {
	        //Console.WriteLine("Start CancelEdit");
	        if (this.inTxn) 
	        {
	            this.entityData = this.backupData;
	            this.backupData = null;
				this.inTxn = false;

				if (this.bindingIsNew)
	        	//if (this.EntityState == EntityState.Added)
	        	{
					if (this.parentCollection != null)
						this.parentCollection.Remove( (ProductCrossSell) this ) ;
				}	            
	        }
	        //Console.WriteLine("End CancelEdit");
	    }
	
		/// <summary>
		/// Pushes changes since the last <c>BeginEdit</c> or <c>IBindingList.AddNew</c> call into the underlying object.
		/// </summary>
	    void IEditableObject.EndEdit() 
	    {
	        //Console.WriteLine("Start EndEdit" + this.custData.id + this.custData.lastName);
	        if (this.inTxn) 
	        {
	            this.backupData = null;
				if (this.IsDirty) 
				{
					if (this.bindingIsNew) {
						this.EntityState = EntityState.Added;
						this.bindingIsNew = false ;
					}
					else
						if (this.EntityState == EntityState.Unchanged) 
							this.EntityState = EntityState.Changed ;
				}

				this.bindingIsNew = false ;
	            this.inTxn = false;	            
	        }
	        //Console.WriteLine("End EndEdit");
	    }
	    
	    /// <summary>
        /// Gets or sets the parent collection.
        /// </summary>
        /// <value>The parent collection.</value>
	    [XmlIgnore]
		[Browsable(false)]
	    public override object ParentCollection
	    {
	        get 
	        {
	            return (object)this.parentCollection;
	        }
	        set 
	        {
	            this.parentCollection = value as TList<ProductCrossSell>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as ProductCrossSell);
	        }
	    }


		#endregion
		
		#region Methods	
			
		///<summary>
		///  Revert all changes and restore original values.
		///  Currently not supported.
		///</summary>
		public override void CancelChanges()
		{
			IEditableObject obj = (IEditableObject) this;
			obj.CancelEdit();
		}	
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed ProductCrossSell Entity 
		///</summary>
		public virtual ProductCrossSell Copy()
		{
			//shallow copy entity
			ProductCrossSell copy = new ProductCrossSell();
			copy.ProductCrossSellTypeId = this.ProductCrossSellTypeId;
			copy.PortalId = this.PortalId;
			copy.ProductId = this.ProductId;
			copy.RelatedProductId = this.RelatedProductId;
			copy.DisplayOrder = this.DisplayOrder;
					
			copy.AcceptChanges();
			return (ProductCrossSell)copy;
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone()
		{
			return this.Copy();
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		
		///<summary>
		///  Returns a Typed ProductCrossSell Entity which is a deep copy of the current entity.
		///</summary>
		public virtual ProductCrossSell DeepCopy()
		{
			return EntityHelper.Clone<ProductCrossSell>(this as ProductCrossSell);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="ProductCrossSellBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(ProductCrossSellBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="ProductCrossSellBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="ProductCrossSellBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="ProductCrossSellBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(ProductCrossSellBase Object1, ProductCrossSellBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.ProductCrossSellTypeId != Object2.ProductCrossSellTypeId)
				equal = false;
			if (Object1.PortalId != Object2.PortalId)
				equal = false;
			if (Object1.ProductId != Object2.ProductId)
				equal = false;
			if (Object1.RelatedProductId != Object2.RelatedProductId)
				equal = false;
			if ( Object1.DisplayOrder != null && Object2.DisplayOrder != null )
			{
				if (Object1.DisplayOrder != Object2.DisplayOrder)
					equal = false;
			}
			else if (Object1.DisplayOrder == null ^ Object2.DisplayOrder == null )
			{
				equal = false;
			}
			return equal;
		}
		
		#endregion
		
		#region IComparable Members
		///<summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		///<param name="obj">An object to compare to this instance, or a null reference (Nothing in Visual Basic).</param>
		///</summary>
		///<returns>A signed integer that indicates the relative order of this instance and obj.</returns>
		public virtual int CompareTo(object obj)
		{
			throw new NotImplementedException();
			// TODO -> generate a strongly typed IComparer in the concrete class
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((ProductCrossSellBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static ProductCrossSellComparer GetComparer()
        {
            return new ProductCrossSellComparer();
        }
        */

        // Comparer delegates back to ProductCrossSell
        // Employee uses the integer's default
        // CompareTo method
        /*
        public int CompareTo(Item rhs)
        {
            return this.Id.CompareTo(rhs.Id);
        }
        */

/*
        // Special implementation to be called by custom comparer
        public int CompareTo(ProductCrossSell rhs, ProductCrossSellColumn which)
        {
            switch (which)
            {
            	
            	
            	case ProductCrossSellColumn.ProductCrossSellTypeId:
            		return this.ProductCrossSellTypeId.CompareTo(rhs.ProductCrossSellTypeId);
            		
            		                 
            	
            	
            	case ProductCrossSellColumn.PortalId:
            		return this.PortalId.CompareTo(rhs.PortalId);
            		
            		                 
            	
            	
            	case ProductCrossSellColumn.ProductId:
            		return this.ProductId.CompareTo(rhs.ProductId);
            		
            		                 
            	
            	
            	case ProductCrossSellColumn.RelatedProductId:
            		return this.RelatedProductId.CompareTo(rhs.RelatedProductId);
            		
            		                 
            	
            	
            	case ProductCrossSellColumn.DisplayOrder:
            		return this.DisplayOrder.Value.CompareTo(rhs.DisplayOrder.Value);
            		
            		                 
            }
            return 0;
        }
        */
	
		#endregion
		
		#region IComponent Members
		
		private ISite _site = null;

		/// <summary>
		/// Gets or Sets the site where this data is located.
		/// </summary>
		[XmlIgnore]
		[SoapIgnore]
		[Browsable(false)]
		public ISite Site
		{
			get{ return this._site; }
			set{ this._site = value; }
		}

		#endregion

		#region IDisposable Members
		
		/// <summary>
		/// Notify those that care when we dispose.
		/// </summary>
		[field:NonSerialized]
		public event System.EventHandler Disposed;

		/// <summary>
		/// Clean up. Nothing here though.
		/// </summary>
		public void Dispose()
		{
			this.parentCollection = null;
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// Clean up.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				EventHandler handler = Disposed;
				if (handler != null)
					handler(this, EventArgs.Empty);
			}
		}
		
		#endregion
				
		#region IEntityKey<ProductCrossSellKey> Members
		
		// member variable for the EntityId property
		private ProductCrossSellKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public ProductCrossSellKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new ProductCrossSellKey(this);
				}

				return _entityId;
			}
			set
			{
				if ( value != null )
				{
					value.Entity = this;
				}
				
				_entityId = value;
			}
		}
		
		#endregion
		
		#region EntityTrackingKey
		///<summary>
		/// Provides the tracking key for the <see cref="EntityLocator"/>
		///</summary>
		[XmlIgnore]
		public override string EntityTrackingKey
		{
			get
			{
				if(entityTrackingKey == null)
					entityTrackingKey = @"ProductCrossSell" 
					+ this.ProductCrossSellTypeId.ToString();
				return entityTrackingKey;
			}
			set
		    {
		        if (value != null)
                    entityTrackingKey = value;
		    }
		}
		#endregion 
		
		#region ToString Method
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{6}{5}- ProductCrossSellTypeId: {0}{5}- PortalId: {1}{5}- ProductId: {2}{5}- RelatedProductId: {3}{5}- DisplayOrder: {4}{5}", 
				this.ProductCrossSellTypeId,
				this.PortalId,
				this.ProductId,
				this.RelatedProductId,
				(this.DisplayOrder == null) ? string.Empty : this.DisplayOrder.ToString(),
				Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'ZNodeProductCrossSell' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class ProductCrossSellEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// ProductCrossSellTypeId : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "ZNodeProductCrossSell"</remarks>
			public System.Int32 ProductCrossSellTypeId;
				
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// PortalId : 
		/// </summary>
		public System.Int32		  PortalId = (int)0;
		
		/// <summary>
		/// ProductId : 
		/// </summary>
		public System.Int32		  ProductId = (int)0;
		
		/// <summary>
		/// RelatedProductId : 
		/// </summary>
		public System.Int32		  RelatedProductId = (int)0;
		
		/// <summary>
		/// DisplayOrder : 
		/// </summary>
		public System.Int32?		  DisplayOrder = (int)0;
		#endregion
			
		#endregion Variable Declarations
		
		#region Clone
		public Object Clone()
		{
			ProductCrossSellEntityData _tmp = new ProductCrossSellEntityData();
						
			_tmp.ProductCrossSellTypeId = this.ProductCrossSellTypeId;
			
			_tmp.PortalId = this.PortalId;
			_tmp.ProductId = this.ProductId;
			_tmp.RelatedProductId = this.RelatedProductId;
			_tmp.DisplayOrder = this.DisplayOrder;
			
			return _tmp;
		}
		#endregion 
		
		#region Data Properties

		#endregion Data Properties

	}//End struct


		#endregion
		
		#region Validation
		
		/// <summary>
		/// Assigns validation rules to this object based on model definition.
		/// </summary>
		/// <remarks>This method overrides the base class to add schema related validation.</remarks>
		protected override void AddValidationRules()
		{
			//Validation rules based on database schema.
		}
   		#endregion
	
	} // End Class
	
	#region ProductCrossSellComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class ProductCrossSellComparer : System.Collections.Generic.IComparer<ProductCrossSell>
	{
		ProductCrossSellColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:ProductCrossSellComparer"/> class.
        /// </summary>
		public ProductCrossSellComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public ProductCrossSellComparer(ProductCrossSellColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="ProductCrossSell"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="ProductCrossSell"/> to compare.</param>
        /// <param name="b">The second <c>ProductCrossSell</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(ProductCrossSell a, ProductCrossSell b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(ProductCrossSell entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(ProductCrossSell a, ProductCrossSell b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public ProductCrossSellColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region ProductCrossSellKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="ProductCrossSell"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class ProductCrossSellKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the ProductCrossSellKey class.
		/// </summary>
		public ProductCrossSellKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the ProductCrossSellKey class.
		/// </summary>
		public ProductCrossSellKey(ProductCrossSellBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.productCrossSellTypeId = entity.ProductCrossSellTypeId;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the ProductCrossSellKey class.
		/// </summary>
		public ProductCrossSellKey(System.Int32 productCrossSellTypeId)
		{
			#region Init Properties

			this.productCrossSellTypeId = productCrossSellTypeId;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private ProductCrossSellBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public ProductCrossSellBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the ProductCrossSellTypeId property
		private System.Int32 productCrossSellTypeId;
		
		/// <summary>
		/// Gets or sets the ProductCrossSellTypeId property.
		/// </summary>
		public System.Int32 ProductCrossSellTypeId
		{
			get { return productCrossSellTypeId; }
			set
			{
				if ( Entity != null )
				{
					Entity.ProductCrossSellTypeId = value;
				}
				
				productCrossSellTypeId = value;
			}
		}
		
		#endregion

		#region Methods
		
		/// <summary>
		/// Reads values from the supplied <see cref="IDictionary"/> object into
		/// properties of the current object.
		/// </summary>
		/// <param name="values">An <see cref="IDictionary"/> instance that contains
		/// the key/value pairs to be used as property values.</param>
		public override void Load(IDictionary values)
		{
			#region Init Properties

			if ( values != null )
			{
				ProductCrossSellTypeId = ( values["ProductCrossSellTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductCrossSellTypeId"], typeof(System.Int32)) : (int)0;
			}

			#endregion
		}

		/// <summary>
		/// Creates a new <see cref="IDictionary"/> object and populates it
		/// with the property values of the current object.
		/// </summary>
		/// <returns>A collection of name/value pairs.</returns>
		public override IDictionary ToDictionary()
		{
			IDictionary values = new Hashtable();

			#region Init Dictionary

			values.Add("ProductCrossSellTypeId", ProductCrossSellTypeId);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("ProductCrossSellTypeId: {0}{1}",
								ProductCrossSellTypeId,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region ProductCrossSellColumn Enum
	
	/// <summary>
	/// Enumerate the ProductCrossSell columns.
	/// </summary>
	[Serializable]
	public enum ProductCrossSellColumn : int
	{
		/// <summary>
		/// ProductCrossSellTypeId : 
		/// </summary>
		[EnumTextValue("ProductCrossSellTypeId")]
		[ColumnEnum("ProductCrossSellTypeId", typeof(System.Int32), System.Data.DbType.Int32, true, true, false)]
		ProductCrossSellTypeId = 1,
		/// <summary>
		/// PortalId : 
		/// </summary>
		[EnumTextValue("PortalId")]
		[ColumnEnum("PortalId", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		PortalId = 2,
		/// <summary>
		/// ProductId : 
		/// </summary>
		[EnumTextValue("ProductId")]
		[ColumnEnum("ProductId", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		ProductId = 3,
		/// <summary>
		/// RelatedProductId : 
		/// </summary>
		[EnumTextValue("RelatedProductId")]
		[ColumnEnum("RelatedProductId", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		RelatedProductId = 4,
		/// <summary>
		/// DisplayOrder : 
		/// </summary>
		[EnumTextValue("DisplayOrder")]
		[ColumnEnum("DisplayOrder", typeof(System.Int32), System.Data.DbType.Int32, false, false, true)]
		DisplayOrder = 5
	}//End enum

	#endregion ProductCrossSellColumn Enum

} // end namespace
