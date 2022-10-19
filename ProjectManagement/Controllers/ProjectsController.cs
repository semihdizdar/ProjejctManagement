﻿using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private List<Project> _projectList;
        private readonly ILogger _logger;
        public ProjectsController(ILogger logger)
        {
            _logger = logger;
            _projectList = new List<Project>
            {
                new Project{ Id = Guid.NewGuid(), Name = "Project 1"},
                new Project{ Id = Guid.NewGuid(), Name = "Project 2"},
                new Project{ Id = Guid.NewGuid(), Name = "Project 3"}
            };
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("Project.Get() has been run.");
                return Ok(_projectList);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Project.Get() has been crashed {ex.Message}");
                throw;
            }
        }
    }
}
