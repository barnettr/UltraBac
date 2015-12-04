using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Checkout Step Tracker
/// </summary>
public partial class Controls_ShoppingCartCheckout_StepTracker : System.Web.UI.UserControl
{
    #region Private Variables
    protected string class_step1 = "Passive";
    protected string class_step2 = "Passive"; //default active
    protected string class_step3 = "Passive";
    private int _step = 0;
    #endregion

    #region Public Properties
    public int Step
    {
        set 
        { 
            _step = value;

            //first de-activate steps
            MakeAllStepsPassive();

            if (_step == 1)
            {
                class_step1 = "Active";
            }
            else if (_step == 2)
            {
                class_step2 = "Active";
            }
            else if (_step == 3)
            {
                class_step3 = "Active";
            }      
            else
            {
                class_step1 = "Active";
            }
        }
    }
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    #endregion

    #region Helper Functions
    private void MakeAllStepsPassive()
    {
       class_step1 = "Passive";
       class_step2 = "Passive"; 
       class_step3 = "Passive";
   }
    #endregion
}
