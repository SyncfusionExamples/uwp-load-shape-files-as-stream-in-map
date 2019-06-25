using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Maps
{
	public partial class MainPage : ContentPage
	{
        Stream stream;
        Assembly assembly;
		public MainPage()
		{
			InitializeComponent();
            assembly = typeof(MainPage).GetTypeInfo().Assembly;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (stream != null)
            {
                //// stream of the shape file accessed from any location can be loaded here.
                layer.ReadAsStream(stream);
            }
        }
                
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (assembly == null) return;           
            var pick = sender as Picker;
            if(pick.SelectedIndex==0)
            {
                //// Stream conversion of the shape file.
                 stream = assembly.GetManifestResourceStream("Maps.ShapeFiles.world1.shp");
            }
            else
            {
                //// Stream conversion of the shape file.
                stream = assembly.GetManifestResourceStream("Maps.ShapeFiles.usa_state.shp");               
            }
        }
    }    
}
