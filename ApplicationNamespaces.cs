// .NET
global using System;
global using Microsoft.Extensions.Options;

// NuGet
global using MongoDB.Bson;
global using MongoDB.Bson.Serialization.Attributes;
global using MongoDB.Driver;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using Microsoft.AspNetCore.Authorization;

// Custom
global using Leden.API.Models;
global using Leden.API.Repositories;
global using Leden.API.Services;
global using Leden.API.Configuration;
global using Leden.API.Context;
global using Leden.API.Validators;
global using Leden.API.GraphQL;
global using Leden.API.GraphQL.Leden;
global using Leden.API.GraphQL.Takken;
global using Leden.API.GraphQL.Groepen;