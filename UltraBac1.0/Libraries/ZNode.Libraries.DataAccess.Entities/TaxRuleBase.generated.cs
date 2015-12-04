﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Thursday, October 18, 2007
	Important: Do not modify this file. Edit the file TaxRule.cs instead.
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
	#region TaxRuleEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="TaxRule"/> object.
	/// </remarks>
	public class TaxRuleEventArgs : System.EventArgs
	{
		private TaxRuleColumn column;
		private object value;
		
		
		///<summary>
		/// Initalizes a new Instance of the TaxRuleEventArgs class.
		///</summary>
		public TaxRuleEventArgs(TaxRuleColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the TaxRuleEventArgs class.
		///</summary>
		public TaxRuleEventArgs(TaxRuleColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		
		///<summary>
		/// The TaxRuleColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="TaxRuleColumn" />
		public TaxRuleColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all TaxRule related events.
	///</summary>
	public delegate void TaxRuleEventHandler(object sender, TaxRuleEventArgs e);
	
	///<summary>
	/// An object representation of the 'ZNodeTaxRule' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(TaxRule))]
	public abstract partial class TaxRuleBase : EntityBase, IEntityId<TaxRuleKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private TaxRuleEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//TaxRuleEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private TaxRuleEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<TaxRule> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event TaxRuleEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event TaxRuleEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="TaxRuleBase"/> instance.
		///</summary>
		public TaxRuleBase()
		{
			this.entityData = new TaxRuleEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="TaxRuleBase"/> instance.
		///</summary>
		///<param name="taxRulePortalID"></param>
		///<param name="taxRuleTaxRate"></param>
		///<param name="taxRuleDestinationCountryCode"></param>
		///<param name="taxRuleDestinationStateCode"></param>
		///<param name="taxRulePrecedence"></param>
		public TaxRuleBase(System.Int32 taxRulePortalID, System.Decimal taxRuleTaxRate, System.String taxRuleDestinationCountryCode, 
			System.String taxRuleDestinationStateCode, System.Int32 taxRulePrecedence)
		{
			this.entityData = new TaxRuleEntityData();
			this.backupData = null;

			this.PortalID = taxRulePortalID;
			this.TaxRate = taxRuleTaxRate;
			this.DestinationCountryCode = taxRuleDestinationCountryCode;
			this.DestinationStateCode = taxRuleDestinationStateCode;
			this.Precedence = taxRulePrecedence;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="TaxRule"/> instance.
		///</summary>
		///<param name="taxRulePortalID"></param>
		///<param name="taxRuleTaxRate"></param>
		///<param name="taxRuleDestinationCountryCode"></param>
		///<param name="taxRuleDestinationStateCode"></param>
		///<param name="taxRulePrecedence"></param>
		public static TaxRule CreateTaxRule(System.Int32 taxRulePortalID, System.Decimal taxRuleTaxRate, System.String taxRuleDestinationCountryCode, 
			System.String taxRuleDestinationStateCode, System.Int32 taxRulePrecedence)
		{
			TaxRule newTaxRule = new TaxRule();
			newTaxRule.PortalID = taxRulePortalID;
			newTaxRule.TaxRate = taxRuleTaxRate;
			newTaxRule.DestinationCountryCode = taxRuleDestinationCountryCode;
			newTaxRule.DestinationStateCode = taxRuleDestinationStateCode;
			newTaxRule.Precedence = taxRulePrecedence;
			return newTaxRule;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="TaxRuleColumn"/> which has raised the event.</param>
		public void OnColumnChanging(TaxRuleColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="TaxRuleColumn"/> which has raised the event.</param>
		public void OnColumnChanged(TaxRuleColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="TaxRuleColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(TaxRuleColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				TaxRuleEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new TaxRuleEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="TaxRuleColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(TaxRuleColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				TaxRuleEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new TaxRuleEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the TaxRuleID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[ReadOnlyAttribute(false)/*, XmlIgnoreAttribute()*/, DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true, true, false)]
		public virtual System.Int32 TaxRuleID
		{
			get
			{
				return this.entityData.TaxRuleID; 
			}
			
			set
			{
				if (this.entityData.TaxRuleID == value)
					return;
					
					
				OnColumnChanging(TaxRuleColumn.TaxRuleID, this.entityData.TaxRuleID);
				this.entityData.TaxRuleID = value;
				this.EntityId.TaxRuleID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(TaxRuleColumn.TaxRuleID, this.entityData.TaxRuleID);
				OnPropertyChanged("TaxRuleID");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the PortalID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Int32 PortalID
		{
			get
			{
				return this.entityData.PortalID; 
			}
			
			set
			{
				if (this.entityData.PortalID == value)
					return;
					
					
				OnColumnChanging(TaxRuleColumn.PortalID, this.entityData.PortalID);
				this.entityData.PortalID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(TaxRuleColumn.PortalID, this.entityData.PortalID);
				OnPropertyChanged("PortalID");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the TaxRate property. 
		///		
		/// </summary>
		/// <value>This type is decimal.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Decimal TaxRate
		{
			get
			{
				return this.entityData.TaxRate; 
			}
			
			set
			{
				if (this.entityData.TaxRate == value)
					return;
					
					
				OnColumnChanging(TaxRuleColumn.TaxRate, this.entityData.TaxRate);
				this.entityData.TaxRate = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(TaxRuleColumn.TaxRate, this.entityData.TaxRate);
				OnPropertyChanged("TaxRate");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the DestinationCountryCode property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, true, 2)]
		public virtual System.String DestinationCountryCode
		{
			get
			{
				return this.entityData.DestinationCountryCode; 
			}
			
			set
			{
				if (this.entityData.DestinationCountryCode == value)
					return;
					
					
				OnColumnChanging(TaxRuleColumn.DestinationCountryCode, this.entityData.DestinationCountryCode);
				this.entityData.DestinationCountryCode = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(TaxRuleColumn.DestinationCountryCode, this.entityData.DestinationCountryCode);
				OnPropertyChanged("DestinationCountryCode");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the DestinationStateCode property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, true, 2)]
		public virtual System.String DestinationStateCode
		{
			get
			{
				return this.entityData.DestinationStateCode; 
			}
			
			set
			{
				if (this.entityData.DestinationStateCode == value)
					return;
					
					
				OnColumnChanging(TaxRuleColumn.DestinationStateCode, this.entityData.DestinationStateCode);
				this.entityData.DestinationStateCode = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(TaxRuleColumn.DestinationStateCode, this.entityData.DestinationStateCode);
				OnPropertyChanged("DestinationStateCode");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Precedence property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Int32 Precedence
		{
			get
			{
				return this.entityData.Precedence; 
			}
			
			set
			{
				if (this.entityData.Precedence == value)
					return;
					
					
				OnColumnChanging(TaxRuleColumn.Precedence, this.entityData.Precedence);
				this.entityData.Precedence = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(TaxRuleColumn.Precedence, this.entityData.Precedence);
				OnPropertyChanged("Precedence");
			}
		}
		

		#region Source Foreign Key Property
				
		private Portal _portalIDSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="Portal"/>.
		/// </summary>
		/// <value>The source Portal for PortalID.</value>
        [XmlIgnore()]
		[Browsable(false), BindableAttribute()]
		public virtual Portal PortalIDSource
      	{
            get { return this._portalIDSource; }
            set { this._portalIDSource = value; }
      	}
		private Country _destinationCountryCodeSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="Country"/>.
		/// </summary>
		/// <value>The source Country for DestinationCountryCode.</value>
        [XmlIgnore()]
		[Browsable(false), BindableAttribute()]
		public virtual Country DestinationCountryCodeSource
      	{
            get { return this._destinationCountryCodeSource; }
            set { this._destinationCountryCodeSource = value; }
      	}
		#endregion
			
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "ZNodeTaxRule"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"TaxRuleID", "PortalID", "TaxRate", "DestinationCountryCode", "DestinationStateCode", "Precedence"};
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
	            this.backupData = this.entityData.Clone() as TaxRuleEntityData;
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
						this.parentCollection.Remove( (TaxRule) this ) ;
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
	            this.parentCollection = value as TList<TaxRule>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as TaxRule);
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
		///  Returns a Typed TaxRule Entity 
		///</summary>
		public virtual TaxRule Copy()
		{
			//shallow copy entity
			TaxRule copy = new TaxRule();
			copy.TaxRuleID = this.TaxRuleID;
			copy.PortalID = this.PortalID;
			copy.TaxRate = this.TaxRate;
			copy.DestinationCountryCode = this.DestinationCountryCode;
			copy.DestinationStateCode = this.DestinationStateCode;
			copy.Precedence = this.Precedence;
					
			copy.AcceptChanges();
			return (TaxRule)copy;
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
		///  Returns a Typed TaxRule Entity which is a deep copy of the current entity.
		///</summary>
		public virtual TaxRule DeepCopy()
		{
			return EntityHelper.Clone<TaxRule>(this as TaxRule);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="TaxRuleBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(TaxRuleBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="TaxRuleBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="TaxRuleBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="TaxRuleBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(TaxRuleBase Object1, TaxRuleBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.TaxRuleID != Object2.TaxRuleID)
				equal = false;
			if (Object1.PortalID != Object2.PortalID)
				equal = false;
			if (Object1.TaxRate != Object2.TaxRate)
				equal = false;
			if ( Object1.DestinationCountryCode != null && Object2.DestinationCountryCode != null )
			{
				if (Object1.DestinationCountryCode != Object2.DestinationCountryCode)
					equal = false;
			}
			else if (Object1.DestinationCountryCode == null ^ Object2.DestinationCountryCode == null )
			{
				equal = false;
			}
			if ( Object1.DestinationStateCode != null && Object2.DestinationStateCode != null )
			{
				if (Object1.DestinationStateCode != Object2.DestinationStateCode)
					equal = false;
			}
			else if (Object1.DestinationStateCode == null ^ Object2.DestinationStateCode == null )
			{
				equal = false;
			}
			if (Object1.Precedence != Object2.Precedence)
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((TaxRuleBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static TaxRuleComparer GetComparer()
        {
            return new TaxRuleComparer();
        }
        */

        // Comparer delegates back to TaxRule
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
        public int CompareTo(TaxRule rhs, TaxRuleColumn which)
        {
            switch (which)
            {
            	
            	
            	case TaxRuleColumn.TaxRuleID:
            		return this.TaxRuleID.CompareTo(rhs.TaxRuleID);
            		
            		                 
            	
            	
            	case TaxRuleColumn.PortalID:
            		return this.PortalID.CompareTo(rhs.PortalID);
            		
            		                 
            	
            	
            	case TaxRuleColumn.TaxRate:
            		return this.TaxRate.CompareTo(rhs.TaxRate);
            		
            		                 
            	
            	
            	case TaxRuleColumn.DestinationCountryCode:
            		return this.DestinationCountryCode.CompareTo(rhs.DestinationCountryCode);
            		
            		                 
            	
            	
            	case TaxRuleColumn.DestinationStateCode:
            		return this.DestinationStateCode.CompareTo(rhs.DestinationStateCode);
            		
            		                 
            	
            	
            	case TaxRuleColumn.Precedence:
            		return this.Precedence.CompareTo(rhs.Precedence);
            		
            		                 
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
				
		#region IEntityKey<TaxRuleKey> Members
		
		// member variable for the EntityId property
		private TaxRuleKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public TaxRuleKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new TaxRuleKey(this);
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
					entityTrackingKey = @"TaxRule" 
					+ this.TaxRuleID.ToString();
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
				"{7}{6}- TaxRuleID: {0}{6}- PortalID: {1}{6}- TaxRate: {2}{6}- DestinationCountryCode: {3}{6}- DestinationStateCode: {4}{6}- Precedence: {5}{6}", 
				this.TaxRuleID,
				this.PortalID,
				this.TaxRate,
				(this.DestinationCountryCode == null) ? string.Empty : this.DestinationCountryCode.ToString(),
				(this.DestinationStateCode == null) ? string.Empty : this.DestinationStateCode.ToString(),
				this.Precedence,
				Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'ZNodeTaxRule' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class TaxRuleEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// TaxRuleID : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "ZNodeTaxRule"</remarks>
			public System.Int32 TaxRuleID;
				
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// PortalID : 
		/// </summary>
		public System.Int32		  PortalID = (int)0;
		
		/// <summary>
		/// TaxRate : 
		/// </summary>
		public System.Decimal		  TaxRate = 0.0m;
		
		/// <summary>
		/// DestinationCountryCode : 
		/// </summary>
		public System.String		  DestinationCountryCode = string.Empty;
		
		/// <summary>
		/// DestinationStateCode : 
		/// </summary>
		public System.String		  DestinationStateCode = string.Empty;
		
		/// <summary>
		/// Precedence : 
		/// </summary>
		public System.Int32		  Precedence = (int)0;
		#endregion
			
		#endregion Variable Declarations
		
		#region Clone
		public Object Clone()
		{
			TaxRuleEntityData _tmp = new TaxRuleEntityData();
						
			_tmp.TaxRuleID = this.TaxRuleID;
			
			_tmp.PortalID = this.PortalID;
			_tmp.TaxRate = this.TaxRate;
			_tmp.DestinationCountryCode = this.DestinationCountryCode;
			_tmp.DestinationStateCode = this.DestinationStateCode;
			_tmp.Precedence = this.Precedence;
			
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
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("DestinationCountryCode",2));
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("DestinationStateCode",2));
		}
   		#endregion
	
	} // End Class
	
	#region TaxRuleComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class TaxRuleComparer : System.Collections.Generic.IComparer<TaxRule>
	{
		TaxRuleColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:TaxRuleComparer"/> class.
        /// </summary>
		public TaxRuleComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public TaxRuleComparer(TaxRuleColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="TaxRule"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="TaxRule"/> to compare.</param>
        /// <param name="b">The second <c>TaxRule</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(TaxRule a, TaxRule b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(TaxRule entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(TaxRule a, TaxRule b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public TaxRuleColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region TaxRuleKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="TaxRule"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class TaxRuleKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the TaxRuleKey class.
		/// </summary>
		public TaxRuleKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the TaxRuleKey class.
		/// </summary>
		public TaxRuleKey(TaxRuleBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.taxRuleID = entity.TaxRuleID;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the TaxRuleKey class.
		/// </summary>
		public TaxRuleKey(System.Int32 taxRuleID)
		{
			#region Init Properties

			this.taxRuleID = taxRuleID;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private TaxRuleBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public TaxRuleBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the TaxRuleID property
		private System.Int32 taxRuleID;
		
		/// <summary>
		/// Gets or sets the TaxRuleID property.
		/// </summary>
		public System.Int32 TaxRuleID
		{
			get { return taxRuleID; }
			set
			{
				if ( Entity != null )
				{
					Entity.TaxRuleID = value;
				}
				
				taxRuleID = value;
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
				TaxRuleID = ( values["TaxRuleID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TaxRuleID"], typeof(System.Int32)) : (int)0;
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

			values.Add("TaxRuleID", TaxRuleID);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("TaxRuleID: {0}{1}",
								TaxRuleID,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region TaxRuleColumn Enum
	
	/// <summary>
	/// Enumerate the TaxRule columns.
	/// </summary>
	[Serializable]
	public enum TaxRuleColumn : int
	{
		/// <summary>
		/// TaxRuleID : 
		/// </summary>
		[EnumTextValue("TaxRuleID")]
		[ColumnEnum("TaxRuleID", typeof(System.Int32), System.Data.DbType.Int32, true, true, false)]
		TaxRuleID = 1,
		/// <summary>
		/// PortalID : 
		/// </summary>
		[EnumTextValue("PortalID")]
		[ColumnEnum("PortalID", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		PortalID = 2,
		/// <summary>
		/// TaxRate : 
		/// </summary>
		[EnumTextValue("TaxRate")]
		[ColumnEnum("TaxRate", typeof(System.Decimal), System.Data.DbType.Decimal, false, false, false)]
		TaxRate = 3,
		/// <summary>
		/// DestinationCountryCode : 
		/// </summary>
		[EnumTextValue("DestinationCountryCode")]
		[ColumnEnum("DestinationCountryCode", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 2)]
		DestinationCountryCode = 4,
		/// <summary>
		/// DestinationStateCode : 
		/// </summary>
		[EnumTextValue("DestinationStateCode")]
		[ColumnEnum("DestinationStateCode", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 2)]
		DestinationStateCode = 5,
		/// <summary>
		/// Precedence : 
		/// </summary>
		[EnumTextValue("Precedence")]
		[ColumnEnum("Precedence", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		Precedence = 6
	}//End enum

	#endregion TaxRuleColumn Enum

} // end namespace