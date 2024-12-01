namespace DamianCA2.Model
{
    public class Article
    {
        public string Title { get; set; } 
        public string Url { get; set; } 
        public Source Sourceinfo { get; set; } 
        public string Description { get; set; }
        public string Author { get; set; }
        public string PublishedAt { get; set; }
        public string Content { get; set; } 
    
        public class Source
        {
            public string Name { get; set; } 
        }
    }
    }