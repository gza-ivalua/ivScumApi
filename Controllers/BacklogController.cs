using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using IvScrumApi.Models;
namespace IvScrumApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BacklogController : ControllerBase
    {
        private DatabaseContext _context;
        private IHttpContextAccessor _contextAccessor;   
        private readonly ILogger<UserController> _logger;

        public BacklogController(ILogger<UserController> logger, 
        DatabaseContext context, 
        IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _context = context;
            _contextAccessor = contextAccessor;
        }        
        [HttpPost]        
        public ActionResult StoreBacklogData([FromBody] Backlog data )
        { 
            _logger.LogInformation(data.ToString());
            if (!data.Date.HasValue)
                data.Date = DateTime.Now;
            data.Id = Guid.NewGuid();         
            _context.Backlog.Add(data);
            _context.SaveChanges();
            _logger.LogInformation(data.ToString());
            return Ok();
        }   
        [HttpGet]
        [Route("{teamId}")]
        public ActionResult GetBacklogData(Guid teamId)
        {
            var date = DateTime.Now;
            date = date.AddDays(-30);
            _logger.LogInformation(date.ToString());    
            var data = _context.Backlog.Where(b => DateTime.Compare(b.Date.Value, date) > 0 
                && b.TeamId == teamId)
                .OrderBy(b => b.Date);            
            foreach(Backlog b in data){
                _logger.LogInformation(b.ToString());    
            }            
            return Ok(data);
        }

        [HttpGet]
        [Route("all")]
        public ActionResult GetBacklogsData()
        {
            var date = DateTime.Now;
            date = date.AddDays(-30);
            try{
                // var teams = _context.Teams;
                List<Team> teams = new List<Team>();
                foreach(Team team in _context.Teams.ToList()){
                    team.Backlogs = _context.Backlog                
                        .Where(b => DateTime.Compare(b.Date.Value, date) > 0)
                        .Where(t => t.TeamId == team.Id).ToList();     
                    teams.Add(team);                                 
                }
                return Ok(teams);            
            } 
            catch(Exception e){
                _logger.LogInformation($@"{e.ToString()}
{e.Message}
{e.StackTrace}");                
            } 
            return Ok();                      
        }

    }
}
