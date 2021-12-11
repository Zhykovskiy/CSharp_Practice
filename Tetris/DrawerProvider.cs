using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    static class DrawerProvider
    {
        public static IDrawer Drawer { get; set; } = new ConsoleDrawer();
    }
}
