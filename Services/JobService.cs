using JobTracker.Api.Models;
using JobTracker.Api.Repositories.Interfaces;
using JobTracker.Api.Services.Interfaces;

namespace JobTracker.Api.Services;

public class JobService : IJobService
{
    private readonly IJobRepo _JobRepo;

    public JobService(IJobRepo jobRepo)
    {
        _JobRepo = jobRepo;
    }

    public async Task<IEnumerable<Job>> GetAllAsync()
    {
        return await _JobRepo.GetAllAsync();
    }

    public async Task<Job?> GetByIdAsync(int id)
    {
        return await _JobRepo.GetByIdAsync(id);
    }

    public async Task<Job> CreateAsync(Job job)
    {
        job.CreatedAt = DateTime.UtcNow;
        return await _JobRepo.AddAsync(job);
    }

    public async Task<bool> UpdateAsync(int id, Job job)
    {
        var existingJob = await _JobRepo.GetByIdAsync(id);

        if (existingJob is null)
        {
            return false;
        }

        existingJob.Company = job.Company;
        existingJob.Location = job.Location;
        existingJob.Note = job.Note;
        existingJob.Position = job.Position;
        existingJob.Salary = job.Salary;
        existingJob.Status = job.Status;
        existingJob.Url = job.Url;
        existingJob.AppliedAt = job.AppliedAt;

        await _JobRepo.UpdateAsync(existingJob);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var job = await _JobRepo.GetByIdAsync(id);

        if (job is null)
        {
            return false;
        }

        await _JobRepo.DeleteAsync(job);

        return true;
    }
}