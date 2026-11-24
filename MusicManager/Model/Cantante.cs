using System;

namespace MusicManager.Model;

public class Cantante
{
    public int Id { get; set; }
    public int EtichettaId { get; set; } //è la foreign key, che permette, in sostanza di collegare un entità attraverso il suo identificativo

    //prendiamo Etichetta e Cantante
    
    // ID (PK)          NOME
    //  1               Sony
    //  2               Universal



    //per indicare che ci occuperemo successivamente dell'assegnare un valore alla variabile (=null!)
    public string NomeArte { get; set; }= null!;
    public string NomeReale { get; set; }= null!;  


    //Navigation property
    
    public Etichetta Etichetta { get; set; } = null!;

    
}
