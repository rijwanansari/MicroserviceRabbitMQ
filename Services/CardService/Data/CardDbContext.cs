using CardService.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace CardService.Data;

public class CardDbContext : DbContext
{
    public CardDbContext(DbContextOptions<CardDbContext> options) : base(options)
    {
    }

    public DbSet<Card> Cards { get; set; }
    //add some seed data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Add in memory outbox
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();

        // seed data
        modelBuilder.Entity<Card>().HasData(
                       new Card
                       {
                           Id = 1,
                           CardNumber = "1234567890123456",
                           CardHolderName = "John Doe",
                           ExpiryDate = "12/25",
                           CVV = "123",
                           CardType = "MasterCard",
                           BankName = "Bank of America",
                           CardLimit = "5000",
                           CardBalance = "2000",
                           CardStatus = Status.Active.ToString()
                       },
                        new Card
                        {
                            Id = 2,
                            CardNumber = "1234567890123457",
                            CardHolderName = "Jane Doe",
                            ExpiryDate = "12/25",
                            CVV = "123",
                            CardType = "Visa",
                            BankName = "Chase",
                            CardLimit = "10000",
                            CardBalance = "5000",
                            CardStatus = Status.Active.ToString()
                        });
    }
}