using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace AppDemo.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DrawerList.PointerReleased += DrawerSelectionChanged;
        DrawerList.KeyUp += DrawerList_KeyUp;
    }
    private void DrawerList_KeyUp(object? sender, KeyEventArgs e) {
        if (e.Key is Key.Space or Key.Enter)
            DrawerSelectionChanged(sender, null);
    }
    public void DrawerSelectionChanged(object? sender, RoutedEventArgs? args) {
        if (sender is not ListBox listBox)
            return;

        if (listBox is { IsFocused: false, IsKeyboardFocusWithin: false })
            return;
        try {
            PageCarousel.SelectedIndex = listBox.SelectedIndex;
            MainScroller.Offset = Vector.Zero;
            MainScroller.VerticalScrollBarVisibility =
                listBox.SelectedIndex == 5 ? ScrollBarVisibility.Disabled : ScrollBarVisibility.Auto;
        }
        catch {
            // ignored
        }
        LeftDrawer.OptionalCloseLeftDrawer();
    }
}