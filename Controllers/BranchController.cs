using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IvScrumApi.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
namespace IvScrumApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BranchController : ControllerBase
    {
        private DatabaseContext _context;
        private IHttpContextAccessor _contextAccessor;   
        private readonly ILogger<UserController> _logger;

        public BranchController(ILogger<UserController> logger, 
        DatabaseContext context, 
        IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _context = context;
            _contextAccessor = contextAccessor;
        }        
        [HttpGet]
        public List<Branch> Get()
        {                                  
            _context.Branches.ToList().ForEach(b => _logger.LogInformation(b.ToString()));
            return _context.Branches.ToList();
        }     
        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(Guid id)
        {
            return Ok(_context.Branches.Where(b => b.Id == id));
        }         
        [HttpPost]
        [Route("new")]
        public ActionResult NewBranch([FromForm] Branch branch)
        {
            try{
                _context.Branches.Add(branch);
                return Ok();
            }
            catch(Exception e){
                _logger.LogError(e.ToString());
                return null;
            }
        }          
    }
}
