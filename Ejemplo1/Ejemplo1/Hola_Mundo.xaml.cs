using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejemplo1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Hola_Mundo : ContentPage
    {
        public Hola_Mundo()
        {
            InitializeComponent();
        }
    }
}