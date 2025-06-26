namespace PostSystem.Entities;

class Post
{
    public DateTime Moment { get; set; } = DateTime.Now;
    public string Title { get; set; }
    public string Content { get; set; }
    public int Likes { get; set; } = 0;
    public List<Comment> Comments { get; set; } = new List<Comment>();

    public Post(string title, string content)
    {
        Title = title;
        Content = content;
    }
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }
    public void RemoveComment(Comment comment)
    {
        Comments.Remove(comment);
    }
    public void Like()
    {
        Likes++;
    }
    public override string ToString()
    {
        return $"{Title}\n{Content}\nLikes: {Likes}\nComments:\n" +
               string.Join("\n", Comments.Select(c => c.Text));
    }
}