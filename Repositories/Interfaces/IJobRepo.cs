using JobTracker.Api.Models;

namespace JobTracker.Api.Repositories.Interfaces;

public interface IJobRepo
{
    Task<IEnumerable<Job>> GetAllAsync();
    Task<Job?> GetByIdAsync(int id);
    Task<Job> AddAsync(Job job);
    Task UpdateAsync(Job job);
    Task DeleteAsync(Job job);
}