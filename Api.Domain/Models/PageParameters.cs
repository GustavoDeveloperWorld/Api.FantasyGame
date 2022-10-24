using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class PageParameters
    {
        const int MaxSizePage = 50;
        public int Page { get; set; } = 1;
		private int _SizePage = 10;

		//Não deixa setar _SizePage além do MaxSizePage
		public int SizePage
		{
			get
			{
				return _SizePage;
			}
			set
			{
				_SizePage = (value > MaxSizePage) ? MaxSizePage : value;
			}
		}
	}
}
