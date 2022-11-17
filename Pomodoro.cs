namespace Pomodoro
{
    internal class Pomodoro
    {


        private int _workDuration;
        private int _restDuration;
        private string _workStart;
        private string _workStop;
        private string _restStart;
        private string _restStop;
        private List<string> _workStartLogs = new ();
        private List<string> _workStopLogs = new ();
        private List<string> _restStartLogs = new();
        private List<string> _restStopLogs = new ();

        private void AddTimeLogs()
        {
            _restStartLogs.Add(_restStart);
            _restStopLogs.Add(_restStop);
            _workStartLogs.Add(_workStart);
            _workStopLogs.Add(_workStop);
        }
        public void PomodoroRule()
        {
            Console.WriteLine("Enter Work Duration In Minutes");
            var workDurationInput = Console.ReadLine();
            Console.WriteLine("Enter Rest Duration In Minutes");
            var restDurationInput = Console.ReadLine();
            Pomodoro pomodoro = new();

            if (int.TryParse(workDurationInput, out pomodoro._workDuration) && int.TryParse(restDurationInput, out pomodoro._restDuration))

            {


                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.CursorVisible = false;
                var workTime = new DateTime(2000, 1, 1, 0, pomodoro._workDuration, 0);
                var restTime = new DateTime(2000, 1, 1, 0, pomodoro._restDuration, 0);


                void WorkPomodoro()
                {
                    DateTime WorkStartTime = DateTime.Now;
                    pomodoro._workStart = WorkStartTime.ToLongTimeString();

                    for (int i = 0; i <= pomodoro._workDuration * 60; i++)
                    {
                        Console.Write("Work Time Remains : {0}", workTime.ToString("mm:ss"));
                        workTime = workTime.AddSeconds(-1);
                        Thread.Sleep(1000);
                        Console.Clear();
                    }

                    DateTime WorkStopTime = DateTime.Now;
                    pomodoro._workStop = WorkStopTime.ToLongTimeString();
                    Console.WriteLine("Work Time Over");
                    Console.WriteLine("Rest Time Starts");

                    Thread.Sleep(2000);
                    Console.Clear();
                }
                WorkPomodoro();
                void RestPomodoro()
                {
                    DateTime RestStartTime = DateTime.Now;
                    pomodoro._restStart = RestStartTime.ToLongTimeString();
                    for (int i = 0; i <= pomodoro._restDuration * 60; i++)
                    {
                        Console.Write("Rest Time Remains : {0}", restTime.ToString("mm:ss"));
                        restTime = restTime.AddSeconds(-1);
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    DateTime RestStopTime = DateTime.Now;
                    pomodoro._restStop = RestStopTime.ToLongTimeString();
                   
                    AddTimeLogs();
                    Console.WriteLine("Rest Time Over, Press Y to start over or any other key to terminate");
                    var Option = Console.ReadLine().ToUpper();
                    
                    if (Option == "Y")
                    {
                        RestartPomodoro();
                    }
                    else
                    {
                        DisplayLogs();
                        return;
                    }
                   
                }

                RestPomodoro();
            }
            else
            {
                Console.WriteLine("Wrong Input Format!!!");
                RestartPomodoro();
            }

          
        }
      
        private void DisplayLogs()
        {
            for (int i = 0; i < _workStartLogs.Count; i++)
            {
                
                Console.WriteLine($"{i} : Started work at {_workStartLogs[i]} ");
                Console.WriteLine($"{i} : Stoped work at {_workStopLogs[i]} ");
                Console.WriteLine($"{i} : Started rest at {_restStartLogs[i]} ");
                Console.WriteLine($"{i} : Stoped rest at {_restStopLogs[i]} ");
            }
        }
       private void RestartPomodoro()
        {
            PomodoroRule();
        }
    }
}
