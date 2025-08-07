namespace TestProjLebedev.db
{
    public class Dot
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int radius { get; set; }
        public string? color { get; set; }

        //public List<Comment> Comments { get; set; } = new();
        //public Comments? Comments { get; set; }
    }

    public class Comment
    {
        public int id { get; set; }
        public int dotId { get; set; }
        public string? text { get; set; }
        public string? color { get; set; }

        //public Dot? dot { get; set; }
    }
}
