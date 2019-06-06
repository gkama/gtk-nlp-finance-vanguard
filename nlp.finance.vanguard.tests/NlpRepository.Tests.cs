using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.Logging.Abstractions;

using Xunit;

using Newtonsoft.Json;

using nlp.finance.vanguard.data;
using nlp.finance.vanguard.services;

namespace nlp.finance.vanguard.tests
{
    public class NlpRepositoryTests
    {
        private readonly INlpRepository<TestModel> repo;

        public NlpRepositoryTests()
        {
            this.repo = new NlpRepository<TestModel>(GetTestModel(), new NullLogger<NlpRepository<TestModel>>());
        }

        [Theory]
        [InlineData("this is the content vtsax")]
        [InlineData("this is a valid content that finds vtsax and vbltx")]
        [InlineData("this is yet another valid content that finds vtsax and vbltx")]
        public void Categorize_Valid_Content(string content)
        {
            var cats = repo.Categorize(content);

            //Asserts
            Assert.True(cats.Count() > 0);
            Assert.True(cats.FirstOrDefault(x => x.total_weight > 0) != null);
        }

        public IModel<TestModel> GetTestModel()
        {
            return new TestModel()
            {
                id = Guid.NewGuid().ToString(),
                name = "Test",
                details = null,
                children = new List<TestModel>()
                {
                    new TestModel()
                    {
                        id = Guid.NewGuid().ToString(),
                        name = "Vanguard Test",
                        details = "vbiix|vbinx|vbisx|vbltx|vbmfx|vdaix|vdvix|veiex|veurx|vexmx|vtsax"
                    }
                }
            };
        }     
    }

    public class TestModel : IModel<TestModel>
    {
        public string id { get; set; }
        public string name { get; set; }
        public string details { get; set; }

        [JsonIgnore]
        public IEnumerable<string> details_split => details.Split('|');

        public ICollection<TestModel> children { get; set; } = new List<TestModel>();
    }
}
