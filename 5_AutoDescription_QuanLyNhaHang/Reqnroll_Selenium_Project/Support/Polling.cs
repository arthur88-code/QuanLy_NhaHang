using NUnit.Framework;

namespace AutoTest.Support;

internal static class Polling
{
    public static async Task UntilAsync(
        Func<Task<bool>> condition,
        string message,
        int timeoutSeconds = 30)
    {
        var deadline = DateTime.UtcNow.AddSeconds(timeoutSeconds);
        Exception? lastError = null;

        while (DateTime.UtcNow < deadline)
        {
            try
            {
                if (await condition())
                {
                    return;
                }
            }
            catch (Exception error)
            {
                lastError = error;
            }

            await Task.Delay(500);
        }

        Assert.Fail(lastError is null ? message : $"{message}. Last error: {lastError.Message}");
    }
}
