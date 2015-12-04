using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Caching;

namespace ZNode.Libraries.DataAccess.Entities
{
    interface IEntityCacheItem
    {
        TimeSpan EntityCacheDuration{ get; set; }
        CacheItemPriority EntityCacheItemPriority { get; set;  }
        ICacheItemExpiration EntityCacheItemExpiration { get; set; }
        ICacheItemRefreshAction EntityCacheItemRefreshAction { get; set; }
    }
}
