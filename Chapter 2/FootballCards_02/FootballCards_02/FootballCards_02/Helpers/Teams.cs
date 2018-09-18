using FootballCards_02.Model;
using System.Collections.Generic;

namespace FootballCards_02.Helpers
{
    // Ground and team information from https://en.wikipedia.org/wiki/List_of_Premier_League_stadiums
    // Long/Lat conversion from https://www.fcc.gov/media/radio/dms-decimal

    public static class Helpers
    {
        public static List<Cards> GenerateCards
        {
            get {
                return new List<Cards>
            {
                new Cards {TeamName="Liverpool", Capacity=45276, StadiumName="Anfield", Latitude = 53.430833, Longitude=2.960833 },
                new Cards {TeamName="West Ham United", Capacity = 35345, StadiumName="Upton Park",Latitude=51.531944, Longitude=0.039444 },
                new Cards {TeamName="Stoke City", Capacity = 27740, StadiumName="Britannia Stadium",Latitude=52.988333,Longitude=2.175556 },
                new Cards {TeamName="Norwich", Capacity = 27033, StadiumName="Carrow Road", Latitude=52.622222,Longitude=1.309167 },
                new Cards {TeamName="Manchester City", Capacity = 55000, StadiumName="Ethiad Stadium",Latitude=53.483056,Longitude=2.200278 },
                new Cards {TeamName="A.F.C. Bournemouth", Capacity=11700, StadiumName="Dean Court",Latitude=50.735278,Longitude=1.838333 },
                new Cards {TeamName="Arsenal", Capacity=60272, StadiumName="Emirates Stadium",Latitude=51.555, Longitude=0.108611 },
                new Cards {TeamName="Everton", Capacity=39571, StadiumName="Goodison Park",Latitude=53.438889, Longitude=2.966389 },
                new Cards {TeamName="West Bromwich Albion", Capacity=26445, StadiumName="The Hawthorns",Latitude=52.509167,Longitude=1.963889 },
                new Cards {TeamName="Leicester City", Capacity=32500, StadiumName="King Power Stadium", Latitude=52.620278, Longitude=1.142222 },
                new Cards {TeamName="Swansea", Capacity=20937, StadiumName="Liberty Stadium",Latitude=51.642778,Longitude=3.934722 },
                new Cards {TeamName="Manchester United", Capacity=75635, StadiumName="Old Trafford", Latitude=53.463056,Longitude=2.291389 },
                new Cards {TeamName="Newcastle United", Capacity=53405, StadiumName="St James' Park", Latitude=54.975556,Longitude=1.621667 },
                new Cards {TeamName="Southampton", Capacity=32689, StadiumName="St Mary's Road",Latitude=50.905833,Longitude=1.391111 },
                new Cards {TeamName="Crystal Palace", Capacity=26309, StadiumName="Selhurst Park",Latitude=51.398333, Longitude=0.085556 },
                new Cards {TeamName="Sunderland", Capacity=49000, StadiumName="Stadium of Light",Latitude=54.914444, Longitude=1.388333 },
                new Cards {TeamName="Chelsea", Capacity=41798, StadiumName="Stamford Bridge",Latitude=51.481667,Longitude=0.191111 },
                new Cards {TeamName="Watford", Capacity=21577, StadiumName="Vicarage Road",Latitude=51.65, Longitude=0.401667 },
                new Cards {TeamName="Aston Villa", Capacity=42682, StadiumName="Villa Park", Latitude=52.509167,Longitude=1.884722 },
                new Cards {TeamName="Tottenham Hotspurs", Capacity=36284, StadiumName="White Hart Lane",Latitude=51.603333, Longitude=0.065833 }
            };
            }
        }
    }
}
