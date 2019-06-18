namespace Konvolucio.MCEL181123.Database
{
    using System.Collections.Generic;

    public class MessageCollection : List<MessageItem>
    {
        /*** MCEL181123 Messages ***/
        public const string MSG_MCEL_V_MEAS = "MSG_MCEL_V_MEAS";
        public const byte MSG_MCEL_V_MEAS_ID = 0x01;

        public const string MSG_MCEL_C_MEAS = "MSG_MCEL_C_MEAS";
        public const byte MSG_MCEL_C_MEAS_ID = 0x02;

        public const string MSG_MCEL_STATUS = "MSG_MCEL_STATUS";
        public const byte MSG_MCEL_STATUS_ID = 0x03;

        public const string MSG_MCEL_TEMPS = "MSG_MCEL_TEMPS";
        public const byte MSG_MCEL_TEMPS_ID = 0x04;

        public const string MSG_MCEL_NET_MON = "MSG_MCEL_NET_MON";
        public const byte MSG_MCEL_NET_MON_ID = 0xFE;

        public const string MSG_MCEL_LIVE = "MSG_MCEL_LIVE";
        public const byte MSG_MCEL_LIVE_ID = 0xFF;

        /*** PC Messages ***/
        public const string MSG_PC_CV_SET = "MSG_PC_CV_SET";
        public const byte MSG_PC_CV_SET_ID = 0x10;

        public const string MSG_PC_CC_SET = "MSG_PC_CC_SET";
        public const byte MSG_PC_CC_SET_ID = 0x20;

        public const string MSG_PC_CAILB_SET = "MSG_PC_CAILB_SET";
        public const byte MSG_PC_CAILB_SET_ID = 0x30;

        public const string MSG_PC_NET_TEST = "MSG_PC_NET_TEST";
        public const byte MSG_PC_NET_TEST_ID = 0xE0;



    }
}
