using System.ComponentModel.DataAnnotations;

namespace CardService.Entities;

//create a card model to store the card details 10 properties
public class Card
{
    [Key]
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string ExpiryDate { get; set; }
    public string CVV { get; set; }
    public string CardType { get; set; }
    public string BankName { get; set; }
    public string CardLimit { get; set; }
    public string CardBalance { get; set; }
    public string CardStatus { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}