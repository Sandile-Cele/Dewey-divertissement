﻿#pragma checksum "..\..\..\ReplacingBooks.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47524F3180C041459D4841D03ECA9384F18BCCA1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Dewey_divertissement;
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


namespace Dewey_divertissement {
    
    
    /// <summary>
    /// ReplacingBooks
    /// </summary>
    public partial class ReplacingBooks : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\ReplacingBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbCalls;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\ReplacingBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDone;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\ReplacingBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewCalls;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\ReplacingBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUndo;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\ReplacingBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbCallsRandom;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\ReplacingBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTime;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\ReplacingBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar pbNextArchivement;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\ReplacingBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbPt;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\ReplacingBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAchievements;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Dewey divertissement;component/replacingbooks.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ReplacingBooks.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\ReplacingBooks.xaml"
            ((Dewey_divertissement.ReplacingBooks)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\ReplacingBooks.xaml"
            ((Dewey_divertissement.ReplacingBooks)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lbCalls = ((System.Windows.Controls.ListBox)(target));
            
            #line 14 "..\..\..\ReplacingBooks.xaml"
            this.lbCalls.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.lbCalls_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnDone = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\ReplacingBooks.xaml"
            this.btnDone.Click += new System.Windows.RoutedEventHandler(this.btnDone_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnNewCalls = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\ReplacingBooks.xaml"
            this.btnNewCalls.Click += new System.Windows.RoutedEventHandler(this.btnNewCalls_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnUndo = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\ReplacingBooks.xaml"
            this.btnUndo.Click += new System.Windows.RoutedEventHandler(this.btnUndo_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lbCallsRandom = ((System.Windows.Controls.ListBox)(target));
            
            #line 24 "..\..\..\ReplacingBooks.xaml"
            this.lbCallsRandom.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.lbCallsRandom_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\ReplacingBooks.xaml"
            this.lbCallsRandom.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbCallsRandom_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 28 "..\..\..\ReplacingBooks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lbTime = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.pbNextArchivement = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 10:
            this.lbPt = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.btnAchievements = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\ReplacingBooks.xaml"
            this.btnAchievements.Click += new System.Windows.RoutedEventHandler(this.btnAchievements_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

