using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Entities;

namespace ZNode.Libraries.Admin
{   
    
    /// <summary>
    /// Provides methods to manage discount coupons 
    /// </summary>
    public class CouponAdmin:ZNodeBusinessBase 
    {
        #region public methods
     
        /// <summary>
        /// Returns all coupon
        /// </summary>
        /// <returns></returns>
        public TList<ZNode.Libraries.DataAccess.Entities.Coupon> GetAll()
        {
            ZNode.Libraries.DataAccess.Service.CouponService _couponaccess = new CouponService();
            TList<ZNode.Libraries.DataAccess.Entities.Coupon> _CouponList = _couponaccess.GetAll();
            return _CouponList;
        }

        /// <summary>
        /// Returns all DiscountType for the coupon
        /// </summary>
        /// <returns></returns>
        public TList<ZNode.Libraries.DataAccess.Entities.DiscountType> GetAllDiscountTypes()
        {
            ZNode.Libraries.DataAccess.Service.DiscountTypeService  discounttype= new DiscountTypeService();
            TList<ZNode.Libraries.DataAccess.Entities.DiscountType> discounttypelist = discounttype.GetAll();            
            return discounttypelist;
        }

        /// <summary>
        /// Returns all DiscountTareget for the coupon
        /// </summary>
        /// <returns></returns>
        public TList<ZNode.Libraries.DataAccess.Entities.DiscountTarget> GetAllDiscountTarget()
        {
            ZNode.Libraries.DataAccess.Service.DiscountTargetService discounttarget = new DiscountTargetService();
            TList<ZNode.Libraries.DataAccess.Entities.DiscountTarget> discounttargetlist = discounttarget.GetAll();
            return discounttargetlist;
        }

        /// <summary>
        /// Returns the DiscountTypeID for the coupon
        /// </summary>
        /// <returns></returns>
        public ZNode.Libraries.DataAccess.Entities.DiscountType GetByDiscountTypeID(int DiscountTypeID)
        {
            ZNode.Libraries.DataAccess.Service.DiscountTypeService discounttype = new DiscountTypeService();
            ZNode.Libraries.DataAccess.Entities.DiscountType discounttypelist = discounttype.GetByDiscountTypeID(DiscountTypeID);
            return discounttypelist;
        }

        /// <summary>
        /// Returns the DiscountTargetID for the coupon
        /// </summary>
        /// <returns></returns>
        public ZNode.Libraries.DataAccess.Entities.DiscountTarget GetByDiscountTargetID(int DiscountTargetID)
        {
            ZNode.Libraries.DataAccess.Service.DiscountTargetService discounttarget = new DiscountTargetService();
            ZNode.Libraries.DataAccess.Entities.DiscountTarget discounttargetlist = discounttarget.GetByDiscountTargetID(DiscountTargetID);
            return discounttargetlist;
        }
       

        /// <summary>
        /// Returns the CouponCode for the coupon
        /// </summary>
        /// <returns></returns>
        public ZNode.Libraries.DataAccess.Entities.Coupon GetByCouponCode(string CouponCode)
        {
            ZNode.Libraries.DataAccess.Service.CouponService _couponaccess = new CouponService();
            ZNode.Libraries.DataAccess.Entities.Coupon _couponlist = _couponaccess.GetByCouponCode(CouponCode);
            return _couponlist;
        }

        /// <summary>
        /// Deletes the coupon
        /// </summary>
        public bool Delete(int ItemID)
        {
            ZNode.Libraries.DataAccess.Service.CouponService _couponaccess = new CouponService();
            bool status = _couponaccess.Delete(ItemID);
            return status;
        }

        /// <summary>
        /// Returns the couponID
        /// </summary>
        public ZNode.Libraries.DataAccess.Entities.Coupon GetByCouponID(int ItemID)
        {
            ZNode.Libraries.DataAccess.Service.CouponService _couponaccess = new CouponService();

            ZNode.Libraries.DataAccess.Entities.Coupon _CouponList = _couponaccess.GetByCouponID(ItemID);

            return _CouponList;
        }

        /// <summary>
        /// Insert the coupon
        /// </summary>
        public bool Insert(ZNode.Libraries.DataAccess.Entities.Coupon  _Coup)
        {
            ZNode.Libraries.DataAccess.Service.CouponService _couponaccess = new CouponService();
            bool status = _couponaccess.Insert(_Coup);            
            return status;
        }

        /// <summary>
        /// Updates the Coupon
        /// </summary>   
        public bool Update(ZNode.Libraries.DataAccess.Entities.Coupon _Coup)
        {
            ZNode.Libraries.DataAccess.Service.CouponService _couponaccess = new CouponService();
            bool status = _couponaccess.Update(_Coup);
            return status;
        }     
     
       #endregion
    }
}
