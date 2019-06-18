namespace Konvolucio.MCEL181123.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class SignalCollection : List<SignalItem>
    {
        /*** Tx By MCEL181123 ***/
        public const string SIG_MCEL_V_MEAS = "SIG_MCEL_V_MEAS";
        public const string SIG_MCEL_C_MEAS = "SIG_MCEL_C_MEAS";
        public const string SIG_MCEL_C_RANGE = "SIG_MCEL_C_RANGE";
        public const string SIG_MCEL_OE_STATUS = "SIG_MCEL_OE_STATUS";
        public const string SIG_MCEL_CV_STATUS = "SIG_MCEL_CV_STATUS";
        public const string SIG_MCEL_CC_STATUS = "SIG_MCEL_CC_STATUS";
        public const string SIG_MCEL_UC_TEMP = "SIG_MCEL_UC_TEMP";
        public const string SIG_MCEL_TR_TEMP = "SIG_MCEL_TR_TEMP";

        public const string SIG_MCEL_RXERRCNT = "SIG_MCEL_RXERRCNT";
        public const string SIG_MCEL_TXERRCNT = "SIG_MCEL_TXERRCNT";
        public const string SIG_MCEL_RXTESTCNT = "SIG_MCEL_RXTESTCNT";
        public const string SIG_MCEL_UPTIME = "SIG_MCEL_RUN_TIME_TICK";
        public const string SIG_MCEL_VERSION = "SIG_MCEL_VERSION";

        /*** Tx By PC ***/
        public const string SIG_PC_CV_SET = "SIG_PC_CV_SET";
        public const string SIG_PC_CC_SET = "SIG_PC_CC_SET";
        public const string SIG_PC_C_MEAS_RNG_SET = "SIG_PC_C_MEAS_RNG_SET";
        public const string SIG_PC_CLB_MD_SET = "SIG_PC_CLB_MD_SET";
        public const string SIG_PC_INC_RX_CNT_TRG = "SIG_PC_INC_RX_CNT_TRG";

    }
}
