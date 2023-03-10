using DaneelBot.Exchange;

namespace DaneelBot.Database.Dto;

public class SymbolDto : DtoModel {
    public string Code { get; set; }

    public ExchangeType ExchangeType;
}