
namespace Hospital_Managment.Models
{
    public class Billings
    {
        public int BId { get; set; }
        public string PName { get; set; }
        public string PGender { get; set; }
        public string PCause { get; set; }
        public string DName { get; set; }
        public string DSpecs { get; set; }
        public string HName { get; set; }
        public string HAddress { get; set; }
        public string HPhone { get; set; }

        public int BAmount { get; set; }
        public string BMode { get; set; }
    }
}
