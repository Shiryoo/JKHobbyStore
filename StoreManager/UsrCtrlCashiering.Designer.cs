﻿using CustomComponents;

namespace StoreManager
{
    partial class UsrCtrlCashiering
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrCtrlCashiering));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.PanelPOS = new System.Windows.Forms.Panel();
            this.PanelPaginationContainer = new Bunifu.UI.WinForms.BunifuPanel();
            this.PanelPagination = new Bunifu.UI.WinForms.BunifuPanel();
            this.LblPaginationText = new Bunifu.UI.WinForms.BunifuLabel();
            this.BtnNextPage = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.BtnPrevPage = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.materialCard1 = new ReaLTaiizor.Controls.MaterialCard();
            this.TbPosSearch = new CustomComponents.CustomMaterialMaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbType = new Bunifu.UI.WinForms.BunifuDropdown();
            this.CmbOrder = new Bunifu.UI.WinForms.BunifuDropdown();
            this.CmbSizes = new Bunifu.UI.WinForms.BunifuDropdown();
            this.PnlCheckout = new System.Windows.Forms.Panel();
            this.BtnCheckout = new ReaLTaiizor.Controls.Button();
            this.LblTaxOutput = new ReaLTaiizor.Controls.HeaderLabel();
            this.LblSubtotalOutput = new ReaLTaiizor.Controls.HeaderLabel();
            this.LblTotalOutput = new ReaLTaiizor.Controls.HeaderLabel();
            this.LblSubtotal = new ReaLTaiizor.Controls.HeaderLabel();
            this.LblTax = new ReaLTaiizor.Controls.HeaderLabel();
            this.LblTotal = new ReaLTaiizor.Controls.HeaderLabel();
            this.PnlProductsPanel = new CustomComponents.ProductsPanel();
            this.PnlOrdersPanel = new CustomComponents.OrdersPanel();
            this.PanelPOS.SuspendLayout();
            this.PanelPaginationContainer.SuspendLayout();
            this.PanelPagination.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.PnlCheckout.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelPOS
            // 
            this.PanelPOS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelPOS.BackColor = System.Drawing.Color.Silver;
            this.PanelPOS.Controls.Add(this.PanelPaginationContainer);
            this.PanelPOS.Controls.Add(this.materialCard1);
            this.PanelPOS.Controls.Add(this.label3);
            this.PanelPOS.Controls.Add(this.label2);
            this.PanelPOS.Controls.Add(this.label1);
            this.PanelPOS.Controls.Add(this.CmbType);
            this.PanelPOS.Controls.Add(this.CmbOrder);
            this.PanelPOS.Controls.Add(this.CmbSizes);
            this.PanelPOS.Controls.Add(this.PnlCheckout);
            this.PanelPOS.Controls.Add(this.PnlProductsPanel);
            this.PanelPOS.Controls.Add(this.PnlOrdersPanel);
            this.PanelPOS.Location = new System.Drawing.Point(0, 0);
            this.PanelPOS.Margin = new System.Windows.Forms.Padding(0);
            this.PanelPOS.Name = "PanelPOS";
            this.PanelPOS.Size = new System.Drawing.Size(1067, 645);
            this.PanelPOS.TabIndex = 1;
            // 
            // PanelPaginationContainer
            // 
            this.PanelPaginationContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelPaginationContainer.BackgroundColor = System.Drawing.Color.Transparent;
            this.PanelPaginationContainer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelPaginationContainer.BackgroundImage")));
            this.PanelPaginationContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelPaginationContainer.BorderColor = System.Drawing.Color.Transparent;
            this.PanelPaginationContainer.BorderRadius = 3;
            this.PanelPaginationContainer.BorderThickness = 1;
            this.PanelPaginationContainer.Controls.Add(this.PanelPagination);
            this.PanelPaginationContainer.Location = new System.Drawing.Point(3, 615);
            this.PanelPaginationContainer.Name = "PanelPaginationContainer";
            this.PanelPaginationContainer.ShowBorders = true;
            this.PanelPaginationContainer.Size = new System.Drawing.Size(663, 27);
            this.PanelPaginationContainer.TabIndex = 10;
            // 
            // PanelPagination
            // 
            this.PanelPagination.BackgroundColor = System.Drawing.Color.Transparent;
            this.PanelPagination.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelPagination.BackgroundImage")));
            this.PanelPagination.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelPagination.BorderColor = System.Drawing.Color.Transparent;
            this.PanelPagination.BorderRadius = 3;
            this.PanelPagination.BorderThickness = 1;
            this.PanelPagination.Controls.Add(this.LblPaginationText);
            this.PanelPagination.Controls.Add(this.BtnNextPage);
            this.PanelPagination.Controls.Add(this.BtnPrevPage);
            this.PanelPagination.Location = new System.Drawing.Point(202, 0);
            this.PanelPagination.Name = "PanelPagination";
            this.PanelPagination.ShowBorders = true;
            this.PanelPagination.Size = new System.Drawing.Size(255, 26);
            this.PanelPagination.TabIndex = 10;
            // 
            // LblPaginationText
            // 
            this.LblPaginationText.AllowParentOverrides = false;
            this.LblPaginationText.AutoEllipsis = false;
            this.LblPaginationText.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblPaginationText.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblPaginationText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPaginationText.Location = new System.Drawing.Point(104, 4);
            this.LblPaginationText.Name = "LblPaginationText";
            this.LblPaginationText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblPaginationText.Size = new System.Drawing.Size(50, 19);
            this.LblPaginationText.TabIndex = 1;
            this.LblPaginationText.Text = "2 of 22";
            this.LblPaginationText.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblPaginationText.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // BtnNextPage
            // 
            this.BtnNextPage.AllowAnimations = true;
            this.BtnNextPage.AllowMouseEffects = true;
            this.BtnNextPage.AllowToggling = false;
            this.BtnNextPage.AnimationSpeed = 200;
            this.BtnNextPage.AutoGenerateColors = false;
            this.BtnNextPage.AutoRoundBorders = false;
            this.BtnNextPage.AutoSizeLeftIcon = true;
            this.BtnNextPage.AutoSizeRightIcon = false;
            this.BtnNextPage.BackColor = System.Drawing.Color.Transparent;
            this.BtnNextPage.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.BtnNextPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnNextPage.BackgroundImage")));
            this.BtnNextPage.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnNextPage.ButtonText = "Next";
            this.BtnNextPage.ButtonTextMarginLeft = 0;
            this.BtnNextPage.ColorContrastOnClick = 45;
            this.BtnNextPage.ColorContrastOnHover = 45;
            this.BtnNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.BtnNextPage.CustomizableEdges = borderEdges3;
            this.BtnNextPage.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnNextPage.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnNextPage.DisabledFillColor = System.Drawing.Color.Empty;
            this.BtnNextPage.DisabledForecolor = System.Drawing.Color.Empty;
            this.BtnNextPage.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnNextPage.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.BtnNextPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnNextPage.ForeColor = System.Drawing.Color.White;
            this.BtnNextPage.IconLeft = null;
            this.BtnNextPage.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNextPage.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNextPage.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.BtnNextPage.IconMarginLeft = 11;
            this.BtnNextPage.IconPadding = 10;
            this.BtnNextPage.IconRight = ((System.Drawing.Image)(resources.GetObject("BtnNextPage.IconRight")));
            this.BtnNextPage.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNextPage.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNextPage.IconRightPadding = new System.Windows.Forms.Padding(0);
            this.BtnNextPage.IconSize = 25;
            this.BtnNextPage.IdleBorderColor = System.Drawing.Color.Empty;
            this.BtnNextPage.IdleBorderRadius = 0;
            this.BtnNextPage.IdleBorderThickness = 0;
            this.BtnNextPage.IdleFillColor = System.Drawing.Color.Empty;
            this.BtnNextPage.IdleIconLeftImage = null;
            this.BtnNextPage.IdleIconRightImage = ((System.Drawing.Image)(resources.GetObject("BtnNextPage.IdleIconRightImage")));
            this.BtnNextPage.IndicateFocus = false;
            this.BtnNextPage.Location = new System.Drawing.Point(181, 0);
            this.BtnNextPage.Name = "BtnNextPage";
            this.BtnNextPage.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnNextPage.OnDisabledState.BorderRadius = 1;
            this.BtnNextPage.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnNextPage.OnDisabledState.BorderThickness = 1;
            this.BtnNextPage.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnNextPage.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnNextPage.OnDisabledState.IconLeftImage = null;
            this.BtnNextPage.OnDisabledState.IconRightImage = null;
            this.BtnNextPage.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnNextPage.onHoverState.BorderRadius = 1;
            this.BtnNextPage.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnNextPage.onHoverState.BorderThickness = 1;
            this.BtnNextPage.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnNextPage.onHoverState.ForeColor = System.Drawing.Color.White;
            this.BtnNextPage.onHoverState.IconLeftImage = null;
            this.BtnNextPage.onHoverState.IconRightImage = null;
            this.BtnNextPage.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnNextPage.OnIdleState.BorderRadius = 1;
            this.BtnNextPage.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnNextPage.OnIdleState.BorderThickness = 1;
            this.BtnNextPage.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnNextPage.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.BtnNextPage.OnIdleState.IconLeftImage = null;
            this.BtnNextPage.OnIdleState.IconRightImage = ((System.Drawing.Image)(resources.GetObject("BtnNextPage.OnIdleState.IconRightImage")));
            this.BtnNextPage.OnPressedState.BorderColor = System.Drawing.Color.Silver;
            this.BtnNextPage.OnPressedState.BorderRadius = 1;
            this.BtnNextPage.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnNextPage.OnPressedState.BorderThickness = 1;
            this.BtnNextPage.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnNextPage.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.BtnNextPage.OnPressedState.IconLeftImage = null;
            this.BtnNextPage.OnPressedState.IconRightImage = null;
            this.BtnNextPage.Size = new System.Drawing.Size(74, 26);
            this.BtnNextPage.TabIndex = 0;
            this.BtnNextPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNextPage.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnNextPage.TextMarginLeft = 0;
            this.BtnNextPage.TextPadding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnNextPage.UseDefaultRadiusAndThickness = true;
            this.BtnNextPage.Click += new System.EventHandler(this.BtnNextPage_Click);
            // 
            // BtnPrevPage
            // 
            this.BtnPrevPage.AllowAnimations = true;
            this.BtnPrevPage.AllowMouseEffects = true;
            this.BtnPrevPage.AllowToggling = false;
            this.BtnPrevPage.AnimationSpeed = 200;
            this.BtnPrevPage.AutoGenerateColors = false;
            this.BtnPrevPage.AutoRoundBorders = false;
            this.BtnPrevPage.AutoSizeLeftIcon = false;
            this.BtnPrevPage.AutoSizeRightIcon = true;
            this.BtnPrevPage.BackColor = System.Drawing.Color.Transparent;
            this.BtnPrevPage.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.BtnPrevPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnPrevPage.BackgroundImage")));
            this.BtnPrevPage.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnPrevPage.ButtonText = "Prev";
            this.BtnPrevPage.ButtonTextMarginLeft = 0;
            this.BtnPrevPage.ColorContrastOnClick = 45;
            this.BtnPrevPage.ColorContrastOnHover = 45;
            this.BtnPrevPage.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.BtnPrevPage.CustomizableEdges = borderEdges4;
            this.BtnPrevPage.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnPrevPage.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnPrevPage.DisabledFillColor = System.Drawing.Color.Empty;
            this.BtnPrevPage.DisabledForecolor = System.Drawing.Color.Empty;
            this.BtnPrevPage.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnPrevPage.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.BtnPrevPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnPrevPage.ForeColor = System.Drawing.Color.White;
            this.BtnPrevPage.IconLeft = ((System.Drawing.Image)(resources.GetObject("BtnPrevPage.IconLeft")));
            this.BtnPrevPage.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPrevPage.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPrevPage.IconLeftPadding = new System.Windows.Forms.Padding(0);
            this.BtnPrevPage.IconMarginLeft = 11;
            this.BtnPrevPage.IconPadding = 0;
            this.BtnPrevPage.IconRight = null;
            this.BtnPrevPage.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPrevPage.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.BtnPrevPage.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.BtnPrevPage.IconSize = 25;
            this.BtnPrevPage.IdleBorderColor = System.Drawing.Color.Empty;
            this.BtnPrevPage.IdleBorderRadius = 0;
            this.BtnPrevPage.IdleBorderThickness = 0;
            this.BtnPrevPage.IdleFillColor = System.Drawing.Color.Empty;
            this.BtnPrevPage.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("BtnPrevPage.IdleIconLeftImage")));
            this.BtnPrevPage.IdleIconRightImage = null;
            this.BtnPrevPage.IndicateFocus = false;
            this.BtnPrevPage.Location = new System.Drawing.Point(0, 0);
            this.BtnPrevPage.Name = "BtnPrevPage";
            this.BtnPrevPage.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnPrevPage.OnDisabledState.BorderRadius = 1;
            this.BtnPrevPage.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnPrevPage.OnDisabledState.BorderThickness = 1;
            this.BtnPrevPage.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnPrevPage.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnPrevPage.OnDisabledState.IconLeftImage = null;
            this.BtnPrevPage.OnDisabledState.IconRightImage = null;
            this.BtnPrevPage.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnPrevPage.onHoverState.BorderRadius = 1;
            this.BtnPrevPage.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnPrevPage.onHoverState.BorderThickness = 1;
            this.BtnPrevPage.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnPrevPage.onHoverState.ForeColor = System.Drawing.Color.White;
            this.BtnPrevPage.onHoverState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("BtnPrevPage.onHoverState.IconLeftImage")));
            this.BtnPrevPage.onHoverState.IconRightImage = null;
            this.BtnPrevPage.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnPrevPage.OnIdleState.BorderRadius = 1;
            this.BtnPrevPage.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnPrevPage.OnIdleState.BorderThickness = 1;
            this.BtnPrevPage.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnPrevPage.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.BtnPrevPage.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("BtnPrevPage.OnIdleState.IconLeftImage")));
            this.BtnPrevPage.OnIdleState.IconRightImage = null;
            this.BtnPrevPage.OnPressedState.BorderColor = System.Drawing.Color.Silver;
            this.BtnPrevPage.OnPressedState.BorderRadius = 1;
            this.BtnPrevPage.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnPrevPage.OnPressedState.BorderThickness = 1;
            this.BtnPrevPage.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnPrevPage.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.BtnPrevPage.OnPressedState.IconLeftImage = null;
            this.BtnPrevPage.OnPressedState.IconRightImage = null;
            this.BtnPrevPage.Size = new System.Drawing.Size(74, 26);
            this.BtnPrevPage.TabIndex = 0;
            this.BtnPrevPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPrevPage.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnPrevPage.TextMarginLeft = 0;
            this.BtnPrevPage.TextPadding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.BtnPrevPage.UseDefaultRadiusAndThickness = true;
            this.BtnPrevPage.Click += new System.EventHandler(this.BtnPrevPage_Click);
            // 
            // materialCard1
            // 
            this.materialCard1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.TbPosSearch);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(7, 7);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(652, 47);
            this.materialCard1.TabIndex = 9;
            // 
            // TbPosSearch
            // 
            this.TbPosSearch.AllowPromptAsInput = true;
            this.TbPosSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbPosSearch.AnimateReadOnly = false;
            this.TbPosSearch.AsciiOnly = false;
            this.TbPosSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TbPosSearch.BeepOnError = false;
            this.TbPosSearch.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.TbPosSearch.Depth = 0;
            this.TbPosSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TbPosSearch.HidePromptOnLeave = false;
            this.TbPosSearch.HideSelection = true;
            this.TbPosSearch.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.TbPosSearch.LeadingIcon = global::StoreManager.Properties.Resources.search_icon;
            this.TbPosSearch.Location = new System.Drawing.Point(0, -1);
            this.TbPosSearch.Margin = new System.Windows.Forms.Padding(0);
            this.TbPosSearch.Mask = "";
            this.TbPosSearch.MaxLength = 32767;
            this.TbPosSearch.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.TbPosSearch.Name = "TbPosSearch";
            this.TbPosSearch.PasswordChar = '\0';
            this.TbPosSearch.PrefixSuffixText = null;
            this.TbPosSearch.PromptChar = '_';
            this.TbPosSearch.ReadOnly = false;
            this.TbPosSearch.RejectInputOnFirstFailure = false;
            this.TbPosSearch.ResetOnPrompt = true;
            this.TbPosSearch.ResetOnSpace = true;
            this.TbPosSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TbPosSearch.SelectedText = "";
            this.TbPosSearch.SelectionLength = 0;
            this.TbPosSearch.SelectionStart = 0;
            this.TbPosSearch.ShortcutsEnabled = true;
            this.TbPosSearch.Size = new System.Drawing.Size(655, 48);
            this.TbPosSearch.SkipLiterals = true;
            this.TbPosSearch.TabIndex = 0;
            this.TbPosSearch.TabStop = false;
            this.TbPosSearch.Text = "Search";
            this.TbPosSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TbPosSearch.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.TbPosSearch.TrailingIcon = null;
            this.TbPosSearch.UnderlineColor = System.Drawing.Color.Black;
            this.TbPosSearch.UseSystemPasswordChar = false;
            this.TbPosSearch.ValidatingType = null;
            this.TbPosSearch.Enter += new System.EventHandler(this.TbPosSearch_Enter);
            this.TbPosSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbPosSearch_KeyPress);
            this.TbPosSearch.Leave += new System.EventHandler(this.TbPosSearch_Leave);
            this.TbPosSearch.TextChanged += new System.EventHandler(this.TbPosSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(923, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "ORDER:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(796, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "TYPE:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(669, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "SIZE:";
            // 
            // CmbType
            // 
            this.CmbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbType.BackColor = System.Drawing.Color.Transparent;
            this.CmbType.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.CmbType.BorderColor = System.Drawing.Color.Silver;
            this.CmbType.BorderRadius = 1;
            this.CmbType.Color = System.Drawing.Color.Silver;
            this.CmbType.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.CmbType.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.CmbType.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.CmbType.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.CmbType.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CmbType.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.CmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbType.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.CmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbType.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.CmbType.FillDropDown = true;
            this.CmbType.FillIndicator = false;
            this.CmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbType.ForeColor = System.Drawing.Color.White;
            this.CmbType.FormattingEnabled = true;
            this.CmbType.Icon = null;
            this.CmbType.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.CmbType.IndicatorColor = System.Drawing.Color.DarkGray;
            this.CmbType.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.CmbType.IndicatorThickness = 2;
            this.CmbType.IntegralHeight = false;
            this.CmbType.IsDropdownOpened = false;
            this.CmbType.ItemBackColor = System.Drawing.Color.WhiteSmoke;
            this.CmbType.ItemBorderColor = System.Drawing.Color.White;
            this.CmbType.ItemForeColor = System.Drawing.Color.Black;
            this.CmbType.ItemHeight = 26;
            this.CmbType.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.CmbType.ItemHighLightForeColor = System.Drawing.Color.White;
            this.CmbType.Items.AddRange(new object[] {
            ""});
            this.CmbType.ItemTopMargin = 3;
            this.CmbType.Location = new System.Drawing.Point(799, 31);
            this.CmbType.Name = "CmbType";
            this.CmbType.Size = new System.Drawing.Size(121, 32);
            this.CmbType.TabIndex = 5;
            this.CmbType.Text = null;
            this.CmbType.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.CmbType.TextLeftMargin = 5;
            this.CmbType.SelectedIndexChanged += new System.EventHandler(this.CmbType_SelectedIndexChanged);
            // 
            // CmbOrder
            // 
            this.CmbOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbOrder.BackColor = System.Drawing.Color.Transparent;
            this.CmbOrder.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.CmbOrder.BorderColor = System.Drawing.Color.Silver;
            this.CmbOrder.BorderRadius = 1;
            this.CmbOrder.Color = System.Drawing.Color.Silver;
            this.CmbOrder.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.CmbOrder.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.CmbOrder.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.CmbOrder.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.CmbOrder.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CmbOrder.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.CmbOrder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbOrder.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.CmbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbOrder.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.CmbOrder.FillDropDown = true;
            this.CmbOrder.FillIndicator = false;
            this.CmbOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbOrder.ForeColor = System.Drawing.Color.White;
            this.CmbOrder.FormattingEnabled = true;
            this.CmbOrder.Icon = null;
            this.CmbOrder.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.CmbOrder.IndicatorColor = System.Drawing.Color.DarkGray;
            this.CmbOrder.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.CmbOrder.IndicatorThickness = 2;
            this.CmbOrder.IntegralHeight = false;
            this.CmbOrder.IsDropdownOpened = false;
            this.CmbOrder.ItemBackColor = System.Drawing.Color.WhiteSmoke;
            this.CmbOrder.ItemBorderColor = System.Drawing.Color.White;
            this.CmbOrder.ItemForeColor = System.Drawing.Color.Black;
            this.CmbOrder.ItemHeight = 26;
            this.CmbOrder.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.CmbOrder.ItemHighLightForeColor = System.Drawing.Color.White;
            this.CmbOrder.Items.AddRange(new object[] {
            "Alphabetical",
            "Low_to_High",
            "High_to_Low"});
            this.CmbOrder.ItemTopMargin = 3;
            this.CmbOrder.Location = new System.Drawing.Point(926, 31);
            this.CmbOrder.Name = "CmbOrder";
            this.CmbOrder.Size = new System.Drawing.Size(121, 32);
            this.CmbOrder.TabIndex = 6;
            this.CmbOrder.Text = null;
            this.CmbOrder.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.CmbOrder.TextLeftMargin = 5;
            this.CmbOrder.SelectedIndexChanged += new System.EventHandler(this.CmbOrder_SelectedIndexChanged);
            // 
            // CmbSizes
            // 
            this.CmbSizes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSizes.BackColor = System.Drawing.Color.Transparent;
            this.CmbSizes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.CmbSizes.BorderColor = System.Drawing.Color.Silver;
            this.CmbSizes.BorderRadius = 1;
            this.CmbSizes.Color = System.Drawing.Color.Silver;
            this.CmbSizes.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.CmbSizes.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.CmbSizes.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.CmbSizes.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.CmbSizes.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CmbSizes.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.CmbSizes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbSizes.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.CmbSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSizes.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.CmbSizes.FillDropDown = true;
            this.CmbSizes.FillIndicator = false;
            this.CmbSizes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbSizes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSizes.ForeColor = System.Drawing.Color.White;
            this.CmbSizes.FormattingEnabled = true;
            this.CmbSizes.Icon = null;
            this.CmbSizes.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.CmbSizes.IndicatorColor = System.Drawing.Color.DarkGray;
            this.CmbSizes.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.CmbSizes.IndicatorThickness = 2;
            this.CmbSizes.IntegralHeight = false;
            this.CmbSizes.IsDropdownOpened = false;
            this.CmbSizes.ItemBackColor = System.Drawing.Color.WhiteSmoke;
            this.CmbSizes.ItemBorderColor = System.Drawing.Color.White;
            this.CmbSizes.ItemForeColor = System.Drawing.Color.Black;
            this.CmbSizes.ItemHeight = 26;
            this.CmbSizes.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.CmbSizes.ItemHighLightForeColor = System.Drawing.Color.White;
            this.CmbSizes.Items.AddRange(new object[] {
            ""});
            this.CmbSizes.ItemTopMargin = 3;
            this.CmbSizes.Location = new System.Drawing.Point(672, 31);
            this.CmbSizes.Name = "CmbSizes";
            this.CmbSizes.Size = new System.Drawing.Size(121, 32);
            this.CmbSizes.TabIndex = 5;
            this.CmbSizes.Text = null;
            this.CmbSizes.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.CmbSizes.TextLeftMargin = 5;
            this.CmbSizes.SelectedIndexChanged += new System.EventHandler(this.CmbSizes_SelectedIndexChanged);
            // 
            // PnlCheckout
            // 
            this.PnlCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlCheckout.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnlCheckout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlCheckout.Controls.Add(this.BtnCheckout);
            this.PnlCheckout.Controls.Add(this.LblTaxOutput);
            this.PnlCheckout.Controls.Add(this.LblSubtotalOutput);
            this.PnlCheckout.Controls.Add(this.LblTotalOutput);
            this.PnlCheckout.Controls.Add(this.LblSubtotal);
            this.PnlCheckout.Controls.Add(this.LblTax);
            this.PnlCheckout.Controls.Add(this.LblTotal);
            this.PnlCheckout.Location = new System.Drawing.Point(672, 427);
            this.PnlCheckout.Name = "PnlCheckout";
            this.PnlCheckout.Size = new System.Drawing.Size(392, 215);
            this.PnlCheckout.TabIndex = 0;
            // 
            // BtnCheckout
            // 
            this.BtnCheckout.BackColor = System.Drawing.Color.Transparent;
            this.BtnCheckout.BorderColor = System.Drawing.Color.White;
            this.BtnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCheckout.EnteredBorderColor = System.Drawing.Color.Black;
            this.BtnCheckout.EnteredColor = System.Drawing.Color.Black;
            this.BtnCheckout.Font = new System.Drawing.Font("Arial Rounded MT Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCheckout.Image = null;
            this.BtnCheckout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCheckout.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.BtnCheckout.Location = new System.Drawing.Point(12, 106);
            this.BtnCheckout.Name = "BtnCheckout";
            this.BtnCheckout.PressedBorderColor = System.Drawing.Color.Gray;
            this.BtnCheckout.PressedColor = System.Drawing.Color.Black;
            this.BtnCheckout.Size = new System.Drawing.Size(363, 97);
            this.BtnCheckout.TabIndex = 1;
            this.BtnCheckout.Text = "CHECKOUT";
            this.BtnCheckout.TextAlignment = System.Drawing.StringAlignment.Center;
            this.BtnCheckout.Click += new System.EventHandler(this.BtnCheckout_Click);
            // 
            // LblTaxOutput
            // 
            this.LblTaxOutput.BackColor = System.Drawing.Color.Transparent;
            this.LblTaxOutput.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTaxOutput.ForeColor = System.Drawing.Color.Black;
            this.LblTaxOutput.Location = new System.Drawing.Point(227, 71);
            this.LblTaxOutput.Name = "LblTaxOutput";
            this.LblTaxOutput.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblTaxOutput.Size = new System.Drawing.Size(143, 24);
            this.LblTaxOutput.TabIndex = 0;
            this.LblTaxOutput.Text = "0";
            // 
            // LblSubtotalOutput
            // 
            this.LblSubtotalOutput.BackColor = System.Drawing.Color.Transparent;
            this.LblSubtotalOutput.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSubtotalOutput.ForeColor = System.Drawing.Color.Black;
            this.LblSubtotalOutput.Location = new System.Drawing.Point(227, 48);
            this.LblSubtotalOutput.Name = "LblSubtotalOutput";
            this.LblSubtotalOutput.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblSubtotalOutput.Size = new System.Drawing.Size(143, 24);
            this.LblSubtotalOutput.TabIndex = 0;
            this.LblSubtotalOutput.Text = "0";
            // 
            // LblTotalOutput
            // 
            this.LblTotalOutput.BackColor = System.Drawing.Color.Transparent;
            this.LblTotalOutput.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalOutput.ForeColor = System.Drawing.Color.Black;
            this.LblTotalOutput.Location = new System.Drawing.Point(227, 14);
            this.LblTotalOutput.Name = "LblTotalOutput";
            this.LblTotalOutput.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblTotalOutput.Size = new System.Drawing.Size(143, 24);
            this.LblTotalOutput.TabIndex = 0;
            this.LblTotalOutput.Text = "0";
            // 
            // LblSubtotal
            // 
            this.LblSubtotal.AutoSize = true;
            this.LblSubtotal.BackColor = System.Drawing.Color.Transparent;
            this.LblSubtotal.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSubtotal.ForeColor = System.Drawing.Color.Black;
            this.LblSubtotal.Location = new System.Drawing.Point(14, 48);
            this.LblSubtotal.Name = "LblSubtotal";
            this.LblSubtotal.Size = new System.Drawing.Size(79, 22);
            this.LblSubtotal.TabIndex = 0;
            this.LblSubtotal.Text = "Subtotal";
            // 
            // LblTax
            // 
            this.LblTax.AutoSize = true;
            this.LblTax.BackColor = System.Drawing.Color.Transparent;
            this.LblTax.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTax.ForeColor = System.Drawing.Color.Black;
            this.LblTax.Location = new System.Drawing.Point(14, 71);
            this.LblTax.Name = "LblTax";
            this.LblTax.Size = new System.Drawing.Size(46, 22);
            this.LblTax.TabIndex = 0;
            this.LblTax.Text = "VAT";
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.BackColor = System.Drawing.Color.Transparent;
            this.LblTotal.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.ForeColor = System.Drawing.Color.Black;
            this.LblTotal.Location = new System.Drawing.Point(14, 14);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(78, 24);
            this.LblTotal.TabIndex = 0;
            this.LblTotal.Text = "TOTAL";
            // 
            // PnlProductsPanel
            // 
            this.PnlProductsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlProductsPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnlProductsPanel.Location = new System.Drawing.Point(3, 68);
            this.PnlProductsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.PnlProductsPanel.Name = "PnlProductsPanel";
            this.PnlProductsPanel.Size = new System.Drawing.Size(663, 544);
            this.PnlProductsPanel.TabIndex = 0;
            // 
            // PnlOrdersPanel
            // 
            this.PnlOrdersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlOrdersPanel.AutoScroll = true;
            this.PnlOrdersPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnlOrdersPanel.DeletedOrder = null;
            this.PnlOrdersPanel.Location = new System.Drawing.Point(672, 68);
            this.PnlOrdersPanel.Name = "PnlOrdersPanel";
            this.PnlOrdersPanel.Size = new System.Drawing.Size(392, 353);
            this.PnlOrdersPanel.TabIndex = 0;
            this.PnlOrdersPanel.TaxRate = 0D;
            // 
            // UsrCtrlCashiering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelPOS);
            this.Name = "UsrCtrlCashiering";
            this.Size = new System.Drawing.Size(1067, 645);
            this.PanelPOS.ResumeLayout(false);
            this.PanelPOS.PerformLayout();
            this.PanelPaginationContainer.ResumeLayout(false);
            this.PanelPagination.ResumeLayout(false);
            this.PanelPagination.PerformLayout();
            this.materialCard1.ResumeLayout(false);
            this.PnlCheckout.ResumeLayout(false);
            this.PnlCheckout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelPOS;
        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private CustomComponents.CustomMaterialMaskedTextBox TbPosSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuDropdown CmbType;
        private Bunifu.UI.WinForms.BunifuDropdown CmbOrder;
        private Bunifu.UI.WinForms.BunifuDropdown CmbSizes;
        private System.Windows.Forms.Panel PnlCheckout;
        private ReaLTaiizor.Controls.Button BtnCheckout;
        private ReaLTaiizor.Controls.HeaderLabel LblTaxOutput;
        private ReaLTaiizor.Controls.HeaderLabel LblSubtotalOutput;
        private ReaLTaiizor.Controls.HeaderLabel LblTotalOutput;
        private ReaLTaiizor.Controls.HeaderLabel LblSubtotal;
        private ReaLTaiizor.Controls.HeaderLabel LblTax;
        private ReaLTaiizor.Controls.HeaderLabel LblTotal;
        private CustomComponents.ProductsPanel PnlProductsPanel;
        private CustomComponents.OrdersPanel PnlOrdersPanel;
        private Bunifu.UI.WinForms.BunifuPanel PanelPagination;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton BtnPrevPage;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton BtnNextPage;
        private Bunifu.UI.WinForms.BunifuPanel PanelPaginationContainer;
        private Bunifu.UI.WinForms.BunifuLabel LblPaginationText;
    }
}
