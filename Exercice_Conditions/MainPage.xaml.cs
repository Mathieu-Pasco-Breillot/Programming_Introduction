using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Programming_Introduction.Model;
using Programming_Introduction.Transverse.Utils;
using Exercice_Conditions.ViewModel;

namespace Exercice_Conditions
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public AnimalViewModel ViewModel { get; set; }
        /// <summary>
        /// Constructeur de la vue
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            this.ViewModel = new AnimalViewModel();
        }

    }
}
