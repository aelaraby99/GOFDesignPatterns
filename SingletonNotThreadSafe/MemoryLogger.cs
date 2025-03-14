﻿namespace SingletonNotThreadSafe
{
    public class MemoryLogger
    {
        private int _InfoCount;
        private int _WarningCount;
        private int _ErrorCount;
        private List<LogMessage> _logs = new List<LogMessage>();
        private static MemoryLogger? _instance;
        private MemoryLogger()
        {
        }
        public static MemoryLogger GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MemoryLogger();
                }
                return _instance;
            }
        }
        public IReadOnlyCollection<LogMessage> Logs => _logs;
        private void Log( string message , LogType logType )
            => _logs.Add(new LogMessage
            {
                Message = message ,
                LogType = logType ,
                CreatedAt = DateTime.Now ,
            });
        public void LogInfo( string message )
        {
            _InfoCount++;
            Log(message , LogType.INFO);
        }
        public void LogWarning( string message )
        {
            _WarningCount++;
            Log(message , LogType.WARNING);
        }
        public void LogError( string message )
        {
            _ErrorCount++;
            Log(message , LogType.ERROR);
        }
        public void ShowLog()
        {
            _logs.ForEach(x => Console.WriteLine(x));
            Console.WriteLine($"-----------------------------------");
            Console.WriteLine($"Info ({_InfoCount}), Warning ({_WarningCount}), Error ({_ErrorCount})");
        }
    }
}