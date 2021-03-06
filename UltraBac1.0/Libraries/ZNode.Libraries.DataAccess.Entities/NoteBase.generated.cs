﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Thursday, October 18, 2007
	Important: Do not modify this file. Edit the file Note.cs instead.
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
	#region NoteEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="Note"/> object.
	/// </remarks>
	public class NoteEventArgs : System.EventArgs
	{
		private NoteColumn column;
		private object value;
		
		
		///<summary>
		/// Initalizes a new Instance of the NoteEventArgs class.
		///</summary>
		public NoteEventArgs(NoteColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the NoteEventArgs class.
		///</summary>
		public NoteEventArgs(NoteColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		
		///<summary>
		/// The NoteColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="NoteColumn" />
		public NoteColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all Note related events.
	///</summary>
	public delegate void NoteEventHandler(object sender, NoteEventArgs e);
	
	///<summary>
	/// An object representation of the 'ZNodeNote' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(Note))]
	public abstract partial class NoteBase : EntityBase, IEntityId<NoteKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private NoteEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//NoteEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private NoteEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<Note> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event NoteEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event NoteEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="NoteBase"/> instance.
		///</summary>
		public NoteBase()
		{
			this.entityData = new NoteEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="NoteBase"/> instance.
		///</summary>
		///<param name="noteCaseID"></param>
		///<param name="noteAccountID"></param>
		///<param name="noteNoteTitle"></param>
		///<param name="noteNoteBody"></param>
		///<param name="noteCreateDte"></param>
		///<param name="noteCreateUser"></param>
		public NoteBase(System.Int32? noteCaseID, System.Int32? noteAccountID, System.String noteNoteTitle, 
			System.String noteNoteBody, System.DateTime noteCreateDte, System.String noteCreateUser)
		{
			this.entityData = new NoteEntityData();
			this.backupData = null;

			this.CaseID = noteCaseID;
			this.AccountID = noteAccountID;
			this.NoteTitle = noteNoteTitle;
			this.NoteBody = noteNoteBody;
			this.CreateDte = noteCreateDte;
			this.CreateUser = noteCreateUser;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="Note"/> instance.
		///</summary>
		///<param name="noteCaseID"></param>
		///<param name="noteAccountID"></param>
		///<param name="noteNoteTitle"></param>
		///<param name="noteNoteBody"></param>
		///<param name="noteCreateDte"></param>
		///<param name="noteCreateUser"></param>
		public static Note CreateNote(System.Int32? noteCaseID, System.Int32? noteAccountID, System.String noteNoteTitle, 
			System.String noteNoteBody, System.DateTime noteCreateDte, System.String noteCreateUser)
		{
			Note newNote = new Note();
			newNote.CaseID = noteCaseID;
			newNote.AccountID = noteAccountID;
			newNote.NoteTitle = noteNoteTitle;
			newNote.NoteBody = noteNoteBody;
			newNote.CreateDte = noteCreateDte;
			newNote.CreateUser = noteCreateUser;
			return newNote;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="NoteColumn"/> which has raised the event.</param>
		public void OnColumnChanging(NoteColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="NoteColumn"/> which has raised the event.</param>
		public void OnColumnChanged(NoteColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="NoteColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(NoteColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				NoteEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new NoteEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="NoteColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(NoteColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				NoteEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new NoteEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the NoteID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[ReadOnlyAttribute(false)/*, XmlIgnoreAttribute()*/, DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true, true, false)]
		public virtual System.Int32 NoteID
		{
			get
			{
				return this.entityData.NoteID; 
			}
			
			set
			{
				if (this.entityData.NoteID == value)
					return;
					
					
				OnColumnChanging(NoteColumn.NoteID, this.entityData.NoteID);
				this.entityData.NoteID = value;
				this.EntityId.NoteID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(NoteColumn.NoteID, this.entityData.NoteID);
				OnPropertyChanged("NoteID");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the CaseID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return (int)0. It is up to the developer
		/// to check the value of IsCaseIDNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, true)]
		public virtual System.Int32? CaseID
		{
			get
			{
				return this.entityData.CaseID; 
			}
			
			set
			{
				if (this.entityData.CaseID == value)
					return;
					
					
				OnColumnChanging(NoteColumn.CaseID, this.entityData.CaseID);
				this.entityData.CaseID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(NoteColumn.CaseID, this.entityData.CaseID);
				OnPropertyChanged("CaseID");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the AccountID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return (int)0. It is up to the developer
		/// to check the value of IsAccountIDNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, true)]
		public virtual System.Int32? AccountID
		{
			get
			{
				return this.entityData.AccountID; 
			}
			
			set
			{
				if (this.entityData.AccountID == value)
					return;
					
					
				OnColumnChanging(NoteColumn.AccountID, this.entityData.AccountID);
				this.entityData.AccountID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(NoteColumn.AccountID, this.entityData.AccountID);
				OnPropertyChanged("AccountID");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the NoteTitle property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false, 255)]
		public virtual System.String NoteTitle
		{
			get
			{
				return this.entityData.NoteTitle; 
			}
			
			set
			{
				if (this.entityData.NoteTitle == value)
					return;
					
					
				OnColumnChanging(NoteColumn.NoteTitle, this.entityData.NoteTitle);
				this.entityData.NoteTitle = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(NoteColumn.NoteTitle, this.entityData.NoteTitle);
				OnPropertyChanged("NoteTitle");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the NoteBody property. 
		///		
		/// </summary>
		/// <value>This type is ntext.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, true)]
		public virtual System.String NoteBody
		{
			get
			{
				return this.entityData.NoteBody; 
			}
			
			set
			{
				if (this.entityData.NoteBody == value)
					return;
					
					
				OnColumnChanging(NoteColumn.NoteBody, this.entityData.NoteBody);
				this.entityData.NoteBody = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(NoteColumn.NoteBody, this.entityData.NoteBody);
				OnPropertyChanged("NoteBody");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the CreateDte property. 
		///		
		/// </summary>
		/// <value>This type is smalldatetime.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.DateTime CreateDte
		{
			get
			{
				return this.entityData.CreateDte; 
			}
			
			set
			{
				if (this.entityData.CreateDte == value)
					return;
					
					
				OnColumnChanging(NoteColumn.CreateDte, this.entityData.CreateDte);
				this.entityData.CreateDte = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(NoteColumn.CreateDte, this.entityData.CreateDte);
				OnPropertyChanged("CreateDte");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the CreateUser property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false, 100)]
		public virtual System.String CreateUser
		{
			get
			{
				return this.entityData.CreateUser; 
			}
			
			set
			{
				if (this.entityData.CreateUser == value)
					return;
					
					
				OnColumnChanging(NoteColumn.CreateUser, this.entityData.CreateUser);
				this.entityData.CreateUser = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(NoteColumn.CreateUser, this.entityData.CreateUser);
				OnPropertyChanged("CreateUser");
			}
		}
		

		#region Source Foreign Key Property
				
		private Account _accountIDSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="Account"/>.
		/// </summary>
		/// <value>The source Account for AccountID.</value>
        [XmlIgnore()]
		[Browsable(false), BindableAttribute()]
		public virtual Account AccountIDSource
      	{
            get { return this._accountIDSource; }
            set { this._accountIDSource = value; }
      	}
		private Case _caseIDSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="Case"/>.
		/// </summary>
		/// <value>The source Case for CaseID.</value>
        [XmlIgnore()]
		[Browsable(false), BindableAttribute()]
		public virtual Case CaseIDSource
      	{
            get { return this._caseIDSource; }
            set { this._caseIDSource = value; }
      	}
		#endregion
			
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "ZNodeNote"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"NoteID", "CaseID", "AccountID", "NoteTitle", "NoteBody", "CreateDte", "CreateUser"};
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
	            this.backupData = this.entityData.Clone() as NoteEntityData;
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
						this.parentCollection.Remove( (Note) this ) ;
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
	            this.parentCollection = value as TList<Note>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as Note);
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
		///  Returns a Typed Note Entity 
		///</summary>
		public virtual Note Copy()
		{
			//shallow copy entity
			Note copy = new Note();
			copy.NoteID = this.NoteID;
			copy.CaseID = this.CaseID;
			copy.AccountID = this.AccountID;
			copy.NoteTitle = this.NoteTitle;
			copy.NoteBody = this.NoteBody;
			copy.CreateDte = this.CreateDte;
			copy.CreateUser = this.CreateUser;
					
			copy.AcceptChanges();
			return (Note)copy;
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
		///  Returns a Typed Note Entity which is a deep copy of the current entity.
		///</summary>
		public virtual Note DeepCopy()
		{
			return EntityHelper.Clone<Note>(this as Note);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="NoteBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(NoteBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="NoteBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="NoteBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="NoteBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(NoteBase Object1, NoteBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.NoteID != Object2.NoteID)
				equal = false;
			if ( Object1.CaseID != null && Object2.CaseID != null )
			{
				if (Object1.CaseID != Object2.CaseID)
					equal = false;
			}
			else if (Object1.CaseID == null ^ Object2.CaseID == null )
			{
				equal = false;
			}
			if ( Object1.AccountID != null && Object2.AccountID != null )
			{
				if (Object1.AccountID != Object2.AccountID)
					equal = false;
			}
			else if (Object1.AccountID == null ^ Object2.AccountID == null )
			{
				equal = false;
			}
			if (Object1.NoteTitle != Object2.NoteTitle)
				equal = false;
			if ( Object1.NoteBody != null && Object2.NoteBody != null )
			{
				if (Object1.NoteBody != Object2.NoteBody)
					equal = false;
			}
			else if (Object1.NoteBody == null ^ Object2.NoteBody == null )
			{
				equal = false;
			}
			if (Object1.CreateDte != Object2.CreateDte)
				equal = false;
			if (Object1.CreateUser != Object2.CreateUser)
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((NoteBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static NoteComparer GetComparer()
        {
            return new NoteComparer();
        }
        */

        // Comparer delegates back to Note
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
        public int CompareTo(Note rhs, NoteColumn which)
        {
            switch (which)
            {
            	
            	
            	case NoteColumn.NoteID:
            		return this.NoteID.CompareTo(rhs.NoteID);
            		
            		                 
            	
            	
            	case NoteColumn.CaseID:
            		return this.CaseID.Value.CompareTo(rhs.CaseID.Value);
            		
            		                 
            	
            	
            	case NoteColumn.AccountID:
            		return this.AccountID.Value.CompareTo(rhs.AccountID.Value);
            		
            		                 
            	
            	
            	case NoteColumn.NoteTitle:
            		return this.NoteTitle.CompareTo(rhs.NoteTitle);
            		
            		                 
            	
            	
            	case NoteColumn.NoteBody:
            		return this.NoteBody.CompareTo(rhs.NoteBody);
            		
            		                 
            	
            	
            	case NoteColumn.CreateDte:
            		return this.CreateDte.CompareTo(rhs.CreateDte);
            		
            		                 
            	
            	
            	case NoteColumn.CreateUser:
            		return this.CreateUser.CompareTo(rhs.CreateUser);
            		
            		                 
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
				
		#region IEntityKey<NoteKey> Members
		
		// member variable for the EntityId property
		private NoteKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public NoteKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new NoteKey(this);
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
					entityTrackingKey = @"Note" 
					+ this.NoteID.ToString();
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
				"{8}{7}- NoteID: {0}{7}- CaseID: {1}{7}- AccountID: {2}{7}- NoteTitle: {3}{7}- NoteBody: {4}{7}- CreateDte: {5}{7}- CreateUser: {6}{7}", 
				this.NoteID,
				(this.CaseID == null) ? string.Empty : this.CaseID.ToString(),
				(this.AccountID == null) ? string.Empty : this.AccountID.ToString(),
				this.NoteTitle,
				(this.NoteBody == null) ? string.Empty : this.NoteBody.ToString(),
				this.CreateDte,
				this.CreateUser,
				Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'ZNodeNote' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class NoteEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// NoteID : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "ZNodeNote"</remarks>
			public System.Int32 NoteID;
				
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// CaseID : 
		/// </summary>
		public System.Int32?		  CaseID = (int)0;
		
		/// <summary>
		/// AccountID : 
		/// </summary>
		public System.Int32?		  AccountID = (int)0;
		
		/// <summary>
		/// NoteTitle : 
		/// </summary>
		public System.String		  NoteTitle = string.Empty;
		
		/// <summary>
		/// NoteBody : 
		/// </summary>
		public System.String		  NoteBody = string.Empty;
		
		/// <summary>
		/// CreateDte : 
		/// </summary>
		public System.DateTime		  CreateDte = DateTime.MinValue;
		
		/// <summary>
		/// CreateUser : 
		/// </summary>
		public System.String		  CreateUser = string.Empty;
		#endregion
			
		#endregion Variable Declarations
		
		#region Clone
		public Object Clone()
		{
			NoteEntityData _tmp = new NoteEntityData();
						
			_tmp.NoteID = this.NoteID;
			
			_tmp.CaseID = this.CaseID;
			_tmp.AccountID = this.AccountID;
			_tmp.NoteTitle = this.NoteTitle;
			_tmp.NoteBody = this.NoteBody;
			_tmp.CreateDte = this.CreateDte;
			_tmp.CreateUser = this.CreateUser;
			
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
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"NoteTitle");
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("NoteTitle",255));
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"CreateUser");
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("CreateUser",100));
		}
   		#endregion
	
	} // End Class
	
	#region NoteComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class NoteComparer : System.Collections.Generic.IComparer<Note>
	{
		NoteColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:NoteComparer"/> class.
        /// </summary>
		public NoteComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public NoteComparer(NoteColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="Note"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="Note"/> to compare.</param>
        /// <param name="b">The second <c>Note</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(Note a, Note b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(Note entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(Note a, Note b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public NoteColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region NoteKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="Note"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class NoteKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the NoteKey class.
		/// </summary>
		public NoteKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the NoteKey class.
		/// </summary>
		public NoteKey(NoteBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.noteID = entity.NoteID;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the NoteKey class.
		/// </summary>
		public NoteKey(System.Int32 noteID)
		{
			#region Init Properties

			this.noteID = noteID;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private NoteBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public NoteBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the NoteID property
		private System.Int32 noteID;
		
		/// <summary>
		/// Gets or sets the NoteID property.
		/// </summary>
		public System.Int32 NoteID
		{
			get { return noteID; }
			set
			{
				if ( Entity != null )
				{
					Entity.NoteID = value;
				}
				
				noteID = value;
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
				NoteID = ( values["NoteID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["NoteID"], typeof(System.Int32)) : (int)0;
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

			values.Add("NoteID", NoteID);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("NoteID: {0}{1}",
								NoteID,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region NoteColumn Enum
	
	/// <summary>
	/// Enumerate the Note columns.
	/// </summary>
	[Serializable]
	public enum NoteColumn : int
	{
		/// <summary>
		/// NoteID : 
		/// </summary>
		[EnumTextValue("NoteID")]
		[ColumnEnum("NoteID", typeof(System.Int32), System.Data.DbType.Int32, true, true, false)]
		NoteID = 1,
		/// <summary>
		/// CaseID : 
		/// </summary>
		[EnumTextValue("CaseID")]
		[ColumnEnum("CaseID", typeof(System.Int32), System.Data.DbType.Int32, false, false, true)]
		CaseID = 2,
		/// <summary>
		/// AccountID : 
		/// </summary>
		[EnumTextValue("AccountID")]
		[ColumnEnum("AccountID", typeof(System.Int32), System.Data.DbType.Int32, false, false, true)]
		AccountID = 3,
		/// <summary>
		/// NoteTitle : 
		/// </summary>
		[EnumTextValue("NoteTitle")]
		[ColumnEnum("NoteTitle", typeof(System.String), System.Data.DbType.AnsiString, false, false, false, 255)]
		NoteTitle = 4,
		/// <summary>
		/// NoteBody : 
		/// </summary>
		[EnumTextValue("NoteBody")]
		[ColumnEnum("NoteBody", typeof(System.String), System.Data.DbType.String, false, false, true)]
		NoteBody = 5,
		/// <summary>
		/// CreateDte : 
		/// </summary>
		[EnumTextValue("CreateDte")]
		[ColumnEnum("CreateDte", typeof(System.DateTime), System.Data.DbType.DateTime, false, false, false)]
		CreateDte = 6,
		/// <summary>
		/// CreateUser : 
		/// </summary>
		[EnumTextValue("CreateUser")]
		[ColumnEnum("CreateUser", typeof(System.String), System.Data.DbType.AnsiString, false, false, false, 100)]
		CreateUser = 7
	}//End enum

	#endregion NoteColumn Enum

} // end namespace
