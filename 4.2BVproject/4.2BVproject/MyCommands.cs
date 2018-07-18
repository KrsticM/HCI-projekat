using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _4._2BVproject
{
    class MyCommands
    {
        public static readonly RoutedUICommand ExitDemo = new RoutedUICommand(
            "Exit demo", "ExitDemo",
            typeof(MyCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Escape)
            }
            );
    }
}
