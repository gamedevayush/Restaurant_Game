using UnityEngine;
using Unity.Notifications.Android;

public class NotificationScript : MonoBehaviour
{
    void Start()
    {
        CreateNotificationChannel();
    }

    void CreateNotificationChannel()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "game_notifications",
            Name = "Game Notifications",
            Importance = Importance.High,
            Description = "Game reminders and updates",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    void ScheduleNotification()
    {
        var notification = new AndroidNotification()
        {
            Title = "Your Customers are Waiting!",
            Text = "The restaurant is empty! Come back and keep your business running! 🍽",
            FireTime = System.DateTime.Now.AddHours(10)
    };

        AndroidNotificationCenter.SendNotification(notification, "game_notifications");
    }

    void OnApplicationQuit()
    {
        ScheduleNotification(); // Set notification when player quits the game
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) // Set notification when game goes to background
        {
            ScheduleNotification();
        }
    }
}
