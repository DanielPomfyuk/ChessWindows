using App6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace App6.Viewes
{
    class Cell
    {
        // changing cell`s colour to red(pressed mode) and back
        public static void ChangeColor(Models.Cell cell, Models.Cell.Types color)
        {
                cell.rectangle.Fill = new SolidColorBrush(Models.Cell.cellColors[color]);
        }
    }
}
