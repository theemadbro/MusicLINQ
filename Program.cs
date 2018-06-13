using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //=========================================================
            //Solve all of the prompts below using various LINQ queries
            //=========================================================
            System.Console.WriteLine("Solving LINQ queries!");
            //=========================================================
            //There is only one artist in this collection from Mount 
            //Vernon. What is their name and age?
            //=========================================================
            var VernonArtist = (from match in Artists
                                where match.Hometown == "Mount Vernon"
                                select match).First();
            //=========================================================
            //Who is the youngest artist in our collection of artists?
            //=========================================================
            var YoungestArtist = (from match in Artists orderby match.Age ascending select match).First();
            //=========================================================
            //Display all artists with 'William' somewhere in their 
            //real name        
            //=========================================================
            var getWillam = from match in Artists   
                                where match.RealName.Contains("William")
                                select match;
            //=========================================================
            //Display all groups with names less than 8 characters
            //=========================================================
            var ShortGroups = from match in Groups
                                where match.GroupName.Length < 9
                                select match;
            //=========================================================
            //Display the 3 oldest artists from Atlanta
            //=========================================================
            var oldAtlanta = (from match in Artists
                                where match.Hometown == "Atlanta"
                                orderby match.Age descending
                                select match).Take(3);
            //=========================================================
            //(Optional) Display the Group Name of all groups that have 
            //at least one member not from New York City
            //=========================================================
            var notNY = from match in Artists
                                join groupa in Groups on match.GroupId equals groupa.Id
                                where match.Hometown != "New York" && match.GroupId != 0
                                select match;

            
            //=========================================================
            //(Optional) Display the artist names of all members of the 
            //group 'Wu-Tang Clan'
            //=========================================================
        }
    }
}
