using System;

namespace MusicManager.Model;

public class Etichetta
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    //Cosa significa null! ??
    //E' un modo per comunicare al compilatore che ci occuperemo di assegnare un valore alla proprietà successivamente, evitando l'avviso di nullabilità
    public string SedeLegale { get; set; } = null!;

    //navigation property

    



}
