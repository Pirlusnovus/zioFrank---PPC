﻿#pragma checksum "..\..\..\UT\UT_Form.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D3AF5F31009B8679B1EC3309DCA7AE89"
//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

using Loaders;
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
    /// UT_Form
    /// </summary>
    public partial class UT_Form : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\UT\UT_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TitleWin;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\UT\UT_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Exit;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\UT\UT_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UT_FileName;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UT\UT_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FireFunction;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\UT\UT_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Comment;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\UT\UT_Form.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border MyLoader;
        
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
            System.Uri resourceLocater = new System.Uri("/PPC;component/ut/ut_form.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UT\UT_Form.xaml"
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
            
            #line 27 "..\..\..\UT\UT_Form.xaml"
            this.TitleWin.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Mover);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Exit = ((System.Windows.Controls.TextBlock)(target));
            
            #line 28 "..\..\..\UT\UT_Form.xaml"
            this.Exit.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Quit);
            
            #line default
            #line hidden
            return;
            case 3:
            this.UT_FileName = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\UT\UT_Form.xaml"
            this.UT_FileName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.UT_FileName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FireFunction = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\UT\UT_Form.xaml"
            this.FireFunction.Click += new System.Windows.RoutedEventHandler(this.UploadTreeButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Comment = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.MyLoader = ((System.Windows.Controls.Border)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

