using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// The challenge settings if action is set to BLOCK.
    /// </summary>
    public class BlockChallengeSettings
    {
        /// <summary>
        /// The method used to block requests that fail the challenge, if action is set to BLOCK. If unspecified, defaults to SHOW_ERROR_PAGE.
        /// <para>Required: no</para>
        /// </summary>
        public string BlockAction { get; set; }

        /// <summary>
        /// The response status code to return when action is set to BLOCK, blockAction is set to SET_RESPONSE_CODE or SHOW_ERROR_PAGE, 
        /// and the request is blocked. If unspecified, defaults to 403.
        /// <para>Required: no</para>
        /// <para>Minimum: 100, Maximum: 999</para>
        /// </summary>
        public int? BlockResponseCode { get; set; }

        /// <summary>
        /// The message to show on the error page when action is set to BLOCK, blockAction is set to SHOW_ERROR_PAGE, and the request is blocked. 
        /// If unspecified, defaults to Access to the website is blocked.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 5000</para>
        /// </summary>
        public string BlockErrorPageMessage { get; set; }

        /// <summary>
        /// The description text to show on the error page when action is set to BLOCK, blockAction is set to SHOW_ERROR_PAGE, and the request is blocked. 
        /// If unspecified, defaults to Access blocked by website owner. Please contact support.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 5000</para>
        /// </summary>
        public string BlockErrorPageDescription { get; set; }

        /// <summary>
        /// The error code to show on the error page when action is set to BLOCK, blockAction is set to SHOW_ERROR_PAGE and the request is blocked. 
        /// If unspecified, defaults to 403.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 5000</para>
        /// </summary>
        public string BlockErrorPageCode { get; set; }

        /// <summary>
        /// The title used when showing a CAPTCHA challenge when action is set to BLOCK, blockAction is set to SHOW_CAPTCHA, and the request is blocked. 
        /// If unspecified, defaults to Are you human?
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 100</para>
        /// </summary>
        public string CaptchaTitle { get; set; }

        /// <summary>
        /// The text to show in the header when showing a CAPTCHA challenge when action is set to BLOCK, blockAction is set to SHOW_CAPTCHA, and the request is blocked. 
        /// If unspecified, defaults to We have detected an increased number of attempts to access this webapp. To help us keep this webapp secure, please let us know 
        /// that you are not a robot by entering the text from captcha below.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 5000</para>
        /// </summary>
        public string CaptchaHeader { get; set; }

        /// <summary>
        /// The text to show in the footer when showing a CAPTCHA challenge when action is set to BLOCK, blockAction is set to SHOW_CAPTCHA, and the request is blocked. 
        /// If unspecified, default to Enter the letters and numbers as they are shown in image above.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 5000</para>
        /// </summary>
        public string CaptchaFooter { get; set; }

        /// <summary>
        /// The text to show on the label of the CAPTCHA challenge submit button when action is set to BLOCK, blockAction is set to SHOW_CAPTCHA, and the request is blocked. 
        /// If unspecified, defaults to Yes, I am human.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 100</para>
        /// </summary>
        public string CaptchaSubmitLabel { get; set; }
    }
}