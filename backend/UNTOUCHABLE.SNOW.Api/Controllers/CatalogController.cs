using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Untouchable.Snow.Domain.Catalog;
using Untouchable.Snow.Data;
using Microsoft.EntityFrameworkCore;

namespace Untouchable.Snow.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CatalogController : ControllerBase
	{
		private readonly StoreContext _db;

		public CatalogController(StoreContext db)
		{
			_db = db;
		}

		[HttpGet("{id:int}")]
		public IActionResult GetItem(int id)
		{
			var item = _db.Items.Find(id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok();
		}

		[HttpPost]
		public IActionResult Post(Item item)
		{
    		_db.Items.Add(item);
			_db.SaveChanges();
			return Created($"/catalog/{item.Id}", item);
		}

		[HttpPost("{id:int}/Ratings")]
		public IActionResult PostRating(int id, [FromBody] Rating rating)
		{
    		var item =  _db.Items.Find(id);
			if (item == null)
			{
				return NotFound();
			}

			item.AddRating(rating);
			_db.SaveChanges();

    		return Ok(item);
		}

		[HttpPost("{id:int}")]
		public IActionResult PutItem(int id, [FromBody] Item item)
		{
   			 if (id != item.Id)
			{
				return BadRequest();
			}

			if (_db.Items.Find(id) == null)
			{
				return NotFound();
			}
			
			_db.Entry(item).State = EntityState.Modified;
			_db.SaveChanges();

			return NoContent(); 
		}

		[HttpDelete]
		public IActionResult DeleteItem(int id)
		{
    		var item = _db.Items.Find(id);
			if (item == null)
			{
				return NotFound();
			}
			
			_db.Items.Remove(item);
			_db.SaveChanges();
			
			return Ok();
		}
	}
}
