using AutoMapper;
using BankApiRESTful.Application.Features.Customers.Commands.CreateCustomerCommand;
using BankApiRESTful.Domain.Entities;

namespace BankApiRESTful.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Commands
            CreateMap<CreateCustomerCommand, Customer>();
            #endregion
        }
    }
}
