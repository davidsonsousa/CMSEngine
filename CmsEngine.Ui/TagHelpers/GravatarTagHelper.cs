using System.Linq;
using System.Text.Encodings.Web;
using CmsEngine.Extensions;
using CmsEngine.Utils;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CmsEngine.Ui.TagHelpers
{
    public class GravatarTagHelper : TagHelper
    {
        /// <summary>
        /// E-mail address registered on gravatar.com
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Image size (default is 80)
        /// </summary>
        public int ImageSize { get; set; } = 80;
        /// <summary>
        /// Default image loaded from gravatar.com (default is 0)
        /// </summary>
        public DefaultImage DefaultImage { get; set; } = DefaultImage.Default;
        /// <summary>
        /// Default image url loaded from gravatar.com (default is "")
        /// </summary>
        public string DefaultImageUrl { get; set; } = "";
        public bool ForceDefaultImage { get; set; }
        /// <summary>
        /// Image rating (default is G)
        /// </summary>
        public Rating Rating { get; set; } = Rating.G;
        public bool ForceSecureRequest { get; set; }
        public string AdditionalCssClasses { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "img";
            var email = string.IsNullOrWhiteSpace(EmailAddress) ? string.Empty : EmailAddress.ToLower();

            output.Attributes.Add("src",
                string.Format("{0}://{1}.gravatar.com/avatar/{2}?s={3}{4}{5}{6}",
                    "https",
                    "s",
                    GravatarUtilities.GetMd5Hash(email),
                    ImageSize,
                    "&d=" + (!string.IsNullOrEmpty(DefaultImageUrl) ? HtmlEncoder.Default.Encode(DefaultImageUrl) : DefaultImage.GetDescription()),
                    ForceDefaultImage ? "&f=y" : "",
                    "&r=" + Rating.GetDescription()
                )
            );
            if (!string.IsNullOrWhiteSpace(AdditionalCssClasses))
            {
                if (output.Attributes.Any(x => x.Name.ToLower() == "class"))
                {
                    AdditionalCssClasses = output.Attributes.First(x => x.Name.ToLower() == "class").Value + " " + AdditionalCssClasses;
                    output.Attributes.Remove(output.Attributes.First(x => x.Name.ToLower() == "class"));
                }

                // Add the additional CSS classes
                output.Attributes.Add("class", AdditionalCssClasses);
            }
            base.Process(context, output);
        }
    }
}