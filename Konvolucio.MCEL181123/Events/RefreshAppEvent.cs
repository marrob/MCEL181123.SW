﻿namespace Konvolucio.MCEL181123.Events
{
    class RefreshAppEvent : IApplicationEvent
    {
        public object Sender { get; private set; } 
        public RefreshAppEvent(object sender)
        {
            Sender = sender;
        }
    }
}
