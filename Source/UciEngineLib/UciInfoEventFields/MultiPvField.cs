namespace ChessBombDetector.UciInfoEventFields
{
    public class MultiPvField : UciInfoEventField
    {
        public int Rank { get; set; }

        public override string Id
        {
            get { return "multipv"; }
        }
    }
}
