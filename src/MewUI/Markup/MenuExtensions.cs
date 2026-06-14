using Aprillz.MewUI.Controls;

namespace Aprillz.MewUI;

/// <summary>
/// Fluent API extensions for menus.
/// </summary>
public static class MenuExtensions
{
    /// <summary>
    /// Sets the item height.
    /// </summary>
    /// <param name="menu">Target menu.</param>
    /// <param name="itemHeight">Item height.</param>
    /// <returns>The menu for chaining.</returns>
    public static Menu ItemHeight(this Menu menu, double itemHeight)
    {
        menu.ItemHeight = itemHeight;
        return menu;
    }

    /// <summary>
    /// Sets the item padding.
    /// </summary>
    /// <param name="menu">Target menu.</param>
    /// <param name="itemPadding">Item padding.</param>
    /// <returns>The menu for chaining.</returns>
    public static Menu ItemPadding(this Menu menu, Thickness? itemPadding)
    {
        menu.ItemPadding = itemPadding;
        return menu;
    }

    /// <summary>
    /// Sets whether the menu bar draws a bottom separator.
    /// </summary>
    /// <param name="bar">Target menu bar.</param>
    /// <param name="value">Whether to draw the separator.</param>
    /// <returns>The menu bar for chaining.</returns>
    public static MenuBar DrawBottomSeparator(this MenuBar bar, bool value = true)
    {
        bar.DrawBottomSeparator = value;
        return bar;
    }

    /// <summary>
    /// Sets the spacing between menu items.
    /// </summary>
    /// <param name="bar">Target menu bar.</param>
    /// <param name="spacing">Spacing value.</param>
    /// <returns>The menu bar for chaining.</returns>
    public static MenuBar Spacing(this MenuBar bar, double spacing)
    {
        bar.Spacing = spacing;
        return bar;
    }

    /// <summary>
    /// Sets the menu items.
    /// </summary>
    /// <param name="bar">Target menu bar.</param>
    /// <param name="items">Menu items.</param>
    /// <returns>The menu bar for chaining.</returns>
    public static MenuBar Items(this MenuBar bar, params MenuItem[] items)
    {
        bar.SetItems(items);
        return bar;
    }

    /// <summary>
    /// Adds a menu item.
    /// </summary>
    /// <param name="bar">Target menu bar.</param>
    /// <param name="item">Menu item to add.</param>
    /// <returns>The menu bar for chaining.</returns>
    public static MenuBar Item(this MenuBar bar, MenuItem item)
    {
        bar.Add(item);
        return bar;
    }

    /// <summary>
    /// Adds a menu item with text and submenu.
    /// </summary>
    /// <param name="bar">Target menu bar.</param>
    /// <param name="text">Menu item text.</param>
    /// <param name="menu">Submenu.</param>
    /// <returns>The menu bar for chaining.</returns>
    public static MenuBar Item(this MenuBar bar, string text, Menu menu)
    {
        ArgumentNullException.ThrowIfNull(menu);
        bar.Add(new MenuItem(text).Menu(menu));
        return bar;
    }

    /// <summary>
    /// Sets the menu item text.
    /// </summary>
    /// <param name="item">Target menu item.</param>
    /// <param name="text">Item text.</param>
    /// <returns>The menu item for chaining.</returns>
    public static MenuItem Text(this MenuItem item, string text)
    {
        item.Text = text ?? string.Empty;
        return item;
    }

    /// <summary>
    /// Sets the submenu.
    /// </summary>
    /// <param name="item">Target menu item.</param>
    /// <param name="menu">Submenu.</param>
    /// <returns>The menu item for chaining.</returns>
    public static MenuItem Menu(this MenuItem item, Menu? menu)
    {
        item.SubMenu = menu;
        return item;
    }

    /// <summary>
    /// Sets the keyboard shortcut gesture. Auto-generates display text.
    /// </summary>
    /// <param name="item">Target menu item.</param>
    /// <param name="gesture">Keyboard shortcut gesture.</param>
    /// <returns>The menu item for chaining.</returns>
    public static MenuItem Shortcut(this MenuItem item, KeyGesture? gesture)
    {
        item.Shortcut = gesture;
        return item;
    }

    /// <summary>
    /// Sets whether the menu item is enabled.
    /// </summary>
    /// <param name="item">Target menu item.</param>
    /// <param name="value">Whether the item is enabled.</param>
    /// <returns>The menu item for chaining.</returns>
    public static MenuItem IsEnabled(this MenuItem item, bool value = true)
    {
        item.IsEnabled = value;
        return item;
    }

    /// <summary>
    /// Sets the predicate that determines whether the menu item can be clicked.
    /// </summary>
    /// <param name="item">Target menu item.</param>
    /// <param name="value">Can-click predicate.</param>
    /// <returns>The menu item for chaining.</returns>
    public static MenuItem CanClick(this MenuItem item, Func<bool>? value)
    {
        item.CanClick = value;
        return item;
    }

    /// <summary>
    /// Sets the menu item click action.
    /// </summary>
    /// <param name="item">Target menu item.</param>
    /// <param name="value">Click action.</param>
    /// <returns>The menu item for chaining.</returns>
    public static MenuItem Click(this MenuItem item, Action? value)
    {
        item.Click = value;
        return item;
    }

    /// <summary>
    /// Sets the nested submenu.
    /// </summary>
    /// <param name="item">Target menu item.</param>
    /// <param name="value">Nested submenu.</param>
    /// <returns>The menu item for chaining.</returns>
    public static MenuItem SubMenu(this MenuItem item, Menu? value)
    {
        item.SubMenu = value;
        return item;
    }

    /// <summary>
    /// Sets the keyboard shortcut gesture by key and modifiers. Auto-generates display text.
    /// </summary>
    /// <param name="item">Target menu item.</param>
    /// <param name="key">Shortcut key.</param>
    /// <param name="modifiers">Shortcut modifiers.</param>
    /// <returns>The menu item for chaining.</returns>
    public static MenuItem Shortcut(this MenuItem item, Key key, ModifierKeys modifiers = ModifierKeys.None)
    {
        item.Shortcut = new KeyGesture(key, modifiers);
        return item;
    }

    /// <summary>
    /// Adds an entry to the menu.
    /// </summary>
    /// <param name="menu">Target menu.</param>
    /// <param name="entry">Menu entry to add.</param>
    /// <returns>The menu for chaining.</returns>
    public static Menu Add(this Menu menu, MenuEntry entry)
    {
        ArgumentNullException.ThrowIfNull(menu);
        ArgumentNullException.ThrowIfNull(entry);
        menu.Items.Add(entry);
        return menu;
    }

    /// <summary>
    /// Adds a clickable menu item.
    /// </summary>
    /// <param name="menu">Target menu.</param>
    /// <param name="text">Menu item text.</param>
    /// <param name="onClick">Click handler.</param>
    /// <param name="isEnabled">Whether the item is enabled.</param>
    /// <param name="shortcut">Keyboard shortcut gesture (optional).</param>
    /// <returns>The menu for chaining.</returns>
    public static Menu Item(this Menu menu, string text, Action? onClick = null, bool isEnabled = true, KeyGesture? shortcut = null)
    {
        ArgumentNullException.ThrowIfNull(menu);
        menu.Items.Add(new MenuItem
        {
            Text = text ?? string.Empty,
            Click = onClick,
            IsEnabled = isEnabled,
            Shortcut = shortcut
        });
        return menu;
    }

    /// <summary>
    /// Adds a submenu item.
    /// </summary>
    /// <param name="menu">Target menu.</param>
    /// <param name="text">Menu item text.</param>
    /// <param name="subMenu">Submenu.</param>
    /// <param name="isEnabled">Whether the item is enabled.</param>
    /// <param name="shortcut">Keyboard shortcut gesture (optional).</param>
    /// <returns>The menu for chaining.</returns>
    public static Menu SubMenu(this Menu menu, string text, Menu subMenu, bool isEnabled = true, KeyGesture? shortcut = null)
    {
        ArgumentNullException.ThrowIfNull(menu);
        ArgumentNullException.ThrowIfNull(subMenu);

        menu.Items.Add(new MenuItem
        {
            Text = text ?? string.Empty,
            IsEnabled = isEnabled,
            Shortcut = shortcut,
            SubMenu = subMenu
        });
        return menu;
    }

    /// <summary>
    /// Adds a separator.
    /// </summary>
    /// <param name="menu">Target menu.</param>
    /// <returns>The menu for chaining.</returns>
    public static Menu Separator(this Menu menu)
    {
        ArgumentNullException.ThrowIfNull(menu);
        menu.Items.Add(MenuSeparator.Instance);
        return menu;
    }
}
