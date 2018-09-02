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
    }
}
