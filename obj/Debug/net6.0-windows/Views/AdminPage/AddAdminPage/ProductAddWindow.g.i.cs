﻿#pragma checksum "..\..\..\..\..\..\Views\AdminPage\AddAdminPage\ProductAddWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5A8CAA171921E38D469F1663540517F87442FC37"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CurcaNaCore.Views.AdminPage.AddAdminPage;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CurcaNaCore.Views.AdminPage.AddAdminPage {
    
    
    /// <summary>
    /// ProductAddWindow
    /// </summary>
    public partial class ProductAddWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\..\..\Views\AdminPage\AddAdminPage\ProductAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxbNameOfProduct;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\..\Views\AdminPage\AddAdminPage\ProductAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbBrand;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\..\Views\AdminPage\AddAdminPage\ProductAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbUnit;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\..\Views\AdminPage\AddAdminPage\ProductAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxbPrice;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\..\Views\AdminPage\AddAdminPage\ProductAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAddProduct;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CurcaNaCore;component/views/adminpage/addadminpage/productaddwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Views\AdminPage\AddAdminPage\ProductAddWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TxbNameOfProduct = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.CmbBrand = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.CmbUnit = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.TxbPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.BtnAddProduct = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\..\..\Views\AdminPage\AddAdminPage\ProductAddWindow.xaml"
            this.BtnAddProduct.Click += new System.Windows.RoutedEventHandler(this.BtnAddProduct_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

