namespace Commander.Dtos
{
    public class CommandReadDto
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; }

        public string Platform { get; set; }

        // we can remove props that we do not want to expose to
        // the user
    }
}