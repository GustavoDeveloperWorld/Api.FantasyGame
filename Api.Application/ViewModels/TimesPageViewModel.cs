using System;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class TimesPageViewModel
    {
        public TimesPageViewModel()
        {
            Times = new List<TimeViewModel>();
        }
        public int Page { get; set; }
        public int SizePage { get; set; }
        public int AmountPage { get; set; }
        public List<TimeViewModel> Times { get; set; }
    }
}