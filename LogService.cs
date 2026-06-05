using mtkclient;
using System;
using System.Text;

public class LogService
{
    private object logs;

    private StringBuilder StrBuilder;

    private Action<Status, string, bool> writer;

    private Action cleaner;

    public enum Status
    {
        NORMAL,
        ERROR,
        SUCCESS
    }

    public void Logger() { }

    public Action<Status, string, bool> WriteLog
    {
        get { return writer; }
        set { writer = value; }
    }

    public Action ClearLog
    {
        get { return cleaner; }
        set { cleaner = value; }
    }

    public StringBuilder FullLog => StrBuilder;

    public LogService()
    {
        logs = new object();
        StrBuilder = new StringBuilder();
    }

    public void Write(string format, Status status, bool newline = true, params object[] args)
    {
        if (args == null)
        {
            args = new object[0];
        }
        WriteLog?.Invoke(status, string.Format(format, args), newline);
        lock (logs)
        {
            StrBuilder.AppendFormat(format, args);
        }
    }

    public void Clear()
    {
        StrBuilder.Clear();
        ClearLog?.Invoke();
    }

    public static void Information(string msg)
    {
        Main.SharedUI.log.Invoke(
            new Action(() =>
            {
                Main.SharedUI.log.AppendText(msg + Environment.NewLine);
            })
        );
    }

    public static void Information(string msg, string inf)
    {
        Main.SharedUI.log.Invoke(
            new Action(() =>
            {
                Main.SharedUI.log.AppendText(string.Format(msg, inf) + Environment.NewLine);
            })
        );
    }

    public static void Information(string msg, int num)
    {
        Main.SharedUI.log.Invoke(
            new Action(() =>
            {
                Main.SharedUI.log.AppendText(string.Format(msg, num) + Environment.NewLine);
            })
        );
    }

    public static void Information(string msg, uint num)
    {
        Main.SharedUI.log.Invoke(
            new Action(() =>
            {
                Main.SharedUI.log.AppendText(string.Format(msg, num) + Environment.NewLine);
            })
        );
    }

    public static void Information(string msg, long num)
    {
        Main.SharedUI.log.Invoke(
            new Action(() =>
            {
                Main.SharedUI.log.AppendText(string.Format(msg, num) + Environment.NewLine);
            })
        );
    }

    public static void Information(string msg, long num, long l)
    {
        Main.SharedUI.log.Invoke(
            new Action(() =>
            {
                Main.SharedUI.log.AppendText(string.Format(msg, num, l) + Environment.NewLine);
            })
        );
    }

    public static void Information(string msg, uint num, byte b)
    {
        Main.SharedUI.log.Invoke(
            new Action(() =>
            {
                Main.SharedUI.log.AppendText(string.Format(msg, num, b) + Environment.NewLine);
            })
        );
    }

    public static void Information(string msg, uint num, byte[] bs)
    {
        Main.SharedUI.log.Invoke(
            new Action(() =>
            {
                Main.SharedUI.log.AppendText(string.Format(msg, num, bs) + Environment.NewLine);
            })
        );
    }

    public static void Information(string msg, int num, long l, ushort u)
    {
        Main.SharedUI.log.Invoke(
            new Action(() =>
            {
                Main.SharedUI.log.AppendText(string.Format(msg, num, l, u) + Environment.NewLine);
            })
        );
    }

    public static void Information(string msg, string str, int num, long l, long a)
    {
        Main.SharedUI.log.Invoke(
            new Action(() =>
            {
                Main.SharedUI.log.AppendText(
                    string.Format(msg, str, num, l, a) + Environment.NewLine
                );
            })
        );
    }
}
