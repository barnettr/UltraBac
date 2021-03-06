﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Thursday, October 18, 2007
	Important: Do not modify this file. Edit the file SKUAttribute.cs instead.
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
	#region SKUAttributeEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="SKUAttribute"/> object.
	/// </remarks>
	public class SKUAttributeEventArgs : System.EventArgs
	{
		private SKUAttributeColumn column;
		private object value;
		
		
		///<summary>
		/// Initalizes a new Instance of the SKUAttributeEventArgs class.
		///</summary>
		public SKUAttributeEventArgs(SKUAttributeColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the SKUAttributeEventArgs class.
		///</summary>
		public SKUAttributeEventArgs(SKUAttributeColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		
		///<summary>
		/// The SKUAttributeColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="SKUAttributeColumn" />
		public SKUAttributeColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all SKUAttribute related events.
	///</summary>
	public delegate void SKUAttributeEventHandler(object sender, SKUAttributeEventArgs e);
	
	///<summary>
	/// An object representation of the 'ZNodeSKUAttribute' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(SKUAttribute))]
	public abstract partial class SKUAttributeBase : EntityBase, IEntityId<SKUAttributeKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private SKUAttributeEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//SKUAttributeEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private SKUAttributeEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<SKUAttribute> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event SKUAttributeEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event SKUAttributeEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="SKUAttributeBase"/> instance.
		///</summary>
		public SKUAttributeBase()
		{
			this.entityData = new SKUAttributeEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="SKUAttributeBase"/> instance.
		///</summary>
		///<param name="sKUAttributeSKUID"></param>
		///<param name="sKUAttributeAttributeId"></param>
		public SKUAttributeBase(System.Int32 sKUAttributeSKUID, System.Int32 sKUAttributeAttributeId)
		{
			this.entityData = new SKUAttributeEntityData();
			this.backupData = null;

			this.SKUID = sKUAttributeSKUID;
			this.AttributeId = sKUAttributeAttributeId;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="SKUAttribute"/> instance.
		///</summary>
		///<param name="sKUAttributeSKUID"></param>
		///<param name="sKUAttributeAttributeId"></param>
		public static SKUAttribute CreateSKUAttribute(System.Int32 sKUAttributeSKUID, System.Int32 sKUAttributeAttributeId)
		{
			SKUAttribute newSKUAttribute = new SKUAttribute();
			newSKUAttribute.SKUID = sKUAttributeSKUID;
			newSKUAttribute.AttributeId = sKUAttributeAttributeId;
			return newSKUAttribute;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="SKUAttributeColumn"/> which has raised the event.</param>
		public void OnColumnChanging(SKUAttributeColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="SKUAttributeColumn"/> which has raised the event.</param>
		public void OnColumnChanged(SKUAttributeColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="SKUAttributeColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(SKUAttributeColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				SKUAttributeEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new SKUAttributeEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="SKUAttributeColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(SKUAttributeColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				SKUAttributeEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new SKUAttributeEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the SKUAttributeID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[ReadOnlyAttribute(false)/*, XmlIgnoreAttribute()*/, DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true, true, false)]
		public virtual System.Int32 SKUAttributeID
		{
			get
			{
				return this.entityData.SKUAttributeID; 
			}
			
			set
			{
				if (this.entityData.SKUAttributeID == value)
					return;
					
					
				OnColumnChanging(SKUAttributeColumn.SKUAttributeID, this.entityData.SKUAttributeID);
				this.entityData.SKUAttributeID = value;
				this.EntityId.SKUAttributeID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(SKUAttributeColumn.SKUAttributeID, this.entityData.SKUAttributeID);
				OnPropertyChanged("SKUAttributeID");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the SKUID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Int32 SKUID
		{
			get
			{
				return this.entityData.SKUID; 
			}
			
			set
			{
				if (this.entityData.SKUID == value)
					return;
					
					
				OnColumnChanging(SKUAttributeColumn.SKUID, this.entityData.SKUID);
				this.entityData.SKUID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(SKUAttributeColumn.SKUID, this.entityData.SKUID);
				OnPropertyChanged("SKUID");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the AttributeId property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Int32 AttributeId
		{
			get
			{
				return this.entityData.AttributeId; 
			}
			
			set
			{
				if (this.entityData.AttributeId == value)
					return;
					
					
				OnColumnChanging(SKUAttributeColumn.AttributeId, this.entityData.AttributeId);
				this.entityData.AttributeId = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(SKUAttributeColumn.AttributeId, this.entityData.AttributeId);
				OnPropertyChanged("AttributeId");
			}
		}
		

		#region Source Foreign Key Property
				
		private ProductAttribute _attributeIdSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="ProductAttribute"/>.
		/// </summary>
		/// <value>The source ProductAttribute for AttributeId.</value>
        [XmlIgnore()]
		[Browsable(false), BindableAttribute()]
		public virtual ProductAttribute AttributeIdSource
      	{
            get { return this._attributeIdSource; }
            set { this._attributeIdSource = value; }
      	}
		private SKU _skuidSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="SKU"/>.
		/// </summary>
		/// <value>The source SKU for SKUID.</value>
        [XmlIgnore()]
		[Browsable(false), BindableAttribute()]
		public virtual SKU SKUIDSource
      	{
            get { return this._skuidSource; }
            set { this._skuidSource = value; }
      	}
		#endregion
			
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "ZNodeSKUAttribute"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"SKUAttributeID", "SKUID", "AttributeId"};
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
	            this.backupData = this.entityData.Clone() as SKUAttributeEntityData;
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
						this.parentCollection.Remove( (SKUAttribute) this ) ;
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
	            this.parentCollection = value as TList<SKUAttribute>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as SKUAttribute);
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
		///  Returns a Typed SKUAttribute Entity 
		///</summary>
		public virtual SKUAttribute Copy()
		{
			//shallow copy entity
			SKUAttribute copy = new SKUAttribute();
			copy.SKUAttributeID = this.SKUAttributeID;
			copy.SKUID = this.SKUID;
			copy.AttributeId = this.AttributeId;
					
			copy.AcceptChanges();
			return (SKUAttribute)copy;
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
		///  Returns a Typed SKUAttribute Entity which is a deep copy of the current entity.
		///</summary>
		public virtual SKUAttribute DeepCopy()
		{
			return EntityHelper.Clone<SKUAttribute>(this as SKUAttribute);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="SKUAttributeBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(SKUAttributeBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="SKUAttributeBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="SKUAttributeBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="SKUAttributeBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(SKUAttributeBase Object1, SKUAttributeBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.SKUAttributeID != Object2.SKUAttributeID)
				equal = false;
			if (Object1.SKUID != Object2.SKUID)
				equal = false;
			if (Object1.AttributeId != Object2.AttributeId)
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((SKUAttributeBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static SKUAttributeComparer GetComparer()
        {
            return new SKUAttributeComparer();
        }
        */

        // Comparer delegates back to SKUAttribute
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
        public int CompareTo(SKUAttribute rhs, SKUAttributeColumn which)
        {
            switch (which)
            {
            	
            	
            	case SKUAttributeColumn.SKUAttributeID:
            		return this.SKUAttributeID.CompareTo(rhs.SKUAttributeID);
            		
            		                 
            	
            	
            	case SKUAttributeColumn.SKUID:
            		return this.SKUID.CompareTo(rhs.SKUID);
            		
            		                 
            	
            	
            	case SKUAttributeColumn.AttributeId:
            		return this.AttributeId.CompareTo(rhs.AttributeId);
            		
            		                 
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
				
		#region IEntityKey<SKUAttributeKey> Members
		
		// member variable for the EntityId property
		private SKUAttributeKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public SKUAttributeKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new SKUAttributeKey(this);
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
					entityTrackingKey = @"SKUAttribute" 
					+ this.SKUAttributeID.ToString();
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
				"{4}{3}- SKUAttributeID: {0}{3}- SKUID: {1}{3}- AttributeId: {2}{3}", 
				this.SKUAttributeID,
				this.SKUID,
				this.AttributeId,
				Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'ZNodeSKUAttribute' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class SKUAttributeEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// SKUAttributeID : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "ZNodeSKUAttribute"</remarks>
			public System.Int32 SKUAttributeID;
				
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// SKUID : 
		/// </summary>
		public System.Int32		  SKUID = (int)0;
		
		/// <summary>
		/// AttributeId : 
		/// </summary>
		public System.Int32		  AttributeId = (int)0;
		#endregion
			
		#endregion Variable Declarations
		
		#region Clone
		public Object Clone()
		{
			SKUAttributeEntityData _tmp = new SKUAttributeEntityData();
						
			_tmp.SKUAttributeID = this.SKUAttributeID;
			
			_tmp.SKUID = this.SKUID;
			_tmp.AttributeId = this.AttributeId;
			
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
	
	#region SKUAttributeComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class SKUAttributeComparer : System.Collections.Generic.IComparer<SKUAttribute>
	{
		SKUAttributeColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:SKUAttributeComparer"/> class.
        /// </summary>
		public SKUAttributeComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public SKUAttributeComparer(SKUAttributeColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="SKUAttribute"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="SKUAttribute"/> to compare.</param>
        /// <param name="b">The second <c>SKUAttribute</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(SKUAttribute a, SKUAttribute b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(SKUAttribute entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(SKUAttribute a, SKUAttribute b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public SKUAttributeColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region SKUAttributeKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="SKUAttribute"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class SKUAttributeKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the SKUAttributeKey class.
		/// </summary>
		public SKUAttributeKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the SKUAttributeKey class.
		/// </summary>
		public SKUAttributeKey(SKUAttributeBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.sKUAttributeID = entity.SKUAttributeID;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the SKUAttributeKey class.
		/// </summary>
		public SKUAttributeKey(System.Int32 sKUAttributeID)
		{
			#region Init Properties

			this.sKUAttributeID = sKUAttributeID;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private SKUAttributeBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public SKUAttributeBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the SKUAttributeID property
		private System.Int32 sKUAttributeID;
		
		/// <summary>
		/// Gets or sets the SKUAttributeID property.
		/// </summary>
		public System.Int32 SKUAttributeID
		{
			get { return sKUAttributeID; }
			set
			{
				if ( Entity != null )
				{
					Entity.SKUAttributeID = value;
				}
				
				sKUAttributeID = value;
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
				SKUAttributeID = ( values["SKUAttributeID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SKUAttributeID"], typeof(System.Int32)) : (int)0;
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

			values.Add("SKUAttributeID", SKUAttributeID);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("SKUAttributeID: {0}{1}",
								SKUAttributeID,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region SKUAttributeColumn Enum
	
	/// <summary>
	/// Enumerate the SKUAttribute columns.
	/// </summary>
	[Serializable]
	public enum SKUAttributeColumn : int
	{
		/// <summary>
		/// SKUAttributeID : 
		/// </summary>
		[EnumTextValue("SKUAttributeID")]
		[ColumnEnum("SKUAttributeID", typeof(System.Int32), System.Data.DbType.Int32, true, true, false)]
		SKUAttributeID = 1,
		/// <summary>
		/// SKUID : 
		/// </summary>
		[EnumTextValue("SKUID")]
		[ColumnEnum("SKUID", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		SKUID = 2,
		/// <summary>
		/// AttributeId : 
		/// </summary>
		[EnumTextValue("AttributeId")]
		[ColumnEnum("AttributeId", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		AttributeId = 3
	}//End enum

	#endregion SKUAttributeColumn Enum

} // end namespace
