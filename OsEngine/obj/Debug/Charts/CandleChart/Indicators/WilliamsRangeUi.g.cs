﻿#pragma checksum "..\..\..\..\..\Charts\CandleChart\Indicators\WilliamsRangeUi.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CEC567672999842B3616384BF7521F5D9E3D2450EC1F8A2DB7049A6C893523DD"
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


namespace OsEngine.Charts.CandleChart.Indicators {
    
    
    /// <summary>
    /// WilliamsRangeUi
    /// </summary>
    public partial class WilliamsRangeUi : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\..\Charts\CandleChart\Indicators\WilliamsRangeUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAccept;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\..\..\Charts\CandleChart\Indicators\WilliamsRangeUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxLenght;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\..\..\Charts\CandleChart\Indicators\WilliamsRangeUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelIndicatorLongPeriod;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\..\..\Charts\CandleChart\Indicators\WilliamsRangeUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBoxPaintOnOff;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\..\Charts\CandleChart\Indicators\WilliamsRangeUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonColor;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\..\Charts\CandleChart\Indicators\WilliamsRangeUi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost HostColorBase;
        
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
            System.Uri resourceLocater = new System.Uri("/OsEngine;component/charts/candlechart/indicators/williamsrangeui.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Charts\CandleChart\Indicators\WilliamsRangeUi.xaml"
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
            
            #line 7 "..\..\..\..\..\Charts\CandleChart\Indicators\WilliamsRangeUi.xaml"
            this.ButtonAccept.Click += new System.Windows.RoutedEventHandler(this.ButtonAccept_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBoxLenght = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.LabelIndicatorLongPeriod = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.CheckBoxPaintOnOff = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.ButtonColor = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\..\Charts\CandleChart\Indicators\WilliamsRangeUi.xaml"
            this.ButtonColor.Click += new System.Windows.RoutedEventHandler(this.ButtonColor_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.HostColorBase = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

