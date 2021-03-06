﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Thursday, October 18, 2007
	Important: Do not modify this file. Edit the file Country.cs instead.
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
	#region CountryEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="Country"/> object.
	/// </remarks>
	public class CountryEventArgs : System.EventArgs
	{
		private CountryColumn column;
		private object value;
		
		
		///<summary>
		/// Initalizes a new Instance of the CountryEventArgs class.
		///</summary>
		public CountryEventArgs(CountryColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the CountryEventArgs class.
		///</summary>
		public CountryEventArgs(CountryColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		
		///<summary>
		/// The CountryColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="CountryColumn" />
		public CountryColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all Country related events.
	///</summary>
	public delegate void CountryEventHandler(object sender, CountryEventArgs e);
	
	///<summary>
	/// An object representation of the 'ZNodeCountry' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(Country))]
	public abstract partial class CountryBase : EntityBase, IEntityId<CountryKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private CountryEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//CountryEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private CountryEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<Country> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event CountryEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event CountryEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="CountryBase"/> instance.
		///</summary>
		public CountryBase()
		{
			this.entityData = new CountryEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="CountryBase"/> instance.
		///</summary>
		///<param name="countryCode"></param>
		///<param name="countryPortalID"></param>
		///<param name="countryName"></param>
		///<param name="countryDisplayOrder"></param>
		///<param name="countryActiveInd"></param>
		public CountryBase(System.String countryCode, System.Int32? countryPortalID, System.String countryName, 
			System.Int32 countryDisplayOrder, System.Boolean countryActiveInd)
		{
			this.entityData = new CountryEntityData();
			this.backupData = null;

			this.Code = countryCode;
			this.PortalID = countryPortalID;
			this.Name = countryName;
			this.DisplayOrder = countryDisplayOrder;
			this.ActiveInd = countryActiveInd;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="Country"/> instance.
		///</summary>
		///<param name="countryCode"></param>
		///<param name="countryPortalID"></param>
		///<param name="countryName"></param>
		///<param name="countryDisplayOrder"></param>
		///<param name="countryActiveInd"></param>
		public static Country CreateCountry(System.String countryCode, System.Int32? countryPortalID, System.String countryName, 
			System.Int32 countryDisplayOrder, System.Boolean countryActiveInd)
		{
			Country newCountry = new Country();
			newCountry.Code = countryCode;
			newCountry.PortalID = countryPortalID;
			newCountry.Name = countryName;
			newCountry.DisplayOrder = countryDisplayOrder;
			newCountry.ActiveInd = countryActiveInd;
			return newCountry;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="CountryColumn"/> which has raised the event.</param>
		public void OnColumnChanging(CountryColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="CountryColumn"/> which has raised the event.</param>
		public void OnColumnChanged(CountryColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="CountryColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(CountryColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				CountryEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new CountryEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="CountryColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(CountryColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				CountryEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new CountryEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
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
		[DataObjectField(true, false, false, 2)]
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
					
					
				OnColumnChanging(CountryColumn.Code, this.entityData.Code);
				this.entityData.Code = value;
				this.EntityId.Code = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CountryColumn.Code, this.entityData.Code);
				OnPropertyChanged("Code");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the Code property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the Code property.</remarks>
		/// <value>This type is varchar</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.String OriginalCode
		{
			get { return this.entityData.OriginalCode; }
			set { this.entityData.OriginalCode = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the PortalID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return (int)0. It is up to the developer
		/// to check the value of IsPortalIDNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, true)]
		public virtual System.Int32? PortalID
		{
			get
			{
				return this.entityData.PortalID; 
			}
			
			set
			{
				if (this.entityData.PortalID == value)
					return;
					
					
				OnColumnChanging(CountryColumn.PortalID, this.entityData.PortalID);
				this.entityData.PortalID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CountryColumn.PortalID, this.entityData.PortalID);
				OnPropertyChanged("PortalID");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Name property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false, 100)]
		public virtual System.String Name
		{
			get
			{
				return this.entityData.Name; 
			}
			
			set
			{
				if (this.entityData.Name == value)
					return;
					
					
				OnColumnChanging(CountryColumn.Name, this.entityData.Name);
				this.entityData.Name = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CountryColumn.Name, this.entityData.Name);
				OnPropertyChanged("Name");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the DisplayOrder property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Int32 DisplayOrder
		{
			get
			{
				return this.entityData.DisplayOrder; 
			}
			
			set
			{
				if (this.entityData.DisplayOrder == value)
					return;
					
					
				OnColumnChanging(CountryColumn.DisplayOrder, this.entityData.DisplayOrder);
				this.entityData.DisplayOrder = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CountryColumn.DisplayOrder, this.entityData.DisplayOrder);
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
					
					
				OnColumnChanging(CountryColumn.ActiveInd, this.entityData.ActiveInd);
				this.entityData.ActiveInd = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CountryColumn.ActiveInd, this.entityData.ActiveInd);
				OnPropertyChanged("ActiveInd");
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
			get { return "ZNodeCountry"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"Code", "PortalID", "Name", "DisplayOrder", "ActiveInd"};
			}
		}
		#endregion 
		
	
		/// <summary>
		///	Holds a collection of TaxRule objects
		///	which are related to this object through the relation FK_ZNodeTaxRule_ZNodeCountry
		/// </summary>	
		[BindableAttribute()]
		public TList<TaxRule> TaxRuleCollection
		{
			get { return entityData.TaxRuleCollection; }
			set { entityData.TaxRuleCollection = value; }	
		}
	
		/// <summary>
		///	Holds a collection of Shipping objects
		///	which are related to this object through the relation FK_ZNodeShipping_ZNodeCountry
		/// </summary>	
		[BindableAttribute()]
		public TList<Shipping> ShippingCollection
		{
			get { return entityData.ShippingCollection; }
			set { entityData.ShippingCollection = value; }	
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
	            this.backupData = this.entityData.Clone() as CountryEntityData;
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
						this.parentCollection.Remove( (Country) this ) ;
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
	            this.parentCollection = value as TList<Country>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as Country);
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
		///  Returns a Typed Country Entity 
		///</summary>
		public virtual Country Copy()
		{
			//shallow copy entity
			Country copy = new Country();
			copy.Code = this.Code;
			copy.OriginalCode = this.OriginalCode;
			copy.PortalID = this.PortalID;
			copy.Name = this.Name;
			copy.DisplayOrder = this.DisplayOrder;
			copy.ActiveInd = this.ActiveInd;
					
			copy.AcceptChanges();
			return (Country)copy;
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
		///  Returns a Typed Country Entity which is a deep copy of the current entity.
		///</summary>
		public virtual Country DeepCopy()
		{
			return EntityHelper.Clone<Country>(this as Country);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="CountryBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(CountryBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="CountryBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="CountryBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="CountryBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(CountryBase Object1, CountryBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.Code != Object2.Code)
				equal = false;
			if ( Object1.PortalID != null && Object2.PortalID != null )
			{
				if (Object1.PortalID != Object2.PortalID)
					equal = false;
			}
			else if (Object1.PortalID == null ^ Object2.PortalID == null )
			{
				equal = false;
			}
			if (Object1.Name != Object2.Name)
				equal = false;
			if (Object1.DisplayOrder != Object2.DisplayOrder)
				equal = false;
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((CountryBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static CountryComparer GetComparer()
        {
            return new CountryComparer();
        }
        */

        // Comparer delegates back to Country
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
        public int CompareTo(Country rhs, CountryColumn which)
        {
            switch (which)
            {
            	
            	
            	case CountryColumn.Code:
            		return this.Code.CompareTo(rhs.Code);
            		
            		                 
            	
            	
            	case CountryColumn.PortalID:
            		return this.PortalID.Value.CompareTo(rhs.PortalID.Value);
            		
            		                 
            	
            	
            	case CountryColumn.Name:
            		return this.Name.CompareTo(rhs.Name);
            		
            		                 
            	
            	
            	case CountryColumn.DisplayOrder:
            		return this.DisplayOrder.CompareTo(rhs.DisplayOrder);
            		
            		                 
            	
            	
            	case CountryColumn.ActiveInd:
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
				
		#region IEntityKey<CountryKey> Members
		
		// member variable for the EntityId property
		private CountryKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public CountryKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new CountryKey(this);
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
					entityTrackingKey = @"Country" 
					+ this.Code.ToString();
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
				"{6}{5}- Code: {0}{5}- PortalID: {1}{5}- Name: {2}{5}- DisplayOrder: {3}{5}- ActiveInd: {4}{5}", 
				this.Code,
				(this.PortalID == null) ? string.Empty : this.PortalID.ToString(),
				this.Name,
				this.DisplayOrder,
				this.ActiveInd,
				Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'ZNodeCountry' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class CountryEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// Code : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "ZNodeCountry"</remarks>
			public System.String Code;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.String OriginalCode;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// PortalID : 
		/// </summary>
		public System.Int32?		  PortalID = (int)0;
		
		/// <summary>
		/// Name : 
		/// </summary>
		public System.String		  Name = string.Empty;
		
		/// <summary>
		/// DisplayOrder : 
		/// </summary>
		public System.Int32		  DisplayOrder = (int)0;
		
		/// <summary>
		/// ActiveInd : 
		/// </summary>
		public System.Boolean		  ActiveInd = false;
		#endregion
			
		#endregion Variable Declarations
		
		#region Clone
		public Object Clone()
		{
			CountryEntityData _tmp = new CountryEntityData();
						
			_tmp.Code = this.Code;
			_tmp.OriginalCode = this.OriginalCode;
			
			_tmp.PortalID = this.PortalID;
			_tmp.Name = this.Name;
			_tmp.DisplayOrder = this.DisplayOrder;
			_tmp.ActiveInd = this.ActiveInd;
			
			return _tmp;
		}
		#endregion 
		
		#region Data Properties

		#region TaxRuleCollection
		
		private TList<TaxRule> taxRuleDestinationCountryCode;
		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation taxRuleDestinationCountryCode
		/// </summary>	
		public TList<TaxRule> TaxRuleCollection
		{
			get
			{
				if (taxRuleDestinationCountryCode == null)
				{
				taxRuleDestinationCountryCode = new TList<TaxRule>();
				}
	
				return taxRuleDestinationCountryCode;
			}
			set { taxRuleDestinationCountryCode = value; }
		}
		
		#endregion

		#region ShippingCollection
		
		private TList<Shipping> shippingDestinationCountryCode;
		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation shippingDestinationCountryCode
		/// </summary>	
		public TList<Shipping> ShippingCollection
		{
			get
			{
				if (shippingDestinationCountryCode == null)
				{
				shippingDestinationCountryCode = new TList<Shipping>();
				}
	
				return shippingDestinationCountryCode;
			}
			set { shippingDestinationCountryCode = value; }
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
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"Code");
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("Code",2));
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"Name");
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("Name",100));
		}
   		#endregion
	
	} // End Class
	
	#region CountryComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class CountryComparer : System.Collections.Generic.IComparer<Country>
	{
		CountryColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:CountryComparer"/> class.
        /// </summary>
		public CountryComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public CountryComparer(CountryColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="Country"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="Country"/> to compare.</param>
        /// <param name="b">The second <c>Country</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(Country a, Country b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(Country entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(Country a, Country b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public CountryColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region CountryKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="Country"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class CountryKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the CountryKey class.
		/// </summary>
		public CountryKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the CountryKey class.
		/// </summary>
		public CountryKey(CountryBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.code = entity.Code;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the CountryKey class.
		/// </summary>
		public CountryKey(System.String code)
		{
			#region Init Properties

			this.code = code;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private CountryBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public CountryBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the Code property
		private System.String code;
		
		/// <summary>
		/// Gets or sets the Code property.
		/// </summary>
		public System.String Code
		{
			get { return code; }
			set
			{
				if ( Entity != null )
				{
					Entity.Code = value;
				}
				
				code = value;
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
				Code = ( values["Code"] != null ) ? (System.String) EntityUtil.ChangeType(values["Code"], typeof(System.String)) : string.Empty;
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

			values.Add("Code", Code);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("Code: {0}{1}",
								Code,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region CountryColumn Enum
	
	/// <summary>
	/// Enumerate the Country columns.
	/// </summary>
	[Serializable]
	public enum CountryColumn : int
	{
		/// <summary>
		/// Code : 
		/// </summary>
		[EnumTextValue("Code")]
		[ColumnEnum("Code", typeof(System.String), System.Data.DbType.AnsiString, true, false, false, 2)]
		Code = 1,
		/// <summary>
		/// PortalID : 
		/// </summary>
		[EnumTextValue("PortalID")]
		[ColumnEnum("PortalID", typeof(System.Int32), System.Data.DbType.Int32, false, false, true)]
		PortalID = 2,
		/// <summary>
		/// Name : 
		/// </summary>
		[EnumTextValue("Name")]
		[ColumnEnum("Name", typeof(System.String), System.Data.DbType.AnsiString, false, false, false, 100)]
		Name = 3,
		/// <summary>
		/// DisplayOrder : 
		/// </summary>
		[EnumTextValue("DisplayOrder")]
		[ColumnEnum("DisplayOrder", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		DisplayOrder = 4,
		/// <summary>
		/// ActiveInd : 
		/// </summary>
		[EnumTextValue("ActiveInd")]
		[ColumnEnum("ActiveInd", typeof(System.Boolean), System.Data.DbType.Boolean, false, false, false)]
		ActiveInd = 5
	}//End enum

	#endregion CountryColumn Enum

} // end namespace
