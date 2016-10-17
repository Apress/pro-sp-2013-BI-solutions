using System;
using System.Data;
using System.Threading;
using System.Xml;
using System.Web;
using Microsoft.Office.Visio.Server;
using DataModules.WcfDataService;

namespace DataModules
{
    public class VisioDataProviderService : AddonDataHandler, IAsyncResult
    {
        private object _asyncState;
        private bool _completeStatus;

        WaitHandle IAsyncResult.AsyncWaitHandle
        {
            get { return null; }
        }
        object IAsyncResult.AsyncState
        {
            get { return _asyncState; }
        }
        bool IAsyncResult.IsCompleted
        {
            get { return this._completeStatus; }
        }
        bool IAsyncResult.CompletedSynchronously
        {
            get { return false; }
        }
        public override IAsyncResult BeginGetData(HttpContext httpContext, AsyncCallback callback, object asyncState)
        {
            _asyncState = asyncState;
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetData), callback);
            return this;
        }
        public override DataSet EndGetData(IAsyncResult asyncResult)
        {
            return this.Data;
        }
        public override void Cancel()
        {
            // Not implemented
        }
        private void GetData(object state)
        {
            AsyncCallback asyncCallback = (AsyncCallback)state;
            try
            {
                ServerStatusClient oServerStatus = new ServerStatusClient();
                DataTable dt = oServerStatus.GetServerStatusDetails();
                this.Data.Reset();
                this.Data.Tables.Add(dt);
                this.Data.AcceptChanges();
            }
            catch (Exception ex)
            {
                this.Error = new AddonDataHandlerException(ex.Message);
            }
            asyncCallback(this);
            _completeStatus = true;

        }
    }
}
