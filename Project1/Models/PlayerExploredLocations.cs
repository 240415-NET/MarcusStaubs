using Project1.Controllers;
using Project1.UserInterfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models;

public class ExploredLocation
{
    [Key]
    public int ID { get; set; }
    public Guid PlayerID { get; set; }
    public int locationHash { get; set; }

    public ExploredLocation()
    {}

    public ExploredLocation(Guid PlayerID, int LocationHash)
    {
        this.PlayerID = PlayerID;
        this.locationHash = LocationHash;
    }
}