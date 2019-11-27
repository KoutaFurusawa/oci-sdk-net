using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// A content access rule. An access rule specifies an action to take if a set of criteria is matched by a request.
    /// </summary>
    public class AccessRuleDetails
    {
        /// <summary>
        /// The unique name of the access rule.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The list of access rule criteria.
        /// <para>Required: yes</para>
        /// </summary>
        public List<AccessRuleCriteriaDetails> Criteria { get; set; }

        /// <summary>
        /// The action to take when the access criteria are met for a rule. If unspecified, defaults to ALLOW.
        /// <para>Required: yes</para>
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// The method used to block requests if action is set to BLOCK and the access criteria are met. If unspecified, defaults to SET_RESPONSE_CODE.
        /// <para>Required: no</para>
        /// </summary>
        public string BlockAction { get; set; }

        /// <summary>
        /// The response status code to return when action is set to BLOCK, blockAction is set to SET_RESPONSE_CODE, and the access criteria are met. If unspecified, defaults to 403.
        /// <para>Required: no</para>
        /// <para>Minimum: 100, Maximum: 999</para>
        /// </summary>
        public int? BlockResponseCode { get; set; }

        /// <summary>
        /// The message to show on the error page when action is set to BLOCK, blockAction is set to SHOW_ERROR_PAGE, and the access criteria are met. 
        /// If unspecified, defaults to 'Access to the website is blocked.'
        /// <para>Required: no</para>
        /// </summary>
        public string BlockErrorPageMessage { get; set; }

        /// <summary>
        /// The error code to show on the error page when action is set to BLOCK, blockAction is set to SHOW_ERROR_PAGE, and the access criteria are met. 
        /// If unspecified, defaults to 'Access rules'.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 5000</para>
        /// </summary>
        public string BlockErrorPageCode { get; set; }

        /// <summary>
        /// The description text to show on the error page when action is set to BLOCK, blockAction is set to SHOW_ERROR_PAGE, and the access criteria are met. 
        /// If unspecified, defaults to 'Access blocked by website owner. Please contact support.'
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 5000</para>
        /// </summary>
        public string BlockErrorPageDescription { get; set; }

        /// <summary>
        /// The list of challenges to bypass when action is set to BYPASS. If unspecified or empty, all challenges are bypassed.
        /// <para>Required: no</para>
        /// <para>Default: null</para>
        /// </summary>
        public List<string> BypassChallenges { get; set; }

        /// <summary>
        /// The target to which the request should be redirected, represented as a URI reference.
        /// <para>Required: no</para>
        /// <para>Default: null</para>
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// The response status code to return when action is set to REDIRECT.
        /// <para>Required: no</para>
        /// <para>Default: MOVED_PERMANENTLY</para>
        /// </summary>
        public string RedirectResponseCode { get; set; }
    }
}
