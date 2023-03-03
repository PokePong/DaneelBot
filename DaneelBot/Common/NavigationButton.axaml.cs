using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using MaterialDesign.Avalonia.PackIcon;
using ReactiveUI;

namespace DaneelBot.Common;

public class NavigationButton : TemplatedControl {
    #region Icon Kind Property

    public static readonly StyledProperty<PackIconKind> IconKindProperty =
        AvaloniaProperty.Register<NavigationButton, PackIconKind>(nameof(IconKind), PackIconKind.Abc);

    public PackIconKind IconKind {
        get => GetValue(IconKindProperty);
        set => SetValue(IconKindProperty, value);
    }

    #endregion

    #region Label Property

    public static readonly StyledProperty<string> LabelProperty =
        AvaloniaProperty.Register<NavigationButton, string>(nameof(Label), string.Empty);

    public string Label {
        get => GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    #endregion

    #region Command Property

    public static readonly StyledProperty<ReactiveCommand<Unit, IRoutableViewModel>> GoToCommandProperty =
        AvaloniaProperty.Register<NavigationButton, ReactiveCommand<Unit, IRoutableViewModel>>(nameof(Label));

    public ReactiveCommand<Unit, IRoutableViewModel> GoToCommand {
        get => GetValue(GoToCommandProperty);
        set => SetValue(GoToCommandProperty, value);
    }

    #endregion
}