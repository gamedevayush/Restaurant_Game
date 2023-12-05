using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateChannel();
        //SendNotification();
    }
    void CreateChannel()
    {
        var c = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Channel_Name",
            Importance = Importance.Default,
            Description = "Notification",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(c);
    }
    void SendNotification()
    {
        var notification = new AndroidNotification();
        notification.Title = "Customers are Waiting..";
        notification.Text = "Mann Nahi hai Restaurant kholne ka?? Please Open the Shop";
        notification.FireTime = System.DateTime.Now.AddSeconds(2);
        AndroidNotificationCenter.SendNotification(notification, " channel_id");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
