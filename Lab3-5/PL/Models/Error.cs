using System.Net;
namespace PL.Models
{
    public class Error
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Error(string m, HttpStatusCode http)
        {
            Status = http.ToString();
            Message = m;
        }
    }
}
