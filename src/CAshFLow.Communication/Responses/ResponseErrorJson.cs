namespace CAshFLow.Communication.Responses
{
    public class  ResponseErrorJson
    {
        public  List<string> ErrorMessages { get; set; } 

        public ResponseErrorJson(string errorMessage)
        {
            ErrorMessages = new List<string> { errorMessage };
        }

        public ResponseErrorJson(List<string> erroMessage)
        {
            ErrorMessages = erroMessage;
        }
    }
}
