using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly DataContext _context;
        public BooksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppBook>>> GetUsers()
        {
            var books = await _context.Books.ToListAsync();

            return books;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AppBook>> GetUser(int id)
        {
            var book = await _context.Books.FindAsync(id);

            return book;
        }
    }
}