namespace trackapi.Model
{
    public class State
    {
        enum States{
            WAITING,
            RUNNING,
            STOPPED
        }

        public int AcelerotometerState {get; set; }
    }
}