﻿#pragma checksum "..\..\EditContact.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B258E6F53ED4D9DF01C2EDA20948EBE7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace IW5_proj1_GUI {
    
    
    /// <summary>
    /// EditContact
    /// </summary>
    public partial class EditContact : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\EditContact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditEmail;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\EditContact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClear;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\EditContact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxEditEmail;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\EditContact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxEditPhone;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\EditContact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label EmailValidationLabel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\EditContact.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PhoneValidationLabel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/IW5_proj1_GUI;component/editcontact.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditContact.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnEditEmail = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\EditContact.xaml"
            this.btnEditEmail.Click += new System.Windows.RoutedEventHandler(this.btnEditEmail_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnClear = ((System.Windows.Controls.Button)(target));
            
            #line 8 "..\..\EditContact.xaml"
            this.btnClear.Click += new System.Windows.RoutedEventHandler(this.ClearButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtBoxEditEmail = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\EditContact.xaml"
            this.txtBoxEditEmail.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.validateEmail);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtBoxEditPhone = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\EditContact.xaml"
            this.txtBoxEditPhone.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.validatePhone);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EmailValidationLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.PhoneValidationLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

