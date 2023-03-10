using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;

namespace DaneelBot.Controls;

public partial class RingProgressBar : UserControl {
    public RingProgressBar() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }

    public static readonly DirectProperty<RingProgressBar, int> ValueProperty =
        AvaloniaProperty.RegisterDirect<RingProgressBar, int>(
            nameof(Value),
            o => o.Value,
            (o, v) => o.Value = v,
            defaultBindingMode: BindingMode.OneWay,
            enableDataValidation: true);

    private int _value = 50;

    public int Value {
        get => _value;
        set => SetAndRaise(ValueProperty, ref _value, (int)(value * 3.6));
    }

    public static readonly StyledProperty<int> WidthProperty = AvaloniaProperty.Register<RingProgressBar, int>(nameof(Width), 150);

    public int Width {
        get => GetValue(WidthProperty);
        set => SetValue(WidthProperty, value);
    }
    
    public static readonly StyledProperty<int> HeightProperty = AvaloniaProperty.Register<RingProgressBar, int>(nameof(Height), 150);

    public int Height {
        get => GetValue(HeightProperty);
        set => SetValue(HeightProperty, value);
    }
    
    public static readonly StyledProperty<int> StrokeSizeProperty = AvaloniaProperty.Register<RingProgressBar, int>(nameof(StrokeSize), 10);

    public int StrokeSize {
        get => GetValue(StrokeSizeProperty);
        set => SetValue(StrokeSizeProperty, value);
    }
}