using Microsoft.EntityFrameworkCore;
using MusicManager.Data;
using MusicManager.Model;
using SQLitePCL;

internal class Program
{
    private static void Main(string[] args)
    {
        // PopulateDB();

        // using var db = new MusicManagerContext();

        // Console.WriteLine("Query numero 1:");
        // Q1(80);

        // Console.WriteLine("Query numero 2:");

        // Q2("Sony Music");

        // Console.WriteLine("Query numero 3:");

        Q3();


    }

        //trovare e stampare i nomi dei cantanti e il relativo festival che hanno avuto l'onere di aprire il festival, ovvero quelli con OrdineUscita = 1

        static void Q3()
        {
            using var db = new MusicManagerContext();

            var risultati = db.Esibizioni
                .Where(e => e.OrdineUscita == 1)
                .Select(e => new
                {
                    e.Cantante.NomeArte,
                    NomeFestival = e.Festival.Nome

                })
                .ToList();

            foreach (var c in risultati)
            {
                Console.WriteLine($"{c.NomeArte} - {c.NomeFestival}");
            }
    }
    

    //metodo che riceva un punteggio minimo e stampi, per le esibizioni che superano la soglia:
    //nome d'arte del cantante
    //nome del festival
    //voti ottenuti
    static void Q1(int punteggioMinimo)
    {
        using var db = new MusicManagerContext();

        var risultati = db.Esibizioni
            .Include(e => e.Cantante)
            .Include(e => e.Festival)
            .Where(e => e.VotiGiuria > punteggioMinimo)
            .ToList();

        
        foreach (var e in risultati)
        {
            Console.WriteLine($"{e.Cantante.NomeArte} - {e.Festival.Nome} - {e.VotiGiuria}");
        }
    }


    //query 2: creare un metodo che riceva il nome di un'etichetta e stampi tutti i festival in cui ha partecpato almeno un cantante di quell'etichetta evitando duplicati nei nomi dei festival

    private static void Q2(string nomeEtichetta)
    {
        using var db = new MusicManagerContext();

        var risultati = db.Esibizioni
            .Where(e => e.Cantante.Etichetta.Nome == nomeEtichetta)
            .Select(e => e.Festival.Nome)
            .Distinct()
            .ToList();

        
        foreach (var nome in risultati)
        {
            Console.WriteLine(nome);
        }
        
    
    }

    static void PopulateDB()
    {
        using var db = new MusicManagerContext();

        List<Etichetta> etichette =
        [
            new (){Id=1, Nome="Universal Music", SedeLegale="Milano"},
            new (){Id=2, Nome="Sony Music", SedeLegale="Roma"},
            new (){Id=3, Nome="Warner Music", SedeLegale="Milano"},
        ];

        List<Cantante> cantanti =
        [
            new (){Id = 1, NomeArte="The Rocker", NomeReale="Mario Rossi", EtichettaId=1},
            new (){Id = 2, NomeArte="Melody", NomeReale="Anna Verdi", EtichettaId=1},
            new (){Id = 3, NomeArte="Trap King", NomeReale="Luca Bianchi", EtichettaId=2},
            new (){Id = 4, NomeArte="Jazz Master", NomeReale="Paolo Neri", EtichettaId=2},
            new (){Id = 5, NomeArte="Pop Queen", NomeReale="Giulia Gialli", EtichettaId=3},
            new (){Id = 6, NomeArte="Indie Boy", NomeReale="Marco Blu", EtichettaId=3}
        ];

        List<Festival> festival =
        [
            new (){Id=1, Nome="Sanremo Giovani", DataInizio=DateTime.Today},
            new (){Id=2, Nome="Festivalbar", DataInizio=DateTime.Today.AddDays(-30)}
        ];

        List<Esibizione> esibizioni =
        [
            // Festival 1 (Sanremo)
            new (){CantanteId = 1, FestivalId = 1, VotiGiuria= 85, OrdineUscita = 1},
            new (){CantanteId = 2, FestivalId = 1, VotiGiuria = 92, OrdineUscita = 2},
            new (){CantanteId = 3, FestivalId = 1, VotiGiuria = 70, OrdineUscita = 3},
            new (){CantanteId = 4, FestivalId = 1, VotiGiuria = 60, OrdineUscita = 4},
            new (){CantanteId = 5, FestivalId = 1, VotiGiuria = 95, OrdineUscita = 5}, 
            new (){CantanteId = 6, FestivalId = 1, VotiGiuria = 50, OrdineUscita = 6},

            // Festival 2 (Festivalbar)
            new (){CantanteId = 4, FestivalId = 2, VotiGiuria = 88, OrdineUscita = 1},
            new (){CantanteId = 2, FestivalId = 2, VotiGiuria = 90, OrdineUscita = 2},
            new (){CantanteId = 1, FestivalId = 2, VotiGiuria = 75, OrdineUscita = 3},
            new (){CantanteId = 5, FestivalId = 2, VotiGiuria = 80, OrdineUscita = 4},
            new (){CantanteId = 6, FestivalId = 2, VotiGiuria = 65, OrdineUscita = 5},
            new (){CantanteId = 3, FestivalId = 2, VotiGiuria = 55, OrdineUscita = 6},
        ];

        db.Etichette.AddRange(etichette);
        db.Cantanti.AddRange(cantanti);
        db.Esibizioni.AddRange(esibizioni);
        db.Festivals.AddRange(festival);

        db.SaveChanges();
        
    }
}