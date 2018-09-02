using System;
using System.Threading;
using System.Threading.Tasks;
using Assesment.Domain;
using Assesment.Domain.ModuleModel;
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

        [TestMethod]
        public async Task CreateModule()
        {
            AssesmentModuleId id = await Sut.CreateModuleAsync(new Name("HSNSI"), new Code("HSLSLS"), CancellationToken.None);
        }

        [TestMethod]
        public async Task EditModule()
        {
            AssesmentModuleId id = await Sut.EditModuleAsync(new AssesmentModuleId("assesmentmodule-64d11ae0-4d1e-443d-a027-2f894bd8f0fb"), new Name("Test Module 2"), CancellationToken.None);
        }
    }
}
