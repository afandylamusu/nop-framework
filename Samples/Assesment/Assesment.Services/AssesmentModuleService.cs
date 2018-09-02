using System.Threading;
using System.Threading.Tasks;
using Assesment.Domain;
using Assesment.Domain.ModuleModel;
using Assesment.Domain.ModuleModel.Commands;
using EventFlow;

namespace Assesment.Services
{
    public interface IAssesmentModuleService
    {
        Task<AssesmentModuleId> CreateModuleAsync(Name name, Code code, CancellationToken cancellationToken);
        Task<AssesmentModuleId> EditModuleAsync(AssesmentModuleId id, Name name, CancellationToken cancellationToken);
    }

    public class AssesmentModuleService : IAssesmentModuleService
    {
        private readonly ICommandBus _commandBus;

        public AssesmentModuleService(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        public async Task<AssesmentModuleId> CreateModuleAsync(Name name, Code code, CancellationToken cancellationToken)
        {
            AssesmentModuleId id = AssesmentModuleId.New;

            await _commandBus.PublishAsync(new CreateAssesmentModuleCommand(id, name, code), cancellationToken).ConfigureAwait(false);

            return id;
        }

        public async Task<AssesmentModuleId> EditModuleAsync(AssesmentModuleId id, Name name, CancellationToken cancellationToken)
        {
            await _commandBus.PublishAsync(new UpdateAssesmentModuleCommand(id, name), cancellationToken).ConfigureAwait(false);
            return id;
        }
    }

}
