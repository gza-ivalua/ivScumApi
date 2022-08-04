using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IvScrumApi.Models;
using Microsoft.AspNetCore.Http;
namespace IvScrumApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private DatabaseContext _context;
        private IHttpContextAccessor _contextAccessor;   
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, 
        DatabaseContext context, 
        IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _context = context;
            _contextAccessor = contextAccessor;
        }

        //Get or create a new user if not exists
        [HttpPost]
        public ActionResult Get([FromForm] User arg)
        {                                    
            bool exists = _context.Users.Any(u => u.Email == arg.Email);
            if (!exists) {                
                _logger.LogWarning("not exists");
                _context.Users.Add(arg);
                _context.SaveChanges();
                _logger.LogInformation(arg.ToString());
            }
            else{
                User u = _context.Users.First(u => u.Email == arg.Email);
                _logger.LogInformation(u.ToString());
                u.PictureUrl = arg.PictureUrl;
                _context.Users.Update(u);
                _context.SaveChanges();
                return Ok(u.Id);
            }
            return Ok(arg.Id);    
        }         
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetUser(Guid id)
        {
            try{
                return Ok(_context.Users.First(u => u.Id == id));
            }
            catch(Exception e){
                _logger.LogError(e.ToString());
                return null;
            }
        }        
        [HttpGet]
        [Route("/team/{teamId}")]
        public ActionResult GetUsers(Guid teamId)
        {
            try{
                return Ok(_context.Users.Where(u => u.Team == teamId));
            }
            catch(Exception e){
                _logger.LogError(e.ToString());
                return null;
            }
        }          
    }
}
