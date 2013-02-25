namespace ChessBombDetector.UciInfoEventFields
{
  [UciFieldId("multipv")]
  public class MultiPvField : UciInfoEventField
    {
        public int Rank { get; set; }
    }
}
