using System.Collections.Generic;

namespace WebAPIClient
{
    public class Item
    {
        public int emailMessageId { get; set; }
        public string name { get; set; }
    }

    public class Root
    {
        public List<Item> items { get; set; }
        public int count { get; set; }
    }


}