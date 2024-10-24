namespace Fire_Emblem.Utils;

public static class ListExtensions
{
    public static void SoftAppend(this List<string> list, params string?[] items)
    {
        foreach (string? item in items)
        {
            if (!string.IsNullOrEmpty(item))
            {
                list.Add(item);
            }
        }
    }
    public static void AddManyLogs(this List<string> list, params string[][] logsList)
    {
        foreach (string[] logs in logsList)
        {
            list.AddRange(logs);
        }
    }

    public static List<string> ReplaceName(this List<string> list, string name)
        => list.Select((message) => message.Replace("@", name)).ToList();

    public static string[] ReplaceMessage(this string[] list, string text)
        => list.Select((message) => message.Replace("#", text)).ToArray();
}