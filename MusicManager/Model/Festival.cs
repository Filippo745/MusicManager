using System;

namespace MusicManager.Model;

public class Festival
{
    public int Id { get; set; }
    public DateTime DataInizio { get; set; }
    public string Nome { get; set; }= null!;
    
}
