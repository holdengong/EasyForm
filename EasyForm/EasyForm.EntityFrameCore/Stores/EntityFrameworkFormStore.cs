using EasyForm.Core.Interfaces;
using EasyForm.Core.Models.Forms;
using EasyForm.EntityFrameCore.Contexts;
using EasyForm.EntityFrameCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class EntityFrameworkFormStore : IFormStore
{
    private readonly FormDbContext _formDbContext;

    public EntityFrameworkFormStore(FormDbContext formDbContext)
    {
        _formDbContext = formDbContext;
    }

    public async Task AddAsync(Form form)
    {
        var existing = _formDbContext.Forms.Any(x => x.Key.Equals(form.Key, StringComparison.CurrentCultureIgnoreCase));
        if (existing)
        {
            throw new InvalidOperationException($"form key {form.Key} already existed");
        }

        var entity = form.ToEntity();

        _formDbContext.Forms.Add(entity);

        await _formDbContext.SaveChangesAsync();
    }

    public Task<IEnumerable<Form>> GetAllAsync()
    {
        var entities = _formDbContext.Forms.ToList();
        var forms = entities
    }

    public Task<Form> GetByKeyAsync(string key)
    {
        throw new System.NotImplementedException();
    }

    public Task RemoveByKeyAsync(string key)
    {
        throw new System.NotImplementedException();
    }

    public Task UpdateAsync(Form form)
    {
        throw new System.NotImplementedException();
    }
}