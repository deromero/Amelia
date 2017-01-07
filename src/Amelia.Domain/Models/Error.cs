using System;

namespace Amelia.Domain.Models
{
    public class Error : IEntityBase
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }

        public static Error FromException(Exception exception)
        {
            if (exception == null) throw new ArgumentNullException(nameof(exception));

            var error = new Error(){
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                DateCreated = DateTime.Now
            };

            return error;

        }
    }
}