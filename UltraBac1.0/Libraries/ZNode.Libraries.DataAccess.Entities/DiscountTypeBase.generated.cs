﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Thursday, October 18, 2007
	Important: Do not modify this file. Edit the file DiscountType.cs instead.
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
	#region DiscountTypeEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="DiscountType"/> object.
	/// </remarks>
	public class DiscountTypeEventArgs : System.EventArgs
	{
		private DiscountTypeColumn column;
		private object value;
		
		
		///<summary>
		/// Initalizes a new Instance of the DiscountTypeEventArgs class.
		///</summary>
		public DiscountTypeEventArgs(DiscountTypeColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the DiscountTypeEventArgs class.
		///</summary>
		public DiscountTypeEventArgs(DiscountTypeColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		
		///<summary>
		/// The DiscountTypeColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="DiscountTypeColumn" />
		public DiscountTypeColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all DiscountType related events.
	///</summary>
	public delegate void DiscountTypeEventHandler(object sender, DiscountTypeEventArgs e);
	
	///<summary>
	/// An object representation of the 'ZNodeDiscountType' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(DiscountType))]
	public abstract partial class DiscountTypeBase : EntityBase, IEntityId<DiscountTypeKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private DiscountTypeEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//DiscountTypeEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private DiscountTypeEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<DiscountType> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event DiscountTypeEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event DiscountTypeEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="DiscountTypeBase"/> instance.
		///</summary>
		public DiscountTypeBase()
		{
			this.entityData = new DiscountTypeEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="DiscountTypeBase"/> instance.
		///</summary>
		///<param name="discountTypeDiscountTypeID"></param>
		///<param name="discountTypeDiscountTypeName"></param>
		public DiscountTypeBase(System.Int32 discountTypeDiscountTypeID, System.String discountTypeDiscountTypeName)
		{
			this.entityData = new DiscountTypeEntityData();
			this.backupData = null;

			this.DiscountTypeID = discountTypeDiscountTypeID;
			this.DiscountTypeName = discountTypeDiscountTypeName;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="DiscountType"/> instance.
		///</summary>
		///<param name="discountTypeDiscountTypeID"></param>
		///<param name="discountTypeDiscountTypeName"></param>
		public static DiscountType CreateDiscountType(System.Int32 discountTypeDiscountTypeID, System.String discountTypeDiscountTypeName)
		{
			DiscountType newDiscountType = new DiscountType();
			newDiscountType.DiscountTypeID = discountTypeDiscountTypeID;
			newDiscountType.DiscountTypeName = discountTypeDiscountTypeName;
			return newDiscountType;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="DiscountTypeColumn"/> which has raised the event.</param>
		public void OnColumnChanging(DiscountTypeColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="DiscountTypeColumn"/> which has raised the event.</param>
		public void OnColumnChanged(DiscountTypeColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="DiscountTypeColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(DiscountTypeColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				DiscountTypeEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new DiscountTypeEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="DiscountTypeColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(DiscountTypeColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				DiscountTypeEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new DiscountTypeEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the DiscountTypeID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true, false, false)]
		public virtual System.Int32 DiscountTypeID
		{
			get
			{
				return this.entityData.DiscountTypeID; 
			}
			
			set
			{
				if (this.entityData.DiscountTypeID == value)
					return;
					
					
				OnColumnChanging(DiscountTypeColumn.DiscountTypeID, this.entityData.DiscountTypeID);
				this.entityData.DiscountTypeID = value;
				this.EntityId.DiscountTypeID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(DiscountTypeColumn.DiscountTypeID, this.entityData.DiscountTypeID);
				OnPropertyChanged("DiscountTypeID");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the DiscountTypeID property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the DiscountTypeID property.</remarks>
		/// <value>This type is int</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.Int32 OriginalDiscountTypeID
		{
			get { return this.entityData.OriginalDiscountTypeID; }
			set { this.entityData.OriginalDiscountTypeID = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the DiscountTypeName property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.String DiscountTypeName
		{
			get
			{
				return this.entityData.DiscountTypeName; 
			}
			
			set
			{
				if (this.entityData.DiscountTypeName == value)
					return;
					
					
				OnColumnChanging(DiscountTypeColumn.DiscountTypeName, this.entityData.DiscountTypeName);
				this.entityData.DiscountTypeName = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(DiscountTypeColumn.DiscountTypeName, this.entityData.DiscountTypeName);
				OnPropertyChanged("DiscountTypeName");
			}
		}
		

		#region Source Foreign Key Property
				
		#endregion
			
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "ZNodeDiscountType"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"DiscountTypeID", "DiscountTypeName"};
			}
		}
		#endregion 
		
	
		/// <summary>
		///	Holds a collection of Coupon objects
		///	which are related to this object through the relation FK_ZNodeCoupon_ZNodeDiscountType
		/// </summary>	
		[BindableAttribute()]
		public TList<Coupon> CouponCollection
		{
			get { return entityData.CouponCollection; }
			set { entityData.CouponCollection = value; }	
		}
		
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
	            this.backupData = this.entityData.Clone() as DiscountTypeEntityData;
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
						this.parentCollection.Remove( (DiscountType) this ) ;
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
	            this.parentCollection = value as TList<DiscountType>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as DiscountType);
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
		///  Returns a Typed DiscountType Entity 
		///</summary>
		public virtual DiscountType Copy()
		{
			//shallow copy entity
			DiscountType copy = new DiscountType();
			copy.DiscountTypeID = this.DiscountTypeID;
			copy.OriginalDiscountTypeID = this.OriginalDiscountTypeID;
			copy.DiscountTypeName = this.DiscountTypeName;
					
			copy.AcceptChanges();
			return (DiscountType)copy;
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
		///  Returns a Typed DiscountType Entity which is a deep copy of the current entity.
		///</summary>
		public virtual DiscountType DeepCopy()
		{
			return EntityHelper.Clone<DiscountType>(this as DiscountType);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="DiscountTypeBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(DiscountTypeBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="DiscountTypeBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="DiscountTypeBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="DiscountTypeBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(DiscountTypeBase Object1, DiscountTypeBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.DiscountTypeID != Object2.DiscountTypeID)
				equal = false;
			if (Object1.DiscountTypeName != Object2.DiscountTypeName)
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((DiscountTypeBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static DiscountTypeComparer GetComparer()
        {
            return new DiscountTypeComparer();
        }
        */

        // Comparer delegates back to DiscountType
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
        public int CompareTo(DiscountType rhs, DiscountTypeColumn which)
        {
            switch (which)
            {
            	
            	
            	case DiscountTypeColumn.DiscountTypeID:
            		return this.DiscountTypeID.CompareTo(rhs.DiscountTypeID);
            		
            		                 
            	
            	
            	case DiscountTypeColumn.DiscountTypeName:
            		return this.DiscountTypeName.CompareTo(rhs.DiscountTypeName);
            		
            		                 
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
				
		#region IEntityKey<DiscountTypeKey> Members
		
		// member variable for the EntityId property
		private DiscountTypeKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public DiscountTypeKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new DiscountTypeKey(this);
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
					entityTrackingKey = @"DiscountType" 
					+ this.DiscountTypeID.ToString();
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
				"{3}{2}- DiscountTypeID: {0}{2}- DiscountTypeName: {1}{2}", 
				this.DiscountTypeID,
				this.DiscountTypeName,
				Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'ZNodeDiscountType' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class DiscountTypeEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// DiscountTypeID : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "ZNodeDiscountType"</remarks>
			public System.Int32 DiscountTypeID;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.Int32 OriginalDiscountTypeID;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// DiscountTypeName : 
		/// </summary>
		public System.String		  DiscountTypeName = string.Empty;
		#endregion
			
		#endregion Variable Declarations
		
		#region Clone
		public Object Clone()
		{
			DiscountTypeEntityData _tmp = new DiscountTypeEntityData();
						
			_tmp.DiscountTypeID = this.DiscountTypeID;
			_tmp.OriginalDiscountTypeID = this.OriginalDiscountTypeID;
			
			_tmp.DiscountTypeName = this.DiscountTypeName;
			
			return _tmp;
		}
		#endregion 
		
		#region Data Properties

		#region CouponCollection
		
		private TList<Coupon> couponDiscountTypeID;
		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation couponDiscountTypeID
		/// </summary>	
		public TList<Coupon> CouponCollection
		{
			get
			{
				if (couponDiscountTypeID == null)
				{
				couponDiscountTypeID = new TList<Coupon>();
				}
	
				return couponDiscountTypeID;
			}
			set { couponDiscountTypeID = value; }
		}
		
		#endregion

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
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"DiscountTypeName");
		}
   		#endregion
	
	} // End Class
	
	#region DiscountTypeComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class DiscountTypeComparer : System.Collections.Generic.IComparer<DiscountType>
	{
		DiscountTypeColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:DiscountTypeComparer"/> class.
        /// </summary>
		public DiscountTypeComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public DiscountTypeComparer(DiscountTypeColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="DiscountType"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="DiscountType"/> to compare.</param>
        /// <param name="b">The second <c>DiscountType</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(DiscountType a, DiscountType b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(DiscountType entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(DiscountType a, DiscountType b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public DiscountTypeColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region DiscountTypeKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="DiscountType"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class DiscountTypeKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the DiscountTypeKey class.
		/// </summary>
		public DiscountTypeKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the DiscountTypeKey class.
		/// </summary>
		public DiscountTypeKey(DiscountTypeBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.discountTypeID = entity.DiscountTypeID;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the DiscountTypeKey class.
		/// </summary>
		public DiscountTypeKey(System.Int32 discountTypeID)
		{
			#region Init Properties

			this.discountTypeID = discountTypeID;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private DiscountTypeBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public DiscountTypeBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the DiscountTypeID property
		private System.Int32 discountTypeID;
		
		/// <summary>
		/// Gets or sets the DiscountTypeID property.
		/// </summary>
		public System.Int32 DiscountTypeID
		{
			get { return discountTypeID; }
			set
			{
				if ( Entity != null )
				{
					Entity.DiscountTypeID = value;
				}
				
				discountTypeID = value;
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
				DiscountTypeID = ( values["DiscountTypeID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DiscountTypeID"], typeof(System.Int32)) : (int)0;
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

			values.Add("DiscountTypeID", DiscountTypeID);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("DiscountTypeID: {0}{1}",
								DiscountTypeID,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region DiscountTypeColumn Enum
	
	/// <summary>
	/// Enumerate the DiscountType columns.
	/// </summary>
	[Serializable]
	public enum DiscountTypeColumn : int
	{
		/// <summary>
		/// DiscountTypeID : 
		/// </summary>
		[EnumTextValue("DiscountTypeID")]
		[ColumnEnum("DiscountTypeID", typeof(System.Int32), System.Data.DbType.Int32, true, false, false)]
		DiscountTypeID = 1,
		/// <summary>
		/// DiscountTypeName : 
		/// </summary>
		[EnumTextValue("DiscountTypeName")]
		[ColumnEnum("DiscountTypeName", typeof(System.String), System.Data.DbType.AnsiString, false, false, false)]
		DiscountTypeName = 2
	}//End enum

	#endregion DiscountTypeColumn Enum

} // end namespace