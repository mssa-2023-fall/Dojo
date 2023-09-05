namespace LearnImmutable
{
    public record class SampleRecord(string ParamString, int ParamInt, DateTime ParamDate)
    {
        public string? MutableProperty { get; set; }
    }
    public record class SampleNameRecord(string FirstName, string LastName);
}