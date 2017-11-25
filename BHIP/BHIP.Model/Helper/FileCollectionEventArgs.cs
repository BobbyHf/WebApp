using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHIP.Model.Helper
{
    public class FileCollectionEventArgs : EventArgs
    {
        private HttpRequestBase _HttpRequest;

        public HttpFileCollectionBase PostedFiles
        {
            get
            {
                return _HttpRequest.Files;
            }
        }

        public int Count
        {
            get { return _HttpRequest.Files.Count; }
        }

        public bool HasFiles
        {
            get { return _HttpRequest.Files.Count > 0 ? true : false; }
        }

        public double TotalSize
        {
            get
            {
                double Size = 0D;
                for (int n = 0; n < _HttpRequest.Files.Count; ++n)
                {
                    if (_HttpRequest.Files[n].ContentLength < 0)
                        continue;
                    else
                        Size += _HttpRequest.Files[n].ContentLength;
                }

                return Math.Round(Size / 1024D, 2);
            }
        }

        public FileCollectionEventArgs(HttpRequestBase oHttpRequest)
        {
            _HttpRequest = oHttpRequest;
        }
    }
}