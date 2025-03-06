using Avalonia.Controls;
using Avalonia.Media;
using System.Collections.Generic;

public class ContextMenuExample
{
    public static ContextMenu CreateContextMenu()
    {
        var contextMenu = new ContextMenu();
        var normalItem = new MenuItem { Header = "Normal Item" };

        // Create a submenu with items
        var submenu = new MenuItem { Header = "Enabled Submenu" };
        submenu.ItemsSource = new List<MenuItem>
        {
            new MenuItem { Header = "Sub Item 1" },
            new MenuItem { Header = "Sub Item 2" }
        };

        var menuWithDisabledItems = new MenuItem
        {
            Header = "Disabled Submenu",
        };

        menuWithDisabledItems.ItemsSource = new List<MenuItem>
        {
            new MenuItem { Header = "Disabled Sub Item 1" },
            new MenuItem { Header = "Disabled Sub Item 2", IsEnabled = false },
            new MenuItem { Header = "Disabled Sub Item 1" },
        };

        menuWithDisabledItems.PointerMoved += (s, e) => e.Handled = true;

        contextMenu.ItemsSource = new List<MenuItem>
        {
            normalItem,
            submenu,
            menuWithDisabledItems
        };

        return contextMenu;
    }
}