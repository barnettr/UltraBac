﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Thursday, October 18, 2007
	Important: Do not modify this file. Edit the file ContentPageRevision.cs instead.
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
	#region ContentPageRevisionEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="ContentPageRevision"/> object.
	/// </remarks>
	public class ContentPageRevisionEventArgs : System.EventArgs
	{
		private ContentPageRevisionColumn column;
		private object value;
		
		
		///<summary>
		/// Initalizes a new Instance of the ContentPageRevisionEventArgs class.
		///</summary>
		public ContentPageRevisionEventArgs(ContentPageRevisionColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the ContentPageRevisionEventArgs class.
		///</summary>
		public ContentPageRevisionEventArgs(ContentPageRevisionColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		
		///<summary>
		/// The ContentPageRevisionColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="ContentPageRevisionColumn" />
		public ContentPageRevisionColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all ContentPageRevision related events.
	///</summary>
	public delegate void ContentPageRevisionEventHandler(object sender, ContentPageRevisionEventArgs e);
	
	///<summary>
	/// An object representation of the 'ZNodeContentPageRevision' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(ContentPageRevision))]
	public abstract partial class ContentPageRevisionBase : EntityBase, IEntityId<ContentPageRevisionKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private ContentPageRevisionEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//ContentPageRevisionEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private ContentPageRevisionEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<ContentPageRevision> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event ContentPageRevisionEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event ContentPageRevisionEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="ContentPageRevisionBase"/> instance.
		///</summary>
		public ContentPageRevisionBase()
		{
			this.entityData = new ContentPageRevisionEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="ContentPageRevisionBase"/> instance.
		///</summary>
		///<param name="contentPageRevisionContentPageID"></param>
		///<param name="contentPageRevisionUpdateDate"></param>
		///<param name="contentPageRevisionUpdateUser"></param>
		///<param name="contentPageRevisionDescription"></param>
		///<param name="contentPageRevisionHtmlText"></param>
		public ContentPageRevisionBase(System.Int32 contentPageRevisionContentPageID, System.DateTime contentPageRevisionUpdateDate, 
			System.String contentPageRevisionUpdateUser, System.String contentPageRevisionDescription, System.String contentPageRevisionHtmlText)
		{
			this.entityData = new ContentPageRevisionEntityData();
			this.backupData = null;

			this.ContentPageID = contentPageRevisionContentPageID;
			this.UpdateDate = contentPageRevisionUpdateDate;
			this.UpdateUser = contentPageRevisionUpdateUser;
			this.Description = contentPageRevisionDescription;
			this.HtmlText = contentPageRevisionHtmlText;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="ContentPageRevision"/> instance.
		///</summary>
		///<param name="contentPageRevisionContentPageID"></param>
		///<param name="contentPageRevisionUpdateDate"></param>
		///<param name="contentPageRevisionUpdateUser"></param>
		///<param name="contentPageRevisionDescription"></param>
		///<param name="contentPageRevisionHtmlText"></param>
		public static ContentPageRevision CreateContentPageRevision(System.Int32 contentPageRevisionContentPageID, System.DateTime contentPageRevisionUpdateDate, 
			System.String contentPageRevisionUpdateUser, System.String contentPageRevisionDescription, System.String contentPageRevisionHtmlText)
		{
			ContentPageRevision newContentPageRevision = new ContentPageRevision();
			newContentPageRevision.ContentPageID = contentPageRevisionContentPageID;
			newContentPageRevision.UpdateDate = contentPageRevisionUpdateDate;
			newContentPageRevision.UpdateUser = contentPageRevisionUpdateUser;
			newContentPageRevision.Description = contentPageRevisionDescription;
			newContentPageRevision.HtmlText = contentPageRevisionHtmlText;
			return newContentPageRevision;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ContentPageRevisionColumn"/> which has raised the event.</param>
		public void OnColumnChanging(ContentPageRevisionColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ContentPageRevisionColumn"/> which has raised the event.</param>
		public void OnColumnChanged(ContentPageRevisionColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ContentPageRevisionColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(ContentPageRevisionColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				ContentPageRevisionEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new ContentPageRevisionEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ContentPageRevisionColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(ContentPageRevisionColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				ContentPageRevisionEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new ContentPageRevisionEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the RevisionID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[ReadOnlyAttribute(false)/*, XmlIgnoreAttribute()*/, DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true, true, false)]
		public virtual System.Int32 RevisionID
		{
			get
			{
				return this.entityData.RevisionID; 
			}
			
			set
			{
				if (this.entityData.RevisionID == value)
					return;
					
					
				OnColumnChanging(ContentPageRevisionColumn.RevisionID, this.entityData.RevisionID);
				this.entityData.RevisionID = value;
				this.EntityId.RevisionID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ContentPageRevisionColumn.RevisionID, this.entityData.RevisionID);
				OnPropertyChanged("RevisionID");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the ContentPageID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Int32 ContentPageID
		{
			get
			{
				return this.entityData.ContentPageID; 
			}
			
			set
			{
				if (this.entityData.ContentPageID == value)
					return;
					
					
				OnColumnChanging(ContentPageRevisionColumn.ContentPageID, this.entityData.ContentPageID);
				this.entityData.ContentPageID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ContentPageRevisionColumn.ContentPageID, this.entityData.ContentPageID);
				OnPropertyChanged("ContentPageID");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the UpdateDate property. 
		///		
		/// </summary>
		/// <value>This type is smalldatetime.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.DateTime UpdateDate
		{
			get
			{
				return this.entityData.UpdateDate; 
			}
			
			set
			{
				if (this.entityData.UpdateDate == value)
					return;
					
					
				OnColumnChanging(ContentPageRevisionColumn.UpdateDate, this.entityData.UpdateDate);
				this.entityData.UpdateDate = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ContentPageRevisionColumn.UpdateDate, this.entityData.UpdateDate);
				OnPropertyChanged("UpdateDate");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the UpdateUser property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false, 50)]
		public virtual System.String UpdateUser
		{
			get
			{
				return this.entityData.UpdateUser; 
			}
			
			set
			{
				if (this.entityData.UpdateUser == value)
					return;
					
					
				OnColumnChanging(ContentPageRevisionColumn.UpdateUser, this.entityData.UpdateUser);
				this.entityData.UpdateUser = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ContentPageRevisionColumn.UpdateUser, this.entityData.UpdateUser);
				OnPropertyChanged("UpdateUser");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Description property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, true)]
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
					
					
				OnColumnChanging(ContentPageRevisionColumn.Description, this.entityData.Description);
				this.entityData.Description = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ContentPageRevisionColumn.Description, this.entityData.Description);
				OnPropertyChanged("Description");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the HtmlText property. 
		///		
		/// </summary>
		/// <value>This type is ntext.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, true)]
		public virtual System.String HtmlText
		{
			get
			{
				return this.entityData.HtmlText; 
			}
			
			set
			{
				if (this.entityData.HtmlText == value)
					return;
					
					
				OnColumnChanging(ContentPageRevisionColumn.HtmlText, this.entityData.HtmlText);
				this.entityData.HtmlText = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ContentPageRevisionColumn.HtmlText, this.entityData.HtmlText);
				OnPropertyChanged("HtmlText");
			}
		}
		

		#region Source Foreign Key Property
				
		private ContentPage _contentPageIDSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="ContentPage"/>.
		/// </summary>
		/// <value>The source ContentPage for ContentPageID.</value>
        [XmlIgnore()]
		[Browsable(false), BindableAttribute()]
		public virtual ContentPage ContentPageIDSource
      	{
            get { return this._contentPageIDSource; }
            set { this._contentPageIDSource = value; }
      	}
		#endregion
			
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "ZNodeContentPageRevision"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"RevisionID", "ContentPageID", "UpdateDate", "UpdateUser", "Description", "HtmlText"};
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
	            this.backupData = this.entityData.Clone() as ContentPageRevisionEntityData;
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
						this.parentCollection.Remove( (ContentPageRevision) this ) ;
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
	            this.parentCollection = value as TList<ContentPageRevision>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as ContentPageRevision);
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
		///  Returns a Typed ContentPageRevision Entity 
		///</summary>
		public virtual ContentPageRevision Copy()
		{
			//shallow copy entity
			ContentPageRevision copy = new ContentPageRevision();
			copy.RevisionID = this.RevisionID;
			copy.ContentPageID = this.ContentPageID;
			copy.UpdateDate = this.UpdateDate;
			copy.UpdateUser = this.UpdateUser;
			copy.Description = this.Description;
			copy.HtmlText = this.HtmlText;
					
			copy.AcceptChanges();
			return (ContentPageRevision)copy;
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
		///  Returns a Typed ContentPageRevision Entity which is a deep copy of the current entity.
		///</summary>
		public virtual ContentPageRevision DeepCopy()
		{
			return EntityHelper.Clone<ContentPageRevision>(this as ContentPageRevision);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="ContentPageRevisionBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(ContentPageRevisionBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="ContentPageRevisionBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="ContentPageRevisionBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="ContentPageRevisionBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(ContentPageRevisionBase Object1, ContentPageRevisionBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.RevisionID != Object2.RevisionID)
				equal = false;
			if (Object1.ContentPageID != Object2.ContentPageID)
				equal = false;
			if (Object1.UpdateDate != Object2.UpdateDate)
				equal = false;
			if (Object1.UpdateUser != Object2.UpdateUser)
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
			if ( Object1.HtmlText != null && Object2.HtmlText != null )
			{
				if (Object1.HtmlText != Object2.HtmlText)
					equal = false;
			}
			else if (Object1.HtmlText == null ^ Object2.HtmlText == null )
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((ContentPageRevisionBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static ContentPageRevisionComparer GetComparer()
        {
            return new ContentPageRevisionComparer();
        }
        */

        // Comparer delegates back to ContentPageRevision
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
        public int CompareTo(ContentPageRevision rhs, ContentPageRevisionColumn which)
        {
            switch (which)
            {
            	
            	
            	case ContentPageRevisionColumn.RevisionID:
            		return this.RevisionID.CompareTo(rhs.RevisionID);
            		
            		                 
            	
            	
            	case ContentPageRevisionColumn.ContentPageID:
            		return this.ContentPageID.CompareTo(rhs.ContentPageID);
            		
            		                 
            	
            	
            	case ContentPageRevisionColumn.UpdateDate:
            		return this.UpdateDate.CompareTo(rhs.UpdateDate);
            		
            		                 
            	
            	
            	case ContentPageRevisionColumn.UpdateUser:
            		return this.UpdateUser.CompareTo(rhs.UpdateUser);
            		
            		                 
            	
            	
            	case ContentPageRevisionColumn.Description:
            		return this.Description.CompareTo(rhs.Description);
            		
            		                 
            	
            	
            	case ContentPageRevisionColumn.HtmlText:
            		return this.HtmlText.CompareTo(rhs.HtmlText);
            		
            		                 
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
				
		#region IEntityKey<ContentPageRevisionKey> Members
		
		// member variable for the EntityId property
		private ContentPageRevisionKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public ContentPageRevisionKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new ContentPageRevisionKey(this);
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
					entityTrackingKey = @"ContentPageRevision" 
					+ this.RevisionID.ToString();
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
				"{7}{6}- RevisionID: {0}{6}- ContentPageID: {1}{6}- UpdateDate: {2}{6}- UpdateUser: {3}{6}- Description: {4}{6}- HtmlText: {5}{6}", 
				this.RevisionID,
				this.ContentPageID,
				this.UpdateDate,
				this.UpdateUser,
				(this.Description == null) ? string.Empty : this.Description.ToString(),
				(this.HtmlText == null) ? string.Empty : this.HtmlText.ToString(),
				Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'ZNodeContentPageRevision' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class ContentPageRevisionEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// RevisionID : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "ZNodeContentPageRevision"</remarks>
			public System.Int32 RevisionID;
				
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// ContentPageID : 
		/// </summary>
		public System.Int32		  ContentPageID = (int)0;
		
		/// <summary>
		/// UpdateDate : 
		/// </summary>
		public System.DateTime		  UpdateDate = DateTime.MinValue;
		
		/// <summary>
		/// UpdateUser : 
		/// </summary>
		public System.String		  UpdateUser = string.Empty;
		
		/// <summary>
		/// Description : 
		/// </summary>
		public System.String		  Description = string.Empty;
		
		/// <summary>
		/// HtmlText : 
		/// </summary>
		public System.String		  HtmlText = string.Empty;
		#endregion
			
		#endregion Variable Declarations
		
		#region Clone
		public Object Clone()
		{
			ContentPageRevisionEntityData _tmp = new ContentPageRevisionEntityData();
						
			_tmp.RevisionID = this.RevisionID;
			
			_tmp.ContentPageID = this.ContentPageID;
			_tmp.UpdateDate = this.UpdateDate;
			_tmp.UpdateUser = this.UpdateUser;
			_tmp.Description = this.Description;
			_tmp.HtmlText = this.HtmlText;
			
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
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"UpdateUser");
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("UpdateUser",50));
		}
   		#endregion
	
	} // End Class
	
	#region ContentPageRevisionComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class ContentPageRevisionComparer : System.Collections.Generic.IComparer<ContentPageRevision>
	{
		ContentPageRevisionColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:ContentPageRevisionComparer"/> class.
        /// </summary>
		public ContentPageRevisionComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public ContentPageRevisionComparer(ContentPageRevisionColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="ContentPageRevision"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="ContentPageRevision"/> to compare.</param>
        /// <param name="b">The second <c>ContentPageRevision</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(ContentPageRevision a, ContentPageRevision b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(ContentPageRevision entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(ContentPageRevision a, ContentPageRevision b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public ContentPageRevisionColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region ContentPageRevisionKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="ContentPageRevision"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class ContentPageRevisionKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the ContentPageRevisionKey class.
		/// </summary>
		public ContentPageRevisionKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the ContentPageRevisionKey class.
		/// </summary>
		public ContentPageRevisionKey(ContentPageRevisionBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.revisionID = entity.RevisionID;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the ContentPageRevisionKey class.
		/// </summary>
		public ContentPageRevisionKey(System.Int32 revisionID)
		{
			#region Init Properties

			this.revisionID = revisionID;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private ContentPageRevisionBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public ContentPageRevisionBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the RevisionID property
		private System.Int32 revisionID;
		
		/// <summary>
		/// Gets or sets the RevisionID property.
		/// </summary>
		public System.Int32 RevisionID
		{
			get { return revisionID; }
			set
			{
				if ( Entity != null )
				{
					Entity.RevisionID = value;
				}
				
				revisionID = value;
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
				RevisionID = ( values["RevisionID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["RevisionID"], typeof(System.Int32)) : (int)0;
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

			values.Add("RevisionID", RevisionID);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("RevisionID: {0}{1}",
								RevisionID,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region ContentPageRevisionColumn Enum
	
	/// <summary>
	/// Enumerate the ContentPageRevision columns.
	/// </summary>
	[Serializable]
	public enum ContentPageRevisionColumn : int
	{
		/// <summary>
		/// RevisionID : 
		/// </summary>
		[EnumTextValue("RevisionID")]
		[ColumnEnum("RevisionID", typeof(System.Int32), System.Data.DbType.Int32, true, true, false)]
		RevisionID = 1,
		/// <summary>
		/// ContentPageID : 
		/// </summary>
		[EnumTextValue("ContentPageID")]
		[ColumnEnum("ContentPageID", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		ContentPageID = 2,
		/// <summary>
		/// UpdateDate : 
		/// </summary>
		[EnumTextValue("UpdateDate")]
		[ColumnEnum("UpdateDate", typeof(System.DateTime), System.Data.DbType.DateTime, false, false, false)]
		UpdateDate = 3,
		/// <summary>
		/// UpdateUser : 
		/// </summary>
		[EnumTextValue("UpdateUser")]
		[ColumnEnum("UpdateUser", typeof(System.String), System.Data.DbType.String, false, false, false, 50)]
		UpdateUser = 4,
		/// <summary>
		/// Description : 
		/// </summary>
		[EnumTextValue("Description")]
		[ColumnEnum("Description", typeof(System.String), System.Data.DbType.String, false, false, true)]
		Description = 5,
		/// <summary>
		/// HtmlText : 
		/// </summary>
		[EnumTextValue("HtmlText")]
		[ColumnEnum("HtmlText", typeof(System.String), System.Data.DbType.String, false, false, true)]
		HtmlText = 6
	}//End enum

	#endregion ContentPageRevisionColumn Enum

} // end namespace