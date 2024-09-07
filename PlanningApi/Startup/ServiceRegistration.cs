using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Planning.Application.Features.Plans.Command.CreatePlan;
using Planning.Application.Features.Plans.Command.DeletePlan;
using Planning.Application.Features.Plans.Queries.GetPlans;
using Planning.Application.Features.Routines.Command.CompleteRoutine;
using Planning.Application.Features.Routines.Command.CreateRoutine;
using Planning.Application.Features.Routines.Command.DeleteRoutine;
using Planning.Application.Features.Routines.Command.ModifyRoutine;
using Planning.Application.Features.Routines.Queries.GetAllRoutines;
using Planning.Application.PipelineBehaviors;
using Planning.Application.Validators;
using Planning.Domain.Interfaces.Repository;
using Planning.Domain.UnitOfWork;
using Planning.Infrastructure.AutoMappers;
using Planning.Infrastructure.AutoMappers.DataContext;
using Planning.Infrastructure.Repositories;
using Planning.Infrastructure.UnitOfWork;
using PlanningAPI.ExceptionHandlers;
using System.Reflection;

namespace PlanningApi.Startup
{
    public class ServiceRegistration
    {
        public static void Register(IServiceCollection services)
        {
            // database
            services.AddDbContext<DataContextEF>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection")
            );

            // cqrs handlers
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
                cfg.RegisterServicesFromAssembly(typeof(CreatePlanCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeletePlanCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetPlansQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CompleteRoutineCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateRoutineCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeleteRoutineCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(ModifyRoutineCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAllRoutinesQueryHandler).Assembly);
            });

            services.AddValidatorsFromAssembly(typeof(CreatePlanCommandValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(DeletePlanCommandValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(CompleteRoutineCommandValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(CreateRoutineCommandValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(DeleteRoutineCommandValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(ModifyRoutineCommandValidator).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            //services.AddHttpLogging(o => { });

            //services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<IRoutineRepository, RoutineRepository>();

            //exceptionHandler
            services.AddExceptionHandler<GlobalExceptionHandler>();

            // Auto Mapper Configurations
            var mapperConfig = new AutoMapperProfile().Configure();
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
