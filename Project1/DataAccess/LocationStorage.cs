using System.Text.Json;
using Project1.Models;

namespace Project1.Data;

public static class LocationStorage
{
    public static readonly string filePath = "./TempDataStorage/Locations.json";
    public static Dictionary<int, Location> GetLocationsList()
    {
        Dictionary<int,Location> locationReference = new();
        //string filePath = "./TempDataStorage/Locations.json";
        List<Location> locations = JsonSerializer.Deserialize<List<Location>>(File.ReadAllText(filePath));
        foreach(Location location in locations)
        {
            locationReference.Add(location.RoomHash,location);
        }
        return locationReference;
    }
    public static void CreateLocationFile()
    {
        List<Location> locationList = new List<Location>();

        List<int> room101801 = new List<int>{1341,1272,1271};
        Location loc101801 = new Location(101801,"Well",6,"This is a forest. But there is a well here. Cool.",50,room101801);
        locationList.Add(loc101801);   

        List<int> room101802 = new List<int>{1271,1272};
        Location loc101802 = new Location(101802,"Forest",7,"This is a forest. With trees and stuff.",40,room101802);
        locationList.Add(loc101802); 

        List<int> room101803 = new List<int>{1271,1272};
        Location loc101803 = new Location(101803,"Forest",7,"This is a forest. With trees and stuff.",50,room101803);
        locationList.Add(loc101803); 

        List<int> room101804 = new List<int>{1271,1272};
        Location loc101804 = new Location(101804,"Forest",7,"This is a forest. With trees and stuff.",50,room101804);
        locationList.Add(loc101804); 

        List<int> room101805 = new List<int>{1271,1272};
        Location loc101805 = new Location(101805,"Forest",3,"This is a forest. With trees and stuff.",50,room101805);
        locationList.Add(loc101805); 


        List<int> room102801 = new List<int>{1271,1272};
        Location loc102801 = new Location(102801,"Forest",14,"This is a forest. With trees and stuff.",40,room102801);
        locationList.Add(loc102801);   

        List<int> room102802 = new List<int>{1271,1272};
        Location loc102802 = new Location(102802,"Meadow",15,"This is a meadow. With grass and stuff.",40,room102802);
        locationList.Add(loc102802); 

        List<int> room102803 = new List<int>{1271,1272};
        Location loc102803 = new Location(102803,"Forest",15,"This is a forest. With trees and stuff.",50,room102803);
        locationList.Add(loc102803); 

        List<int> room102804 = new List<int>{1341,1272,1271};
        Location loc102804 = new Location(102804,"Forest Clearing",15,"This is a clearing in the forest. With grass and shrubs and stuff.",55,room102804);
        locationList.Add(loc102804); 

        List<int> room102805 = new List<int>{1271,1272};
        Location loc102805 = new Location(102805,"Forest",11,"This is a forest. With trees and stuff.",50,room102805);
        locationList.Add(loc102805); 


        List<int> room103801 = new List<int>{1152, 1272, 1271};
        Location loc103801 = new Location(103801,"Meadow",14,"This is a meadow. With grass and stuff.",35,room103801);
        locationList.Add(loc103801);   

        List<int> room103802 = new List<int>{1152, 1272, 1271};
        Location loc103802 = new Location(103802,"Meadow",15,"This is a meadow. With grass and stuff.",35,room103802);
        locationList.Add(loc103802); 

        List<int> room103803 = new List<int>{1152, 1272, 1271};
        Location loc103803 = new Location(103803,"Forest",15,"This is a forest. With trees and stuff.",35,room103803);
        locationList.Add(loc103803); 

        List<int> room103804 = new List<int>{1271,1272};
        Location loc103804 = new Location(103804,"Forest",15,"This is a forest. With trees and stuff.",50,room103804);
        locationList.Add(loc103804); 

        List<int> room103805 = new List<int>{1271,1272};
        Location loc103805 = new Location(103805,"Forest",11,"This is a forest. With trees and stuff.",50,room103805);
        locationList.Add(loc103805); 


        List<int> room104801 = new List<int>{1271,1272};
        Location loc104801 = new Location(104801,"Meadow",12,"This is a meadow. With grass and stuff.",35,room104801);
        locationList.Add(loc104801);   

        List<int> room104802 = new List<int>{1271,1272};
        Location loc104802 = new Location(104802,"Meadow",15,"This is a meadow. With grass and stuff.",35,room104802);
        locationList.Add(loc104802); 

        List<int> room104803 = new List<int>{1271,1272};
        Location loc104803 = new Location(104803,"Meadow",13,"This is a meadow. With grass and stuff.",35,room104803);
        locationList.Add(loc104803); 

        List<int> room104804 = new List<int>{1341,1272,1271};
        Location loc104804 = new Location(104804,"Forest",13,"This is a forest. With trees and stuff.",40,room104804);
        locationList.Add(loc104804); 

        List<int> room104805 = new List<int>{1271,1272};
        Location loc104805 = new Location(104805,"Forest",9,"This is a forest. With trees and stuff.",40,room104805);
        locationList.Add(loc104805);      


        List<int> room105802 = new List<int>{1151};
        Location loc105802 = new Location(105802,"Mountain Path",10,"A mountain path. You can see a meadow ahead.",30,room105802);
        locationList.Add(loc105802);


        List<int> room106801 = new List<int>{1151,1271};
        Location loc106801 = new Location(106801,"Small Pond",4,"You see a small pond. Too bad you can't swim.",30,room106801);
        locationList.Add(loc106801);   

        List<int> room106802 = new List<int>{1151,1271};
        Location loc106802 = new Location(106802,"Crossroads",15,"A fork in the path. There are several ways to go.",25,room106802);
        locationList.Add(loc106802); 

        List<int> room106803 = new List<int>{1151};
        Location loc106803 = new Location(106803,"Mountain Path",5,"A narrow dirt path. There are mountains on either side.",25,room106803);
        locationList.Add(loc106803); 

        List<int> room106804 = new List<int>{1151};
        Location loc106804 = new Location(106804,"Mountain Path",5,"A narrow dirt path. There are mountains on either side.",20,room106804);
        locationList.Add(loc106804); 

        List<int> room106805 = new List<int>{1151};
        Location loc106805 = new Location(106805,"Mountain Path",1,"A narrow dirt path. There are mountains on either side and the path behind you was blocked by a landslide.",0,room106805);
        locationList.Add(loc106805);   


        List<int> room107802 = new List<int>{1251};
        Location loc107802 = new Location(107802,"Cave Entrance",10,"You've entered a cave. It is kinda dark in here...",30,room107802);
        locationList.Add(loc107802);         


        List<int> room108802 = new List<int>{1251};
        Location loc108802 = new Location(108802,"Underground Tunnel",12,"An underground tunnel. The walls appear to have been carved. Poorly.",35,room108802);
        locationList.Add(loc108802); 

        List<int> room108803 = new List<int>{1251,1321};
        Location loc108803 = new Location(108803,"Underground Tunnel",3,"An underground tunnel. The walls appear to have been carved. Poorly.",35,room108803);
        locationList.Add(loc108803); 

        List<int> room108804 = new List<int>{1251,1321};
        Location loc108804 = new Location(108804,"Underground Tunnel",1,"An underground tunnel. The walls appear to have been carved. Poorly.",35,room108804);
        locationList.Add(loc108804);


        List<int> room109803 = new List<int>{1251,1321};
        Location loc109803 = new Location(109803,"Underground Tunnel",10,"An underground tunnel. The walls appear to have been carved. Poorly.",35,room109803);
        locationList.Add(loc109803);  


        List<int> room110801 = new List<int>{1251,1321,1471};
        Location loc110801 = new Location(110801,"Underground Tunnel",6,"An underground tunnel. The walls appear to have been carved. Poorly.",40,room110801);
        locationList.Add(loc110801);   

        List<int> room110802 = new List<int>{1251,1321,1471};
        Location loc110802 = new Location(110802,"Underground Tunnel",5,"An underground tunnel. The walls appear to have been carved. Poorly.",40,room110802);
        locationList.Add(loc110802); 

        List<int> room110803 = new List<int>{1251,1321,1471};
        Location loc110803 = new Location(110803,"Underground Tunnel",13,"An underground tunnel. The walls appear to have been carved. Poorly.",40,room110803);
        locationList.Add(loc110803); 

        List<int> room110804 = new List<int>{1251,1321,1471};
        Location loc110804 = new Location(110804,"Underground Tunnel",5,"An underground tunnel. The walls appear to have been carved. Poorly.",40,room110804);
        locationList.Add(loc110804); 

        List<int> room110805 = new List<int>{1251,1321,1471,1571};
        Location loc110805 = new Location(110805,"Underground Tunnel",1,"An underground tunnel. The walls appear to have been carved. Poorly.",60,room110805);
        locationList.Add(loc110805); 


        List<int> room111801 = new List<int>{1251,1321,1471};
        Location loc111801 = new Location(111801,"Underground Tunnel",10,"An underground tunnel. The walls appear to have been carved. Poorly.",40,room111801);
        locationList.Add(loc111801);   


        List<int> room112801 = new List<int>{1251,1321,1471};
        Location loc112801 = new Location(112801,"Underground Tunnel",10,"An underground tunnel. The walls appear to have been carved. Poorly.",50,room112801);
        locationList.Add(loc112801);   

        List<int> room112803 = new List<int>{1251,1321,1471};
        Location loc112803 = new Location(112803,"Underground Tunnel",6,"An underground tunnel. The walls appear to have been carved. Poorly.",50,room112803);
        locationList.Add(loc112803); 

        List<int> room112804 = new List<int>{1251,1321,1471};
        Location loc112804 = new Location(112804,"Underground Tunnel",4,"An underground tunnel. There is a mysterious door to the south glowing with power that refuses to open no matter how much you jiggle the handle",40,room112804);
        locationList.Add(loc112804); 

        List<int> room112805 = new List<int>{1151};
        Location loc112805 = new Location(112805,"Boss Lair",1,"You have entered a massive cavern. The ceiling and walls are well beyond the limits of your sight.\nThe mysterious door has closed behind you and is glowing again.\nChecking you find it is sealed and unable to be opened.",0,room112805);
        locationList.Add(loc112805);


        List<int> room113801 = new List<int>{1251,1321,1471};
        Location loc113801 = new Location(113801,"Underground Tunnel",6,"An underground tunnel. The walls appear to have been carved. Poorly.",40,room113801);
        locationList.Add(loc113801);   

        List<int> room113802 = new List<int>{1251,1321,1471};
        Location loc113802 = new Location(113802,"Underground Tunnel",5,"An underground tunnel. The walls appear to have been carved. Poorly.",40,room113802);
        locationList.Add(loc113802); 

        List<int> room113803 = new List<int>{1251,1321,1471};
        Location loc113803 = new Location(113803,"Underground Tunnel",9,"An underground tunnel. The walls appear to have been carved. Poorly.",40,room113803);
        locationList.Add(loc113803); 
        
        //string filePath = "./TempDataStorage/Locations.json";
        string locationListString = JsonSerializer.Serialize(locationList);
        File.WriteAllText(filePath,locationListString);
    }
}