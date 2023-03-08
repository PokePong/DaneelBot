using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DaneelBot.ViewModels;
using MongoDB.Driver.Linq;
using ReactiveUI;

namespace DaneelBot.Views;

public partial class ImportView : ReactiveUserControl<ImportPageViewModel> {
    
    private DateTime _selectedStartDate;

    public ImportView() {
        this.WhenActivated(disposables => {
            var today = DateTime.Now;

            var calendar = this.FindControl<Calendar>("CalendarPicker");
            calendar.DisplayDateStart = today.AddYears(-4);
            calendar.DisplayDateEnd = today;
            calendar.SelectedDatesChanged += ((sender, args) => {
                if (calendar.SelectedDate is null) return;
                _selectedStartDate = (DateTime)calendar.SelectedDate;
                ViewModel!.SelectedStartDate = _selectedStartDate.ToString("dd/MM/yyyy");
            });
        });
        AvaloniaXamlLoader.Load(this);
    }
}