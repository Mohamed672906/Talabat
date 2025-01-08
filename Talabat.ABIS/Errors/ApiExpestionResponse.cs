namespace Talabat.ABIS.Errors
{
    public class ApiExpestionResponse : ApiResponce
    {

        public string? Details { get; set; }

        public ApiExpestionResponse(int StatusCode , string? Message = null , string? details =null):base(StatusCode , Message)
        {
            Details = details;

        }





    }
}
