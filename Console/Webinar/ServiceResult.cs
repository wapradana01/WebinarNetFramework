using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webinar
{
    public class ServiceResult
    {
        public ServiceResult(ServiceResultCode resultCode, string? message = null)
        {
            switch (resultCode)
            {
                case ServiceResultCode.Ok:
                    OK(message);
                    break;

                case ServiceResultCode.BadRequest:
                    BadRequest(message);
                    break;

                case ServiceResultCode.UnAuthorized:
                    UnAuthorized(message);
                    break;

                case ServiceResultCode.Forbidden:
                    Forbidden(message);
                    break;

                case ServiceResultCode.NotFound:
                    NotFound(message);
                    break;

                case ServiceResultCode.TimeOut:
                    TimeOut(message);
                    break;

                case ServiceResultCode.Error:
                    Error(message);
                    break;

                default:
                    break;
            }
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Code { get; set; }
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public object Obj { get; set; }

        #region Public Methods
        public void OK(string? message)
        {
            Code = (int)ServiceResultCode.Ok;
            Succeeded = true;
            Message = message ?? string.Empty;
        }
        public void BadRequest(string? message)
        {
            Code = (int)ServiceResultCode.BadRequest;
            Succeeded = false;
            Message = message ?? string.Empty;
        }
        public void UnAuthorized(string? message)
        {
            Code = (int)ServiceResultCode.UnAuthorized;
            Succeeded = false;
            Message = message ?? string.Empty;
        }
        public void Forbidden(string? message)
        {
            Code = (int)ServiceResultCode.Forbidden;
            Succeeded = false;
            Message = message ?? string.Empty;
        }
        public void NotFound(string? message)
        {
            Code = (int)ServiceResultCode.NotFound;
            Succeeded = false;
            Message = message ?? string.Empty;
        }
        public void TimeOut(string? message)
        {
            Code = (int)ServiceResultCode.TimeOut;
            Succeeded = false;
            Message = message ?? string.Empty;
        }
        public void Error(string? message)
        {
            Code = (int)ServiceResultCode.Error;
            Succeeded = false;
            Message = message ?? string.Empty;
        }
        #endregion
    }
}
