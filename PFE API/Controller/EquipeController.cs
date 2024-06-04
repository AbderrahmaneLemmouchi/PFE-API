
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFE_API.Database_Controllers;
using PFE_API.DTO;
using PFE_API.Model;
using System.Security.Claims;



namespace PFE_API.Controller
{

    [ApiController]
    [Route("[controller]")]
    public class EquipeController : ControllerBase
    {


        [Authorize(Roles = "RH")]//(Roles = "RH,Resposable")]
        [HttpGet("GetEquipes")]
        public IActionResult GetEquipes()
        {
            return Ok(EquipeDbController.GetEquipes());
        }
/*
        [HttpPost]
        //[Authorize(Roles = "RH")]
         public IActionResult InsertEquipe(
                 int id,

             string nom,
             string resp,
             int rattachee

             )
         {
             var equipe = new Equipe
             {
                 IDEquipe = id,
                 NomEquipe = nom,
                 Responsable = resp,
                 rattache = rattachee,


             };

         }
        
*/






    } 
}
