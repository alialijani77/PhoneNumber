using Microsoft.Extensions.DependencyInjection;
using PhoneNumber.Application.Services.Implementions;
using PhoneNumber.Application.Services.Interfaces;
using PhoneNumber.DataLayer.Repositories;
using PhoneNumber.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumber.IoC
{
	public static class DependencyContainer
	{
		public static void RegisterDependencies(IServiceCollection services)
		{
			#region Services

			services.AddScoped<IPhoneNumberService, PhoneNumberService>();			

			#endregion

			#region Repositories

			services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();			

			#endregion
		}
	}
}
