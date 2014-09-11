using System;
using System.ServiceModel.Discovery;

namespace Broobu.Engine.Service
{
    sealed class OnResolveAsyncResult : AsyncResultBase
    {
        EndpointDiscoveryMetadata matchingEndpoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="OnResolveAsyncResult"/> class.
        /// </summary>
        /// <param name="matchingEndpoint">The matching endpoint.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        public OnResolveAsyncResult(EndpointDiscoveryMetadata matchingEndpoint, AsyncCallback callback, object state)
            : base(callback, state)
        {
            this.matchingEndpoint = matchingEndpoint;
            this.Complete(true);
        }
    

        /// <summary>
        /// Ends the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        public static EndpointDiscoveryMetadata End(IAsyncResult result)
        {
            OnResolveAsyncResult thisPtr = AsyncResultBase.End<OnResolveAsyncResult>(result);
            return thisPtr.matchingEndpoint;
        }
    }


}
