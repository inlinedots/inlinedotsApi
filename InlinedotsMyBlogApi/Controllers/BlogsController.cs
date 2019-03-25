using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InlinedotsMyBlogApi.Models.Entities;
using InlinedotsMyBlogApi.Services.Models.Blog;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Globalization;

namespace InlinedotsMyBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly MyBlogContext _context;

        public BlogsController(MyBlogContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get all blogs
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(BlogViewModel), 200)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var blogListDb = await _context.Blog.Include(x => x.Entity).Where(x => x.Entity.Deleted != 1).ToListAsync();
            if (blogListDb == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var userListVM = Mapper.Map<ICollection<Blog>, ICollection<BlogViewModel>>(blogListDb);
            return StatusCode(StatusCodes.Status200OK, userListVM);
        }

        /// <summary>
        /// Get blogs by Id
        /// </summary>

        [ProducesResponseType(typeof(BlogViewModel), 200)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blogDb = await _context.Blog.Include(x => x.Entity)
                .FirstOrDefaultAsync(x => x.Id == id && x.Entity.Deleted != 1);
            if (blogDb == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var blogVM = Mapper.Map<Blog, BlogViewModel>(blogDb);
            return StatusCode(StatusCodes.Status200OK, blogVM);
        }

        ///<summary>
        ///Post a Blog
        /// </summary>
        /// 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BlogViewModel blogVM)
        {
            var newBlog = Mapper.Map<BlogViewModel, Blog>(blogVM);
            _context.Blog.Add(newBlog);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK);
        }
        
        /// <summary>
        /// Update Blog
        /// </summary>

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BlogViewModel), 200)]
        public async Task<IActionResult> Update(int id, [FromBody]BlogPlainModel blogPM)
        {
            var updateBlog = await _context.Blog.Include(x => x.Entity).FirstOrDefaultAsync(x => x.Id == id);
            if (updateBlog == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            Mapper.Map<BlogPlainModel, Blog>(blogPM, updateBlog);

            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK);
        }

        ///<summary>
        ///Delete Post
        /// </summary>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blogDb = await _context.Blog.Include(x => x.Entity)
                .FirstOrDefaultAsync(x => x.Id == id && x.Entity.Deleted != 1);
            if (blogDb == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Blog not found");
            }

            blogDb.Entity.Deleted = 1;
            blogDb.Entity.Updated = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}