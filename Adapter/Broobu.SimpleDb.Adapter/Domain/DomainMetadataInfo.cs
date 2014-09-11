namespace Iris.SimpleDb.Adapter.Domain
{
    public class DomainMetadataInfo : SimpleDbDomainObject<DomainMetadataInfo>
    {
        protected override System.Collections.Generic.ICollection<string> Validate()
        {
            return null;
        }

        protected override string Validate(string columnName)
        {
            return null;
        }

        public string DomainName { get; set; }
        public string ItemCount { get; set; }
        public string ItemNamesSizeBytes { get; set; }
        public string AttributeNameCount { get; set; }
        public string AttributeNamesSizeBytes { get; set; }
        public string AttributeValueCount { get; set; }
        public string AttributeValuesSizeBytes { get; set; }
        public string Timestamp { get; set; }


    }
}
