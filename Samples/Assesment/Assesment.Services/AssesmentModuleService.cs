using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Assesment.Domain;
using Assesment.Domain.ModuleModel;
using Assesment.Domain.ModuleModel.Commands;
using Assesment.Domain.ModuleModel.Entities;
using EventFlow;

namespace Assesment.Services
{
    public interface IAssesmentModuleService
    {
        Task<AssesmentModuleId> CreateModuleAsync(Name name, Code code, AssesmentModuleType type, CancellationToken cancellationToken);
        Task<AssesmentModuleId> EditModuleAsync(AssesmentModuleId id, Name name, CancellationToken cancellationToken);
        Task<AssesmentChecklistId> AddChecklistAsync(AssesmentModuleId moduleId, Name name, Code code, CancellationToken cancellationToken);
        Task<AssesmentAttributeId> AddAttributeAsync(AssesmentModuleId moduleId, Name name, Code code, CancellationToken cancellationToken);
        Task<AssesmentChecklistId> AddChecklistAttributesAsync(AssesmentModuleId moduleId, AssesmentChecklistId checklistId, IEnumerable<AssesmentAttributeId> list, CancellationToken cancellationToken);
    }

    public class AssesmentModuleService : IAssesmentModuleService
    {
        private readonly ICommandBus _commandBus;

        public AssesmentModuleService(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        public async Task<AssesmentAttributeId> AddAttributeAsync(AssesmentModuleId moduleId, Name name, Code code, CancellationToken cancellationToken)
        {
            AssesmentAttributeId id = AssesmentAttributeId.New;
            await _commandBus.PublishAsync(new AddAssesmentAttributeCommand(moduleId, id, name, code), cancellationToken).ConfigureAwait(false);

            return id;
        }

        public async Task<AssesmentChecklistId> AddChecklistAsync(AssesmentModuleId moduleId, Name name, Code code, CancellationToken cancellationToken)
        {
            AssesmentChecklistId id = AssesmentChecklistId.New;
            await _commandBus.PublishAsync(new AddAssesmentChecklistCommand(moduleId, id, name, code), cancellationToken).ConfigureAwait(false);

            return id;
        }

        public Task<AssesmentChecklistId> AddChecklistAttributesAsync(AssesmentModuleId moduleId, AssesmentChecklistId checklistId, IEnumerable<AssesmentAttributeId> list, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AssesmentModuleId> CreateModuleAsync(Name name, Code code, AssesmentModuleType type, CancellationToken cancellationToken)
        {
            AssesmentModuleId id = AssesmentModuleId.New;

            await _commandBus.PublishAsync(new CreateAssesmentModuleCommand(id, name, code, type), cancellationToken).ConfigureAwait(false);

            return id;
        }

        public async Task<AssesmentModuleId> EditModuleAsync(AssesmentModuleId id, Name name, CancellationToken cancellationToken)
        {
            await _commandBus.PublishAsync(new UpdateAssesmentModuleCommand(id, name), cancellationToken).ConfigureAwait(false);
            return id;
        }
    }

}
