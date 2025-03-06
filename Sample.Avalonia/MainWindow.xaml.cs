using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace Sample.Avalonia {

    internal class MainWindow : Window {

        private int counter = 1;

        private TabControl tabs;

        private ContextMenu contextMenu;

        public MainWindow() {
            AvaloniaXamlLoader.Load(this);

            tabs = this.FindControl<TabControl>("tabs");

            CutCommand = ReactiveCommand.Create(() => {
                SelectedView.EditCommands.Cut();
            });

            CopyCommand = ReactiveCommand.Create(() => {
                SelectedView.EditCommands.Copy();
            });

            PasteCommand = ReactiveCommand.Create(() => {
                SelectedView.EditCommands.Paste();
            });

            UndoCommand = ReactiveCommand.Create(() => {
                SelectedView.EditCommands.Undo();
            });

            RedoCommand = ReactiveCommand.Create(() => {
                SelectedView.EditCommands.Redo();
            });

            SelectAllCommand = ReactiveCommand.Create(() => {
                SelectedView.EditCommands.SelectAll();
            });

            DeleteCommand = ReactiveCommand.Create(() => {
                SelectedView.EditCommands.Delete();
            });

            contextMenu = ContextMenuExample.CreateContextMenu();

            this.PointerReleased += OnRightClick;

#if DEBUG
            this.AttachDevTools(new KeyGesture(Key.F5));
#endif
        }

        private TabView SelectedView => (TabView) tabs.SelectedContent;

        private void OnToggleThemeStyleSheetMenuItemClick(object sender, RoutedEventArgs e) => Settings.IsLightTheme = !Settings.IsLightTheme;

        private void OnShowDevToolsMenuItemClick(object sender, RoutedEventArgs e) => SelectedView.ShowDevTools();

        private void OnToggleIsEnabledMenuItemClick(object sender, RoutedEventArgs e) => SelectedView.ToggleIsEnabled();

        private void OnRightClick(object sender, PointerReleasedEventArgs e)
        {
            // Show context menu only on right-click
            if (e.InitialPressMouseButton == MouseButton.Right)
            {
                var point = e.GetPosition(this); // Get cursor position relative to window

                // Open the context menu at the cursor position
                contextMenu.PlacementMode = PlacementMode.Pointer;
                contextMenu.Open(this);
            }
        }

        public ReactiveCommand<Unit, Unit> CutCommand { get; }

        public ReactiveCommand<Unit, Unit> CopyCommand { get; }

        public ReactiveCommand<Unit, Unit> PasteCommand { get; }

        public ReactiveCommand<Unit, Unit> UndoCommand { get; }

        public ReactiveCommand<Unit, Unit> RedoCommand { get; }

        public ReactiveCommand<Unit, Unit> SelectAllCommand { get; }

        public ReactiveCommand<Unit, Unit> DeleteCommand { get; }
    }
}