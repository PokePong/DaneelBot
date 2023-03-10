using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DaneelBot.ViewModels;
using ReactiveUI;

namespace DaneelBot.Views;

public partial class ImportView : ReactiveUserControl<ImportPageViewModel> {
    public ImportView() {
        this.WhenActivated(disposables => {
            var today = DateTime.Now;

            var calendar = this.FindControl<Calendar>("CalendarPicker");

            calendar.DisplayDateStart = today.AddYears(-4);
            calendar.DisplayDateEnd = today;
            calendar.SelectedDatesChanged += (sender, args) => {
                if (calendar.SelectedDate is null) return;
                ViewModel!.SelectedStartDate = (DateTime)calendar.SelectedDate;
            };
        });
        AvaloniaXamlLoader.Load(this);
    }
}