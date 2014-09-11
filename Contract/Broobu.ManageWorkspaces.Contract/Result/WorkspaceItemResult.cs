using System.Runtime.Serialization;

namespace Pms.ManageWorkspaces.Contract.Result
{
    [DataContract]
    public class WorkspaceItemResult<T> : Framework.Domain.Result
    {
        [DataMember]
        public T Description { get; set; }
        [DataMember]
        public T[] Descriptions { get; set; }
        [DataMember]
        public T Item { get; set; }
        [DataMember]
        public T[] Items { get; set; }
        [DataMember]
        public T[] Property { get; set; }
        [DataMember]
        public T[] Properties { get; set; }
        [DataMember]
        public T Result { get; set; }
        [DataMember]
        public T WorkspaceSource { get; set; }
        [DataMember]
        public T WorkspaceTarget { get; set; }
        [DataMember]
        public string SaveResult { get; set; }
    }
}
