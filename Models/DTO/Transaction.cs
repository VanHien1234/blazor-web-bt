namespace web_blazor_server.Models.DTO;

public class Transaction
{
    public string Type { get; set; } = string.Empty; // "Deposit" hoặc "Withdraw"
    public decimal Amount { get; set; }
    public DateTime DateTime { get; set; }
}

