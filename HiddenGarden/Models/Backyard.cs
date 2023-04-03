namespace HiddenGarden.Models
{
  public class Backyard
  {
    public int BackyardId { get; set; }
    public string Service { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public string Instructions { get; set; }
  }
}