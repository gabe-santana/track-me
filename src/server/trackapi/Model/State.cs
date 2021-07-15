namespace trackapi.Model
{
    public class State
    {
        enum States{
            RUNNING,
            STOPPED
        }

        public int AceleratometerState {get; set; }
    }
}