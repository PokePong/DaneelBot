using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DaneelBot.Controls;

public partial class SideMenu : UserControl {
    public SideMenu() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}