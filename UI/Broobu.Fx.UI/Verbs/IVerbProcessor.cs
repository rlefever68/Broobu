namespace Broobu.Fx.UI.Verbs
{
    public interface IVerbProcessor
    {
        ResponseInfo ProcessVerb(object sender, VerbInfo info);
    }
}