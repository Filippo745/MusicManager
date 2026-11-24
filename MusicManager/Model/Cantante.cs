using System;

namespace MusicManager.Model;

public class Cantante
{
    //Navigation property, un cantante può avere una sola etichetta, quindi
    public Etichetta Etichetta { get; set; } = null!;
    
    //un cantante può avere diverse esibizioni --> uno a molti

    public ICollection<Esibizione> Esibizioni { get; set; }= null!;


    //Skip navigation propery --> serve a saltare l'oggetto intermedio
    //cantante a festival molti a molti

    public ICollection<Festival> Festivals { get; set; }= null!;



    public int Id { get; set; }
    public int EtichettaId { get; set; } //è la foreign key, che permette, in sostanza di collegare un entità attraverso il suo identificativo

    // = null! serve per voler dire al compilatore che ci occuperemo successivamente di assegnargli un valore, quindi per il momento sopprimiamo l'avviso 
    public string NomeArte { get; set; }= null!; 
    public string NomeReale { get; set; }= null!;  

    

    
}
