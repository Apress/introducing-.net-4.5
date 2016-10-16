using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace AspWebformsExamples
{
    public class TestBinderAttribute : ValueProviderSourceAttribute
    {
        private readonly string _key;
        public TestBinderAttribute()
        {
        }

        public TestBinderAttribute(string key)
        {
            _key = key;
        }

        public string Key
        {
            get
            {
                return _key;
            }
        }
        public bool ValidateInput { get; set; }

        public override string GetModelName()
        {
            return "";
        }

        public override IValueProvider GetValueProvider(ModelBindingExecutionContext modelBindingExecutionContext)
        {
            return new TestBinderAttributeProvider();

        }

    }

    public class TestBinderAttributeProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return false;
        }

        public ValueProviderResult GetValue(string key)
        {
            var result = new ValueProviderResult("Echo " + key, key, CultureInfo.InvariantCulture);
            return result;

        }
    }

}