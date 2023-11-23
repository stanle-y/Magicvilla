﻿using AutoMapper;
using Magicvilla_API.Datos;
using Magicvilla_API.modelos;
using Magicvilla_API.modelos.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Magicvilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public VillaController(ILogger<VillaController>logger,ApplicationDbContext db,IMapper mapper )
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
            
            
        }




        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task < ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            _logger.LogInformation("Obtener las villas");

            IEnumerable<Villa> villalist = await _db.Villas.ToListAsync();

           


            return Ok(_mapper.Map<IEnumerable<VillaDTO>>(villalist));

        }


        [HttpGet("id:int", Name = "Getvilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task< ActionResult<VillaDTO>> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al tarer la villa con id" + id);
                return BadRequest();
            }
            //var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            var villa =  await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);
            
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<VillaDTO>(villa));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task< ActionResult<VillaDTO>> CrearVilla([FromBody] VillaCreateDTO createDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _db.Villas.FirstOrDefaultAsync(v => v.Nombre.ToLower() == createDTO.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "La Villa con ese Nombre ya existes");
                return BadRequest(ModelState);
            }

            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }
            Villa modelo = _mapper.Map<Villa>(createDTO);

            
           
             await _db.Villas.AddAsync(modelo);
             await _db.SaveChangesAsync();

            return CreatedAtRoute("GetVilla", new { id = modelo.Id }, modelo);
            {

            }
            

            



        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteVilla(int id) 
        {
            if(id==0) 
            {
                return BadRequest();

            }
            var villa = await _db.Villas.FirstOrDefaultAsync(v=>v.Id == id);
            if (villa == null) 
            {
                return NotFound();
            }
             _db.Villas.Remove(villa);
             await _db.SaveChangesAsync();
            

            return NoContent();
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <IActionResult> Updatevilla(int id, [FromBody] VillaUpdateDTO updateDTO)
        {
            if(updateDTO==null || id!= updateDTO .Id) 
            {
                return BadRequest();
            }
            
            Villa modelo = _mapper.Map<Villa>(updateDTO);


            _db.Villas.Update(modelo);
             await _db.SaveChangesAsync();

            return NoContent();
                    
        }

    }
}
