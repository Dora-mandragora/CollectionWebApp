using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionWebApp.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }       
        public string Description { get; set; }
        public byte[] Image { get; set; }  

        public User User { get; set; }
        public Topic Topic { get; set; }

        public ICollection<Item> Items { get; set; } 
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Collection Collection { get; set; }
        public ItemHistory ItemHistory { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }

    public class Comment
    {
        public int Id { get; set; }
        public int FromUser { get; set; }
        public string Content { get; set; }

        public Item Item { get; set; }
    }

    public class Like
    {
        public int Id { get; set; }
        public int FromUser { get; set; }
        
        public Item Item { get; set; }
    }

    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Collection> Collections { get; set; }
    }

    public class ItemHistory
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        public User User { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
