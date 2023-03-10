using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DaneelBot.Controls; 

public partial class DesktopPage : UserControl {
    public DesktopPage() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}