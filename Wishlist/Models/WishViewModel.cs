namespace Wishlist.Models
{
    public sealed class WishViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public Link[] Links { get; set; } = new Link[0];

        public string Price { get; set; }

        public sealed class Link
        {
            public string Text { get; set; }

            public string Url { get; set; }
        }
    }
}
