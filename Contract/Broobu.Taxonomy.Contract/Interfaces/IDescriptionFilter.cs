namespace Broobu.Taxonomy.Contract.Interfaces
{
    public interface IDescriptionFilter
    {
        string ObjectId { get; set; }
        string CultureId { get; set; }
        string TypeId { get; set; }
    }
}