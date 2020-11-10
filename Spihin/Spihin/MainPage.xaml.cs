using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Grid_App_2020
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConPage : ContentPage
    {
        Picker Korova;
        Editor Edit;
        DatePicker dpicker;
        Entry entry;
        TimePicker tpicker;
        string hh;
        public ConPage()
        {
            Grid gr = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)}
                }
            };
            Korova = new Picker
            {
                Title = "Keeled"
            };
            Korova.Items.Add("Kozerog");
            Korova.Items.Add("Riba");
            Korova.Items.Add("Vodolei");
            Korova.Items.Add("Vesi");
            Korova.Items.Add("Oven");
            gr.Children.Add(Korova, 0, 0);
            Korova.SelectedIndexChanged += Picker_SelectedIndexChanged;

            Edit = new Editor { Placeholder = "Horoskop" };
            gr.Children.Add(Edit, 1, 0);

            /*dpicker = new DatePicker
            {
                Format = "D",
                MinimumDate = DateTime.Now.AddDays(-10),
                MaximumDate = DateTime.Now.AddDays(10)
            };
            dpicker.DateSelected += Dpicker_DateSelected;
            gr.Children.Add(dpicker, 1, 1);*/

            tpicker = new TimePicker()
            {
                //Time = new TimeSpan(18, 0, 0)

                Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            };
            tpicker.PropertyChanged += Tpicker_PropertyChanged;
            gr.Children.Add(tpicker, 1, 1);
            entry = new Entry { Text = "Vali kuupäev või kellaaeg" };
            gr.Children.Add(entry, 0, 1);
            Content = gr;
        }
        private void Tpicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
            {
                TimeSpan selctTime = tpicker.Time;
                entry.Text = selctTime.ToString();
            }
        }

        private void Dpicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            entry.Text = "Рыбы (лат. Pisces) — двенадцатый знак зодиака, соответствующий сектору эклиптики от 330° до 360°, считая от точки весеннего равноденствия; мутабельный знак тригона Вода. Управляющая планета Рыб — Нептун, но второй управитель также Юпитер." + e.NewDate.ToString("G");
        }
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edit.Text = "Oli valitud: " + Korova.Items[Korova.SelectedIndex];
        }
    }
}
