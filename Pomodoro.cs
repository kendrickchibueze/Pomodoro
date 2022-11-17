namespace Pomodoro
{
    internal class Pomodoro
    {


        private int _workDuration;
        private int _restDuration;

      

        private List<string> _workStartLogs = new();
        private List<string> _workStopLogs = new();
        private List<string> _restStartLogs = new();
        private List<string> _restStopLogs = new();


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
                
                var workTime = new DateTime(2000, 1, 1, 0, pomodoro._workDuration, 0);
                var restTime = new DateTime(2000, 1, 1, 0, pomodoro._restDuration, 0);


                void WorkPomodoro()
                {

                    DateTime WorkStartTime = DateTime.Now;
                    string workStart = Convert.ToString(WorkStartTime);
                    _workStartLogs.Add($"Started working at : {workStart}");
                    Console.CursorVisible = false;
                    for (int i = 0; i <= pomodoro._workDuration * 60; i++)
                    {
                        Console.Write("Work Time Remains : {0}", workTime.ToString("mm:ss"));
                        workTime = workTime.AddSeconds(-1);
                        Thread.Sleep(1000);
                        Console.Clear();
                    }

                    DateTime WorkStopTime = DateTime.Now;
                    string workStop = Convert.ToString(WorkStopTime);
                    _workStopLogs.Add($"Stopped working at : {workStop}");

                    Console.Beep(3276, 2000);
                    Console.WriteLine("Work Time Over");
                    Console.WriteLine("Rest Time Starts");
                    
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                WorkPomodoro();
                void RestPomodoro()
                {
                    DateTime RestStartTime = DateTime.Now;
                    string restStart = Convert.ToString(RestStartTime);
                    _restStartLogs.Add($"Started resting at : {restStart}");

                    Console.CursorVisible = false;
                    for (int i = 0; i <= pomodoro._restDuration * 60; i++)
                    {
                        Console.Write("Rest Time Remains : {0}", restTime.ToString("mm:ss"));
                        restTime = restTime.AddSeconds(-1);
                        Thread.Sleep(1000);
                        Console.Clear();
                    }

                    Console.Beep(3276, 2000);
                    DateTime RestStopTime = DateTime.Now;
                    string restStop = Convert.ToString(RestStopTime);
                    _restStopLogs.Add($"Stopped resting at : {restStop}");

                   
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

                Console.WriteLine($"{i} : {_workStartLogs[i]} ");
                Console.WriteLine($"{i} : {_workStopLogs[i]} ");
                Console.WriteLine($"{i} : {_restStartLogs[i]} ");
                Console.WriteLine($"{i} : {_restStopLogs[i]} ");
            }
            
        }
        

        private void RestartPomodoro() => PomodoroRule();
        
    }
}
