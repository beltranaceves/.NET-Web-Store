﻿using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model.Objetos;
using Es.Udc.DotNet.PracticaMad.Model.Services.Exceptions;
using Es.Udc.DotNet.PracticaMad.Model.Services.ShoppingCartService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMad.Web.Pages.Orders
{
    public partial class SeeShoppingCart : SpecificCulturePage
    {
        private List<ShoppingCartLine> f = new List<ShoppingCartLine>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblNoStock.Visible = false;

                f = SessionManager.shoppingCart.shoppingCartLines;

                double price = 0;

                for (int i = 0; i < SessionManager.shoppingCart.shoppingCartLines.Count; i++)
                {
                    price += SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).totalPrice;
                }

                lblShoppingCartEmpty.Visible = false;

                txtPrizeTotal.Text = ((price)).ToString();

                LoadGrid2();
            }
        }

        protected void quantityList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList drop = sender as DropDownList;

                int units = Convert.ToInt32(drop.SelectedItem.Text);

                GridViewRow row = drop.NamingContainer as GridViewRow;

                long productId = (long)Convert.ToInt32(row.Cells[0].Text);

                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

                IShoppingCartService shop = (IShoppingCartService)iocManager.Resolve<IShoppingCartService>();

                for (int i = 0; i < SessionManager.shoppingCart.shoppingCartLines.Count; i++)
                {
                    if (SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).productId == productId)

                        shop.UpdateNumberOfUnits(SessionManager.shoppingCart.shoppingCartLines.ElementAt(i), SessionManager.shoppingCart, units);
                }

                f = SessionManager.shoppingCart.shoppingCartLines;

                gvShoppingCart.DataSource = f;

                gvShoppingCart.DataBind();

                Response.Redirect(Request.RawUrl.ToString());
            }
            catch (NotEnoughStockException)
            {
                lblNoStock.Visible = true;
            }
        }

        protected void cbForGift_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            GridViewRow row = c.NamingContainer as GridViewRow;

            long productId = (long)Convert.ToInt32(row.Cells[0].Text);

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

            IShoppingCartService shop = (IShoppingCartService)iocManager.Resolve<IShoppingCartService>();

            for (int i = 0; i < SessionManager.shoppingCart.shoppingCartLines.Count; i++)
            {
                if (SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).productId == productId)
                {
                    if (SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).forGift == true)
                        shop.UpdateForGiftStatus(SessionManager.shoppingCart.shoppingCartLines.ElementAt(i), SessionManager.shoppingCart, false);
                    else
                        shop.UpdateForGiftStatus(SessionManager.shoppingCart.shoppingCartLines.ElementAt(i), SessionManager.shoppingCart, true);
                }
            }

            f = SessionManager.shoppingCart.shoppingCartLines;
            f = SessionManager.shoppingCart.shoppingCartLines;

            gvShoppingCart.DataSource = f;

            gvShoppingCart.DataBind();

            LoadGrid2();
        }

        protected void btnToPay_Click(object sender, EventArgs e)
        {
            bool val1 = (System.Web.HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated;

            if (val1 == true)
                Server.Transfer(Response.ApplyAppPathModifier("~/Pages/Orders/ManageOrder.aspx"));


            else
                Server.Transfer(Response.ApplyAppPathModifier("~/Pages/User/Authentication.aspx"));
        }

        protected void gvShoppingCart_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gvShoppingCart.Rows[e.NewSelectedIndex];

            long productId = (long)Convert.ToInt32(row.Cells[0].Text);

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];

            IShoppingCartService shop = (IShoppingCartService)iocManager.Resolve<IShoppingCartService>();

            SessionManager.DeleteShoppingCartOneRow(productId);

            gvShoppingCart.DataSource = SessionManager.shoppingCart.shoppingCartLines;
            gvShoppingCart.DataBind();

            Response.Redirect(Request.RawUrl.ToString());
        }

        protected void gvShoppingCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            {
                var units = e.Row.Cells[6].FindControl("quantityList") as DropDownList;
                if (units != null)
                {
                    if (Convert.ToInt32(e.Row.Cells[3].Text) <= 10)
                    {
                        units.SelectedValue = e.Row.Cells[3].Text;
          
                    }
                    else
                    {
                        units.SelectedValue = "1";
                    }
                }
            }
        }

        protected void cbForGift_DataBinding(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            GridViewRow row = c.NamingContainer as GridViewRow;

            long productId = (long)Convert.ToInt32(row.Cells[0].Text);

            for (int i = 0; i < SessionManager.shoppingCart.shoppingCartLines.Count; i++)
            {
                if (SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).productId == productId &&
                    SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).forGift == true)
                    c.Checked = true;
            }
        }

       

        private void LoadGrid2()
        {

            if (SessionManager.shoppingCart.shoppingCartLines.Count == 0)
            {
                lblShoppingCartEmpty.Visible = true;
                lclPrize.Visible = false;
                txtPrizeTotal.Visible = false;
                btnPay.Visible = false;
                return;
            }

            f = SessionManager.shoppingCart.shoppingCartLines;

            gvShoppingCart.DataSource = f;
            gvShoppingCart.DataBind();
        }
    }
}