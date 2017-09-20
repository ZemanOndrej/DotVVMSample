using System;
using System.Collections.Generic;

namespace DotVVMSample.ViewModels
{
    public class HomeViewModel : MainViewModel
    {

        public string Text { get; set; }
        public DateTime Date { get; set; }  = DateTime.Today;

        public HomeViewModel()
        {
            Text = "Hello from DotVVM!";
        }


        public void SendDate()
        {
            Console.WriteLine(Date);
        }



    }
}

