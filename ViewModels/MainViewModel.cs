using Lab_2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.ViewModels
{
    class MainViewModel
    {
        private readonly Chart _chart;
        public Chart Chart { get => _chart; }
        public MainViewModel()
        {
            _chart = new();
        }
        
    }
}
