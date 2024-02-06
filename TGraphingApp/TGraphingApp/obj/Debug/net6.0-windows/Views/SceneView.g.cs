﻿#pragma checksum "..\..\..\..\Views\SceneView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6299E1D5F462AB87C03D9AC65C2BA27C3DF42437"
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
using TGraphingApp.Views;


namespace TGraphingApp.Views {
    
    
    /// <summary>
    /// SceneView
    /// </summary>
    public partial class SceneView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\Views\SceneView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SceneName;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Views\SceneView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox XStart;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Views\SceneView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox XEnd;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Views\SceneView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox YStart;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\Views\SceneView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox YEnd;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Views\SceneView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TGraphingApp.Components.InstanceList ViewInstances;
        
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
            System.Uri resourceLocater = new System.Uri("/TGraphingApp;component/views/sceneview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\SceneView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.SceneName = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\..\Views\SceneView.xaml"
            this.SceneName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.DoNoteChange_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.XStart = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\..\Views\SceneView.xaml"
            this.XStart.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.DoNoteChange_TextChanged);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\..\Views\SceneView.xaml"
            this.XStart.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.AllowNumbersOnly_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.XEnd = ((System.Windows.Controls.TextBox)(target));
            
            #line 48 "..\..\..\..\Views\SceneView.xaml"
            this.XEnd.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.DoNoteChange_TextChanged);
            
            #line default
            #line hidden
            
            #line 48 "..\..\..\..\Views\SceneView.xaml"
            this.XEnd.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.AllowNumbersOnly_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.YStart = ((System.Windows.Controls.TextBox)(target));
            
            #line 65 "..\..\..\..\Views\SceneView.xaml"
            this.YStart.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.DoNoteChange_TextChanged);
            
            #line default
            #line hidden
            
            #line 65 "..\..\..\..\Views\SceneView.xaml"
            this.YStart.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.AllowNumbersOnly_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.YEnd = ((System.Windows.Controls.TextBox)(target));
            
            #line 75 "..\..\..\..\Views\SceneView.xaml"
            this.YEnd.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.DoNoteChange_TextChanged);
            
            #line default
            #line hidden
            
            #line 75 "..\..\..\..\Views\SceneView.xaml"
            this.YEnd.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.AllowNumbersOnly_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ViewInstances = ((TGraphingApp.Components.InstanceList)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

