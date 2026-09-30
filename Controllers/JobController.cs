using JobTracker.Api.Models;
using JobTracker.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {   
        var jobs = await _jobService.GetAllAsync();
        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var job = await _jobService.GetByIdAsync(id);
        
        if (job is null)
        {
            return NotFound();
        }

        return Ok(job);
    }

    [HttpPost]
    public async Task<IActionResult> AddJob(Job job)
    {
        var createdJob = await _jobService.CreateAsync(job);
        return CreatedAtAction(
            nameof(GetById),
            new {id = createdJob.Id },
            createdJob
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Job job)
    {
        var updated = await _jobService.UpdateAsync(id, job);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _jobService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}