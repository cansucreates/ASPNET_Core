using System.ComponentModel.DataAnnotations;

namespace ASPNET_Core.Models
{
    public class Turler
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Lütfen tür adını giriniz.")]
        public string KitapTur { get; set; }

        [Required, Range(1,100), Display(Name = "Türün bulunduğu Raf No")]
        public int RafNo { get; set; }

        public virtual List<Kitaplar> Kitaplars { get; set; } = new List<Kitaplar>(); // bir türün birden fazla kitabı olabilir şeklinde bağlandı
    }
}
