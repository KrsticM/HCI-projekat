﻿#pragma checksum "..\..\WindowEtiketa.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ECAA93EF9026611B97B4DC5048F5B793666283F2"
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
using _4._2BVproject;


namespace _4._2BVproject {
    
    
    /// <summary>
    /// WindowEtiketa
    /// </summary>
    public partial class WindowEtiketa : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\WindowEtiketa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgrMainTip;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\WindowEtiketa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Izmeni;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\WindowEtiketa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pomocDugme;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\WindowEtiketa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox xColor;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\WindowEtiketa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox xOznaka;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\WindowEtiketa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox xOpis;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\WindowEtiketa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Pretrazi;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\WindowEtiketa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ponisti;
        
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
            System.Uri resourceLocater = new System.Uri("/4.2BVproject;component/windowetiketa.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowEtiketa.xaml"
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
            this.dgrMainTip = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            
            #line 68 "..\..\WindowEtiketa.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.dodajAkcija);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Izmeni = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\WindowEtiketa.xaml"
            this.Izmeni.Click += new System.Windows.RoutedEventHandler(this.Izmeni_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 82 "..\..\WindowEtiketa.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.obrisiAkcija);
            
            #line default
            #line hidden
            return;
            case 5:
            this.pomocDugme = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\WindowEtiketa.xaml"
            this.pomocDugme.Click += new System.Windows.RoutedEventHandler(this.pomocDugme_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.xColor = ((System.Windows.Controls.ComboBox)(target));
            
            #line 101 "..\..\WindowEtiketa.xaml"
            this.xColor.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.xColor_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.xOznaka = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.xOpis = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.Pretrazi = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\WindowEtiketa.xaml"
            this.Pretrazi.Click += new System.Windows.RoutedEventHandler(this.Pretrazi_Click_1);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Ponisti = ((System.Windows.Controls.Button)(target));
            
            #line 124 "..\..\WindowEtiketa.xaml"
            this.Ponisti.Click += new System.Windows.RoutedEventHandler(this.Ponisti_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

