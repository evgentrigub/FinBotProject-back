<<<<<<< Updated upstream
﻿#pragma checksum "..\..\..\..\OsTrader\RiskManager\RiskManagerUi.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4BC1AE1964A290E089BB4C66B00106F48C1F0D9B21B82B158DADC264E0A15408"
=======
﻿#pragma checksum "..\..\..\..\OsTrader\RiskManager\RiskManagerUi.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DC1E7D5942AE2316000EF4922DF20422ED974206"
>>>>>>> Stashed changes
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


namespace OsEngine.OsTrader.RiskManager {
    
    
    /// <summary>
    /// RiskManagerUi
    /// </summary>
    public partial class RiskManagerUi : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\OsTrader\RiskManager\RiskManagerUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAccept;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\OsTrader\RiskManager\RiskManagerUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBoxIsOn;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\OsTrader\RiskManager\RiskManagerUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxOpenMaxDd;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\OsTrader\RiskManager\RiskManagerUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelMaxRisk;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\OsTrader\RiskManager\RiskManagerUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxReaction;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\OsTrader\RiskManager\RiskManagerUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelMaxLossReactioin;
        
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
            System.Uri resourceLocater = new System.Uri("/OsEngine;component/ostrader/riskmanager/riskmanagerui.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\OsTrader\RiskManager\RiskManagerUi.xaml"
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
            
            #line 13 "..\..\..\..\OsTrader\RiskManager\RiskManagerUi.xaml"
            this.ButtonAccept.Click += new System.Windows.RoutedEventHandler(this.ButtonAccept_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CheckBoxIsOn = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 3:
            this.TextBoxOpenMaxDd = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.LabelMaxRisk = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.ComboBoxReaction = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.LabelMaxLossReactioin = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

