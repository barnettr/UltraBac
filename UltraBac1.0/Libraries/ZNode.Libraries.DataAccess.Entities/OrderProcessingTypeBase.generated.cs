﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Thursday, October 18, 2007
	Important: Do not modify this file. Edit the file OrderProcessingType.cs instead.
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
	#region OrderProcessingTypeEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="OrderProcessingType"/> object.
	/// </remarks>
	public class OrderProcessingTypeEventArgs : System.EventArgs
	{
		private OrderProcessingTypeColumn column;
		private object value;
		
		
		///<summary>
		/// Initalizes a new Instance of the OrderProcessingTypeEventArgs class.
		///</summary>
		public OrderProcessingTypeEventArgs(OrderProcessingTypeColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the OrderProcessingTypeEventArgs class.
		///</summary>
		public OrderProcessingTypeEventArgs(OrderProcessingTypeColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		
		///<summary>
		/// The OrderProcessingTypeColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="OrderProcessingTypeColumn" />
		public OrderProcessingTypeColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all OrderProcessingType related events.
	///</summary>
	public delegate void OrderProcessingTypeEventHandler(object sender, OrderProcessingTypeEventArgs e);
	
	///<summary>
	/// An object representation of the 'ZNodeOrderProcessingType' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(OrderProcessingType))]
	public abstract partial class OrderProcessingTypeBase : EntityBase, IEntityId<OrderProcessingTypeKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private OrderProcessingTypeEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//OrderProcessingTypeEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private OrderProcessingTypeEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<OrderProcessingType> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event OrderProcessingTypeEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event OrderProcessingTypeEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="OrderProcessingTypeBase"/> instance.
		///</summary>
		public OrderProcessingTypeBase()
		{
			this.entityData = new OrderProcessingTypeEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="OrderProcessingTypeBase"/> instance.
		///</summary>
		///<param name="orderProcessingTypeDescription"></param>
		///<param name="orderProcessingTypeClassID"></param>
		public OrderProcessingTypeBase(System.String orderProcessingTypeDescription, System.String orderProcessingTypeClassID)
		{
			this.entityData = new OrderProcessingTypeEntityData();
			this.backupData = null;

			this.Description = orderProcessingTypeDescription;
			this.ClassID = orderProcessingTypeClassID;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="OrderProcessingType"/> instance.
		///</summary>
		///<param name="orderProcessingTypeDescription"></param>
		///<param name="orderProcessingTypeClassID"></param>
		public static OrderProcessingType CreateOrderProcessingType(System.String orderProcessingTypeDescription, System.String orderProcessingTypeClassID)
		{
			OrderProcessingType newOrderProcessingType = new OrderProcessingType();
			newOrderProcessingType.Description = orderProcessingTypeDescription;
			newOrderProcessingType.ClassID = orderProcessingTypeClassID;
			return newOrderProcessingType;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="OrderProcessingTypeColumn"/> which has raised the event.</param>
		public void OnColumnChanging(OrderProcessingTypeColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="OrderProcessingTypeColumn"/> which has raised the event.</param>
		public void OnColumnChanged(OrderProcessingTypeColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="OrderProcessingTypeColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(OrderProcessingTypeColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				OrderProcessingTypeEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new OrderProcessingTypeEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="OrderProcessingTypeColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(OrderProcessingTypeColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				OrderProcessingTypeEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new OrderProcessingTypeEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the OrderProcessingTypeID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[ReadOnlyAttribute(false)/*, XmlIgnoreAttribute()*/, DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true, true, false)]
		public virtual System.Int32 OrderProcessingTypeID
		{
			get
			{
				return this.entityData.OrderProcessingTypeID; 
			}
			
			set
			{
				if (this.entityData.OrderProcessingTypeID == value)
					return;
					
					
				OnColumnChanging(OrderProcessingTypeColumn.OrderProcessingTypeID, this.entityData.OrderProcessingTypeID);
				this.entityData.OrderProcessingTypeID = value;
				this.EntityId.OrderProcessingTypeID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(OrderProcessingTypeColumn.OrderProcessingTypeID, this.entityData.OrderProcessingTypeID);
				OnPropertyChanged("OrderProcessingTypeID");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Description property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, true, 50)]
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
					
					
				OnColumnChanging(OrderProcessingTypeColumn.Description, this.entityData.Description);
				this.entityData.Description = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(OrderProcessingTypeColumn.Description, this.entityData.Description);
				OnPropertyChanged("Description");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the ClassID property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, true, 30)]
		public virtual System.String ClassID
		{
			get
			{
				return this.entityData.ClassID; 
			}
			
			set
			{
				if (this.entityData.ClassID == value)
					return;
					
					
				OnColumnChanging(OrderProcessingTypeColumn.ClassID, this.entityData.ClassID);
				this.entityData.ClassID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(OrderProcessingTypeColumn.ClassID, this.entityData.ClassID);
				OnPropertyChanged("ClassID");
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
			get { return "ZNodeOrderProcessingType"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"OrderProcessingTypeID", "Description", "ClassID"};
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
	            this.backupData = this.entityData.Clone() as OrderProcessingTypeEntityData;
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
						this.parentCollection.Remove( (OrderProcessingType) this ) ;
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
	            this.parentCollection = value as TList<OrderProcessingType>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as OrderProcessingType);
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
		///  Returns a Typed OrderProcessingType Entity 
		///</summary>
		public virtual OrderProcessingType Copy()
		{
			//shallow copy entity
			OrderProcessingType copy = new OrderProcessingType();
			copy.OrderProcessingTypeID = this.OrderProcessingTypeID;
			copy.Description = this.Description;
			copy.ClassID = this.ClassID;
					
			copy.AcceptChanges();
			return (OrderProcessingType)copy;
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
		///  Returns a Typed OrderProcessingType Entity which is a deep copy of the current entity.
		///</summary>
		public virtual OrderProcessingType DeepCopy()
		{
			return EntityHelper.Clone<OrderProcessingType>(this as OrderProcessingType);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="OrderProcessingTypeBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(OrderProcessingTypeBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="OrderProcessingTypeBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="OrderProcessingTypeBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="OrderProcessingTypeBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(OrderProcessingTypeBase Object1, OrderProcessingTypeBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.OrderProcessingTypeID != Object2.OrderProcessingTypeID)
				equal = false;
			if ( Object1.Description != null && Object2.Description != null )
			{
				if (Object1.Description != Object2.Description)
					equal = false;
			}
			else if (Object1.Description == null ^ Object2.Description == null )
			{
				equal = false;
			}
			if ( Object1.ClassID != null && Object2.ClassID != null )
			{
				if (Object1.ClassID != Object2.ClassID)
					equal = false;
			}
			else if (Object1.ClassID == null ^ Object2.ClassID == null )
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((OrderProcessingTypeBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static OrderProcessingTypeComparer GetComparer()
        {
            return new OrderProcessingTypeComparer();
        }
        */

        // Comparer delegates back to OrderProcessingType
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
        public int CompareTo(OrderProcessingType rhs, OrderProcessingTypeColumn which)
        {
            switch (which)
            {
            	
            	
            	case OrderProcessingTypeColumn.OrderProcessingTypeID:
            		return this.OrderProcessingTypeID.CompareTo(rhs.OrderProcessingTypeID);
            		
            		                 
            	
            	
            	case OrderProcessingTypeColumn.Description:
            		return this.Description.CompareTo(rhs.Description);
            		
            		                 
            	
            	
            	case OrderProcessingTypeColumn.ClassID:
            		return this.ClassID.CompareTo(rhs.ClassID);
            		
            		                 
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
				
		#region IEntityKey<OrderProcessingTypeKey> Members
		
		// member variable for the EntityId property
		private OrderProcessingTypeKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public OrderProcessingTypeKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new OrderProcessingTypeKey(this);
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
					entityTrackingKey = @"OrderProcessingType" 
					+ this.OrderProcessingTypeID.ToString();
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
				"{4}{3}- OrderProcessingTypeID: {0}{3}- Description: {1}{3}- ClassID: {2}{3}", 
				this.OrderProcessingTypeID,
				(this.Description == null) ? string.Empty : this.Description.ToString(),
				(this.ClassID == null) ? string.Empty : this.ClassID.ToString(),
				Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'ZNodeOrderProcessingType' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class OrderProcessingTypeEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// OrderProcessingTypeID : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "ZNodeOrderProcessingType"</remarks>
			public System.Int32 OrderProcessingTypeID;
				
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// Description : 
		/// </summary>
		public System.String		  Description = string.Empty;
		
		/// <summary>
		/// ClassID : 
		/// </summary>
		public System.String		  ClassID = string.Empty;
		#endregion
			
		#endregion Variable Declarations
		
		#region Clone
		public Object Clone()
		{
			OrderProcessingTypeEntityData _tmp = new OrderProcessingTypeEntityData();
						
			_tmp.OrderProcessingTypeID = this.OrderProcessingTypeID;
			
			_tmp.Description = this.Description;
			_tmp.ClassID = this.ClassID;
			
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
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("Description",50));
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("ClassID",30));
		}
   		#endregion
	
	} // End Class
	
	#region OrderProcessingTypeComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class OrderProcessingTypeComparer : System.Collections.Generic.IComparer<OrderProcessingType>
	{
		OrderProcessingTypeColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:OrderProcessingTypeComparer"/> class.
        /// </summary>
		public OrderProcessingTypeComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public OrderProcessingTypeComparer(OrderProcessingTypeColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="OrderProcessingType"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="OrderProcessingType"/> to compare.</param>
        /// <param name="b">The second <c>OrderProcessingType</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(OrderProcessingType a, OrderProcessingType b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(OrderProcessingType entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(OrderProcessingType a, OrderProcessingType b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public OrderProcessingTypeColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region OrderProcessingTypeKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="OrderProcessingType"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class OrderProcessingTypeKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the OrderProcessingTypeKey class.
		/// </summary>
		public OrderProcessingTypeKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the OrderProcessingTypeKey class.
		/// </summary>
		public OrderProcessingTypeKey(OrderProcessingTypeBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.orderProcessingTypeID = entity.OrderProcessingTypeID;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the OrderProcessingTypeKey class.
		/// </summary>
		public OrderProcessingTypeKey(System.Int32 orderProcessingTypeID)
		{
			#region Init Properties

			this.orderProcessingTypeID = orderProcessingTypeID;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private OrderProcessingTypeBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public OrderProcessingTypeBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the OrderProcessingTypeID property
		private System.Int32 orderProcessingTypeID;
		
		/// <summary>
		/// Gets or sets the OrderProcessingTypeID property.
		/// </summary>
		public System.Int32 OrderProcessingTypeID
		{
			get { return orderProcessingTypeID; }
			set
			{
				if ( Entity != null )
				{
					Entity.OrderProcessingTypeID = value;
				}
				
				orderProcessingTypeID = value;
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
				OrderProcessingTypeID = ( values["OrderProcessingTypeID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["OrderProcessingTypeID"], typeof(System.Int32)) : (int)0;
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

			values.Add("OrderProcessingTypeID", OrderProcessingTypeID);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("OrderProcessingTypeID: {0}{1}",
								OrderProcessingTypeID,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region OrderProcessingTypeColumn Enum
	
	/// <summary>
	/// Enumerate the OrderProcessingType columns.
	/// </summary>
	[Serializable]
	public enum OrderProcessingTypeColumn : int
	{
		/// <summary>
		/// OrderProcessingTypeID : 
		/// </summary>
		[EnumTextValue("OrderProcessingTypeID")]
		[ColumnEnum("OrderProcessingTypeID", typeof(System.Int32), System.Data.DbType.Int32, true, true, false)]
		OrderProcessingTypeID = 1,
		/// <summary>
		/// Description : 
		/// </summary>
		[EnumTextValue("Description")]
		[ColumnEnum("Description", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
		Description = 2,
		/// <summary>
		/// ClassID : 
		/// </summary>
		[EnumTextValue("ClassID")]
		[ColumnEnum("ClassID", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 30)]
		ClassID = 3
	}//End enum

	#endregion OrderProcessingTypeColumn Enum

} // end namespace
