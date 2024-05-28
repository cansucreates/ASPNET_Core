using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNET_Core.Models
{
    public class Kitaplar
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Lütfen kitap adını giriniz.")]
        public string KitapAdi { get; set; }

        [StringLength(50)]
        public string YazarAdi { get; set; }

        [Required, Range(0,2024, ErrorMessage = "Lütfen 0-2024 arasında bir değer giriniz.")]
        public int BasimYili { get; set; }

        [ForeignKey("Turler")]
        public int TurId { get; set; }
        public virtual Turler Turler { get; set; } // bir kitabın bir türü olabilir şeklinde bağlandı


    }
}
