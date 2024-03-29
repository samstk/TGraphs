﻿#pragma checksum "..\..\..\..\Components\Timebar.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A16145D7502924493D4E9FB5C05250218831C029"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using System.Windows.Controls.Ribbon;
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
using TGraphingApp.Components;


namespace TGraphingApp.Components {
    
    
    /// <summary>
    /// Timebar
    /// </summary>
    public partial class Timebar : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Components\Timebar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PlayPauseButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Components\Timebar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar PlayProgress;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Components\Timebar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TMin;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Components\Timebar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TStep;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Components\Timebar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TRenderStep;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Components\Timebar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TMax;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TGraphingApp;component/components/timebar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Components\Timebar.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.PlayPauseButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\Components\Timebar.xaml"
            this.PlayPauseButton.Click += new System.Windows.RoutedEventHandler(this.PlayPauseButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PlayProgress = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 3:
            this.TMin = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\..\Components\Timebar.xaml"
            this.TMin.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.DoNoteChange_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TStep = ((System.Windows.Controls.TextBox)(target));
            
            #line 47 "..\..\..\..\Components\Timebar.xaml"
            this.TStep.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.DoNoteChange_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TRenderStep = ((System.Windows.Controls.TextBox)(target));
            
            #line 57 "..\..\..\..\Components\Timebar.xaml"
            this.TRenderStep.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.DoNoteChange_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TMax = ((System.Windows.Controls.TextBox)(target));
            
            #line 67 "..\..\..\..\Components\Timebar.xaml"
            this.TMax.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.DoNoteChange_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

