using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DaneelBot.ViewModels;
using ReactiveUI;

namespace DaneelBot.Views;

public partial class ImportView : ReactiveUserControl<ImportPageViewModel> {
    public ImportView() {
        this.WhenActivated(disposables => {
            
        });
        AvaloniaXamlLoader.Load(this);
    }
}