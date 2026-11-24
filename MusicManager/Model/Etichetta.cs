using System;

namespace MusicManager.Model;

public class Etichetta
{
    //Un'etichetta può avere più cantanti, quindi uno a molti ICollection

    public ICollection<Cantante> Cantanti { get; set; } = null!;


    public int Id { get; set; }
    public string Nome { get; set; } = null!;

    //Cosa significa null! ??
    //E' un modo per comunicare al compilatore che ci occuperemo di assegnare un valore alla proprietà successivamente, evitando l'avviso di nullabilità
    public string SedeLegale { get; set; } = null!;

    
    



}
