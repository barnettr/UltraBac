
Use [ZnodeStorefront]
Go
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePortal_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePortal_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePortal_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodePortal table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePortal_Get_List

AS


				
				SELECT
					[PortalID],
					[DomainName],
					[CompanyName],
					[StoreName],
					[LogoPath],
					[UseSSL],
					[AdminEmail],
					[SalesEmail],
					[CustomerServiceEmail],
					[SalesPhoneNumber],
					[CustomerServicePhoneNumber],
					[ImageNotAvailablePath],
					[MaxCatalogDisplayColumns],
					[MaxCatalogDisplayItems],
					[MaxCatalogItemSmallWidth],
					[MaxCatalogItemMediumWidth],
					[MaxCatalogItemThumbnailWidth],
					[MaxCatalogItemLargeWidth],
					[ActiveInd],
					[SMTPServer],
					[SMTPUserName],
					[SMTPPassword],
					[BottomScriptBlock],
					[UPSUserName],
					[UPSPassword],
					[UPSKey],
					[ShippingOriginZipCode],
					[Theme],
					[ShopByPriceMin],
					[ShopByPriceMax],
					[ShopByPriceIncrement],
					[FedExAccountNumber],
					[FedExMeterNumber],
					[FedExProductionKey],
					[FedExSecurityCode],
					[ShippingOriginStateCode],
					[ShippingOriginCountryCode]
				FROM
					dbo.[ZNodePortal]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePortal_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePortal_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePortal_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodePortal table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePortal_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[PortalID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [PortalID]'
				SET @SQL = @SQL + ', [DomainName]'
				SET @SQL = @SQL + ', [CompanyName]'
				SET @SQL = @SQL + ', [StoreName]'
				SET @SQL = @SQL + ', [LogoPath]'
				SET @SQL = @SQL + ', [UseSSL]'
				SET @SQL = @SQL + ', [AdminEmail]'
				SET @SQL = @SQL + ', [SalesEmail]'
				SET @SQL = @SQL + ', [CustomerServiceEmail]'
				SET @SQL = @SQL + ', [SalesPhoneNumber]'
				SET @SQL = @SQL + ', [CustomerServicePhoneNumber]'
				SET @SQL = @SQL + ', [ImageNotAvailablePath]'
				SET @SQL = @SQL + ', [MaxCatalogDisplayColumns]'
				SET @SQL = @SQL + ', [MaxCatalogDisplayItems]'
				SET @SQL = @SQL + ', [MaxCatalogItemSmallWidth]'
				SET @SQL = @SQL + ', [MaxCatalogItemMediumWidth]'
				SET @SQL = @SQL + ', [MaxCatalogItemThumbnailWidth]'
				SET @SQL = @SQL + ', [MaxCatalogItemLargeWidth]'
				SET @SQL = @SQL + ', [ActiveInd]'
				SET @SQL = @SQL + ', [SMTPServer]'
				SET @SQL = @SQL + ', [SMTPUserName]'
				SET @SQL = @SQL + ', [SMTPPassword]'
				SET @SQL = @SQL + ', [BottomScriptBlock]'
				SET @SQL = @SQL + ', [UPSUserName]'
				SET @SQL = @SQL + ', [UPSPassword]'
				SET @SQL = @SQL + ', [UPSKey]'
				SET @SQL = @SQL + ', [ShippingOriginZipCode]'
				SET @SQL = @SQL + ', [Theme]'
				SET @SQL = @SQL + ', [ShopByPriceMin]'
				SET @SQL = @SQL + ', [ShopByPriceMax]'
				SET @SQL = @SQL + ', [ShopByPriceIncrement]'
				SET @SQL = @SQL + ', [FedExAccountNumber]'
				SET @SQL = @SQL + ', [FedExMeterNumber]'
				SET @SQL = @SQL + ', [FedExProductionKey]'
				SET @SQL = @SQL + ', [FedExSecurityCode]'
				SET @SQL = @SQL + ', [ShippingOriginStateCode]'
				SET @SQL = @SQL + ', [ShippingOriginCountryCode]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodePortal]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [PortalID],'
				SET @SQL = @SQL + ' [DomainName],'
				SET @SQL = @SQL + ' [CompanyName],'
				SET @SQL = @SQL + ' [StoreName],'
				SET @SQL = @SQL + ' [LogoPath],'
				SET @SQL = @SQL + ' [UseSSL],'
				SET @SQL = @SQL + ' [AdminEmail],'
				SET @SQL = @SQL + ' [SalesEmail],'
				SET @SQL = @SQL + ' [CustomerServiceEmail],'
				SET @SQL = @SQL + ' [SalesPhoneNumber],'
				SET @SQL = @SQL + ' [CustomerServicePhoneNumber],'
				SET @SQL = @SQL + ' [ImageNotAvailablePath],'
				SET @SQL = @SQL + ' [MaxCatalogDisplayColumns],'
				SET @SQL = @SQL + ' [MaxCatalogDisplayItems],'
				SET @SQL = @SQL + ' [MaxCatalogItemSmallWidth],'
				SET @SQL = @SQL + ' [MaxCatalogItemMediumWidth],'
				SET @SQL = @SQL + ' [MaxCatalogItemThumbnailWidth],'
				SET @SQL = @SQL + ' [MaxCatalogItemLargeWidth],'
				SET @SQL = @SQL + ' [ActiveInd],'
				SET @SQL = @SQL + ' [SMTPServer],'
				SET @SQL = @SQL + ' [SMTPUserName],'
				SET @SQL = @SQL + ' [SMTPPassword],'
				SET @SQL = @SQL + ' [BottomScriptBlock],'
				SET @SQL = @SQL + ' [UPSUserName],'
				SET @SQL = @SQL + ' [UPSPassword],'
				SET @SQL = @SQL + ' [UPSKey],'
				SET @SQL = @SQL + ' [ShippingOriginZipCode],'
				SET @SQL = @SQL + ' [Theme],'
				SET @SQL = @SQL + ' [ShopByPriceMin],'
				SET @SQL = @SQL + ' [ShopByPriceMax],'
				SET @SQL = @SQL + ' [ShopByPriceIncrement],'
				SET @SQL = @SQL + ' [FedExAccountNumber],'
				SET @SQL = @SQL + ' [FedExMeterNumber],'
				SET @SQL = @SQL + ' [FedExProductionKey],'
				SET @SQL = @SQL + ' [FedExSecurityCode],'
				SET @SQL = @SQL + ' [ShippingOriginStateCode],'
				SET @SQL = @SQL + ' [ShippingOriginCountryCode]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodePortal]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePortal_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePortal_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePortal_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodePortal table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePortal_Insert
(

	@PortalID int    OUTPUT,

	@DomainName nvarchar (MAX)  ,

	@CompanyName nvarchar (MAX)  ,

	@StoreName nvarchar (MAX)  ,

	@LogoPath nvarchar (MAX)  ,

	@UseSSL bit   ,

	@AdminEmail nvarchar (MAX)  ,

	@SalesEmail nvarchar (MAX)  ,

	@CustomerServiceEmail nvarchar (MAX)  ,

	@SalesPhoneNumber nvarchar (MAX)  ,

	@CustomerServicePhoneNumber nvarchar (MAX)  ,

	@ImageNotAvailablePath nvarchar (MAX)  ,

	@MaxCatalogDisplayColumns tinyint   ,

	@MaxCatalogDisplayItems int   ,

	@MaxCatalogItemSmallWidth int   ,

	@MaxCatalogItemMediumWidth int   ,

	@MaxCatalogItemThumbnailWidth int   ,

	@MaxCatalogItemLargeWidth int   ,

	@ActiveInd bit   ,

	@SMTPServer nvarchar (MAX)  ,

	@SMTPUserName nvarchar (MAX)  ,

	@SMTPPassword nvarchar (MAX)  ,

	@BottomScriptBlock ntext   ,

	@UPSUserName nvarchar (MAX)  ,

	@UPSPassword nvarchar (MAX)  ,

	@UPSKey nvarchar (MAX)  ,

	@ShippingOriginZipCode nvarchar (50)  ,

	@Theme nvarchar (MAX)  ,

	@ShopByPriceMin int   ,

	@ShopByPriceMax int   ,

	@ShopByPriceIncrement int   ,

	@FedExAccountNumber nvarchar (MAX)  ,

	@FedExMeterNumber nvarchar (MAX)  ,

	@FedExProductionKey nvarchar (MAX)  ,

	@FedExSecurityCode nvarchar (MAX)  ,

	@ShippingOriginStateCode nvarchar (MAX)  ,

	@ShippingOriginCountryCode nvarchar (MAX)  
)
AS


					
				INSERT INTO dbo.[ZNodePortal]
					(
					[DomainName]
					,[CompanyName]
					,[StoreName]
					,[LogoPath]
					,[UseSSL]
					,[AdminEmail]
					,[SalesEmail]
					,[CustomerServiceEmail]
					,[SalesPhoneNumber]
					,[CustomerServicePhoneNumber]
					,[ImageNotAvailablePath]
					,[MaxCatalogDisplayColumns]
					,[MaxCatalogDisplayItems]
					,[MaxCatalogItemSmallWidth]
					,[MaxCatalogItemMediumWidth]
					,[MaxCatalogItemThumbnailWidth]
					,[MaxCatalogItemLargeWidth]
					,[ActiveInd]
					,[SMTPServer]
					,[SMTPUserName]
					,[SMTPPassword]
					,[BottomScriptBlock]
					,[UPSUserName]
					,[UPSPassword]
					,[UPSKey]
					,[ShippingOriginZipCode]
					,[Theme]
					,[ShopByPriceMin]
					,[ShopByPriceMax]
					,[ShopByPriceIncrement]
					,[FedExAccountNumber]
					,[FedExMeterNumber]
					,[FedExProductionKey]
					,[FedExSecurityCode]
					,[ShippingOriginStateCode]
					,[ShippingOriginCountryCode]
					)
				VALUES
					(
					@DomainName
					,@CompanyName
					,@StoreName
					,@LogoPath
					,@UseSSL
					,@AdminEmail
					,@SalesEmail
					,@CustomerServiceEmail
					,@SalesPhoneNumber
					,@CustomerServicePhoneNumber
					,@ImageNotAvailablePath
					,@MaxCatalogDisplayColumns
					,@MaxCatalogDisplayItems
					,@MaxCatalogItemSmallWidth
					,@MaxCatalogItemMediumWidth
					,@MaxCatalogItemThumbnailWidth
					,@MaxCatalogItemLargeWidth
					,@ActiveInd
					,@SMTPServer
					,@SMTPUserName
					,@SMTPPassword
					,@BottomScriptBlock
					,@UPSUserName
					,@UPSPassword
					,@UPSKey
					,@ShippingOriginZipCode
					,@Theme
					,@ShopByPriceMin
					,@ShopByPriceMax
					,@ShopByPriceIncrement
					,@FedExAccountNumber
					,@FedExMeterNumber
					,@FedExProductionKey
					,@FedExSecurityCode
					,@ShippingOriginStateCode
					,@ShippingOriginCountryCode
					)
				
				-- Get the identity value
				SET @PortalID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePortal_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePortal_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePortal_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodePortal table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePortal_Update
(

	@PortalID int   ,

	@DomainName nvarchar (MAX)  ,

	@CompanyName nvarchar (MAX)  ,

	@StoreName nvarchar (MAX)  ,

	@LogoPath nvarchar (MAX)  ,

	@UseSSL bit   ,

	@AdminEmail nvarchar (MAX)  ,

	@SalesEmail nvarchar (MAX)  ,

	@CustomerServiceEmail nvarchar (MAX)  ,

	@SalesPhoneNumber nvarchar (MAX)  ,

	@CustomerServicePhoneNumber nvarchar (MAX)  ,

	@ImageNotAvailablePath nvarchar (MAX)  ,

	@MaxCatalogDisplayColumns tinyint   ,

	@MaxCatalogDisplayItems int   ,

	@MaxCatalogItemSmallWidth int   ,

	@MaxCatalogItemMediumWidth int   ,

	@MaxCatalogItemThumbnailWidth int   ,

	@MaxCatalogItemLargeWidth int   ,

	@ActiveInd bit   ,

	@SMTPServer nvarchar (MAX)  ,

	@SMTPUserName nvarchar (MAX)  ,

	@SMTPPassword nvarchar (MAX)  ,

	@BottomScriptBlock ntext   ,

	@UPSUserName nvarchar (MAX)  ,

	@UPSPassword nvarchar (MAX)  ,

	@UPSKey nvarchar (MAX)  ,

	@ShippingOriginZipCode nvarchar (50)  ,

	@Theme nvarchar (MAX)  ,

	@ShopByPriceMin int   ,

	@ShopByPriceMax int   ,

	@ShopByPriceIncrement int   ,

	@FedExAccountNumber nvarchar (MAX)  ,

	@FedExMeterNumber nvarchar (MAX)  ,

	@FedExProductionKey nvarchar (MAX)  ,

	@FedExSecurityCode nvarchar (MAX)  ,

	@ShippingOriginStateCode nvarchar (MAX)  ,

	@ShippingOriginCountryCode nvarchar (MAX)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodePortal]
				SET
					[DomainName] = @DomainName
					,[CompanyName] = @CompanyName
					,[StoreName] = @StoreName
					,[LogoPath] = @LogoPath
					,[UseSSL] = @UseSSL
					,[AdminEmail] = @AdminEmail
					,[SalesEmail] = @SalesEmail
					,[CustomerServiceEmail] = @CustomerServiceEmail
					,[SalesPhoneNumber] = @SalesPhoneNumber
					,[CustomerServicePhoneNumber] = @CustomerServicePhoneNumber
					,[ImageNotAvailablePath] = @ImageNotAvailablePath
					,[MaxCatalogDisplayColumns] = @MaxCatalogDisplayColumns
					,[MaxCatalogDisplayItems] = @MaxCatalogDisplayItems
					,[MaxCatalogItemSmallWidth] = @MaxCatalogItemSmallWidth
					,[MaxCatalogItemMediumWidth] = @MaxCatalogItemMediumWidth
					,[MaxCatalogItemThumbnailWidth] = @MaxCatalogItemThumbnailWidth
					,[MaxCatalogItemLargeWidth] = @MaxCatalogItemLargeWidth
					,[ActiveInd] = @ActiveInd
					,[SMTPServer] = @SMTPServer
					,[SMTPUserName] = @SMTPUserName
					,[SMTPPassword] = @SMTPPassword
					,[BottomScriptBlock] = @BottomScriptBlock
					,[UPSUserName] = @UPSUserName
					,[UPSPassword] = @UPSPassword
					,[UPSKey] = @UPSKey
					,[ShippingOriginZipCode] = @ShippingOriginZipCode
					,[Theme] = @Theme
					,[ShopByPriceMin] = @ShopByPriceMin
					,[ShopByPriceMax] = @ShopByPriceMax
					,[ShopByPriceIncrement] = @ShopByPriceIncrement
					,[FedExAccountNumber] = @FedExAccountNumber
					,[FedExMeterNumber] = @FedExMeterNumber
					,[FedExProductionKey] = @FedExProductionKey
					,[FedExSecurityCode] = @FedExSecurityCode
					,[ShippingOriginStateCode] = @ShippingOriginStateCode
					,[ShippingOriginCountryCode] = @ShippingOriginCountryCode
				WHERE
[PortalID] = @PortalID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePortal_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePortal_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePortal_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodePortal table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePortal_Delete
(

	@PortalID int   
)
AS


				DELETE FROM dbo.[ZNodePortal] WITH (ROWLOCK) 
				WHERE
					[PortalID] = @PortalID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePortal_GetByPortalID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePortal_GetByPortalID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePortal_GetByPortalID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodePortal table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePortal_GetByPortalID
(

	@PortalID int   
)
AS


				SELECT
					[PortalID],
					[DomainName],
					[CompanyName],
					[StoreName],
					[LogoPath],
					[UseSSL],
					[AdminEmail],
					[SalesEmail],
					[CustomerServiceEmail],
					[SalesPhoneNumber],
					[CustomerServicePhoneNumber],
					[ImageNotAvailablePath],
					[MaxCatalogDisplayColumns],
					[MaxCatalogDisplayItems],
					[MaxCatalogItemSmallWidth],
					[MaxCatalogItemMediumWidth],
					[MaxCatalogItemThumbnailWidth],
					[MaxCatalogItemLargeWidth],
					[ActiveInd],
					[SMTPServer],
					[SMTPUserName],
					[SMTPPassword],
					[BottomScriptBlock],
					[UPSUserName],
					[UPSPassword],
					[UPSKey],
					[ShippingOriginZipCode],
					[Theme],
					[ShopByPriceMin],
					[ShopByPriceMax],
					[ShopByPriceIncrement],
					[FedExAccountNumber],
					[FedExMeterNumber],
					[FedExProductionKey],
					[FedExSecurityCode],
					[ShippingOriginStateCode],
					[ShippingOriginCountryCode]
				FROM
					dbo.[ZNodePortal]
				WHERE
					[PortalID] = @PortalID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePortal_GetByActiveInd procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePortal_GetByActiveInd') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePortal_GetByActiveInd
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodePortal table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePortal_GetByActiveInd
(

	@ActiveInd bit   
)
AS


				SELECT
					[PortalID],
					[DomainName],
					[CompanyName],
					[StoreName],
					[LogoPath],
					[UseSSL],
					[AdminEmail],
					[SalesEmail],
					[CustomerServiceEmail],
					[SalesPhoneNumber],
					[CustomerServicePhoneNumber],
					[ImageNotAvailablePath],
					[MaxCatalogDisplayColumns],
					[MaxCatalogDisplayItems],
					[MaxCatalogItemSmallWidth],
					[MaxCatalogItemMediumWidth],
					[MaxCatalogItemThumbnailWidth],
					[MaxCatalogItemLargeWidth],
					[ActiveInd],
					[SMTPServer],
					[SMTPUserName],
					[SMTPPassword],
					[BottomScriptBlock],
					[UPSUserName],
					[UPSPassword],
					[UPSKey],
					[ShippingOriginZipCode],
					[Theme],
					[ShopByPriceMin],
					[ShopByPriceMax],
					[ShopByPriceIncrement],
					[FedExAccountNumber],
					[FedExMeterNumber],
					[FedExProductionKey],
					[FedExSecurityCode],
					[ShippingOriginStateCode],
					[ShippingOriginCountryCode]
				FROM
					dbo.[ZNodePortal]
				WHERE
					[ActiveInd] = @ActiveInd
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePortal_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePortal_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePortal_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodePortal table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePortal_Find
(

	@SearchUsingOR bit   = null ,

	@PortalID int   = null ,

	@DomainName nvarchar (MAX)  = null ,

	@CompanyName nvarchar (MAX)  = null ,

	@StoreName nvarchar (MAX)  = null ,

	@LogoPath nvarchar (MAX)  = null ,

	@UseSSL bit   = null ,

	@AdminEmail nvarchar (MAX)  = null ,

	@SalesEmail nvarchar (MAX)  = null ,

	@CustomerServiceEmail nvarchar (MAX)  = null ,

	@SalesPhoneNumber nvarchar (MAX)  = null ,

	@CustomerServicePhoneNumber nvarchar (MAX)  = null ,

	@ImageNotAvailablePath nvarchar (MAX)  = null ,

	@MaxCatalogDisplayColumns tinyint   = null ,

	@MaxCatalogDisplayItems int   = null ,

	@MaxCatalogItemSmallWidth int   = null ,

	@MaxCatalogItemMediumWidth int   = null ,

	@MaxCatalogItemThumbnailWidth int   = null ,

	@MaxCatalogItemLargeWidth int   = null ,

	@ActiveInd bit   = null ,

	@SMTPServer nvarchar (MAX)  = null ,

	@SMTPUserName nvarchar (MAX)  = null ,

	@SMTPPassword nvarchar (MAX)  = null ,

	@BottomScriptBlock ntext   = null ,

	@UPSUserName nvarchar (MAX)  = null ,

	@UPSPassword nvarchar (MAX)  = null ,

	@UPSKey nvarchar (MAX)  = null ,

	@ShippingOriginZipCode nvarchar (50)  = null ,

	@Theme nvarchar (MAX)  = null ,

	@ShopByPriceMin int   = null ,

	@ShopByPriceMax int   = null ,

	@ShopByPriceIncrement int   = null ,

	@FedExAccountNumber nvarchar (MAX)  = null ,

	@FedExMeterNumber nvarchar (MAX)  = null ,

	@FedExProductionKey nvarchar (MAX)  = null ,

	@FedExSecurityCode nvarchar (MAX)  = null ,

	@ShippingOriginStateCode nvarchar (MAX)  = null ,

	@ShippingOriginCountryCode nvarchar (MAX)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [PortalID]
	, [DomainName]
	, [CompanyName]
	, [StoreName]
	, [LogoPath]
	, [UseSSL]
	, [AdminEmail]
	, [SalesEmail]
	, [CustomerServiceEmail]
	, [SalesPhoneNumber]
	, [CustomerServicePhoneNumber]
	, [ImageNotAvailablePath]
	, [MaxCatalogDisplayColumns]
	, [MaxCatalogDisplayItems]
	, [MaxCatalogItemSmallWidth]
	, [MaxCatalogItemMediumWidth]
	, [MaxCatalogItemThumbnailWidth]
	, [MaxCatalogItemLargeWidth]
	, [ActiveInd]
	, [SMTPServer]
	, [SMTPUserName]
	, [SMTPPassword]
	, [BottomScriptBlock]
	, [UPSUserName]
	, [UPSPassword]
	, [UPSKey]
	, [ShippingOriginZipCode]
	, [Theme]
	, [ShopByPriceMin]
	, [ShopByPriceMax]
	, [ShopByPriceIncrement]
	, [FedExAccountNumber]
	, [FedExMeterNumber]
	, [FedExProductionKey]
	, [FedExSecurityCode]
	, [ShippingOriginStateCode]
	, [ShippingOriginCountryCode]
    FROM
	dbo.[ZNodePortal]
    WHERE 
	 ([PortalID] = @PortalID OR @PortalID is null)
	AND ([DomainName] = @DomainName OR @DomainName is null)
	AND ([CompanyName] = @CompanyName OR @CompanyName is null)
	AND ([StoreName] = @StoreName OR @StoreName is null)
	AND ([LogoPath] = @LogoPath OR @LogoPath is null)
	AND ([UseSSL] = @UseSSL OR @UseSSL is null)
	AND ([AdminEmail] = @AdminEmail OR @AdminEmail is null)
	AND ([SalesEmail] = @SalesEmail OR @SalesEmail is null)
	AND ([CustomerServiceEmail] = @CustomerServiceEmail OR @CustomerServiceEmail is null)
	AND ([SalesPhoneNumber] = @SalesPhoneNumber OR @SalesPhoneNumber is null)
	AND ([CustomerServicePhoneNumber] = @CustomerServicePhoneNumber OR @CustomerServicePhoneNumber is null)
	AND ([ImageNotAvailablePath] = @ImageNotAvailablePath OR @ImageNotAvailablePath is null)
	AND ([MaxCatalogDisplayColumns] = @MaxCatalogDisplayColumns OR @MaxCatalogDisplayColumns is null)
	AND ([MaxCatalogDisplayItems] = @MaxCatalogDisplayItems OR @MaxCatalogDisplayItems is null)
	AND ([MaxCatalogItemSmallWidth] = @MaxCatalogItemSmallWidth OR @MaxCatalogItemSmallWidth is null)
	AND ([MaxCatalogItemMediumWidth] = @MaxCatalogItemMediumWidth OR @MaxCatalogItemMediumWidth is null)
	AND ([MaxCatalogItemThumbnailWidth] = @MaxCatalogItemThumbnailWidth OR @MaxCatalogItemThumbnailWidth is null)
	AND ([MaxCatalogItemLargeWidth] = @MaxCatalogItemLargeWidth OR @MaxCatalogItemLargeWidth is null)
	AND ([ActiveInd] = @ActiveInd OR @ActiveInd is null)
	AND ([SMTPServer] = @SMTPServer OR @SMTPServer is null)
	AND ([SMTPUserName] = @SMTPUserName OR @SMTPUserName is null)
	AND ([SMTPPassword] = @SMTPPassword OR @SMTPPassword is null)
	AND ([UPSUserName] = @UPSUserName OR @UPSUserName is null)
	AND ([UPSPassword] = @UPSPassword OR @UPSPassword is null)
	AND ([UPSKey] = @UPSKey OR @UPSKey is null)
	AND ([ShippingOriginZipCode] = @ShippingOriginZipCode OR @ShippingOriginZipCode is null)
	AND ([Theme] = @Theme OR @Theme is null)
	AND ([ShopByPriceMin] = @ShopByPriceMin OR @ShopByPriceMin is null)
	AND ([ShopByPriceMax] = @ShopByPriceMax OR @ShopByPriceMax is null)
	AND ([ShopByPriceIncrement] = @ShopByPriceIncrement OR @ShopByPriceIncrement is null)
	AND ([FedExAccountNumber] = @FedExAccountNumber OR @FedExAccountNumber is null)
	AND ([FedExMeterNumber] = @FedExMeterNumber OR @FedExMeterNumber is null)
	AND ([FedExProductionKey] = @FedExProductionKey OR @FedExProductionKey is null)
	AND ([FedExSecurityCode] = @FedExSecurityCode OR @FedExSecurityCode is null)
	AND ([ShippingOriginStateCode] = @ShippingOriginStateCode OR @ShippingOriginStateCode is null)
	AND ([ShippingOriginCountryCode] = @ShippingOriginCountryCode OR @ShippingOriginCountryCode is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [PortalID]
	, [DomainName]
	, [CompanyName]
	, [StoreName]
	, [LogoPath]
	, [UseSSL]
	, [AdminEmail]
	, [SalesEmail]
	, [CustomerServiceEmail]
	, [SalesPhoneNumber]
	, [CustomerServicePhoneNumber]
	, [ImageNotAvailablePath]
	, [MaxCatalogDisplayColumns]
	, [MaxCatalogDisplayItems]
	, [MaxCatalogItemSmallWidth]
	, [MaxCatalogItemMediumWidth]
	, [MaxCatalogItemThumbnailWidth]
	, [MaxCatalogItemLargeWidth]
	, [ActiveInd]
	, [SMTPServer]
	, [SMTPUserName]
	, [SMTPPassword]
	, [BottomScriptBlock]
	, [UPSUserName]
	, [UPSPassword]
	, [UPSKey]
	, [ShippingOriginZipCode]
	, [Theme]
	, [ShopByPriceMin]
	, [ShopByPriceMax]
	, [ShopByPriceIncrement]
	, [FedExAccountNumber]
	, [FedExMeterNumber]
	, [FedExProductionKey]
	, [FedExSecurityCode]
	, [ShippingOriginStateCode]
	, [ShippingOriginCountryCode]
    FROM
	dbo.[ZNodePortal]
    WHERE 
	 ([PortalID] = @PortalID AND @PortalID is not null)
	OR ([DomainName] = @DomainName AND @DomainName is not null)
	OR ([CompanyName] = @CompanyName AND @CompanyName is not null)
	OR ([StoreName] = @StoreName AND @StoreName is not null)
	OR ([LogoPath] = @LogoPath AND @LogoPath is not null)
	OR ([UseSSL] = @UseSSL AND @UseSSL is not null)
	OR ([AdminEmail] = @AdminEmail AND @AdminEmail is not null)
	OR ([SalesEmail] = @SalesEmail AND @SalesEmail is not null)
	OR ([CustomerServiceEmail] = @CustomerServiceEmail AND @CustomerServiceEmail is not null)
	OR ([SalesPhoneNumber] = @SalesPhoneNumber AND @SalesPhoneNumber is not null)
	OR ([CustomerServicePhoneNumber] = @CustomerServicePhoneNumber AND @CustomerServicePhoneNumber is not null)
	OR ([ImageNotAvailablePath] = @ImageNotAvailablePath AND @ImageNotAvailablePath is not null)
	OR ([MaxCatalogDisplayColumns] = @MaxCatalogDisplayColumns AND @MaxCatalogDisplayColumns is not null)
	OR ([MaxCatalogDisplayItems] = @MaxCatalogDisplayItems AND @MaxCatalogDisplayItems is not null)
	OR ([MaxCatalogItemSmallWidth] = @MaxCatalogItemSmallWidth AND @MaxCatalogItemSmallWidth is not null)
	OR ([MaxCatalogItemMediumWidth] = @MaxCatalogItemMediumWidth AND @MaxCatalogItemMediumWidth is not null)
	OR ([MaxCatalogItemThumbnailWidth] = @MaxCatalogItemThumbnailWidth AND @MaxCatalogItemThumbnailWidth is not null)
	OR ([MaxCatalogItemLargeWidth] = @MaxCatalogItemLargeWidth AND @MaxCatalogItemLargeWidth is not null)
	OR ([ActiveInd] = @ActiveInd AND @ActiveInd is not null)
	OR ([SMTPServer] = @SMTPServer AND @SMTPServer is not null)
	OR ([SMTPUserName] = @SMTPUserName AND @SMTPUserName is not null)
	OR ([SMTPPassword] = @SMTPPassword AND @SMTPPassword is not null)
	OR ([UPSUserName] = @UPSUserName AND @UPSUserName is not null)
	OR ([UPSPassword] = @UPSPassword AND @UPSPassword is not null)
	OR ([UPSKey] = @UPSKey AND @UPSKey is not null)
	OR ([ShippingOriginZipCode] = @ShippingOriginZipCode AND @ShippingOriginZipCode is not null)
	OR ([Theme] = @Theme AND @Theme is not null)
	OR ([ShopByPriceMin] = @ShopByPriceMin AND @ShopByPriceMin is not null)
	OR ([ShopByPriceMax] = @ShopByPriceMax AND @ShopByPriceMax is not null)
	OR ([ShopByPriceIncrement] = @ShopByPriceIncrement AND @ShopByPriceIncrement is not null)
	OR ([FedExAccountNumber] = @FedExAccountNumber AND @FedExAccountNumber is not null)
	OR ([FedExMeterNumber] = @FedExMeterNumber AND @FedExMeterNumber is not null)
	OR ([FedExProductionKey] = @FedExProductionKey AND @FedExProductionKey is not null)
	OR ([FedExSecurityCode] = @FedExSecurityCode AND @FedExSecurityCode is not null)
	OR ([ShippingOriginStateCode] = @ShippingOriginStateCode AND @ShippingOriginStateCode is not null)
	OR ([ShippingOriginCountryCode] = @ShippingOriginCountryCode AND @ShippingOriginCountryCode is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeProductType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductType_Get_List

AS


				
				SELECT
					[ProductTypeId],
					[PortalId],
					[Name],
					[Description],
					[DisplayOrder]
				FROM
					dbo.[ZNodeProductType]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeProductType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductType_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ProductTypeId]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ProductTypeId]'
				SET @SQL = @SQL + ', [PortalId]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [DisplayOrder]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ProductTypeId],'
				SET @SQL = @SQL + ' [PortalId],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [DisplayOrder]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductType_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeProductType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductType_Insert
(

	@ProductTypeId int    OUTPUT,

	@PortalId int   ,

	@Name varchar (50)  ,

	@Description varchar (255)  ,

	@DisplayOrder int   
)
AS


					
				INSERT INTO dbo.[ZNodeProductType]
					(
					[PortalId]
					,[Name]
					,[Description]
					,[DisplayOrder]
					)
				VALUES
					(
					@PortalId
					,@Name
					,@Description
					,@DisplayOrder
					)
				
				-- Get the identity value
				SET @ProductTypeId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductType_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeProductType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductType_Update
(

	@ProductTypeId int   ,

	@PortalId int   ,

	@Name varchar (50)  ,

	@Description varchar (255)  ,

	@DisplayOrder int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeProductType]
				SET
					[PortalId] = @PortalId
					,[Name] = @Name
					,[Description] = @Description
					,[DisplayOrder] = @DisplayOrder
				WHERE
[ProductTypeId] = @ProductTypeId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductType_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeProductType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductType_Delete
(

	@ProductTypeId int   
)
AS


				DELETE FROM dbo.[ZNodeProductType] WITH (ROWLOCK) 
				WHERE
					[ProductTypeId] = @ProductTypeId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductType_GetByPortalId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductType_GetByPortalId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductType_GetByPortalId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductType table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductType_GetByPortalId
(

	@PortalId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ProductTypeId],
					[PortalId],
					[Name],
					[Description],
					[DisplayOrder]
				FROM
					dbo.[ZNodeProductType]
				WHERE
					[PortalId] = @PortalId
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductType_GetByProductTypeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductType_GetByProductTypeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductType_GetByProductTypeId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductType_GetByProductTypeId
(

	@ProductTypeId int   
)
AS


				SELECT
					[ProductTypeId],
					[PortalId],
					[Name],
					[Description],
					[DisplayOrder]
				FROM
					dbo.[ZNodeProductType]
				WHERE
					[ProductTypeId] = @ProductTypeId
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductType_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeProductType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductType_Find
(

	@SearchUsingOR bit   = null ,

	@ProductTypeId int   = null ,

	@PortalId int   = null ,

	@Name varchar (50)  = null ,

	@Description varchar (255)  = null ,

	@DisplayOrder int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ProductTypeId]
	, [PortalId]
	, [Name]
	, [Description]
	, [DisplayOrder]
    FROM
	dbo.[ZNodeProductType]
    WHERE 
	 ([ProductTypeId] = @ProductTypeId OR @ProductTypeId is null)
	AND ([PortalId] = @PortalId OR @PortalId is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([Description] = @Description OR @Description is null)
	AND ([DisplayOrder] = @DisplayOrder OR @DisplayOrder is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ProductTypeId]
	, [PortalId]
	, [Name]
	, [Description]
	, [DisplayOrder]
    FROM
	dbo.[ZNodeProductType]
    WHERE 
	 ([ProductTypeId] = @ProductTypeId AND @ProductTypeId is not null)
	OR ([PortalId] = @PortalId AND @PortalId is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([DisplayOrder] = @DisplayOrder AND @DisplayOrder is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCrossSell_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCrossSell_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeProductCrossSell table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_Get_List

AS


				
				SELECT
					[ProductCrossSellTypeId],
					[PortalId],
					[ProductId],
					[RelatedProductId],
					[DisplayOrder]
				FROM
					dbo.[ZNodeProductCrossSell]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCrossSell_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCrossSell_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeProductCrossSell table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ProductCrossSellTypeId]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ProductCrossSellTypeId]'
				SET @SQL = @SQL + ', [PortalId]'
				SET @SQL = @SQL + ', [ProductId]'
				SET @SQL = @SQL + ', [RelatedProductId]'
				SET @SQL = @SQL + ', [DisplayOrder]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductCrossSell]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ProductCrossSellTypeId],'
				SET @SQL = @SQL + ' [PortalId],'
				SET @SQL = @SQL + ' [ProductId],'
				SET @SQL = @SQL + ' [RelatedProductId],'
				SET @SQL = @SQL + ' [DisplayOrder]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductCrossSell]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCrossSell_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCrossSell_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeProductCrossSell table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_Insert
(

	@ProductCrossSellTypeId int    OUTPUT,

	@PortalId int   ,

	@ProductId int   ,

	@RelatedProductId int   ,

	@DisplayOrder int   
)
AS


					
				INSERT INTO dbo.[ZNodeProductCrossSell]
					(
					[PortalId]
					,[ProductId]
					,[RelatedProductId]
					,[DisplayOrder]
					)
				VALUES
					(
					@PortalId
					,@ProductId
					,@RelatedProductId
					,@DisplayOrder
					)
				
				-- Get the identity value
				SET @ProductCrossSellTypeId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCrossSell_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCrossSell_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeProductCrossSell table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_Update
(

	@ProductCrossSellTypeId int   ,

	@PortalId int   ,

	@ProductId int   ,

	@RelatedProductId int   ,

	@DisplayOrder int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeProductCrossSell]
				SET
					[PortalId] = @PortalId
					,[ProductId] = @ProductId
					,[RelatedProductId] = @RelatedProductId
					,[DisplayOrder] = @DisplayOrder
				WHERE
[ProductCrossSellTypeId] = @ProductCrossSellTypeId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCrossSell_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCrossSell_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeProductCrossSell table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_Delete
(

	@ProductCrossSellTypeId int   
)
AS


				DELETE FROM dbo.[ZNodeProductCrossSell] WITH (ROWLOCK) 
				WHERE
					[ProductCrossSellTypeId] = @ProductCrossSellTypeId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCrossSell_GetByProductId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCrossSell_GetByProductId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_GetByProductId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductCrossSell table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_GetByProductId
(

	@ProductId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ProductCrossSellTypeId],
					[PortalId],
					[ProductId],
					[RelatedProductId],
					[DisplayOrder]
				FROM
					dbo.[ZNodeProductCrossSell]
				WHERE
					[ProductId] = @ProductId
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCrossSell_GetByProductCrossSellTypeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCrossSell_GetByProductCrossSellTypeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_GetByProductCrossSellTypeId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductCrossSell table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_GetByProductCrossSellTypeId
(

	@ProductCrossSellTypeId int   
)
AS


				SELECT
					[ProductCrossSellTypeId],
					[PortalId],
					[ProductId],
					[RelatedProductId],
					[DisplayOrder]
				FROM
					dbo.[ZNodeProductCrossSell]
				WHERE
					[ProductCrossSellTypeId] = @ProductCrossSellTypeId
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCrossSell_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCrossSell_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeProductCrossSell table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCrossSell_Find
(

	@SearchUsingOR bit   = null ,

	@ProductCrossSellTypeId int   = null ,

	@PortalId int   = null ,

	@ProductId int   = null ,

	@RelatedProductId int   = null ,

	@DisplayOrder int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ProductCrossSellTypeId]
	, [PortalId]
	, [ProductId]
	, [RelatedProductId]
	, [DisplayOrder]
    FROM
	dbo.[ZNodeProductCrossSell]
    WHERE 
	 ([ProductCrossSellTypeId] = @ProductCrossSellTypeId OR @ProductCrossSellTypeId is null)
	AND ([PortalId] = @PortalId OR @PortalId is null)
	AND ([ProductId] = @ProductId OR @ProductId is null)
	AND ([RelatedProductId] = @RelatedProductId OR @RelatedProductId is null)
	AND ([DisplayOrder] = @DisplayOrder OR @DisplayOrder is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ProductCrossSellTypeId]
	, [PortalId]
	, [ProductId]
	, [RelatedProductId]
	, [DisplayOrder]
    FROM
	dbo.[ZNodeProductCrossSell]
    WHERE 
	 ([ProductCrossSellTypeId] = @ProductCrossSellTypeId AND @ProductCrossSellTypeId is not null)
	OR ([PortalId] = @PortalId AND @PortalId is not null)
	OR ([ProductId] = @ProductId AND @ProductId is not null)
	OR ([RelatedProductId] = @RelatedProductId AND @RelatedProductId is not null)
	OR ([DisplayOrder] = @DisplayOrder AND @DisplayOrder is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductHighlight_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductHighlight_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeProductHighlight table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_Get_List

AS


				
				SELECT
					[ProductHighlightID],
					[ProductID],
					[HighlightID],
					[DisplayOrder]
				FROM
					dbo.[ZNodeProductHighlight]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductHighlight_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductHighlight_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeProductHighlight table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ProductHighlightID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ProductHighlightID]'
				SET @SQL = @SQL + ', [ProductID]'
				SET @SQL = @SQL + ', [HighlightID]'
				SET @SQL = @SQL + ', [DisplayOrder]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductHighlight]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ProductHighlightID],'
				SET @SQL = @SQL + ' [ProductID],'
				SET @SQL = @SQL + ' [HighlightID],'
				SET @SQL = @SQL + ' [DisplayOrder]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductHighlight]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductHighlight_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductHighlight_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeProductHighlight table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_Insert
(

	@ProductHighlightID int   ,

	@ProductID int   ,

	@HighlightID int   ,

	@DisplayOrder int   
)
AS


					
				INSERT INTO dbo.[ZNodeProductHighlight]
					(
					[ProductHighlightID]
					,[ProductID]
					,[HighlightID]
					,[DisplayOrder]
					)
				VALUES
					(
					@ProductHighlightID
					,@ProductID
					,@HighlightID
					,@DisplayOrder
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductHighlight_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductHighlight_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeProductHighlight table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_Update
(

	@ProductHighlightID int   ,

	@OriginalProductHighlightID int   ,

	@ProductID int   ,

	@HighlightID int   ,

	@DisplayOrder int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeProductHighlight]
				SET
					[ProductHighlightID] = @ProductHighlightID
					,[ProductID] = @ProductID
					,[HighlightID] = @HighlightID
					,[DisplayOrder] = @DisplayOrder
				WHERE
[ProductHighlightID] = @OriginalProductHighlightID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductHighlight_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductHighlight_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeProductHighlight table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_Delete
(

	@ProductHighlightID int   
)
AS


				DELETE FROM dbo.[ZNodeProductHighlight] WITH (ROWLOCK) 
				WHERE
					[ProductHighlightID] = @ProductHighlightID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductHighlight_GetByHighlightID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductHighlight_GetByHighlightID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_GetByHighlightID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductHighlight table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_GetByHighlightID
(

	@HighlightID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ProductHighlightID],
					[ProductID],
					[HighlightID],
					[DisplayOrder]
				FROM
					dbo.[ZNodeProductHighlight]
				WHERE
					[HighlightID] = @HighlightID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductHighlight_GetByProductID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductHighlight_GetByProductID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_GetByProductID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductHighlight table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_GetByProductID
(

	@ProductID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ProductHighlightID],
					[ProductID],
					[HighlightID],
					[DisplayOrder]
				FROM
					dbo.[ZNodeProductHighlight]
				WHERE
					[ProductID] = @ProductID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductHighlight_GetByProductHighlightID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductHighlight_GetByProductHighlightID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_GetByProductHighlightID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductHighlight table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_GetByProductHighlightID
(

	@ProductHighlightID int   
)
AS


				SELECT
					[ProductHighlightID],
					[ProductID],
					[HighlightID],
					[DisplayOrder]
				FROM
					dbo.[ZNodeProductHighlight]
				WHERE
					[ProductHighlightID] = @ProductHighlightID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductHighlight_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductHighlight_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeProductHighlight table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductHighlight_Find
(

	@SearchUsingOR bit   = null ,

	@ProductHighlightID int   = null ,

	@ProductID int   = null ,

	@HighlightID int   = null ,

	@DisplayOrder int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ProductHighlightID]
	, [ProductID]
	, [HighlightID]
	, [DisplayOrder]
    FROM
	dbo.[ZNodeProductHighlight]
    WHERE 
	 ([ProductHighlightID] = @ProductHighlightID OR @ProductHighlightID is null)
	AND ([ProductID] = @ProductID OR @ProductID is null)
	AND ([HighlightID] = @HighlightID OR @HighlightID is null)
	AND ([DisplayOrder] = @DisplayOrder OR @DisplayOrder is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ProductHighlightID]
	, [ProductID]
	, [HighlightID]
	, [DisplayOrder]
    FROM
	dbo.[ZNodeProductHighlight]
    WHERE 
	 ([ProductHighlightID] = @ProductHighlightID AND @ProductHighlightID is not null)
	OR ([ProductID] = @ProductID AND @ProductID is not null)
	OR ([HighlightID] = @HighlightID AND @HighlightID is not null)
	OR ([DisplayOrder] = @DisplayOrder AND @DisplayOrder is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductImage_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductImage_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeProductImage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_Get_List

AS


				
				SELECT
					[ProductImageID],
					[ProductID],
					[Name],
					[ImageFile],
					[ActiveInd]
				FROM
					dbo.[ZNodeProductImage]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductImage_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductImage_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeProductImage table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ProductImageID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ProductImageID]'
				SET @SQL = @SQL + ', [ProductID]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [ImageFile]'
				SET @SQL = @SQL + ', [ActiveInd]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductImage]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ProductImageID],'
				SET @SQL = @SQL + ' [ProductID],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [ImageFile],'
				SET @SQL = @SQL + ' [ActiveInd]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductImage]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductImage_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductImage_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeProductImage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_Insert
(

	@ProductImageID int    OUTPUT,

	@ProductID int   ,

	@Name varchar (255)  ,

	@ImageFile varchar (255)  ,

	@ActiveInd bit   
)
AS


					
				INSERT INTO dbo.[ZNodeProductImage]
					(
					[ProductID]
					,[Name]
					,[ImageFile]
					,[ActiveInd]
					)
				VALUES
					(
					@ProductID
					,@Name
					,@ImageFile
					,@ActiveInd
					)
				
				-- Get the identity value
				SET @ProductImageID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductImage_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductImage_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeProductImage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_Update
(

	@ProductImageID int   ,

	@ProductID int   ,

	@Name varchar (255)  ,

	@ImageFile varchar (255)  ,

	@ActiveInd bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeProductImage]
				SET
					[ProductID] = @ProductID
					,[Name] = @Name
					,[ImageFile] = @ImageFile
					,[ActiveInd] = @ActiveInd
				WHERE
[ProductImageID] = @ProductImageID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductImage_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductImage_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeProductImage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_Delete
(

	@ProductImageID int   
)
AS


				DELETE FROM dbo.[ZNodeProductImage] WITH (ROWLOCK) 
				WHERE
					[ProductImageID] = @ProductImageID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductImage_GetByProductID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductImage_GetByProductID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_GetByProductID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductImage table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_GetByProductID
(

	@ProductID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ProductImageID],
					[ProductID],
					[Name],
					[ImageFile],
					[ActiveInd]
				FROM
					dbo.[ZNodeProductImage]
				WHERE
					[ProductID] = @ProductID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductImage_GetByProductImageID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductImage_GetByProductImageID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_GetByProductImageID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductImage table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_GetByProductImageID
(

	@ProductImageID int   
)
AS


				SELECT
					[ProductImageID],
					[ProductID],
					[Name],
					[ImageFile],
					[ActiveInd]
				FROM
					dbo.[ZNodeProductImage]
				WHERE
					[ProductImageID] = @ProductImageID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductImage_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductImage_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeProductImage table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductImage_Find
(

	@SearchUsingOR bit   = null ,

	@ProductImageID int   = null ,

	@ProductID int   = null ,

	@Name varchar (255)  = null ,

	@ImageFile varchar (255)  = null ,

	@ActiveInd bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ProductImageID]
	, [ProductID]
	, [Name]
	, [ImageFile]
	, [ActiveInd]
    FROM
	dbo.[ZNodeProductImage]
    WHERE 
	 ([ProductImageID] = @ProductImageID OR @ProductImageID is null)
	AND ([ProductID] = @ProductID OR @ProductID is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([ImageFile] = @ImageFile OR @ImageFile is null)
	AND ([ActiveInd] = @ActiveInd OR @ActiveInd is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ProductImageID]
	, [ProductID]
	, [Name]
	, [ImageFile]
	, [ActiveInd]
    FROM
	dbo.[ZNodeProductImage]
    WHERE 
	 ([ProductImageID] = @ProductImageID AND @ProductImageID is not null)
	OR ([ProductID] = @ProductID AND @ProductID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([ImageFile] = @ImageFile AND @ImageFile is not null)
	OR ([ActiveInd] = @ActiveInd AND @ActiveInd is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductTypeAttribute_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductTypeAttribute_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeProductTypeAttribute table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_Get_List

AS


				
				SELECT
					[ProductAttributeTypeID],
					[ProductTypeId],
					[AttributeTypeId]
				FROM
					dbo.[ZNodeProductTypeAttribute]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductTypeAttribute_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductTypeAttribute_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeProductTypeAttribute table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ProductAttributeTypeID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ProductAttributeTypeID]'
				SET @SQL = @SQL + ', [ProductTypeId]'
				SET @SQL = @SQL + ', [AttributeTypeId]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductTypeAttribute]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ProductAttributeTypeID],'
				SET @SQL = @SQL + ' [ProductTypeId],'
				SET @SQL = @SQL + ' [AttributeTypeId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductTypeAttribute]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductTypeAttribute_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductTypeAttribute_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeProductTypeAttribute table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_Insert
(

	@ProductAttributeTypeID int    OUTPUT,

	@ProductTypeId int   ,

	@AttributeTypeId int   
)
AS


					
				INSERT INTO dbo.[ZNodeProductTypeAttribute]
					(
					[ProductTypeId]
					,[AttributeTypeId]
					)
				VALUES
					(
					@ProductTypeId
					,@AttributeTypeId
					)
				
				-- Get the identity value
				SET @ProductAttributeTypeID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductTypeAttribute_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductTypeAttribute_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeProductTypeAttribute table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_Update
(

	@ProductAttributeTypeID int   ,

	@ProductTypeId int   ,

	@AttributeTypeId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeProductTypeAttribute]
				SET
					[ProductTypeId] = @ProductTypeId
					,[AttributeTypeId] = @AttributeTypeId
				WHERE
[ProductAttributeTypeID] = @ProductAttributeTypeID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductTypeAttribute_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductTypeAttribute_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeProductTypeAttribute table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_Delete
(

	@ProductAttributeTypeID int   
)
AS


				DELETE FROM dbo.[ZNodeProductTypeAttribute] WITH (ROWLOCK) 
				WHERE
					[ProductAttributeTypeID] = @ProductAttributeTypeID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductTypeAttribute_GetByProductTypeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductTypeAttribute_GetByProductTypeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_GetByProductTypeId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductTypeAttribute table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_GetByProductTypeId
(

	@ProductTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ProductAttributeTypeID],
					[ProductTypeId],
					[AttributeTypeId]
				FROM
					dbo.[ZNodeProductTypeAttribute]
				WHERE
					[ProductTypeId] = @ProductTypeId
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductTypeAttribute_GetByProductAttributeTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductTypeAttribute_GetByProductAttributeTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_GetByProductAttributeTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductTypeAttribute table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_GetByProductAttributeTypeID
(

	@ProductAttributeTypeID int   
)
AS


				SELECT
					[ProductAttributeTypeID],
					[ProductTypeId],
					[AttributeTypeId]
				FROM
					dbo.[ZNodeProductTypeAttribute]
				WHERE
					[ProductAttributeTypeID] = @ProductAttributeTypeID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductTypeAttribute_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductTypeAttribute_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeProductTypeAttribute table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductTypeAttribute_Find
(

	@SearchUsingOR bit   = null ,

	@ProductAttributeTypeID int   = null ,

	@ProductTypeId int   = null ,

	@AttributeTypeId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ProductAttributeTypeID]
	, [ProductTypeId]
	, [AttributeTypeId]
    FROM
	dbo.[ZNodeProductTypeAttribute]
    WHERE 
	 ([ProductAttributeTypeID] = @ProductAttributeTypeID OR @ProductAttributeTypeID is null)
	AND ([ProductTypeId] = @ProductTypeId OR @ProductTypeId is null)
	AND ([AttributeTypeId] = @AttributeTypeId OR @AttributeTypeId is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ProductAttributeTypeID]
	, [ProductTypeId]
	, [AttributeTypeId]
    FROM
	dbo.[ZNodeProductTypeAttribute]
    WHERE 
	 ([ProductAttributeTypeID] = @ProductAttributeTypeID AND @ProductAttributeTypeID is not null)
	OR ([ProductTypeId] = @ProductTypeId AND @ProductTypeId is not null)
	OR ([AttributeTypeId] = @AttributeTypeId AND @AttributeTypeId is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodePaymentType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_Get_List

AS


				
				SELECT
					[PaymentTypeID],
					[Name],
					[Description],
					[ActiveInd]
				FROM
					dbo.[ZNodePaymentType]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodePaymentType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[PaymentTypeID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [PaymentTypeID]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [ActiveInd]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodePaymentType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [PaymentTypeID],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [ActiveInd]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodePaymentType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodePaymentType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_Insert
(

	@PaymentTypeID int    OUTPUT,

	@Name varchar (50)  ,

	@Description text   ,

	@ActiveInd bit   
)
AS


					
				INSERT INTO dbo.[ZNodePaymentType]
					(
					[Name]
					,[Description]
					,[ActiveInd]
					)
				VALUES
					(
					@Name
					,@Description
					,@ActiveInd
					)
				
				-- Get the identity value
				SET @PaymentTypeID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodePaymentType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_Update
(

	@PaymentTypeID int   ,

	@Name varchar (50)  ,

	@Description text   ,

	@ActiveInd bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodePaymentType]
				SET
					[Name] = @Name
					,[Description] = @Description
					,[ActiveInd] = @ActiveInd
				WHERE
[PaymentTypeID] = @PaymentTypeID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodePaymentType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_Delete
(

	@PaymentTypeID int   
)
AS


				DELETE FROM dbo.[ZNodePaymentType] WITH (ROWLOCK) 
				WHERE
					[PaymentTypeID] = @PaymentTypeID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentType_GetByPaymentTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentType_GetByPaymentTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_GetByPaymentTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodePaymentType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_GetByPaymentTypeID
(

	@PaymentTypeID int   
)
AS


				SELECT
					[PaymentTypeID],
					[Name],
					[Description],
					[ActiveInd]
				FROM
					dbo.[ZNodePaymentType]
				WHERE
					[PaymentTypeID] = @PaymentTypeID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentType_GetByName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentType_GetByName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_GetByName
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodePaymentType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_GetByName
(

	@Name varchar (50)  
)
AS


				SELECT
					[PaymentTypeID],
					[Name],
					[Description],
					[ActiveInd]
				FROM
					dbo.[ZNodePaymentType]
				WHERE
					[Name] = @Name
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodePaymentType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentType_Find
(

	@SearchUsingOR bit   = null ,

	@PaymentTypeID int   = null ,

	@Name varchar (50)  = null ,

	@Description text   = null ,

	@ActiveInd bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [PaymentTypeID]
	, [Name]
	, [Description]
	, [ActiveInd]
    FROM
	dbo.[ZNodePaymentType]
    WHERE 
	 ([PaymentTypeID] = @PaymentTypeID OR @PaymentTypeID is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([ActiveInd] = @ActiveInd OR @ActiveInd is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [PaymentTypeID]
	, [Name]
	, [Description]
	, [ActiveInd]
    FROM
	dbo.[ZNodePaymentType]
    WHERE 
	 ([PaymentTypeID] = @PaymentTypeID AND @PaymentTypeID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([ActiveInd] = @ActiveInd AND @ActiveInd is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProduct_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProduct_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProduct_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeProduct table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProduct_Get_List

AS


				
				SELECT
					[ProductID],
					[PortalID],
					[Name],
					[ShortDescription],
					[Description],
					[FeaturesDesc],
					[ProductNum],
					[ProductTypeID],
					[RetailPrice],
					[WholesalePrice],
					[SalePrice],
					[ImageFile],
					[Weight],
					[ActiveInd],
					[DisplayOrder],
					[CallForPricing],
					[HomepageSpecial],
					[CategorySpecial],
					[InventoryDisplay],
					[Keywords],
					[ManufacturerID],
					[AdditionalInfoLink],
					[AdditionalInfoLinkLabel],
					[ShippingRuleTypeID],
					[SEOTitle],
					[SEOKeywords],
					[SEODescription],
					[Custom1],
					[Custom2],
					[Custom3],
					[ShipEachItemSeparately],
					[SKU],
					[QuantityOnHand],
					[AllowBackOrder],
					[BackOrderMsg],
					[DropShipInd],
					[DropShipEmailID],
					[Specifications],
					[AdditionalInformation],
					[InStockMsg],
					[OutOfStockMsg],
					[TrackInventoryInd]
				FROM
					dbo.[ZNodeProduct]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProduct_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProduct_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeProduct table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ProductID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ProductID]'
				SET @SQL = @SQL + ', [PortalID]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [ShortDescription]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [FeaturesDesc]'
				SET @SQL = @SQL + ', [ProductNum]'
				SET @SQL = @SQL + ', [ProductTypeID]'
				SET @SQL = @SQL + ', [RetailPrice]'
				SET @SQL = @SQL + ', [WholesalePrice]'
				SET @SQL = @SQL + ', [SalePrice]'
				SET @SQL = @SQL + ', [ImageFile]'
				SET @SQL = @SQL + ', [Weight]'
				SET @SQL = @SQL + ', [ActiveInd]'
				SET @SQL = @SQL + ', [DisplayOrder]'
				SET @SQL = @SQL + ', [CallForPricing]'
				SET @SQL = @SQL + ', [HomepageSpecial]'
				SET @SQL = @SQL + ', [CategorySpecial]'
				SET @SQL = @SQL + ', [InventoryDisplay]'
				SET @SQL = @SQL + ', [Keywords]'
				SET @SQL = @SQL + ', [ManufacturerID]'
				SET @SQL = @SQL + ', [AdditionalInfoLink]'
				SET @SQL = @SQL + ', [AdditionalInfoLinkLabel]'
				SET @SQL = @SQL + ', [ShippingRuleTypeID]'
				SET @SQL = @SQL + ', [SEOTitle]'
				SET @SQL = @SQL + ', [SEOKeywords]'
				SET @SQL = @SQL + ', [SEODescription]'
				SET @SQL = @SQL + ', [Custom1]'
				SET @SQL = @SQL + ', [Custom2]'
				SET @SQL = @SQL + ', [Custom3]'
				SET @SQL = @SQL + ', [ShipEachItemSeparately]'
				SET @SQL = @SQL + ', [SKU]'
				SET @SQL = @SQL + ', [QuantityOnHand]'
				SET @SQL = @SQL + ', [AllowBackOrder]'
				SET @SQL = @SQL + ', [BackOrderMsg]'
				SET @SQL = @SQL + ', [DropShipInd]'
				SET @SQL = @SQL + ', [DropShipEmailID]'
				SET @SQL = @SQL + ', [Specifications]'
				SET @SQL = @SQL + ', [AdditionalInformation]'
				SET @SQL = @SQL + ', [InStockMsg]'
				SET @SQL = @SQL + ', [OutOfStockMsg]'
				SET @SQL = @SQL + ', [TrackInventoryInd]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProduct]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ProductID],'
				SET @SQL = @SQL + ' [PortalID],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [ShortDescription],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [FeaturesDesc],'
				SET @SQL = @SQL + ' [ProductNum],'
				SET @SQL = @SQL + ' [ProductTypeID],'
				SET @SQL = @SQL + ' [RetailPrice],'
				SET @SQL = @SQL + ' [WholesalePrice],'
				SET @SQL = @SQL + ' [SalePrice],'
				SET @SQL = @SQL + ' [ImageFile],'
				SET @SQL = @SQL + ' [Weight],'
				SET @SQL = @SQL + ' [ActiveInd],'
				SET @SQL = @SQL + ' [DisplayOrder],'
				SET @SQL = @SQL + ' [CallForPricing],'
				SET @SQL = @SQL + ' [HomepageSpecial],'
				SET @SQL = @SQL + ' [CategorySpecial],'
				SET @SQL = @SQL + ' [InventoryDisplay],'
				SET @SQL = @SQL + ' [Keywords],'
				SET @SQL = @SQL + ' [ManufacturerID],'
				SET @SQL = @SQL + ' [AdditionalInfoLink],'
				SET @SQL = @SQL + ' [AdditionalInfoLinkLabel],'
				SET @SQL = @SQL + ' [ShippingRuleTypeID],'
				SET @SQL = @SQL + ' [SEOTitle],'
				SET @SQL = @SQL + ' [SEOKeywords],'
				SET @SQL = @SQL + ' [SEODescription],'
				SET @SQL = @SQL + ' [Custom1],'
				SET @SQL = @SQL + ' [Custom2],'
				SET @SQL = @SQL + ' [Custom3],'
				SET @SQL = @SQL + ' [ShipEachItemSeparately],'
				SET @SQL = @SQL + ' [SKU],'
				SET @SQL = @SQL + ' [QuantityOnHand],'
				SET @SQL = @SQL + ' [AllowBackOrder],'
				SET @SQL = @SQL + ' [BackOrderMsg],'
				SET @SQL = @SQL + ' [DropShipInd],'
				SET @SQL = @SQL + ' [DropShipEmailID],'
				SET @SQL = @SQL + ' [Specifications],'
				SET @SQL = @SQL + ' [AdditionalInformation],'
				SET @SQL = @SQL + ' [InStockMsg],'
				SET @SQL = @SQL + ' [OutOfStockMsg],'
				SET @SQL = @SQL + ' [TrackInventoryInd]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProduct]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProduct_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProduct_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProduct_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeProduct table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProduct_Insert
(

	@ProductID int    OUTPUT,

	@PortalID int   ,

	@Name nvarchar (MAX)  ,

	@ShortDescription ntext   ,

	@Description ntext   ,

	@FeaturesDesc ntext   ,

	@ProductNum nvarchar (MAX)  ,

	@ProductTypeID int   ,

	@RetailPrice money   ,

	@WholesalePrice money   ,

	@SalePrice money   ,

	@ImageFile nvarchar (MAX)  ,

	@Weight decimal (18, 2)  ,

	@ActiveInd bit   ,

	@DisplayOrder int   ,

	@CallForPricing bit   ,

	@HomepageSpecial bit   ,

	@CategorySpecial bit   ,

	@InventoryDisplay tinyint   ,

	@Keywords nvarchar (MAX)  ,

	@ManufacturerID int   ,

	@AdditionalInfoLink nvarchar (MAX)  ,

	@AdditionalInfoLinkLabel nvarchar (MAX)  ,

	@ShippingRuleTypeID int   ,

	@SEOTitle nvarchar (MAX)  ,

	@SEOKeywords nvarchar (MAX)  ,

	@SEODescription nvarchar (MAX)  ,

	@Custom1 nvarchar (MAX)  ,

	@Custom2 nvarchar (MAX)  ,

	@Custom3 nvarchar (MAX)  ,

	@ShipEachItemSeparately bit   ,

	@SKU nvarchar (MAX)  ,

	@QuantityOnHand int   ,

	@AllowBackOrder bit   ,

	@BackOrderMsg nvarchar (MAX)  ,

	@DropShipInd bit   ,

	@DropShipEmailID nvarchar (MAX)  ,

	@Specifications ntext   ,

	@AdditionalInformation ntext   ,

	@InStockMsg ntext   ,

	@OutOfStockMsg ntext   ,

	@TrackInventoryInd bit   
)
AS


					
				INSERT INTO dbo.[ZNodeProduct]
					(
					[PortalID]
					,[Name]
					,[ShortDescription]
					,[Description]
					,[FeaturesDesc]
					,[ProductNum]
					,[ProductTypeID]
					,[RetailPrice]
					,[WholesalePrice]
					,[SalePrice]
					,[ImageFile]
					,[Weight]
					,[ActiveInd]
					,[DisplayOrder]
					,[CallForPricing]
					,[HomepageSpecial]
					,[CategorySpecial]
					,[InventoryDisplay]
					,[Keywords]
					,[ManufacturerID]
					,[AdditionalInfoLink]
					,[AdditionalInfoLinkLabel]
					,[ShippingRuleTypeID]
					,[SEOTitle]
					,[SEOKeywords]
					,[SEODescription]
					,[Custom1]
					,[Custom2]
					,[Custom3]
					,[ShipEachItemSeparately]
					,[SKU]
					,[QuantityOnHand]
					,[AllowBackOrder]
					,[BackOrderMsg]
					,[DropShipInd]
					,[DropShipEmailID]
					,[Specifications]
					,[AdditionalInformation]
					,[InStockMsg]
					,[OutOfStockMsg]
					,[TrackInventoryInd]
					)
				VALUES
					(
					@PortalID
					,@Name
					,@ShortDescription
					,@Description
					,@FeaturesDesc
					,@ProductNum
					,@ProductTypeID
					,@RetailPrice
					,@WholesalePrice
					,@SalePrice
					,@ImageFile
					,@Weight
					,@ActiveInd
					,@DisplayOrder
					,@CallForPricing
					,@HomepageSpecial
					,@CategorySpecial
					,@InventoryDisplay
					,@Keywords
					,@ManufacturerID
					,@AdditionalInfoLink
					,@AdditionalInfoLinkLabel
					,@ShippingRuleTypeID
					,@SEOTitle
					,@SEOKeywords
					,@SEODescription
					,@Custom1
					,@Custom2
					,@Custom3
					,@ShipEachItemSeparately
					,@SKU
					,@QuantityOnHand
					,@AllowBackOrder
					,@BackOrderMsg
					,@DropShipInd
					,@DropShipEmailID
					,@Specifications
					,@AdditionalInformation
					,@InStockMsg
					,@OutOfStockMsg
					,@TrackInventoryInd
					)
				
				-- Get the identity value
				SET @ProductID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProduct_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProduct_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProduct_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeProduct table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProduct_Update
(

	@ProductID int   ,

	@PortalID int   ,

	@Name nvarchar (MAX)  ,

	@ShortDescription ntext   ,

	@Description ntext   ,

	@FeaturesDesc ntext   ,

	@ProductNum nvarchar (MAX)  ,

	@ProductTypeID int   ,

	@RetailPrice money   ,

	@WholesalePrice money   ,

	@SalePrice money   ,

	@ImageFile nvarchar (MAX)  ,

	@Weight decimal (18, 2)  ,

	@ActiveInd bit   ,

	@DisplayOrder int   ,

	@CallForPricing bit   ,

	@HomepageSpecial bit   ,

	@CategorySpecial bit   ,

	@InventoryDisplay tinyint   ,

	@Keywords nvarchar (MAX)  ,

	@ManufacturerID int   ,

	@AdditionalInfoLink nvarchar (MAX)  ,

	@AdditionalInfoLinkLabel nvarchar (MAX)  ,

	@ShippingRuleTypeID int   ,

	@SEOTitle nvarchar (MAX)  ,

	@SEOKeywords nvarchar (MAX)  ,

	@SEODescription nvarchar (MAX)  ,

	@Custom1 nvarchar (MAX)  ,

	@Custom2 nvarchar (MAX)  ,

	@Custom3 nvarchar (MAX)  ,

	@ShipEachItemSeparately bit   ,

	@SKU nvarchar (MAX)  ,

	@QuantityOnHand int   ,

	@AllowBackOrder bit   ,

	@BackOrderMsg nvarchar (MAX)  ,

	@DropShipInd bit   ,

	@DropShipEmailID nvarchar (MAX)  ,

	@Specifications ntext   ,

	@AdditionalInformation ntext   ,

	@InStockMsg ntext   ,

	@OutOfStockMsg ntext   ,

	@TrackInventoryInd bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeProduct]
				SET
					[PortalID] = @PortalID
					,[Name] = @Name
					,[ShortDescription] = @ShortDescription
					,[Description] = @Description
					,[FeaturesDesc] = @FeaturesDesc
					,[ProductNum] = @ProductNum
					,[ProductTypeID] = @ProductTypeID
					,[RetailPrice] = @RetailPrice
					,[WholesalePrice] = @WholesalePrice
					,[SalePrice] = @SalePrice
					,[ImageFile] = @ImageFile
					,[Weight] = @Weight
					,[ActiveInd] = @ActiveInd
					,[DisplayOrder] = @DisplayOrder
					,[CallForPricing] = @CallForPricing
					,[HomepageSpecial] = @HomepageSpecial
					,[CategorySpecial] = @CategorySpecial
					,[InventoryDisplay] = @InventoryDisplay
					,[Keywords] = @Keywords
					,[ManufacturerID] = @ManufacturerID
					,[AdditionalInfoLink] = @AdditionalInfoLink
					,[AdditionalInfoLinkLabel] = @AdditionalInfoLinkLabel
					,[ShippingRuleTypeID] = @ShippingRuleTypeID
					,[SEOTitle] = @SEOTitle
					,[SEOKeywords] = @SEOKeywords
					,[SEODescription] = @SEODescription
					,[Custom1] = @Custom1
					,[Custom2] = @Custom2
					,[Custom3] = @Custom3
					,[ShipEachItemSeparately] = @ShipEachItemSeparately
					,[SKU] = @SKU
					,[QuantityOnHand] = @QuantityOnHand
					,[AllowBackOrder] = @AllowBackOrder
					,[BackOrderMsg] = @BackOrderMsg
					,[DropShipInd] = @DropShipInd
					,[DropShipEmailID] = @DropShipEmailID
					,[Specifications] = @Specifications
					,[AdditionalInformation] = @AdditionalInformation
					,[InStockMsg] = @InStockMsg
					,[OutOfStockMsg] = @OutOfStockMsg
					,[TrackInventoryInd] = @TrackInventoryInd
				WHERE
[ProductID] = @ProductID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProduct_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProduct_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProduct_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeProduct table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProduct_Delete
(

	@ProductID int   
)
AS


				DELETE FROM dbo.[ZNodeProduct] WITH (ROWLOCK) 
				WHERE
					[ProductID] = @ProductID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProduct_GetByManufacturerID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProduct_GetByManufacturerID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetByManufacturerID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProduct table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetByManufacturerID
(

	@ManufacturerID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ProductID],
					[PortalID],
					[Name],
					[ShortDescription],
					[Description],
					[FeaturesDesc],
					[ProductNum],
					[ProductTypeID],
					[RetailPrice],
					[WholesalePrice],
					[SalePrice],
					[ImageFile],
					[Weight],
					[ActiveInd],
					[DisplayOrder],
					[CallForPricing],
					[HomepageSpecial],
					[CategorySpecial],
					[InventoryDisplay],
					[Keywords],
					[ManufacturerID],
					[AdditionalInfoLink],
					[AdditionalInfoLinkLabel],
					[ShippingRuleTypeID],
					[SEOTitle],
					[SEOKeywords],
					[SEODescription],
					[Custom1],
					[Custom2],
					[Custom3],
					[ShipEachItemSeparately],
					[SKU],
					[QuantityOnHand],
					[AllowBackOrder],
					[BackOrderMsg],
					[DropShipInd],
					[DropShipEmailID],
					[Specifications],
					[AdditionalInformation],
					[InStockMsg],
					[OutOfStockMsg],
					[TrackInventoryInd]
				FROM
					dbo.[ZNodeProduct]
				WHERE
					[ManufacturerID] = @ManufacturerID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProduct_GetByProductTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProduct_GetByProductTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetByProductTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProduct table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetByProductTypeID
(

	@ProductTypeID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ProductID],
					[PortalID],
					[Name],
					[ShortDescription],
					[Description],
					[FeaturesDesc],
					[ProductNum],
					[ProductTypeID],
					[RetailPrice],
					[WholesalePrice],
					[SalePrice],
					[ImageFile],
					[Weight],
					[ActiveInd],
					[DisplayOrder],
					[CallForPricing],
					[HomepageSpecial],
					[CategorySpecial],
					[InventoryDisplay],
					[Keywords],
					[ManufacturerID],
					[AdditionalInfoLink],
					[AdditionalInfoLinkLabel],
					[ShippingRuleTypeID],
					[SEOTitle],
					[SEOKeywords],
					[SEODescription],
					[Custom1],
					[Custom2],
					[Custom3],
					[ShipEachItemSeparately],
					[SKU],
					[QuantityOnHand],
					[AllowBackOrder],
					[BackOrderMsg],
					[DropShipInd],
					[DropShipEmailID],
					[Specifications],
					[AdditionalInformation],
					[InStockMsg],
					[OutOfStockMsg],
					[TrackInventoryInd]
				FROM
					dbo.[ZNodeProduct]
				WHERE
					[ProductTypeID] = @ProductTypeID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProduct_GetByShippingRuleTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProduct_GetByShippingRuleTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetByShippingRuleTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProduct table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetByShippingRuleTypeID
(

	@ShippingRuleTypeID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ProductID],
					[PortalID],
					[Name],
					[ShortDescription],
					[Description],
					[FeaturesDesc],
					[ProductNum],
					[ProductTypeID],
					[RetailPrice],
					[WholesalePrice],
					[SalePrice],
					[ImageFile],
					[Weight],
					[ActiveInd],
					[DisplayOrder],
					[CallForPricing],
					[HomepageSpecial],
					[CategorySpecial],
					[InventoryDisplay],
					[Keywords],
					[ManufacturerID],
					[AdditionalInfoLink],
					[AdditionalInfoLinkLabel],
					[ShippingRuleTypeID],
					[SEOTitle],
					[SEOKeywords],
					[SEODescription],
					[Custom1],
					[Custom2],
					[Custom3],
					[ShipEachItemSeparately],
					[SKU],
					[QuantityOnHand],
					[AllowBackOrder],
					[BackOrderMsg],
					[DropShipInd],
					[DropShipEmailID],
					[Specifications],
					[AdditionalInformation],
					[InStockMsg],
					[OutOfStockMsg],
					[TrackInventoryInd]
				FROM
					dbo.[ZNodeProduct]
				WHERE
					[ShippingRuleTypeID] = @ShippingRuleTypeID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProduct_GetByProductID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProduct_GetByProductID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetByProductID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProduct table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetByProductID
(

	@ProductID int   
)
AS


				SELECT
					[ProductID],
					[PortalID],
					[Name],
					[ShortDescription],
					[Description],
					[FeaturesDesc],
					[ProductNum],
					[ProductTypeID],
					[RetailPrice],
					[WholesalePrice],
					[SalePrice],
					[ImageFile],
					[Weight],
					[ActiveInd],
					[DisplayOrder],
					[CallForPricing],
					[HomepageSpecial],
					[CategorySpecial],
					[InventoryDisplay],
					[Keywords],
					[ManufacturerID],
					[AdditionalInfoLink],
					[AdditionalInfoLinkLabel],
					[ShippingRuleTypeID],
					[SEOTitle],
					[SEOKeywords],
					[SEODescription],
					[Custom1],
					[Custom2],
					[Custom3],
					[ShipEachItemSeparately],
					[SKU],
					[QuantityOnHand],
					[AllowBackOrder],
					[BackOrderMsg],
					[DropShipInd],
					[DropShipEmailID],
					[Specifications],
					[AdditionalInformation],
					[InStockMsg],
					[OutOfStockMsg],
					[TrackInventoryInd]
				FROM
					dbo.[ZNodeProduct]
				WHERE
					[ProductID] = @ProductID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProduct_GetByPortalID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProduct_GetByPortalID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetByPortalID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProduct table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetByPortalID
(

	@PortalID int   
)
AS


				SELECT
					[ProductID],
					[PortalID],
					[Name],
					[ShortDescription],
					[Description],
					[FeaturesDesc],
					[ProductNum],
					[ProductTypeID],
					[RetailPrice],
					[WholesalePrice],
					[SalePrice],
					[ImageFile],
					[Weight],
					[ActiveInd],
					[DisplayOrder],
					[CallForPricing],
					[HomepageSpecial],
					[CategorySpecial],
					[InventoryDisplay],
					[Keywords],
					[ManufacturerID],
					[AdditionalInfoLink],
					[AdditionalInfoLinkLabel],
					[ShippingRuleTypeID],
					[SEOTitle],
					[SEOKeywords],
					[SEODescription],
					[Custom1],
					[Custom2],
					[Custom3],
					[ShipEachItemSeparately],
					[SKU],
					[QuantityOnHand],
					[AllowBackOrder],
					[BackOrderMsg],
					[DropShipInd],
					[DropShipEmailID],
					[Specifications],
					[AdditionalInformation],
					[InStockMsg],
					[OutOfStockMsg],
					[TrackInventoryInd]
				FROM
					dbo.[ZNodeProduct]
				WHERE
					[PortalID] = @PortalID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProduct_GetByHomepageSpecialPortalID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProduct_GetByHomepageSpecialPortalID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetByHomepageSpecialPortalID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProduct table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetByHomepageSpecialPortalID
(

	@HomepageSpecial bit   ,

	@PortalID int   
)
AS


				SELECT
					[ProductID],
					[PortalID],
					[Name],
					[ShortDescription],
					[Description],
					[FeaturesDesc],
					[ProductNum],
					[ProductTypeID],
					[RetailPrice],
					[WholesalePrice],
					[SalePrice],
					[ImageFile],
					[Weight],
					[ActiveInd],
					[DisplayOrder],
					[CallForPricing],
					[HomepageSpecial],
					[CategorySpecial],
					[InventoryDisplay],
					[Keywords],
					[ManufacturerID],
					[AdditionalInfoLink],
					[AdditionalInfoLinkLabel],
					[ShippingRuleTypeID],
					[SEOTitle],
					[SEOKeywords],
					[SEODescription],
					[Custom1],
					[Custom2],
					[Custom3],
					[ShipEachItemSeparately],
					[SKU],
					[QuantityOnHand],
					[AllowBackOrder],
					[BackOrderMsg],
					[DropShipInd],
					[DropShipEmailID],
					[Specifications],
					[AdditionalInformation],
					[InStockMsg],
					[OutOfStockMsg],
					[TrackInventoryInd]
				FROM
					dbo.[ZNodeProduct]
				WHERE
					[HomepageSpecial] = @HomepageSpecial
					AND [PortalID] = @PortalID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProduct_GetByActiveInd procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProduct_GetByActiveInd') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetByActiveInd
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProduct table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProduct_GetByActiveInd
(

	@ActiveInd bit   
)
AS


				SELECT
					[ProductID],
					[PortalID],
					[Name],
					[ShortDescription],
					[Description],
					[FeaturesDesc],
					[ProductNum],
					[ProductTypeID],
					[RetailPrice],
					[WholesalePrice],
					[SalePrice],
					[ImageFile],
					[Weight],
					[ActiveInd],
					[DisplayOrder],
					[CallForPricing],
					[HomepageSpecial],
					[CategorySpecial],
					[InventoryDisplay],
					[Keywords],
					[ManufacturerID],
					[AdditionalInfoLink],
					[AdditionalInfoLinkLabel],
					[ShippingRuleTypeID],
					[SEOTitle],
					[SEOKeywords],
					[SEODescription],
					[Custom1],
					[Custom2],
					[Custom3],
					[ShipEachItemSeparately],
					[SKU],
					[QuantityOnHand],
					[AllowBackOrder],
					[BackOrderMsg],
					[DropShipInd],
					[DropShipEmailID],
					[Specifications],
					[AdditionalInformation],
					[InStockMsg],
					[OutOfStockMsg],
					[TrackInventoryInd]
				FROM
					dbo.[ZNodeProduct]
				WHERE
					[ActiveInd] = @ActiveInd
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProduct_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProduct_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProduct_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeProduct table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProduct_Find
(

	@SearchUsingOR bit   = null ,

	@ProductID int   = null ,

	@PortalID int   = null ,

	@Name nvarchar (MAX)  = null ,

	@ShortDescription ntext   = null ,

	@Description ntext   = null ,

	@FeaturesDesc ntext   = null ,

	@ProductNum nvarchar (MAX)  = null ,

	@ProductTypeID int   = null ,

	@RetailPrice money   = null ,

	@WholesalePrice money   = null ,

	@SalePrice money   = null ,

	@ImageFile nvarchar (MAX)  = null ,

	@Weight decimal (18, 2)  = null ,

	@ActiveInd bit   = null ,

	@DisplayOrder int   = null ,

	@CallForPricing bit   = null ,

	@HomepageSpecial bit   = null ,

	@CategorySpecial bit   = null ,

	@InventoryDisplay tinyint   = null ,

	@Keywords nvarchar (MAX)  = null ,

	@ManufacturerID int   = null ,

	@AdditionalInfoLink nvarchar (MAX)  = null ,

	@AdditionalInfoLinkLabel nvarchar (MAX)  = null ,

	@ShippingRuleTypeID int   = null ,

	@SEOTitle nvarchar (MAX)  = null ,

	@SEOKeywords nvarchar (MAX)  = null ,

	@SEODescription nvarchar (MAX)  = null ,

	@Custom1 nvarchar (MAX)  = null ,

	@Custom2 nvarchar (MAX)  = null ,

	@Custom3 nvarchar (MAX)  = null ,

	@ShipEachItemSeparately bit   = null ,

	@SKU nvarchar (MAX)  = null ,

	@QuantityOnHand int   = null ,

	@AllowBackOrder bit   = null ,

	@BackOrderMsg nvarchar (MAX)  = null ,

	@DropShipInd bit   = null ,

	@DropShipEmailID nvarchar (MAX)  = null ,

	@Specifications ntext   = null ,

	@AdditionalInformation ntext   = null ,

	@InStockMsg ntext   = null ,

	@OutOfStockMsg ntext   = null ,

	@TrackInventoryInd bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ProductID]
	, [PortalID]
	, [Name]
	, [ShortDescription]
	, [Description]
	, [FeaturesDesc]
	, [ProductNum]
	, [ProductTypeID]
	, [RetailPrice]
	, [WholesalePrice]
	, [SalePrice]
	, [ImageFile]
	, [Weight]
	, [ActiveInd]
	, [DisplayOrder]
	, [CallForPricing]
	, [HomepageSpecial]
	, [CategorySpecial]
	, [InventoryDisplay]
	, [Keywords]
	, [ManufacturerID]
	, [AdditionalInfoLink]
	, [AdditionalInfoLinkLabel]
	, [ShippingRuleTypeID]
	, [SEOTitle]
	, [SEOKeywords]
	, [SEODescription]
	, [Custom1]
	, [Custom2]
	, [Custom3]
	, [ShipEachItemSeparately]
	, [SKU]
	, [QuantityOnHand]
	, [AllowBackOrder]
	, [BackOrderMsg]
	, [DropShipInd]
	, [DropShipEmailID]
	, [Specifications]
	, [AdditionalInformation]
	, [InStockMsg]
	, [OutOfStockMsg]
	, [TrackInventoryInd]
    FROM
	dbo.[ZNodeProduct]
    WHERE 
	 ([ProductID] = @ProductID OR @ProductID is null)
	AND ([PortalID] = @PortalID OR @PortalID is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([ProductNum] = @ProductNum OR @ProductNum is null)
	AND ([ProductTypeID] = @ProductTypeID OR @ProductTypeID is null)
	AND ([RetailPrice] = @RetailPrice OR @RetailPrice is null)
	AND ([WholesalePrice] = @WholesalePrice OR @WholesalePrice is null)
	AND ([SalePrice] = @SalePrice OR @SalePrice is null)
	AND ([ImageFile] = @ImageFile OR @ImageFile is null)
	AND ([Weight] = @Weight OR @Weight is null)
	AND ([ActiveInd] = @ActiveInd OR @ActiveInd is null)
	AND ([DisplayOrder] = @DisplayOrder OR @DisplayOrder is null)
	AND ([CallForPricing] = @CallForPricing OR @CallForPricing is null)
	AND ([HomepageSpecial] = @HomepageSpecial OR @HomepageSpecial is null)
	AND ([CategorySpecial] = @CategorySpecial OR @CategorySpecial is null)
	AND ([InventoryDisplay] = @InventoryDisplay OR @InventoryDisplay is null)
	AND ([Keywords] = @Keywords OR @Keywords is null)
	AND ([ManufacturerID] = @ManufacturerID OR @ManufacturerID is null)
	AND ([AdditionalInfoLink] = @AdditionalInfoLink OR @AdditionalInfoLink is null)
	AND ([AdditionalInfoLinkLabel] = @AdditionalInfoLinkLabel OR @AdditionalInfoLinkLabel is null)
	AND ([ShippingRuleTypeID] = @ShippingRuleTypeID OR @ShippingRuleTypeID is null)
	AND ([SEOTitle] = @SEOTitle OR @SEOTitle is null)
	AND ([SEOKeywords] = @SEOKeywords OR @SEOKeywords is null)
	AND ([SEODescription] = @SEODescription OR @SEODescription is null)
	AND ([Custom1] = @Custom1 OR @Custom1 is null)
	AND ([Custom2] = @Custom2 OR @Custom2 is null)
	AND ([Custom3] = @Custom3 OR @Custom3 is null)
	AND ([ShipEachItemSeparately] = @ShipEachItemSeparately OR @ShipEachItemSeparately is null)
	AND ([SKU] = @SKU OR @SKU is null)
	AND ([QuantityOnHand] = @QuantityOnHand OR @QuantityOnHand is null)
	AND ([AllowBackOrder] = @AllowBackOrder OR @AllowBackOrder is null)
	AND ([BackOrderMsg] = @BackOrderMsg OR @BackOrderMsg is null)
	AND ([DropShipInd] = @DropShipInd OR @DropShipInd is null)
	AND ([DropShipEmailID] = @DropShipEmailID OR @DropShipEmailID is null)
	AND ([TrackInventoryInd] = @TrackInventoryInd OR @TrackInventoryInd is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ProductID]
	, [PortalID]
	, [Name]
	, [ShortDescription]
	, [Description]
	, [FeaturesDesc]
	, [ProductNum]
	, [ProductTypeID]
	, [RetailPrice]
	, [WholesalePrice]
	, [SalePrice]
	, [ImageFile]
	, [Weight]
	, [ActiveInd]
	, [DisplayOrder]
	, [CallForPricing]
	, [HomepageSpecial]
	, [CategorySpecial]
	, [InventoryDisplay]
	, [Keywords]
	, [ManufacturerID]
	, [AdditionalInfoLink]
	, [AdditionalInfoLinkLabel]
	, [ShippingRuleTypeID]
	, [SEOTitle]
	, [SEOKeywords]
	, [SEODescription]
	, [Custom1]
	, [Custom2]
	, [Custom3]
	, [ShipEachItemSeparately]
	, [SKU]
	, [QuantityOnHand]
	, [AllowBackOrder]
	, [BackOrderMsg]
	, [DropShipInd]
	, [DropShipEmailID]
	, [Specifications]
	, [AdditionalInformation]
	, [InStockMsg]
	, [OutOfStockMsg]
	, [TrackInventoryInd]
    FROM
	dbo.[ZNodeProduct]
    WHERE 
	 ([ProductID] = @ProductID AND @ProductID is not null)
	OR ([PortalID] = @PortalID AND @PortalID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([ProductNum] = @ProductNum AND @ProductNum is not null)
	OR ([ProductTypeID] = @ProductTypeID AND @ProductTypeID is not null)
	OR ([RetailPrice] = @RetailPrice AND @RetailPrice is not null)
	OR ([WholesalePrice] = @WholesalePrice AND @WholesalePrice is not null)
	OR ([SalePrice] = @SalePrice AND @SalePrice is not null)
	OR ([ImageFile] = @ImageFile AND @ImageFile is not null)
	OR ([Weight] = @Weight AND @Weight is not null)
	OR ([ActiveInd] = @ActiveInd AND @ActiveInd is not null)
	OR ([DisplayOrder] = @DisplayOrder AND @DisplayOrder is not null)
	OR ([CallForPricing] = @CallForPricing AND @CallForPricing is not null)
	OR ([HomepageSpecial] = @HomepageSpecial AND @HomepageSpecial is not null)
	OR ([CategorySpecial] = @CategorySpecial AND @CategorySpecial is not null)
	OR ([InventoryDisplay] = @InventoryDisplay AND @InventoryDisplay is not null)
	OR ([Keywords] = @Keywords AND @Keywords is not null)
	OR ([ManufacturerID] = @ManufacturerID AND @ManufacturerID is not null)
	OR ([AdditionalInfoLink] = @AdditionalInfoLink AND @AdditionalInfoLink is not null)
	OR ([AdditionalInfoLinkLabel] = @AdditionalInfoLinkLabel AND @AdditionalInfoLinkLabel is not null)
	OR ([ShippingRuleTypeID] = @ShippingRuleTypeID AND @ShippingRuleTypeID is not null)
	OR ([SEOTitle] = @SEOTitle AND @SEOTitle is not null)
	OR ([SEOKeywords] = @SEOKeywords AND @SEOKeywords is not null)
	OR ([SEODescription] = @SEODescription AND @SEODescription is not null)
	OR ([Custom1] = @Custom1 AND @Custom1 is not null)
	OR ([Custom2] = @Custom2 AND @Custom2 is not null)
	OR ([Custom3] = @Custom3 AND @Custom3 is not null)
	OR ([ShipEachItemSeparately] = @ShipEachItemSeparately AND @ShipEachItemSeparately is not null)
	OR ([SKU] = @SKU AND @SKU is not null)
	OR ([QuantityOnHand] = @QuantityOnHand AND @QuantityOnHand is not null)
	OR ([AllowBackOrder] = @AllowBackOrder AND @AllowBackOrder is not null)
	OR ([BackOrderMsg] = @BackOrderMsg AND @BackOrderMsg is not null)
	OR ([DropShipInd] = @DropShipInd AND @DropShipInd is not null)
	OR ([DropShipEmailID] = @DropShipEmailID AND @DropShipEmailID is not null)
	OR ([TrackInventoryInd] = @TrackInventoryInd AND @TrackInventoryInd is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentSetting_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentSetting_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodePaymentSetting table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_Get_List

AS


				
				SELECT
					[PaymentSettingID],
					[PaymentTypeID],
					[ProfileID],
					[GatewayTypeID],
					[GatewayUsername],
					[GatewayPassword],
					[EnableVisa],
					[EnableMasterCard],
					[EnableAmex],
					[EnableDiscover],
					[TransactionKey],
					[ActiveInd],
					[DisplayOrder],
					[TestMode],
					[OfflineMode],
					[SaveCreditCartInfo]
				FROM
					dbo.[ZNodePaymentSetting]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentSetting_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentSetting_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodePaymentSetting table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[PaymentSettingID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [PaymentSettingID]'
				SET @SQL = @SQL + ', [PaymentTypeID]'
				SET @SQL = @SQL + ', [ProfileID]'
				SET @SQL = @SQL + ', [GatewayTypeID]'
				SET @SQL = @SQL + ', [GatewayUsername]'
				SET @SQL = @SQL + ', [GatewayPassword]'
				SET @SQL = @SQL + ', [EnableVisa]'
				SET @SQL = @SQL + ', [EnableMasterCard]'
				SET @SQL = @SQL + ', [EnableAmex]'
				SET @SQL = @SQL + ', [EnableDiscover]'
				SET @SQL = @SQL + ', [TransactionKey]'
				SET @SQL = @SQL + ', [ActiveInd]'
				SET @SQL = @SQL + ', [DisplayOrder]'
				SET @SQL = @SQL + ', [TestMode]'
				SET @SQL = @SQL + ', [OfflineMode]'
				SET @SQL = @SQL + ', [SaveCreditCartInfo]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodePaymentSetting]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [PaymentSettingID],'
				SET @SQL = @SQL + ' [PaymentTypeID],'
				SET @SQL = @SQL + ' [ProfileID],'
				SET @SQL = @SQL + ' [GatewayTypeID],'
				SET @SQL = @SQL + ' [GatewayUsername],'
				SET @SQL = @SQL + ' [GatewayPassword],'
				SET @SQL = @SQL + ' [EnableVisa],'
				SET @SQL = @SQL + ' [EnableMasterCard],'
				SET @SQL = @SQL + ' [EnableAmex],'
				SET @SQL = @SQL + ' [EnableDiscover],'
				SET @SQL = @SQL + ' [TransactionKey],'
				SET @SQL = @SQL + ' [ActiveInd],'
				SET @SQL = @SQL + ' [DisplayOrder],'
				SET @SQL = @SQL + ' [TestMode],'
				SET @SQL = @SQL + ' [OfflineMode],'
				SET @SQL = @SQL + ' [SaveCreditCartInfo]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodePaymentSetting]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentSetting_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentSetting_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodePaymentSetting table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_Insert
(

	@PaymentSettingID int    OUTPUT,

	@PaymentTypeID int   ,

	@ProfileID int   ,

	@GatewayTypeID int   ,

	@GatewayUsername varchar (MAX)  ,

	@GatewayPassword varchar (MAX)  ,

	@EnableVisa bit   ,

	@EnableMasterCard bit   ,

	@EnableAmex bit   ,

	@EnableDiscover bit   ,

	@TransactionKey varchar (MAX)  ,

	@ActiveInd bit   ,

	@DisplayOrder tinyint   ,

	@TestMode bit   ,

	@OfflineMode bit   ,

	@SaveCreditCartInfo bit   
)
AS


					
				INSERT INTO dbo.[ZNodePaymentSetting]
					(
					[PaymentTypeID]
					,[ProfileID]
					,[GatewayTypeID]
					,[GatewayUsername]
					,[GatewayPassword]
					,[EnableVisa]
					,[EnableMasterCard]
					,[EnableAmex]
					,[EnableDiscover]
					,[TransactionKey]
					,[ActiveInd]
					,[DisplayOrder]
					,[TestMode]
					,[OfflineMode]
					,[SaveCreditCartInfo]
					)
				VALUES
					(
					@PaymentTypeID
					,@ProfileID
					,@GatewayTypeID
					,@GatewayUsername
					,@GatewayPassword
					,@EnableVisa
					,@EnableMasterCard
					,@EnableAmex
					,@EnableDiscover
					,@TransactionKey
					,@ActiveInd
					,@DisplayOrder
					,@TestMode
					,@OfflineMode
					,@SaveCreditCartInfo
					)
				
				-- Get the identity value
				SET @PaymentSettingID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentSetting_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentSetting_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodePaymentSetting table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_Update
(

	@PaymentSettingID int   ,

	@PaymentTypeID int   ,

	@ProfileID int   ,

	@GatewayTypeID int   ,

	@GatewayUsername varchar (MAX)  ,

	@GatewayPassword varchar (MAX)  ,

	@EnableVisa bit   ,

	@EnableMasterCard bit   ,

	@EnableAmex bit   ,

	@EnableDiscover bit   ,

	@TransactionKey varchar (MAX)  ,

	@ActiveInd bit   ,

	@DisplayOrder tinyint   ,

	@TestMode bit   ,

	@OfflineMode bit   ,

	@SaveCreditCartInfo bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodePaymentSetting]
				SET
					[PaymentTypeID] = @PaymentTypeID
					,[ProfileID] = @ProfileID
					,[GatewayTypeID] = @GatewayTypeID
					,[GatewayUsername] = @GatewayUsername
					,[GatewayPassword] = @GatewayPassword
					,[EnableVisa] = @EnableVisa
					,[EnableMasterCard] = @EnableMasterCard
					,[EnableAmex] = @EnableAmex
					,[EnableDiscover] = @EnableDiscover
					,[TransactionKey] = @TransactionKey
					,[ActiveInd] = @ActiveInd
					,[DisplayOrder] = @DisplayOrder
					,[TestMode] = @TestMode
					,[OfflineMode] = @OfflineMode
					,[SaveCreditCartInfo] = @SaveCreditCartInfo
				WHERE
[PaymentSettingID] = @PaymentSettingID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentSetting_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentSetting_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodePaymentSetting table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_Delete
(

	@PaymentSettingID int   
)
AS


				DELETE FROM dbo.[ZNodePaymentSetting] WITH (ROWLOCK) 
				WHERE
					[PaymentSettingID] = @PaymentSettingID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentSetting_GetByGatewayTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentSetting_GetByGatewayTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_GetByGatewayTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodePaymentSetting table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_GetByGatewayTypeID
(

	@GatewayTypeID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[PaymentSettingID],
					[PaymentTypeID],
					[ProfileID],
					[GatewayTypeID],
					[GatewayUsername],
					[GatewayPassword],
					[EnableVisa],
					[EnableMasterCard],
					[EnableAmex],
					[EnableDiscover],
					[TransactionKey],
					[ActiveInd],
					[DisplayOrder],
					[TestMode],
					[OfflineMode],
					[SaveCreditCartInfo]
				FROM
					dbo.[ZNodePaymentSetting]
				WHERE
					[GatewayTypeID] = @GatewayTypeID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentSetting_GetByPaymentTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentSetting_GetByPaymentTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_GetByPaymentTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodePaymentSetting table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_GetByPaymentTypeID
(

	@PaymentTypeID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[PaymentSettingID],
					[PaymentTypeID],
					[ProfileID],
					[GatewayTypeID],
					[GatewayUsername],
					[GatewayPassword],
					[EnableVisa],
					[EnableMasterCard],
					[EnableAmex],
					[EnableDiscover],
					[TransactionKey],
					[ActiveInd],
					[DisplayOrder],
					[TestMode],
					[OfflineMode],
					[SaveCreditCartInfo]
				FROM
					dbo.[ZNodePaymentSetting]
				WHERE
					[PaymentTypeID] = @PaymentTypeID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentSetting_GetByPaymentSettingID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentSetting_GetByPaymentSettingID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_GetByPaymentSettingID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodePaymentSetting table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_GetByPaymentSettingID
(

	@PaymentSettingID int   
)
AS


				SELECT
					[PaymentSettingID],
					[PaymentTypeID],
					[ProfileID],
					[GatewayTypeID],
					[GatewayUsername],
					[GatewayPassword],
					[EnableVisa],
					[EnableMasterCard],
					[EnableAmex],
					[EnableDiscover],
					[TransactionKey],
					[ActiveInd],
					[DisplayOrder],
					[TestMode],
					[OfflineMode],
					[SaveCreditCartInfo]
				FROM
					dbo.[ZNodePaymentSetting]
				WHERE
					[PaymentSettingID] = @PaymentSettingID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentSetting_GetByProfileIDPaymentTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentSetting_GetByProfileIDPaymentTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_GetByProfileIDPaymentTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodePaymentSetting table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_GetByProfileIDPaymentTypeID
(

	@ProfileID int   ,

	@PaymentTypeID int   
)
AS


				SELECT
					[PaymentSettingID],
					[PaymentTypeID],
					[ProfileID],
					[GatewayTypeID],
					[GatewayUsername],
					[GatewayPassword],
					[EnableVisa],
					[EnableMasterCard],
					[EnableAmex],
					[EnableDiscover],
					[TransactionKey],
					[ActiveInd],
					[DisplayOrder],
					[TestMode],
					[OfflineMode],
					[SaveCreditCartInfo]
				FROM
					dbo.[ZNodePaymentSetting]
				WHERE
					[ProfileID] = @ProfileID
					AND [PaymentTypeID] = @PaymentTypeID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentSetting_GetByProfileID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentSetting_GetByProfileID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_GetByProfileID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodePaymentSetting table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_GetByProfileID
(

	@ProfileID int   
)
AS


				SELECT
					[PaymentSettingID],
					[PaymentTypeID],
					[ProfileID],
					[GatewayTypeID],
					[GatewayUsername],
					[GatewayPassword],
					[EnableVisa],
					[EnableMasterCard],
					[EnableAmex],
					[EnableDiscover],
					[TransactionKey],
					[ActiveInd],
					[DisplayOrder],
					[TestMode],
					[OfflineMode],
					[SaveCreditCartInfo]
				FROM
					dbo.[ZNodePaymentSetting]
				WHERE
					[ProfileID] = @ProfileID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodePaymentSetting_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodePaymentSetting_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodePaymentSetting table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodePaymentSetting_Find
(

	@SearchUsingOR bit   = null ,

	@PaymentSettingID int   = null ,

	@PaymentTypeID int   = null ,

	@ProfileID int   = null ,

	@GatewayTypeID int   = null ,

	@GatewayUsername varchar (MAX)  = null ,

	@GatewayPassword varchar (MAX)  = null ,

	@EnableVisa bit   = null ,

	@EnableMasterCard bit   = null ,

	@EnableAmex bit   = null ,

	@EnableDiscover bit   = null ,

	@TransactionKey varchar (MAX)  = null ,

	@ActiveInd bit   = null ,

	@DisplayOrder tinyint   = null ,

	@TestMode bit   = null ,

	@OfflineMode bit   = null ,

	@SaveCreditCartInfo bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [PaymentSettingID]
	, [PaymentTypeID]
	, [ProfileID]
	, [GatewayTypeID]
	, [GatewayUsername]
	, [GatewayPassword]
	, [EnableVisa]
	, [EnableMasterCard]
	, [EnableAmex]
	, [EnableDiscover]
	, [TransactionKey]
	, [ActiveInd]
	, [DisplayOrder]
	, [TestMode]
	, [OfflineMode]
	, [SaveCreditCartInfo]
    FROM
	dbo.[ZNodePaymentSetting]
    WHERE 
	 ([PaymentSettingID] = @PaymentSettingID OR @PaymentSettingID is null)
	AND ([PaymentTypeID] = @PaymentTypeID OR @PaymentTypeID is null)
	AND ([ProfileID] = @ProfileID OR @ProfileID is null)
	AND ([GatewayTypeID] = @GatewayTypeID OR @GatewayTypeID is null)
	AND ([GatewayUsername] = @GatewayUsername OR @GatewayUsername is null)
	AND ([GatewayPassword] = @GatewayPassword OR @GatewayPassword is null)
	AND ([EnableVisa] = @EnableVisa OR @EnableVisa is null)
	AND ([EnableMasterCard] = @EnableMasterCard OR @EnableMasterCard is null)
	AND ([EnableAmex] = @EnableAmex OR @EnableAmex is null)
	AND ([EnableDiscover] = @EnableDiscover OR @EnableDiscover is null)
	AND ([TransactionKey] = @TransactionKey OR @TransactionKey is null)
	AND ([ActiveInd] = @ActiveInd OR @ActiveInd is null)
	AND ([DisplayOrder] = @DisplayOrder OR @DisplayOrder is null)
	AND ([TestMode] = @TestMode OR @TestMode is null)
	AND ([OfflineMode] = @OfflineMode OR @OfflineMode is null)
	AND ([SaveCreditCartInfo] = @SaveCreditCartInfo OR @SaveCreditCartInfo is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [PaymentSettingID]
	, [PaymentTypeID]
	, [ProfileID]
	, [GatewayTypeID]
	, [GatewayUsername]
	, [GatewayPassword]
	, [EnableVisa]
	, [EnableMasterCard]
	, [EnableAmex]
	, [EnableDiscover]
	, [TransactionKey]
	, [ActiveInd]
	, [DisplayOrder]
	, [TestMode]
	, [OfflineMode]
	, [SaveCreditCartInfo]
    FROM
	dbo.[ZNodePaymentSetting]
    WHERE 
	 ([PaymentSettingID] = @PaymentSettingID AND @PaymentSettingID is not null)
	OR ([PaymentTypeID] = @PaymentTypeID AND @PaymentTypeID is not null)
	OR ([ProfileID] = @ProfileID AND @ProfileID is not null)
	OR ([GatewayTypeID] = @GatewayTypeID AND @GatewayTypeID is not null)
	OR ([GatewayUsername] = @GatewayUsername AND @GatewayUsername is not null)
	OR ([GatewayPassword] = @GatewayPassword AND @GatewayPassword is not null)
	OR ([EnableVisa] = @EnableVisa AND @EnableVisa is not null)
	OR ([EnableMasterCard] = @EnableMasterCard AND @EnableMasterCard is not null)
	OR ([EnableAmex] = @EnableAmex AND @EnableAmex is not null)
	OR ([EnableDiscover] = @EnableDiscover AND @EnableDiscover is not null)
	OR ([TransactionKey] = @TransactionKey AND @TransactionKey is not null)
	OR ([ActiveInd] = @ActiveInd AND @ActiveInd is not null)
	OR ([DisplayOrder] = @DisplayOrder AND @DisplayOrder is not null)
	OR ([TestMode] = @TestMode AND @TestMode is not null)
	OR ([OfflineMode] = @OfflineMode AND @OfflineMode is not null)
	OR ([SaveCreditCartInfo] = @SaveCreditCartInfo AND @SaveCreditCartInfo is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAddOn_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAddOn_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeProductAddOn table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_Get_List

AS


				
				SELECT
					[ProductAddOnID],
					[ProductID],
					[AddOnID]
				FROM
					dbo.[ZNodeProductAddOn]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAddOn_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAddOn_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeProductAddOn table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ProductAddOnID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ProductAddOnID]'
				SET @SQL = @SQL + ', [ProductID]'
				SET @SQL = @SQL + ', [AddOnID]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductAddOn]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ProductAddOnID],'
				SET @SQL = @SQL + ' [ProductID],'
				SET @SQL = @SQL + ' [AddOnID]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductAddOn]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAddOn_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAddOn_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeProductAddOn table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_Insert
(

	@ProductAddOnID int    OUTPUT,

	@ProductID int   ,

	@AddOnID int   
)
AS


					
				INSERT INTO dbo.[ZNodeProductAddOn]
					(
					[ProductID]
					,[AddOnID]
					)
				VALUES
					(
					@ProductID
					,@AddOnID
					)
				
				-- Get the identity value
				SET @ProductAddOnID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAddOn_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAddOn_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeProductAddOn table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_Update
(

	@ProductAddOnID int   ,

	@ProductID int   ,

	@AddOnID int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeProductAddOn]
				SET
					[ProductID] = @ProductID
					,[AddOnID] = @AddOnID
				WHERE
[ProductAddOnID] = @ProductAddOnID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAddOn_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAddOn_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeProductAddOn table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_Delete
(

	@ProductAddOnID int   
)
AS


				DELETE FROM dbo.[ZNodeProductAddOn] WITH (ROWLOCK) 
				WHERE
					[ProductAddOnID] = @ProductAddOnID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAddOn_GetByProductID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAddOn_GetByProductID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_GetByProductID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductAddOn table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_GetByProductID
(

	@ProductID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ProductAddOnID],
					[ProductID],
					[AddOnID]
				FROM
					dbo.[ZNodeProductAddOn]
				WHERE
					[ProductID] = @ProductID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAddOn_GetByAddOnID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAddOn_GetByAddOnID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_GetByAddOnID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductAddOn table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_GetByAddOnID
(

	@AddOnID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ProductAddOnID],
					[ProductID],
					[AddOnID]
				FROM
					dbo.[ZNodeProductAddOn]
				WHERE
					[AddOnID] = @AddOnID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAddOn_GetByProductAddOnID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAddOn_GetByProductAddOnID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_GetByProductAddOnID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductAddOn table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_GetByProductAddOnID
(

	@ProductAddOnID int   
)
AS


				SELECT
					[ProductAddOnID],
					[ProductID],
					[AddOnID]
				FROM
					dbo.[ZNodeProductAddOn]
				WHERE
					[ProductAddOnID] = @ProductAddOnID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAddOn_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAddOn_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeProductAddOn table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAddOn_Find
(

	@SearchUsingOR bit   = null ,

	@ProductAddOnID int   = null ,

	@ProductID int   = null ,

	@AddOnID int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ProductAddOnID]
	, [ProductID]
	, [AddOnID]
    FROM
	dbo.[ZNodeProductAddOn]
    WHERE 
	 ([ProductAddOnID] = @ProductAddOnID OR @ProductAddOnID is null)
	AND ([ProductID] = @ProductID OR @ProductID is null)
	AND ([AddOnID] = @AddOnID OR @AddOnID is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ProductAddOnID]
	, [ProductID]
	, [AddOnID]
    FROM
	dbo.[ZNodeProductAddOn]
    WHERE 
	 ([ProductAddOnID] = @ProductAddOnID AND @ProductAddOnID is not null)
	OR ([ProductID] = @ProductID AND @ProductID is not null)
	OR ([AddOnID] = @AddOnID AND @AddOnID is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCategory_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCategory_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeProductCategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_Get_List

AS


				
				SELECT
					[ProductCategoryID],
					[ProductID],
					[CategoryID]
				FROM
					dbo.[ZNodeProductCategory]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCategory_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCategory_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeProductCategory table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ProductCategoryID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ProductCategoryID]'
				SET @SQL = @SQL + ', [ProductID]'
				SET @SQL = @SQL + ', [CategoryID]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductCategory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ProductCategoryID],'
				SET @SQL = @SQL + ' [ProductID],'
				SET @SQL = @SQL + ' [CategoryID]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductCategory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCategory_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCategory_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeProductCategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_Insert
(

	@ProductCategoryID int    OUTPUT,

	@ProductID int   ,

	@CategoryID int   
)
AS


					
				INSERT INTO dbo.[ZNodeProductCategory]
					(
					[ProductID]
					,[CategoryID]
					)
				VALUES
					(
					@ProductID
					,@CategoryID
					)
				
				-- Get the identity value
				SET @ProductCategoryID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCategory_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCategory_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeProductCategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_Update
(

	@ProductCategoryID int   ,

	@ProductID int   ,

	@CategoryID int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeProductCategory]
				SET
					[ProductID] = @ProductID
					,[CategoryID] = @CategoryID
				WHERE
[ProductCategoryID] = @ProductCategoryID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCategory_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCategory_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeProductCategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_Delete
(

	@ProductCategoryID int   
)
AS


				DELETE FROM dbo.[ZNodeProductCategory] WITH (ROWLOCK) 
				WHERE
					[ProductCategoryID] = @ProductCategoryID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCategory_GetByCategoryID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCategory_GetByCategoryID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_GetByCategoryID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductCategory table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_GetByCategoryID
(

	@CategoryID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ProductCategoryID],
					[ProductID],
					[CategoryID]
				FROM
					dbo.[ZNodeProductCategory]
				WHERE
					[CategoryID] = @CategoryID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCategory_GetByProductID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCategory_GetByProductID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_GetByProductID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductCategory table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_GetByProductID
(

	@ProductID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ProductCategoryID],
					[ProductID],
					[CategoryID]
				FROM
					dbo.[ZNodeProductCategory]
				WHERE
					[ProductID] = @ProductID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCategory_GetByProductCategoryID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCategory_GetByProductCategoryID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_GetByProductCategoryID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductCategory table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_GetByProductCategoryID
(

	@ProductCategoryID int   
)
AS


				SELECT
					[ProductCategoryID],
					[ProductID],
					[CategoryID]
				FROM
					dbo.[ZNodeProductCategory]
				WHERE
					[ProductCategoryID] = @ProductCategoryID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductCategory_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductCategory_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeProductCategory table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductCategory_Find
(

	@SearchUsingOR bit   = null ,

	@ProductCategoryID int   = null ,

	@ProductID int   = null ,

	@CategoryID int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ProductCategoryID]
	, [ProductID]
	, [CategoryID]
    FROM
	dbo.[ZNodeProductCategory]
    WHERE 
	 ([ProductCategoryID] = @ProductCategoryID OR @ProductCategoryID is null)
	AND ([ProductID] = @ProductID OR @ProductID is null)
	AND ([CategoryID] = @CategoryID OR @CategoryID is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ProductCategoryID]
	, [ProductID]
	, [CategoryID]
    FROM
	dbo.[ZNodeProductCategory]
    WHERE 
	 ([ProductCategoryID] = @ProductCategoryID AND @ProductCategoryID is not null)
	OR ([ProductID] = @ProductID AND @ProductID is not null)
	OR ([CategoryID] = @CategoryID AND @CategoryID is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAttribute_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAttribute_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeProductAttribute table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_Get_List

AS


				
				SELECT
					[AttributeId],
					[AttributeTypeId],
					[Name],
					[ExternalId],
					[DisplayOrder],
					[IsActive],
					[OldAttributeId]
				FROM
					dbo.[ZNodeProductAttribute]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAttribute_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAttribute_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeProductAttribute table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[AttributeId]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [AttributeId]'
				SET @SQL = @SQL + ', [AttributeTypeId]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [ExternalId]'
				SET @SQL = @SQL + ', [DisplayOrder]'
				SET @SQL = @SQL + ', [IsActive]'
				SET @SQL = @SQL + ', [OldAttributeId]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductAttribute]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AttributeId],'
				SET @SQL = @SQL + ' [AttributeTypeId],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [ExternalId],'
				SET @SQL = @SQL + ' [DisplayOrder],'
				SET @SQL = @SQL + ' [IsActive],'
				SET @SQL = @SQL + ' [OldAttributeId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProductAttribute]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAttribute_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAttribute_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeProductAttribute table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_Insert
(

	@AttributeId int    OUTPUT,

	@AttributeTypeId int   ,

	@Name nvarchar (255)  ,

	@ExternalId nvarchar (255)  ,

	@DisplayOrder int   ,

	@IsActive bit   ,

	@OldAttributeId int   
)
AS


					
				INSERT INTO dbo.[ZNodeProductAttribute]
					(
					[AttributeTypeId]
					,[Name]
					,[ExternalId]
					,[DisplayOrder]
					,[IsActive]
					,[OldAttributeId]
					)
				VALUES
					(
					@AttributeTypeId
					,@Name
					,@ExternalId
					,@DisplayOrder
					,@IsActive
					,@OldAttributeId
					)
				
				-- Get the identity value
				SET @AttributeId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAttribute_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAttribute_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeProductAttribute table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_Update
(

	@AttributeId int   ,

	@AttributeTypeId int   ,

	@Name nvarchar (255)  ,

	@ExternalId nvarchar (255)  ,

	@DisplayOrder int   ,

	@IsActive bit   ,

	@OldAttributeId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeProductAttribute]
				SET
					[AttributeTypeId] = @AttributeTypeId
					,[Name] = @Name
					,[ExternalId] = @ExternalId
					,[DisplayOrder] = @DisplayOrder
					,[IsActive] = @IsActive
					,[OldAttributeId] = @OldAttributeId
				WHERE
[AttributeId] = @AttributeId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAttribute_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAttribute_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeProductAttribute table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_Delete
(

	@AttributeId int   
)
AS


				DELETE FROM dbo.[ZNodeProductAttribute] WITH (ROWLOCK) 
				WHERE
					[AttributeId] = @AttributeId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAttribute_GetByAttributeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAttribute_GetByAttributeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_GetByAttributeId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductAttribute table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_GetByAttributeId
(

	@AttributeId int   
)
AS


				SELECT
					[AttributeId],
					[AttributeTypeId],
					[Name],
					[ExternalId],
					[DisplayOrder],
					[IsActive],
					[OldAttributeId]
				FROM
					dbo.[ZNodeProductAttribute]
				WHERE
					[AttributeId] = @AttributeId
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAttribute_GetByAttributeTypeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAttribute_GetByAttributeTypeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_GetByAttributeTypeId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProductAttribute table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_GetByAttributeTypeId
(

	@AttributeTypeId int   
)
AS


				SELECT
					[AttributeId],
					[AttributeTypeId],
					[Name],
					[ExternalId],
					[DisplayOrder],
					[IsActive],
					[OldAttributeId]
				FROM
					dbo.[ZNodeProductAttribute]
				WHERE
					[AttributeTypeId] = @AttributeTypeId
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProductAttribute_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProductAttribute_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeProductAttribute table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProductAttribute_Find
(

	@SearchUsingOR bit   = null ,

	@AttributeId int   = null ,

	@AttributeTypeId int   = null ,

	@Name nvarchar (255)  = null ,

	@ExternalId nvarchar (255)  = null ,

	@DisplayOrder int   = null ,

	@IsActive bit   = null ,

	@OldAttributeId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AttributeId]
	, [AttributeTypeId]
	, [Name]
	, [ExternalId]
	, [DisplayOrder]
	, [IsActive]
	, [OldAttributeId]
    FROM
	dbo.[ZNodeProductAttribute]
    WHERE 
	 ([AttributeId] = @AttributeId OR @AttributeId is null)
	AND ([AttributeTypeId] = @AttributeTypeId OR @AttributeTypeId is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([ExternalId] = @ExternalId OR @ExternalId is null)
	AND ([DisplayOrder] = @DisplayOrder OR @DisplayOrder is null)
	AND ([IsActive] = @IsActive OR @IsActive is null)
	AND ([OldAttributeId] = @OldAttributeId OR @OldAttributeId is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AttributeId]
	, [AttributeTypeId]
	, [Name]
	, [ExternalId]
	, [DisplayOrder]
	, [IsActive]
	, [OldAttributeId]
    FROM
	dbo.[ZNodeProductAttribute]
    WHERE 
	 ([AttributeId] = @AttributeId AND @AttributeId is not null)
	OR ([AttributeTypeId] = @AttributeTypeId AND @AttributeTypeId is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([ExternalId] = @ExternalId AND @ExternalId is not null)
	OR ([DisplayOrder] = @DisplayOrder AND @DisplayOrder is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([OldAttributeId] = @OldAttributeId AND @OldAttributeId is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProfile_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProfile_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProfile_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeProfile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProfile_Get_List

AS


				
				SELECT
					[ProfileID],
					[PortalID],
					[Name],
					[IsDefault]
				FROM
					dbo.[ZNodeProfile]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProfile_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProfile_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProfile_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeProfile table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProfile_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ProfileID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ProfileID]'
				SET @SQL = @SQL + ', [PortalID]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [IsDefault]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProfile]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ProfileID],'
				SET @SQL = @SQL + ' [PortalID],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [IsDefault]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeProfile]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProfile_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProfile_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProfile_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeProfile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProfile_Insert
(

	@ProfileID int    OUTPUT,

	@PortalID int   ,

	@Name varchar (100)  ,

	@IsDefault bit   
)
AS


					
				INSERT INTO dbo.[ZNodeProfile]
					(
					[PortalID]
					,[Name]
					,[IsDefault]
					)
				VALUES
					(
					@PortalID
					,@Name
					,@IsDefault
					)
				
				-- Get the identity value
				SET @ProfileID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProfile_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProfile_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProfile_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeProfile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProfile_Update
(

	@ProfileID int   ,

	@PortalID int   ,

	@Name varchar (100)  ,

	@IsDefault bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeProfile]
				SET
					[PortalID] = @PortalID
					,[Name] = @Name
					,[IsDefault] = @IsDefault
				WHERE
[ProfileID] = @ProfileID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProfile_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProfile_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProfile_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeProfile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProfile_Delete
(

	@ProfileID int   
)
AS


				DELETE FROM dbo.[ZNodeProfile] WITH (ROWLOCK) 
				WHERE
					[ProfileID] = @ProfileID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProfile_GetByPortalID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProfile_GetByPortalID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProfile_GetByPortalID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProfile table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProfile_GetByPortalID
(

	@PortalID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ProfileID],
					[PortalID],
					[Name],
					[IsDefault]
				FROM
					dbo.[ZNodeProfile]
				WHERE
					[PortalID] = @PortalID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProfile_GetByProfileID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProfile_GetByProfileID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProfile_GetByProfileID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProfile table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProfile_GetByProfileID
(

	@ProfileID int   
)
AS


				SELECT
					[ProfileID],
					[PortalID],
					[Name],
					[IsDefault]
				FROM
					dbo.[ZNodeProfile]
				WHERE
					[ProfileID] = @ProfileID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProfile_GetByName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProfile_GetByName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProfile_GetByName
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProfile table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProfile_GetByName
(

	@Name varchar (100)  
)
AS


				SELECT
					[ProfileID],
					[PortalID],
					[Name],
					[IsDefault]
				FROM
					dbo.[ZNodeProfile]
				WHERE
					[Name] = @Name
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProfile_GetByIsDefault procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProfile_GetByIsDefault') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProfile_GetByIsDefault
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeProfile table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProfile_GetByIsDefault
(

	@IsDefault bit   
)
AS


				SELECT
					[ProfileID],
					[PortalID],
					[Name],
					[IsDefault]
				FROM
					dbo.[ZNodeProfile]
				WHERE
					[IsDefault] = @IsDefault
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeProfile_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeProfile_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeProfile_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeProfile table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeProfile_Find
(

	@SearchUsingOR bit   = null ,

	@ProfileID int   = null ,

	@PortalID int   = null ,

	@Name varchar (100)  = null ,

	@IsDefault bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ProfileID]
	, [PortalID]
	, [Name]
	, [IsDefault]
    FROM
	dbo.[ZNodeProfile]
    WHERE 
	 ([ProfileID] = @ProfileID OR @ProfileID is null)
	AND ([PortalID] = @PortalID OR @PortalID is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([IsDefault] = @IsDefault OR @IsDefault is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ProfileID]
	, [PortalID]
	, [Name]
	, [IsDefault]
    FROM
	dbo.[ZNodeProfile]
    WHERE 
	 ([ProfileID] = @ProfileID AND @ProfileID is not null)
	OR ([PortalID] = @PortalID AND @PortalID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([IsDefault] = @IsDefault AND @IsDefault is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeState_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeState_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeState_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeState table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeState_Get_List

AS


				
				SELECT
					[Code],
					[CountryCode],
					[Name]
				FROM
					dbo.[ZNodeState]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeState_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeState_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeState_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeState table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeState_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Code]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Code]'
				SET @SQL = @SQL + ', [CountryCode]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeState]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Code],'
				SET @SQL = @SQL + ' [CountryCode],'
				SET @SQL = @SQL + ' [Name]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeState]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeState_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeState_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeState_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeState table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeState_Insert
(

	@Code varchar (2)  ,

	@CountryCode varchar (2)  ,

	@Name varchar (100)  
)
AS


					
				INSERT INTO dbo.[ZNodeState]
					(
					[Code]
					,[CountryCode]
					,[Name]
					)
				VALUES
					(
					@Code
					,@CountryCode
					,@Name
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeState_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeState_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeState_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeState table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeState_Update
(

	@Code varchar (2)  ,

	@OriginalCode varchar (2)  ,

	@CountryCode varchar (2)  ,

	@Name varchar (100)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeState]
				SET
					[Code] = @Code
					,[CountryCode] = @CountryCode
					,[Name] = @Name
				WHERE
[Code] = @OriginalCode 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeState_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeState_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeState_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeState table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeState_Delete
(

	@Code varchar (2)  
)
AS


				DELETE FROM dbo.[ZNodeState] WITH (ROWLOCK) 
				WHERE
					[Code] = @Code
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeState_GetByCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeState_GetByCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeState_GetByCode
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeState table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeState_GetByCode
(

	@Code varchar (2)  
)
AS


				SELECT
					[Code],
					[CountryCode],
					[Name]
				FROM
					dbo.[ZNodeState]
				WHERE
					[Code] = @Code
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeState_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeState_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeState_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeState table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeState_Find
(

	@SearchUsingOR bit   = null ,

	@Code varchar (2)  = null ,

	@CountryCode varchar (2)  = null ,

	@Name varchar (100)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Code]
	, [CountryCode]
	, [Name]
    FROM
	dbo.[ZNodeState]
    WHERE 
	 ([Code] = @Code OR @Code is null)
	AND ([CountryCode] = @CountryCode OR @CountryCode is null)
	AND ([Name] = @Name OR @Name is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Code]
	, [CountryCode]
	, [Name]
    FROM
	dbo.[ZNodeState]
    WHERE 
	 ([Code] = @Code AND @Code is not null)
	OR ([CountryCode] = @CountryCode AND @CountryCode is not null)
	OR ([Name] = @Name AND @Name is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKUAttribute_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKUAttribute_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeSKUAttribute table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_Get_List

AS


				
				SELECT
					[SKUAttributeID],
					[SKUID],
					[AttributeId]
				FROM
					dbo.[ZNodeSKUAttribute]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKUAttribute_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKUAttribute_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeSKUAttribute table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[SKUAttributeID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [SKUAttributeID]'
				SET @SQL = @SQL + ', [SKUID]'
				SET @SQL = @SQL + ', [AttributeId]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeSKUAttribute]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [SKUAttributeID],'
				SET @SQL = @SQL + ' [SKUID],'
				SET @SQL = @SQL + ' [AttributeId]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeSKUAttribute]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKUAttribute_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKUAttribute_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeSKUAttribute table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_Insert
(

	@SKUAttributeID int    OUTPUT,

	@SKUID int   ,

	@AttributeId int   
)
AS


					
				INSERT INTO dbo.[ZNodeSKUAttribute]
					(
					[SKUID]
					,[AttributeId]
					)
				VALUES
					(
					@SKUID
					,@AttributeId
					)
				
				-- Get the identity value
				SET @SKUAttributeID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKUAttribute_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKUAttribute_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeSKUAttribute table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_Update
(

	@SKUAttributeID int   ,

	@SKUID int   ,

	@AttributeId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeSKUAttribute]
				SET
					[SKUID] = @SKUID
					,[AttributeId] = @AttributeId
				WHERE
[SKUAttributeID] = @SKUAttributeID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKUAttribute_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKUAttribute_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeSKUAttribute table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_Delete
(

	@SKUAttributeID int   
)
AS


				DELETE FROM dbo.[ZNodeSKUAttribute] WITH (ROWLOCK) 
				WHERE
					[SKUAttributeID] = @SKUAttributeID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKUAttribute_GetByAttributeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKUAttribute_GetByAttributeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_GetByAttributeId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeSKUAttribute table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_GetByAttributeId
(

	@AttributeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[SKUAttributeID],
					[SKUID],
					[AttributeId]
				FROM
					dbo.[ZNodeSKUAttribute]
				WHERE
					[AttributeId] = @AttributeId
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKUAttribute_GetBySKUID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKUAttribute_GetBySKUID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_GetBySKUID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeSKUAttribute table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_GetBySKUID
(

	@SKUID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[SKUAttributeID],
					[SKUID],
					[AttributeId]
				FROM
					dbo.[ZNodeSKUAttribute]
				WHERE
					[SKUID] = @SKUID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKUAttribute_GetBySKUAttributeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKUAttribute_GetBySKUAttributeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_GetBySKUAttributeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeSKUAttribute table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_GetBySKUAttributeID
(

	@SKUAttributeID int   
)
AS


				SELECT
					[SKUAttributeID],
					[SKUID],
					[AttributeId]
				FROM
					dbo.[ZNodeSKUAttribute]
				WHERE
					[SKUAttributeID] = @SKUAttributeID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKUAttribute_GetByAttributeIdSKUID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKUAttribute_GetByAttributeIdSKUID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_GetByAttributeIdSKUID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeSKUAttribute table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_GetByAttributeIdSKUID
(

	@AttributeId int   ,

	@SKUID int   
)
AS


				SELECT
					[SKUAttributeID],
					[SKUID],
					[AttributeId]
				FROM
					dbo.[ZNodeSKUAttribute]
				WHERE
					[AttributeId] = @AttributeId
					AND [SKUID] = @SKUID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKUAttribute_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKUAttribute_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeSKUAttribute table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKUAttribute_Find
(

	@SearchUsingOR bit   = null ,

	@SKUAttributeID int   = null ,

	@SKUID int   = null ,

	@AttributeId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SKUAttributeID]
	, [SKUID]
	, [AttributeId]
    FROM
	dbo.[ZNodeSKUAttribute]
    WHERE 
	 ([SKUAttributeID] = @SKUAttributeID OR @SKUAttributeID is null)
	AND ([SKUID] = @SKUID OR @SKUID is null)
	AND ([AttributeId] = @AttributeId OR @AttributeId is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SKUAttributeID]
	, [SKUID]
	, [AttributeId]
    FROM
	dbo.[ZNodeSKUAttribute]
    WHERE 
	 ([SKUAttributeID] = @SKUAttributeID AND @SKUAttributeID is not null)
	OR ([SKUID] = @SKUID AND @SKUID is not null)
	OR ([AttributeId] = @AttributeId AND @AttributeId is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeShippingType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingType_Get_List

AS


				
				SELECT
					[ShippingTypeID],
					[Name],
					[Description]
				FROM
					dbo.[ZNodeShippingType]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeShippingType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingType_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ShippingTypeID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ShippingTypeID]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeShippingType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ShippingTypeID],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Description]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeShippingType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingType_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeShippingType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingType_Insert
(

	@ShippingTypeID int   ,

	@Name varchar (50)  ,

	@Description text   
)
AS


					
				INSERT INTO dbo.[ZNodeShippingType]
					(
					[ShippingTypeID]
					,[Name]
					,[Description]
					)
				VALUES
					(
					@ShippingTypeID
					,@Name
					,@Description
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingType_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeShippingType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingType_Update
(

	@ShippingTypeID int   ,

	@OriginalShippingTypeID int   ,

	@Name varchar (50)  ,

	@Description text   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeShippingType]
				SET
					[ShippingTypeID] = @ShippingTypeID
					,[Name] = @Name
					,[Description] = @Description
				WHERE
[ShippingTypeID] = @OriginalShippingTypeID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingType_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeShippingType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingType_Delete
(

	@ShippingTypeID int   
)
AS


				DELETE FROM dbo.[ZNodeShippingType] WITH (ROWLOCK) 
				WHERE
					[ShippingTypeID] = @ShippingTypeID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingType_GetByShippingTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingType_GetByShippingTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingType_GetByShippingTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeShippingType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingType_GetByShippingTypeID
(

	@ShippingTypeID int   
)
AS


				SELECT
					[ShippingTypeID],
					[Name],
					[Description]
				FROM
					dbo.[ZNodeShippingType]
				WHERE
					[ShippingTypeID] = @ShippingTypeID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingType_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeShippingType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingType_Find
(

	@SearchUsingOR bit   = null ,

	@ShippingTypeID int   = null ,

	@Name varchar (50)  = null ,

	@Description text   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ShippingTypeID]
	, [Name]
	, [Description]
    FROM
	dbo.[ZNodeShippingType]
    WHERE 
	 ([ShippingTypeID] = @ShippingTypeID OR @ShippingTypeID is null)
	AND ([Name] = @Name OR @Name is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ShippingTypeID]
	, [Name]
	, [Description]
    FROM
	dbo.[ZNodeShippingType]
    WHERE 
	 ([ShippingTypeID] = @ShippingTypeID AND @ShippingTypeID is not null)
	OR ([Name] = @Name AND @Name is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeTaxRule_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeTaxRule_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeTaxRule table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_Get_List

AS


				
				SELECT
					[TaxRuleID],
					[PortalID],
					[TaxRate],
					[DestinationCountryCode],
					[DestinationStateCode],
					[Precedence]
				FROM
					dbo.[ZNodeTaxRule]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeTaxRule_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeTaxRule_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeTaxRule table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[TaxRuleID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [TaxRuleID]'
				SET @SQL = @SQL + ', [PortalID]'
				SET @SQL = @SQL + ', [TaxRate]'
				SET @SQL = @SQL + ', [DestinationCountryCode]'
				SET @SQL = @SQL + ', [DestinationStateCode]'
				SET @SQL = @SQL + ', [Precedence]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeTaxRule]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [TaxRuleID],'
				SET @SQL = @SQL + ' [PortalID],'
				SET @SQL = @SQL + ' [TaxRate],'
				SET @SQL = @SQL + ' [DestinationCountryCode],'
				SET @SQL = @SQL + ' [DestinationStateCode],'
				SET @SQL = @SQL + ' [Precedence]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeTaxRule]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeTaxRule_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeTaxRule_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeTaxRule table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_Insert
(

	@TaxRuleID int    OUTPUT,

	@PortalID int   ,

	@TaxRate decimal (18, 2)  ,

	@DestinationCountryCode varchar (2)  ,

	@DestinationStateCode varchar (2)  ,

	@Precedence int   
)
AS


					
				INSERT INTO dbo.[ZNodeTaxRule]
					(
					[PortalID]
					,[TaxRate]
					,[DestinationCountryCode]
					,[DestinationStateCode]
					,[Precedence]
					)
				VALUES
					(
					@PortalID
					,@TaxRate
					,@DestinationCountryCode
					,@DestinationStateCode
					,@Precedence
					)
				
				-- Get the identity value
				SET @TaxRuleID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeTaxRule_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeTaxRule_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeTaxRule table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_Update
(

	@TaxRuleID int   ,

	@PortalID int   ,

	@TaxRate decimal (18, 2)  ,

	@DestinationCountryCode varchar (2)  ,

	@DestinationStateCode varchar (2)  ,

	@Precedence int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeTaxRule]
				SET
					[PortalID] = @PortalID
					,[TaxRate] = @TaxRate
					,[DestinationCountryCode] = @DestinationCountryCode
					,[DestinationStateCode] = @DestinationStateCode
					,[Precedence] = @Precedence
				WHERE
[TaxRuleID] = @TaxRuleID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeTaxRule_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeTaxRule_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeTaxRule table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_Delete
(

	@TaxRuleID int   
)
AS


				DELETE FROM dbo.[ZNodeTaxRule] WITH (ROWLOCK) 
				WHERE
					[TaxRuleID] = @TaxRuleID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeTaxRule_GetByPortalID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeTaxRule_GetByPortalID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_GetByPortalID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeTaxRule table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_GetByPortalID
(

	@PortalID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[TaxRuleID],
					[PortalID],
					[TaxRate],
					[DestinationCountryCode],
					[DestinationStateCode],
					[Precedence]
				FROM
					dbo.[ZNodeTaxRule]
				WHERE
					[PortalID] = @PortalID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeTaxRule_GetByDestinationCountryCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeTaxRule_GetByDestinationCountryCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_GetByDestinationCountryCode
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeTaxRule table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_GetByDestinationCountryCode
(

	@DestinationCountryCode varchar (2)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[TaxRuleID],
					[PortalID],
					[TaxRate],
					[DestinationCountryCode],
					[DestinationStateCode],
					[Precedence]
				FROM
					dbo.[ZNodeTaxRule]
				WHERE
					[DestinationCountryCode] = @DestinationCountryCode
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeTaxRule_GetByTaxRuleID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeTaxRule_GetByTaxRuleID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_GetByTaxRuleID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeTaxRule table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_GetByTaxRuleID
(

	@TaxRuleID int   
)
AS


				SELECT
					[TaxRuleID],
					[PortalID],
					[TaxRate],
					[DestinationCountryCode],
					[DestinationStateCode],
					[Precedence]
				FROM
					dbo.[ZNodeTaxRule]
				WHERE
					[TaxRuleID] = @TaxRuleID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeTaxRule_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeTaxRule_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeTaxRule table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeTaxRule_Find
(

	@SearchUsingOR bit   = null ,

	@TaxRuleID int   = null ,

	@PortalID int   = null ,

	@TaxRate decimal (18, 2)  = null ,

	@DestinationCountryCode varchar (2)  = null ,

	@DestinationStateCode varchar (2)  = null ,

	@Precedence int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [TaxRuleID]
	, [PortalID]
	, [TaxRate]
	, [DestinationCountryCode]
	, [DestinationStateCode]
	, [Precedence]
    FROM
	dbo.[ZNodeTaxRule]
    WHERE 
	 ([TaxRuleID] = @TaxRuleID OR @TaxRuleID is null)
	AND ([PortalID] = @PortalID OR @PortalID is null)
	AND ([TaxRate] = @TaxRate OR @TaxRate is null)
	AND ([DestinationCountryCode] = @DestinationCountryCode OR @DestinationCountryCode is null)
	AND ([DestinationStateCode] = @DestinationStateCode OR @DestinationStateCode is null)
	AND ([Precedence] = @Precedence OR @Precedence is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [TaxRuleID]
	, [PortalID]
	, [TaxRate]
	, [DestinationCountryCode]
	, [DestinationStateCode]
	, [Precedence]
    FROM
	dbo.[ZNodeTaxRule]
    WHERE 
	 ([TaxRuleID] = @TaxRuleID AND @TaxRuleID is not null)
	OR ([PortalID] = @PortalID AND @PortalID is not null)
	OR ([TaxRate] = @TaxRate AND @TaxRate is not null)
	OR ([DestinationCountryCode] = @DestinationCountryCode AND @DestinationCountryCode is not null)
	OR ([DestinationStateCode] = @DestinationStateCode AND @DestinationStateCode is not null)
	OR ([Precedence] = @Precedence AND @Precedence is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccountType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccountType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccountType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeAccountType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccountType_Get_List

AS


				
				SELECT
					[AccountTypeID],
					[AccountTypeNme]
				FROM
					dbo.[ZNodeAccountType]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccountType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccountType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccountType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeAccountType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccountType_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[AccountTypeID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [AccountTypeID]'
				SET @SQL = @SQL + ', [AccountTypeNme]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeAccountType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AccountTypeID],'
				SET @SQL = @SQL + ' [AccountTypeNme]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeAccountType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccountType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccountType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccountType_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeAccountType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccountType_Insert
(

	@AccountTypeID int   ,

	@AccountTypeNme varchar (100)  
)
AS


					
				INSERT INTO dbo.[ZNodeAccountType]
					(
					[AccountTypeID]
					,[AccountTypeNme]
					)
				VALUES
					(
					@AccountTypeID
					,@AccountTypeNme
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccountType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccountType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccountType_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeAccountType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccountType_Update
(

	@AccountTypeID int   ,

	@OriginalAccountTypeID int   ,

	@AccountTypeNme varchar (100)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeAccountType]
				SET
					[AccountTypeID] = @AccountTypeID
					,[AccountTypeNme] = @AccountTypeNme
				WHERE
[AccountTypeID] = @OriginalAccountTypeID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccountType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccountType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccountType_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeAccountType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccountType_Delete
(

	@AccountTypeID int   
)
AS


				DELETE FROM dbo.[ZNodeAccountType] WITH (ROWLOCK) 
				WHERE
					[AccountTypeID] = @AccountTypeID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccountType_GetByAccountTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccountType_GetByAccountTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccountType_GetByAccountTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeAccountType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccountType_GetByAccountTypeID
(

	@AccountTypeID int   
)
AS


				SELECT
					[AccountTypeID],
					[AccountTypeNme]
				FROM
					dbo.[ZNodeAccountType]
				WHERE
					[AccountTypeID] = @AccountTypeID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccountType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccountType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccountType_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeAccountType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccountType_Find
(

	@SearchUsingOR bit   = null ,

	@AccountTypeID int   = null ,

	@AccountTypeNme varchar (100)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AccountTypeID]
	, [AccountTypeNme]
    FROM
	dbo.[ZNodeAccountType]
    WHERE 
	 ([AccountTypeID] = @AccountTypeID OR @AccountTypeID is null)
	AND ([AccountTypeNme] = @AccountTypeNme OR @AccountTypeNme is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AccountTypeID]
	, [AccountTypeNme]
    FROM
	dbo.[ZNodeAccountType]
    WHERE 
	 ([AccountTypeID] = @AccountTypeID AND @AccountTypeID is not null)
	OR ([AccountTypeNme] = @AccountTypeNme AND @AccountTypeNme is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeStore_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeStore_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeStore_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeStore table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeStore_Get_List

AS


				
				SELECT
					[StoreID],
					[Name],
					[Address1],
					[Address2],
					[Address3],
					[City],
					[State],
					[Zip],
					[Phone],
					[Fax],
					[ContactName],
					[ContactAddress1],
					[ContactAddress2],
					[ContactCity],
					[ContactState],
					[ContactZip],
					[ContactPhone],
					[IsDealer],
					[p1]
				FROM
					dbo.[ZNodeStore]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeStore_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeStore_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeStore_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeStore table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeStore_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[StoreID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [StoreID]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Address1]'
				SET @SQL = @SQL + ', [Address2]'
				SET @SQL = @SQL + ', [Address3]'
				SET @SQL = @SQL + ', [City]'
				SET @SQL = @SQL + ', [State]'
				SET @SQL = @SQL + ', [Zip]'
				SET @SQL = @SQL + ', [Phone]'
				SET @SQL = @SQL + ', [Fax]'
				SET @SQL = @SQL + ', [ContactName]'
				SET @SQL = @SQL + ', [ContactAddress1]'
				SET @SQL = @SQL + ', [ContactAddress2]'
				SET @SQL = @SQL + ', [ContactCity]'
				SET @SQL = @SQL + ', [ContactState]'
				SET @SQL = @SQL + ', [ContactZip]'
				SET @SQL = @SQL + ', [ContactPhone]'
				SET @SQL = @SQL + ', [IsDealer]'
				SET @SQL = @SQL + ', [p1]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeStore]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [StoreID],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Address1],'
				SET @SQL = @SQL + ' [Address2],'
				SET @SQL = @SQL + ' [Address3],'
				SET @SQL = @SQL + ' [City],'
				SET @SQL = @SQL + ' [State],'
				SET @SQL = @SQL + ' [Zip],'
				SET @SQL = @SQL + ' [Phone],'
				SET @SQL = @SQL + ' [Fax],'
				SET @SQL = @SQL + ' [ContactName],'
				SET @SQL = @SQL + ' [ContactAddress1],'
				SET @SQL = @SQL + ' [ContactAddress2],'
				SET @SQL = @SQL + ' [ContactCity],'
				SET @SQL = @SQL + ' [ContactState],'
				SET @SQL = @SQL + ' [ContactZip],'
				SET @SQL = @SQL + ' [ContactPhone],'
				SET @SQL = @SQL + ' [IsDealer],'
				SET @SQL = @SQL + ' [p1]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeStore]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeStore_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeStore_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeStore_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeStore table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeStore_Insert
(

	@StoreID int   ,

	@Name varchar (255)  ,

	@Address1 varchar (255)  ,

	@Address2 varchar (255)  ,

	@Address3 varchar (255)  ,

	@City varchar (255)  ,

	@State char (2)  ,

	@Zip varchar (10)  ,

	@Phone varchar (15)  ,

	@Fax varchar (15)  ,

	@ContactName varchar (255)  ,

	@ContactAddress1 varchar (255)  ,

	@ContactAddress2 varchar (255)  ,

	@ContactCity varchar (255)  ,

	@ContactState char (2)  ,

	@ContactZip varchar (10)  ,

	@ContactPhone varchar (15)  ,

	@IsDealer char (1)  ,

	@P1 varchar (50)  
)
AS


					
				INSERT INTO dbo.[ZNodeStore]
					(
					[StoreID]
					,[Name]
					,[Address1]
					,[Address2]
					,[Address3]
					,[City]
					,[State]
					,[Zip]
					,[Phone]
					,[Fax]
					,[ContactName]
					,[ContactAddress1]
					,[ContactAddress2]
					,[ContactCity]
					,[ContactState]
					,[ContactZip]
					,[ContactPhone]
					,[IsDealer]
					,[p1]
					)
				VALUES
					(
					@StoreID
					,@Name
					,@Address1
					,@Address2
					,@Address3
					,@City
					,@State
					,@Zip
					,@Phone
					,@Fax
					,@ContactName
					,@ContactAddress1
					,@ContactAddress2
					,@ContactCity
					,@ContactState
					,@ContactZip
					,@ContactPhone
					,@IsDealer
					,@P1
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeStore_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeStore_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeStore_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeStore table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeStore_Update
(

	@StoreID int   ,

	@OriginalStoreID int   ,

	@Name varchar (255)  ,

	@Address1 varchar (255)  ,

	@Address2 varchar (255)  ,

	@Address3 varchar (255)  ,

	@City varchar (255)  ,

	@State char (2)  ,

	@Zip varchar (10)  ,

	@Phone varchar (15)  ,

	@Fax varchar (15)  ,

	@ContactName varchar (255)  ,

	@ContactAddress1 varchar (255)  ,

	@ContactAddress2 varchar (255)  ,

	@ContactCity varchar (255)  ,

	@ContactState char (2)  ,

	@ContactZip varchar (10)  ,

	@ContactPhone varchar (15)  ,

	@IsDealer char (1)  ,

	@P1 varchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeStore]
				SET
					[StoreID] = @StoreID
					,[Name] = @Name
					,[Address1] = @Address1
					,[Address2] = @Address2
					,[Address3] = @Address3
					,[City] = @City
					,[State] = @State
					,[Zip] = @Zip
					,[Phone] = @Phone
					,[Fax] = @Fax
					,[ContactName] = @ContactName
					,[ContactAddress1] = @ContactAddress1
					,[ContactAddress2] = @ContactAddress2
					,[ContactCity] = @ContactCity
					,[ContactState] = @ContactState
					,[ContactZip] = @ContactZip
					,[ContactPhone] = @ContactPhone
					,[IsDealer] = @IsDealer
					,[p1] = @P1
				WHERE
[StoreID] = @OriginalStoreID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeStore_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeStore_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeStore_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeStore table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeStore_Delete
(

	@StoreID int   
)
AS


				DELETE FROM dbo.[ZNodeStore] WITH (ROWLOCK) 
				WHERE
					[StoreID] = @StoreID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeStore_GetByStoreID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeStore_GetByStoreID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeStore_GetByStoreID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeStore table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeStore_GetByStoreID
(

	@StoreID int   
)
AS


				SELECT
					[StoreID],
					[Name],
					[Address1],
					[Address2],
					[Address3],
					[City],
					[State],
					[Zip],
					[Phone],
					[Fax],
					[ContactName],
					[ContactAddress1],
					[ContactAddress2],
					[ContactCity],
					[ContactState],
					[ContactZip],
					[ContactPhone],
					[IsDealer],
					[p1]
				FROM
					dbo.[ZNodeStore]
				WHERE
					[StoreID] = @StoreID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeStore_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeStore_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeStore_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeStore table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeStore_Find
(

	@SearchUsingOR bit   = null ,

	@StoreID int   = null ,

	@Name varchar (255)  = null ,

	@Address1 varchar (255)  = null ,

	@Address2 varchar (255)  = null ,

	@Address3 varchar (255)  = null ,

	@City varchar (255)  = null ,

	@State char (2)  = null ,

	@Zip varchar (10)  = null ,

	@Phone varchar (15)  = null ,

	@Fax varchar (15)  = null ,

	@ContactName varchar (255)  = null ,

	@ContactAddress1 varchar (255)  = null ,

	@ContactAddress2 varchar (255)  = null ,

	@ContactCity varchar (255)  = null ,

	@ContactState char (2)  = null ,

	@ContactZip varchar (10)  = null ,

	@ContactPhone varchar (15)  = null ,

	@IsDealer char (1)  = null ,

	@P1 varchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [StoreID]
	, [Name]
	, [Address1]
	, [Address2]
	, [Address3]
	, [City]
	, [State]
	, [Zip]
	, [Phone]
	, [Fax]
	, [ContactName]
	, [ContactAddress1]
	, [ContactAddress2]
	, [ContactCity]
	, [ContactState]
	, [ContactZip]
	, [ContactPhone]
	, [IsDealer]
	, [p1]
    FROM
	dbo.[ZNodeStore]
    WHERE 
	 ([StoreID] = @StoreID OR @StoreID is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([Address1] = @Address1 OR @Address1 is null)
	AND ([Address2] = @Address2 OR @Address2 is null)
	AND ([Address3] = @Address3 OR @Address3 is null)
	AND ([City] = @City OR @City is null)
	AND ([State] = @State OR @State is null)
	AND ([Zip] = @Zip OR @Zip is null)
	AND ([Phone] = @Phone OR @Phone is null)
	AND ([Fax] = @Fax OR @Fax is null)
	AND ([ContactName] = @ContactName OR @ContactName is null)
	AND ([ContactAddress1] = @ContactAddress1 OR @ContactAddress1 is null)
	AND ([ContactAddress2] = @ContactAddress2 OR @ContactAddress2 is null)
	AND ([ContactCity] = @ContactCity OR @ContactCity is null)
	AND ([ContactState] = @ContactState OR @ContactState is null)
	AND ([ContactZip] = @ContactZip OR @ContactZip is null)
	AND ([ContactPhone] = @ContactPhone OR @ContactPhone is null)
	AND ([IsDealer] = @IsDealer OR @IsDealer is null)
	AND ([p1] = @P1 OR @P1 is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [StoreID]
	, [Name]
	, [Address1]
	, [Address2]
	, [Address3]
	, [City]
	, [State]
	, [Zip]
	, [Phone]
	, [Fax]
	, [ContactName]
	, [ContactAddress1]
	, [ContactAddress2]
	, [ContactCity]
	, [ContactState]
	, [ContactZip]
	, [ContactPhone]
	, [IsDealer]
	, [p1]
    FROM
	dbo.[ZNodeStore]
    WHERE 
	 ([StoreID] = @StoreID AND @StoreID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Address1] = @Address1 AND @Address1 is not null)
	OR ([Address2] = @Address2 AND @Address2 is not null)
	OR ([Address3] = @Address3 AND @Address3 is not null)
	OR ([City] = @City AND @City is not null)
	OR ([State] = @State AND @State is not null)
	OR ([Zip] = @Zip AND @Zip is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([Fax] = @Fax AND @Fax is not null)
	OR ([ContactName] = @ContactName AND @ContactName is not null)
	OR ([ContactAddress1] = @ContactAddress1 AND @ContactAddress1 is not null)
	OR ([ContactAddress2] = @ContactAddress2 AND @ContactAddress2 is not null)
	OR ([ContactCity] = @ContactCity AND @ContactCity is not null)
	OR ([ContactState] = @ContactState AND @ContactState is not null)
	OR ([ContactZip] = @ContactZip AND @ContactZip is not null)
	OR ([ContactPhone] = @ContactPhone AND @ContactPhone is not null)
	OR ([IsDealer] = @IsDealer AND @IsDealer is not null)
	OR ([p1] = @P1 AND @P1 is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKU_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKU_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKU_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeSKU table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKU_Get_List

AS


				
				SELECT
					[SKUID],
					[ProductID],
					[SKU],
					[WarehouseNo],
					[Note],
					[QuantityOnHand],
					[ReorderLevel],
					[WeightAdditional],
					[SKUPicturePath],
					[DisplayOrder],
					[RetailPriceAdditional],
					[WholesalePriceAdditional],
					[ActiveInd],
					[Custom1],
					[Custom2],
					[Custom3]
				FROM
					dbo.[ZNodeSKU]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKU_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKU_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKU_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeSKU table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKU_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[SKUID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [SKUID]'
				SET @SQL = @SQL + ', [ProductID]'
				SET @SQL = @SQL + ', [SKU]'
				SET @SQL = @SQL + ', [WarehouseNo]'
				SET @SQL = @SQL + ', [Note]'
				SET @SQL = @SQL + ', [QuantityOnHand]'
				SET @SQL = @SQL + ', [ReorderLevel]'
				SET @SQL = @SQL + ', [WeightAdditional]'
				SET @SQL = @SQL + ', [SKUPicturePath]'
				SET @SQL = @SQL + ', [DisplayOrder]'
				SET @SQL = @SQL + ', [RetailPriceAdditional]'
				SET @SQL = @SQL + ', [WholesalePriceAdditional]'
				SET @SQL = @SQL + ', [ActiveInd]'
				SET @SQL = @SQL + ', [Custom1]'
				SET @SQL = @SQL + ', [Custom2]'
				SET @SQL = @SQL + ', [Custom3]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeSKU]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [SKUID],'
				SET @SQL = @SQL + ' [ProductID],'
				SET @SQL = @SQL + ' [SKU],'
				SET @SQL = @SQL + ' [WarehouseNo],'
				SET @SQL = @SQL + ' [Note],'
				SET @SQL = @SQL + ' [QuantityOnHand],'
				SET @SQL = @SQL + ' [ReorderLevel],'
				SET @SQL = @SQL + ' [WeightAdditional],'
				SET @SQL = @SQL + ' [SKUPicturePath],'
				SET @SQL = @SQL + ' [DisplayOrder],'
				SET @SQL = @SQL + ' [RetailPriceAdditional],'
				SET @SQL = @SQL + ' [WholesalePriceAdditional],'
				SET @SQL = @SQL + ' [ActiveInd],'
				SET @SQL = @SQL + ' [Custom1],'
				SET @SQL = @SQL + ' [Custom2],'
				SET @SQL = @SQL + ' [Custom3]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeSKU]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKU_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKU_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKU_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeSKU table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKU_Insert
(

	@SKUID int    OUTPUT,

	@ProductID int   ,

	@SKU nvarchar (MAX)  ,

	@WarehouseNo int   ,

	@Note nvarchar (MAX)  ,

	@QuantityOnHand int   ,

	@ReorderLevel int   ,

	@WeightAdditional decimal (10, 2)  ,

	@SKUPicturePath nvarchar (MAX)  ,

	@DisplayOrder int   ,

	@RetailPriceAdditional money   ,

	@WholesalePriceAdditional money   ,

	@ActiveInd bit   ,

	@Custom1 varchar (MAX)  ,

	@Custom2 varchar (MAX)  ,

	@Custom3 varchar (MAX)  
)
AS


					
				INSERT INTO dbo.[ZNodeSKU]
					(
					[ProductID]
					,[SKU]
					,[WarehouseNo]
					,[Note]
					,[QuantityOnHand]
					,[ReorderLevel]
					,[WeightAdditional]
					,[SKUPicturePath]
					,[DisplayOrder]
					,[RetailPriceAdditional]
					,[WholesalePriceAdditional]
					,[ActiveInd]
					,[Custom1]
					,[Custom2]
					,[Custom3]
					)
				VALUES
					(
					@ProductID
					,@SKU
					,@WarehouseNo
					,@Note
					,@QuantityOnHand
					,@ReorderLevel
					,@WeightAdditional
					,@SKUPicturePath
					,@DisplayOrder
					,@RetailPriceAdditional
					,@WholesalePriceAdditional
					,@ActiveInd
					,@Custom1
					,@Custom2
					,@Custom3
					)
				
				-- Get the identity value
				SET @SKUID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKU_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKU_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKU_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeSKU table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKU_Update
(

	@SKUID int   ,

	@ProductID int   ,

	@SKU nvarchar (MAX)  ,

	@WarehouseNo int   ,

	@Note nvarchar (MAX)  ,

	@QuantityOnHand int   ,

	@ReorderLevel int   ,

	@WeightAdditional decimal (10, 2)  ,

	@SKUPicturePath nvarchar (MAX)  ,

	@DisplayOrder int   ,

	@RetailPriceAdditional money   ,

	@WholesalePriceAdditional money   ,

	@ActiveInd bit   ,

	@Custom1 varchar (MAX)  ,

	@Custom2 varchar (MAX)  ,

	@Custom3 varchar (MAX)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeSKU]
				SET
					[ProductID] = @ProductID
					,[SKU] = @SKU
					,[WarehouseNo] = @WarehouseNo
					,[Note] = @Note
					,[QuantityOnHand] = @QuantityOnHand
					,[ReorderLevel] = @ReorderLevel
					,[WeightAdditional] = @WeightAdditional
					,[SKUPicturePath] = @SKUPicturePath
					,[DisplayOrder] = @DisplayOrder
					,[RetailPriceAdditional] = @RetailPriceAdditional
					,[WholesalePriceAdditional] = @WholesalePriceAdditional
					,[ActiveInd] = @ActiveInd
					,[Custom1] = @Custom1
					,[Custom2] = @Custom2
					,[Custom3] = @Custom3
				WHERE
[SKUID] = @SKUID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKU_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKU_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKU_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeSKU table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKU_Delete
(

	@SKUID int   
)
AS


				DELETE FROM dbo.[ZNodeSKU] WITH (ROWLOCK) 
				WHERE
					[SKUID] = @SKUID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKU_GetBySKUID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKU_GetBySKUID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKU_GetBySKUID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeSKU table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKU_GetBySKUID
(

	@SKUID int   
)
AS


				SELECT
					[SKUID],
					[ProductID],
					[SKU],
					[WarehouseNo],
					[Note],
					[QuantityOnHand],
					[ReorderLevel],
					[WeightAdditional],
					[SKUPicturePath],
					[DisplayOrder],
					[RetailPriceAdditional],
					[WholesalePriceAdditional],
					[ActiveInd],
					[Custom1],
					[Custom2],
					[Custom3]
				FROM
					dbo.[ZNodeSKU]
				WHERE
					[SKUID] = @SKUID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKU_GetByProductID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKU_GetByProductID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKU_GetByProductID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeSKU table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKU_GetByProductID
(

	@ProductID int   
)
AS


				SELECT
					[SKUID],
					[ProductID],
					[SKU],
					[WarehouseNo],
					[Note],
					[QuantityOnHand],
					[ReorderLevel],
					[WeightAdditional],
					[SKUPicturePath],
					[DisplayOrder],
					[RetailPriceAdditional],
					[WholesalePriceAdditional],
					[ActiveInd],
					[Custom1],
					[Custom2],
					[Custom3]
				FROM
					dbo.[ZNodeSKU]
				WHERE
					[ProductID] = @ProductID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeSKU_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeSKU_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeSKU_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeSKU table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeSKU_Find
(

	@SearchUsingOR bit   = null ,

	@SKUID int   = null ,

	@ProductID int   = null ,

	@SKU nvarchar (MAX)  = null ,

	@WarehouseNo int   = null ,

	@Note nvarchar (MAX)  = null ,

	@QuantityOnHand int   = null ,

	@ReorderLevel int   = null ,

	@WeightAdditional decimal (10, 2)  = null ,

	@SKUPicturePath nvarchar (MAX)  = null ,

	@DisplayOrder int   = null ,

	@RetailPriceAdditional money   = null ,

	@WholesalePriceAdditional money   = null ,

	@ActiveInd bit   = null ,

	@Custom1 varchar (MAX)  = null ,

	@Custom2 varchar (MAX)  = null ,

	@Custom3 varchar (MAX)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SKUID]
	, [ProductID]
	, [SKU]
	, [WarehouseNo]
	, [Note]
	, [QuantityOnHand]
	, [ReorderLevel]
	, [WeightAdditional]
	, [SKUPicturePath]
	, [DisplayOrder]
	, [RetailPriceAdditional]
	, [WholesalePriceAdditional]
	, [ActiveInd]
	, [Custom1]
	, [Custom2]
	, [Custom3]
    FROM
	dbo.[ZNodeSKU]
    WHERE 
	 ([SKUID] = @SKUID OR @SKUID is null)
	AND ([ProductID] = @ProductID OR @ProductID is null)
	AND ([SKU] = @SKU OR @SKU is null)
	AND ([WarehouseNo] = @WarehouseNo OR @WarehouseNo is null)
	AND ([Note] = @Note OR @Note is null)
	AND ([QuantityOnHand] = @QuantityOnHand OR @QuantityOnHand is null)
	AND ([ReorderLevel] = @ReorderLevel OR @ReorderLevel is null)
	AND ([WeightAdditional] = @WeightAdditional OR @WeightAdditional is null)
	AND ([SKUPicturePath] = @SKUPicturePath OR @SKUPicturePath is null)
	AND ([DisplayOrder] = @DisplayOrder OR @DisplayOrder is null)
	AND ([RetailPriceAdditional] = @RetailPriceAdditional OR @RetailPriceAdditional is null)
	AND ([WholesalePriceAdditional] = @WholesalePriceAdditional OR @WholesalePriceAdditional is null)
	AND ([ActiveInd] = @ActiveInd OR @ActiveInd is null)
	AND ([Custom1] = @Custom1 OR @Custom1 is null)
	AND ([Custom2] = @Custom2 OR @Custom2 is null)
	AND ([Custom3] = @Custom3 OR @Custom3 is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SKUID]
	, [ProductID]
	, [SKU]
	, [WarehouseNo]
	, [Note]
	, [QuantityOnHand]
	, [ReorderLevel]
	, [WeightAdditional]
	, [SKUPicturePath]
	, [DisplayOrder]
	, [RetailPriceAdditional]
	, [WholesalePriceAdditional]
	, [ActiveInd]
	, [Custom1]
	, [Custom2]
	, [Custom3]
    FROM
	dbo.[ZNodeSKU]
    WHERE 
	 ([SKUID] = @SKUID AND @SKUID is not null)
	OR ([ProductID] = @ProductID AND @ProductID is not null)
	OR ([SKU] = @SKU AND @SKU is not null)
	OR ([WarehouseNo] = @WarehouseNo AND @WarehouseNo is not null)
	OR ([Note] = @Note AND @Note is not null)
	OR ([QuantityOnHand] = @QuantityOnHand AND @QuantityOnHand is not null)
	OR ([ReorderLevel] = @ReorderLevel AND @ReorderLevel is not null)
	OR ([WeightAdditional] = @WeightAdditional AND @WeightAdditional is not null)
	OR ([SKUPicturePath] = @SKUPicturePath AND @SKUPicturePath is not null)
	OR ([DisplayOrder] = @DisplayOrder AND @DisplayOrder is not null)
	OR ([RetailPriceAdditional] = @RetailPriceAdditional AND @RetailPriceAdditional is not null)
	OR ([WholesalePriceAdditional] = @WholesalePriceAdditional AND @WholesalePriceAdditional is not null)
	OR ([ActiveInd] = @ActiveInd AND @ActiveInd is not null)
	OR ([Custom1] = @Custom1 AND @Custom1 is not null)
	OR ([Custom2] = @Custom2 AND @Custom2 is not null)
	OR ([Custom3] = @Custom3 AND @Custom3 is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContactTemperature_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContactTemperature_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContactTemperature_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeContactTemperature table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContactTemperature_Get_List

AS


				
				SELECT
					[ContactTemperatureID],
					[Name]
				FROM
					dbo.[ZNodeContactTemperature]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContactTemperature_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContactTemperature_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContactTemperature_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeContactTemperature table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContactTemperature_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ContactTemperatureID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ContactTemperatureID]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeContactTemperature]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ContactTemperatureID],'
				SET @SQL = @SQL + ' [Name]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeContactTemperature]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContactTemperature_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContactTemperature_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContactTemperature_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeContactTemperature table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContactTemperature_Insert
(

	@ContactTemperatureID int   ,

	@Name varchar (50)  
)
AS


					
				INSERT INTO dbo.[ZNodeContactTemperature]
					(
					[ContactTemperatureID]
					,[Name]
					)
				VALUES
					(
					@ContactTemperatureID
					,@Name
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContactTemperature_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContactTemperature_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContactTemperature_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeContactTemperature table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContactTemperature_Update
(

	@ContactTemperatureID int   ,

	@OriginalContactTemperatureID int   ,

	@Name varchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeContactTemperature]
				SET
					[ContactTemperatureID] = @ContactTemperatureID
					,[Name] = @Name
				WHERE
[ContactTemperatureID] = @OriginalContactTemperatureID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContactTemperature_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContactTemperature_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContactTemperature_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeContactTemperature table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContactTemperature_Delete
(

	@ContactTemperatureID int   
)
AS


				DELETE FROM dbo.[ZNodeContactTemperature] WITH (ROWLOCK) 
				WHERE
					[ContactTemperatureID] = @ContactTemperatureID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContactTemperature_GetByContactTemperatureID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContactTemperature_GetByContactTemperatureID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContactTemperature_GetByContactTemperatureID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeContactTemperature table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContactTemperature_GetByContactTemperatureID
(

	@ContactTemperatureID int   
)
AS


				SELECT
					[ContactTemperatureID],
					[Name]
				FROM
					dbo.[ZNodeContactTemperature]
				WHERE
					[ContactTemperatureID] = @ContactTemperatureID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContactTemperature_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContactTemperature_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContactTemperature_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeContactTemperature table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContactTemperature_Find
(

	@SearchUsingOR bit   = null ,

	@ContactTemperatureID int   = null ,

	@Name varchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ContactTemperatureID]
	, [Name]
    FROM
	dbo.[ZNodeContactTemperature]
    WHERE 
	 ([ContactTemperatureID] = @ContactTemperatureID OR @ContactTemperatureID is null)
	AND ([Name] = @Name OR @Name is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ContactTemperatureID]
	, [Name]
    FROM
	dbo.[ZNodeContactTemperature]
    WHERE 
	 ([ContactTemperatureID] = @ContactTemperatureID AND @ContactTemperatureID is not null)
	OR ([Name] = @Name AND @Name is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShipping_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShipping_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShipping_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeShipping table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShipping_Get_List

AS


				
				SELECT
					[ShippingID],
					[ShippingTypeID],
					[ProfileID],
					[ShippingCode],
					[HandlingCharge],
					[DestinationCountryCode],
					[Description],
					[ActiveInd],
					[DisplayOrder]
				FROM
					dbo.[ZNodeShipping]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShipping_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShipping_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShipping_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeShipping table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShipping_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ShippingID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ShippingID]'
				SET @SQL = @SQL + ', [ShippingTypeID]'
				SET @SQL = @SQL + ', [ProfileID]'
				SET @SQL = @SQL + ', [ShippingCode]'
				SET @SQL = @SQL + ', [HandlingCharge]'
				SET @SQL = @SQL + ', [DestinationCountryCode]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [ActiveInd]'
				SET @SQL = @SQL + ', [DisplayOrder]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeShipping]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ShippingID],'
				SET @SQL = @SQL + ' [ShippingTypeID],'
				SET @SQL = @SQL + ' [ProfileID],'
				SET @SQL = @SQL + ' [ShippingCode],'
				SET @SQL = @SQL + ' [HandlingCharge],'
				SET @SQL = @SQL + ' [DestinationCountryCode],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [ActiveInd],'
				SET @SQL = @SQL + ' [DisplayOrder]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeShipping]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShipping_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShipping_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShipping_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeShipping table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShipping_Insert
(

	@ShippingID int    OUTPUT,

	@ShippingTypeID int   ,

	@ProfileID int   ,

	@ShippingCode nvarchar (MAX)  ,

	@HandlingCharge smallmoney   ,

	@DestinationCountryCode varchar (2)  ,

	@Description nvarchar (MAX)  ,

	@ActiveInd bit   ,

	@DisplayOrder int   
)
AS


					
				INSERT INTO dbo.[ZNodeShipping]
					(
					[ShippingTypeID]
					,[ProfileID]
					,[ShippingCode]
					,[HandlingCharge]
					,[DestinationCountryCode]
					,[Description]
					,[ActiveInd]
					,[DisplayOrder]
					)
				VALUES
					(
					@ShippingTypeID
					,@ProfileID
					,@ShippingCode
					,@HandlingCharge
					,@DestinationCountryCode
					,@Description
					,@ActiveInd
					,@DisplayOrder
					)
				
				-- Get the identity value
				SET @ShippingID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShipping_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShipping_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShipping_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeShipping table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShipping_Update
(

	@ShippingID int   ,

	@ShippingTypeID int   ,

	@ProfileID int   ,

	@ShippingCode nvarchar (MAX)  ,

	@HandlingCharge smallmoney   ,

	@DestinationCountryCode varchar (2)  ,

	@Description nvarchar (MAX)  ,

	@ActiveInd bit   ,

	@DisplayOrder int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeShipping]
				SET
					[ShippingTypeID] = @ShippingTypeID
					,[ProfileID] = @ProfileID
					,[ShippingCode] = @ShippingCode
					,[HandlingCharge] = @HandlingCharge
					,[DestinationCountryCode] = @DestinationCountryCode
					,[Description] = @Description
					,[ActiveInd] = @ActiveInd
					,[DisplayOrder] = @DisplayOrder
				WHERE
[ShippingID] = @ShippingID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShipping_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShipping_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShipping_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeShipping table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShipping_Delete
(

	@ShippingID int   
)
AS


				DELETE FROM dbo.[ZNodeShipping] WITH (ROWLOCK) 
				WHERE
					[ShippingID] = @ShippingID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShipping_GetByDestinationCountryCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShipping_GetByDestinationCountryCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShipping_GetByDestinationCountryCode
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeShipping table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShipping_GetByDestinationCountryCode
(

	@DestinationCountryCode varchar (2)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ShippingID],
					[ShippingTypeID],
					[ProfileID],
					[ShippingCode],
					[HandlingCharge],
					[DestinationCountryCode],
					[Description],
					[ActiveInd],
					[DisplayOrder]
				FROM
					dbo.[ZNodeShipping]
				WHERE
					[DestinationCountryCode] = @DestinationCountryCode
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShipping_GetByShippingID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShipping_GetByShippingID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShipping_GetByShippingID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeShipping table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShipping_GetByShippingID
(

	@ShippingID int   
)
AS


				SELECT
					[ShippingID],
					[ShippingTypeID],
					[ProfileID],
					[ShippingCode],
					[HandlingCharge],
					[DestinationCountryCode],
					[Description],
					[ActiveInd],
					[DisplayOrder]
				FROM
					dbo.[ZNodeShipping]
				WHERE
					[ShippingID] = @ShippingID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShipping_GetByShippingTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShipping_GetByShippingTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShipping_GetByShippingTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeShipping table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShipping_GetByShippingTypeID
(

	@ShippingTypeID int   
)
AS


				SELECT
					[ShippingID],
					[ShippingTypeID],
					[ProfileID],
					[ShippingCode],
					[HandlingCharge],
					[DestinationCountryCode],
					[Description],
					[ActiveInd],
					[DisplayOrder]
				FROM
					dbo.[ZNodeShipping]
				WHERE
					[ShippingTypeID] = @ShippingTypeID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShipping_GetByProfileID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShipping_GetByProfileID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShipping_GetByProfileID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeShipping table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShipping_GetByProfileID
(

	@ProfileID int   
)
AS


				SELECT
					[ShippingID],
					[ShippingTypeID],
					[ProfileID],
					[ShippingCode],
					[HandlingCharge],
					[DestinationCountryCode],
					[Description],
					[ActiveInd],
					[DisplayOrder]
				FROM
					dbo.[ZNodeShipping]
				WHERE
					[ProfileID] = @ProfileID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShipping_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShipping_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShipping_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeShipping table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShipping_Find
(

	@SearchUsingOR bit   = null ,

	@ShippingID int   = null ,

	@ShippingTypeID int   = null ,

	@ProfileID int   = null ,

	@ShippingCode nvarchar (MAX)  = null ,

	@HandlingCharge smallmoney   = null ,

	@DestinationCountryCode varchar (2)  = null ,

	@Description nvarchar (MAX)  = null ,

	@ActiveInd bit   = null ,

	@DisplayOrder int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ShippingID]
	, [ShippingTypeID]
	, [ProfileID]
	, [ShippingCode]
	, [HandlingCharge]
	, [DestinationCountryCode]
	, [Description]
	, [ActiveInd]
	, [DisplayOrder]
    FROM
	dbo.[ZNodeShipping]
    WHERE 
	 ([ShippingID] = @ShippingID OR @ShippingID is null)
	AND ([ShippingTypeID] = @ShippingTypeID OR @ShippingTypeID is null)
	AND ([ProfileID] = @ProfileID OR @ProfileID is null)
	AND ([ShippingCode] = @ShippingCode OR @ShippingCode is null)
	AND ([HandlingCharge] = @HandlingCharge OR @HandlingCharge is null)
	AND ([DestinationCountryCode] = @DestinationCountryCode OR @DestinationCountryCode is null)
	AND ([Description] = @Description OR @Description is null)
	AND ([ActiveInd] = @ActiveInd OR @ActiveInd is null)
	AND ([DisplayOrder] = @DisplayOrder OR @DisplayOrder is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ShippingID]
	, [ShippingTypeID]
	, [ProfileID]
	, [ShippingCode]
	, [HandlingCharge]
	, [DestinationCountryCode]
	, [Description]
	, [ActiveInd]
	, [DisplayOrder]
    FROM
	dbo.[ZNodeShipping]
    WHERE 
	 ([ShippingID] = @ShippingID AND @ShippingID is not null)
	OR ([ShippingTypeID] = @ShippingTypeID AND @ShippingTypeID is not null)
	OR ([ProfileID] = @ProfileID AND @ProfileID is not null)
	OR ([ShippingCode] = @ShippingCode AND @ShippingCode is not null)
	OR ([HandlingCharge] = @HandlingCharge AND @HandlingCharge is not null)
	OR ([DestinationCountryCode] = @DestinationCountryCode AND @DestinationCountryCode is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([ActiveInd] = @ActiveInd AND @ActiveInd is not null)
	OR ([DisplayOrder] = @DisplayOrder AND @DisplayOrder is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRule_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRule_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeShippingRule table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_Get_List

AS


				
				SELECT
					[ShippingRuleID],
					[ShippingID],
					[ShippingRuleTypeID],
					[LowerLimit],
					[UpperLimit],
					[BaseCost],
					[PerItemCost]
				FROM
					dbo.[ZNodeShippingRule]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRule_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRule_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeShippingRule table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ShippingRuleID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ShippingRuleID]'
				SET @SQL = @SQL + ', [ShippingID]'
				SET @SQL = @SQL + ', [ShippingRuleTypeID]'
				SET @SQL = @SQL + ', [LowerLimit]'
				SET @SQL = @SQL + ', [UpperLimit]'
				SET @SQL = @SQL + ', [BaseCost]'
				SET @SQL = @SQL + ', [PerItemCost]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeShippingRule]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ShippingRuleID],'
				SET @SQL = @SQL + ' [ShippingID],'
				SET @SQL = @SQL + ' [ShippingRuleTypeID],'
				SET @SQL = @SQL + ' [LowerLimit],'
				SET @SQL = @SQL + ' [UpperLimit],'
				SET @SQL = @SQL + ' [BaseCost],'
				SET @SQL = @SQL + ' [PerItemCost]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeShippingRule]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRule_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRule_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeShippingRule table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_Insert
(

	@ShippingRuleID int    OUTPUT,

	@ShippingID int   ,

	@ShippingRuleTypeID int   ,

	@LowerLimit decimal (18, 2)  ,

	@UpperLimit decimal (18, 2)  ,

	@BaseCost smallmoney   ,

	@PerItemCost smallmoney   
)
AS


					
				INSERT INTO dbo.[ZNodeShippingRule]
					(
					[ShippingID]
					,[ShippingRuleTypeID]
					,[LowerLimit]
					,[UpperLimit]
					,[BaseCost]
					,[PerItemCost]
					)
				VALUES
					(
					@ShippingID
					,@ShippingRuleTypeID
					,@LowerLimit
					,@UpperLimit
					,@BaseCost
					,@PerItemCost
					)
				
				-- Get the identity value
				SET @ShippingRuleID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRule_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRule_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeShippingRule table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_Update
(

	@ShippingRuleID int   ,

	@ShippingID int   ,

	@ShippingRuleTypeID int   ,

	@LowerLimit decimal (18, 2)  ,

	@UpperLimit decimal (18, 2)  ,

	@BaseCost smallmoney   ,

	@PerItemCost smallmoney   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeShippingRule]
				SET
					[ShippingID] = @ShippingID
					,[ShippingRuleTypeID] = @ShippingRuleTypeID
					,[LowerLimit] = @LowerLimit
					,[UpperLimit] = @UpperLimit
					,[BaseCost] = @BaseCost
					,[PerItemCost] = @PerItemCost
				WHERE
[ShippingRuleID] = @ShippingRuleID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRule_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRule_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeShippingRule table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_Delete
(

	@ShippingRuleID int   
)
AS


				DELETE FROM dbo.[ZNodeShippingRule] WITH (ROWLOCK) 
				WHERE
					[ShippingRuleID] = @ShippingRuleID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRule_GetByShippingRuleTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRule_GetByShippingRuleTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_GetByShippingRuleTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeShippingRule table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_GetByShippingRuleTypeID
(

	@ShippingRuleTypeID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ShippingRuleID],
					[ShippingID],
					[ShippingRuleTypeID],
					[LowerLimit],
					[UpperLimit],
					[BaseCost],
					[PerItemCost]
				FROM
					dbo.[ZNodeShippingRule]
				WHERE
					[ShippingRuleTypeID] = @ShippingRuleTypeID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRule_GetByShippingRuleID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRule_GetByShippingRuleID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_GetByShippingRuleID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeShippingRule table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_GetByShippingRuleID
(

	@ShippingRuleID int   
)
AS


				SELECT
					[ShippingRuleID],
					[ShippingID],
					[ShippingRuleTypeID],
					[LowerLimit],
					[UpperLimit],
					[BaseCost],
					[PerItemCost]
				FROM
					dbo.[ZNodeShippingRule]
				WHERE
					[ShippingRuleID] = @ShippingRuleID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRule_GetByShippingID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRule_GetByShippingID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_GetByShippingID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeShippingRule table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_GetByShippingID
(

	@ShippingID int   
)
AS


				SELECT
					[ShippingRuleID],
					[ShippingID],
					[ShippingRuleTypeID],
					[LowerLimit],
					[UpperLimit],
					[BaseCost],
					[PerItemCost]
				FROM
					dbo.[ZNodeShippingRule]
				WHERE
					[ShippingID] = @ShippingID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRule_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRule_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeShippingRule table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRule_Find
(

	@SearchUsingOR bit   = null ,

	@ShippingRuleID int   = null ,

	@ShippingID int   = null ,

	@ShippingRuleTypeID int   = null ,

	@LowerLimit decimal (18, 2)  = null ,

	@UpperLimit decimal (18, 2)  = null ,

	@BaseCost smallmoney   = null ,

	@PerItemCost smallmoney   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ShippingRuleID]
	, [ShippingID]
	, [ShippingRuleTypeID]
	, [LowerLimit]
	, [UpperLimit]
	, [BaseCost]
	, [PerItemCost]
    FROM
	dbo.[ZNodeShippingRule]
    WHERE 
	 ([ShippingRuleID] = @ShippingRuleID OR @ShippingRuleID is null)
	AND ([ShippingID] = @ShippingID OR @ShippingID is null)
	AND ([ShippingRuleTypeID] = @ShippingRuleTypeID OR @ShippingRuleTypeID is null)
	AND ([LowerLimit] = @LowerLimit OR @LowerLimit is null)
	AND ([UpperLimit] = @UpperLimit OR @UpperLimit is null)
	AND ([BaseCost] = @BaseCost OR @BaseCost is null)
	AND ([PerItemCost] = @PerItemCost OR @PerItemCost is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ShippingRuleID]
	, [ShippingID]
	, [ShippingRuleTypeID]
	, [LowerLimit]
	, [UpperLimit]
	, [BaseCost]
	, [PerItemCost]
    FROM
	dbo.[ZNodeShippingRule]
    WHERE 
	 ([ShippingRuleID] = @ShippingRuleID AND @ShippingRuleID is not null)
	OR ([ShippingID] = @ShippingID AND @ShippingID is not null)
	OR ([ShippingRuleTypeID] = @ShippingRuleTypeID AND @ShippingRuleTypeID is not null)
	OR ([LowerLimit] = @LowerLimit AND @LowerLimit is not null)
	OR ([UpperLimit] = @UpperLimit AND @UpperLimit is not null)
	OR ([BaseCost] = @BaseCost AND @BaseCost is not null)
	OR ([PerItemCost] = @PerItemCost AND @PerItemCost is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingServiceCode_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingServiceCode_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeShippingServiceCode table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_Get_List

AS


				
				SELECT
					[ShippingServiceCodeID],
					[ShippingTypeID],
					[Code],
					[Description],
					[DisplayOrder],
					[ActiveInd]
				FROM
					dbo.[ZNodeShippingServiceCode]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingServiceCode_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingServiceCode_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeShippingServiceCode table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ShippingServiceCodeID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ShippingServiceCodeID]'
				SET @SQL = @SQL + ', [ShippingTypeID]'
				SET @SQL = @SQL + ', [Code]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [DisplayOrder]'
				SET @SQL = @SQL + ', [ActiveInd]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeShippingServiceCode]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ShippingServiceCodeID],'
				SET @SQL = @SQL + ' [ShippingTypeID],'
				SET @SQL = @SQL + ' [Code],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [DisplayOrder],'
				SET @SQL = @SQL + ' [ActiveInd]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeShippingServiceCode]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingServiceCode_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingServiceCode_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeShippingServiceCode table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_Insert
(

	@ShippingServiceCodeID int    OUTPUT,

	@ShippingTypeID int   ,

	@Code varchar (MAX)  ,

	@Description varchar (MAX)  ,

	@DisplayOrder int   ,

	@ActiveInd bit   
)
AS


					
				INSERT INTO dbo.[ZNodeShippingServiceCode]
					(
					[ShippingTypeID]
					,[Code]
					,[Description]
					,[DisplayOrder]
					,[ActiveInd]
					)
				VALUES
					(
					@ShippingTypeID
					,@Code
					,@Description
					,@DisplayOrder
					,@ActiveInd
					)
				
				-- Get the identity value
				SET @ShippingServiceCodeID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingServiceCode_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingServiceCode_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeShippingServiceCode table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_Update
(

	@ShippingServiceCodeID int   ,

	@ShippingTypeID int   ,

	@Code varchar (MAX)  ,

	@Description varchar (MAX)  ,

	@DisplayOrder int   ,

	@ActiveInd bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeShippingServiceCode]
				SET
					[ShippingTypeID] = @ShippingTypeID
					,[Code] = @Code
					,[Description] = @Description
					,[DisplayOrder] = @DisplayOrder
					,[ActiveInd] = @ActiveInd
				WHERE
[ShippingServiceCodeID] = @ShippingServiceCodeID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingServiceCode_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingServiceCode_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeShippingServiceCode table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_Delete
(

	@ShippingServiceCodeID int   
)
AS


				DELETE FROM dbo.[ZNodeShippingServiceCode] WITH (ROWLOCK) 
				WHERE
					[ShippingServiceCodeID] = @ShippingServiceCodeID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingServiceCode_GetByShippingTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingServiceCode_GetByShippingTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_GetByShippingTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeShippingServiceCode table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_GetByShippingTypeID
(

	@ShippingTypeID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ShippingServiceCodeID],
					[ShippingTypeID],
					[Code],
					[Description],
					[DisplayOrder],
					[ActiveInd]
				FROM
					dbo.[ZNodeShippingServiceCode]
				WHERE
					[ShippingTypeID] = @ShippingTypeID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingServiceCode_GetByShippingServiceCodeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingServiceCode_GetByShippingServiceCodeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_GetByShippingServiceCodeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeShippingServiceCode table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_GetByShippingServiceCodeID
(

	@ShippingServiceCodeID int   
)
AS


				SELECT
					[ShippingServiceCodeID],
					[ShippingTypeID],
					[Code],
					[Description],
					[DisplayOrder],
					[ActiveInd]
				FROM
					dbo.[ZNodeShippingServiceCode]
				WHERE
					[ShippingServiceCodeID] = @ShippingServiceCodeID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingServiceCode_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingServiceCode_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeShippingServiceCode table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingServiceCode_Find
(

	@SearchUsingOR bit   = null ,

	@ShippingServiceCodeID int   = null ,

	@ShippingTypeID int   = null ,

	@Code varchar (MAX)  = null ,

	@Description varchar (MAX)  = null ,

	@DisplayOrder int   = null ,

	@ActiveInd bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ShippingServiceCodeID]
	, [ShippingTypeID]
	, [Code]
	, [Description]
	, [DisplayOrder]
	, [ActiveInd]
    FROM
	dbo.[ZNodeShippingServiceCode]
    WHERE 
	 ([ShippingServiceCodeID] = @ShippingServiceCodeID OR @ShippingServiceCodeID is null)
	AND ([ShippingTypeID] = @ShippingTypeID OR @ShippingTypeID is null)
	AND ([Code] = @Code OR @Code is null)
	AND ([Description] = @Description OR @Description is null)
	AND ([DisplayOrder] = @DisplayOrder OR @DisplayOrder is null)
	AND ([ActiveInd] = @ActiveInd OR @ActiveInd is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ShippingServiceCodeID]
	, [ShippingTypeID]
	, [Code]
	, [Description]
	, [DisplayOrder]
	, [ActiveInd]
    FROM
	dbo.[ZNodeShippingServiceCode]
    WHERE 
	 ([ShippingServiceCodeID] = @ShippingServiceCodeID AND @ShippingServiceCodeID is not null)
	OR ([ShippingTypeID] = @ShippingTypeID AND @ShippingTypeID is not null)
	OR ([Code] = @Code AND @Code is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([DisplayOrder] = @DisplayOrder AND @DisplayOrder is not null)
	OR ([ActiveInd] = @ActiveInd AND @ActiveInd is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRuleType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRuleType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRuleType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeShippingRuleType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRuleType_Get_List

AS


				
				SELECT
					[ShippingRuleTypeID],
					[Name],
					[Description]
				FROM
					dbo.[ZNodeShippingRuleType]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRuleType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRuleType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRuleType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeShippingRuleType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRuleType_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ShippingRuleTypeID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ShippingRuleTypeID]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeShippingRuleType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ShippingRuleTypeID],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Description]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeShippingRuleType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRuleType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRuleType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRuleType_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeShippingRuleType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRuleType_Insert
(

	@ShippingRuleTypeID int   ,

	@Name varchar (50)  ,

	@Description varchar (MAX)  
)
AS


					
				INSERT INTO dbo.[ZNodeShippingRuleType]
					(
					[ShippingRuleTypeID]
					,[Name]
					,[Description]
					)
				VALUES
					(
					@ShippingRuleTypeID
					,@Name
					,@Description
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRuleType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRuleType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRuleType_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeShippingRuleType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRuleType_Update
(

	@ShippingRuleTypeID int   ,

	@OriginalShippingRuleTypeID int   ,

	@Name varchar (50)  ,

	@Description varchar (MAX)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeShippingRuleType]
				SET
					[ShippingRuleTypeID] = @ShippingRuleTypeID
					,[Name] = @Name
					,[Description] = @Description
				WHERE
[ShippingRuleTypeID] = @OriginalShippingRuleTypeID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRuleType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRuleType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRuleType_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeShippingRuleType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRuleType_Delete
(

	@ShippingRuleTypeID int   
)
AS


				DELETE FROM dbo.[ZNodeShippingRuleType] WITH (ROWLOCK) 
				WHERE
					[ShippingRuleTypeID] = @ShippingRuleTypeID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRuleType_GetByShippingRuleTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRuleType_GetByShippingRuleTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRuleType_GetByShippingRuleTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeShippingRuleType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRuleType_GetByShippingRuleTypeID
(

	@ShippingRuleTypeID int   
)
AS


				SELECT
					[ShippingRuleTypeID],
					[Name],
					[Description]
				FROM
					dbo.[ZNodeShippingRuleType]
				WHERE
					[ShippingRuleTypeID] = @ShippingRuleTypeID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeShippingRuleType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeShippingRuleType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeShippingRuleType_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeShippingRuleType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeShippingRuleType_Find
(

	@SearchUsingOR bit   = null ,

	@ShippingRuleTypeID int   = null ,

	@Name varchar (50)  = null ,

	@Description varchar (MAX)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ShippingRuleTypeID]
	, [Name]
	, [Description]
    FROM
	dbo.[ZNodeShippingRuleType]
    WHERE 
	 ([ShippingRuleTypeID] = @ShippingRuleTypeID OR @ShippingRuleTypeID is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([Description] = @Description OR @Description is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ShippingRuleTypeID]
	, [Name]
	, [Description]
    FROM
	dbo.[ZNodeShippingRuleType]
    WHERE 
	 ([ShippingRuleTypeID] = @ShippingRuleTypeID AND @ShippingRuleTypeID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Description] = @Description AND @Description is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCaseType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCaseType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCaseType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeCaseType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCaseType_Get_List

AS


				
				SELECT
					[CaseTypeID],
					[CaseTypeNme]
				FROM
					dbo.[ZNodeCaseType]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCaseType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCaseType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCaseType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeCaseType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCaseType_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[CaseTypeID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [CaseTypeID]'
				SET @SQL = @SQL + ', [CaseTypeNme]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeCaseType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CaseTypeID],'
				SET @SQL = @SQL + ' [CaseTypeNme]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeCaseType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCaseType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCaseType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCaseType_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeCaseType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCaseType_Insert
(

	@CaseTypeID int   ,

	@CaseTypeNme varchar (100)  
)
AS


					
				INSERT INTO dbo.[ZNodeCaseType]
					(
					[CaseTypeID]
					,[CaseTypeNme]
					)
				VALUES
					(
					@CaseTypeID
					,@CaseTypeNme
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCaseType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCaseType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCaseType_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeCaseType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCaseType_Update
(

	@CaseTypeID int   ,

	@OriginalCaseTypeID int   ,

	@CaseTypeNme varchar (100)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeCaseType]
				SET
					[CaseTypeID] = @CaseTypeID
					,[CaseTypeNme] = @CaseTypeNme
				WHERE
[CaseTypeID] = @OriginalCaseTypeID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCaseType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCaseType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCaseType_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeCaseType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCaseType_Delete
(

	@CaseTypeID int   
)
AS


				DELETE FROM dbo.[ZNodeCaseType] WITH (ROWLOCK) 
				WHERE
					[CaseTypeID] = @CaseTypeID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCaseType_GetByCaseTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCaseType_GetByCaseTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCaseType_GetByCaseTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCaseType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCaseType_GetByCaseTypeID
(

	@CaseTypeID int   
)
AS


				SELECT
					[CaseTypeID],
					[CaseTypeNme]
				FROM
					dbo.[ZNodeCaseType]
				WHERE
					[CaseTypeID] = @CaseTypeID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCaseType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCaseType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCaseType_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeCaseType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCaseType_Find
(

	@SearchUsingOR bit   = null ,

	@CaseTypeID int   = null ,

	@CaseTypeNme varchar (100)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CaseTypeID]
	, [CaseTypeNme]
    FROM
	dbo.[ZNodeCaseType]
    WHERE 
	 ([CaseTypeID] = @CaseTypeID OR @CaseTypeID is null)
	AND ([CaseTypeNme] = @CaseTypeNme OR @CaseTypeNme is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CaseTypeID]
	, [CaseTypeNme]
    FROM
	dbo.[ZNodeCaseType]
    WHERE 
	 ([CaseTypeID] = @CaseTypeID AND @CaseTypeID is not null)
	OR ([CaseTypeNme] = @CaseTypeNme AND @CaseTypeNme is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPage_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPage_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeContentPage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_Get_List

AS


				
				SELECT
					[ContentPageID],
					[Name],
					[PortalID],
					[Title],
					[SEOTitle],
					[SEOMetaKeywords],
					[SEOMetaDescription],
					[AllowDelete],
					[TemplateName],
					[ActiveInd],
					[AnalyticsCode],
					[Custom1],
					[Custom2],
					[Custom3]
				FROM
					dbo.[ZNodeContentPage]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPage_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPage_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeContentPage table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ContentPageID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ContentPageID]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [PortalID]'
				SET @SQL = @SQL + ', [Title]'
				SET @SQL = @SQL + ', [SEOTitle]'
				SET @SQL = @SQL + ', [SEOMetaKeywords]'
				SET @SQL = @SQL + ', [SEOMetaDescription]'
				SET @SQL = @SQL + ', [AllowDelete]'
				SET @SQL = @SQL + ', [TemplateName]'
				SET @SQL = @SQL + ', [ActiveInd]'
				SET @SQL = @SQL + ', [AnalyticsCode]'
				SET @SQL = @SQL + ', [Custom1]'
				SET @SQL = @SQL + ', [Custom2]'
				SET @SQL = @SQL + ', [Custom3]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeContentPage]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ContentPageID],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [PortalID],'
				SET @SQL = @SQL + ' [Title],'
				SET @SQL = @SQL + ' [SEOTitle],'
				SET @SQL = @SQL + ' [SEOMetaKeywords],'
				SET @SQL = @SQL + ' [SEOMetaDescription],'
				SET @SQL = @SQL + ' [AllowDelete],'
				SET @SQL = @SQL + ' [TemplateName],'
				SET @SQL = @SQL + ' [ActiveInd],'
				SET @SQL = @SQL + ' [AnalyticsCode],'
				SET @SQL = @SQL + ' [Custom1],'
				SET @SQL = @SQL + ' [Custom2],'
				SET @SQL = @SQL + ' [Custom3]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeContentPage]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPage_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPage_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeContentPage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_Insert
(

	@ContentPageID int    OUTPUT,

	@Name varchar (50)  ,

	@PortalID int   ,

	@Title nvarchar (MAX)  ,

	@SEOTitle nvarchar (MAX)  ,

	@SEOMetaKeywords nvarchar (MAX)  ,

	@SEOMetaDescription nvarchar (MAX)  ,

	@AllowDelete bit   ,

	@TemplateName nvarchar (MAX)  ,

	@ActiveInd bit   ,

	@AnalyticsCode varchar (MAX)  ,

	@Custom1 varchar (MAX)  ,

	@Custom2 varchar (MAX)  ,

	@Custom3 varchar (MAX)  
)
AS


					
				INSERT INTO dbo.[ZNodeContentPage]
					(
					[Name]
					,[PortalID]
					,[Title]
					,[SEOTitle]
					,[SEOMetaKeywords]
					,[SEOMetaDescription]
					,[AllowDelete]
					,[TemplateName]
					,[ActiveInd]
					,[AnalyticsCode]
					,[Custom1]
					,[Custom2]
					,[Custom3]
					)
				VALUES
					(
					@Name
					,@PortalID
					,@Title
					,@SEOTitle
					,@SEOMetaKeywords
					,@SEOMetaDescription
					,@AllowDelete
					,@TemplateName
					,@ActiveInd
					,@AnalyticsCode
					,@Custom1
					,@Custom2
					,@Custom3
					)
				
				-- Get the identity value
				SET @ContentPageID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPage_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPage_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeContentPage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_Update
(

	@ContentPageID int   ,

	@Name varchar (50)  ,

	@PortalID int   ,

	@Title nvarchar (MAX)  ,

	@SEOTitle nvarchar (MAX)  ,

	@SEOMetaKeywords nvarchar (MAX)  ,

	@SEOMetaDescription nvarchar (MAX)  ,

	@AllowDelete bit   ,

	@TemplateName nvarchar (MAX)  ,

	@ActiveInd bit   ,

	@AnalyticsCode varchar (MAX)  ,

	@Custom1 varchar (MAX)  ,

	@Custom2 varchar (MAX)  ,

	@Custom3 varchar (MAX)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeContentPage]
				SET
					[Name] = @Name
					,[PortalID] = @PortalID
					,[Title] = @Title
					,[SEOTitle] = @SEOTitle
					,[SEOMetaKeywords] = @SEOMetaKeywords
					,[SEOMetaDescription] = @SEOMetaDescription
					,[AllowDelete] = @AllowDelete
					,[TemplateName] = @TemplateName
					,[ActiveInd] = @ActiveInd
					,[AnalyticsCode] = @AnalyticsCode
					,[Custom1] = @Custom1
					,[Custom2] = @Custom2
					,[Custom3] = @Custom3
				WHERE
[ContentPageID] = @ContentPageID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPage_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPage_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeContentPage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_Delete
(

	@ContentPageID int   
)
AS


				DELETE FROM dbo.[ZNodeContentPage] WITH (ROWLOCK) 
				WHERE
					[ContentPageID] = @ContentPageID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPage_GetByPortalID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPage_GetByPortalID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_GetByPortalID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeContentPage table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_GetByPortalID
(

	@PortalID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ContentPageID],
					[Name],
					[PortalID],
					[Title],
					[SEOTitle],
					[SEOMetaKeywords],
					[SEOMetaDescription],
					[AllowDelete],
					[TemplateName],
					[ActiveInd],
					[AnalyticsCode],
					[Custom1],
					[Custom2],
					[Custom3]
				FROM
					dbo.[ZNodeContentPage]
				WHERE
					[PortalID] = @PortalID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPage_GetByContentPageID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPage_GetByContentPageID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_GetByContentPageID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeContentPage table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_GetByContentPageID
(

	@ContentPageID int   
)
AS


				SELECT
					[ContentPageID],
					[Name],
					[PortalID],
					[Title],
					[SEOTitle],
					[SEOMetaKeywords],
					[SEOMetaDescription],
					[AllowDelete],
					[TemplateName],
					[ActiveInd],
					[AnalyticsCode],
					[Custom1],
					[Custom2],
					[Custom3]
				FROM
					dbo.[ZNodeContentPage]
				WHERE
					[ContentPageID] = @ContentPageID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPage_GetByName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPage_GetByName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_GetByName
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeContentPage table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_GetByName
(

	@Name varchar (50)  
)
AS


				SELECT
					[ContentPageID],
					[Name],
					[PortalID],
					[Title],
					[SEOTitle],
					[SEOMetaKeywords],
					[SEOMetaDescription],
					[AllowDelete],
					[TemplateName],
					[ActiveInd],
					[AnalyticsCode],
					[Custom1],
					[Custom2],
					[Custom3]
				FROM
					dbo.[ZNodeContentPage]
				WHERE
					[Name] = @Name
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPage_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPage_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeContentPage table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPage_Find
(

	@SearchUsingOR bit   = null ,

	@ContentPageID int   = null ,

	@Name varchar (50)  = null ,

	@PortalID int   = null ,

	@Title nvarchar (MAX)  = null ,

	@SEOTitle nvarchar (MAX)  = null ,

	@SEOMetaKeywords nvarchar (MAX)  = null ,

	@SEOMetaDescription nvarchar (MAX)  = null ,

	@AllowDelete bit   = null ,

	@TemplateName nvarchar (MAX)  = null ,

	@ActiveInd bit   = null ,

	@AnalyticsCode varchar (MAX)  = null ,

	@Custom1 varchar (MAX)  = null ,

	@Custom2 varchar (MAX)  = null ,

	@Custom3 varchar (MAX)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ContentPageID]
	, [Name]
	, [PortalID]
	, [Title]
	, [SEOTitle]
	, [SEOMetaKeywords]
	, [SEOMetaDescription]
	, [AllowDelete]
	, [TemplateName]
	, [ActiveInd]
	, [AnalyticsCode]
	, [Custom1]
	, [Custom2]
	, [Custom3]
    FROM
	dbo.[ZNodeContentPage]
    WHERE 
	 ([ContentPageID] = @ContentPageID OR @ContentPageID is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([PortalID] = @PortalID OR @PortalID is null)
	AND ([Title] = @Title OR @Title is null)
	AND ([SEOTitle] = @SEOTitle OR @SEOTitle is null)
	AND ([SEOMetaKeywords] = @SEOMetaKeywords OR @SEOMetaKeywords is null)
	AND ([SEOMetaDescription] = @SEOMetaDescription OR @SEOMetaDescription is null)
	AND ([AllowDelete] = @AllowDelete OR @AllowDelete is null)
	AND ([TemplateName] = @TemplateName OR @TemplateName is null)
	AND ([ActiveInd] = @ActiveInd OR @ActiveInd is null)
	AND ([AnalyticsCode] = @AnalyticsCode OR @AnalyticsCode is null)
	AND ([Custom1] = @Custom1 OR @Custom1 is null)
	AND ([Custom2] = @Custom2 OR @Custom2 is null)
	AND ([Custom3] = @Custom3 OR @Custom3 is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ContentPageID]
	, [Name]
	, [PortalID]
	, [Title]
	, [SEOTitle]
	, [SEOMetaKeywords]
	, [SEOMetaDescription]
	, [AllowDelete]
	, [TemplateName]
	, [ActiveInd]
	, [AnalyticsCode]
	, [Custom1]
	, [Custom2]
	, [Custom3]
    FROM
	dbo.[ZNodeContentPage]
    WHERE 
	 ([ContentPageID] = @ContentPageID AND @ContentPageID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([PortalID] = @PortalID AND @PortalID is not null)
	OR ([Title] = @Title AND @Title is not null)
	OR ([SEOTitle] = @SEOTitle AND @SEOTitle is not null)
	OR ([SEOMetaKeywords] = @SEOMetaKeywords AND @SEOMetaKeywords is not null)
	OR ([SEOMetaDescription] = @SEOMetaDescription AND @SEOMetaDescription is not null)
	OR ([AllowDelete] = @AllowDelete AND @AllowDelete is not null)
	OR ([TemplateName] = @TemplateName AND @TemplateName is not null)
	OR ([ActiveInd] = @ActiveInd AND @ActiveInd is not null)
	OR ([AnalyticsCode] = @AnalyticsCode AND @AnalyticsCode is not null)
	OR ([Custom1] = @Custom1 AND @Custom1 is not null)
	OR ([Custom2] = @Custom2 AND @Custom2 is not null)
	OR ([Custom3] = @Custom3 AND @Custom3 is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCaseStatus_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCaseStatus_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCaseStatus_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeCaseStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCaseStatus_Get_List

AS


				
				SELECT
					[CaseStatusID],
					[CaseStatusNme],
					[ViewOrder]
				FROM
					dbo.[ZNodeCaseStatus]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCaseStatus_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCaseStatus_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCaseStatus_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeCaseStatus table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCaseStatus_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[CaseStatusID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [CaseStatusID]'
				SET @SQL = @SQL + ', [CaseStatusNme]'
				SET @SQL = @SQL + ', [ViewOrder]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeCaseStatus]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CaseStatusID],'
				SET @SQL = @SQL + ' [CaseStatusNme],'
				SET @SQL = @SQL + ' [ViewOrder]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeCaseStatus]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCaseStatus_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCaseStatus_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCaseStatus_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeCaseStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCaseStatus_Insert
(

	@CaseStatusID int   ,

	@CaseStatusNme varchar (100)  ,

	@ViewOrder int   
)
AS


					
				INSERT INTO dbo.[ZNodeCaseStatus]
					(
					[CaseStatusID]
					,[CaseStatusNme]
					,[ViewOrder]
					)
				VALUES
					(
					@CaseStatusID
					,@CaseStatusNme
					,@ViewOrder
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCaseStatus_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCaseStatus_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCaseStatus_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeCaseStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCaseStatus_Update
(

	@CaseStatusID int   ,

	@OriginalCaseStatusID int   ,

	@CaseStatusNme varchar (100)  ,

	@ViewOrder int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeCaseStatus]
				SET
					[CaseStatusID] = @CaseStatusID
					,[CaseStatusNme] = @CaseStatusNme
					,[ViewOrder] = @ViewOrder
				WHERE
[CaseStatusID] = @OriginalCaseStatusID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCaseStatus_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCaseStatus_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCaseStatus_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeCaseStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCaseStatus_Delete
(

	@CaseStatusID int   
)
AS


				DELETE FROM dbo.[ZNodeCaseStatus] WITH (ROWLOCK) 
				WHERE
					[CaseStatusID] = @CaseStatusID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCaseStatus_GetByCaseStatusID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCaseStatus_GetByCaseStatusID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCaseStatus_GetByCaseStatusID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCaseStatus table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCaseStatus_GetByCaseStatusID
(

	@CaseStatusID int   
)
AS


				SELECT
					[CaseStatusID],
					[CaseStatusNme],
					[ViewOrder]
				FROM
					dbo.[ZNodeCaseStatus]
				WHERE
					[CaseStatusID] = @CaseStatusID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCaseStatus_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCaseStatus_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCaseStatus_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeCaseStatus table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCaseStatus_Find
(

	@SearchUsingOR bit   = null ,

	@CaseStatusID int   = null ,

	@CaseStatusNme varchar (100)  = null ,

	@ViewOrder int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CaseStatusID]
	, [CaseStatusNme]
	, [ViewOrder]
    FROM
	dbo.[ZNodeCaseStatus]
    WHERE 
	 ([CaseStatusID] = @CaseStatusID OR @CaseStatusID is null)
	AND ([CaseStatusNme] = @CaseStatusNme OR @CaseStatusNme is null)
	AND ([ViewOrder] = @ViewOrder OR @ViewOrder is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CaseStatusID]
	, [CaseStatusNme]
	, [ViewOrder]
    FROM
	dbo.[ZNodeCaseStatus]
    WHERE 
	 ([CaseStatusID] = @CaseStatusID AND @CaseStatusID is not null)
	OR ([CaseStatusNme] = @CaseStatusNme AND @CaseStatusNme is not null)
	OR ([ViewOrder] = @ViewOrder AND @ViewOrder is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPageRevision_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPageRevision_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeContentPageRevision table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_Get_List

AS


				
				SELECT
					[RevisionID],
					[ContentPageID],
					[UpdateDate],
					[UpdateUser],
					[Description],
					[HtmlText]
				FROM
					dbo.[ZNodeContentPageRevision]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPageRevision_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPageRevision_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeContentPageRevision table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[RevisionID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [RevisionID]'
				SET @SQL = @SQL + ', [ContentPageID]'
				SET @SQL = @SQL + ', [UpdateDate]'
				SET @SQL = @SQL + ', [UpdateUser]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [HtmlText]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeContentPageRevision]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [RevisionID],'
				SET @SQL = @SQL + ' [ContentPageID],'
				SET @SQL = @SQL + ' [UpdateDate],'
				SET @SQL = @SQL + ' [UpdateUser],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [HtmlText]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeContentPageRevision]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPageRevision_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPageRevision_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeContentPageRevision table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_Insert
(

	@RevisionID int    OUTPUT,

	@ContentPageID int   ,

	@UpdateDate smalldatetime   ,

	@UpdateUser nvarchar (50)  ,

	@Description nvarchar (MAX)  ,

	@HtmlText ntext   
)
AS


					
				INSERT INTO dbo.[ZNodeContentPageRevision]
					(
					[ContentPageID]
					,[UpdateDate]
					,[UpdateUser]
					,[Description]
					,[HtmlText]
					)
				VALUES
					(
					@ContentPageID
					,@UpdateDate
					,@UpdateUser
					,@Description
					,@HtmlText
					)
				
				-- Get the identity value
				SET @RevisionID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPageRevision_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPageRevision_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeContentPageRevision table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_Update
(

	@RevisionID int   ,

	@ContentPageID int   ,

	@UpdateDate smalldatetime   ,

	@UpdateUser nvarchar (50)  ,

	@Description nvarchar (MAX)  ,

	@HtmlText ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeContentPageRevision]
				SET
					[ContentPageID] = @ContentPageID
					,[UpdateDate] = @UpdateDate
					,[UpdateUser] = @UpdateUser
					,[Description] = @Description
					,[HtmlText] = @HtmlText
				WHERE
[RevisionID] = @RevisionID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPageRevision_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPageRevision_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeContentPageRevision table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_Delete
(

	@RevisionID int   
)
AS


				DELETE FROM dbo.[ZNodeContentPageRevision] WITH (ROWLOCK) 
				WHERE
					[RevisionID] = @RevisionID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPageRevision_GetByContentPageID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPageRevision_GetByContentPageID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_GetByContentPageID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeContentPageRevision table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_GetByContentPageID
(

	@ContentPageID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[RevisionID],
					[ContentPageID],
					[UpdateDate],
					[UpdateUser],
					[Description],
					[HtmlText]
				FROM
					dbo.[ZNodeContentPageRevision]
				WHERE
					[ContentPageID] = @ContentPageID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPageRevision_GetByRevisionID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPageRevision_GetByRevisionID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_GetByRevisionID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeContentPageRevision table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_GetByRevisionID
(

	@RevisionID int   
)
AS


				SELECT
					[RevisionID],
					[ContentPageID],
					[UpdateDate],
					[UpdateUser],
					[Description],
					[HtmlText]
				FROM
					dbo.[ZNodeContentPageRevision]
				WHERE
					[RevisionID] = @RevisionID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeContentPageRevision_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeContentPageRevision_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeContentPageRevision table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeContentPageRevision_Find
(

	@SearchUsingOR bit   = null ,

	@RevisionID int   = null ,

	@ContentPageID int   = null ,

	@UpdateDate smalldatetime   = null ,

	@UpdateUser nvarchar (50)  = null ,

	@Description nvarchar (MAX)  = null ,

	@HtmlText ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [RevisionID]
	, [ContentPageID]
	, [UpdateDate]
	, [UpdateUser]
	, [Description]
	, [HtmlText]
    FROM
	dbo.[ZNodeContentPageRevision]
    WHERE 
	 ([RevisionID] = @RevisionID OR @RevisionID is null)
	AND ([ContentPageID] = @ContentPageID OR @ContentPageID is null)
	AND ([UpdateDate] = @UpdateDate OR @UpdateDate is null)
	AND ([UpdateUser] = @UpdateUser OR @UpdateUser is null)
	AND ([Description] = @Description OR @Description is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [RevisionID]
	, [ContentPageID]
	, [UpdateDate]
	, [UpdateUser]
	, [Description]
	, [HtmlText]
    FROM
	dbo.[ZNodeContentPageRevision]
    WHERE 
	 ([RevisionID] = @RevisionID AND @RevisionID is not null)
	OR ([ContentPageID] = @ContentPageID AND @ContentPageID is not null)
	OR ([UpdateDate] = @UpdateDate AND @UpdateDate is not null)
	OR ([UpdateUser] = @UpdateUser AND @UpdateUser is not null)
	OR ([Description] = @Description AND @Description is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCategory_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCategory_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCategory_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeCategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCategory_Get_List

AS


				
				SELECT
					[CategoryID],
					[PortalID],
					[Name],
					[Title],
					[ShortDescription],
					[Description],
					[ParentCategoryID],
					[DisplayOrder],
					[ImageFile],
					[VisibleInd],
					[SubCategoryGridVisibleInd],
					[SEOTitle],
					[SEOKeywords],
					[SEODescription]
				FROM
					dbo.[ZNodeCategory]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCategory_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCategory_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCategory_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeCategory table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCategory_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[CategoryID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [CategoryID]'
				SET @SQL = @SQL + ', [PortalID]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Title]'
				SET @SQL = @SQL + ', [ShortDescription]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [ParentCategoryID]'
				SET @SQL = @SQL + ', [DisplayOrder]'
				SET @SQL = @SQL + ', [ImageFile]'
				SET @SQL = @SQL + ', [VisibleInd]'
				SET @SQL = @SQL + ', [SubCategoryGridVisibleInd]'
				SET @SQL = @SQL + ', [SEOTitle]'
				SET @SQL = @SQL + ', [SEOKeywords]'
				SET @SQL = @SQL + ', [SEODescription]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeCategory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CategoryID],'
				SET @SQL = @SQL + ' [PortalID],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Title],'
				SET @SQL = @SQL + ' [ShortDescription],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [ParentCategoryID],'
				SET @SQL = @SQL + ' [DisplayOrder],'
				SET @SQL = @SQL + ' [ImageFile],'
				SET @SQL = @SQL + ' [VisibleInd],'
				SET @SQL = @SQL + ' [SubCategoryGridVisibleInd],'
				SET @SQL = @SQL + ' [SEOTitle],'
				SET @SQL = @SQL + ' [SEOKeywords],'
				SET @SQL = @SQL + ' [SEODescription]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeCategory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCategory_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCategory_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCategory_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeCategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCategory_Insert
(

	@CategoryID int    OUTPUT,

	@PortalID int   ,

	@Name nvarchar (MAX)  ,

	@Title nvarchar (MAX)  ,

	@ShortDescription ntext   ,

	@Description ntext   ,

	@ParentCategoryID int   ,

	@DisplayOrder int   ,

	@ImageFile nvarchar (MAX)  ,

	@VisibleInd bit   ,

	@SubCategoryGridVisibleInd bit   ,

	@SEOTitle nvarchar (MAX)  ,

	@SEOKeywords nvarchar (MAX)  ,

	@SEODescription nvarchar (MAX)  
)
AS


					
				INSERT INTO dbo.[ZNodeCategory]
					(
					[PortalID]
					,[Name]
					,[Title]
					,[ShortDescription]
					,[Description]
					,[ParentCategoryID]
					,[DisplayOrder]
					,[ImageFile]
					,[VisibleInd]
					,[SubCategoryGridVisibleInd]
					,[SEOTitle]
					,[SEOKeywords]
					,[SEODescription]
					)
				VALUES
					(
					@PortalID
					,@Name
					,@Title
					,@ShortDescription
					,@Description
					,@ParentCategoryID
					,@DisplayOrder
					,@ImageFile
					,@VisibleInd
					,@SubCategoryGridVisibleInd
					,@SEOTitle
					,@SEOKeywords
					,@SEODescription
					)
				
				-- Get the identity value
				SET @CategoryID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCategory_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCategory_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCategory_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeCategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCategory_Update
(

	@CategoryID int   ,

	@PortalID int   ,

	@Name nvarchar (MAX)  ,

	@Title nvarchar (MAX)  ,

	@ShortDescription ntext   ,

	@Description ntext   ,

	@ParentCategoryID int   ,

	@DisplayOrder int   ,

	@ImageFile nvarchar (MAX)  ,

	@VisibleInd bit   ,

	@SubCategoryGridVisibleInd bit   ,

	@SEOTitle nvarchar (MAX)  ,

	@SEOKeywords nvarchar (MAX)  ,

	@SEODescription nvarchar (MAX)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeCategory]
				SET
					[PortalID] = @PortalID
					,[Name] = @Name
					,[Title] = @Title
					,[ShortDescription] = @ShortDescription
					,[Description] = @Description
					,[ParentCategoryID] = @ParentCategoryID
					,[DisplayOrder] = @DisplayOrder
					,[ImageFile] = @ImageFile
					,[VisibleInd] = @VisibleInd
					,[SubCategoryGridVisibleInd] = @SubCategoryGridVisibleInd
					,[SEOTitle] = @SEOTitle
					,[SEOKeywords] = @SEOKeywords
					,[SEODescription] = @SEODescription
				WHERE
[CategoryID] = @CategoryID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCategory_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCategory_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCategory_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeCategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCategory_Delete
(

	@CategoryID int   
)
AS


				DELETE FROM dbo.[ZNodeCategory] WITH (ROWLOCK) 
				WHERE
					[CategoryID] = @CategoryID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCategory_GetByPortalID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCategory_GetByPortalID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCategory_GetByPortalID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCategory table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCategory_GetByPortalID
(

	@PortalID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[CategoryID],
					[PortalID],
					[Name],
					[Title],
					[ShortDescription],
					[Description],
					[ParentCategoryID],
					[DisplayOrder],
					[ImageFile],
					[VisibleInd],
					[SubCategoryGridVisibleInd],
					[SEOTitle],
					[SEOKeywords],
					[SEODescription]
				FROM
					dbo.[ZNodeCategory]
				WHERE
					[PortalID] = @PortalID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCategory_GetByParentCategoryID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCategory_GetByParentCategoryID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCategory_GetByParentCategoryID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCategory table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCategory_GetByParentCategoryID
(

	@ParentCategoryID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[CategoryID],
					[PortalID],
					[Name],
					[Title],
					[ShortDescription],
					[Description],
					[ParentCategoryID],
					[DisplayOrder],
					[ImageFile],
					[VisibleInd],
					[SubCategoryGridVisibleInd],
					[SEOTitle],
					[SEOKeywords],
					[SEODescription]
				FROM
					dbo.[ZNodeCategory]
				WHERE
					[ParentCategoryID] = @ParentCategoryID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCategory_GetByCategoryID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCategory_GetByCategoryID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCategory_GetByCategoryID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCategory table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCategory_GetByCategoryID
(

	@CategoryID int   
)
AS


				SELECT
					[CategoryID],
					[PortalID],
					[Name],
					[Title],
					[ShortDescription],
					[Description],
					[ParentCategoryID],
					[DisplayOrder],
					[ImageFile],
					[VisibleInd],
					[SubCategoryGridVisibleInd],
					[SEOTitle],
					[SEOKeywords],
					[SEODescription]
				FROM
					dbo.[ZNodeCategory]
				WHERE
					[CategoryID] = @CategoryID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCategory_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCategory_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCategory_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeCategory table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCategory_Find
(

	@SearchUsingOR bit   = null ,

	@CategoryID int   = null ,

	@PortalID int   = null ,

	@Name nvarchar (MAX)  = null ,

	@Title nvarchar (MAX)  = null ,

	@ShortDescription ntext   = null ,

	@Description ntext   = null ,

	@ParentCategoryID int   = null ,

	@DisplayOrder int   = null ,

	@ImageFile nvarchar (MAX)  = null ,

	@VisibleInd bit   = null ,

	@SubCategoryGridVisibleInd bit   = null ,

	@SEOTitle nvarchar (MAX)  = null ,

	@SEOKeywords nvarchar (MAX)  = null ,

	@SEODescription nvarchar (MAX)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CategoryID]
	, [PortalID]
	, [Name]
	, [Title]
	, [ShortDescription]
	, [Description]
	, [ParentCategoryID]
	, [DisplayOrder]
	, [ImageFile]
	, [VisibleInd]
	, [SubCategoryGridVisibleInd]
	, [SEOTitle]
	, [SEOKeywords]
	, [SEODescription]
    FROM
	dbo.[ZNodeCategory]
    WHERE 
	 ([CategoryID] = @CategoryID OR @CategoryID is null)
	AND ([PortalID] = @PortalID OR @PortalID is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([Title] = @Title OR @Title is null)
	AND ([ParentCategoryID] = @ParentCategoryID OR @ParentCategoryID is null)
	AND ([DisplayOrder] = @DisplayOrder OR @DisplayOrder is null)
	AND ([ImageFile] = @ImageFile OR @ImageFile is null)
	AND ([VisibleInd] = @VisibleInd OR @VisibleInd is null)
	AND ([SubCategoryGridVisibleInd] = @SubCategoryGridVisibleInd OR @SubCategoryGridVisibleInd is null)
	AND ([SEOTitle] = @SEOTitle OR @SEOTitle is null)
	AND ([SEOKeywords] = @SEOKeywords OR @SEOKeywords is null)
	AND ([SEODescription] = @SEODescription OR @SEODescription is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CategoryID]
	, [PortalID]
	, [Name]
	, [Title]
	, [ShortDescription]
	, [Description]
	, [ParentCategoryID]
	, [DisplayOrder]
	, [ImageFile]
	, [VisibleInd]
	, [SubCategoryGridVisibleInd]
	, [SEOTitle]
	, [SEOKeywords]
	, [SEODescription]
    FROM
	dbo.[ZNodeCategory]
    WHERE 
	 ([CategoryID] = @CategoryID AND @CategoryID is not null)
	OR ([PortalID] = @PortalID AND @PortalID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Title] = @Title AND @Title is not null)
	OR ([ParentCategoryID] = @ParentCategoryID AND @ParentCategoryID is not null)
	OR ([DisplayOrder] = @DisplayOrder AND @DisplayOrder is not null)
	OR ([ImageFile] = @ImageFile AND @ImageFile is not null)
	OR ([VisibleInd] = @VisibleInd AND @VisibleInd is not null)
	OR ([SubCategoryGridVisibleInd] = @SubCategoryGridVisibleInd AND @SubCategoryGridVisibleInd is not null)
	OR ([SEOTitle] = @SEOTitle AND @SEOTitle is not null)
	OR ([SEOKeywords] = @SEOKeywords AND @SEOKeywords is not null)
	OR ([SEODescription] = @SEODescription AND @SEODescription is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCasePriority_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCasePriority_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCasePriority_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeCasePriority table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCasePriority_Get_List

AS


				
				SELECT
					[CasePriorityID],
					[CasePriorityNme],
					[ViewOrder]
				FROM
					dbo.[ZNodeCasePriority]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCasePriority_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCasePriority_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCasePriority_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeCasePriority table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCasePriority_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[CasePriorityID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [CasePriorityID]'
				SET @SQL = @SQL + ', [CasePriorityNme]'
				SET @SQL = @SQL + ', [ViewOrder]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeCasePriority]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CasePriorityID],'
				SET @SQL = @SQL + ' [CasePriorityNme],'
				SET @SQL = @SQL + ' [ViewOrder]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeCasePriority]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCasePriority_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCasePriority_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCasePriority_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeCasePriority table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCasePriority_Insert
(

	@CasePriorityID int   ,

	@CasePriorityNme varchar (100)  ,

	@ViewOrder int   
)
AS


					
				INSERT INTO dbo.[ZNodeCasePriority]
					(
					[CasePriorityID]
					,[CasePriorityNme]
					,[ViewOrder]
					)
				VALUES
					(
					@CasePriorityID
					,@CasePriorityNme
					,@ViewOrder
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCasePriority_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCasePriority_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCasePriority_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeCasePriority table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCasePriority_Update
(

	@CasePriorityID int   ,

	@OriginalCasePriorityID int   ,

	@CasePriorityNme varchar (100)  ,

	@ViewOrder int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeCasePriority]
				SET
					[CasePriorityID] = @CasePriorityID
					,[CasePriorityNme] = @CasePriorityNme
					,[ViewOrder] = @ViewOrder
				WHERE
[CasePriorityID] = @OriginalCasePriorityID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCasePriority_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCasePriority_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCasePriority_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeCasePriority table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCasePriority_Delete
(

	@CasePriorityID int   
)
AS


				DELETE FROM dbo.[ZNodeCasePriority] WITH (ROWLOCK) 
				WHERE
					[CasePriorityID] = @CasePriorityID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCasePriority_GetByCasePriorityID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCasePriority_GetByCasePriorityID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCasePriority_GetByCasePriorityID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCasePriority table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCasePriority_GetByCasePriorityID
(

	@CasePriorityID int   
)
AS


				SELECT
					[CasePriorityID],
					[CasePriorityNme],
					[ViewOrder]
				FROM
					dbo.[ZNodeCasePriority]
				WHERE
					[CasePriorityID] = @CasePriorityID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCasePriority_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCasePriority_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCasePriority_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeCasePriority table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCasePriority_Find
(

	@SearchUsingOR bit   = null ,

	@CasePriorityID int   = null ,

	@CasePriorityNme varchar (100)  = null ,

	@ViewOrder int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CasePriorityID]
	, [CasePriorityNme]
	, [ViewOrder]
    FROM
	dbo.[ZNodeCasePriority]
    WHERE 
	 ([CasePriorityID] = @CasePriorityID OR @CasePriorityID is null)
	AND ([CasePriorityNme] = @CasePriorityNme OR @CasePriorityNme is null)
	AND ([ViewOrder] = @ViewOrder OR @ViewOrder is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CasePriorityID]
	, [CasePriorityNme]
	, [ViewOrder]
    FROM
	dbo.[ZNodeCasePriority]
    WHERE 
	 ([CasePriorityID] = @CasePriorityID AND @CasePriorityID is not null)
	OR ([CasePriorityNme] = @CasePriorityNme AND @CasePriorityNme is not null)
	OR ([ViewOrder] = @ViewOrder AND @ViewOrder is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAddOn_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAddOn_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAddOn_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeAddOn table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAddOn_Get_List

AS


				
				SELECT
					[AddOnID],
					[ProductID],
					[Title],
					[Name],
					[Description],
					[DisplayOrder],
					[DisplayType],
					[OptionalInd],
					[AllowBackOrder],
					[InStockMsg],
					[OutOfStockMsg],
					[BackOrderMsg],
					[PromptMsg],
					[TrackInventoryInd]
				FROM
					dbo.[ZNodeAddOn]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAddOn_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAddOn_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAddOn_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeAddOn table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAddOn_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[AddOnID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [AddOnID]'
				SET @SQL = @SQL + ', [ProductID]'
				SET @SQL = @SQL + ', [Title]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [DisplayOrder]'
				SET @SQL = @SQL + ', [DisplayType]'
				SET @SQL = @SQL + ', [OptionalInd]'
				SET @SQL = @SQL + ', [AllowBackOrder]'
				SET @SQL = @SQL + ', [InStockMsg]'
				SET @SQL = @SQL + ', [OutOfStockMsg]'
				SET @SQL = @SQL + ', [BackOrderMsg]'
				SET @SQL = @SQL + ', [PromptMsg]'
				SET @SQL = @SQL + ', [TrackInventoryInd]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeAddOn]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AddOnID],'
				SET @SQL = @SQL + ' [ProductID],'
				SET @SQL = @SQL + ' [Title],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [DisplayOrder],'
				SET @SQL = @SQL + ' [DisplayType],'
				SET @SQL = @SQL + ' [OptionalInd],'
				SET @SQL = @SQL + ' [AllowBackOrder],'
				SET @SQL = @SQL + ' [InStockMsg],'
				SET @SQL = @SQL + ' [OutOfStockMsg],'
				SET @SQL = @SQL + ' [BackOrderMsg],'
				SET @SQL = @SQL + ' [PromptMsg],'
				SET @SQL = @SQL + ' [TrackInventoryInd]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeAddOn]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAddOn_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAddOn_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAddOn_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeAddOn table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAddOn_Insert
(

	@AddOnID int    OUTPUT,

	@ProductID int   ,

	@Title nvarchar (MAX)  ,

	@Name nvarchar (MAX)  ,

	@Description text   ,

	@DisplayOrder int   ,

	@DisplayType nvarchar (50)  ,

	@OptionalInd bit   ,

	@AllowBackOrder bit   ,

	@InStockMsg nvarchar (MAX)  ,

	@OutOfStockMsg nvarchar (MAX)  ,

	@BackOrderMsg nvarchar (MAX)  ,

	@PromptMsg ntext   ,

	@TrackInventoryInd bit   
)
AS


					
				INSERT INTO dbo.[ZNodeAddOn]
					(
					[ProductID]
					,[Title]
					,[Name]
					,[Description]
					,[DisplayOrder]
					,[DisplayType]
					,[OptionalInd]
					,[AllowBackOrder]
					,[InStockMsg]
					,[OutOfStockMsg]
					,[BackOrderMsg]
					,[PromptMsg]
					,[TrackInventoryInd]
					)
				VALUES
					(
					@ProductID
					,@Title
					,@Name
					,@Description
					,@DisplayOrder
					,@DisplayType
					,@OptionalInd
					,@AllowBackOrder
					,@InStockMsg
					,@OutOfStockMsg
					,@BackOrderMsg
					,@PromptMsg
					,@TrackInventoryInd
					)
				
				-- Get the identity value
				SET @AddOnID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAddOn_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAddOn_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAddOn_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeAddOn table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAddOn_Update
(

	@AddOnID int   ,

	@ProductID int   ,

	@Title nvarchar (MAX)  ,

	@Name nvarchar (MAX)  ,

	@Description text   ,

	@DisplayOrder int   ,

	@DisplayType nvarchar (50)  ,

	@OptionalInd bit   ,

	@AllowBackOrder bit   ,

	@InStockMsg nvarchar (MAX)  ,

	@OutOfStockMsg nvarchar (MAX)  ,

	@BackOrderMsg nvarchar (MAX)  ,

	@PromptMsg ntext   ,

	@TrackInventoryInd bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeAddOn]
				SET
					[ProductID] = @ProductID
					,[Title] = @Title
					,[Name] = @Name
					,[Description] = @Description
					,[DisplayOrder] = @DisplayOrder
					,[DisplayType] = @DisplayType
					,[OptionalInd] = @OptionalInd
					,[AllowBackOrder] = @AllowBackOrder
					,[InStockMsg] = @InStockMsg
					,[OutOfStockMsg] = @OutOfStockMsg
					,[BackOrderMsg] = @BackOrderMsg
					,[PromptMsg] = @PromptMsg
					,[TrackInventoryInd] = @TrackInventoryInd
				WHERE
[AddOnID] = @AddOnID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAddOn_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAddOn_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAddOn_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeAddOn table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAddOn_Delete
(

	@AddOnID int   
)
AS


				DELETE FROM dbo.[ZNodeAddOn] WITH (ROWLOCK) 
				WHERE
					[AddOnID] = @AddOnID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAddOn_GetByAddOnID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAddOn_GetByAddOnID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAddOn_GetByAddOnID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeAddOn table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAddOn_GetByAddOnID
(

	@AddOnID int   
)
AS


				SELECT
					[AddOnID],
					[ProductID],
					[Title],
					[Name],
					[Description],
					[DisplayOrder],
					[DisplayType],
					[OptionalInd],
					[AllowBackOrder],
					[InStockMsg],
					[OutOfStockMsg],
					[BackOrderMsg],
					[PromptMsg],
					[TrackInventoryInd]
				FROM
					dbo.[ZNodeAddOn]
				WHERE
					[AddOnID] = @AddOnID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAddOn_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAddOn_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAddOn_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeAddOn table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAddOn_Find
(

	@SearchUsingOR bit   = null ,

	@AddOnID int   = null ,

	@ProductID int   = null ,

	@Title nvarchar (MAX)  = null ,

	@Name nvarchar (MAX)  = null ,

	@Description text   = null ,

	@DisplayOrder int   = null ,

	@DisplayType nvarchar (50)  = null ,

	@OptionalInd bit   = null ,

	@AllowBackOrder bit   = null ,

	@InStockMsg nvarchar (MAX)  = null ,

	@OutOfStockMsg nvarchar (MAX)  = null ,

	@BackOrderMsg nvarchar (MAX)  = null ,

	@PromptMsg ntext   = null ,

	@TrackInventoryInd bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AddOnID]
	, [ProductID]
	, [Title]
	, [Name]
	, [Description]
	, [DisplayOrder]
	, [DisplayType]
	, [OptionalInd]
	, [AllowBackOrder]
	, [InStockMsg]
	, [OutOfStockMsg]
	, [BackOrderMsg]
	, [PromptMsg]
	, [TrackInventoryInd]
    FROM
	dbo.[ZNodeAddOn]
    WHERE 
	 ([AddOnID] = @AddOnID OR @AddOnID is null)
	AND ([ProductID] = @ProductID OR @ProductID is null)
	AND ([Title] = @Title OR @Title is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([DisplayOrder] = @DisplayOrder OR @DisplayOrder is null)
	AND ([DisplayType] = @DisplayType OR @DisplayType is null)
	AND ([OptionalInd] = @OptionalInd OR @OptionalInd is null)
	AND ([AllowBackOrder] = @AllowBackOrder OR @AllowBackOrder is null)
	AND ([InStockMsg] = @InStockMsg OR @InStockMsg is null)
	AND ([OutOfStockMsg] = @OutOfStockMsg OR @OutOfStockMsg is null)
	AND ([BackOrderMsg] = @BackOrderMsg OR @BackOrderMsg is null)
	AND ([TrackInventoryInd] = @TrackInventoryInd OR @TrackInventoryInd is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AddOnID]
	, [ProductID]
	, [Title]
	, [Name]
	, [Description]
	, [DisplayOrder]
	, [DisplayType]
	, [OptionalInd]
	, [AllowBackOrder]
	, [InStockMsg]
	, [OutOfStockMsg]
	, [BackOrderMsg]
	, [PromptMsg]
	, [TrackInventoryInd]
    FROM
	dbo.[ZNodeAddOn]
    WHERE 
	 ([AddOnID] = @AddOnID AND @AddOnID is not null)
	OR ([ProductID] = @ProductID AND @ProductID is not null)
	OR ([Title] = @Title AND @Title is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([DisplayOrder] = @DisplayOrder AND @DisplayOrder is not null)
	OR ([DisplayType] = @DisplayType AND @DisplayType is not null)
	OR ([OptionalInd] = @OptionalInd AND @OptionalInd is not null)
	OR ([AllowBackOrder] = @AllowBackOrder AND @AllowBackOrder is not null)
	OR ([InStockMsg] = @InStockMsg AND @InStockMsg is not null)
	OR ([OutOfStockMsg] = @OutOfStockMsg AND @OutOfStockMsg is not null)
	OR ([BackOrderMsg] = @BackOrderMsg AND @BackOrderMsg is not null)
	OR ([TrackInventoryInd] = @TrackInventoryInd AND @TrackInventoryInd is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccount_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccount_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccount_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeAccount table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccount_Get_List

AS


				
				SELECT
					[AccountID],
					[ParentAccountID],
					[PortalID],
					[UserID],
					[ExternalAccountNo],
					[CompanyName],
					[AccountTypeID],
					[ProfileID],
					[AccountProfileCode],
					[SubAccountLimit],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountryCode],
					[BillingPhoneNumber],
					[BillingEmailID],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountryCode],
					[ShipEmailID],
					[ShipPhoneNumber],
					[Description],
					[CreateUser],
					[CreateDte],
					[UpdateUser],
					[UpdateDte],
					[ActiveInd],
					[Website],
					[Source],
					[ReferredBy],
					[Custom1],
					[Custom2],
					[Custom3],
					[ContactTemperatureID]
				FROM
					dbo.[ZNodeAccount]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccount_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccount_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeAccount table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[AccountID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [AccountID]'
				SET @SQL = @SQL + ', [ParentAccountID]'
				SET @SQL = @SQL + ', [PortalID]'
				SET @SQL = @SQL + ', [UserID]'
				SET @SQL = @SQL + ', [ExternalAccountNo]'
				SET @SQL = @SQL + ', [CompanyName]'
				SET @SQL = @SQL + ', [AccountTypeID]'
				SET @SQL = @SQL + ', [ProfileID]'
				SET @SQL = @SQL + ', [AccountProfileCode]'
				SET @SQL = @SQL + ', [SubAccountLimit]'
				SET @SQL = @SQL + ', [BillingFirstName]'
				SET @SQL = @SQL + ', [BillingLastName]'
				SET @SQL = @SQL + ', [BillingCompanyName]'
				SET @SQL = @SQL + ', [BillingStreet]'
				SET @SQL = @SQL + ', [BillingStreet1]'
				SET @SQL = @SQL + ', [BillingCity]'
				SET @SQL = @SQL + ', [BillingStateCode]'
				SET @SQL = @SQL + ', [BillingPostalCode]'
				SET @SQL = @SQL + ', [BillingCountryCode]'
				SET @SQL = @SQL + ', [BillingPhoneNumber]'
				SET @SQL = @SQL + ', [BillingEmailID]'
				SET @SQL = @SQL + ', [ShipFirstName]'
				SET @SQL = @SQL + ', [ShipLastName]'
				SET @SQL = @SQL + ', [ShipCompanyName]'
				SET @SQL = @SQL + ', [ShipStreet]'
				SET @SQL = @SQL + ', [ShipStreet1]'
				SET @SQL = @SQL + ', [ShipCity]'
				SET @SQL = @SQL + ', [ShipStateCode]'
				SET @SQL = @SQL + ', [ShipPostalCode]'
				SET @SQL = @SQL + ', [ShipCountryCode]'
				SET @SQL = @SQL + ', [ShipEmailID]'
				SET @SQL = @SQL + ', [ShipPhoneNumber]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [CreateUser]'
				SET @SQL = @SQL + ', [CreateDte]'
				SET @SQL = @SQL + ', [UpdateUser]'
				SET @SQL = @SQL + ', [UpdateDte]'
				SET @SQL = @SQL + ', [ActiveInd]'
				SET @SQL = @SQL + ', [Website]'
				SET @SQL = @SQL + ', [Source]'
				SET @SQL = @SQL + ', [ReferredBy]'
				SET @SQL = @SQL + ', [Custom1]'
				SET @SQL = @SQL + ', [Custom2]'
				SET @SQL = @SQL + ', [Custom3]'
				SET @SQL = @SQL + ', [ContactTemperatureID]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeAccount]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AccountID],'
				SET @SQL = @SQL + ' [ParentAccountID],'
				SET @SQL = @SQL + ' [PortalID],'
				SET @SQL = @SQL + ' [UserID],'
				SET @SQL = @SQL + ' [ExternalAccountNo],'
				SET @SQL = @SQL + ' [CompanyName],'
				SET @SQL = @SQL + ' [AccountTypeID],'
				SET @SQL = @SQL + ' [ProfileID],'
				SET @SQL = @SQL + ' [AccountProfileCode],'
				SET @SQL = @SQL + ' [SubAccountLimit],'
				SET @SQL = @SQL + ' [BillingFirstName],'
				SET @SQL = @SQL + ' [BillingLastName],'
				SET @SQL = @SQL + ' [BillingCompanyName],'
				SET @SQL = @SQL + ' [BillingStreet],'
				SET @SQL = @SQL + ' [BillingStreet1],'
				SET @SQL = @SQL + ' [BillingCity],'
				SET @SQL = @SQL + ' [BillingStateCode],'
				SET @SQL = @SQL + ' [BillingPostalCode],'
				SET @SQL = @SQL + ' [BillingCountryCode],'
				SET @SQL = @SQL + ' [BillingPhoneNumber],'
				SET @SQL = @SQL + ' [BillingEmailID],'
				SET @SQL = @SQL + ' [ShipFirstName],'
				SET @SQL = @SQL + ' [ShipLastName],'
				SET @SQL = @SQL + ' [ShipCompanyName],'
				SET @SQL = @SQL + ' [ShipStreet],'
				SET @SQL = @SQL + ' [ShipStreet1],'
				SET @SQL = @SQL + ' [ShipCity],'
				SET @SQL = @SQL + ' [ShipStateCode],'
				SET @SQL = @SQL + ' [ShipPostalCode],'
				SET @SQL = @SQL + ' [ShipCountryCode],'
				SET @SQL = @SQL + ' [ShipEmailID],'
				SET @SQL = @SQL + ' [ShipPhoneNumber],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [CreateUser],'
				SET @SQL = @SQL + ' [CreateDte],'
				SET @SQL = @SQL + ' [UpdateUser],'
				SET @SQL = @SQL + ' [UpdateDte],'
				SET @SQL = @SQL + ' [ActiveInd],'
				SET @SQL = @SQL + ' [Website],'
				SET @SQL = @SQL + ' [Source],'
				SET @SQL = @SQL + ' [ReferredBy],'
				SET @SQL = @SQL + ' [Custom1],'
				SET @SQL = @SQL + ' [Custom2],'
				SET @SQL = @SQL + ' [Custom3],'
				SET @SQL = @SQL + ' [ContactTemperatureID]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeAccount]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccount_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccount_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccount_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeAccount table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccount_Insert
(

	@AccountID int    OUTPUT,

	@ParentAccountID int   ,

	@PortalID int   ,

	@UserID uniqueidentifier   ,

	@ExternalAccountNo varchar (100)  ,

	@CompanyName varchar (100)  ,

	@AccountTypeID int   ,

	@ProfileID int   ,

	@AccountProfileCode varchar (100)  ,

	@SubAccountLimit int   ,

	@BillingFirstName varchar (100)  ,

	@BillingLastName varchar (100)  ,

	@BillingCompanyName varchar (100)  ,

	@BillingStreet varchar (100)  ,

	@BillingStreet1 varchar (100)  ,

	@BillingCity varchar (100)  ,

	@BillingStateCode varchar (2)  ,

	@BillingPostalCode varchar (10)  ,

	@BillingCountryCode varchar (2)  ,

	@BillingPhoneNumber varchar (100)  ,

	@BillingEmailID varchar (100)  ,

	@ShipFirstName varchar (100)  ,

	@ShipLastName varchar (100)  ,

	@ShipCompanyName varchar (100)  ,

	@ShipStreet varchar (100)  ,

	@ShipStreet1 varchar (100)  ,

	@ShipCity varchar (100)  ,

	@ShipStateCode varchar (2)  ,

	@ShipPostalCode varchar (10)  ,

	@ShipCountryCode varchar (2)  ,

	@ShipEmailID varchar (100)  ,

	@ShipPhoneNumber varchar (100)  ,

	@Description text   ,

	@CreateUser varchar (100)  ,

	@CreateDte smalldatetime   ,

	@UpdateUser varchar (100)  ,

	@UpdateDte smalldatetime   ,

	@ActiveInd bit   ,

	@Website varchar (250)  ,

	@Source varchar (100)  ,

	@ReferredBy varbinary   ,

	@Custom1 varchar (MAX)  ,

	@Custom2 varchar (MAX)  ,

	@Custom3 varchar (MAX)  ,

	@ContactTemperatureID int   
)
AS


					
				INSERT INTO dbo.[ZNodeAccount]
					(
					[ParentAccountID]
					,[PortalID]
					,[UserID]
					,[ExternalAccountNo]
					,[CompanyName]
					,[AccountTypeID]
					,[ProfileID]
					,[AccountProfileCode]
					,[SubAccountLimit]
					,[BillingFirstName]
					,[BillingLastName]
					,[BillingCompanyName]
					,[BillingStreet]
					,[BillingStreet1]
					,[BillingCity]
					,[BillingStateCode]
					,[BillingPostalCode]
					,[BillingCountryCode]
					,[BillingPhoneNumber]
					,[BillingEmailID]
					,[ShipFirstName]
					,[ShipLastName]
					,[ShipCompanyName]
					,[ShipStreet]
					,[ShipStreet1]
					,[ShipCity]
					,[ShipStateCode]
					,[ShipPostalCode]
					,[ShipCountryCode]
					,[ShipEmailID]
					,[ShipPhoneNumber]
					,[Description]
					,[CreateUser]
					,[CreateDte]
					,[UpdateUser]
					,[UpdateDte]
					,[ActiveInd]
					,[Website]
					,[Source]
					,[ReferredBy]
					,[Custom1]
					,[Custom2]
					,[Custom3]
					,[ContactTemperatureID]
					)
				VALUES
					(
					@ParentAccountID
					,@PortalID
					,@UserID
					,@ExternalAccountNo
					,@CompanyName
					,@AccountTypeID
					,@ProfileID
					,@AccountProfileCode
					,@SubAccountLimit
					,@BillingFirstName
					,@BillingLastName
					,@BillingCompanyName
					,@BillingStreet
					,@BillingStreet1
					,@BillingCity
					,@BillingStateCode
					,@BillingPostalCode
					,@BillingCountryCode
					,@BillingPhoneNumber
					,@BillingEmailID
					,@ShipFirstName
					,@ShipLastName
					,@ShipCompanyName
					,@ShipStreet
					,@ShipStreet1
					,@ShipCity
					,@ShipStateCode
					,@ShipPostalCode
					,@ShipCountryCode
					,@ShipEmailID
					,@ShipPhoneNumber
					,@Description
					,@CreateUser
					,@CreateDte
					,@UpdateUser
					,@UpdateDte
					,@ActiveInd
					,@Website
					,@Source
					,@ReferredBy
					,@Custom1
					,@Custom2
					,@Custom3
					,@ContactTemperatureID
					)
				
				-- Get the identity value
				SET @AccountID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccount_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccount_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccount_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeAccount table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccount_Update
(

	@AccountID int   ,

	@ParentAccountID int   ,

	@PortalID int   ,

	@UserID uniqueidentifier   ,

	@ExternalAccountNo varchar (100)  ,

	@CompanyName varchar (100)  ,

	@AccountTypeID int   ,

	@ProfileID int   ,

	@AccountProfileCode varchar (100)  ,

	@SubAccountLimit int   ,

	@BillingFirstName varchar (100)  ,

	@BillingLastName varchar (100)  ,

	@BillingCompanyName varchar (100)  ,

	@BillingStreet varchar (100)  ,

	@BillingStreet1 varchar (100)  ,

	@BillingCity varchar (100)  ,

	@BillingStateCode varchar (2)  ,

	@BillingPostalCode varchar (10)  ,

	@BillingCountryCode varchar (2)  ,

	@BillingPhoneNumber varchar (100)  ,

	@BillingEmailID varchar (100)  ,

	@ShipFirstName varchar (100)  ,

	@ShipLastName varchar (100)  ,

	@ShipCompanyName varchar (100)  ,

	@ShipStreet varchar (100)  ,

	@ShipStreet1 varchar (100)  ,

	@ShipCity varchar (100)  ,

	@ShipStateCode varchar (2)  ,

	@ShipPostalCode varchar (10)  ,

	@ShipCountryCode varchar (2)  ,

	@ShipEmailID varchar (100)  ,

	@ShipPhoneNumber varchar (100)  ,

	@Description text   ,

	@CreateUser varchar (100)  ,

	@CreateDte smalldatetime   ,

	@UpdateUser varchar (100)  ,

	@UpdateDte smalldatetime   ,

	@ActiveInd bit   ,

	@Website varchar (250)  ,

	@Source varchar (100)  ,

	@ReferredBy varbinary   ,

	@Custom1 varchar (MAX)  ,

	@Custom2 varchar (MAX)  ,

	@Custom3 varchar (MAX)  ,

	@ContactTemperatureID int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeAccount]
				SET
					[ParentAccountID] = @ParentAccountID
					,[PortalID] = @PortalID
					,[UserID] = @UserID
					,[ExternalAccountNo] = @ExternalAccountNo
					,[CompanyName] = @CompanyName
					,[AccountTypeID] = @AccountTypeID
					,[ProfileID] = @ProfileID
					,[AccountProfileCode] = @AccountProfileCode
					,[SubAccountLimit] = @SubAccountLimit
					,[BillingFirstName] = @BillingFirstName
					,[BillingLastName] = @BillingLastName
					,[BillingCompanyName] = @BillingCompanyName
					,[BillingStreet] = @BillingStreet
					,[BillingStreet1] = @BillingStreet1
					,[BillingCity] = @BillingCity
					,[BillingStateCode] = @BillingStateCode
					,[BillingPostalCode] = @BillingPostalCode
					,[BillingCountryCode] = @BillingCountryCode
					,[BillingPhoneNumber] = @BillingPhoneNumber
					,[BillingEmailID] = @BillingEmailID
					,[ShipFirstName] = @ShipFirstName
					,[ShipLastName] = @ShipLastName
					,[ShipCompanyName] = @ShipCompanyName
					,[ShipStreet] = @ShipStreet
					,[ShipStreet1] = @ShipStreet1
					,[ShipCity] = @ShipCity
					,[ShipStateCode] = @ShipStateCode
					,[ShipPostalCode] = @ShipPostalCode
					,[ShipCountryCode] = @ShipCountryCode
					,[ShipEmailID] = @ShipEmailID
					,[ShipPhoneNumber] = @ShipPhoneNumber
					,[Description] = @Description
					,[CreateUser] = @CreateUser
					,[CreateDte] = @CreateDte
					,[UpdateUser] = @UpdateUser
					,[UpdateDte] = @UpdateDte
					,[ActiveInd] = @ActiveInd
					,[Website] = @Website
					,[Source] = @Source
					,[ReferredBy] = @ReferredBy
					,[Custom1] = @Custom1
					,[Custom2] = @Custom2
					,[Custom3] = @Custom3
					,[ContactTemperatureID] = @ContactTemperatureID
				WHERE
[AccountID] = @AccountID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccount_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccount_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccount_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeAccount table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccount_Delete
(

	@AccountID int   
)
AS


				DELETE FROM dbo.[ZNodeAccount] WITH (ROWLOCK) 
				WHERE
					[AccountID] = @AccountID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccount_GetByPortalID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccount_GetByPortalID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByPortalID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeAccount table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByPortalID
(

	@PortalID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AccountID],
					[ParentAccountID],
					[PortalID],
					[UserID],
					[ExternalAccountNo],
					[CompanyName],
					[AccountTypeID],
					[ProfileID],
					[AccountProfileCode],
					[SubAccountLimit],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountryCode],
					[BillingPhoneNumber],
					[BillingEmailID],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountryCode],
					[ShipEmailID],
					[ShipPhoneNumber],
					[Description],
					[CreateUser],
					[CreateDte],
					[UpdateUser],
					[UpdateDte],
					[ActiveInd],
					[Website],
					[Source],
					[ReferredBy],
					[Custom1],
					[Custom2],
					[Custom3],
					[ContactTemperatureID]
				FROM
					dbo.[ZNodeAccount]
				WHERE
					[PortalID] = @PortalID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccount_GetByParentAccountID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccount_GetByParentAccountID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByParentAccountID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeAccount table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByParentAccountID
(

	@ParentAccountID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AccountID],
					[ParentAccountID],
					[PortalID],
					[UserID],
					[ExternalAccountNo],
					[CompanyName],
					[AccountTypeID],
					[ProfileID],
					[AccountProfileCode],
					[SubAccountLimit],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountryCode],
					[BillingPhoneNumber],
					[BillingEmailID],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountryCode],
					[ShipEmailID],
					[ShipPhoneNumber],
					[Description],
					[CreateUser],
					[CreateDte],
					[UpdateUser],
					[UpdateDte],
					[ActiveInd],
					[Website],
					[Source],
					[ReferredBy],
					[Custom1],
					[Custom2],
					[Custom3],
					[ContactTemperatureID]
				FROM
					dbo.[ZNodeAccount]
				WHERE
					[ParentAccountID] = @ParentAccountID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccount_GetByAccountTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccount_GetByAccountTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByAccountTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeAccount table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByAccountTypeID
(

	@AccountTypeID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AccountID],
					[ParentAccountID],
					[PortalID],
					[UserID],
					[ExternalAccountNo],
					[CompanyName],
					[AccountTypeID],
					[ProfileID],
					[AccountProfileCode],
					[SubAccountLimit],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountryCode],
					[BillingPhoneNumber],
					[BillingEmailID],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountryCode],
					[ShipEmailID],
					[ShipPhoneNumber],
					[Description],
					[CreateUser],
					[CreateDte],
					[UpdateUser],
					[UpdateDte],
					[ActiveInd],
					[Website],
					[Source],
					[ReferredBy],
					[Custom1],
					[Custom2],
					[Custom3],
					[ContactTemperatureID]
				FROM
					dbo.[ZNodeAccount]
				WHERE
					[AccountTypeID] = @AccountTypeID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccount_GetByUserID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccount_GetByUserID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByUserID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeAccount table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByUserID
(

	@UserID uniqueidentifier   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AccountID],
					[ParentAccountID],
					[PortalID],
					[UserID],
					[ExternalAccountNo],
					[CompanyName],
					[AccountTypeID],
					[ProfileID],
					[AccountProfileCode],
					[SubAccountLimit],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountryCode],
					[BillingPhoneNumber],
					[BillingEmailID],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountryCode],
					[ShipEmailID],
					[ShipPhoneNumber],
					[Description],
					[CreateUser],
					[CreateDte],
					[UpdateUser],
					[UpdateDte],
					[ActiveInd],
					[Website],
					[Source],
					[ReferredBy],
					[Custom1],
					[Custom2],
					[Custom3],
					[ContactTemperatureID]
				FROM
					dbo.[ZNodeAccount]
				WHERE
					[UserID] = @UserID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccount_GetByProfileID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccount_GetByProfileID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByProfileID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeAccount table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByProfileID
(

	@ProfileID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AccountID],
					[ParentAccountID],
					[PortalID],
					[UserID],
					[ExternalAccountNo],
					[CompanyName],
					[AccountTypeID],
					[ProfileID],
					[AccountProfileCode],
					[SubAccountLimit],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountryCode],
					[BillingPhoneNumber],
					[BillingEmailID],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountryCode],
					[ShipEmailID],
					[ShipPhoneNumber],
					[Description],
					[CreateUser],
					[CreateDte],
					[UpdateUser],
					[UpdateDte],
					[ActiveInd],
					[Website],
					[Source],
					[ReferredBy],
					[Custom1],
					[Custom2],
					[Custom3],
					[ContactTemperatureID]
				FROM
					dbo.[ZNodeAccount]
				WHERE
					[ProfileID] = @ProfileID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccount_GetByContactTemperatureID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccount_GetByContactTemperatureID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByContactTemperatureID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeAccount table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByContactTemperatureID
(

	@ContactTemperatureID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AccountID],
					[ParentAccountID],
					[PortalID],
					[UserID],
					[ExternalAccountNo],
					[CompanyName],
					[AccountTypeID],
					[ProfileID],
					[AccountProfileCode],
					[SubAccountLimit],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountryCode],
					[BillingPhoneNumber],
					[BillingEmailID],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountryCode],
					[ShipEmailID],
					[ShipPhoneNumber],
					[Description],
					[CreateUser],
					[CreateDte],
					[UpdateUser],
					[UpdateDte],
					[ActiveInd],
					[Website],
					[Source],
					[ReferredBy],
					[Custom1],
					[Custom2],
					[Custom3],
					[ContactTemperatureID]
				FROM
					dbo.[ZNodeAccount]
				WHERE
					[ContactTemperatureID] = @ContactTemperatureID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccount_GetByAccountID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccount_GetByAccountID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByAccountID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeAccount table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByAccountID
(

	@AccountID int   
)
AS


				SELECT
					[AccountID],
					[ParentAccountID],
					[PortalID],
					[UserID],
					[ExternalAccountNo],
					[CompanyName],
					[AccountTypeID],
					[ProfileID],
					[AccountProfileCode],
					[SubAccountLimit],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountryCode],
					[BillingPhoneNumber],
					[BillingEmailID],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountryCode],
					[ShipEmailID],
					[ShipPhoneNumber],
					[Description],
					[CreateUser],
					[CreateDte],
					[UpdateUser],
					[UpdateDte],
					[ActiveInd],
					[Website],
					[Source],
					[ReferredBy],
					[Custom1],
					[Custom2],
					[Custom3],
					[ContactTemperatureID]
				FROM
					dbo.[ZNodeAccount]
				WHERE
					[AccountID] = @AccountID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccount_GetByCompanyName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccount_GetByCompanyName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByCompanyName
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeAccount table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccount_GetByCompanyName
(

	@CompanyName varchar (100)  
)
AS


				SELECT
					[AccountID],
					[ParentAccountID],
					[PortalID],
					[UserID],
					[ExternalAccountNo],
					[CompanyName],
					[AccountTypeID],
					[ProfileID],
					[AccountProfileCode],
					[SubAccountLimit],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountryCode],
					[BillingPhoneNumber],
					[BillingEmailID],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountryCode],
					[ShipEmailID],
					[ShipPhoneNumber],
					[Description],
					[CreateUser],
					[CreateDte],
					[UpdateUser],
					[UpdateDte],
					[ActiveInd],
					[Website],
					[Source],
					[ReferredBy],
					[Custom1],
					[Custom2],
					[Custom3],
					[ContactTemperatureID]
				FROM
					dbo.[ZNodeAccount]
				WHERE
					[CompanyName] = @CompanyName
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAccount_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAccount_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAccount_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeAccount table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAccount_Find
(

	@SearchUsingOR bit   = null ,

	@AccountID int   = null ,

	@ParentAccountID int   = null ,

	@PortalID int   = null ,

	@UserID uniqueidentifier   = null ,

	@ExternalAccountNo varchar (100)  = null ,

	@CompanyName varchar (100)  = null ,

	@AccountTypeID int   = null ,

	@ProfileID int   = null ,

	@AccountProfileCode varchar (100)  = null ,

	@SubAccountLimit int   = null ,

	@BillingFirstName varchar (100)  = null ,

	@BillingLastName varchar (100)  = null ,

	@BillingCompanyName varchar (100)  = null ,

	@BillingStreet varchar (100)  = null ,

	@BillingStreet1 varchar (100)  = null ,

	@BillingCity varchar (100)  = null ,

	@BillingStateCode varchar (2)  = null ,

	@BillingPostalCode varchar (10)  = null ,

	@BillingCountryCode varchar (2)  = null ,

	@BillingPhoneNumber varchar (100)  = null ,

	@BillingEmailID varchar (100)  = null ,

	@ShipFirstName varchar (100)  = null ,

	@ShipLastName varchar (100)  = null ,

	@ShipCompanyName varchar (100)  = null ,

	@ShipStreet varchar (100)  = null ,

	@ShipStreet1 varchar (100)  = null ,

	@ShipCity varchar (100)  = null ,

	@ShipStateCode varchar (2)  = null ,

	@ShipPostalCode varchar (10)  = null ,

	@ShipCountryCode varchar (2)  = null ,

	@ShipEmailID varchar (100)  = null ,

	@ShipPhoneNumber varchar (100)  = null ,

	@Description text   = null ,

	@CreateUser varchar (100)  = null ,

	@CreateDte smalldatetime   = null ,

	@UpdateUser varchar (100)  = null ,

	@UpdateDte smalldatetime   = null ,

	@ActiveInd bit   = null ,

	@Website varchar (250)  = null ,

	@Source varchar (100)  = null ,

	@ReferredBy varbinary   = null ,

	@Custom1 varchar (MAX)  = null ,

	@Custom2 varchar (MAX)  = null ,

	@Custom3 varchar (MAX)  = null ,

	@ContactTemperatureID int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AccountID]
	, [ParentAccountID]
	, [PortalID]
	, [UserID]
	, [ExternalAccountNo]
	, [CompanyName]
	, [AccountTypeID]
	, [ProfileID]
	, [AccountProfileCode]
	, [SubAccountLimit]
	, [BillingFirstName]
	, [BillingLastName]
	, [BillingCompanyName]
	, [BillingStreet]
	, [BillingStreet1]
	, [BillingCity]
	, [BillingStateCode]
	, [BillingPostalCode]
	, [BillingCountryCode]
	, [BillingPhoneNumber]
	, [BillingEmailID]
	, [ShipFirstName]
	, [ShipLastName]
	, [ShipCompanyName]
	, [ShipStreet]
	, [ShipStreet1]
	, [ShipCity]
	, [ShipStateCode]
	, [ShipPostalCode]
	, [ShipCountryCode]
	, [ShipEmailID]
	, [ShipPhoneNumber]
	, [Description]
	, [CreateUser]
	, [CreateDte]
	, [UpdateUser]
	, [UpdateDte]
	, [ActiveInd]
	, [Website]
	, [Source]
	, [ReferredBy]
	, [Custom1]
	, [Custom2]
	, [Custom3]
	, [ContactTemperatureID]
    FROM
	dbo.[ZNodeAccount]
    WHERE 
	 ([AccountID] = @AccountID OR @AccountID is null)
	AND ([ParentAccountID] = @ParentAccountID OR @ParentAccountID is null)
	AND ([PortalID] = @PortalID OR @PortalID is null)
	AND ([UserID] = @UserID OR @UserID is null)
	AND ([ExternalAccountNo] = @ExternalAccountNo OR @ExternalAccountNo is null)
	AND ([CompanyName] = @CompanyName OR @CompanyName is null)
	AND ([AccountTypeID] = @AccountTypeID OR @AccountTypeID is null)
	AND ([ProfileID] = @ProfileID OR @ProfileID is null)
	AND ([AccountProfileCode] = @AccountProfileCode OR @AccountProfileCode is null)
	AND ([SubAccountLimit] = @SubAccountLimit OR @SubAccountLimit is null)
	AND ([BillingFirstName] = @BillingFirstName OR @BillingFirstName is null)
	AND ([BillingLastName] = @BillingLastName OR @BillingLastName is null)
	AND ([BillingCompanyName] = @BillingCompanyName OR @BillingCompanyName is null)
	AND ([BillingStreet] = @BillingStreet OR @BillingStreet is null)
	AND ([BillingStreet1] = @BillingStreet1 OR @BillingStreet1 is null)
	AND ([BillingCity] = @BillingCity OR @BillingCity is null)
	AND ([BillingStateCode] = @BillingStateCode OR @BillingStateCode is null)
	AND ([BillingPostalCode] = @BillingPostalCode OR @BillingPostalCode is null)
	AND ([BillingCountryCode] = @BillingCountryCode OR @BillingCountryCode is null)
	AND ([BillingPhoneNumber] = @BillingPhoneNumber OR @BillingPhoneNumber is null)
	AND ([BillingEmailID] = @BillingEmailID OR @BillingEmailID is null)
	AND ([ShipFirstName] = @ShipFirstName OR @ShipFirstName is null)
	AND ([ShipLastName] = @ShipLastName OR @ShipLastName is null)
	AND ([ShipCompanyName] = @ShipCompanyName OR @ShipCompanyName is null)
	AND ([ShipStreet] = @ShipStreet OR @ShipStreet is null)
	AND ([ShipStreet1] = @ShipStreet1 OR @ShipStreet1 is null)
	AND ([ShipCity] = @ShipCity OR @ShipCity is null)
	AND ([ShipStateCode] = @ShipStateCode OR @ShipStateCode is null)
	AND ([ShipPostalCode] = @ShipPostalCode OR @ShipPostalCode is null)
	AND ([ShipCountryCode] = @ShipCountryCode OR @ShipCountryCode is null)
	AND ([ShipEmailID] = @ShipEmailID OR @ShipEmailID is null)
	AND ([ShipPhoneNumber] = @ShipPhoneNumber OR @ShipPhoneNumber is null)
	AND ([CreateUser] = @CreateUser OR @CreateUser is null)
	AND ([CreateDte] = @CreateDte OR @CreateDte is null)
	AND ([UpdateUser] = @UpdateUser OR @UpdateUser is null)
	AND ([UpdateDte] = @UpdateDte OR @UpdateDte is null)
	AND ([ActiveInd] = @ActiveInd OR @ActiveInd is null)
	AND ([Website] = @Website OR @Website is null)
	AND ([Source] = @Source OR @Source is null)
	AND ([Custom1] = @Custom1 OR @Custom1 is null)
	AND ([Custom2] = @Custom2 OR @Custom2 is null)
	AND ([Custom3] = @Custom3 OR @Custom3 is null)
	AND ([ContactTemperatureID] = @ContactTemperatureID OR @ContactTemperatureID is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AccountID]
	, [ParentAccountID]
	, [PortalID]
	, [UserID]
	, [ExternalAccountNo]
	, [CompanyName]
	, [AccountTypeID]
	, [ProfileID]
	, [AccountProfileCode]
	, [SubAccountLimit]
	, [BillingFirstName]
	, [BillingLastName]
	, [BillingCompanyName]
	, [BillingStreet]
	, [BillingStreet1]
	, [BillingCity]
	, [BillingStateCode]
	, [BillingPostalCode]
	, [BillingCountryCode]
	, [BillingPhoneNumber]
	, [BillingEmailID]
	, [ShipFirstName]
	, [ShipLastName]
	, [ShipCompanyName]
	, [ShipStreet]
	, [ShipStreet1]
	, [ShipCity]
	, [ShipStateCode]
	, [ShipPostalCode]
	, [ShipCountryCode]
	, [ShipEmailID]
	, [ShipPhoneNumber]
	, [Description]
	, [CreateUser]
	, [CreateDte]
	, [UpdateUser]
	, [UpdateDte]
	, [ActiveInd]
	, [Website]
	, [Source]
	, [ReferredBy]
	, [Custom1]
	, [Custom2]
	, [Custom3]
	, [ContactTemperatureID]
    FROM
	dbo.[ZNodeAccount]
    WHERE 
	 ([AccountID] = @AccountID AND @AccountID is not null)
	OR ([ParentAccountID] = @ParentAccountID AND @ParentAccountID is not null)
	OR ([PortalID] = @PortalID AND @PortalID is not null)
	OR ([UserID] = @UserID AND @UserID is not null)
	OR ([ExternalAccountNo] = @ExternalAccountNo AND @ExternalAccountNo is not null)
	OR ([CompanyName] = @CompanyName AND @CompanyName is not null)
	OR ([AccountTypeID] = @AccountTypeID AND @AccountTypeID is not null)
	OR ([ProfileID] = @ProfileID AND @ProfileID is not null)
	OR ([AccountProfileCode] = @AccountProfileCode AND @AccountProfileCode is not null)
	OR ([SubAccountLimit] = @SubAccountLimit AND @SubAccountLimit is not null)
	OR ([BillingFirstName] = @BillingFirstName AND @BillingFirstName is not null)
	OR ([BillingLastName] = @BillingLastName AND @BillingLastName is not null)
	OR ([BillingCompanyName] = @BillingCompanyName AND @BillingCompanyName is not null)
	OR ([BillingStreet] = @BillingStreet AND @BillingStreet is not null)
	OR ([BillingStreet1] = @BillingStreet1 AND @BillingStreet1 is not null)
	OR ([BillingCity] = @BillingCity AND @BillingCity is not null)
	OR ([BillingStateCode] = @BillingStateCode AND @BillingStateCode is not null)
	OR ([BillingPostalCode] = @BillingPostalCode AND @BillingPostalCode is not null)
	OR ([BillingCountryCode] = @BillingCountryCode AND @BillingCountryCode is not null)
	OR ([BillingPhoneNumber] = @BillingPhoneNumber AND @BillingPhoneNumber is not null)
	OR ([BillingEmailID] = @BillingEmailID AND @BillingEmailID is not null)
	OR ([ShipFirstName] = @ShipFirstName AND @ShipFirstName is not null)
	OR ([ShipLastName] = @ShipLastName AND @ShipLastName is not null)
	OR ([ShipCompanyName] = @ShipCompanyName AND @ShipCompanyName is not null)
	OR ([ShipStreet] = @ShipStreet AND @ShipStreet is not null)
	OR ([ShipStreet1] = @ShipStreet1 AND @ShipStreet1 is not null)
	OR ([ShipCity] = @ShipCity AND @ShipCity is not null)
	OR ([ShipStateCode] = @ShipStateCode AND @ShipStateCode is not null)
	OR ([ShipPostalCode] = @ShipPostalCode AND @ShipPostalCode is not null)
	OR ([ShipCountryCode] = @ShipCountryCode AND @ShipCountryCode is not null)
	OR ([ShipEmailID] = @ShipEmailID AND @ShipEmailID is not null)
	OR ([ShipPhoneNumber] = @ShipPhoneNumber AND @ShipPhoneNumber is not null)
	OR ([CreateUser] = @CreateUser AND @CreateUser is not null)
	OR ([CreateDte] = @CreateDte AND @CreateDte is not null)
	OR ([UpdateUser] = @UpdateUser AND @UpdateUser is not null)
	OR ([UpdateDte] = @UpdateDte AND @UpdateDte is not null)
	OR ([ActiveInd] = @ActiveInd AND @ActiveInd is not null)
	OR ([Website] = @Website AND @Website is not null)
	OR ([Source] = @Source AND @Source is not null)
	OR ([Custom1] = @Custom1 AND @Custom1 is not null)
	OR ([Custom2] = @Custom2 AND @Custom2 is not null)
	OR ([Custom3] = @Custom3 AND @Custom3 is not null)
	OR ([ContactTemperatureID] = @ContactTemperatureID AND @ContactTemperatureID is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAddOnValue_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAddOnValue_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeAddOnValue table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_Get_List

AS


				
				SELECT
					[AddOnValueID],
					[AddOnID],
					[Name],
					[Description],
					[SKU],
					[QuantityOnHand],
					[DefaultInd],
					[DisplayOrder],
					[ImageFile],
					[Price],
					[Weight]
				FROM
					dbo.[ZNodeAddOnValue]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAddOnValue_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAddOnValue_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeAddOnValue table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[AddOnValueID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [AddOnValueID]'
				SET @SQL = @SQL + ', [AddOnID]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [SKU]'
				SET @SQL = @SQL + ', [QuantityOnHand]'
				SET @SQL = @SQL + ', [DefaultInd]'
				SET @SQL = @SQL + ', [DisplayOrder]'
				SET @SQL = @SQL + ', [ImageFile]'
				SET @SQL = @SQL + ', [Price]'
				SET @SQL = @SQL + ', [Weight]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeAddOnValue]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AddOnValueID],'
				SET @SQL = @SQL + ' [AddOnID],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [SKU],'
				SET @SQL = @SQL + ' [QuantityOnHand],'
				SET @SQL = @SQL + ' [DefaultInd],'
				SET @SQL = @SQL + ' [DisplayOrder],'
				SET @SQL = @SQL + ' [ImageFile],'
				SET @SQL = @SQL + ' [Price],'
				SET @SQL = @SQL + ' [Weight]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeAddOnValue]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAddOnValue_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAddOnValue_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeAddOnValue table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_Insert
(

	@AddOnValueID int    OUTPUT,

	@AddOnID int   ,

	@Name nvarchar (MAX)  ,

	@Description ntext   ,

	@SKU nvarchar (MAX)  ,

	@QuantityOnHand int   ,

	@DefaultInd bit   ,

	@DisplayOrder int   ,

	@ImageFile nvarchar (MAX)  ,

	@Price decimal (18, 2)  ,

	@Weight decimal (18, 2)  
)
AS


					
				INSERT INTO dbo.[ZNodeAddOnValue]
					(
					[AddOnID]
					,[Name]
					,[Description]
					,[SKU]
					,[QuantityOnHand]
					,[DefaultInd]
					,[DisplayOrder]
					,[ImageFile]
					,[Price]
					,[Weight]
					)
				VALUES
					(
					@AddOnID
					,@Name
					,@Description
					,@SKU
					,@QuantityOnHand
					,@DefaultInd
					,@DisplayOrder
					,@ImageFile
					,@Price
					,@Weight
					)
				
				-- Get the identity value
				SET @AddOnValueID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAddOnValue_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAddOnValue_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeAddOnValue table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_Update
(

	@AddOnValueID int   ,

	@AddOnID int   ,

	@Name nvarchar (MAX)  ,

	@Description ntext   ,

	@SKU nvarchar (MAX)  ,

	@QuantityOnHand int   ,

	@DefaultInd bit   ,

	@DisplayOrder int   ,

	@ImageFile nvarchar (MAX)  ,

	@Price decimal (18, 2)  ,

	@Weight decimal (18, 2)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeAddOnValue]
				SET
					[AddOnID] = @AddOnID
					,[Name] = @Name
					,[Description] = @Description
					,[SKU] = @SKU
					,[QuantityOnHand] = @QuantityOnHand
					,[DefaultInd] = @DefaultInd
					,[DisplayOrder] = @DisplayOrder
					,[ImageFile] = @ImageFile
					,[Price] = @Price
					,[Weight] = @Weight
				WHERE
[AddOnValueID] = @AddOnValueID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAddOnValue_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAddOnValue_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeAddOnValue table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_Delete
(

	@AddOnValueID int   
)
AS


				DELETE FROM dbo.[ZNodeAddOnValue] WITH (ROWLOCK) 
				WHERE
					[AddOnValueID] = @AddOnValueID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAddOnValue_GetByAddOnID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAddOnValue_GetByAddOnID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_GetByAddOnID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeAddOnValue table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_GetByAddOnID
(

	@AddOnID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AddOnValueID],
					[AddOnID],
					[Name],
					[Description],
					[SKU],
					[QuantityOnHand],
					[DefaultInd],
					[DisplayOrder],
					[ImageFile],
					[Price],
					[Weight]
				FROM
					dbo.[ZNodeAddOnValue]
				WHERE
					[AddOnID] = @AddOnID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAddOnValue_GetByAddOnValueID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAddOnValue_GetByAddOnValueID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_GetByAddOnValueID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeAddOnValue table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_GetByAddOnValueID
(

	@AddOnValueID int   
)
AS


				SELECT
					[AddOnValueID],
					[AddOnID],
					[Name],
					[Description],
					[SKU],
					[QuantityOnHand],
					[DefaultInd],
					[DisplayOrder],
					[ImageFile],
					[Price],
					[Weight]
				FROM
					dbo.[ZNodeAddOnValue]
				WHERE
					[AddOnValueID] = @AddOnValueID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAddOnValue_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAddOnValue_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeAddOnValue table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAddOnValue_Find
(

	@SearchUsingOR bit   = null ,

	@AddOnValueID int   = null ,

	@AddOnID int   = null ,

	@Name nvarchar (MAX)  = null ,

	@Description ntext   = null ,

	@SKU nvarchar (MAX)  = null ,

	@QuantityOnHand int   = null ,

	@DefaultInd bit   = null ,

	@DisplayOrder int   = null ,

	@ImageFile nvarchar (MAX)  = null ,

	@Price decimal (18, 2)  = null ,

	@Weight decimal (18, 2)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AddOnValueID]
	, [AddOnID]
	, [Name]
	, [Description]
	, [SKU]
	, [QuantityOnHand]
	, [DefaultInd]
	, [DisplayOrder]
	, [ImageFile]
	, [Price]
	, [Weight]
    FROM
	dbo.[ZNodeAddOnValue]
    WHERE 
	 ([AddOnValueID] = @AddOnValueID OR @AddOnValueID is null)
	AND ([AddOnID] = @AddOnID OR @AddOnID is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([SKU] = @SKU OR @SKU is null)
	AND ([QuantityOnHand] = @QuantityOnHand OR @QuantityOnHand is null)
	AND ([DefaultInd] = @DefaultInd OR @DefaultInd is null)
	AND ([DisplayOrder] = @DisplayOrder OR @DisplayOrder is null)
	AND ([ImageFile] = @ImageFile OR @ImageFile is null)
	AND ([Price] = @Price OR @Price is null)
	AND ([Weight] = @Weight OR @Weight is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AddOnValueID]
	, [AddOnID]
	, [Name]
	, [Description]
	, [SKU]
	, [QuantityOnHand]
	, [DefaultInd]
	, [DisplayOrder]
	, [ImageFile]
	, [Price]
	, [Weight]
    FROM
	dbo.[ZNodeAddOnValue]
    WHERE 
	 ([AddOnValueID] = @AddOnValueID AND @AddOnValueID is not null)
	OR ([AddOnID] = @AddOnID AND @AddOnID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([SKU] = @SKU AND @SKU is not null)
	OR ([QuantityOnHand] = @QuantityOnHand AND @QuantityOnHand is not null)
	OR ([DefaultInd] = @DefaultInd AND @DefaultInd is not null)
	OR ([DisplayOrder] = @DisplayOrder AND @DisplayOrder is not null)
	OR ([ImageFile] = @ImageFile AND @ImageFile is not null)
	OR ([Price] = @Price AND @Price is not null)
	OR ([Weight] = @Weight AND @Weight is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCase_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCase_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCase_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeCase table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCase_Get_List

AS


				
				SELECT
					[CaseID],
					[PortalID],
					[AccountID],
					[OwnerAccountID],
					[CaseStatusID],
					[CasePriorityID],
					[CaseTypeID],
					[CaseOrigin],
					[Title],
					[Description],
					[FirstName],
					[LastName],
					[CompanyName],
					[EmailID],
					[PhoneNumber],
					[CreateDte],
					[CreateUser]
				FROM
					dbo.[ZNodeCase]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCase_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCase_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeCase table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[CaseID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [CaseID]'
				SET @SQL = @SQL + ', [PortalID]'
				SET @SQL = @SQL + ', [AccountID]'
				SET @SQL = @SQL + ', [OwnerAccountID]'
				SET @SQL = @SQL + ', [CaseStatusID]'
				SET @SQL = @SQL + ', [CasePriorityID]'
				SET @SQL = @SQL + ', [CaseTypeID]'
				SET @SQL = @SQL + ', [CaseOrigin]'
				SET @SQL = @SQL + ', [Title]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [FirstName]'
				SET @SQL = @SQL + ', [LastName]'
				SET @SQL = @SQL + ', [CompanyName]'
				SET @SQL = @SQL + ', [EmailID]'
				SET @SQL = @SQL + ', [PhoneNumber]'
				SET @SQL = @SQL + ', [CreateDte]'
				SET @SQL = @SQL + ', [CreateUser]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeCase]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CaseID],'
				SET @SQL = @SQL + ' [PortalID],'
				SET @SQL = @SQL + ' [AccountID],'
				SET @SQL = @SQL + ' [OwnerAccountID],'
				SET @SQL = @SQL + ' [CaseStatusID],'
				SET @SQL = @SQL + ' [CasePriorityID],'
				SET @SQL = @SQL + ' [CaseTypeID],'
				SET @SQL = @SQL + ' [CaseOrigin],'
				SET @SQL = @SQL + ' [Title],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [FirstName],'
				SET @SQL = @SQL + ' [LastName],'
				SET @SQL = @SQL + ' [CompanyName],'
				SET @SQL = @SQL + ' [EmailID],'
				SET @SQL = @SQL + ' [PhoneNumber],'
				SET @SQL = @SQL + ' [CreateDte],'
				SET @SQL = @SQL + ' [CreateUser]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeCase]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCase_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCase_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCase_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeCase table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCase_Insert
(

	@CaseID int    OUTPUT,

	@PortalID int   ,

	@AccountID int   ,

	@OwnerAccountID int   ,

	@CaseStatusID int   ,

	@CasePriorityID int   ,

	@CaseTypeID int   ,

	@CaseOrigin varchar (50)  ,

	@Title varchar (255)  ,

	@Description ntext   ,

	@FirstName varchar (100)  ,

	@LastName varchar (100)  ,

	@CompanyName varchar (100)  ,

	@EmailID varchar (200)  ,

	@PhoneNumber varchar (20)  ,

	@CreateDte smalldatetime   ,

	@CreateUser varchar (100)  
)
AS


					
				INSERT INTO dbo.[ZNodeCase]
					(
					[PortalID]
					,[AccountID]
					,[OwnerAccountID]
					,[CaseStatusID]
					,[CasePriorityID]
					,[CaseTypeID]
					,[CaseOrigin]
					,[Title]
					,[Description]
					,[FirstName]
					,[LastName]
					,[CompanyName]
					,[EmailID]
					,[PhoneNumber]
					,[CreateDte]
					,[CreateUser]
					)
				VALUES
					(
					@PortalID
					,@AccountID
					,@OwnerAccountID
					,@CaseStatusID
					,@CasePriorityID
					,@CaseTypeID
					,@CaseOrigin
					,@Title
					,@Description
					,@FirstName
					,@LastName
					,@CompanyName
					,@EmailID
					,@PhoneNumber
					,@CreateDte
					,@CreateUser
					)
				
				-- Get the identity value
				SET @CaseID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCase_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCase_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCase_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeCase table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCase_Update
(

	@CaseID int   ,

	@PortalID int   ,

	@AccountID int   ,

	@OwnerAccountID int   ,

	@CaseStatusID int   ,

	@CasePriorityID int   ,

	@CaseTypeID int   ,

	@CaseOrigin varchar (50)  ,

	@Title varchar (255)  ,

	@Description ntext   ,

	@FirstName varchar (100)  ,

	@LastName varchar (100)  ,

	@CompanyName varchar (100)  ,

	@EmailID varchar (200)  ,

	@PhoneNumber varchar (20)  ,

	@CreateDte smalldatetime   ,

	@CreateUser varchar (100)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeCase]
				SET
					[PortalID] = @PortalID
					,[AccountID] = @AccountID
					,[OwnerAccountID] = @OwnerAccountID
					,[CaseStatusID] = @CaseStatusID
					,[CasePriorityID] = @CasePriorityID
					,[CaseTypeID] = @CaseTypeID
					,[CaseOrigin] = @CaseOrigin
					,[Title] = @Title
					,[Description] = @Description
					,[FirstName] = @FirstName
					,[LastName] = @LastName
					,[CompanyName] = @CompanyName
					,[EmailID] = @EmailID
					,[PhoneNumber] = @PhoneNumber
					,[CreateDte] = @CreateDte
					,[CreateUser] = @CreateUser
				WHERE
[CaseID] = @CaseID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCase_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCase_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCase_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeCase table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCase_Delete
(

	@CaseID int   
)
AS


				DELETE FROM dbo.[ZNodeCase] WITH (ROWLOCK) 
				WHERE
					[CaseID] = @CaseID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCase_GetByPortalID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCase_GetByPortalID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByPortalID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCase table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByPortalID
(

	@PortalID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[CaseID],
					[PortalID],
					[AccountID],
					[OwnerAccountID],
					[CaseStatusID],
					[CasePriorityID],
					[CaseTypeID],
					[CaseOrigin],
					[Title],
					[Description],
					[FirstName],
					[LastName],
					[CompanyName],
					[EmailID],
					[PhoneNumber],
					[CreateDte],
					[CreateUser]
				FROM
					dbo.[ZNodeCase]
				WHERE
					[PortalID] = @PortalID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCase_GetByAccountID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCase_GetByAccountID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByAccountID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCase table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByAccountID
(

	@AccountID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[CaseID],
					[PortalID],
					[AccountID],
					[OwnerAccountID],
					[CaseStatusID],
					[CasePriorityID],
					[CaseTypeID],
					[CaseOrigin],
					[Title],
					[Description],
					[FirstName],
					[LastName],
					[CompanyName],
					[EmailID],
					[PhoneNumber],
					[CreateDte],
					[CreateUser]
				FROM
					dbo.[ZNodeCase]
				WHERE
					[AccountID] = @AccountID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCase_GetByCaseTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCase_GetByCaseTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByCaseTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCase table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByCaseTypeID
(

	@CaseTypeID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[CaseID],
					[PortalID],
					[AccountID],
					[OwnerAccountID],
					[CaseStatusID],
					[CasePriorityID],
					[CaseTypeID],
					[CaseOrigin],
					[Title],
					[Description],
					[FirstName],
					[LastName],
					[CompanyName],
					[EmailID],
					[PhoneNumber],
					[CreateDte],
					[CreateUser]
				FROM
					dbo.[ZNodeCase]
				WHERE
					[CaseTypeID] = @CaseTypeID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCase_GetByCasePriorityID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCase_GetByCasePriorityID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByCasePriorityID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCase table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByCasePriorityID
(

	@CasePriorityID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[CaseID],
					[PortalID],
					[AccountID],
					[OwnerAccountID],
					[CaseStatusID],
					[CasePriorityID],
					[CaseTypeID],
					[CaseOrigin],
					[Title],
					[Description],
					[FirstName],
					[LastName],
					[CompanyName],
					[EmailID],
					[PhoneNumber],
					[CreateDte],
					[CreateUser]
				FROM
					dbo.[ZNodeCase]
				WHERE
					[CasePriorityID] = @CasePriorityID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCase_GetByCaseID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCase_GetByCaseID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByCaseID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCase table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByCaseID
(

	@CaseID int   
)
AS


				SELECT
					[CaseID],
					[PortalID],
					[AccountID],
					[OwnerAccountID],
					[CaseStatusID],
					[CasePriorityID],
					[CaseTypeID],
					[CaseOrigin],
					[Title],
					[Description],
					[FirstName],
					[LastName],
					[CompanyName],
					[EmailID],
					[PhoneNumber],
					[CreateDte],
					[CreateUser]
				FROM
					dbo.[ZNodeCase]
				WHERE
					[CaseID] = @CaseID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCase_GetByAccountIDCaseTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCase_GetByAccountIDCaseTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByAccountIDCaseTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCase table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByAccountIDCaseTypeID
(

	@AccountID int   ,

	@CaseTypeID int   
)
AS


				SELECT
					[CaseID],
					[PortalID],
					[AccountID],
					[OwnerAccountID],
					[CaseStatusID],
					[CasePriorityID],
					[CaseTypeID],
					[CaseOrigin],
					[Title],
					[Description],
					[FirstName],
					[LastName],
					[CompanyName],
					[EmailID],
					[PhoneNumber],
					[CreateDte],
					[CreateUser]
				FROM
					dbo.[ZNodeCase]
				WHERE
					[AccountID] = @AccountID
					AND [CaseTypeID] = @CaseTypeID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCase_GetByOwnerAccountID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCase_GetByOwnerAccountID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByOwnerAccountID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCase table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByOwnerAccountID
(

	@OwnerAccountID int   
)
AS


				SELECT
					[CaseID],
					[PortalID],
					[AccountID],
					[OwnerAccountID],
					[CaseStatusID],
					[CasePriorityID],
					[CaseTypeID],
					[CaseOrigin],
					[Title],
					[Description],
					[FirstName],
					[LastName],
					[CompanyName],
					[EmailID],
					[PhoneNumber],
					[CreateDte],
					[CreateUser]
				FROM
					dbo.[ZNodeCase]
				WHERE
					[OwnerAccountID] = @OwnerAccountID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCase_GetByCaseStatusID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCase_GetByCaseStatusID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByCaseStatusID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCase table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByCaseStatusID
(

	@CaseStatusID int   
)
AS


				SELECT
					[CaseID],
					[PortalID],
					[AccountID],
					[OwnerAccountID],
					[CaseStatusID],
					[CasePriorityID],
					[CaseTypeID],
					[CaseOrigin],
					[Title],
					[Description],
					[FirstName],
					[LastName],
					[CompanyName],
					[EmailID],
					[PhoneNumber],
					[CreateDte],
					[CreateUser]
				FROM
					dbo.[ZNodeCase]
				WHERE
					[CaseStatusID] = @CaseStatusID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCase_GetByTitleFirstNameLastNameCompanyName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCase_GetByTitleFirstNameLastNameCompanyName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByTitleFirstNameLastNameCompanyName
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCase table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCase_GetByTitleFirstNameLastNameCompanyName
(

	@Title varchar (255)  ,

	@FirstName varchar (100)  ,

	@LastName varchar (100)  ,

	@CompanyName varchar (100)  
)
AS


				SELECT
					[CaseID],
					[PortalID],
					[AccountID],
					[OwnerAccountID],
					[CaseStatusID],
					[CasePriorityID],
					[CaseTypeID],
					[CaseOrigin],
					[Title],
					[Description],
					[FirstName],
					[LastName],
					[CompanyName],
					[EmailID],
					[PhoneNumber],
					[CreateDte],
					[CreateUser]
				FROM
					dbo.[ZNodeCase]
				WHERE
					[Title] = @Title
					AND [FirstName] = @FirstName
					AND [LastName] = @LastName
					AND [CompanyName] = @CompanyName
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCase_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCase_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCase_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeCase table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCase_Find
(

	@SearchUsingOR bit   = null ,

	@CaseID int   = null ,

	@PortalID int   = null ,

	@AccountID int   = null ,

	@OwnerAccountID int   = null ,

	@CaseStatusID int   = null ,

	@CasePriorityID int   = null ,

	@CaseTypeID int   = null ,

	@CaseOrigin varchar (50)  = null ,

	@Title varchar (255)  = null ,

	@Description ntext   = null ,

	@FirstName varchar (100)  = null ,

	@LastName varchar (100)  = null ,

	@CompanyName varchar (100)  = null ,

	@EmailID varchar (200)  = null ,

	@PhoneNumber varchar (20)  = null ,

	@CreateDte smalldatetime   = null ,

	@CreateUser varchar (100)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CaseID]
	, [PortalID]
	, [AccountID]
	, [OwnerAccountID]
	, [CaseStatusID]
	, [CasePriorityID]
	, [CaseTypeID]
	, [CaseOrigin]
	, [Title]
	, [Description]
	, [FirstName]
	, [LastName]
	, [CompanyName]
	, [EmailID]
	, [PhoneNumber]
	, [CreateDte]
	, [CreateUser]
    FROM
	dbo.[ZNodeCase]
    WHERE 
	 ([CaseID] = @CaseID OR @CaseID is null)
	AND ([PortalID] = @PortalID OR @PortalID is null)
	AND ([AccountID] = @AccountID OR @AccountID is null)
	AND ([OwnerAccountID] = @OwnerAccountID OR @OwnerAccountID is null)
	AND ([CaseStatusID] = @CaseStatusID OR @CaseStatusID is null)
	AND ([CasePriorityID] = @CasePriorityID OR @CasePriorityID is null)
	AND ([CaseTypeID] = @CaseTypeID OR @CaseTypeID is null)
	AND ([CaseOrigin] = @CaseOrigin OR @CaseOrigin is null)
	AND ([Title] = @Title OR @Title is null)
	AND ([FirstName] = @FirstName OR @FirstName is null)
	AND ([LastName] = @LastName OR @LastName is null)
	AND ([CompanyName] = @CompanyName OR @CompanyName is null)
	AND ([EmailID] = @EmailID OR @EmailID is null)
	AND ([PhoneNumber] = @PhoneNumber OR @PhoneNumber is null)
	AND ([CreateDte] = @CreateDte OR @CreateDte is null)
	AND ([CreateUser] = @CreateUser OR @CreateUser is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CaseID]
	, [PortalID]
	, [AccountID]
	, [OwnerAccountID]
	, [CaseStatusID]
	, [CasePriorityID]
	, [CaseTypeID]
	, [CaseOrigin]
	, [Title]
	, [Description]
	, [FirstName]
	, [LastName]
	, [CompanyName]
	, [EmailID]
	, [PhoneNumber]
	, [CreateDte]
	, [CreateUser]
    FROM
	dbo.[ZNodeCase]
    WHERE 
	 ([CaseID] = @CaseID AND @CaseID is not null)
	OR ([PortalID] = @PortalID AND @PortalID is not null)
	OR ([AccountID] = @AccountID AND @AccountID is not null)
	OR ([OwnerAccountID] = @OwnerAccountID AND @OwnerAccountID is not null)
	OR ([CaseStatusID] = @CaseStatusID AND @CaseStatusID is not null)
	OR ([CasePriorityID] = @CasePriorityID AND @CasePriorityID is not null)
	OR ([CaseTypeID] = @CaseTypeID AND @CaseTypeID is not null)
	OR ([CaseOrigin] = @CaseOrigin AND @CaseOrigin is not null)
	OR ([Title] = @Title AND @Title is not null)
	OR ([FirstName] = @FirstName AND @FirstName is not null)
	OR ([LastName] = @LastName AND @LastName is not null)
	OR ([CompanyName] = @CompanyName AND @CompanyName is not null)
	OR ([EmailID] = @EmailID AND @EmailID is not null)
	OR ([PhoneNumber] = @PhoneNumber AND @PhoneNumber is not null)
	OR ([CreateDte] = @CreateDte AND @CreateDte is not null)
	OR ([CreateUser] = @CreateUser AND @CreateUser is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAttributeType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAttributeType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAttributeType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeAttributeType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAttributeType_Get_List

AS


				
				SELECT
					[AttributeTypeId],
					[PortalId],
					[Name],
					[Description],
					[DisplayOrder],
					[IsPrivate]
				FROM
					dbo.[ZNodeAttributeType]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAttributeType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAttributeType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAttributeType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeAttributeType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAttributeType_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[AttributeTypeId]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [AttributeTypeId]'
				SET @SQL = @SQL + ', [PortalId]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [DisplayOrder]'
				SET @SQL = @SQL + ', [IsPrivate]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeAttributeType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AttributeTypeId],'
				SET @SQL = @SQL + ' [PortalId],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [DisplayOrder],'
				SET @SQL = @SQL + ' [IsPrivate]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeAttributeType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAttributeType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAttributeType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAttributeType_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeAttributeType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAttributeType_Insert
(

	@AttributeTypeId int    OUTPUT,

	@PortalId int   ,

	@Name varchar (50)  ,

	@Description text   ,

	@DisplayOrder int   ,

	@IsPrivate bit   
)
AS


					
				INSERT INTO dbo.[ZNodeAttributeType]
					(
					[PortalId]
					,[Name]
					,[Description]
					,[DisplayOrder]
					,[IsPrivate]
					)
				VALUES
					(
					@PortalId
					,@Name
					,@Description
					,@DisplayOrder
					,@IsPrivate
					)
				
				-- Get the identity value
				SET @AttributeTypeId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAttributeType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAttributeType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAttributeType_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeAttributeType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAttributeType_Update
(

	@AttributeTypeId int   ,

	@PortalId int   ,

	@Name varchar (50)  ,

	@Description text   ,

	@DisplayOrder int   ,

	@IsPrivate bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeAttributeType]
				SET
					[PortalId] = @PortalId
					,[Name] = @Name
					,[Description] = @Description
					,[DisplayOrder] = @DisplayOrder
					,[IsPrivate] = @IsPrivate
				WHERE
[AttributeTypeId] = @AttributeTypeId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAttributeType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAttributeType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAttributeType_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeAttributeType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAttributeType_Delete
(

	@AttributeTypeId int   
)
AS


				DELETE FROM dbo.[ZNodeAttributeType] WITH (ROWLOCK) 
				WHERE
					[AttributeTypeId] = @AttributeTypeId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAttributeType_GetByAttributeTypeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAttributeType_GetByAttributeTypeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAttributeType_GetByAttributeTypeId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeAttributeType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAttributeType_GetByAttributeTypeId
(

	@AttributeTypeId int   
)
AS


				SELECT
					[AttributeTypeId],
					[PortalId],
					[Name],
					[Description],
					[DisplayOrder],
					[IsPrivate]
				FROM
					dbo.[ZNodeAttributeType]
				WHERE
					[AttributeTypeId] = @AttributeTypeId
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeAttributeType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeAttributeType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeAttributeType_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeAttributeType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeAttributeType_Find
(

	@SearchUsingOR bit   = null ,

	@AttributeTypeId int   = null ,

	@PortalId int   = null ,

	@Name varchar (50)  = null ,

	@Description text   = null ,

	@DisplayOrder int   = null ,

	@IsPrivate bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AttributeTypeId]
	, [PortalId]
	, [Name]
	, [Description]
	, [DisplayOrder]
	, [IsPrivate]
    FROM
	dbo.[ZNodeAttributeType]
    WHERE 
	 ([AttributeTypeId] = @AttributeTypeId OR @AttributeTypeId is null)
	AND ([PortalId] = @PortalId OR @PortalId is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([DisplayOrder] = @DisplayOrder OR @DisplayOrder is null)
	AND ([IsPrivate] = @IsPrivate OR @IsPrivate is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AttributeTypeId]
	, [PortalId]
	, [Name]
	, [Description]
	, [DisplayOrder]
	, [IsPrivate]
    FROM
	dbo.[ZNodeAttributeType]
    WHERE 
	 ([AttributeTypeId] = @AttributeTypeId AND @AttributeTypeId is not null)
	OR ([PortalId] = @PortalId AND @PortalId is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([DisplayOrder] = @DisplayOrder AND @DisplayOrder is not null)
	OR ([IsPrivate] = @IsPrivate AND @IsPrivate is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCountry_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCountry_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCountry_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeCountry table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCountry_Get_List

AS


				
				SELECT
					[Code],
					[PortalID],
					[Name],
					[DisplayOrder],
					[ActiveInd]
				FROM
					dbo.[ZNodeCountry]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCountry_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCountry_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCountry_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeCountry table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCountry_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[Code]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [Code]'
				SET @SQL = @SQL + ', [PortalID]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [DisplayOrder]'
				SET @SQL = @SQL + ', [ActiveInd]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeCountry]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [Code],'
				SET @SQL = @SQL + ' [PortalID],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [DisplayOrder],'
				SET @SQL = @SQL + ' [ActiveInd]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeCountry]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCountry_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCountry_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCountry_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeCountry table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCountry_Insert
(

	@Code varchar (2)  ,

	@PortalID int   ,

	@Name varchar (100)  ,

	@DisplayOrder int   ,

	@ActiveInd bit   
)
AS


					
				INSERT INTO dbo.[ZNodeCountry]
					(
					[Code]
					,[PortalID]
					,[Name]
					,[DisplayOrder]
					,[ActiveInd]
					)
				VALUES
					(
					@Code
					,@PortalID
					,@Name
					,@DisplayOrder
					,@ActiveInd
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCountry_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCountry_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCountry_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeCountry table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCountry_Update
(

	@Code varchar (2)  ,

	@OriginalCode varchar (2)  ,

	@PortalID int   ,

	@Name varchar (100)  ,

	@DisplayOrder int   ,

	@ActiveInd bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeCountry]
				SET
					[Code] = @Code
					,[PortalID] = @PortalID
					,[Name] = @Name
					,[DisplayOrder] = @DisplayOrder
					,[ActiveInd] = @ActiveInd
				WHERE
[Code] = @OriginalCode 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCountry_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCountry_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCountry_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeCountry table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCountry_Delete
(

	@Code varchar (2)  
)
AS


				DELETE FROM dbo.[ZNodeCountry] WITH (ROWLOCK) 
				WHERE
					[Code] = @Code
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCountry_GetByCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCountry_GetByCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCountry_GetByCode
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCountry table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCountry_GetByCode
(

	@Code varchar (2)  
)
AS


				SELECT
					[Code],
					[PortalID],
					[Name],
					[DisplayOrder],
					[ActiveInd]
				FROM
					dbo.[ZNodeCountry]
				WHERE
					[Code] = @Code
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCountry_GetByPortalIDActiveInd procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCountry_GetByPortalIDActiveInd') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCountry_GetByPortalIDActiveInd
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCountry table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCountry_GetByPortalIDActiveInd
(

	@PortalID int   ,

	@ActiveInd bit   
)
AS


				SELECT
					[Code],
					[PortalID],
					[Name],
					[DisplayOrder],
					[ActiveInd]
				FROM
					dbo.[ZNodeCountry]
				WHERE
					[PortalID] = @PortalID
					AND [ActiveInd] = @ActiveInd
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCountry_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCountry_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCountry_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeCountry table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCountry_Find
(

	@SearchUsingOR bit   = null ,

	@Code varchar (2)  = null ,

	@PortalID int   = null ,

	@Name varchar (100)  = null ,

	@DisplayOrder int   = null ,

	@ActiveInd bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Code]
	, [PortalID]
	, [Name]
	, [DisplayOrder]
	, [ActiveInd]
    FROM
	dbo.[ZNodeCountry]
    WHERE 
	 ([Code] = @Code OR @Code is null)
	AND ([PortalID] = @PortalID OR @PortalID is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([DisplayOrder] = @DisplayOrder OR @DisplayOrder is null)
	AND ([ActiveInd] = @ActiveInd OR @ActiveInd is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Code]
	, [PortalID]
	, [Name]
	, [DisplayOrder]
	, [ActiveInd]
    FROM
	dbo.[ZNodeCountry]
    WHERE 
	 ([Code] = @Code AND @Code is not null)
	OR ([PortalID] = @PortalID AND @PortalID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([DisplayOrder] = @DisplayOrder AND @DisplayOrder is not null)
	OR ([ActiveInd] = @ActiveInd AND @ActiveInd is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderProcessingType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderProcessingType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderProcessingType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeOrderProcessingType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderProcessingType_Get_List

AS


				
				SELECT
					[OrderProcessingTypeID],
					[Description],
					[ClassID]
				FROM
					dbo.[ZNodeOrderProcessingType]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderProcessingType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderProcessingType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderProcessingType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeOrderProcessingType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderProcessingType_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OrderProcessingTypeID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OrderProcessingTypeID]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [ClassID]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeOrderProcessingType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OrderProcessingTypeID],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [ClassID]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeOrderProcessingType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderProcessingType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderProcessingType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderProcessingType_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeOrderProcessingType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderProcessingType_Insert
(

	@OrderProcessingTypeID int    OUTPUT,

	@Description varchar (50)  ,

	@ClassID varchar (30)  
)
AS


					
				INSERT INTO dbo.[ZNodeOrderProcessingType]
					(
					[Description]
					,[ClassID]
					)
				VALUES
					(
					@Description
					,@ClassID
					)
				
				-- Get the identity value
				SET @OrderProcessingTypeID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderProcessingType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderProcessingType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderProcessingType_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeOrderProcessingType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderProcessingType_Update
(

	@OrderProcessingTypeID int   ,

	@Description varchar (50)  ,

	@ClassID varchar (30)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeOrderProcessingType]
				SET
					[Description] = @Description
					,[ClassID] = @ClassID
				WHERE
[OrderProcessingTypeID] = @OrderProcessingTypeID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderProcessingType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderProcessingType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderProcessingType_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeOrderProcessingType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderProcessingType_Delete
(

	@OrderProcessingTypeID int   
)
AS


				DELETE FROM dbo.[ZNodeOrderProcessingType] WITH (ROWLOCK) 
				WHERE
					[OrderProcessingTypeID] = @OrderProcessingTypeID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderProcessingType_GetByOrderProcessingTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderProcessingType_GetByOrderProcessingTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderProcessingType_GetByOrderProcessingTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeOrderProcessingType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderProcessingType_GetByOrderProcessingTypeID
(

	@OrderProcessingTypeID int   
)
AS


				SELECT
					[OrderProcessingTypeID],
					[Description],
					[ClassID]
				FROM
					dbo.[ZNodeOrderProcessingType]
				WHERE
					[OrderProcessingTypeID] = @OrderProcessingTypeID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderProcessingType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderProcessingType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderProcessingType_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeOrderProcessingType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderProcessingType_Find
(

	@SearchUsingOR bit   = null ,

	@OrderProcessingTypeID int   = null ,

	@Description varchar (50)  = null ,

	@ClassID varchar (30)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OrderProcessingTypeID]
	, [Description]
	, [ClassID]
    FROM
	dbo.[ZNodeOrderProcessingType]
    WHERE 
	 ([OrderProcessingTypeID] = @OrderProcessingTypeID OR @OrderProcessingTypeID is null)
	AND ([Description] = @Description OR @Description is null)
	AND ([ClassID] = @ClassID OR @ClassID is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OrderProcessingTypeID]
	, [Description]
	, [ClassID]
    FROM
	dbo.[ZNodeOrderProcessingType]
    WHERE 
	 ([OrderProcessingTypeID] = @OrderProcessingTypeID AND @OrderProcessingTypeID is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([ClassID] = @ClassID AND @ClassID is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeNote_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeNote_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeNote_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeNote table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeNote_Get_List

AS


				
				SELECT
					[NoteID],
					[CaseID],
					[AccountID],
					[NoteTitle],
					[NoteBody],
					[CreateDte],
					[CreateUser]
				FROM
					dbo.[ZNodeNote]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeNote_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeNote_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeNote_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeNote table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeNote_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[NoteID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [NoteID]'
				SET @SQL = @SQL + ', [CaseID]'
				SET @SQL = @SQL + ', [AccountID]'
				SET @SQL = @SQL + ', [NoteTitle]'
				SET @SQL = @SQL + ', [NoteBody]'
				SET @SQL = @SQL + ', [CreateDte]'
				SET @SQL = @SQL + ', [CreateUser]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeNote]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [NoteID],'
				SET @SQL = @SQL + ' [CaseID],'
				SET @SQL = @SQL + ' [AccountID],'
				SET @SQL = @SQL + ' [NoteTitle],'
				SET @SQL = @SQL + ' [NoteBody],'
				SET @SQL = @SQL + ' [CreateDte],'
				SET @SQL = @SQL + ' [CreateUser]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeNote]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeNote_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeNote_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeNote_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeNote table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeNote_Insert
(

	@NoteID int    OUTPUT,

	@CaseID int   ,

	@AccountID int   ,

	@NoteTitle varchar (255)  ,

	@NoteBody ntext   ,

	@CreateDte smalldatetime   ,

	@CreateUser varchar (100)  
)
AS


					
				INSERT INTO dbo.[ZNodeNote]
					(
					[CaseID]
					,[AccountID]
					,[NoteTitle]
					,[NoteBody]
					,[CreateDte]
					,[CreateUser]
					)
				VALUES
					(
					@CaseID
					,@AccountID
					,@NoteTitle
					,@NoteBody
					,@CreateDte
					,@CreateUser
					)
				
				-- Get the identity value
				SET @NoteID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeNote_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeNote_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeNote_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeNote table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeNote_Update
(

	@NoteID int   ,

	@CaseID int   ,

	@AccountID int   ,

	@NoteTitle varchar (255)  ,

	@NoteBody ntext   ,

	@CreateDte smalldatetime   ,

	@CreateUser varchar (100)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeNote]
				SET
					[CaseID] = @CaseID
					,[AccountID] = @AccountID
					,[NoteTitle] = @NoteTitle
					,[NoteBody] = @NoteBody
					,[CreateDte] = @CreateDte
					,[CreateUser] = @CreateUser
				WHERE
[NoteID] = @NoteID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeNote_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeNote_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeNote_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeNote table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeNote_Delete
(

	@NoteID int   
)
AS


				DELETE FROM dbo.[ZNodeNote] WITH (ROWLOCK) 
				WHERE
					[NoteID] = @NoteID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeNote_GetByAccountID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeNote_GetByAccountID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeNote_GetByAccountID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeNote table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeNote_GetByAccountID
(

	@AccountID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[NoteID],
					[CaseID],
					[AccountID],
					[NoteTitle],
					[NoteBody],
					[CreateDte],
					[CreateUser]
				FROM
					dbo.[ZNodeNote]
				WHERE
					[AccountID] = @AccountID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeNote_GetByNoteID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeNote_GetByNoteID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeNote_GetByNoteID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeNote table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeNote_GetByNoteID
(

	@NoteID int   
)
AS


				SELECT
					[NoteID],
					[CaseID],
					[AccountID],
					[NoteTitle],
					[NoteBody],
					[CreateDte],
					[CreateUser]
				FROM
					dbo.[ZNodeNote]
				WHERE
					[NoteID] = @NoteID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeNote_GetByCaseID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeNote_GetByCaseID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeNote_GetByCaseID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeNote table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeNote_GetByCaseID
(

	@CaseID int   
)
AS


				SELECT
					[NoteID],
					[CaseID],
					[AccountID],
					[NoteTitle],
					[NoteBody],
					[CreateDte],
					[CreateUser]
				FROM
					dbo.[ZNodeNote]
				WHERE
					[CaseID] = @CaseID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeNote_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeNote_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeNote_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeNote table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeNote_Find
(

	@SearchUsingOR bit   = null ,

	@NoteID int   = null ,

	@CaseID int   = null ,

	@AccountID int   = null ,

	@NoteTitle varchar (255)  = null ,

	@NoteBody ntext   = null ,

	@CreateDte smalldatetime   = null ,

	@CreateUser varchar (100)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [NoteID]
	, [CaseID]
	, [AccountID]
	, [NoteTitle]
	, [NoteBody]
	, [CreateDte]
	, [CreateUser]
    FROM
	dbo.[ZNodeNote]
    WHERE 
	 ([NoteID] = @NoteID OR @NoteID is null)
	AND ([CaseID] = @CaseID OR @CaseID is null)
	AND ([AccountID] = @AccountID OR @AccountID is null)
	AND ([NoteTitle] = @NoteTitle OR @NoteTitle is null)
	AND ([CreateDte] = @CreateDte OR @CreateDte is null)
	AND ([CreateUser] = @CreateUser OR @CreateUser is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [NoteID]
	, [CaseID]
	, [AccountID]
	, [NoteTitle]
	, [NoteBody]
	, [CreateDte]
	, [CreateUser]
    FROM
	dbo.[ZNodeNote]
    WHERE 
	 ([NoteID] = @NoteID AND @NoteID is not null)
	OR ([CaseID] = @CaseID AND @CaseID is not null)
	OR ([AccountID] = @AccountID AND @AccountID is not null)
	OR ([NoteTitle] = @NoteTitle AND @NoteTitle is not null)
	OR ([CreateDte] = @CreateDte AND @CreateDte is not null)
	OR ([CreateUser] = @CreateUser AND @CreateUser is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeDiscountType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeDiscountType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeDiscountType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeDiscountType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeDiscountType_Get_List

AS


				
				SELECT
					[DiscountTypeID],
					[DiscountTypeName]
				FROM
					dbo.[ZNodeDiscountType]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeDiscountType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeDiscountType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeDiscountType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeDiscountType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeDiscountType_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[DiscountTypeID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [DiscountTypeID]'
				SET @SQL = @SQL + ', [DiscountTypeName]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeDiscountType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [DiscountTypeID],'
				SET @SQL = @SQL + ' [DiscountTypeName]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeDiscountType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeDiscountType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeDiscountType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeDiscountType_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeDiscountType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeDiscountType_Insert
(

	@DiscountTypeID int   ,

	@DiscountTypeName varchar (MAX)  
)
AS


					
				INSERT INTO dbo.[ZNodeDiscountType]
					(
					[DiscountTypeID]
					,[DiscountTypeName]
					)
				VALUES
					(
					@DiscountTypeID
					,@DiscountTypeName
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeDiscountType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeDiscountType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeDiscountType_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeDiscountType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeDiscountType_Update
(

	@DiscountTypeID int   ,

	@OriginalDiscountTypeID int   ,

	@DiscountTypeName varchar (MAX)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeDiscountType]
				SET
					[DiscountTypeID] = @DiscountTypeID
					,[DiscountTypeName] = @DiscountTypeName
				WHERE
[DiscountTypeID] = @OriginalDiscountTypeID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeDiscountType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeDiscountType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeDiscountType_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeDiscountType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeDiscountType_Delete
(

	@DiscountTypeID int   
)
AS


				DELETE FROM dbo.[ZNodeDiscountType] WITH (ROWLOCK) 
				WHERE
					[DiscountTypeID] = @DiscountTypeID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeDiscountType_GetByDiscountTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeDiscountType_GetByDiscountTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeDiscountType_GetByDiscountTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeDiscountType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeDiscountType_GetByDiscountTypeID
(

	@DiscountTypeID int   
)
AS


				SELECT
					[DiscountTypeID],
					[DiscountTypeName]
				FROM
					dbo.[ZNodeDiscountType]
				WHERE
					[DiscountTypeID] = @DiscountTypeID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeDiscountType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeDiscountType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeDiscountType_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeDiscountType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeDiscountType_Find
(

	@SearchUsingOR bit   = null ,

	@DiscountTypeID int   = null ,

	@DiscountTypeName varchar (MAX)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [DiscountTypeID]
	, [DiscountTypeName]
    FROM
	dbo.[ZNodeDiscountType]
    WHERE 
	 ([DiscountTypeID] = @DiscountTypeID OR @DiscountTypeID is null)
	AND ([DiscountTypeName] = @DiscountTypeName OR @DiscountTypeName is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [DiscountTypeID]
	, [DiscountTypeName]
    FROM
	dbo.[ZNodeDiscountType]
    WHERE 
	 ([DiscountTypeID] = @DiscountTypeID AND @DiscountTypeID is not null)
	OR ([DiscountTypeName] = @DiscountTypeName AND @DiscountTypeName is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderState_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderState_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderState_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeOrderState table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderState_Get_List

AS


				
				SELECT
					[OrderStateID],
					[OrderStateName]
				FROM
					dbo.[ZNodeOrderState]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderState_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderState_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderState_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeOrderState table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderState_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OrderStateID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OrderStateID]'
				SET @SQL = @SQL + ', [OrderStateName]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeOrderState]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OrderStateID],'
				SET @SQL = @SQL + ' [OrderStateName]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeOrderState]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderState_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderState_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderState_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeOrderState table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderState_Insert
(

	@OrderStateID int   ,

	@OrderStateName varchar (50)  
)
AS


					
				INSERT INTO dbo.[ZNodeOrderState]
					(
					[OrderStateID]
					,[OrderStateName]
					)
				VALUES
					(
					@OrderStateID
					,@OrderStateName
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderState_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderState_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderState_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeOrderState table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderState_Update
(

	@OrderStateID int   ,

	@OriginalOrderStateID int   ,

	@OrderStateName varchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeOrderState]
				SET
					[OrderStateID] = @OrderStateID
					,[OrderStateName] = @OrderStateName
				WHERE
[OrderStateID] = @OriginalOrderStateID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderState_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderState_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderState_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeOrderState table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderState_Delete
(

	@OrderStateID int   
)
AS


				DELETE FROM dbo.[ZNodeOrderState] WITH (ROWLOCK) 
				WHERE
					[OrderStateID] = @OrderStateID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderState_GetByOrderStateID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderState_GetByOrderStateID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderState_GetByOrderStateID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeOrderState table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderState_GetByOrderStateID
(

	@OrderStateID int   
)
AS


				SELECT
					[OrderStateID],
					[OrderStateName]
				FROM
					dbo.[ZNodeOrderState]
				WHERE
					[OrderStateID] = @OrderStateID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderState_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderState_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderState_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeOrderState table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderState_Find
(

	@SearchUsingOR bit   = null ,

	@OrderStateID int   = null ,

	@OrderStateName varchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OrderStateID]
	, [OrderStateName]
    FROM
	dbo.[ZNodeOrderState]
    WHERE 
	 ([OrderStateID] = @OrderStateID OR @OrderStateID is null)
	AND ([OrderStateName] = @OrderStateName OR @OrderStateName is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OrderStateID]
	, [OrderStateName]
    FROM
	dbo.[ZNodeOrderState]
    WHERE 
	 ([OrderStateID] = @OrderStateID AND @OrderStateID is not null)
	OR ([OrderStateName] = @OrderStateName AND @OrderStateName is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeDiscountTarget_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeDiscountTarget_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeDiscountTarget_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeDiscountTarget table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeDiscountTarget_Get_List

AS


				
				SELECT
					[DiscountTargetID],
					[DiscountTargetName]
				FROM
					dbo.[ZNodeDiscountTarget]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeDiscountTarget_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeDiscountTarget_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeDiscountTarget_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeDiscountTarget table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeDiscountTarget_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[DiscountTargetID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [DiscountTargetID]'
				SET @SQL = @SQL + ', [DiscountTargetName]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeDiscountTarget]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [DiscountTargetID],'
				SET @SQL = @SQL + ' [DiscountTargetName]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeDiscountTarget]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeDiscountTarget_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeDiscountTarget_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeDiscountTarget_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeDiscountTarget table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeDiscountTarget_Insert
(

	@DiscountTargetID int   ,

	@DiscountTargetName varchar (MAX)  
)
AS


					
				INSERT INTO dbo.[ZNodeDiscountTarget]
					(
					[DiscountTargetID]
					,[DiscountTargetName]
					)
				VALUES
					(
					@DiscountTargetID
					,@DiscountTargetName
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeDiscountTarget_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeDiscountTarget_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeDiscountTarget_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeDiscountTarget table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeDiscountTarget_Update
(

	@DiscountTargetID int   ,

	@OriginalDiscountTargetID int   ,

	@DiscountTargetName varchar (MAX)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeDiscountTarget]
				SET
					[DiscountTargetID] = @DiscountTargetID
					,[DiscountTargetName] = @DiscountTargetName
				WHERE
[DiscountTargetID] = @OriginalDiscountTargetID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeDiscountTarget_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeDiscountTarget_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeDiscountTarget_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeDiscountTarget table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeDiscountTarget_Delete
(

	@DiscountTargetID int   
)
AS


				DELETE FROM dbo.[ZNodeDiscountTarget] WITH (ROWLOCK) 
				WHERE
					[DiscountTargetID] = @DiscountTargetID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeDiscountTarget_GetByDiscountTargetID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeDiscountTarget_GetByDiscountTargetID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeDiscountTarget_GetByDiscountTargetID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeDiscountTarget table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeDiscountTarget_GetByDiscountTargetID
(

	@DiscountTargetID int   
)
AS


				SELECT
					[DiscountTargetID],
					[DiscountTargetName]
				FROM
					dbo.[ZNodeDiscountTarget]
				WHERE
					[DiscountTargetID] = @DiscountTargetID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeDiscountTarget_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeDiscountTarget_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeDiscountTarget_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeDiscountTarget table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeDiscountTarget_Find
(

	@SearchUsingOR bit   = null ,

	@DiscountTargetID int   = null ,

	@DiscountTargetName varchar (MAX)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [DiscountTargetID]
	, [DiscountTargetName]
    FROM
	dbo.[ZNodeDiscountTarget]
    WHERE 
	 ([DiscountTargetID] = @DiscountTargetID OR @DiscountTargetID is null)
	AND ([DiscountTargetName] = @DiscountTargetName OR @DiscountTargetName is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [DiscountTargetID]
	, [DiscountTargetName]
    FROM
	dbo.[ZNodeDiscountTarget]
    WHERE 
	 ([DiscountTargetID] = @DiscountTargetID AND @DiscountTargetID is not null)
	OR ([DiscountTargetName] = @DiscountTargetName AND @DiscountTargetName is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeManufacturer_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeManufacturer_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeManufacturer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_Get_List

AS


				
				SELECT
					[ManufacturerID],
					[PortalID],
					[Name],
					[Description],
					[ActiveInd],
					[Custom1],
					[Custom2],
					[Custom3]
				FROM
					dbo.[ZNodeManufacturer]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeManufacturer_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeManufacturer_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeManufacturer table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ManufacturerID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ManufacturerID]'
				SET @SQL = @SQL + ', [PortalID]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [ActiveInd]'
				SET @SQL = @SQL + ', [Custom1]'
				SET @SQL = @SQL + ', [Custom2]'
				SET @SQL = @SQL + ', [Custom3]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeManufacturer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ManufacturerID],'
				SET @SQL = @SQL + ' [PortalID],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [ActiveInd],'
				SET @SQL = @SQL + ' [Custom1],'
				SET @SQL = @SQL + ' [Custom2],'
				SET @SQL = @SQL + ' [Custom3]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeManufacturer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeManufacturer_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeManufacturer_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeManufacturer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_Insert
(

	@ManufacturerID int    OUTPUT,

	@PortalID int   ,

	@Name varchar (100)  ,

	@Description text   ,

	@ActiveInd bit   ,

	@Custom1 varchar (MAX)  ,

	@Custom2 varchar (MAX)  ,

	@Custom3 varchar (MAX)  
)
AS


					
				INSERT INTO dbo.[ZNodeManufacturer]
					(
					[PortalID]
					,[Name]
					,[Description]
					,[ActiveInd]
					,[Custom1]
					,[Custom2]
					,[Custom3]
					)
				VALUES
					(
					@PortalID
					,@Name
					,@Description
					,@ActiveInd
					,@Custom1
					,@Custom2
					,@Custom3
					)
				
				-- Get the identity value
				SET @ManufacturerID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeManufacturer_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeManufacturer_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeManufacturer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_Update
(

	@ManufacturerID int   ,

	@PortalID int   ,

	@Name varchar (100)  ,

	@Description text   ,

	@ActiveInd bit   ,

	@Custom1 varchar (MAX)  ,

	@Custom2 varchar (MAX)  ,

	@Custom3 varchar (MAX)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeManufacturer]
				SET
					[PortalID] = @PortalID
					,[Name] = @Name
					,[Description] = @Description
					,[ActiveInd] = @ActiveInd
					,[Custom1] = @Custom1
					,[Custom2] = @Custom2
					,[Custom3] = @Custom3
				WHERE
[ManufacturerID] = @ManufacturerID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeManufacturer_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeManufacturer_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeManufacturer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_Delete
(

	@ManufacturerID int   
)
AS


				DELETE FROM dbo.[ZNodeManufacturer] WITH (ROWLOCK) 
				WHERE
					[ManufacturerID] = @ManufacturerID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeManufacturer_GetByPortalID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeManufacturer_GetByPortalID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_GetByPortalID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeManufacturer table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_GetByPortalID
(

	@PortalID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ManufacturerID],
					[PortalID],
					[Name],
					[Description],
					[ActiveInd],
					[Custom1],
					[Custom2],
					[Custom3]
				FROM
					dbo.[ZNodeManufacturer]
				WHERE
					[PortalID] = @PortalID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeManufacturer_GetByManufacturerID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeManufacturer_GetByManufacturerID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_GetByManufacturerID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeManufacturer table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_GetByManufacturerID
(

	@ManufacturerID int   
)
AS


				SELECT
					[ManufacturerID],
					[PortalID],
					[Name],
					[Description],
					[ActiveInd],
					[Custom1],
					[Custom2],
					[Custom3]
				FROM
					dbo.[ZNodeManufacturer]
				WHERE
					[ManufacturerID] = @ManufacturerID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeManufacturer_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeManufacturer_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeManufacturer table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeManufacturer_Find
(

	@SearchUsingOR bit   = null ,

	@ManufacturerID int   = null ,

	@PortalID int   = null ,

	@Name varchar (100)  = null ,

	@Description text   = null ,

	@ActiveInd bit   = null ,

	@Custom1 varchar (MAX)  = null ,

	@Custom2 varchar (MAX)  = null ,

	@Custom3 varchar (MAX)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ManufacturerID]
	, [PortalID]
	, [Name]
	, [Description]
	, [ActiveInd]
	, [Custom1]
	, [Custom2]
	, [Custom3]
    FROM
	dbo.[ZNodeManufacturer]
    WHERE 
	 ([ManufacturerID] = @ManufacturerID OR @ManufacturerID is null)
	AND ([PortalID] = @PortalID OR @PortalID is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([ActiveInd] = @ActiveInd OR @ActiveInd is null)
	AND ([Custom1] = @Custom1 OR @Custom1 is null)
	AND ([Custom2] = @Custom2 OR @Custom2 is null)
	AND ([Custom3] = @Custom3 OR @Custom3 is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ManufacturerID]
	, [PortalID]
	, [Name]
	, [Description]
	, [ActiveInd]
	, [Custom1]
	, [Custom2]
	, [Custom3]
    FROM
	dbo.[ZNodeManufacturer]
    WHERE 
	 ([ManufacturerID] = @ManufacturerID AND @ManufacturerID is not null)
	OR ([PortalID] = @PortalID AND @PortalID is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([ActiveInd] = @ActiveInd AND @ActiveInd is not null)
	OR ([Custom1] = @Custom1 AND @Custom1 is not null)
	OR ([Custom2] = @Custom2 AND @Custom2 is not null)
	OR ([Custom3] = @Custom3 AND @Custom3 is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeGateway_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeGateway_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeGateway_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeGateway table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeGateway_Get_List

AS


				
				SELECT
					[GatewayTypeID],
					[GatewayName],
					[WebsiteURL]
				FROM
					dbo.[ZNodeGateway]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeGateway_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeGateway_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeGateway_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeGateway table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeGateway_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[GatewayTypeID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [GatewayTypeID]'
				SET @SQL = @SQL + ', [GatewayName]'
				SET @SQL = @SQL + ', [WebsiteURL]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeGateway]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [GatewayTypeID],'
				SET @SQL = @SQL + ' [GatewayName],'
				SET @SQL = @SQL + ' [WebsiteURL]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeGateway]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeGateway_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeGateway_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeGateway_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeGateway table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeGateway_Insert
(

	@GatewayTypeID int   ,

	@GatewayName varchar (MAX)  ,

	@WebsiteURL varchar (MAX)  
)
AS


					
				INSERT INTO dbo.[ZNodeGateway]
					(
					[GatewayTypeID]
					,[GatewayName]
					,[WebsiteURL]
					)
				VALUES
					(
					@GatewayTypeID
					,@GatewayName
					,@WebsiteURL
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeGateway_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeGateway_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeGateway_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeGateway table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeGateway_Update
(

	@GatewayTypeID int   ,

	@OriginalGatewayTypeID int   ,

	@GatewayName varchar (MAX)  ,

	@WebsiteURL varchar (MAX)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeGateway]
				SET
					[GatewayTypeID] = @GatewayTypeID
					,[GatewayName] = @GatewayName
					,[WebsiteURL] = @WebsiteURL
				WHERE
[GatewayTypeID] = @OriginalGatewayTypeID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeGateway_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeGateway_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeGateway_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeGateway table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeGateway_Delete
(

	@GatewayTypeID int   
)
AS


				DELETE FROM dbo.[ZNodeGateway] WITH (ROWLOCK) 
				WHERE
					[GatewayTypeID] = @GatewayTypeID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeGateway_GetByGatewayTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeGateway_GetByGatewayTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeGateway_GetByGatewayTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeGateway table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeGateway_GetByGatewayTypeID
(

	@GatewayTypeID int   
)
AS


				SELECT
					[GatewayTypeID],
					[GatewayName],
					[WebsiteURL]
				FROM
					dbo.[ZNodeGateway]
				WHERE
					[GatewayTypeID] = @GatewayTypeID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeGateway_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeGateway_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeGateway_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeGateway table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeGateway_Find
(

	@SearchUsingOR bit   = null ,

	@GatewayTypeID int   = null ,

	@GatewayName varchar (MAX)  = null ,

	@WebsiteURL varchar (MAX)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [GatewayTypeID]
	, [GatewayName]
	, [WebsiteURL]
    FROM
	dbo.[ZNodeGateway]
    WHERE 
	 ([GatewayTypeID] = @GatewayTypeID OR @GatewayTypeID is null)
	AND ([GatewayName] = @GatewayName OR @GatewayName is null)
	AND ([WebsiteURL] = @WebsiteURL OR @WebsiteURL is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [GatewayTypeID]
	, [GatewayName]
	, [WebsiteURL]
    FROM
	dbo.[ZNodeGateway]
    WHERE 
	 ([GatewayTypeID] = @GatewayTypeID AND @GatewayTypeID is not null)
	OR ([GatewayName] = @GatewayName AND @GatewayName is not null)
	OR ([WebsiteURL] = @WebsiteURL AND @WebsiteURL is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCoupon_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCoupon_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeCoupon table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_Get_List

AS


				
				SELECT
					[CouponID],
					[CouponCode],
					[Discount],
					[DiscountTypeID],
					[DiscountTargetID],
					[StartDate],
					[ExpDate],
					[QuantityAvailable],
					[ProductList],
					[OrderMinimum]
				FROM
					dbo.[ZNodeCoupon]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCoupon_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCoupon_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeCoupon table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[CouponID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [CouponID]'
				SET @SQL = @SQL + ', [CouponCode]'
				SET @SQL = @SQL + ', [Discount]'
				SET @SQL = @SQL + ', [DiscountTypeID]'
				SET @SQL = @SQL + ', [DiscountTargetID]'
				SET @SQL = @SQL + ', [StartDate]'
				SET @SQL = @SQL + ', [ExpDate]'
				SET @SQL = @SQL + ', [QuantityAvailable]'
				SET @SQL = @SQL + ', [ProductList]'
				SET @SQL = @SQL + ', [OrderMinimum]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeCoupon]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CouponID],'
				SET @SQL = @SQL + ' [CouponCode],'
				SET @SQL = @SQL + ' [Discount],'
				SET @SQL = @SQL + ' [DiscountTypeID],'
				SET @SQL = @SQL + ' [DiscountTargetID],'
				SET @SQL = @SQL + ' [StartDate],'
				SET @SQL = @SQL + ' [ExpDate],'
				SET @SQL = @SQL + ' [QuantityAvailable],'
				SET @SQL = @SQL + ' [ProductList],'
				SET @SQL = @SQL + ' [OrderMinimum]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeCoupon]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCoupon_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCoupon_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeCoupon table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_Insert
(

	@CouponID int    OUTPUT,

	@CouponCode varchar (100)  ,

	@Discount decimal (18, 2)  ,

	@DiscountTypeID int   ,

	@DiscountTargetID int   ,

	@StartDate smalldatetime   ,

	@ExpDate smalldatetime   ,

	@QuantityAvailable int   ,

	@ProductList varchar (MAX)  ,

	@OrderMinimum money   
)
AS


					
				INSERT INTO dbo.[ZNodeCoupon]
					(
					[CouponCode]
					,[Discount]
					,[DiscountTypeID]
					,[DiscountTargetID]
					,[StartDate]
					,[ExpDate]
					,[QuantityAvailable]
					,[ProductList]
					,[OrderMinimum]
					)
				VALUES
					(
					@CouponCode
					,@Discount
					,@DiscountTypeID
					,@DiscountTargetID
					,@StartDate
					,@ExpDate
					,@QuantityAvailable
					,@ProductList
					,@OrderMinimum
					)
				
				-- Get the identity value
				SET @CouponID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCoupon_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCoupon_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeCoupon table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_Update
(

	@CouponID int   ,

	@CouponCode varchar (100)  ,

	@Discount decimal (18, 2)  ,

	@DiscountTypeID int   ,

	@DiscountTargetID int   ,

	@StartDate smalldatetime   ,

	@ExpDate smalldatetime   ,

	@QuantityAvailable int   ,

	@ProductList varchar (MAX)  ,

	@OrderMinimum money   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeCoupon]
				SET
					[CouponCode] = @CouponCode
					,[Discount] = @Discount
					,[DiscountTypeID] = @DiscountTypeID
					,[DiscountTargetID] = @DiscountTargetID
					,[StartDate] = @StartDate
					,[ExpDate] = @ExpDate
					,[QuantityAvailable] = @QuantityAvailable
					,[ProductList] = @ProductList
					,[OrderMinimum] = @OrderMinimum
				WHERE
[CouponID] = @CouponID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCoupon_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCoupon_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeCoupon table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_Delete
(

	@CouponID int   
)
AS


				DELETE FROM dbo.[ZNodeCoupon] WITH (ROWLOCK) 
				WHERE
					[CouponID] = @CouponID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCoupon_GetByDiscountTargetID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCoupon_GetByDiscountTargetID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_GetByDiscountTargetID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCoupon table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_GetByDiscountTargetID
(

	@DiscountTargetID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[CouponID],
					[CouponCode],
					[Discount],
					[DiscountTypeID],
					[DiscountTargetID],
					[StartDate],
					[ExpDate],
					[QuantityAvailable],
					[ProductList],
					[OrderMinimum]
				FROM
					dbo.[ZNodeCoupon]
				WHERE
					[DiscountTargetID] = @DiscountTargetID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCoupon_GetByDiscountTypeID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCoupon_GetByDiscountTypeID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_GetByDiscountTypeID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCoupon table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_GetByDiscountTypeID
(

	@DiscountTypeID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[CouponID],
					[CouponCode],
					[Discount],
					[DiscountTypeID],
					[DiscountTargetID],
					[StartDate],
					[ExpDate],
					[QuantityAvailable],
					[ProductList],
					[OrderMinimum]
				FROM
					dbo.[ZNodeCoupon]
				WHERE
					[DiscountTypeID] = @DiscountTypeID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCoupon_GetByCouponID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCoupon_GetByCouponID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_GetByCouponID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCoupon table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_GetByCouponID
(

	@CouponID int   
)
AS


				SELECT
					[CouponID],
					[CouponCode],
					[Discount],
					[DiscountTypeID],
					[DiscountTargetID],
					[StartDate],
					[ExpDate],
					[QuantityAvailable],
					[ProductList],
					[OrderMinimum]
				FROM
					dbo.[ZNodeCoupon]
				WHERE
					[CouponID] = @CouponID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCoupon_GetByCouponCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCoupon_GetByCouponCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_GetByCouponCode
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeCoupon table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_GetByCouponCode
(

	@CouponCode varchar (100)  
)
AS


				SELECT
					[CouponID],
					[CouponCode],
					[Discount],
					[DiscountTypeID],
					[DiscountTargetID],
					[StartDate],
					[ExpDate],
					[QuantityAvailable],
					[ProductList],
					[OrderMinimum]
				FROM
					dbo.[ZNodeCoupon]
				WHERE
					[CouponCode] = @CouponCode
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeCoupon_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeCoupon_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeCoupon table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeCoupon_Find
(

	@SearchUsingOR bit   = null ,

	@CouponID int   = null ,

	@CouponCode varchar (100)  = null ,

	@Discount decimal (18, 2)  = null ,

	@DiscountTypeID int   = null ,

	@DiscountTargetID int   = null ,

	@StartDate smalldatetime   = null ,

	@ExpDate smalldatetime   = null ,

	@QuantityAvailable int   = null ,

	@ProductList varchar (MAX)  = null ,

	@OrderMinimum money   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CouponID]
	, [CouponCode]
	, [Discount]
	, [DiscountTypeID]
	, [DiscountTargetID]
	, [StartDate]
	, [ExpDate]
	, [QuantityAvailable]
	, [ProductList]
	, [OrderMinimum]
    FROM
	dbo.[ZNodeCoupon]
    WHERE 
	 ([CouponID] = @CouponID OR @CouponID is null)
	AND ([CouponCode] = @CouponCode OR @CouponCode is null)
	AND ([Discount] = @Discount OR @Discount is null)
	AND ([DiscountTypeID] = @DiscountTypeID OR @DiscountTypeID is null)
	AND ([DiscountTargetID] = @DiscountTargetID OR @DiscountTargetID is null)
	AND ([StartDate] = @StartDate OR @StartDate is null)
	AND ([ExpDate] = @ExpDate OR @ExpDate is null)
	AND ([QuantityAvailable] = @QuantityAvailable OR @QuantityAvailable is null)
	AND ([ProductList] = @ProductList OR @ProductList is null)
	AND ([OrderMinimum] = @OrderMinimum OR @OrderMinimum is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CouponID]
	, [CouponCode]
	, [Discount]
	, [DiscountTypeID]
	, [DiscountTargetID]
	, [StartDate]
	, [ExpDate]
	, [QuantityAvailable]
	, [ProductList]
	, [OrderMinimum]
    FROM
	dbo.[ZNodeCoupon]
    WHERE 
	 ([CouponID] = @CouponID AND @CouponID is not null)
	OR ([CouponCode] = @CouponCode AND @CouponCode is not null)
	OR ([Discount] = @Discount AND @Discount is not null)
	OR ([DiscountTypeID] = @DiscountTypeID AND @DiscountTypeID is not null)
	OR ([DiscountTargetID] = @DiscountTargetID AND @DiscountTargetID is not null)
	OR ([StartDate] = @StartDate AND @StartDate is not null)
	OR ([ExpDate] = @ExpDate AND @ExpDate is not null)
	OR ([QuantityAvailable] = @QuantityAvailable AND @QuantityAvailable is not null)
	OR ([ProductList] = @ProductList AND @ProductList is not null)
	OR ([OrderMinimum] = @OrderMinimum AND @OrderMinimum is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderLineItem_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderLineItem_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeOrderLineItem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_Get_List

AS


				
				SELECT
					[OrderLineItemID],
					[OrderID],
					[ShipmentID],
					[ProductNum],
					[Name],
					[Description],
					[Quantity],
					[Price],
					[Weight],
					[PrePromoPrice],
					[Custom1],
					[Custom2],
					[Custom3],
					[SKU],
					[ParentOrderLineItemID]
				FROM
					dbo.[ZNodeOrderLineItem]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderLineItem_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderLineItem_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeOrderLineItem table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OrderLineItemID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OrderLineItemID]'
				SET @SQL = @SQL + ', [OrderID]'
				SET @SQL = @SQL + ', [ShipmentID]'
				SET @SQL = @SQL + ', [ProductNum]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [Quantity]'
				SET @SQL = @SQL + ', [Price]'
				SET @SQL = @SQL + ', [Weight]'
				SET @SQL = @SQL + ', [PrePromoPrice]'
				SET @SQL = @SQL + ', [Custom1]'
				SET @SQL = @SQL + ', [Custom2]'
				SET @SQL = @SQL + ', [Custom3]'
				SET @SQL = @SQL + ', [SKU]'
				SET @SQL = @SQL + ', [ParentOrderLineItemID]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeOrderLineItem]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OrderLineItemID],'
				SET @SQL = @SQL + ' [OrderID],'
				SET @SQL = @SQL + ' [ShipmentID],'
				SET @SQL = @SQL + ' [ProductNum],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [Quantity],'
				SET @SQL = @SQL + ' [Price],'
				SET @SQL = @SQL + ' [Weight],'
				SET @SQL = @SQL + ' [PrePromoPrice],'
				SET @SQL = @SQL + ' [Custom1],'
				SET @SQL = @SQL + ' [Custom2],'
				SET @SQL = @SQL + ' [Custom3],'
				SET @SQL = @SQL + ' [SKU],'
				SET @SQL = @SQL + ' [ParentOrderLineItemID]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeOrderLineItem]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderLineItem_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderLineItem_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeOrderLineItem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_Insert
(

	@OrderLineItemID int    OUTPUT,

	@OrderID int   ,

	@ShipmentID int   ,

	@ProductNum varchar (50)  ,

	@Name varchar (100)  ,

	@Description varchar (500)  ,

	@Quantity int   ,

	@Price money   ,

	@Weight decimal (18, 2)  ,

	@PrePromoPrice money   ,

	@Custom1 nvarchar (MAX)  ,

	@Custom2 nvarchar (MAX)  ,

	@Custom3 nvarchar (MAX)  ,

	@SKU nvarchar (MAX)  ,

	@ParentOrderLineItemID int   
)
AS


					
				INSERT INTO dbo.[ZNodeOrderLineItem]
					(
					[OrderID]
					,[ShipmentID]
					,[ProductNum]
					,[Name]
					,[Description]
					,[Quantity]
					,[Price]
					,[Weight]
					,[PrePromoPrice]
					,[Custom1]
					,[Custom2]
					,[Custom3]
					,[SKU]
					,[ParentOrderLineItemID]
					)
				VALUES
					(
					@OrderID
					,@ShipmentID
					,@ProductNum
					,@Name
					,@Description
					,@Quantity
					,@Price
					,@Weight
					,@PrePromoPrice
					,@Custom1
					,@Custom2
					,@Custom3
					,@SKU
					,@ParentOrderLineItemID
					)
				
				-- Get the identity value
				SET @OrderLineItemID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderLineItem_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderLineItem_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeOrderLineItem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_Update
(

	@OrderLineItemID int   ,

	@OrderID int   ,

	@ShipmentID int   ,

	@ProductNum varchar (50)  ,

	@Name varchar (100)  ,

	@Description varchar (500)  ,

	@Quantity int   ,

	@Price money   ,

	@Weight decimal (18, 2)  ,

	@PrePromoPrice money   ,

	@Custom1 nvarchar (MAX)  ,

	@Custom2 nvarchar (MAX)  ,

	@Custom3 nvarchar (MAX)  ,

	@SKU nvarchar (MAX)  ,

	@ParentOrderLineItemID int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeOrderLineItem]
				SET
					[OrderID] = @OrderID
					,[ShipmentID] = @ShipmentID
					,[ProductNum] = @ProductNum
					,[Name] = @Name
					,[Description] = @Description
					,[Quantity] = @Quantity
					,[Price] = @Price
					,[Weight] = @Weight
					,[PrePromoPrice] = @PrePromoPrice
					,[Custom1] = @Custom1
					,[Custom2] = @Custom2
					,[Custom3] = @Custom3
					,[SKU] = @SKU
					,[ParentOrderLineItemID] = @ParentOrderLineItemID
				WHERE
[OrderLineItemID] = @OrderLineItemID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderLineItem_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderLineItem_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeOrderLineItem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_Delete
(

	@OrderLineItemID int   
)
AS


				DELETE FROM dbo.[ZNodeOrderLineItem] WITH (ROWLOCK) 
				WHERE
					[OrderLineItemID] = @OrderLineItemID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderLineItem_GetByParentOrderLineItemID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderLineItem_GetByParentOrderLineItemID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_GetByParentOrderLineItemID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeOrderLineItem table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_GetByParentOrderLineItemID
(

	@ParentOrderLineItemID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[OrderLineItemID],
					[OrderID],
					[ShipmentID],
					[ProductNum],
					[Name],
					[Description],
					[Quantity],
					[Price],
					[Weight],
					[PrePromoPrice],
					[Custom1],
					[Custom2],
					[Custom3],
					[SKU],
					[ParentOrderLineItemID]
				FROM
					dbo.[ZNodeOrderLineItem]
				WHERE
					[ParentOrderLineItemID] = @ParentOrderLineItemID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderLineItem_GetByOrderID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderLineItem_GetByOrderID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_GetByOrderID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeOrderLineItem table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_GetByOrderID
(

	@OrderID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[OrderLineItemID],
					[OrderID],
					[ShipmentID],
					[ProductNum],
					[Name],
					[Description],
					[Quantity],
					[Price],
					[Weight],
					[PrePromoPrice],
					[Custom1],
					[Custom2],
					[Custom3],
					[SKU],
					[ParentOrderLineItemID]
				FROM
					dbo.[ZNodeOrderLineItem]
				WHERE
					[OrderID] = @OrderID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderLineItem_GetByOrderLineItemID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderLineItem_GetByOrderLineItemID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_GetByOrderLineItemID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeOrderLineItem table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_GetByOrderLineItemID
(

	@OrderLineItemID int   
)
AS


				SELECT
					[OrderLineItemID],
					[OrderID],
					[ShipmentID],
					[ProductNum],
					[Name],
					[Description],
					[Quantity],
					[Price],
					[Weight],
					[PrePromoPrice],
					[Custom1],
					[Custom2],
					[Custom3],
					[SKU],
					[ParentOrderLineItemID]
				FROM
					dbo.[ZNodeOrderLineItem]
				WHERE
					[OrderLineItemID] = @OrderLineItemID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrderLineItem_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrderLineItem_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeOrderLineItem table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrderLineItem_Find
(

	@SearchUsingOR bit   = null ,

	@OrderLineItemID int   = null ,

	@OrderID int   = null ,

	@ShipmentID int   = null ,

	@ProductNum varchar (50)  = null ,

	@Name varchar (100)  = null ,

	@Description varchar (500)  = null ,

	@Quantity int   = null ,

	@Price money   = null ,

	@Weight decimal (18, 2)  = null ,

	@PrePromoPrice money   = null ,

	@Custom1 nvarchar (MAX)  = null ,

	@Custom2 nvarchar (MAX)  = null ,

	@Custom3 nvarchar (MAX)  = null ,

	@SKU nvarchar (MAX)  = null ,

	@ParentOrderLineItemID int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OrderLineItemID]
	, [OrderID]
	, [ShipmentID]
	, [ProductNum]
	, [Name]
	, [Description]
	, [Quantity]
	, [Price]
	, [Weight]
	, [PrePromoPrice]
	, [Custom1]
	, [Custom2]
	, [Custom3]
	, [SKU]
	, [ParentOrderLineItemID]
    FROM
	dbo.[ZNodeOrderLineItem]
    WHERE 
	 ([OrderLineItemID] = @OrderLineItemID OR @OrderLineItemID is null)
	AND ([OrderID] = @OrderID OR @OrderID is null)
	AND ([ShipmentID] = @ShipmentID OR @ShipmentID is null)
	AND ([ProductNum] = @ProductNum OR @ProductNum is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([Description] = @Description OR @Description is null)
	AND ([Quantity] = @Quantity OR @Quantity is null)
	AND ([Price] = @Price OR @Price is null)
	AND ([Weight] = @Weight OR @Weight is null)
	AND ([PrePromoPrice] = @PrePromoPrice OR @PrePromoPrice is null)
	AND ([Custom1] = @Custom1 OR @Custom1 is null)
	AND ([Custom2] = @Custom2 OR @Custom2 is null)
	AND ([Custom3] = @Custom3 OR @Custom3 is null)
	AND ([SKU] = @SKU OR @SKU is null)
	AND ([ParentOrderLineItemID] = @ParentOrderLineItemID OR @ParentOrderLineItemID is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OrderLineItemID]
	, [OrderID]
	, [ShipmentID]
	, [ProductNum]
	, [Name]
	, [Description]
	, [Quantity]
	, [Price]
	, [Weight]
	, [PrePromoPrice]
	, [Custom1]
	, [Custom2]
	, [Custom3]
	, [SKU]
	, [ParentOrderLineItemID]
    FROM
	dbo.[ZNodeOrderLineItem]
    WHERE 
	 ([OrderLineItemID] = @OrderLineItemID AND @OrderLineItemID is not null)
	OR ([OrderID] = @OrderID AND @OrderID is not null)
	OR ([ShipmentID] = @ShipmentID AND @ShipmentID is not null)
	OR ([ProductNum] = @ProductNum AND @ProductNum is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([Quantity] = @Quantity AND @Quantity is not null)
	OR ([Price] = @Price AND @Price is not null)
	OR ([Weight] = @Weight AND @Weight is not null)
	OR ([PrePromoPrice] = @PrePromoPrice AND @PrePromoPrice is not null)
	OR ([Custom1] = @Custom1 AND @Custom1 is not null)
	OR ([Custom2] = @Custom2 AND @Custom2 is not null)
	OR ([Custom3] = @Custom3 AND @Custom3 is not null)
	OR ([SKU] = @SKU AND @SKU is not null)
	OR ([ParentOrderLineItemID] = @ParentOrderLineItemID AND @ParentOrderLineItemID is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeHighlight_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeHighlight_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeHighlight_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeHighlight table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeHighlight_Get_List

AS


				
				SELECT
					[HighlightID],
					[PortalID],
					[ImageFile],
					[Name],
					[Description],
					[DisplayPopup]
				FROM
					dbo.[ZNodeHighlight]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeHighlight_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeHighlight_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeHighlight_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeHighlight table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeHighlight_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[HighlightID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [HighlightID]'
				SET @SQL = @SQL + ', [PortalID]'
				SET @SQL = @SQL + ', [ImageFile]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [DisplayPopup]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeHighlight]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [HighlightID],'
				SET @SQL = @SQL + ' [PortalID],'
				SET @SQL = @SQL + ' [ImageFile],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [DisplayPopup]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeHighlight]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeHighlight_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeHighlight_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeHighlight_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeHighlight table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeHighlight_Insert
(

	@HighlightID int    OUTPUT,

	@PortalID int   ,

	@ImageFile varchar (100)  ,

	@Name varchar (100)  ,

	@Description text   ,

	@DisplayPopup bit   
)
AS


					
				INSERT INTO dbo.[ZNodeHighlight]
					(
					[PortalID]
					,[ImageFile]
					,[Name]
					,[Description]
					,[DisplayPopup]
					)
				VALUES
					(
					@PortalID
					,@ImageFile
					,@Name
					,@Description
					,@DisplayPopup
					)
				
				-- Get the identity value
				SET @HighlightID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeHighlight_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeHighlight_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeHighlight_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeHighlight table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeHighlight_Update
(

	@HighlightID int   ,

	@PortalID int   ,

	@ImageFile varchar (100)  ,

	@Name varchar (100)  ,

	@Description text   ,

	@DisplayPopup bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeHighlight]
				SET
					[PortalID] = @PortalID
					,[ImageFile] = @ImageFile
					,[Name] = @Name
					,[Description] = @Description
					,[DisplayPopup] = @DisplayPopup
				WHERE
[HighlightID] = @HighlightID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeHighlight_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeHighlight_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeHighlight_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeHighlight table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeHighlight_Delete
(

	@HighlightID int   
)
AS


				DELETE FROM dbo.[ZNodeHighlight] WITH (ROWLOCK) 
				WHERE
					[HighlightID] = @HighlightID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeHighlight_GetByHighlightID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeHighlight_GetByHighlightID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeHighlight_GetByHighlightID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeHighlight table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeHighlight_GetByHighlightID
(

	@HighlightID int   
)
AS


				SELECT
					[HighlightID],
					[PortalID],
					[ImageFile],
					[Name],
					[Description],
					[DisplayPopup]
				FROM
					dbo.[ZNodeHighlight]
				WHERE
					[HighlightID] = @HighlightID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeHighlight_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeHighlight_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeHighlight_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeHighlight table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeHighlight_Find
(

	@SearchUsingOR bit   = null ,

	@HighlightID int   = null ,

	@PortalID int   = null ,

	@ImageFile varchar (100)  = null ,

	@Name varchar (100)  = null ,

	@Description text   = null ,

	@DisplayPopup bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [HighlightID]
	, [PortalID]
	, [ImageFile]
	, [Name]
	, [Description]
	, [DisplayPopup]
    FROM
	dbo.[ZNodeHighlight]
    WHERE 
	 ([HighlightID] = @HighlightID OR @HighlightID is null)
	AND ([PortalID] = @PortalID OR @PortalID is null)
	AND ([ImageFile] = @ImageFile OR @ImageFile is null)
	AND ([Name] = @Name OR @Name is null)
	AND ([DisplayPopup] = @DisplayPopup OR @DisplayPopup is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [HighlightID]
	, [PortalID]
	, [ImageFile]
	, [Name]
	, [Description]
	, [DisplayPopup]
    FROM
	dbo.[ZNodeHighlight]
    WHERE 
	 ([HighlightID] = @HighlightID AND @HighlightID is not null)
	OR ([PortalID] = @PortalID AND @PortalID is not null)
	OR ([ImageFile] = @ImageFile AND @ImageFile is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([DisplayPopup] = @DisplayPopup AND @DisplayPopup is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrder_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrder_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrder_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets all records from the ZNodeOrder table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrder_Get_List

AS


				
				SELECT
					[OrderID],
					[PortalId],
					[AccountID],
					[OrderStateID],
					[ShippingID],
					[PaymentTypeId],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountry],
					[ShipPhoneNumber],
					[ShipEmailID],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountry],
					[BillingPhoneNumber],
					[BillingEmailId],
					[CardTransactionID],
					[CardTypeId],
					[CardEndsIn],
					[TaxCost],
					[ShippingCost],
					[SubTotal],
					[DiscountAmount],
					[Total],
					[CouponID],
					[OrderDate],
					[CreditCardNumber],
					[CreditCardExp],
					[CreditCardCVV],
					[Custom1],
					[Custom2],
					[AdditionalInstructions],
					[Custom3]
				FROM
					dbo.[ZNodeOrder]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrder_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrder_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrder_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Gets records from the ZNodeOrder table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrder_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OrderID]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OrderID]'
				SET @SQL = @SQL + ', [PortalId]'
				SET @SQL = @SQL + ', [AccountID]'
				SET @SQL = @SQL + ', [OrderStateID]'
				SET @SQL = @SQL + ', [ShippingID]'
				SET @SQL = @SQL + ', [PaymentTypeId]'
				SET @SQL = @SQL + ', [ShipFirstName]'
				SET @SQL = @SQL + ', [ShipLastName]'
				SET @SQL = @SQL + ', [ShipCompanyName]'
				SET @SQL = @SQL + ', [ShipStreet]'
				SET @SQL = @SQL + ', [ShipStreet1]'
				SET @SQL = @SQL + ', [ShipCity]'
				SET @SQL = @SQL + ', [ShipStateCode]'
				SET @SQL = @SQL + ', [ShipPostalCode]'
				SET @SQL = @SQL + ', [ShipCountry]'
				SET @SQL = @SQL + ', [ShipPhoneNumber]'
				SET @SQL = @SQL + ', [ShipEmailID]'
				SET @SQL = @SQL + ', [BillingFirstName]'
				SET @SQL = @SQL + ', [BillingLastName]'
				SET @SQL = @SQL + ', [BillingCompanyName]'
				SET @SQL = @SQL + ', [BillingStreet]'
				SET @SQL = @SQL + ', [BillingStreet1]'
				SET @SQL = @SQL + ', [BillingCity]'
				SET @SQL = @SQL + ', [BillingStateCode]'
				SET @SQL = @SQL + ', [BillingPostalCode]'
				SET @SQL = @SQL + ', [BillingCountry]'
				SET @SQL = @SQL + ', [BillingPhoneNumber]'
				SET @SQL = @SQL + ', [BillingEmailId]'
				SET @SQL = @SQL + ', [CardTransactionID]'
				SET @SQL = @SQL + ', [CardTypeId]'
				SET @SQL = @SQL + ', [CardEndsIn]'
				SET @SQL = @SQL + ', [TaxCost]'
				SET @SQL = @SQL + ', [ShippingCost]'
				SET @SQL = @SQL + ', [SubTotal]'
				SET @SQL = @SQL + ', [DiscountAmount]'
				SET @SQL = @SQL + ', [Total]'
				SET @SQL = @SQL + ', [CouponID]'
				SET @SQL = @SQL + ', [OrderDate]'
				SET @SQL = @SQL + ', [CreditCardNumber]'
				SET @SQL = @SQL + ', [CreditCardExp]'
				SET @SQL = @SQL + ', [CreditCardCVV]'
				SET @SQL = @SQL + ', [Custom1]'
				SET @SQL = @SQL + ', [Custom2]'
				SET @SQL = @SQL + ', [AdditionalInstructions]'
				SET @SQL = @SQL + ', [Custom3]'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeOrder]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OrderID],'
				SET @SQL = @SQL + ' [PortalId],'
				SET @SQL = @SQL + ' [AccountID],'
				SET @SQL = @SQL + ' [OrderStateID],'
				SET @SQL = @SQL + ' [ShippingID],'
				SET @SQL = @SQL + ' [PaymentTypeId],'
				SET @SQL = @SQL + ' [ShipFirstName],'
				SET @SQL = @SQL + ' [ShipLastName],'
				SET @SQL = @SQL + ' [ShipCompanyName],'
				SET @SQL = @SQL + ' [ShipStreet],'
				SET @SQL = @SQL + ' [ShipStreet1],'
				SET @SQL = @SQL + ' [ShipCity],'
				SET @SQL = @SQL + ' [ShipStateCode],'
				SET @SQL = @SQL + ' [ShipPostalCode],'
				SET @SQL = @SQL + ' [ShipCountry],'
				SET @SQL = @SQL + ' [ShipPhoneNumber],'
				SET @SQL = @SQL + ' [ShipEmailID],'
				SET @SQL = @SQL + ' [BillingFirstName],'
				SET @SQL = @SQL + ' [BillingLastName],'
				SET @SQL = @SQL + ' [BillingCompanyName],'
				SET @SQL = @SQL + ' [BillingStreet],'
				SET @SQL = @SQL + ' [BillingStreet1],'
				SET @SQL = @SQL + ' [BillingCity],'
				SET @SQL = @SQL + ' [BillingStateCode],'
				SET @SQL = @SQL + ' [BillingPostalCode],'
				SET @SQL = @SQL + ' [BillingCountry],'
				SET @SQL = @SQL + ' [BillingPhoneNumber],'
				SET @SQL = @SQL + ' [BillingEmailId],'
				SET @SQL = @SQL + ' [CardTransactionID],'
				SET @SQL = @SQL + ' [CardTypeId],'
				SET @SQL = @SQL + ' [CardEndsIn],'
				SET @SQL = @SQL + ' [TaxCost],'
				SET @SQL = @SQL + ' [ShippingCost],'
				SET @SQL = @SQL + ' [SubTotal],'
				SET @SQL = @SQL + ' [DiscountAmount],'
				SET @SQL = @SQL + ' [Total],'
				SET @SQL = @SQL + ' [CouponID],'
				SET @SQL = @SQL + ' [OrderDate],'
				SET @SQL = @SQL + ' [CreditCardNumber],'
				SET @SQL = @SQL + ' [CreditCardExp],'
				SET @SQL = @SQL + ' [CreditCardCVV],'
				SET @SQL = @SQL + ' [Custom1],'
				SET @SQL = @SQL + ' [Custom2],'
				SET @SQL = @SQL + ' [AdditionalInstructions],'
				SET @SQL = @SQL + ' [Custom3]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM dbo.[ZNodeOrder]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrder_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrder_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrder_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Inserts a record into the ZNodeOrder table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrder_Insert
(

	@OrderID int    OUTPUT,

	@PortalId int   ,

	@AccountID int   ,

	@OrderStateID int   ,

	@ShippingID int   ,

	@PaymentTypeId int   ,

	@ShipFirstName varchar (100)  ,

	@ShipLastName varchar (100)  ,

	@ShipCompanyName varchar (100)  ,

	@ShipStreet varchar (100)  ,

	@ShipStreet1 varchar (100)  ,

	@ShipCity varchar (100)  ,

	@ShipStateCode varchar (2)  ,

	@ShipPostalCode varchar (10)  ,

	@ShipCountry varchar (2)  ,

	@ShipPhoneNumber varchar (100)  ,

	@ShipEmailID varchar (200)  ,

	@BillingFirstName varchar (100)  ,

	@BillingLastName varchar (100)  ,

	@BillingCompanyName varchar (100)  ,

	@BillingStreet varchar (100)  ,

	@BillingStreet1 varchar (100)  ,

	@BillingCity varchar (100)  ,

	@BillingStateCode varchar (2)  ,

	@BillingPostalCode varchar (10)  ,

	@BillingCountry varchar (2)  ,

	@BillingPhoneNumber varchar (100)  ,

	@BillingEmailId varchar (200)  ,

	@CardTransactionID varchar (MAX)  ,

	@CardTypeId int   ,

	@CardEndsIn varchar (4)  ,

	@TaxCost smallmoney   ,

	@ShippingCost smallmoney   ,

	@SubTotal money   ,

	@DiscountAmount money   ,

	@Total money   ,

	@CouponID int   ,

	@OrderDate datetime   ,

	@CreditCardNumber varchar (MAX)  ,

	@CreditCardExp varchar (MAX)  ,

	@CreditCardCVV varchar (MAX)  ,

	@Custom1 nvarchar (MAX)  ,

	@Custom2 nvarchar (MAX)  ,

	@AdditionalInstructions nvarchar (MAX)  ,

	@Custom3 nvarchar (MAX)  
)
AS


					
				INSERT INTO dbo.[ZNodeOrder]
					(
					[PortalId]
					,[AccountID]
					,[OrderStateID]
					,[ShippingID]
					,[PaymentTypeId]
					,[ShipFirstName]
					,[ShipLastName]
					,[ShipCompanyName]
					,[ShipStreet]
					,[ShipStreet1]
					,[ShipCity]
					,[ShipStateCode]
					,[ShipPostalCode]
					,[ShipCountry]
					,[ShipPhoneNumber]
					,[ShipEmailID]
					,[BillingFirstName]
					,[BillingLastName]
					,[BillingCompanyName]
					,[BillingStreet]
					,[BillingStreet1]
					,[BillingCity]
					,[BillingStateCode]
					,[BillingPostalCode]
					,[BillingCountry]
					,[BillingPhoneNumber]
					,[BillingEmailId]
					,[CardTransactionID]
					,[CardTypeId]
					,[CardEndsIn]
					,[TaxCost]
					,[ShippingCost]
					,[SubTotal]
					,[DiscountAmount]
					,[Total]
					,[CouponID]
					,[OrderDate]
					,[CreditCardNumber]
					,[CreditCardExp]
					,[CreditCardCVV]
					,[Custom1]
					,[Custom2]
					,[AdditionalInstructions]
					,[Custom3]
					)
				VALUES
					(
					@PortalId
					,@AccountID
					,@OrderStateID
					,@ShippingID
					,@PaymentTypeId
					,@ShipFirstName
					,@ShipLastName
					,@ShipCompanyName
					,@ShipStreet
					,@ShipStreet1
					,@ShipCity
					,@ShipStateCode
					,@ShipPostalCode
					,@ShipCountry
					,@ShipPhoneNumber
					,@ShipEmailID
					,@BillingFirstName
					,@BillingLastName
					,@BillingCompanyName
					,@BillingStreet
					,@BillingStreet1
					,@BillingCity
					,@BillingStateCode
					,@BillingPostalCode
					,@BillingCountry
					,@BillingPhoneNumber
					,@BillingEmailId
					,@CardTransactionID
					,@CardTypeId
					,@CardEndsIn
					,@TaxCost
					,@ShippingCost
					,@SubTotal
					,@DiscountAmount
					,@Total
					,@CouponID
					,@OrderDate
					,@CreditCardNumber
					,@CreditCardExp
					,@CreditCardCVV
					,@Custom1
					,@Custom2
					,@AdditionalInstructions
					,@Custom3
					)
				
				-- Get the identity value
				SET @OrderID = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrder_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrder_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrder_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Updates a record in the ZNodeOrder table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrder_Update
(

	@OrderID int   ,

	@PortalId int   ,

	@AccountID int   ,

	@OrderStateID int   ,

	@ShippingID int   ,

	@PaymentTypeId int   ,

	@ShipFirstName varchar (100)  ,

	@ShipLastName varchar (100)  ,

	@ShipCompanyName varchar (100)  ,

	@ShipStreet varchar (100)  ,

	@ShipStreet1 varchar (100)  ,

	@ShipCity varchar (100)  ,

	@ShipStateCode varchar (2)  ,

	@ShipPostalCode varchar (10)  ,

	@ShipCountry varchar (2)  ,

	@ShipPhoneNumber varchar (100)  ,

	@ShipEmailID varchar (200)  ,

	@BillingFirstName varchar (100)  ,

	@BillingLastName varchar (100)  ,

	@BillingCompanyName varchar (100)  ,

	@BillingStreet varchar (100)  ,

	@BillingStreet1 varchar (100)  ,

	@BillingCity varchar (100)  ,

	@BillingStateCode varchar (2)  ,

	@BillingPostalCode varchar (10)  ,

	@BillingCountry varchar (2)  ,

	@BillingPhoneNumber varchar (100)  ,

	@BillingEmailId varchar (200)  ,

	@CardTransactionID varchar (MAX)  ,

	@CardTypeId int   ,

	@CardEndsIn varchar (4)  ,

	@TaxCost smallmoney   ,

	@ShippingCost smallmoney   ,

	@SubTotal money   ,

	@DiscountAmount money   ,

	@Total money   ,

	@CouponID int   ,

	@OrderDate datetime   ,

	@CreditCardNumber varchar (MAX)  ,

	@CreditCardExp varchar (MAX)  ,

	@CreditCardCVV varchar (MAX)  ,

	@Custom1 nvarchar (MAX)  ,

	@Custom2 nvarchar (MAX)  ,

	@AdditionalInstructions nvarchar (MAX)  ,

	@Custom3 nvarchar (MAX)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					dbo.[ZNodeOrder]
				SET
					[PortalId] = @PortalId
					,[AccountID] = @AccountID
					,[OrderStateID] = @OrderStateID
					,[ShippingID] = @ShippingID
					,[PaymentTypeId] = @PaymentTypeId
					,[ShipFirstName] = @ShipFirstName
					,[ShipLastName] = @ShipLastName
					,[ShipCompanyName] = @ShipCompanyName
					,[ShipStreet] = @ShipStreet
					,[ShipStreet1] = @ShipStreet1
					,[ShipCity] = @ShipCity
					,[ShipStateCode] = @ShipStateCode
					,[ShipPostalCode] = @ShipPostalCode
					,[ShipCountry] = @ShipCountry
					,[ShipPhoneNumber] = @ShipPhoneNumber
					,[ShipEmailID] = @ShipEmailID
					,[BillingFirstName] = @BillingFirstName
					,[BillingLastName] = @BillingLastName
					,[BillingCompanyName] = @BillingCompanyName
					,[BillingStreet] = @BillingStreet
					,[BillingStreet1] = @BillingStreet1
					,[BillingCity] = @BillingCity
					,[BillingStateCode] = @BillingStateCode
					,[BillingPostalCode] = @BillingPostalCode
					,[BillingCountry] = @BillingCountry
					,[BillingPhoneNumber] = @BillingPhoneNumber
					,[BillingEmailId] = @BillingEmailId
					,[CardTransactionID] = @CardTransactionID
					,[CardTypeId] = @CardTypeId
					,[CardEndsIn] = @CardEndsIn
					,[TaxCost] = @TaxCost
					,[ShippingCost] = @ShippingCost
					,[SubTotal] = @SubTotal
					,[DiscountAmount] = @DiscountAmount
					,[Total] = @Total
					,[CouponID] = @CouponID
					,[OrderDate] = @OrderDate
					,[CreditCardNumber] = @CreditCardNumber
					,[CreditCardExp] = @CreditCardExp
					,[CreditCardCVV] = @CreditCardCVV
					,[Custom1] = @Custom1
					,[Custom2] = @Custom2
					,[AdditionalInstructions] = @AdditionalInstructions
					,[Custom3] = @Custom3
				WHERE
[OrderID] = @OrderID 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrder_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrder_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrder_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Deletes a record in the ZNodeOrder table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrder_Delete
(

	@OrderID int   
)
AS


				DELETE FROM dbo.[ZNodeOrder] WITH (ROWLOCK) 
				WHERE
					[OrderID] = @OrderID
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrder_GetByPortalId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrder_GetByPortalId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrder_GetByPortalId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeOrder table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrder_GetByPortalId
(

	@PortalId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[OrderID],
					[PortalId],
					[AccountID],
					[OrderStateID],
					[ShippingID],
					[PaymentTypeId],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountry],
					[ShipPhoneNumber],
					[ShipEmailID],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountry],
					[BillingPhoneNumber],
					[BillingEmailId],
					[CardTransactionID],
					[CardTypeId],
					[CardEndsIn],
					[TaxCost],
					[ShippingCost],
					[SubTotal],
					[DiscountAmount],
					[Total],
					[CouponID],
					[OrderDate],
					[CreditCardNumber],
					[CreditCardExp],
					[CreditCardCVV],
					[Custom1],
					[Custom2],
					[AdditionalInstructions],
					[Custom3]
				FROM
					dbo.[ZNodeOrder]
				WHERE
					[PortalId] = @PortalId
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrder_GetByShippingID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrder_GetByShippingID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrder_GetByShippingID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeOrder table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrder_GetByShippingID
(

	@ShippingID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[OrderID],
					[PortalId],
					[AccountID],
					[OrderStateID],
					[ShippingID],
					[PaymentTypeId],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountry],
					[ShipPhoneNumber],
					[ShipEmailID],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountry],
					[BillingPhoneNumber],
					[BillingEmailId],
					[CardTransactionID],
					[CardTypeId],
					[CardEndsIn],
					[TaxCost],
					[ShippingCost],
					[SubTotal],
					[DiscountAmount],
					[Total],
					[CouponID],
					[OrderDate],
					[CreditCardNumber],
					[CreditCardExp],
					[CreditCardCVV],
					[Custom1],
					[Custom2],
					[AdditionalInstructions],
					[Custom3]
				FROM
					dbo.[ZNodeOrder]
				WHERE
					[ShippingID] = @ShippingID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrder_GetByCouponID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrder_GetByCouponID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrder_GetByCouponID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeOrder table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrder_GetByCouponID
(

	@CouponID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[OrderID],
					[PortalId],
					[AccountID],
					[OrderStateID],
					[ShippingID],
					[PaymentTypeId],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountry],
					[ShipPhoneNumber],
					[ShipEmailID],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountry],
					[BillingPhoneNumber],
					[BillingEmailId],
					[CardTransactionID],
					[CardTypeId],
					[CardEndsIn],
					[TaxCost],
					[ShippingCost],
					[SubTotal],
					[DiscountAmount],
					[Total],
					[CouponID],
					[OrderDate],
					[CreditCardNumber],
					[CreditCardExp],
					[CreditCardCVV],
					[Custom1],
					[Custom2],
					[AdditionalInstructions],
					[Custom3]
				FROM
					dbo.[ZNodeOrder]
				WHERE
					[CouponID] = @CouponID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrder_GetByOrderStateID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrder_GetByOrderStateID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrder_GetByOrderStateID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeOrder table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrder_GetByOrderStateID
(

	@OrderStateID int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[OrderID],
					[PortalId],
					[AccountID],
					[OrderStateID],
					[ShippingID],
					[PaymentTypeId],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountry],
					[ShipPhoneNumber],
					[ShipEmailID],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountry],
					[BillingPhoneNumber],
					[BillingEmailId],
					[CardTransactionID],
					[CardTypeId],
					[CardEndsIn],
					[TaxCost],
					[ShippingCost],
					[SubTotal],
					[DiscountAmount],
					[Total],
					[CouponID],
					[OrderDate],
					[CreditCardNumber],
					[CreditCardExp],
					[CreditCardCVV],
					[Custom1],
					[Custom2],
					[AdditionalInstructions],
					[Custom3]
				FROM
					dbo.[ZNodeOrder]
				WHERE
					[OrderStateID] = @OrderStateID
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrder_GetByOrderID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrder_GetByOrderID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrder_GetByOrderID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeOrder table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrder_GetByOrderID
(

	@OrderID int   
)
AS


				SELECT
					[OrderID],
					[PortalId],
					[AccountID],
					[OrderStateID],
					[ShippingID],
					[PaymentTypeId],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountry],
					[ShipPhoneNumber],
					[ShipEmailID],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountry],
					[BillingPhoneNumber],
					[BillingEmailId],
					[CardTransactionID],
					[CardTypeId],
					[CardEndsIn],
					[TaxCost],
					[ShippingCost],
					[SubTotal],
					[DiscountAmount],
					[Total],
					[CouponID],
					[OrderDate],
					[CreditCardNumber],
					[CreditCardExp],
					[CreditCardCVV],
					[Custom1],
					[Custom2],
					[AdditionalInstructions],
					[Custom3]
				FROM
					dbo.[ZNodeOrder]
				WHERE
					[OrderID] = @OrderID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrder_GetByAccountID procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrder_GetByAccountID') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrder_GetByAccountID
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Select records from the ZNodeOrder table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrder_GetByAccountID
(

	@AccountID int   
)
AS


				SELECT
					[OrderID],
					[PortalId],
					[AccountID],
					[OrderStateID],
					[ShippingID],
					[PaymentTypeId],
					[ShipFirstName],
					[ShipLastName],
					[ShipCompanyName],
					[ShipStreet],
					[ShipStreet1],
					[ShipCity],
					[ShipStateCode],
					[ShipPostalCode],
					[ShipCountry],
					[ShipPhoneNumber],
					[ShipEmailID],
					[BillingFirstName],
					[BillingLastName],
					[BillingCompanyName],
					[BillingStreet],
					[BillingStreet1],
					[BillingCity],
					[BillingStateCode],
					[BillingPostalCode],
					[BillingCountry],
					[BillingPhoneNumber],
					[BillingEmailId],
					[CardTransactionID],
					[CardTypeId],
					[CardEndsIn],
					[TaxCost],
					[ShippingCost],
					[SubTotal],
					[DiscountAmount],
					[Total],
					[CouponID],
					[OrderDate],
					[CreditCardNumber],
					[CreditCardExp],
					[CreditCardCVV],
					[Custom1],
					[Custom2],
					[AdditionalInstructions],
					[Custom3]
				FROM
					dbo.[ZNodeOrder]
				WHERE
					[AccountID] = @AccountID
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ZNODE_NT_ZNodeOrder_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ZNODE_NT_ZNodeOrder_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ZNODE_NT_ZNodeOrder_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, October 18, 2007

-- Created By: ZNode Inc (http://www.znode.com)
-- Purpose: Finds records in the ZNodeOrder table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ZNODE_NT_ZNodeOrder_Find
(

	@SearchUsingOR bit   = null ,

	@OrderID int   = null ,

	@PortalId int   = null ,

	@AccountID int   = null ,

	@OrderStateID int   = null ,

	@ShippingID int   = null ,

	@PaymentTypeId int   = null ,

	@ShipFirstName varchar (100)  = null ,

	@ShipLastName varchar (100)  = null ,

	@ShipCompanyName varchar (100)  = null ,

	@ShipStreet varchar (100)  = null ,

	@ShipStreet1 varchar (100)  = null ,

	@ShipCity varchar (100)  = null ,

	@ShipStateCode varchar (2)  = null ,

	@ShipPostalCode varchar (10)  = null ,

	@ShipCountry varchar (2)  = null ,

	@ShipPhoneNumber varchar (100)  = null ,

	@ShipEmailID varchar (200)  = null ,

	@BillingFirstName varchar (100)  = null ,

	@BillingLastName varchar (100)  = null ,

	@BillingCompanyName varchar (100)  = null ,

	@BillingStreet varchar (100)  = null ,

	@BillingStreet1 varchar (100)  = null ,

	@BillingCity varchar (100)  = null ,

	@BillingStateCode varchar (2)  = null ,

	@BillingPostalCode varchar (10)  = null ,

	@BillingCountry varchar (2)  = null ,

	@BillingPhoneNumber varchar (100)  = null ,

	@BillingEmailId varchar (200)  = null ,

	@CardTransactionID varchar (MAX)  = null ,

	@CardTypeId int   = null ,

	@CardEndsIn varchar (4)  = null ,

	@TaxCost smallmoney   = null ,

	@ShippingCost smallmoney   = null ,

	@SubTotal money   = null ,

	@DiscountAmount money   = null ,

	@Total money   = null ,

	@CouponID int   = null ,

	@OrderDate datetime   = null ,

	@CreditCardNumber varchar (MAX)  = null ,

	@CreditCardExp varchar (MAX)  = null ,

	@CreditCardCVV varchar (MAX)  = null ,

	@Custom1 nvarchar (MAX)  = null ,

	@Custom2 nvarchar (MAX)  = null ,

	@AdditionalInstructions nvarchar (MAX)  = null ,

	@Custom3 nvarchar (MAX)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OrderID]
	, [PortalId]
	, [AccountID]
	, [OrderStateID]
	, [ShippingID]
	, [PaymentTypeId]
	, [ShipFirstName]
	, [ShipLastName]
	, [ShipCompanyName]
	, [ShipStreet]
	, [ShipStreet1]
	, [ShipCity]
	, [ShipStateCode]
	, [ShipPostalCode]
	, [ShipCountry]
	, [ShipPhoneNumber]
	, [ShipEmailID]
	, [BillingFirstName]
	, [BillingLastName]
	, [BillingCompanyName]
	, [BillingStreet]
	, [BillingStreet1]
	, [BillingCity]
	, [BillingStateCode]
	, [BillingPostalCode]
	, [BillingCountry]
	, [BillingPhoneNumber]
	, [BillingEmailId]
	, [CardTransactionID]
	, [CardTypeId]
	, [CardEndsIn]
	, [TaxCost]
	, [ShippingCost]
	, [SubTotal]
	, [DiscountAmount]
	, [Total]
	, [CouponID]
	, [OrderDate]
	, [CreditCardNumber]
	, [CreditCardExp]
	, [CreditCardCVV]
	, [Custom1]
	, [Custom2]
	, [AdditionalInstructions]
	, [Custom3]
    FROM
	dbo.[ZNodeOrder]
    WHERE 
	 ([OrderID] = @OrderID OR @OrderID is null)
	AND ([PortalId] = @PortalId OR @PortalId is null)
	AND ([AccountID] = @AccountID OR @AccountID is null)
	AND ([OrderStateID] = @OrderStateID OR @OrderStateID is null)
	AND ([ShippingID] = @ShippingID OR @ShippingID is null)
	AND ([PaymentTypeId] = @PaymentTypeId OR @PaymentTypeId is null)
	AND ([ShipFirstName] = @ShipFirstName OR @ShipFirstName is null)
	AND ([ShipLastName] = @ShipLastName OR @ShipLastName is null)
	AND ([ShipCompanyName] = @ShipCompanyName OR @ShipCompanyName is null)
	AND ([ShipStreet] = @ShipStreet OR @ShipStreet is null)
	AND ([ShipStreet1] = @ShipStreet1 OR @ShipStreet1 is null)
	AND ([ShipCity] = @ShipCity OR @ShipCity is null)
	AND ([ShipStateCode] = @ShipStateCode OR @ShipStateCode is null)
	AND ([ShipPostalCode] = @ShipPostalCode OR @ShipPostalCode is null)
	AND ([ShipCountry] = @ShipCountry OR @ShipCountry is null)
	AND ([ShipPhoneNumber] = @ShipPhoneNumber OR @ShipPhoneNumber is null)
	AND ([ShipEmailID] = @ShipEmailID OR @ShipEmailID is null)
	AND ([BillingFirstName] = @BillingFirstName OR @BillingFirstName is null)
	AND ([BillingLastName] = @BillingLastName OR @BillingLastName is null)
	AND ([BillingCompanyName] = @BillingCompanyName OR @BillingCompanyName is null)
	AND ([BillingStreet] = @BillingStreet OR @BillingStreet is null)
	AND ([BillingStreet1] = @BillingStreet1 OR @BillingStreet1 is null)
	AND ([BillingCity] = @BillingCity OR @BillingCity is null)
	AND ([BillingStateCode] = @BillingStateCode OR @BillingStateCode is null)
	AND ([BillingPostalCode] = @BillingPostalCode OR @BillingPostalCode is null)
	AND ([BillingCountry] = @BillingCountry OR @BillingCountry is null)
	AND ([BillingPhoneNumber] = @BillingPhoneNumber OR @BillingPhoneNumber is null)
	AND ([BillingEmailId] = @BillingEmailId OR @BillingEmailId is null)
	AND ([CardTransactionID] = @CardTransactionID OR @CardTransactionID is null)
	AND ([CardTypeId] = @CardTypeId OR @CardTypeId is null)
	AND ([CardEndsIn] = @CardEndsIn OR @CardEndsIn is null)
	AND ([TaxCost] = @TaxCost OR @TaxCost is null)
	AND ([ShippingCost] = @ShippingCost OR @ShippingCost is null)
	AND ([SubTotal] = @SubTotal OR @SubTotal is null)
	AND ([DiscountAmount] = @DiscountAmount OR @DiscountAmount is null)
	AND ([Total] = @Total OR @Total is null)
	AND ([CouponID] = @CouponID OR @CouponID is null)
	AND ([OrderDate] = @OrderDate OR @OrderDate is null)
	AND ([CreditCardNumber] = @CreditCardNumber OR @CreditCardNumber is null)
	AND ([CreditCardExp] = @CreditCardExp OR @CreditCardExp is null)
	AND ([CreditCardCVV] = @CreditCardCVV OR @CreditCardCVV is null)
	AND ([Custom1] = @Custom1 OR @Custom1 is null)
	AND ([Custom2] = @Custom2 OR @Custom2 is null)
	AND ([AdditionalInstructions] = @AdditionalInstructions OR @AdditionalInstructions is null)
	AND ([Custom3] = @Custom3 OR @Custom3 is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OrderID]
	, [PortalId]
	, [AccountID]
	, [OrderStateID]
	, [ShippingID]
	, [PaymentTypeId]
	, [ShipFirstName]
	, [ShipLastName]
	, [ShipCompanyName]
	, [ShipStreet]
	, [ShipStreet1]
	, [ShipCity]
	, [ShipStateCode]
	, [ShipPostalCode]
	, [ShipCountry]
	, [ShipPhoneNumber]
	, [ShipEmailID]
	, [BillingFirstName]
	, [BillingLastName]
	, [BillingCompanyName]
	, [BillingStreet]
	, [BillingStreet1]
	, [BillingCity]
	, [BillingStateCode]
	, [BillingPostalCode]
	, [BillingCountry]
	, [BillingPhoneNumber]
	, [BillingEmailId]
	, [CardTransactionID]
	, [CardTypeId]
	, [CardEndsIn]
	, [TaxCost]
	, [ShippingCost]
	, [SubTotal]
	, [DiscountAmount]
	, [Total]
	, [CouponID]
	, [OrderDate]
	, [CreditCardNumber]
	, [CreditCardExp]
	, [CreditCardCVV]
	, [Custom1]
	, [Custom2]
	, [AdditionalInstructions]
	, [Custom3]
    FROM
	dbo.[ZNodeOrder]
    WHERE 
	 ([OrderID] = @OrderID AND @OrderID is not null)
	OR ([PortalId] = @PortalId AND @PortalId is not null)
	OR ([AccountID] = @AccountID AND @AccountID is not null)
	OR ([OrderStateID] = @OrderStateID AND @OrderStateID is not null)
	OR ([ShippingID] = @ShippingID AND @ShippingID is not null)
	OR ([PaymentTypeId] = @PaymentTypeId AND @PaymentTypeId is not null)
	OR ([ShipFirstName] = @ShipFirstName AND @ShipFirstName is not null)
	OR ([ShipLastName] = @ShipLastName AND @ShipLastName is not null)
	OR ([ShipCompanyName] = @ShipCompanyName AND @ShipCompanyName is not null)
	OR ([ShipStreet] = @ShipStreet AND @ShipStreet is not null)
	OR ([ShipStreet1] = @ShipStreet1 AND @ShipStreet1 is not null)
	OR ([ShipCity] = @ShipCity AND @ShipCity is not null)
	OR ([ShipStateCode] = @ShipStateCode AND @ShipStateCode is not null)
	OR ([ShipPostalCode] = @ShipPostalCode AND @ShipPostalCode is not null)
	OR ([ShipCountry] = @ShipCountry AND @ShipCountry is not null)
	OR ([ShipPhoneNumber] = @ShipPhoneNumber AND @ShipPhoneNumber is not null)
	OR ([ShipEmailID] = @ShipEmailID AND @ShipEmailID is not null)
	OR ([BillingFirstName] = @BillingFirstName AND @BillingFirstName is not null)
	OR ([BillingLastName] = @BillingLastName AND @BillingLastName is not null)
	OR ([BillingCompanyName] = @BillingCompanyName AND @BillingCompanyName is not null)
	OR ([BillingStreet] = @BillingStreet AND @BillingStreet is not null)
	OR ([BillingStreet1] = @BillingStreet1 AND @BillingStreet1 is not null)
	OR ([BillingCity] = @BillingCity AND @BillingCity is not null)
	OR ([BillingStateCode] = @BillingStateCode AND @BillingStateCode is not null)
	OR ([BillingPostalCode] = @BillingPostalCode AND @BillingPostalCode is not null)
	OR ([BillingCountry] = @BillingCountry AND @BillingCountry is not null)
	OR ([BillingPhoneNumber] = @BillingPhoneNumber AND @BillingPhoneNumber is not null)
	OR ([BillingEmailId] = @BillingEmailId AND @BillingEmailId is not null)
	OR ([CardTransactionID] = @CardTransactionID AND @CardTransactionID is not null)
	OR ([CardTypeId] = @CardTypeId AND @CardTypeId is not null)
	OR ([CardEndsIn] = @CardEndsIn AND @CardEndsIn is not null)
	OR ([TaxCost] = @TaxCost AND @TaxCost is not null)
	OR ([ShippingCost] = @ShippingCost AND @ShippingCost is not null)
	OR ([SubTotal] = @SubTotal AND @SubTotal is not null)
	OR ([DiscountAmount] = @DiscountAmount AND @DiscountAmount is not null)
	OR ([Total] = @Total AND @Total is not null)
	OR ([CouponID] = @CouponID AND @CouponID is not null)
	OR ([OrderDate] = @OrderDate AND @OrderDate is not null)
	OR ([CreditCardNumber] = @CreditCardNumber AND @CreditCardNumber is not null)
	OR ([CreditCardExp] = @CreditCardExp AND @CreditCardExp is not null)
	OR ([CreditCardCVV] = @CreditCardCVV AND @CreditCardCVV is not null)
	OR ([Custom1] = @Custom1 AND @Custom1 is not null)
	OR ([Custom2] = @Custom2 AND @Custom2 is not null)
	OR ([AdditionalInstructions] = @AdditionalInstructions AND @AdditionalInstructions is not null)
	OR ([Custom3] = @Custom3 AND @Custom3 is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

