namespace Amelia.WebApp.Models
{
    public class GenericResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public static GenericResult Ok(string message)
        {
            return Generate(false,message);
        }

        public static GenericResult Failure(string message)
        {
            return Generate(false,message);
        }

        private static GenericResult Generate(bool isSucceded,string message){
            var result = new GenericResult
            {
                Succeeded = isSucceded,
                Message = message
            };

            return result;
        }

    }
}