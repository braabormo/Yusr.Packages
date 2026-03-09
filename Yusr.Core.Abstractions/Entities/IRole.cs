namespace Yusr.Core.Abstractions.Entities
{
    public interface IRole
    {
        public string Name { get; set; }
        public IEnumerable<string> Permissions { get; set; }
    }
}
