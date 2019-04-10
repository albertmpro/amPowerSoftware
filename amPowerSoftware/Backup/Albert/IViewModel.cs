using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace Albert.Standard
{
    /// <summary>
    /// Interface for implementing a ViewModel(MVVM) Concept 
    /// </summary>
    public interface IViewModel
    {
        //Private Field's 
        event Action<string> OnNotification;
        //object Message { get; set; }



      


    }
}
