using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassLibraryDataBase;

namespace FinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsDataController : ControllerBase
    {

        private readonly ILogger<MaterialsDataController> _logger;

        public MaterialsDataController(ILogger<MaterialsDataController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Materials")]
        public IEnumerable<Materialss> Get()
        {
            return DistEntities.GetContext().Materialss.ToList();
        }


        [HttpGet("GetMaterial/{id}")]
        public Materialss GetMaterial(int id)
        {
            return DistEntities.GetContext().Materialss.FirstOrDefault(x => x.Material_ID == id);
        }
        [HttpPost("material")]
        public ActionResult<Materialss> Post(Materialss material)
        {
            material.Material_ID = DistEntities.GetContext().Materialss.Max(p => p.Material_ID) + 1;
            DistEntities.GetContext().Materialss.Add(material);
            DistEntities.GetContext().SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = material.Material_ID }, material);
        }

        [HttpPut("ChangeMterial/{id}")]
        public IActionResult Put(int id, Materialss material)
        {
            var existing = DistEntities.GetContext().Materialss.FirstOrDefault(p => p.Material_ID == id);
            if (existing == null) return NotFound();

            existing.Material_Name = material.Material_Name;
            existing.Material_Cost = material.Material_Cost;
            DistEntities.GetContext().SaveChanges();

            return NoContent();
        }

        [HttpDelete("DeleteMaterial/{id}")]
        public IActionResult Delete(int id)
        {
            var material = DistEntities.GetContext().Materialss.FirstOrDefault(p => p.Material_ID == id);
            if (material == null) return NotFound();

            DistEntities.GetContext().Materialss.Remove(material);
            DistEntities.GetContext().SaveChanges();
            return NoContent();
        }
    }
}
