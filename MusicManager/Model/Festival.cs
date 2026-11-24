using System;

namespace MusicManager.Model;

public class Festival
{
    //Navigation property

    //un festival può ospitare più esibizioni: uno a molti
    public ICollection<Esibizione> Esibizioni { get; set; }=null!;

    //skip navigation property --> festival cantante molti a molti

    public ICollection<Cantante> Cantanti { get; set; }= null!;


    public int Id { get; set; }
    public DateTime DataInizio { get; set; }
    public string Nome { get; set; }= null!;
    
}
