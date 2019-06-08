namespace Konvolucio.MCEL181123.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;


    public class MessageCollection : List<MessageItem>
    {
        /*** MCEL181123 Messages ***/
        public const string MSG_MCEL_V_MEAS = "MSG_MCEL_V_MEAS";
        public const string MSG_MCEL_C_MEAS = "MSG_MCEL_C_MEAS";
        public const string MSG_MCEL_STATUS = "MSG_MCEL_STATUS";
        public const string MSG_MCEL_LIVE = "MSG_MCEL_LIVE";

        public const byte MSG_MCEL_V_MEAS_ID = 0x01;
        public const byte MSG_MCEL_C_MEAS_ID = 0x02;
        public const byte MSG_MCEL_STATUS_ID = 0x03;
        public const byte MSG_MCEL_LIVE_ID = 0xFF;

        /*** PC Messages ***/
        public const string MSG_PC_CC_SET = "MSG_PC_CC_SET";
        public const string MSG_PC_CV_SET = "MSG_PC_CV_SET";
    }
}
