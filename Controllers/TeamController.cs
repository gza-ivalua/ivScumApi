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
    public class TeamController : ControllerBase
    {
        private DatabaseContext _context;
        private IHttpContextAccessor _contextAccessor;   
        private readonly ILogger<UserController> _logger;

        public TeamController(ILogger<UserController> logger, 
        DatabaseContext context, 
        IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _context = context;
            _contextAccessor = contextAccessor;
        }        
        [HttpGet]
        public ActionResult GetTeams()
        {
            try{
                return Ok(_context.Teams);
            }
            catch(Exception e){
                _logger.LogError(e.ToString());
                return null;
            }
        }
        [HttpPost]        
        public ActionResult UpdateTeam([FromForm] Models.Team data)
        {
            try{                                       
                if (data.Id == null){
                    data.Id = Guid.NewGuid();
                    var u = _context.Teams.Add(data).Entity;
                    _context.SaveChanges();   
                    return Ok(u);               
                }
                else{
                    _context.Teams.Update(data);                   
                    _context.SaveChanges();
                }
                return Ok(data);
            }
            catch(Exception e){
                _logger.LogError(e.ToString());
                return null;
            }
        }                 
    }
}
