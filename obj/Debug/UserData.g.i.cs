﻿#pragma checksum "..\..\UserData.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4896685038F44BBBA5CC3A040DB53296367AC00292918FE6DB65F00CFE34E4E8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using UP_01._01.Laba_5;


namespace UP_01._01.Laba_5 {
    
    
    /// <summary>
    /// UserData
    /// </summary>
    public partial class UserData : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\UserData.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid container_pages;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\UserData.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox write_log;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\UserData.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox write_pass;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\UserData.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox role_cbx;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\UserData.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\UserData.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button edit;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\UserData.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button del;
        
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
            System.Uri resourceLocater = new System.Uri("/UP_01.01.Laba_5;component/userdata.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserData.xaml"
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
            
            #line 9 "..\..\UserData.xaml"
            ((UP_01._01.Laba_5.UserData)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.container_pages = ((System.Windows.Controls.DataGrid)(target));
            
            #line 20 "..\..\UserData.xaml"
            this.container_pages.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.container_pages_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.write_log = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.write_pass = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.role_cbx = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.add = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\UserData.xaml"
            this.add.Click += new System.Windows.RoutedEventHandler(this.add_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.edit = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\UserData.xaml"
            this.edit.Click += new System.Windows.RoutedEventHandler(this.edit_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.del = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\UserData.xaml"
            this.del.Click += new System.Windows.RoutedEventHandler(this.del_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
