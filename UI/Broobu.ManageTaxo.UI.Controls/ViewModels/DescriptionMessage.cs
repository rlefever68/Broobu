using Broobu.Taxonomy.Contract.Interfaces;

namespace Broobu.ManageTaxonomy.UI.Controls.ViewModels
{
    public class DescriptionMessage
    {
        public IDescriptionFilter Filter { get; set; }
        public DescriptionMessageType MessageType { get;set;}
    }
}