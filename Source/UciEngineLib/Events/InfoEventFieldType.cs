using System.ComponentModel;

namespace UciEngineLib.Events
{
    public enum InfoEventFieldType
    {
        [Description("depth")]
        Depth,

        [Description("seldepth")]
        SelDepth,

        [Description("time")]
        Time,

        [Description("nodes")]
        Nodes,

        [Description("pv")]
        Pv,

        [Description("multipv")]
        MultiPv,

        [Description("score")]
        Score,

        [Description("currmove")]
        CurrMove,

        [Description("currmovenumber")]
        CurrMoveNumber,

        [Description("hashfull")]
        HashFull,

        [Description("nps")]
        Nps,

        [Description("tbhits")]
        TbHits,

        [Description("cpuload")]
        CpuLoad,

        [Description("string")]
        String,

        [Description("refutation")]
        Refutation,

        [Description("currline")]
        CurrLine,

        [Description("idle")]
        Idle
    }
}
