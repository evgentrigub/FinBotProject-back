﻿#pragma checksum "..\..\..\Logging\ServerSmsUi.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8A19CE52C40BDD9DC613C744710993E3EF272EE56373F4EDA557A59F0F49A413"
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


namespace OsEngine.Logging {
    
    
    /// <summary>
    /// ServerSmsUi
    /// </summary>
    public partial class ServerSmsUi : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\Logging\ServerSmsUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAccept;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\Logging\ServerSmsUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxMyLogin;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\Logging\ServerSmsUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPassword;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Logging\ServerSmsUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxFones;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Logging\ServerSmsUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label15;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Logging\ServerSmsUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label12;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Logging\ServerSmsUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label14;
        
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
            System.Uri resourceLocater = new System.Uri("/OsEngine;component/logging/serversmsui.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Logging\ServerSmsUi.xaml"
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
            this.ButtonAccept = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\..\Logging\ServerSmsUi.xaml"
            this.ButtonAccept.Click += new System.Windows.RoutedEventHandler(this.buttonAccept_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBoxMyLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TextBoxPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TextBoxFones = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Label15 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.Label12 = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Label14 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

