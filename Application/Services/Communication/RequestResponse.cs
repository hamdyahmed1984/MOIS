using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Communication
{
    public class RequestResponse : BaseResponse
    {
        public Request Request { get; private set; }
        private RequestResponse(bool success, string message, Request request) : base(success, message) => Request = request;
        public RequestResponse(Request request):this(true, string.Empty, request) { }
        public RequestResponse(string message) : this(false, message, null) { }
        public RequestResponse(bool success, string message) : this(success, message, null) { }
    }
}
