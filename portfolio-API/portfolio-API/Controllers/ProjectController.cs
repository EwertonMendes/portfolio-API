using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using portfolio_API.DBContexts;
using portfolio_API.Dtos;
using portfolio_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace portfolio_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        public readonly PortfolioContext _context;
        public ProjectController(PortfolioContext context)
        {
            _context = context;
        }
        // GET: ProjectController
        [HttpGet]
        public ActionResult<IEnumerable<Project>> Get()
        {
            var projects = _context.Projects.AsEnumerable();

            return Ok(projects);
        }

        [HttpPost("create")]
        public ActionResult Create([FromBody] ProjectDto newProject)
        {
            try
            {
                var project = new Project
                {
                    Name = newProject.Name,
                    Description = newProject.Description,
                    ImageURL = newProject.ImageURL,
                    RepoURL = newProject.RepoURL
                };

                _context.Projects.Add(project);

                _context.SaveChanges();

                return Ok("Projeto " + project.Name + " Com o ID " + project.Id + " Criado com sucesso");
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("delete")]
        public ActionResult Delete([FromQuery] int projectId)
        {
            try
            {
                var project = _context.Projects.FirstOrDefault(o => o.Id == projectId);
                _context.Projects.Remove(project);

                _context.SaveChanges();

                return Ok("Projeto Removido");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
