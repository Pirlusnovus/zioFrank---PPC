﻿#pragma checksum "..\..\PPC_FeedBack.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "11DA38E336ED2D52B8915DE21C2FFCB6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Themes;
using PPC;
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


namespace PPC {
    
    
    /// <summary>
    /// PPC_FeedBack
    /// </summary>
    public partial class PPC_FeedBack : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\PPC_FeedBack.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TitleWin;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\PPC_FeedBack.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\PPC_FeedBack.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Lable_PPC;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\PPC_FeedBack.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back_H;
        
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
            System.Uri resourceLocater = new System.Uri("/PPC;component/ppc_feedback.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PPC_FeedBack.xaml"
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
            this.TitleWin = ((System.Windows.Controls.TextBlock)(target));
            
            #line 17 "..\..\PPC_FeedBack.xaml"
            this.TitleWin.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Mover);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Lable_PPC = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Back_H = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\PPC_FeedBack.xaml"
            this.Back_H.Click += new System.Windows.RoutedEventHandler(this.Ok);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

