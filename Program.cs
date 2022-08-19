
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SixMinApi.Data;
using SixMinApi.Dtos;
using SixMinApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConBuilder = new SqlConnectionStringBuilder();

sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("SQLDbConnection");
sqlConBuilder.UserID = builder.Configuration["UserID"];
sqlConBuilder.Password = builder.Configuration["Password"];

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));
builder.Services.AddScoped<IClientModelRepo, ClientModelRepo>();
builder.Services.AddScoped<IAddressModelRepo, AddressModelRepo>();
builder.Services.AddScoped<IBeneficiaryModelRepo, BeneficiaryModelRepo>();
builder.Services.AddScoped<IDependantModelRepo, DependantModelRepo>();
builder.Services.AddScoped<IBankingModelRepo, BankingModelRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/getallclients", async (IClientModelRepo repo, IMapper mapper) => {
    var commands = await repo.GetAllClientModels();
    return Results.Ok(mapper.Map<IEnumerable<ClientReadDto>>(commands));
});

app.MapGet("api/v1/getclient/{id}", async (IClientModelRepo repo, IMapper mapper, int id) => {
    var command = await repo.GetClientModelById(id);
    if (command != null)
    {
        return Results.Ok(mapper.Map<ClientReadDto>(command));
    }
    return Results.NotFound("The requested user could not be found.");
});

app.MapPost("api/v1/addclient", async (IClientModelRepo repo, IMapper mapper, ClientCreateDto cmdCreateDto) => {
    var commandModel = mapper.Map<ClientModel>(cmdCreateDto);

    await repo.CreateClientModel(commandModel);
    await repo.SaveChanges();

    var cmdReadDto = mapper.Map<ClientReadDto>(commandModel);

    return Results.Created($"api/v1/getclient/{cmdReadDto.UserId}", cmdReadDto);

});

app.MapPut("api/v1/updateclient/{id}", async (IClientModelRepo repo, IMapper mapper, int id, ClientUpdateDto cmdUpdateDto) => {
    var command = await repo.GetClientModelById(id);
    if (command == null)
    {
        return Results.NotFound("The requested client could not be found.");
    }

    mapper.Map(cmdUpdateDto, command);

    await repo.SaveChanges();

    return Results.NoContent();
});

app.MapDelete("api/v1/deleteclient/{id}", async (IClientModelRepo repo, IMapper mapper, int id) => {
    var command = await repo.GetClientModelById(id);
    if (command == null)
    {
        return Results.NotFound("The requested client could not be found.");
    }

    repo.DeleteClientModel(command);

    await repo.SaveChanges();

    return Results.NoContent();

});

app.MapGet("api/v1/getaddresses", async (IAddressModelRepo repo, IMapper mapper) => {
    var addresses = await repo.GetAllAddresses();
    return Results.Ok(mapper.Map<IEnumerable<AddressReadDto>>(addresses));
});

app.MapPost("api/v1/newaddress", async (IAddressModelRepo repo, IMapper mapper, AddressCreateDto createAddress) => {
    var address = mapper.Map<AddressModel>(createAddress);

    try
    {
        await repo.CreateAddressModel(address);
        await repo.SaveChanges();
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }

    var addressReadDto = mapper.Map<AddressReadDto>(address);
    return Results.Created($"api/v1/getaddresses", address);
});

app.MapGet("api/v1/getallbankdetails", async (IBankingModelRepo repo, IMapper mapper) => {
    var banks = await repo.GetAllBankAccounts();
    return Results.Ok(mapper.Map<IEnumerable<BankModelReadDto>>(banks));
});

app.MapPost("api/v1/savebankaccount", async (IBankingModelRepo repo, IMapper mapper, BankModelCreateDto createBank) => {
    var bank = mapper.Map<BankAccountModel>(createBank);

    try
    {
        await repo.CreateBankAccountModel(bank);
        await repo.SaveChanges();
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }

    var bankAccountReadDto = mapper.Map<BankModelReadDto>(bank);
    return Results.Created($"api/v1/getallbankdetails", bank);
});

app.MapPut("api/v1/updatebankdetails/{id}", async (IBankingModelRepo repo, IMapper mapper, BankModelUpdateDto updateBankAccount, int id) => {
 var command = await repo.GetBankAccountById(id);
    if (command == null)
    {
        return Results.NotFound("The requested bank details could not be found.");
    }

    mapper.Map(updateBankAccount, command);

    await repo.SaveChanges();

    return Results.NoContent();
});

app.MapDelete("api/v1/deletebank/{id}", async (IBankingModelRepo repo, IMapper map, int id) => {
     var command = await repo.GetBankAccountById(id);
    if (command == null)
    {
        return Results.NotFound("The requested bank account could not be found.");
    }

    repo.DeleteBankAccount(command);

    await repo.SaveChanges();

    return Results.NoContent();
});

app.MapGet("api/v1/getdependants", async (IDependantModelRepo repo, IMapper mapper) => {
    var dependants = await repo.GetAllDependants();
    return Results.Ok(mapper.Map<IEnumerable<DependantReadDto>>(dependants));
});

app.MapGet("api/v1/getdependant/{id}", async (IDependantModelRepo repo, IMapper mapper, int id) => {
    var dependant = await repo.GetDependantById(id);
    if (dependant != null)
    {
        return Results.Ok(mapper.Map<DependantReadDto>(dependant));
    }
    return Results.NotFound("Couldnt find the required dependant");

});

app.MapPost("api/v1/savedependant", async (IDependantModelRepo repo, IMapper mapper, DependantUpdateDto saveDependant) => {
 var dependant = mapper.Map<DependantModel>(saveDependant);

    try
    {
        await repo.CreateDependantModel(dependant);
        await repo.SaveChanges();
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }

    var dependantReadDto = mapper.Map<DependantReadDto>(dependant);
    return Results.Created($"api/v1/getallbankdetails", dependant);
});

app.MapPut("api/v1/updatedependant/{id}", async (IDependantModelRepo repo, IMapper mapper, DependantUpdateDto updateDependant, int id) => {
var command = await repo.GetDependantById(id);
    if (command == null)
    {
        return Results.NotFound("The requested dependant could not be found.");
    }

    mapper.Map(updateDependant, command);

    await repo.SaveChanges();

    return Results.NoContent();
});

app.MapDelete("api/v1/deletedependant/{id}", async (IDependantModelRepo repo, IMapper mapper, int id) => {
    var command = await repo.GetDependantById(id);
    if (command == null)
    {
        return Results.NotFound("The requested dependant could not be found.");
    }

    repo.DeleteDependant(command);

    await repo.SaveChanges();

    return Results.NoContent();
});

app.MapGet("api/v1/getbeneficiaries", async (IBeneficiaryModelRepo repo, IMapper mapper) => {
    var beneficiaries = await repo.GetAllBeneficiaryModels();
    return Results.Ok(mapper.Map<IEnumerable<BeneficiaryReadDto>>(beneficiaries));
});

app.MapGet("api/v1/getbeneficiary/{id}", async (IBeneficiaryModelRepo repo, IMapper mapper, int id) => {
    var beneficiary = await repo.GetBeneficiaryModelById(id);
    if (beneficiary == null)
    {
        return Results.NotFound("The required beneficiary could not be found.");
    }

    return Results.Ok(mapper.Map<BeneficiaryReadDto>(beneficiary));
});

app.MapPost("api/v1/savebeneficiary", async (IBeneficiaryModelRepo repo, IMapper mapper, BeneficiaryCreateDto newBeneficiary) => {
var beneficiary = mapper.Map<BeneficiaryModel>(newBeneficiary);

    try
    {
        await repo.CreateBeneficiaryModel(beneficiary);
        await repo.SaveChanges();
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }

    var beneficiaryReadDto = mapper.Map<BeneficiaryReadDto>(beneficiary);
    return Results.Created($"api/v1/getbeneficiaries", beneficiary);
});

app.MapPut("api/v1/updatebeneficiary/{id}", async (IBeneficiaryModelRepo repo, IMapper mapper, BeneficiaryUpdateDto updateBeneficiary, int id) => {
    var beneficiary = await repo.GetBeneficiaryModelById(id);
    if (beneficiary == null)
        {
            return Results.NotFound("The requested beneficiary could not be found.");
        }

        mapper.Map(updateBeneficiary, beneficiary);

        await repo.SaveChanges();

        return Results.NoContent();

});

app.MapDelete("api/v1/deletebeneficiary/{id}", async (IBeneficiaryModelRepo repo, IMapper mapper, int id) => {
    var beneficiary = await repo.GetBeneficiaryModelById(id);

    if (beneficiary == null)
    {
        return Results.NotFound("The required beneficiary could not be found");
    }

    repo.DeleteBeneficaryModel(beneficiary);
    await repo.SaveChanges();

    return Results.NoContent();
});

app.Run();

