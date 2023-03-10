using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DaneelBot.ViewModels;
using ReactiveUI;

namespace DaneelBot.Views;

public partial class ImportView : ReactiveUserControl<ImportPageViewModel> {
    private DateTime _selectedStartDate;

    public ImportView() {
        this.WhenActivated(disposables => {
            var today = DateTime.Now;

            var calendar = this.FindControl<Calendar>("CalendarPicker");
            var dateButton = this.FindControl<Button>("DateButton");

            calendar.DisplayDateStart = today.AddYears(-4);
            calendar.DisplayDateEnd = today;
            calendar.SelectedDatesChanged += ((sender, args) => {
                if (calendar.SelectedDate is null) return;
                _selectedStartDate = (DateTime)calendar.SelectedDate;
                ViewModel!.SelectedStartDate = _selectedStartDate.ToString("dd/MM/yyyy");
                Debug.WriteLine(_selectedStartDate.ToString("dd/MM/yyyy"));
            });
        });
        AvaloniaXamlLoader.Load(this);
    }
}