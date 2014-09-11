using System;

namespace Broobu.Engine.Service
{
    sealed class OnOnlineAnnouncementAsyncResult : AsyncResultBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnOnlineAnnouncementAsyncResult"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        public OnOnlineAnnouncementAsyncResult(AsyncCallback callback, object state)
            : base(callback, state)
        {
            this.Complete(true);
        }

        /// <summary>
        /// Ends the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        public static void End(IAsyncResult result)
        {
            AsyncResultBase.End<OnOnlineAnnouncementAsyncResult>(result);
        }
    }

}
