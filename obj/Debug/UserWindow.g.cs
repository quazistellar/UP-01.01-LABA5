﻿#pragma checksum "..\..\UserWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "43A9E8BF8B366680494FF8BF66E457CAD77C10112E8A369AC170452F6275E292"
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
    /// UserWindow
    /// </summary>
    public partial class UserWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid tovariDG;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid pokupkaDG;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox summa_tbx;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock info1;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buy;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock schet;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buy_done;
        
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
            System.Uri resourceLocater = new System.Uri("/UP_01.01.Laba_5;component/userwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserWindow.xaml"
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
            
            #line 8 "..\..\UserWindow.xaml"
            ((UP_01._01.Laba_5.UserWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tovariDG = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.pokupkaDG = ((System.Windows.Controls.DataGrid)(target));
            
            #line 40 "..\..\UserWindow.xaml"
            this.pokupkaDG.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.pokupkaDG_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.summa_tbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.info1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.buy = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\UserWindow.xaml"
            this.buy.Click += new System.Windows.RoutedEventHandler(this.buy_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.schet = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.buy_done = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\UserWindow.xaml"
            this.buy_done.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 65 "..\..\UserWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

