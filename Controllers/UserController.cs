using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using IvScrumApi.Models;
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
        [Route("team/{teamId}")]
        public ActionResult GetUsers(Guid teamId, bool newUser)
        {
            try{
                var users = _context.Users.Where(u => u.TeamId == teamId);
                if (newUser){
                    _logger.LogError(newUser.ToString());
                    var finalList = users.ToList();
                    finalList.Add(new User(){
                        TeamId = teamId,
                        Id = null
                     });
                    return Ok(finalList);
                }
                return Ok(users);
            }
            catch(Exception e){
                _logger.LogError(e.ToString());
                return null;
            }
        }    
        [HttpPost]        
        public ActionResult UpdateUser([FromForm] Models.User data)
        {
            try{                                       
                if (data.Id == null){
                    data.Id = Guid.NewGuid();
                    var u = _context.Users.Add(data).Entity;
                    _context.SaveChanges();   
                    return Ok(u);                 
                }
                else{
                    _context.Users.Update(data);                   
                    _context.SaveChanges();
                }                
                return Ok(data);
            }
            catch(Exception e){
                _logger.LogError(e.ToString());
                return null;
            }
        }        
        [HttpGet]
        [Route("{id}/delete")]
        public ActionResult DeleteUser(Guid id)
        {
            try{
                _context.Users.Remove(new Models.User(){ Id = id});
                _context.SaveChanges();
                return Ok();
            }
            catch(Exception e){
                _logger.LogError(e.ToString());
                return null;
            }
        }       
        [HttpPost]
        [Route("{id}/here")]
        public ActionResult UpdatePresenceStatus(Guid id, [FromForm] bool here)
        {
            try{
                var u = _context.Users.First(u => u.Id == id);                
                u.Here = here;
                _context.Update(u);
                _context.SaveChanges();                
                return Ok();
            }
            catch(Exception e){
                _logger.LogError(e.ToString());
                return null;
            }
        }           
    }
}
