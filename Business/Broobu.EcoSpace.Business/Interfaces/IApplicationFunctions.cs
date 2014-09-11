namespace Broobu.EcoSpace.Business.Interfaces
{
    public interface IApplicationFunctions : IApplicationFunction
    {
        void RegisterRequiredDomainObjects();
        ApplicationFunction RootFolder { get; }
        ApplicationFunction UnRegisteredFolder { get;}
        ApplicationFunction CommunityFolder { get;}
    }
}
