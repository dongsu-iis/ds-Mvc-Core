using ds.NorthwindApp.Model.UnitOfWork;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ds.NorthwindApp.Web.Infrastructure.ActionFilters
{
    public class UnitOfWorkAttribute : IAsyncActionFilter, IAsyncResultFilter
    {

        private IUnitOfWork _unitOfWork;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = context.HttpContext.RequestServices.GetService<IUnitOfWork>();
            }
            await next();

        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await _unitOfWork.Commit();
            await next();
        }
    }

}
