namespace BoardGame
{
    public enum ActionStatus
    {
        NONE,
        COMPLETE,
        SUCCESS,
        FAILURE
    }

    public class ActionResult
    {
        public ActionStatus Status { get; set; }

        public ActionResult()
        {
            Status = ActionStatus.NONE;
        }

        public string Message { get; set; }
    }
}
