namespace Lesson27Task
{
    public class UserJson
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
    }
    public class UserData
    {
        public List<UserJson> Users { get; set; }
    }
}
