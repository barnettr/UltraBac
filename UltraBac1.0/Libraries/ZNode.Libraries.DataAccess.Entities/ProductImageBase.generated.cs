﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Thursday, October 18, 2007
	Important: Do not modify this file. Edit the file ProductImage.cs instead.
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
	#region ProductImageEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="ProductImage"/> object.
	/// </remarks>
	public class ProductImageEventArgs : System.EventArgs
	{
		private ProductImageColumn column;
		private object value;
		
		
		///<summary>
		/// Initalizes a new Instance of the ProductImageEventArgs class.
		///</summary>
		public ProductImageEventArgs(ProductImageColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the ProductImageEventArgs class.
		///</summary>
		public ProductImageEventArgs(ProductImageColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		
		///<summary>
		/// The ProductImageColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="ProductImageColumn" />
		public ProductImageColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all ProductImage related events.
	///</summary>
	public delegate void ProductImageEventHandler(object sender, ProductImageEventArgs e);
	
	///<summary>
	/// An object representation of the 'ZNodeProductImage' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(ProductImage))]
	public abstract partial class ProductImageBase : EntityBase, IEntityId<ProductImageKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private ProductImageEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//ProductImageEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private ProductImageEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<ProductImage> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event ProductImageEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event ProductImageEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="ProductImageBase"/> instance.
		///</summary>
		public ProductImageBase()
		{
			this.entityData = new ProductImageEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="ProductImageBase"/> instance.
		///</summary>
		///<param name="productImageProductID"></param>
		///<param name="productImageName"></param>
		///<param name="productImageImageFile"></param>
		///<param name="productImageActiveInd"></param>
		public ProductImageBase(System.Int32 productImageProductID, System.String productImageName, System.String productImageImageFile, 
			System.Boolean productImageActiveInd)
		{
			this.entityData = new ProductImageEntityData();
			this.backupData = null;

			this.ProductID = productImageProductID;
			this.Name = productImageName;
			this.ImageFile = productImageImageFile;
			this.ActiveInd = productImageActiveInd;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="ProductImage"/> instance.
		///</summary>
		///<param name="productImageProductID"></param>
		///<param name="productImageName"></param>
		///<param name="productImageImageFile"></param>
		///<param name="productImageActiveInd"></param>
		public static ProductImage CreateProductImage(System.Int32 productImageProductID, System.String productImageName, System.String productImageImageFile, 
			System.Boolean productImageActiveInd)
		{
			ProductImage newProductImage = new ProductImage();
			newProductImage.ProductID = productImageProductID;
			newProductImage.Name = productImageName;
			newProductImage.ImageFile = productImageImageFile;
			newProductImage.ActiveInd = productImageActiveInd;
			return newProductImage;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ProductImageColumn"/> which has raised the event.</param>
		public void OnColumnChanging(ProductImageColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ProductImageColumn"/> which has raised the event.</param>
		public void OnColumnChanged(ProductImageColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ProductImageColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(ProductImageColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				ProductImageEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new ProductImageEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ProductImageColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(ProductImageColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				ProductImageEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new ProductImageEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the ProductImageID property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[ReadOnlyAttribute(false)/*, XmlIgnoreAttribute()*/, DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true, true, false)]
		public virtual System.Int32 ProductImageID
		{
			get
			{
				return this.entityData.ProductImageID; 
			}
			
			set
			{
				if (this.entityData.ProductImageID == value)
					return;
					
					
				OnColumnChanging(ProductImageColumn.ProductImageID, this.entityData.ProductImageID);
				this.entityData.ProductImageID = value;
				this.EntityId.ProductImageID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ProductImageColumn.ProductImageID, this.entityData.ProductImageID);
				OnPropertyChanged("ProductImageID");
			}
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
					
					
				OnColumnChanging(ProductImageColumn.ProductID, this.entityData.ProductID);
				this.entityData.ProductID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ProductImageColumn.ProductID, this.entityData.ProductID);
				OnPropertyChanged("ProductID");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Name property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, true, 255)]
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
					
					
				OnColumnChanging(ProductImageColumn.Name, this.entityData.Name);
				this.entityData.Name = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ProductImageColumn.Name, this.entityData.Name);
				OnPropertyChanged("Name");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the ImageFile property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, true, 255)]
		public virtual System.String ImageFile
		{
			get
			{
				return this.entityData.ImageFile; 
			}
			
			set
			{
				if (this.entityData.ImageFile == value)
					return;
					
					
				OnColumnChanging(ProductImageColumn.ImageFile, this.entityData.ImageFile);
				this.entityData.ImageFile = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ProductImageColumn.ImageFile, this.entityData.ImageFile);
				OnPropertyChanged("ImageFile");
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
					
					
				OnColumnChanging(ProductImageColumn.ActiveInd, this.entityData.ActiveInd);
				this.entityData.ActiveInd = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ProductImageColumn.ActiveInd, this.entityData.ActiveInd);
				OnPropertyChanged("ActiveInd");
			}
		}
		

		#region Source Foreign Key Property
				
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
			get { return "ZNodeProductImage"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"ProductImageID", "ProductID", "Name", "ImageFile", "ActiveInd"};
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
	            this.backupData = this.entityData.Clone() as ProductImageEntityData;
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
						this.parentCollection.Remove( (ProductImage) this ) ;
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
	            this.parentCollection = value as TList<ProductImage>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as ProductImage);
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
		///  Returns a Typed ProductImage Entity 
		///</summary>
		public virtual ProductImage Copy()
		{
			//shallow copy entity
			ProductImage copy = new ProductImage();
			copy.ProductImageID = this.ProductImageID;
			copy.ProductID = this.ProductID;
			copy.Name = this.Name;
			copy.ImageFile = this.ImageFile;
			copy.ActiveInd = this.ActiveInd;
					
			copy.AcceptChanges();
			return (ProductImage)copy;
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
		///  Returns a Typed ProductImage Entity which is a deep copy of the current entity.
		///</summary>
		public virtual ProductImage DeepCopy()
		{
			return EntityHelper.Clone<ProductImage>(this as ProductImage);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="ProductImageBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(ProductImageBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="ProductImageBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="ProductImageBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="ProductImageBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(ProductImageBase Object1, ProductImageBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.ProductImageID != Object2.ProductImageID)
				equal = false;
			if (Object1.ProductID != Object2.ProductID)
				equal = false;
			if ( Object1.Name != null && Object2.Name != null )
			{
				if (Object1.Name != Object2.Name)
					equal = false;
			}
			else if (Object1.Name == null ^ Object2.Name == null )
			{
				equal = false;
			}
			if ( Object1.ImageFile != null && Object2.ImageFile != null )
			{
				if (Object1.ImageFile != Object2.ImageFile)
					equal = false;
			}
			else if (Object1.ImageFile == null ^ Object2.ImageFile == null )
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((ProductImageBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static ProductImageComparer GetComparer()
        {
            return new ProductImageComparer();
        }
        */

        // Comparer delegates back to ProductImage
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
        public int CompareTo(ProductImage rhs, ProductImageColumn which)
        {
            switch (which)
            {
            	
            	
            	case ProductImageColumn.ProductImageID:
            		return this.ProductImageID.CompareTo(rhs.ProductImageID);
            		
            		                 
            	
            	
            	case ProductImageColumn.ProductID:
            		return this.ProductID.CompareTo(rhs.ProductID);
            		
            		                 
            	
            	
            	case ProductImageColumn.Name:
            		return this.Name.CompareTo(rhs.Name);
            		
            		                 
            	
            	
            	case ProductImageColumn.ImageFile:
            		return this.ImageFile.CompareTo(rhs.ImageFile);
            		
            		                 
            	
            	
            	case ProductImageColumn.ActiveInd:
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
				
		#region IEntityKey<ProductImageKey> Members
		
		// member variable for the EntityId property
		private ProductImageKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public ProductImageKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new ProductImageKey(this);
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
					entityTrackingKey = @"ProductImage" 
					+ this.ProductImageID.ToString();
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
				"{6}{5}- ProductImageID: {0}{5}- ProductID: {1}{5}- Name: {2}{5}- ImageFile: {3}{5}- ActiveInd: {4}{5}", 
				this.ProductImageID,
				this.ProductID,
				(this.Name == null) ? string.Empty : this.Name.ToString(),
				(this.ImageFile == null) ? string.Empty : this.ImageFile.ToString(),
				this.ActiveInd,
				Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'ZNodeProductImage' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class ProductImageEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// ProductImageID : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "ZNodeProductImage"</remarks>
			public System.Int32 ProductImageID;
				
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// ProductID : 
		/// </summary>
		public System.Int32		  ProductID = (int)0;
		
		/// <summary>
		/// Name : 
		/// </summary>
		public System.String		  Name = string.Empty;
		
		/// <summary>
		/// ImageFile : 
		/// </summary>
		public System.String		  ImageFile = string.Empty;
		
		/// <summary>
		/// ActiveInd : 
		/// </summary>
		public System.Boolean		  ActiveInd = false;
		#endregion
			
		#endregion Variable Declarations
		
		#region Clone
		public Object Clone()
		{
			ProductImageEntityData _tmp = new ProductImageEntityData();
						
			_tmp.ProductImageID = this.ProductImageID;
			
			_tmp.ProductID = this.ProductID;
			_tmp.Name = this.Name;
			_tmp.ImageFile = this.ImageFile;
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
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("Name",255));
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("ImageFile",255));
		}
   		#endregion
	
	} // End Class
	
	#region ProductImageComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class ProductImageComparer : System.Collections.Generic.IComparer<ProductImage>
	{
		ProductImageColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:ProductImageComparer"/> class.
        /// </summary>
		public ProductImageComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public ProductImageComparer(ProductImageColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="ProductImage"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="ProductImage"/> to compare.</param>
        /// <param name="b">The second <c>ProductImage</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(ProductImage a, ProductImage b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(ProductImage entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(ProductImage a, ProductImage b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public ProductImageColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region ProductImageKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="ProductImage"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class ProductImageKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the ProductImageKey class.
		/// </summary>
		public ProductImageKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the ProductImageKey class.
		/// </summary>
		public ProductImageKey(ProductImageBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.productImageID = entity.ProductImageID;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the ProductImageKey class.
		/// </summary>
		public ProductImageKey(System.Int32 productImageID)
		{
			#region Init Properties

			this.productImageID = productImageID;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private ProductImageBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public ProductImageBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the ProductImageID property
		private System.Int32 productImageID;
		
		/// <summary>
		/// Gets or sets the ProductImageID property.
		/// </summary>
		public System.Int32 ProductImageID
		{
			get { return productImageID; }
			set
			{
				if ( Entity != null )
				{
					Entity.ProductImageID = value;
				}
				
				productImageID = value;
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
				ProductImageID = ( values["ProductImageID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProductImageID"], typeof(System.Int32)) : (int)0;
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

			values.Add("ProductImageID", ProductImageID);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("ProductImageID: {0}{1}",
								ProductImageID,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region ProductImageColumn Enum
	
	/// <summary>
	/// Enumerate the ProductImage columns.
	/// </summary>
	[Serializable]
	public enum ProductImageColumn : int
	{
		/// <summary>
		/// ProductImageID : 
		/// </summary>
		[EnumTextValue("ProductImageID")]
		[ColumnEnum("ProductImageID", typeof(System.Int32), System.Data.DbType.Int32, true, true, false)]
		ProductImageID = 1,
		/// <summary>
		/// ProductID : 
		/// </summary>
		[EnumTextValue("ProductID")]
		[ColumnEnum("ProductID", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		ProductID = 2,
		/// <summary>
		/// Name : 
		/// </summary>
		[EnumTextValue("Name")]
		[ColumnEnum("Name", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 255)]
		Name = 3,
		/// <summary>
		/// ImageFile : 
		/// </summary>
		[EnumTextValue("ImageFile")]
		[ColumnEnum("ImageFile", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 255)]
		ImageFile = 4,
		/// <summary>
		/// ActiveInd : 
		/// </summary>
		[EnumTextValue("ActiveInd")]
		[ColumnEnum("ActiveInd", typeof(System.Boolean), System.Data.DbType.Boolean, false, false, false)]
		ActiveInd = 5
	}//End enum

	#endregion ProductImageColumn Enum

} // end namespace
