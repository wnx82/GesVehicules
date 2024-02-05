using GesVehicules.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace GesVehicules.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class VehiculeController : ControllerBase
	{
		private readonly Database dbSession;

		public VehiculeController(Database db)
		{
			this.dbSession = db;
		}

		// GetAll
		[HttpGet]
		[AllowAnonymous]
		public IActionResult GetAll()
		{
			try
			{
				var vehicules = this.dbSession.Vehicules.ToList();
				return StatusCode(StatusCodes.Status200OK, vehicules);
			}
			catch (SqlNullValueException ex)
			{
				// Créez un objet contenant l'information d'erreur
				var errorResponse = new
				{
					message = "Une erreur s'est produite lors de la récupération des données.",
					exception = ex.ToString() // Ceci inclut le message et la trace de la pile
				};

				// Renvoie l'objet comme réponse JSON avec un code d'état 500
				return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
			}
		}


		// Ajout d'une vehicule
		[HttpPost]
		[AllowAnonymous]
		public IActionResult Add([FromBody] Vehicule vehicule)
		{
			if (vehicule != null)
			{
				this.dbSession.Vehicules.Add(vehicule);
				this.dbSession.SaveChanges();

				return StatusCode(StatusCodes.Status200OK, null);
			}
			else
			{
				// La vehicule est null, vous pouvez retourner un code d'erreur approprié
				return StatusCode(StatusCodes.Status400BadRequest, "Vehicule is null.");
			}
		}


		// Modification d'une vehicule
		[HttpPost]
		[AllowAnonymous]
		public IActionResult Update(Vehicule updatedVehicule)
		{
			var vehicule = dbSession.Vehicules.Find(updatedVehicule.Id);

			if (vehicule == null)
			{
				return NotFound("Vehicule not found.");
			}

			//vehicule = updatedVehicule;


			vehicule.Marque = updatedVehicule.Marque;
			vehicule.Modèle = updatedVehicule.Modèle;
			vehicule.Immatriculation = updatedVehicule.Immatriculation;
			vehicule.CreatedAt = updatedVehicule.CreatedAt;
			vehicule.UpdatedAt = updatedVehicule.UpdatedAt;
			vehicule.DeletedAt = updatedVehicule.DeletedAt;


			this.dbSession.Vehicules.Update(vehicule);
			this.dbSession.SaveChanges();
			return StatusCode(StatusCodes.Status200OK, null);
		}

		// Effacer une vehicule
		[HttpPost]
		[AllowAnonymous]
		public IActionResult Delete(Vehicule art)
		{
			try
			{
				var vehicule = this.dbSession.Vehicules.Find(art.Id);

				if (vehicule == null)
				{
					return StatusCode(StatusCodes.Status404NotFound, "Vehicule not found.");
				}

				this.dbSession.Vehicules.Remove(vehicule);
				this.dbSession.SaveChanges();

				return StatusCode(StatusCodes.Status200OK, null);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, "Impossible d'effacer ce vehicule");
			}
		}




	}
}