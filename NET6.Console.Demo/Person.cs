namespace NET6.Console.Demo.Model
{
    record  struct Person
    {
        public string FirstName { get; init; } = "Jone";
        public string LastName { get; init; } = "Doe";
        public void WriteToFile(string filePath)
            => File.WriteAllText(filePath, this.ToString());
    }
}
