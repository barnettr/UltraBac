﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Thursday, October 18, 2007
	Important: Do not modify this file. Edit the file ShippingServiceCode.cs instead.
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
	#region ShippingServiceCodeEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="ShippingServiceCode"/> object.
	/// </remarks>
	public class ShippingServiceCodeEventArgs : System.EventArgs
	{
		private ShippingServiceCodeColumn column;
		private object value;
		
		
		///<summary>
		/// Initalizes a new Instance of the ShippingServiceCodeEventArgs class.
		///</summary>
		public ShippingServiceCodeEventArgs(ShippingServiceCodeColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the ShippingServiceCodeEventArgs class.
		///</summary>
		public ShippingServiceCodeEventArgs(ShippingServiceCodeColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		
		///<summary>
		/// The ShippingServiceCodeColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="ShippingServiceCodeColumn" />
		public ShippingServiceCodeColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all ShippingServiceCode related events.
	///</summary>
	public delegate void ShippingServiceCodeEventHandler(object sender, ShippingServiceCodeEventArgs e);
	
	///<summary>
	/// An object representation of the 'ZNodeShippingServiceCode' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(ShippingServiceCode))]
	public abstract partial class ShippingServiceCodeBase : EntityBase, IEntityId<ShippingServiceCodeKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private ShippingServiceCodeEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//ShippingServiceCodeEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private ShippingServiceCodeEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<ShippingServiceCode> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event ShippingServiceCodeEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event ShippingServiceCodeEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="ShippingServiceCodeBase"/> instance.
		///</summary>
		public ShippingServiceCodeBase()
		{
			this.entityData = new ShippingServiceCodeEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="ShippingServiceCodeBase"/> instance.
		///</summary>
		///<param name="shippingServiceCodeShippingTypeID"></param>
		///<param name="shippingServiceCodeCode"></param>
		///<param name="shippingServiceCodeDescription"></param>
		///<param name="shippingServiceCodeDisplayOrder"></param>
		///<param name="shippingServiceCodeActiveInd"></param>
		public ShippingServiceCodeBase(System.Int32 shippingServiceCodeShippingTypeID, System.String shippingServiceCodeCode, 
			System.String shippingServiceCodeDescription, System.Int32? shippingServiceCodeDisplayOrder, System.Boolean shippingServiceCodeActiveInd)
		{
			this.entityData = new ShippingServiceCodeEntityData();
			this.backupData = null;

			this.ShippingTypeID = shippingServiceCodeShippingTypeID;
			this.Code = shippingServiceCodeCode;
			this.Description = shippingServiceCodeDescription;
			this.DisplayOrder = shippingServiceCodeDisplayOrder;
			this.ActiveInd = shippingServiceCodeActiveInd;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="ShippingServiceCode"/> instance.
		///</summary>
		///<param name="shippingServiceCodeShippingTypeID"></param>
		///<param name="shippingServiceCodeCode"></param>
		///<param name="shippingServiceCodeDescription"></param>
		///<param name="shippingServiceCodeDisplayOrder"></param>
		///<param name="shippingServiceCodeActiveInd"></param>
		public static ShippingServiceCode CreateShippingServiceCode(System.Int32 shippingServiceCodeShippingTypeID, System.String shippingServiceCodeCode, 
			System.String shippingServiceCodeDescription, System.Int32? shippingServiceCodeDisplayOrder, System.Boolean shippingServiceCodeActiveInd)
		{
			ShippingServiceCode newShippingServiceCode = new ShippingServiceCode();
			newShippingServiceCode.ShippingTypeID = shippingServiceCodeShippingTypeID;
			newShippingServiceCode.Code = shippingServiceCodeCode;
			newShippingServiceCode.Description = shippingServiceCodeDescription;
			newShippingServiceCode.DisplayOrder = shippingServiceCodeDisplayOrder;
			newShippingServiceCode.ActiveInd = shippingServiceCodeActiveInd;
			return newShippingServiceCode;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ShippingServiceCodeColumn"/> which has raised the event.</param>
		public void OnColumnChanging(ShippingServiceCodeColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ShippingServiceCodeColumn"/> which has raised the event.</param>
		public void OnColumnChanged(ShippingServiceCodeColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ShippingServiceCodeColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(ShippingServiceCodeColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				ShippingServiceCodeEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new ShippingServiceCodeEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ShippingServiceCodeColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(ShippingServiceCodeColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				ShippingServiceCodeEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new ShippingServiceCodeEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the ShippingServiceCodeID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[ReadOnlyAttribute(false)/*, XmlIgnoreAttribute()*/, DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true, true, false)]
		public virtual System.Int32 ShippingServiceCodeID
		{
			get
			{
				return this.entityData.ShippingServiceCodeID; 
			}
			
			set
			{
				if (this.entityData.ShippingServiceCodeID == value)
					return;
					
					
				OnColumnChanging(ShippingServiceCodeColumn.ShippingServiceCodeID, this.entityData.ShippingServiceCodeID);
				this.entityData.ShippingServiceCodeID = value;
				this.EntityId.ShippingServiceCodeID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ShippingServiceCodeColumn.ShippingServiceCodeID, this.entityData.ShippingServiceCodeID);
				OnPropertyChanged("ShippingServiceCodeID");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the ShippingTypeID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Int32 ShippingTypeID
		{
			get
			{
				return this.entityData.ShippingTypeID; 
			}
			
			set
			{
				if (this.entityData.ShippingTypeID == value)
					return;
					
					
				OnColumnChanging(ShippingServiceCodeColumn.ShippingTypeID, this.entityData.ShippingTypeID);
				this.entityData.ShippingTypeID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ShippingServiceCodeColumn.ShippingTypeID, this.entityData.ShippingTypeID);
				OnPropertyChanged("ShippingTypeID");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Code property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.String Code
		{
			get
			{
				return this.entityData.Code; 
			}
			
			set
			{
				if (this.entityData.Code == value)
					return;
					
					
				OnColumnChanging(ShippingServiceCodeColumn.Code, this.entityData.Code);
				this.entityData.Code = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ShippingServiceCodeColumn.Code, this.entityData.Code);
				OnPropertyChanged("Code");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Description property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.String Description
		{
			get
			{
				return this.entityData.Description; 
			}
			
			set
			{
				if (this.entityData.Description == value)
					return;
					
					
				OnColumnChanging(ShippingServiceCodeColumn.Description, this.entityData.Description);
				this.entityData.Description = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ShippingServiceCodeColumn.Description, this.entityData.Description);
				OnPropertyChanged("Description");
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
					
					
				OnColumnChanging(ShippingServiceCodeColumn.DisplayOrder, this.entityData.DisplayOrder);
				this.entityData.DisplayOrder = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ShippingServiceCodeColumn.DisplayOrder, this.entityData.DisplayOrder);
				OnPropertyChanged("DisplayOrder");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the ActiveInd property. 
		///		
		/// </summary>
		/// <value>This type is bit.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Boolean ActiveInd
		{
			get
			{
				return this.entityData.ActiveInd; 
			}
			
			set
			{
				if (this.entityData.ActiveInd == value)
					return;
					
					
				OnColumnChanging(ShippingServiceCodeColumn.ActiveInd, this.entityData.ActiveInd);
				this.entityData.ActiveInd = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ShippingServiceCodeColumn.ActiveInd, this.entityData.ActiveInd);
				OnPropertyChanged("ActiveInd");
			}
		}
		

		#region Source Foreign Key Property
				
		private ShippingType _shippingTypeIDSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="ShippingType"/>.
		/// </summary>
		/// <value>The source ShippingType for ShippingTypeID.</value>
        [XmlIgnore()]
		[Browsable(false), BindableAttribute()]
		public virtual ShippingType ShippingTypeIDSource
      	{
            get { return this._shippingTypeIDSource; }
            set { this._shippingTypeIDSource = value; }
      	}
		#endregion
			
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "ZNodeShippingServiceCode"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"ShippingServiceCodeID", "ShippingTypeID", "Code", "Description", "DisplayOrder", "ActiveInd"};
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
	            this.backupData = this.entityData.Clone() as ShippingServiceCodeEntityData;
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
						this.parentCollection.Remove( (ShippingServiceCode) this ) ;
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
	            this.parentCollection = value as TList<ShippingServiceCode>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as ShippingServiceCode);
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
		///  Returns a Typed ShippingServiceCode Entity 
		///</summary>
		public virtual ShippingServiceCode Copy()
		{
			//shallow copy entity
			ShippingServiceCode copy = new ShippingServiceCode();
			copy.ShippingServiceCodeID = this.ShippingServiceCodeID;
			copy.ShippingTypeID = this.ShippingTypeID;
			copy.Code = this.Code;
			copy.Description = this.Description;
			copy.DisplayOrder = this.DisplayOrder;
			copy.ActiveInd = this.ActiveInd;
					
			copy.AcceptChanges();
			return (ShippingServiceCode)copy;
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
		///  Returns a Typed ShippingServiceCode Entity which is a deep copy of the current entity.
		///</summary>
		public virtual ShippingServiceCode DeepCopy()
		{
			return EntityHelper.Clone<ShippingServiceCode>(this as ShippingServiceCode);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="ShippingServiceCodeBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(ShippingServiceCodeBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="ShippingServiceCodeBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="ShippingServiceCodeBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="ShippingServiceCodeBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(ShippingServiceCodeBase Object1, ShippingServiceCodeBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.ShippingServiceCodeID != Object2.ShippingServiceCodeID)
				equal = false;
			if (Object1.ShippingTypeID != Object2.ShippingTypeID)
				equal = false;
			if (Object1.Code != Object2.Code)
				equal = false;
			if (Object1.Description != Object2.Description)
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
			if (Object1.ActiveInd != Object2.ActiveInd)
				equal = false;
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((ShippingServiceCodeBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static ShippingServiceCodeComparer GetComparer()
        {
            return new ShippingServiceCodeComparer();
        }
        */

        // Comparer delegates back to ShippingServiceCode
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
        public int CompareTo(ShippingServiceCode rhs, ShippingServiceCodeColumn which)
        {
            switch (which)
            {
            	
            	
            	case ShippingServiceCodeColumn.ShippingServiceCodeID:
            		return this.ShippingServiceCodeID.CompareTo(rhs.ShippingServiceCodeID);
            		
            		                 
            	
            	
            	case ShippingServiceCodeColumn.ShippingTypeID:
            		return this.ShippingTypeID.CompareTo(rhs.ShippingTypeID);
            		
            		                 
            	
            	
            	case ShippingServiceCodeColumn.Code:
            		return this.Code.CompareTo(rhs.Code);
            		
            		                 
            	
            	
            	case ShippingServiceCodeColumn.Description:
            		return this.Description.CompareTo(rhs.Description);
            		
            		                 
            	
            	
            	case ShippingServiceCodeColumn.DisplayOrder:
            		return this.DisplayOrder.Value.CompareTo(rhs.DisplayOrder.Value);
            		
            		                 
            	
            	
            	case ShippingServiceCodeColumn.ActiveInd:
            		return this.ActiveInd.CompareTo(rhs.ActiveInd);
            		
            		                 
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
				
		#region IEntityKey<ShippingServiceCodeKey> Members
		
		// member variable for the EntityId property
		private ShippingServiceCodeKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public ShippingServiceCodeKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new ShippingServiceCodeKey(this);
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
					entityTrackingKey = @"ShippingServiceCode" 
					+ this.ShippingServiceCodeID.ToString();
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
				"{7}{6}- ShippingServiceCodeID: {0}{6}- ShippingTypeID: {1}{6}- Code: {2}{6}- Description: {3}{6}- DisplayOrder: {4}{6}- ActiveInd: {5}{6}", 
				this.ShippingServiceCodeID,
				this.ShippingTypeID,
				this.Code,
				this.Description,
				(this.DisplayOrder == null) ? string.Empty : this.DisplayOrder.ToString(),
				this.ActiveInd,
				Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'ZNodeShippingServiceCode' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class ShippingServiceCodeEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// ShippingServiceCodeID : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "ZNodeShippingServiceCode"</remarks>
			public System.Int32 ShippingServiceCodeID;
				
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// ShippingTypeID : 
		/// </summary>
		public System.Int32		  ShippingTypeID = (int)0;
		
		/// <summary>
		/// Code : 
		/// </summary>
		public System.String		  Code = string.Empty;
		
		/// <summary>
		/// Description : 
		/// </summary>
		public System.String		  Description = string.Empty;
		
		/// <summary>
		/// DisplayOrder : 
		/// </summary>
		public System.Int32?		  DisplayOrder = (int)0;
		
		/// <summary>
		/// ActiveInd : 
		/// </summary>
		public System.Boolean		  ActiveInd = false;
		#endregion
			
		#endregion Variable Declarations
		
		#region Clone
		public Object Clone()
		{
			ShippingServiceCodeEntityData _tmp = new ShippingServiceCodeEntityData();
						
			_tmp.ShippingServiceCodeID = this.ShippingServiceCodeID;
			
			_tmp.ShippingTypeID = this.ShippingTypeID;
			_tmp.Code = this.Code;
			_tmp.Description = this.Description;
			_tmp.DisplayOrder = this.DisplayOrder;
			_tmp.ActiveInd = this.ActiveInd;
			
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
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"Code");
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"Description");
		}
   		#endregion
	
	} // End Class
	
	#region ShippingServiceCodeComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class ShippingServiceCodeComparer : System.Collections.Generic.IComparer<ShippingServiceCode>
	{
		ShippingServiceCodeColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:ShippingServiceCodeComparer"/> class.
        /// </summary>
		public ShippingServiceCodeComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public ShippingServiceCodeComparer(ShippingServiceCodeColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="ShippingServiceCode"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="ShippingServiceCode"/> to compare.</param>
        /// <param name="b">The second <c>ShippingServiceCode</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(ShippingServiceCode a, ShippingServiceCode b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(ShippingServiceCode entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(ShippingServiceCode a, ShippingServiceCode b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public ShippingServiceCodeColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region ShippingServiceCodeKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="ShippingServiceCode"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class ShippingServiceCodeKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the ShippingServiceCodeKey class.
		/// </summary>
		public ShippingServiceCodeKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the ShippingServiceCodeKey class.
		/// </summary>
		public ShippingServiceCodeKey(ShippingServiceCodeBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.shippingServiceCodeID = entity.ShippingServiceCodeID;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the ShippingServiceCodeKey class.
		/// </summary>
		public ShippingServiceCodeKey(System.Int32 shippingServiceCodeID)
		{
			#region Init Properties

			this.shippingServiceCodeID = shippingServiceCodeID;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private ShippingServiceCodeBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public ShippingServiceCodeBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the ShippingServiceCodeID property
		private System.Int32 shippingServiceCodeID;
		
		/// <summary>
		/// Gets or sets the ShippingServiceCodeID property.
		/// </summary>
		public System.Int32 ShippingServiceCodeID
		{
			get { return shippingServiceCodeID; }
			set
			{
				if ( Entity != null )
				{
					Entity.ShippingServiceCodeID = value;
				}
				
				shippingServiceCodeID = value;
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
				ShippingServiceCodeID = ( values["ShippingServiceCodeID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ShippingServiceCodeID"], typeof(System.Int32)) : (int)0;
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

			values.Add("ShippingServiceCodeID", ShippingServiceCodeID);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("ShippingServiceCodeID: {0}{1}",
								ShippingServiceCodeID,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region ShippingServiceCodeColumn Enum
	
	/// <summary>
	/// Enumerate the ShippingServiceCode columns.
	/// </summary>
	[Serializable]
	public enum ShippingServiceCodeColumn : int
	{
		/// <summary>
		/// ShippingServiceCodeID : 
		/// </summary>
		[EnumTextValue("ShippingServiceCodeID")]
		[ColumnEnum("ShippingServiceCodeID", typeof(System.Int32), System.Data.DbType.Int32, true, true, false)]
		ShippingServiceCodeID = 1,
		/// <summary>
		/// ShippingTypeID : 
		/// </summary>
		[EnumTextValue("ShippingTypeID")]
		[ColumnEnum("ShippingTypeID", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		ShippingTypeID = 2,
		/// <summary>
		/// Code : 
		/// </summary>
		[EnumTextValue("Code")]
		[ColumnEnum("Code", typeof(System.String), System.Data.DbType.AnsiString, false, false, false)]
		Code = 3,
		/// <summary>
		/// Description : 
		/// </summary>
		[EnumTextValue("Description")]
		[ColumnEnum("Description", typeof(System.String), System.Data.DbType.AnsiString, false, false, false)]
		Description = 4,
		/// <summary>
		/// DisplayOrder : 
		/// </summary>
		[EnumTextValue("DisplayOrder")]
		[ColumnEnum("DisplayOrder", typeof(System.Int32), System.Data.DbType.Int32, false, false, true)]
		DisplayOrder = 5,
		/// <summary>
		/// ActiveInd : 
		/// </summary>
		[EnumTextValue("ActiveInd")]
		[ColumnEnum("ActiveInd", typeof(System.Boolean), System.Data.DbType.Boolean, false, false, false)]
		ActiveInd = 6
	}//End enum

	#endregion ShippingServiceCodeColumn Enum

} // end namespace
