namespace SingletonEagerLoading
{
    public class LogMessage
    {
        public string Message { get; set; }
        public LogType LogType { get; set; }
        public DateTime CreatedAt { get; set; }
        public override string ToString() => $"{LogType.ToString().PadLeft(7 , ' ')} [{CreatedAt.ToString("yyyy-MM-dd hh:mm")}] {Message}";
    }
}