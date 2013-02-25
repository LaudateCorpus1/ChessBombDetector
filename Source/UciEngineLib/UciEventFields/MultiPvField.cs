namespace ChessBombDetector.UciInfoEventFields
{
  [UciFieldId("multipv")]
  public class MultiPvField : UciEventField
    {
        public int Rank { get; set; }
    }
}
