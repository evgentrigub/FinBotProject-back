﻿#pragma checksum "..\..\..\..\..\Market\Servers\Transaq\ChangeTransaqPassword.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DB42A0DD1C4EA2542CE0DFD1DD29B782D57D525200383E060FF92C486C0305D1"
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
using System.Windows.Forms.Integration;
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


namespace OsEngine.Market.Servers.Transaq {
    
    
    /// <summary>
    /// ChangeTransaqPassword
    /// </summary>
    public partial class ChangeTransaqPassword : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\..\Market\Servers\Transaq\ChangeTransaqPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Rectangle;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\Market\Servers\Transaq\ChangeTransaqPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextInfo;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\Market\Servers\Transaq\ChangeTransaqPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewPassword;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\Market\Servers\Transaq\ChangeTransaqPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OldPassword;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\Market\Servers\Transaq\ChangeTransaqPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAccept;
        
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
            System.Uri resourceLocater = new System.Uri("/OsEngine;component/market/servers/transaq/changetransaqpassword.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Market\Servers\Transaq\ChangeTransaqPassword.xaml"
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
            this.Rectangle = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 2:
            this.TextInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.NewPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.OldPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ButtonAccept = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\..\Market\Servers\Transaq\ChangeTransaqPassword.xaml"
            this.ButtonAccept.Click += new System.Windows.RoutedEventHandler(this.ButtonAccept_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

