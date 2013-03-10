using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComponentOwl.BetterListView;

namespace aIWServerParser4.Classes
{
    public class Variables
    {
        public static bool Favourites;
        public static List<Server> Servers = new List<Server>();
        public static int ServersDone;
        public static int ServersFiltered;
        public static Filter Filter = new Filter();
        public const int Version = 4;
        public static int PlayerCount;
        public static List<BetterListViewItem> ItemsToAdd;
    }
}
