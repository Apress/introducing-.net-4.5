using System;
using System.Xaml;

namespace MarkupExtension
{
    public class TruncationExtension : IMarkupExtension<string>
    {
        public string Text { get; set; }
        public int Length { get; set; }

        #region IMarkupExtension<string> Members

        public string ProvideValue(IServiceProvider serviceProvider)
        {
            return (Text.Length > Length) ? string.Format("{0}...", Text.Substring(0, Length - 3)) : Text;
        }

        #endregion
    }
}