namespace PostSystem;
class Program
{
    static void Main(string[] args)
    {
        var post = new Entities.Post("My First Post", "This is the content of my first post.");
        post.Like();
        post.AddComment(new Entities.Comment("Great post!"));
        post.AddComment(new Entities.Comment("Thanks for sharing!"));

        Console.WriteLine(post);


        post.Like();
        post.Like();
        post.AddComment(new Entities.Comment("I learned a lot from this!"));
        Console.WriteLine(post);
    }
}