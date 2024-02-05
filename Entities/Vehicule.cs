using System.ComponentModel.DataAnnotations.Schema;

namespace GesVehicules.Entities
{
	public class Vehicule
	{
        public Guid Id{ get; set; }

		public string? Marque { get; set; }

		public string? Modèle { get; set; }

		public string? Immatriculation { get; set; }

		[Column("CreatedAt")]
		public DateTime? CreatedAt { get; set; }

		[Column("UpdatedAt")]
		public DateTime? UpdatedAt { get; set; }

		[Column("DeletedAt")]
		public DateTime? DeletedAt { get; set; }

	}
}
