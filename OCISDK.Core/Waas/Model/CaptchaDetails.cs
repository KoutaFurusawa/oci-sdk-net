using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// The settings of the CAPTCHA challenge. 
    /// If a specific URL should be accessed only by a human, a CAPTCHA challenge can be placed at the URL to protect the web application from bots.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class CaptchaDetails
    {
        /// <summary>
        /// The unique URL path at which to show the CAPTCHA challenge.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 8000</para>
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The amount of time before the CAPTCHA expires, in seconds. If unspecified, defaults to 300.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Maximum: 432000</para>
        /// </summary>
        public int SessionExpirationInSeconds { get; set; }

        /// <summary>
        /// The title used when displaying a CAPTCHA challenge. If unspecified, defaults to Are you human?
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 100</para>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The text to show in the header when showing a CAPTCHA challenge. 
        /// If unspecified, defaults to 'We have detected an increased number of attempts to access this website. 
        /// To help us keep this site secure, please let us know that you are not a robot by entering the text from the image below.'
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 5000</para>
        /// </summary>
        public string HeaderText { get; set; }

        /// <summary>
        /// The text to show in the footer when showing a CAPTCHA challenge. 
        /// If unspecified, defaults to 'Enter the letters and numbers as they are shown in the image above.'
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 5000</para>
        /// </summary>
        public string FooterText { get; set; }

        /// <summary>
        /// The text to show when incorrect CAPTCHA text is entered. If unspecified, defaults to The CAPTCHA was incorrect. Try again.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 5000</para>
        /// </summary>
        public string FailureMessage { get; set; }

        /// <summary>
        /// The text to show on the label of the CAPTCHA challenge submit button. If unspecified, defaults to Yes, I am human.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 100</para>
        /// </summary>
        public string SubmitLabel { get; set; }
    }
}
