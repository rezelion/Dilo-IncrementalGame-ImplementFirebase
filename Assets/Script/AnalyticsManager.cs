using Firebase.Analytics;
public class AnalyticsManager
{
    private static void LogEvent(string eventName,params Parameter[] parameters)
    {
        //Method utama untuk menembakkan Firebase
        FirebaseAnalytics.LogEvent(eventName, parameters);
    }

    public static void LogUpgradeEvent(int resIndex, int lvl)
    {
        // Kita memakai Event dan Parameter yang tersedia di Firebase (tidak memakai yang custom)
        // agar dapat muncul sebagai report data di Analytics Firebase
        LogEvent(
            FirebaseAnalytics.EventLevelUp,
            new Parameter(FirebaseAnalytics.ParameterIndex,resIndex.ToString()),
            new Parameter(FirebaseAnalytics.ParameterLevel,lvl)
            );
        // Karena resourceIndex digunakan sebagai ID, maka seharusnya kita menyimpannya
        // sebagai string bukan integer
    }
    public static void LogUnlockEvent(int resIndex)
    {
        LogEvent(
            FirebaseAnalytics.EventUnlockAchievement,
            new Parameter(FirebaseAnalytics.ParameterIndex, resIndex.ToString())
        );
    }
    public static void SetUserProperties(string name, string value)
    {
        FirebaseAnalytics.SetUserProperty(name, value);
    }
}
