using JobTracker.Api.Data;
using JobTracker.Api.Models;
using JobTracker.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobTracker.Api.Repositories;

public class JobRepo : IJobRepo
{
    private readonly AppDbContext _context;

    public JobRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Job>> GetAllAsync()
    {
        return await _context.Jobs.ToListAsync();    
    }

    public async Task<Job?> GetByIdAsync(int id)
    {
        return await _context.Jobs.FindAsync(id);
    }

    public async Task<Job> AddAsync(Job job)
    {
        await _context.Jobs.AddAsync(job);
        await _context.SaveChangesAsync();

        return job;
    }

    public async Task UpdateAsync(Job job)
    {
        _context.Jobs.Update(job);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Job job)
    {
        _context.Jobs.Remove(job);
        await _context.SaveChangesAsync();
    }
}