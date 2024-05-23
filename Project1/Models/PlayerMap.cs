using Microsoft.Identity.Client;
using Project1.Controllers;
using Project1.UserInterfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models;

public class PlayerMap
{
    [Key]
    public int ID {get; set;}
    public int MapLineOrder {get; set; }
    public string MapLine {get; set;}
    public Guid PlayerID {get; set;}

    public PlayerMap()
    {}

    public PlayerMap(int MapLineOrder, string MapLine, Guid PlayerID)
    {
        this.MapLineOrder = MapLineOrder;
        this.MapLine = MapLine;
        this.PlayerID = PlayerID;
    }
}