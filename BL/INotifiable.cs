using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeLoader
{
    public interface INotifiable
    {
        Action<String> Notify { get; set; }
    }
}
