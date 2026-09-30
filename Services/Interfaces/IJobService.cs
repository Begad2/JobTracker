using JobTracker.Api.Models;

namespace JobTracker.Api.Services.Interfaces;

public interface IJobService
{
    Task<IEnumerable<Job>> GetAllAsync();

    Task<Job?> GetByIdAsync(int id1);

    Task<Job> CreateAsync(Job job);

    Task<bool> UpdateAsync(int id, Job job);

    Task<bool> DeleteAsync(int id); 
}