﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Thursday, October 18, 2007
	Important: Do not modify this file. Edit the file ProductHighlight.cs instead.
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
	#region ProductHighlightEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="ProductHighlight"/> object.
	/// </remarks>
	public class ProductHighlightEventArgs : System.EventArgs
	{
		private ProductHighlightColumn column;
		private object value;
		
		
		///<summary>
		/// Initalizes a new Instance of the ProductHighlightEventArgs class.
		///</summary>
		public ProductHighlightEventArgs(ProductHighlightColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the ProductHighlightEventArgs class.
		///</summary>
		public ProductHighlightEventArgs(ProductHighlightColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		
		///<summary>
		/// The ProductHighlightColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="ProductHighlightColumn" />
		public ProductHighlightColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all ProductHighlight related events.
	///</summary>
	public delegate void ProductHighlightEventHandler(object sender, ProductHighlightEventArgs e);
	
	///<summary>
	/// An object representation of the 'ZNodeProductHighlight' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(ProductHighlight))]
	public abstract partial class ProductHighlightBase : EntityBase, IEntityId<ProductHighlightKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private ProductHighlightEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//ProductHighlightEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private ProductHighlightEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<ProductHighlight> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event ProductHighlightEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event ProductHighlightEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="ProductHighlightBase"/> instance.
		///</summary>
		public ProductHighlightBase()
		{
			this.entityData = new ProductHighlightEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="ProductHighlightBase"/> instance.
		///</summary>
		///<param name="productHighlightProductHighlightID"></param>
		///<param name="productHighlightProductID"></param>
		///<param name="productHighlightHighlightID"></param>
		///<param name="productHighlightDisplayOrder"></param>
		public ProductHighlightBase(System.Int32 productHighlightProductHighlightID, System.Int32 productHighlightProductID, 
			System.Int32 productHighlightHighlightID, System.Int32? productHighlightDisplayOrder)
		{
			this.entityData = new ProductHighlightEntityData();
			this.backupData = null;

			this.ProductHighlightID = productHighlightProductHighlightID;
			this.ProductID = productHighlightProductID;
			this.HighlightID = productHighlightHighlightID;
			this.DisplayOrder = productHighlightDisplayOrder;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="ProductHighlight"/> instance.
		///</summary>
		///<param name="productHighlightProductHighlightID"></param>
		///<param name="productHighlightProductID"></param>
		///<param name="productHighlightHighlightID"></param>
		///<param name="productHighlightDisplayOrder"></param>
		public static ProductHighlight CreateProductHighlight(System.Int32 productHighlightProductHighlightID, System.Int32 productHighlightProductID, 
			System.Int32 productHighlightHighlightID, System.Int32? productHighlightDisplayOrder)
		{
			ProductHighlight newProductHighlight = new ProductHighlight();
			newProductHighlight.ProductHighlightID = productHighlightProductHighlightID;
			newProductHighlight.ProductID = productHighlightProductID;
			newProductHighlight.HighlightID = productHighlightHighlightID;
			newProductHighlight.DisplayOrder = productHighlightDisplayOrder;
			return newProductHighlight;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ProductHighlightColumn"/> which has raised the event.</param>
		public void OnColumnChanging(ProductHighlightColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ProductHighlightColumn"/> which has raised the event.</param>
		public void OnColumnChanged(ProductHighlightColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ProductHighlightColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(ProductHighlightColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				ProductHighlightEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new ProductHighlightEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ProductHighlightColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(ProductHighlightColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				ProductHighlightEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new ProductHighlightEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the ProductHighlightID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true, false, false)]
		public virtual System.Int32 ProductHighlightID
		{
			get
			{
				return this.entityData.ProductHighlightID; 
			}
			
			set
			{
				if (this.entityData.ProductHighlightID == value)
					return;
					
					
				OnColumnChanging(ProductHighlightColumn.ProductHighlightID, this.entityData.ProductHighlightID);
				this.entityData.ProductHighlightID = value;
				this.EntityId.ProductHighlightID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ProductHighlightColumn.ProductHighlightID, this.entityData.ProductHighlightID);
				OnPropertyChanged("ProductHighlightID");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the ProductHighlightID property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the ProductHighlightID property.</remarks>
		/// <value>This type is int</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.Int32 OriginalProductHighlightID
		{
			get { return this.entityData.OriginalProductHighlightID; }
			set { this.entityData.OriginalProductHighlightID = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the ProductID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Int32 ProductID
		{
			get
			{
				return this.entityData.ProductID; 
			}
			
			set
			{
				if (this.entityData.ProductID == value)
					return;
					
					
				OnColumnChanging(ProductHighlightColumn.ProductID, this.entityData.ProductID);
				this.entityData.ProductID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ProductHighlightColumn.ProductID, this.entityData.ProductID);
				OnPropertyChanged("ProductID");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the HighlightID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Int32 HighlightID
		{
			get
			{
				return this.entityData.HighlightID; 
			}
			
			set
			{
				if (this.entityData.HighlightID == value)
					return;
					
					
				OnColumnChanging(ProductHighlightColumn.HighlightID, this.entityData.HighlightID);
				this.entityData.HighlightID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ProductHighlightColumn.HighlightID, this.entityData.HighlightID);
				OnPropertyChanged("HighlightID");
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
					
					
				OnColumnChanging(ProductHighlightColumn.DisplayOrder, this.entityData.DisplayOrder);
				this.entityData.DisplayOrder = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ProductHighlightColumn.DisplayOrder, this.entityData.DisplayOrder);
				OnPropertyChanged("DisplayOrder");
			}
		}
		

		#region Source Foreign Key Property
				
		private Highlight _highlightIDSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="Highlight"/>.
		/// </summary>
		/// <value>The source Highlight for HighlightID.</value>
        [XmlIgnore()]
		[Browsable(false), BindableAttribute()]
		public virtual Highlight HighlightIDSource
      	{
            get { return this._highlightIDSource; }
            set { this._highlightIDSource = value; }
      	}
		private Product _productIDSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="Product"/>.
		/// </summary>
		/// <value>The source Product for ProductID.</value>
        [XmlIgnore()]
		[Browsable(false), BindableAttribute()]
		public virtual Product ProductIDSource
      	{
            get { return this._productIDSource; }
            set { this._productIDSource = value; }
      	}
		#endregion
			
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "ZNodeProductHighlight"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"ProductHighlightID", "ProductID", "HighlightID", "DisplayOrder"};
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
	            this.backupData = this.entityData.Clone() as ProductHighlightEntityData;
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
						this.parentCollection.Remove( (ProductHighlight) this ) ;
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
	            this.parentCollection = value as TList<ProductHighlight>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as ProductHighlight);
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
		///  Returns a Typed ProductHighlight Entity 
		///</summary>
		public virtual ProductHighlight Copy()
		{
			//shallow copy entity
			ProductHighlight copy = new ProductHighlight();
			copy.ProductHighlightID = this.ProductHighlightID;
			copy.OriginalProductHighlightID = this.OriginalProductHighlightID;
			copy.ProductID = this.ProductID;
			copy.HighlightID = this.HighlightID;
			copy.DisplayOrder = this.DisplayOrder;
					
			copy.AcceptChanges();
			return (ProductHighlight)copy;
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
		///  Returns a Typed ProductHighlight Entity which is a deep copy of the current entity.
		///</summary>
		public virtual ProductHighlight DeepCopy()
		{
			return EntityHelper.Clone<ProductHighlight>(this as ProductHighlight);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="ProductHighlightBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(ProductHighlightBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="ProductHighlightBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="ProductHighlightBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="ProductHighlightBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(ProductHighlightBase Object1, ProductHighlightBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.ProductHighlightID != Object2.ProductHighlightID)
				equal = false;
			if (Object1.ProductID != Object2.ProductID)
				equal = false;
			if (Object1.HighlightID != Object2.HighlightID)
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((ProductHighlightBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static ProductHighlightComparer GetComparer()
        {
            return new ProductHighlightComparer();
        }
        */

        // Comparer delegates back to ProductHighlight
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
        public int CompareTo(ProductHighlight rhs, ProductHighlightColumn which)
        {
            switch (which)
            {
            	
            	
            	case ProductHighlightColumn.ProductHighlightID:
            		return this.ProductHighlightID.CompareTo(rhs.ProductHighlightID);
            		
            		                 
            	
            	
            	case ProductHighlightColumn.ProductID:
            		return this.ProductID.CompareTo(rhs.ProductID);
            		
            		                 
            	
            	
            	case ProductHighlightColumn.HighlightID:
            		return this.HighlightID.CompareTo(rhs.HighlightID);
            		
            		                 
            	
            	
            	case ProductHighlightColumn.DisplayOrder:
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
				
		#region IEntityKey<ProductHighlightKey> Members
		
		// member variable for the EntityId property
		private ProductHighlightKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public ProductHighlightKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new ProductHighlightKey(this);
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
					entityTrackingKey = @"ProductHighlight" 
					+ this.ProductHighlightID.ToString();
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
				"{5}{4}- ProductHighlightID: {0}{4}- ProductID: {1}{4}- HighlightID: {2}{4}- DisplayOrder: {3}{4}", 
				this.ProductHighlightID,
				this.ProductID,
				this.HighlightID,
				(this.DisplayOrder == null) ? string.Empty : this.DisplayOrder.ToString(),
				Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'ZNodeProductHighlight' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class ProductHighlightEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// ProductHighlightID : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "ZNodeProductHighlight"</remarks>
			public System.Int32 ProductHighlightID;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.Int32 OriginalProductHighlightID;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// ProductID : 
		/// </summary>
		public System.Int32		  ProductID = (int)0;
		
		/// <summary>
		/// HighlightID : 
		/// </summary>
		public System.Int32		  HighlightID = (int)0;
		
		/// <summary>
		/// DisplayOrder : 
		/// </summary>
		public System.Int32?		  DisplayOrder = (int)0;
		#endregion
			
		#endregion Variable Declarations
		
		#region Clone
		public Object Clone()
		{
			ProductHighlightEntityData _tmp = new ProductHighlightEntityData();
						
			_tmp.ProductHighlightID = this.ProductHighlightID;
			_tmp.OriginalProductHighlightID = this.OriginalProductHighlightID;
			
			_tmp.ProductID = this.ProductID;
			_tmp.HighlightID = this.HighlightID;
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
	
	#region ProductHighlightComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class ProductHighlightComparer : System.Collections.Generic.IComparer<ProductHighlight>
	{
		ProductHighlightColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:ProductHighlightComparer"/> class.
        /// </summary>
		public ProductHighlightComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public ProductHighlightComparer(ProductHighlightColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="ProductHighlight"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="ProductHighlight"/> to compare.</param>
        /// <param name="b">The second <c>ProductHighlight</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(ProductHighlight a, ProductHighlight b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(ProductHighlight entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(ProductHighlight a, ProductHighlight b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public ProductHighlightColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region ProductHighlightKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="ProductHighlight"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class ProductHighlightKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the ProductHighlightKey class.
		/// </summary>
		public ProductHighlightKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the ProductHighlightKey class.
		/// </summary>
		public ProductHighlightKey(ProductHighlightBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.productHighlightID = entity.ProductHighlightID;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the ProductHighlightKey class.
		/// </summary>
		public ProductHighlightKey(System.Int32 productHighlightID)
		{
			#region Init Properties

			this.productHighlightID = productHighlightID;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private ProductHighlightBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public ProductHighlightBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the ProductHighlightID property
		private System.Int32 productHighlightID;
		
		/// <summary>
		/// Gets or sets the ProductHighlightID property.
		/// </summary>
		public System.Int32 ProductHighlightID
		{
			get { return productHighlightID; }
			set
			{
				if ( Entity != null )
				{
					Entity.ProductHighlightID = value;
				}
				
				productHighlightID = value;
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
				ProductHighlightID = ( values["ProductHighlightID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductHighlightID"], typeof(System.Int32)) : (int)0;
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

			values.Add("ProductHighlightID", ProductHighlightID);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("ProductHighlightID: {0}{1}",
								ProductHighlightID,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region ProductHighlightColumn Enum
	
	/// <summary>
	/// Enumerate the ProductHighlight columns.
	/// </summary>
	[Serializable]
	public enum ProductHighlightColumn : int
	{
		/// <summary>
		/// ProductHighlightID : 
		/// </summary>
		[EnumTextValue("ProductHighlightID")]
		[ColumnEnum("ProductHighlightID", typeof(System.Int32), System.Data.DbType.Int32, true, false, false)]
		ProductHighlightID = 1,
		/// <summary>
		/// ProductID : 
		/// </summary>
		[EnumTextValue("ProductID")]
		[ColumnEnum("ProductID", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		ProductID = 2,
		/// <summary>
		/// HighlightID : 
		/// </summary>
		[EnumTextValue("HighlightID")]
		[ColumnEnum("HighlightID", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		HighlightID = 3,
		/// <summary>
		/// DisplayOrder : 
		/// </summary>
		[EnumTextValue("DisplayOrder")]
		[ColumnEnum("DisplayOrder", typeof(System.Int32), System.Data.DbType.Int32, false, false, true)]
		DisplayOrder = 4
	}//End enum

	#endregion ProductHighlightColumn Enum

} // end namespace
