using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MusicManager.Model;

namespace MusicManager.Data;

public class MusicManagerContext: DbContext
{
    //DbSet --> rappresenta un insieme di entità di uno specifico tipo e ci permette di leggere, aggiungere, modificare ed eliminare i dati della relativa tabella
    
    public DbSet<Cantante> Cantanti { get; set; } = null!;

    //Grazie a questa proprietà, quando avremo configurato il database, potremo scrivere query
    //Scrivo gli altri DbSet

    public DbSet<Esibizione> Esibizioni { get; set; } = null!;

    public DbSet<Etichetta> Etichette { get; set; } = null!;

    public DbSet<Festival> Festivals { get; set; } = null!;

    //Ora indichiamo DOVE verrà salvato il file del database SQLite

    public string DbPath { get; }

    public MusicManagerContext()
    {
        var cartellaApp = AppContext.BaseDirectory;
        DbPath = Path.Combine(cartellaApp, "../../../MusicManager.db");
    }

    //l'onconfiguring --come mi collego? -quale tecnologia

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data source={DbPath}");
    }


    //dobbiamo specificare a ef core che per realizzare il collegamento fra cantante e festival, deve utilizzare la tabella intermedia  Esibizione, anziché crearne un'altra automaticamente faccio onmodelcreating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cantante>()
            .HasMany(c => c.Festivals)
            .WithMany(f => f.Cantanti)
            .UsingEntity<Esibizione>();

    }




}
