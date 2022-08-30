using Microsoft.AspNetCore.Mvc;
using SendEmailAPI.Entities;
using SendEmailAPI.Models;
using SendEmailAPI.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendEmailAPI.Controllers
{
    [ApiController]
    [Route("api/packages")]
    public class PackagesController : ControllerBase
    {
        private readonly EmailContext _context;

        public PackagesController(EmailContext context)
        {
            _context = context;
        }

        // GET api/packages
        [HttpGet]
        public IActionResult GetAll()
        {
            var packages = _context.Packages;

            return Ok(packages);
        }

        // GET api/packages/{code}
        [HttpGet("{code}")]
        public IActionResult GetByCode(string code)
        {
            var package = _context
                .Packages
                .SingleOrDefault(d => d.Code == code);

            if(package == null)
            {
                return NotFound();
            }

            return Ok(package);
        }

        // POST api/packages
        [HttpPost]
        public IActionResult Post(AddPackageInputModel model)
        {
            if(model.Title.Length < 10)
            {
                return BadRequest("Type length must be at 10 characters long");
            }

            var package = new Package(model.Title, model.Weight);
            _context.Packages.Add(package);

            return CreatedAtAction(
                "GetByCode", new { code = package.Code},
                package
                );
        }

        // POST api/packages/{code}/updates
        [HttpPost("{code}/updates")]
        public IActionResult PostUpdate(string code, AddPackageUpdateInputModel model)
        {
            var package = _context
            .Packages
            .SingleOrDefault(d => d.Code == code);

            if(package == null)
            {
                return NotFound();
            }

            package.AddUpdate(model.Status, model.Delivered);

            return NoContent();
        }
    }
}
