﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XFTest.ViewModels;
using Prism.Services.Dialogs;

namespace XFTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CleaningList : ContentPage
    {
        public CleaningList()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            var state = width < 280 ? "Small" : width < 360 ? "Medium" : "Large";
            VisualStateManager.GoToState(PageHeading, state); 
            VisualStateManager.GoToState(lblNoTasks, state); 
        }

        private async void OpenCalendar_Tapped(object sender, EventArgs e)
        {
            await calendar.TranslateTo(0, -100, 0);
            await calendar.TranslateTo(0, 0, 200);
        }
        private async void HideCalendar_Tapped(object sender, EventArgs e)
        {
            await calendar.TranslateTo(0, 0, 0);
            await calendar.TranslateTo(0, -100, 200);
        }
    }
}