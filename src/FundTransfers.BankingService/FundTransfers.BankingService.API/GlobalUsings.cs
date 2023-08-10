global using System;
global using System.IO;
global using System.Reflection;
global using MediatR;
global using Dapr.Client;


global using Microsoft.AspNetCore.Builder;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Options;
global using Serilog;
global using Serilog.Events;
global using Swashbuckle.AspNetCore.Filters;
global using Swashbuckle.AspNetCore.SwaggerGen;
global using Swashbuckle.AspNetCore.SwaggerUI;
global using Microsoft.Extensions.Configuration;

global using FundTransfers.BankingService.API.Extensions;
global using FundTransfers.BankingService.API.Options;
global using FundTransfers.BankingService.Application.Commands;
global using FundTransfers.BankingService.Application.Dtos;
global using FundTransfers.BankingService.Domain.AggregatesModel;
global using FundTransfers.BankingService.Domain.Events;
global using FundTransfers.BankingService.Domain.SeedWork;
global using FundTransfers.BankingService.Infrastructure;
global using FundTransfers.BankingService.Infrastructure.Implementations;
