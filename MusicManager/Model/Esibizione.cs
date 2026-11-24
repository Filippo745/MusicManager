using System;
using Microsoft.EntityFrameworkCore;


namespace MusicManager.Model;

//chiave primaria
//a cosa serve la chiave primaria composta?
//serve proprio a garantire l'univocità della combinazione dei valori, non dei singoli valori 
//i singoli valori possono ripetersi, la stessa coppia no


[PrimaryKey(nameof(CantanteId), nameof(FestivalId))]

public class Esibizione
{
    //2 foreign key, un esibizione può appartenere a un solo festival e può avere un solo cantante, quindi due oggetti di due tipi diversi --> molti a uno + molti a uno
    public Cantante Cantante { get; set; } = null!;
    public Festival Festival { get; set; } = null!;


    public int FestivalId { get; set; } //foreign key
    public int CantanteId { get; set; } //foreign key
    public int VotiGiuria { get; set; }
    public int OrdineUscita { get; set; }
    
}
