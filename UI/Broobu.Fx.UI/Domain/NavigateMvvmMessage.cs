namespace Broobu.Fx.UI.Domain
{
    public class NavigateMvvmMessage : IViewNameMessage
    {
        public string Header { get; set; }
        public object Parameter { get; set; }
        public string ViewName { get; set; }
    }
}