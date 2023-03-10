using System;

namespace DaneelBot.Models;

public class ImportConfig {
    public string? Exchange { get; set; }
    public string? Symbol { get; set; }
    public DateTime? Start { get; set; }

}