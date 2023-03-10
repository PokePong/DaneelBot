using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DaneelBot.Controls; 

public partial class InteractiveContainer : UserControl {
    public InteractiveContainer() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}