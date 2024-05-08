using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejemplo1.Droid
{
    public class Bootstrapper : Ejemplo1.Bootstrapper
    {
        public static void Init()
        {
            var instance = new Bootstrapper();
        }
    }

}