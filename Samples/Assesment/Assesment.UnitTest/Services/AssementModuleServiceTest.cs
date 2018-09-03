using System;
using System.Threading;
using System.Threading.Tasks;
using Assesment.Domain;
using Assesment.Domain.ModuleModel;
using Assesment.Domain.ModuleModel.Entities;
using Assesment.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assesment.UnitTest
{
    [TestClass]
    public class AssementModuleServiceTest : TestFor<IAssesmentModuleService>
    {
        public AssementModuleServiceTest() : base()
        {
            
        }

        private Task<AssesmentModuleId> NewModule()
        {
            return Sut.CreateModuleAsync(new Name("HSNSI"), new Code("HSLSLS"), CancellationToken.None);
        }

        private Task<AssesmentChecklistId> NewChecklist(AssesmentModuleId moduleId = null)
        {
            return Sut.AddChecklistAsync(moduleId ?? NewModule().Result, new Name("Check list 1"), new Code("CHK1"), CancellationToken.None);
        }

        [TestMethod]
        public async Task CreateModule()
        {
            AssesmentModuleId id = await NewModule();
        }

        [TestMethod]
        public async Task EditModule()
        {
            AssesmentModuleId id = await Sut.EditModuleAsync(await NewModule(), new Name("Test Module 2"), CancellationToken.None);
        }

        [TestMethod]
        public async Task AddCheckList()
        {
            AssesmentChecklistId id = await NewChecklist();
        }

        [TestMethod]
        public async Task AddAttribute()
        {
            AssesmentModuleId moduleId = await NewModule();
            AssesmentChecklistId checklistId = await NewChecklist(moduleId);
            AssesmentAttributeId id = await Sut.AddAttributeAsync(moduleId, checklistId, new Name("Check list 1"), new Code("CHK1"), CancellationToken.None);
        }
    }
}
