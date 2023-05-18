using AutoMapper;
using Aw2.Data.Domains;
using Aw2.Data.UnitOfWork;
using Aw2.Schema;
using Aw2.Schema.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Aw2.Service.Controllers;
[Route("aw2api/v1/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private IMapper mapper;
    public StaffController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    public List<StaffResponse> GetAll()
    {
        var list = unitOfWork.StaffRepository.GetAll();
        var mapped = mapper.Map<List<StaffResponse>>(list);
        return mapped;
    }

    [HttpGet("{id}")]
    public StaffResponse GetById(int id)
    {
        var single = unitOfWork.StaffRepository.GetById(id);
        var mapped = mapper.Map<StaffResponse>(single);
        return mapped;
    }

    [HttpGet("[action]")]
    public List<StaffResponse> GetWithFilter([FromQuery] string? country, [FromQuery] string? city)
    {
        List<Staff> filter = CountryAndCityFilter(country, city);
        var mapped = mapper.Map<List<StaffResponse>>(filter);
        return mapped;
    }
    

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StaffRequest request)
    {
        var entity = mapper.Map<Staff>(request);
        await unitOfWork.StaffRepository.AddAsync(entity);
        unitOfWork.Complete();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] StaffRequest request)
    {
        request.Id = id;

        var entity = mapper.Map<Staff>(request);
        unitOfWork.StaffRepository.Update(entity);
        unitOfWork.Complete();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        unitOfWork.StaffRepository.DeleteById(id);
        unitOfWork.Complete();
        return Ok();
    }


    private List<Staff> CountryAndCityFilter(string? country, string? city)
    {
        List<Staff> filter;
        if (country == null)
        {
            filter = unitOfWork.StaffRepository.GetWhere(p => p.City == city).ToList();
        }
        else if (city == null)
        {
            filter = unitOfWork.StaffRepository.GetWhere(p => p.Country == country).ToList();
        }
        else
        {
            filter = unitOfWork.StaffRepository.GetWhere(p => p.Country == country && p.City == city).ToList();
        }
        return filter;
    }
}
