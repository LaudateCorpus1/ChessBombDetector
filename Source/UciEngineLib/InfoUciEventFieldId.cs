using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector
{
    enum InfoUciEventFieldId
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

        [Description("sbhits")]
        CpuLoad,

        [Description("string")]
        String,

        [Description("Refutation")]
        Refutation,

        [Description("currline")]
        CurrLine
    }
}
